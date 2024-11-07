// Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
using Constructs;

namespace Aspire.Hosting.AWS.CDK;

/// <summary>
/// Delegate for resolving outputs of a construct.
/// </summary>
/// <typeparam name="T">Construct type</typeparam>
public delegate string ConstructOutputDelegate<in T>(T construct) where T : IConstruct;
