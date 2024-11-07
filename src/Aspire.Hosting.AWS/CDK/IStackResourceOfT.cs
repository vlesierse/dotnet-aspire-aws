// Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.

using Amazon.CDK;

namespace Aspire.Hosting.AWS.CDK;

/// <inheritdoc cref="IStackResource"/>
public interface IStackResource<out T> : IStackResource, IResourceWithConstruct<T>
    where T : Stack
{
    /// <summary>
    /// The AWS CDK stack
    /// </summary>
    new T Stack { get; }
}
