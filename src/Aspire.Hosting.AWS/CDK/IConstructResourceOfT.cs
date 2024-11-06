// Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.

using Constructs;

namespace Aspire.Hosting.AWS.CDK;

/// <inheritdoc cref="IConstructResource"/>
public interface IConstructResource<out T> : IConstructResource, IResourceWithConstruct<T> where T : IConstruct;
