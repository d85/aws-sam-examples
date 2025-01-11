From: https://docs.aws.amazon.com/serverless-application-model/latest/developerguide/serverless-getting-started-hello-world.html

# Step 1 - Download a sample application
```sh
sam init --runtime python3.10
```

# Step 2 - Build your application
```sh
cd sam-app
sam build
```

# Step 3 - Package your application (what was actually done)
```sh
sam deploy --guided
```

# Step 3 - Package your application
```sh
sam package --output-template packaged.yaml --s3-bucket TODO --region ap-southeast-2
```

# Step 4 - Deploy your application
```sh
sam deploy --template-file packaged.yaml --capabilities CAPABILITY_IAM --stack-name aws-sam-getting-started --region ap-southeast-2
```