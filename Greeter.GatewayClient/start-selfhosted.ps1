dapr run `
    --app-id greeter-gatewayclient `
    --app-port 5244 `
    --app-protocol http `
    --dapr-http-port 3502 `
    --dapr-grpc-port 50002 `
    dotnet run