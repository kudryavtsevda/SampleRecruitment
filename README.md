# SampleRecuitment
## General description

* The solution is created via VS2019 using .NET 5. It is a small [API](https://github.com/kudryavtsevda/SampleRecruitment/tree/main/Recruitment.Api) with one main feature: md5 hash calculation.
* There are no controllers created explicitly. Instead, [CommandQuery](https://github.com/hlaueriksson/CommandQuery/tree/master/src/CommandQuery) and [CommandQuery.AspNetCore](https://github.com/hlaueriksson/CommandQuery/tree/master/src/CommandQuery.AspNetCore) libraries are used in accordance with tech requirements.
* [Client](https://github.com/kudryavtsevda/SampleRecruitment/tree/main/Recruitment.Client) leverages [Flurl](https://github.com/tmenier/Flurl) package to connect out hash calculation endpoint.
* [Contracts](https://github.com/kudryavtsevda/SampleRecruitment/tree/main/Recruitment.Contracts) contains shared classes which are used both by [Api](https://github.com/kudryavtsevda/SampleRecruitment/tree/main/Recruitment.Api) and [ApiClient](https://github.com/kudryavtsevda/SampleRecruitment/tree/main/Recruitment.Client).
It consists of only one class CalculateHashCommand with two required fields: login and password.
* [CommandHandlers](https://github.com/kudryavtsevda/SampleRecruitment/tree/main/Recruitment.CommandHandlers) contains only one handler which concatenates login and password fields and call md5 hash function.
* [DomainLogic](https://github.com/kudryavtsevda/SampleRecruitment/tree/main/Recruitment.DomainLogic) consists of classes and interfaces for md5 hash evaluation. It receives string and apply hash function.
* [Tests](https://github.com/kudryavtsevda/SampleRecruitment/tree/main/Recruitment.Tests) uses [Moq](https://github.com/moq/moq) for mocking. It covers Client, Handler and MD5 hash calculation based on [RFC1321](https://datatracker.ietf.org/doc/html/rfc1321) specification.
* [IntegrationTests](https://github.com/kudryavtsevda/SampleRecruitment/tree/main/Recruitment.IntegrationTests) checks the main api and health check endpoints.

## The solution structure
![image](https://user-images.githubusercontent.com/4447809/134943499-c08ffb5f-a62e-43a5-bfd1-36028855d57b.png)


## Health check api
There are additional endpoints for health checks. It is possible to see the result of health checks on UI client (screenshot below).
![image](https://user-images.githubusercontent.com/4447809/134942411-37ae1cd0-f0d8-463d-8c8a-b3e996da78a1.png)

## Swagger
Swagger is added to provide ability to check the main endpoint (screenshot below)
![image](https://user-images.githubusercontent.com/4447809/134942716-24738e7e-72b1-4dc6-aa8d-ae4d3e87fe30.png)
