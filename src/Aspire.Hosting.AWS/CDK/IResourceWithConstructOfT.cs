// Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.

using Constructs;

namespace Aspire.Hosting.AWS.CDK;

/// <inheritdoc cref="IResourceWithConstruct"/>
public interface IResourceWithConstruct<out T> : IResourceWithConstruct
    where T : IConstruct
{
    /// <inheritdoc cref="IResourceWithConstruct.Construct"/>
    new T Construct { get; }
}
