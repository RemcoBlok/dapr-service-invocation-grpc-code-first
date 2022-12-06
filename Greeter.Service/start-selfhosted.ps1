dapr run `
    --app-id greeter-service `
    --app-port 5281 `
    --app-protocol grpc `
    --dapr-http-port 3501 `
    --dapr-grpc-port 50001 `
    dotnet run