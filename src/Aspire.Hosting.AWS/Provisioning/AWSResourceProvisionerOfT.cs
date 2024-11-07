// Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
namespace Aspire.Hosting.AWS.Provisioning;

internal interface IAWSResourceProvisioner
{
    Task GetOrCreateResourceAsync(IAWSResource resource, CancellationToken cancellationToken = default);
}

internal abstract class AWSResourceProvisioner<TResource> : IAWSResourceProvisioner
    where TResource : IAWSResource
{
    public Task GetOrCreateResourceAsync(
        IAWSResource resource,
        CancellationToken cancellationToken)
        => GetOrCreateResourceAsync((TResource)resource, cancellationToken);

    protected abstract Task GetOrCreateResourceAsync(TResource resource, CancellationToken cancellationToken);
}
