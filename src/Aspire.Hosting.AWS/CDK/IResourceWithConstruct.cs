// Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.

using Aspire.Hosting.ApplicationModel;
using Constructs;

namespace Aspire.Hosting.AWS.CDK;

/// <summary>
/// Represents a resource that has an AWS CDK construct.
/// </summary>
public interface IResourceWithConstruct : IResource
{
    /// <summary>
    /// The AWS CDK construct
    /// </summary>
    IConstruct Construct { get; }
}
