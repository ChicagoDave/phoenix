using System.Net;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;

namespace phoenix.api;

public class UnfollowLambda
{
    /// <summary>
    /// Default constructor that Lambda will invoke.
    /// </summary>
    public UnfollowLambda()
    {
    }


    /// <summary>
    /// A Lambda function to respond to HTTP Get methods from API Gateway
    /// </summary>
    /// <param name="request"></param>
    /// <returns>The API Gateway response.</returns>
    public APIGatewayProxyResponse Post(APIGatewayProxyRequest request, ILambdaContext context)
    {
        context.Logger.LogInformation("Post Request\n");

        var response = new APIGatewayProxyResponse
        {
            StatusCode = (int)HttpStatusCode.OK,
            Body = "Hello AWS Serverless",
            Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
        };

        return response;
    }
}