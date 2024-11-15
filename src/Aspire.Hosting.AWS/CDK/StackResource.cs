// Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.

using Amazon.CDK;
using Amazon.S3;
using Aspire.Hosting.AWS.CloudFormation;
using Constructs;
using Stack = Amazon.CDK.Stack;

namespace Aspire.Hosting.AWS.CDK;

/// <inheritdoc cref="Aspire.Hosting.AWS.CDK.IStackResource" />
internal class StackResource(string name, Stack stack) : CloudFormationTemplateResource(name, stack.StackName, stack.GetTemplatePath()), IStackResource
{
    /// <inheritdoc/>
    public Stack Stack { get; } = stack;

    /// <inheritdoc/>
    public IConstruct Construct => Stack;

    /// <summary>
    /// The AWS CDK App the stack belongs to. This is needed for building the AWS CDK app tree.
    /// </summary>
    public App App => (App)Stack.Node.Root;
    
    /// <inheritdoc/>
    public IAmazonS3? S3Client { get; set; }
}

/// <inheritdoc cref="Aspire.Hosting.AWS.CDK.StackResource" />
internal sealed class StackResource<T>(string name, T stack) : StackResource(name, stack), IStackResource<T>
    where T : Stack
{
    public new T Stack { get; } = stack;
    public new T Construct => Stack;
}
