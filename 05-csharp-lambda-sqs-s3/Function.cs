using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.SQS;
using Amazon.SQS.Model;
using Amazon.S3;
using Amazon.S3.Model;
using System.Text.Json;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

public class Function
{
    private readonly IAmazonSQS _sqsClient;
    private readonly IAmazonS3 _s3Client;
    private const string QueueUrl = "YOUR_SQS_QUEUE_URL";
    private const string BucketName = "YOUR_S3_BUCKET_NAME";

    public Function()
    {
        _sqsClient = new AmazonSQSClient();
        _s3Client = new AmazonS3Client();
    }

    public async Task<APIGatewayProxyResponse> FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
    {
        // Log the route path
        context.Logger.LogInformation($"Lambda invoked with route: {request.Path}");

        // Create a sample JSON payload
        var payload = new { Message = "Hello from Lambda!", Timestamp = DateTime.UtcNow };
        string jsonPayload = JsonSerializer.Serialize(payload);

        // Publish to SQS
        await PublishToSqs(jsonPayload);

        // Write to S3
        await WriteToS3(jsonPayload, context);

        return new APIGatewayProxyResponse
        {
            StatusCode = 200,
            Body = "Message published to SQS and written to S3 successfully"
        };
    }

    private async Task PublishToSqs(string message)
    {
        var sendMessageRequest = new SendMessageRequest
        {
            QueueUrl = QueueUrl,
            MessageBody = message
        };

        await _sqsClient.SendMessageAsync(sendMessageRequest);
    }

    private async Task WriteToS3(string content, ILambdaContext context)
    {
        var key = $"lambda-output-{DateTime.UtcNow:yyyy-MM-dd-HH-mm-ss}.json";

        var putObjectRequest = new PutObjectRequest
        {
            BucketName = BucketName,
            Key = key,
            ContentBody = content
        };

        await _s3Client.PutObjectAsync(putObjectRequest);
        context.Logger.LogInformation($"Object written to S3: s3://{BucketName}/{key}");
    }
}
