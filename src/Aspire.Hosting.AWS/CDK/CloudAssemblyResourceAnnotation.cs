// Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.

using System.Diagnostics;
using Amazon.CDK.CXAPI;
using Aspire.Hosting.ApplicationModel;

namespace Aspire.Hosting.AWS.CDK;

/// <summary>
/// Annotations that stores the <see cref="CloudFormationStackArtifact"/> to the stack resource.
/// </summary>
[DebuggerDisplay("Type = {GetType().Name,nq}, StackName = {StackArtifact.StackName}")]
internal sealed class CloudAssemblyResourceAnnotation(CloudFormationStackArtifact stackArtifact) : IResourceAnnotation
{

    public AssetManifestArtifact? AssetsArtifact { get; } = stackArtifact.Dependencies.OfType<AssetManifestArtifact>().FirstOrDefault();

    public CloudFormationStackArtifact StackArtifact { get; } = stackArtifact;    
}
