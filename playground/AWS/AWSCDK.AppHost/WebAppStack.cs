// Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.

using Amazon.CDK;
using Amazon.CDK.AWS.DynamoDB;
using Constructs;
using Attribute = Amazon.CDK.AWS.DynamoDB.Attribute;

namespace AWSCDK.AppHost;

public class WebAppStackProps : StackProps;

public class WebAppStack : Stack
{
    public ITable Table { get; }

    public WebAppStack(Construct scope, string id, WebAppStackProps props)
        : base(scope, id, props)
    {
        Table = new Table(this, "Table", new TableProps
        {
            PartitionKey = new Attribute { Name = "id", Type = AttributeType.STRING },
            BillingMode = BillingMode.PAY_PER_REQUEST
        });
    }
}
