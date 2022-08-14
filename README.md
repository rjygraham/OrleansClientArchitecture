# Orleans.Cqrs

A quick/niave POC of what a clean architecture using ASP.NET Minimal APIs and Microsoft Orleans could look like with minimal plumbing.

Requirements:
1. Validation of incoming HTTP request
2. Mapping from HTTP model to domain object
3. Minimal extra code - both from "framework" side as well as application side

## Request Flow

HTTP [GET/POST] Request -> RequestProcessor -> RequestHandler -> (Validation (if registered), Mapping from model to domain object (if required), Hander ExecuteRequest) -> HTTP IResult Response

## Usage

Clone the repo run the following command from the root of the repo:

```bash
dotnet run --project ./src/Sample.Profile.Api.Host/Sample.Profile.Api.Host.csproj
```

Use your favorite HTTP testing tool to send a POST request:

```http
POST http://localhost:5000/profile
Content-Type: application/json

{
  "givenName": "Clark",
  "surname": "Kent",
  "dateOfBirth": "1987-05-03T00:00:00.00+00:00",
  "emailAddress": "clarkkent@example.com",
  "phoneNumber": "5555551234"
}
```

Copy the guid from the location header in the response and issue new GET request:

```http
GET http://localhost:5000/profile/f69abf28-db65-415f-bd8e-871134070272
```

To observe how everything works, place a breakpoint in ` Orleans.Cqrs.Core.RequestProcessor.ExecuteRequestAsync` of the `Orleans.Cqrs.Core` project

## Alternatives

Much of this solution could be replaced with an alternative like [MediatR](https://github.com/jbogard/MediatR), however, I wanted to do this as a thought experiment and here we are.

Similar Orleans solutions exist:

- [Orleans.Http](https://github.com/OrleansContrib/Orleans.Http)
- [Orleans.HttpGateway.AspNetCore](https://github.com/OrleansContrib/Orleans.HttpGateway.AspNetCore)
- [OCore](https://github.com/COCPORN/OCore)