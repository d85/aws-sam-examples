exports.lambdaHandler = async (event, context) => {
  return event.queryStringParameters.foo
}
