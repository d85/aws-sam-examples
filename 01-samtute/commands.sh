# create an s3 bucket
aws s3 mb s3://dan-awssoa-code-sam

# package cloudformation help
aws cloudformation package help

# package cloudformation
# uploads code to s3 as zip
aws cloudformation package --s3-bucket dan-awssoa-code-sam --template-file template.yaml --output-template-file gen/template-generated.yaml
# sam package is same thing

# deploy
# creates changeset and then runs changeset
aws cloudformation deploy --template-file gen/template-generated.yaml --stack-name hello-world-sam --capabilities CAPABILITY_IAM
# In CloudFormation under Resources, this creates a lambda function and other resources such as iam role(s)
