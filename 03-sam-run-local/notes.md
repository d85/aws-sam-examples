# Docker

start docker
```sh
sudo systemctl start docker
```

stop docker
```sh
sudo systemctl stop docker
```

run container
```sh
docker run hello-world
```

# SAM local invoke

Invoke lambda function
```sh
sam local invoke -e ./lambda/lambda_event.json LambdaDemoFunction
```

```sh
No current session found, using default AWS::AccountId
Invoking lambda.lambdaHandler (nodejs18.x)
Local image is up-to-date
Using local image: public.ecr.aws/lambda/nodejs:18-rapid-x86_64.
                
Mounting ~/code/aws-sam-examples/03-sam-run-local/lambda as /var/task:ro,delegated, inside runtime container
START RequestId: c72da92f-0b5b-494e-858e-b49389a3479b Version: $LATEST
END RequestId: dd27715f-37d4-487c-9c29-76763723d6f6
REPORT RequestId: dd27715f-37d4-487c-9c29-76763723d6f6
Init Duration: 0.02 ms  Duration: 67.57 ms      Billed Duration: 68 ms  Memory Size: 128 MB  Max Memory Used: 128 MB

"lambda done. id: 1123, data: this is the data"
```

Invoke lambda function through API Gateway
```sh
sam local invoke -e ./apigateway/apigateway_event.json ApiGatewayFunction
```

```sh
Invoking apigateway.lambdaHandler (nodejs18.x)
Local image is up-to-date                                         
Using local image: public.ecr.aws/lambda/nodejs:18-rapid-x86_64.
                                                                                                                           
Mounting ~/code/aws-sam-examples/03-sam-run-local/apigateway as /var/task:ro,delegated, inside runtime container                     
START RequestId: 19d90ed4-0758-4b22-b8f1-df60653a1f83 Version: $LATEST
END RequestId: 7eb9c2bf-f581-4943-b6b5-c6af39f4c892
REPORT RequestId: 7eb9c2bf-f581-4943-b6b5-c6af39f4c892  Init Duration: 0.04 ms  Duration: 67.93 ms      Billed Duration: 68 ms  Memory Size: 128 MB  Max Memory Used: 128 MB

"bar"
```

API Gateway only
```sh
sam local start-api
```