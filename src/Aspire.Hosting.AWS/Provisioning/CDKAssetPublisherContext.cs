using Amazon.SecurityToken;
using Amazon.SecurityToken.Model;

namespace Aspire.Hosting.AWS.Provisioning;

#pragma warning disable CS9113 // Parameter is unread.
internal class CDKAssetPublisherContext(IAmazonSecurityTokenService stsClient)
#pragma warning restore CS9113 // Parameter is unread.
{
    public Task<string> ReplacePlaceholders(string value)
    {
        return Task.FromResult(value);
    }
}