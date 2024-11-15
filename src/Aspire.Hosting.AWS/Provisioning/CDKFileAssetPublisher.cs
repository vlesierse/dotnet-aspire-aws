// Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.

using Amazon.CDK.CloudAssembly.Schema;
using Amazon.S3;
using Microsoft.Extensions.Logging;

namespace Aspire.Hosting.AWS.Provisioning;

#pragma warning disable CS9113 // Parameter is unread.
public class CDKFileAssetPublisher(IAmazonS3 s3Client, ILogger logger)
#pragma warning restore CS9113 // Parameter is unread.
{
    public Task Publish(string id, IFileAsset asset)
    {
        return Task.WhenAll(asset.Destinations.Select(destination =>
        {
            logger.LogInformation("Publishing file asset {Id} to {BucketName}", id, destination.Key);
            return Task.CompletedTask;
        }));
    }
}