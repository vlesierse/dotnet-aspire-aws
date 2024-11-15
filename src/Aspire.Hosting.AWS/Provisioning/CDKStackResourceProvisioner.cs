// Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.

using Amazon.CDK.CloudAssemblySchema;
using Amazon.CloudFormation;
using Amazon.Runtime;
using Amazon.S3;
using Aspire.Hosting.ApplicationModel;
using Aspire.Hosting.AWS.CDK;
using Microsoft.Extensions.Logging;

namespace Aspire.Hosting.AWS.Provisioning;

internal sealed class CDKStackResourceProvisioner(
    ResourceLoggerService loggerService,
    ResourceNotificationService notificationService)
    : CloudFormationTemplateResourceProvisioner<StackResource>(loggerService, notificationService)
{
    protected override async Task GetOrCreateResourceAsync(StackResource resource, CancellationToken cancellationToken)
    {
        var logger = LoggerService.GetLogger(resource);
        await ProvisionStackAssetsAsync(resource, logger).ConfigureAwait(false);
        await base.GetOrCreateResourceAsync(resource, cancellationToken).ConfigureAwait(false);
    }

    private static Task ProvisionStackAssetsAsync(StackResource resource, ILogger logger)
    {
        // Currently CDK Stack Assets like S3 and Container images are not supported. When a stack contains those assets
        // we stop provisioning as it can introduce unwanted issues.
        if (!resource.TryGetAssetsArtifact(out var artifact))
        {
            return Task.CompletedTask;
        }

        var fileAssetPublisher = new CDKFileAssetPublisher(GetS3Client(resource), logger);
        var imageAssetPublisher = new CDKImageAssetPublisher(logger);
        // Publish all assets in parallel
        var fileAssets = artifact.Contents.Files?.Values ?? [];
        var imageAssets = artifact.Contents.DockerImages?.Values ?? [];
        
        return Task.CompletedTask;
    }

    protected override void HandleTemplateProvisioningException(Exception ex, StackResource resource, ILogger logger)
    {
        if (ex.InnerException is AmazonCloudFormationException inner && inner.Message.StartsWith(@"Unable to fetch parameters [/cdk-bootstrap/"))
        {
            logger.LogError("The environment doesn't have the CDK toolkit stack installed. Use 'cdk boostrap' to setup your environment for use AWS CDK with Aspire");
        }
    }
    
    private static IAmazonS3 GetS3Client(IStackResource resource)
    {
        if (resource.S3Client != null)
        {
            return resource.S3Client;
        }

        try
        {
            AmazonS3Client client;
            if (resource.AWSSDKConfig != null)
            {
                var config = resource.AWSSDKConfig.CreateServiceConfig<AmazonS3Config>();

                var awsCredentials = FallbackCredentialsFactory.GetCredentials(config);
                client = new AmazonS3Client(awsCredentials, config);
            }
            else
            {
                client = new AmazonS3Client();
            }

            client.BeforeRequestEvent += SdkUtilities.ConfigureUserAgentString;

            return client;
        }
        catch (Exception e)
        {
            throw new AWSProvisioningException("Failed to construct AWS S3 service client to provision AWS resources.", e);
        }
    }
}
