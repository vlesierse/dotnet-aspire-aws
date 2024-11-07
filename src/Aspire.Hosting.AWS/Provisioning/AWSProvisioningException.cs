// Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.

namespace Aspire.Hosting.AWS.Provisioning;

/// <summary>
/// Exception for errors provisioning AWS application resources
/// </summary>
/// <param name="message"></param>
/// <param name="innerException"></param>
public class AWSProvisioningException(string message, Exception? innerException = null) : Exception(message, innerException)
{
}
