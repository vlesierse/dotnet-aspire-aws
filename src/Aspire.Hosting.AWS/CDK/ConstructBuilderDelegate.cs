// Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.

using Constructs;

namespace Aspire.Hosting.AWS.CDK;

/// <summary>
/// Delegate for building an AWS CDK construct
/// </summary>
/// <typeparam name="T">Construct type</typeparam>
public delegate T ConstructBuilderDelegate<out T>(Construct scope) where T : IConstruct;
