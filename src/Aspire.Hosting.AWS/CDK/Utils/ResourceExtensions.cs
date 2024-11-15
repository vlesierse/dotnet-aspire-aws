// Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.

using System.Diagnostics.CodeAnalysis;
using Amazon.CDK.CXAPI;
using Aspire.Hosting.ApplicationModel;

namespace Aspire.Hosting.AWS.CDK;

internal static class ResourceExtensions
{
    /// <summary>
    /// Resolves a <see cref="CloudFormationStackArtifact"/> from a resource.
    /// </summary>
    /// <param name="resource"></param>
    /// <param name="stackArtifact"></param>
    /// <returns>False when no <see cref="CloudAssemblyResourceAnnotation"/> is not found as annotation of the resource.</returns>
    public static bool TryGetStackArtifact(this IStackResource resource, [NotNullWhen(true)] out CloudFormationStackArtifact? stackArtifact)
    {
        stackArtifact = default;
        if (!resource.TryGetAnnotationsOfType<CloudAssemblyResourceAnnotation>(out var annotations))
        {
            return false;
        }
        stackArtifact = annotations.First().StackArtifact;
        return true;
    }

    /// <summary>
    /// Resolves a <see cref="AssetManifestArtifact"/> from a resource.
    /// </summary>
    /// <param name="resource"></param>
    /// <param name="assetsArtifact"></param>
    /// <returns>False when no <see cref="CloudAssemblyResourceAnnotation"/> is not found as annotation of the resource.</returns>
    public static bool TryGetAssetsArtifact(this IStackResource resource, [NotNullWhen(true)] out AssetManifestArtifact? assetsArtifact)
    {
        assetsArtifact = default;
        if (!resource.TryGetAnnotationsOfType<CloudAssemblyResourceAnnotation>(out var annotations))
        {
            return false;
        }
        assetsArtifact = annotations.First().AssetsArtifact;
        return assetsArtifact != null;
    }
}
