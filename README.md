[![](https://img.shields.io/nuget/v/soenneker.intercom.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.intercom.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.intercom.openapiclient/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.intercom.openapiclient/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.intercom.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.intercom.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.intercom.openapiclient/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.intercom.openapiclient/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Intercom.OpenApiClient

Call Intercom endpoints through a Kiota-generated client with typed request builders and models.

## Install

```bash
dotnet add package Soenneker.Intercom.OpenApiClient
```

## Create a client

```csharp
using System.Net.Http.Headers;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Intercom.OpenApiClient;

var httpClient = new HttpClient
{
    BaseAddress = new Uri("https://api.intercom.io/")
};
httpClient.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", accessToken);

var adapter = new HttpClientRequestAdapter(
    new AnonymousAuthenticationProvider(),
    httpClient: httpClient);

var client = new IntercomOpenApiClient(adapter);
```

The `HttpClient` supplies authentication, so the Kiota adapter uses anonymous authentication. Reuse the transport rather than constructing one per request, and dispose it when its owning application component shuts down.

For application registration, lazy client reuse, and coordinated transport ownership, use `Soenneker.Intercom.OpenApiClientUtil` instead of constructing the generated client directly.

## Call an endpoint

```csharp
using Soenneker.Intercom.OpenApiClient.Models;

AdminList? admins = await client.Admins.GetAsync(
    cancellationToken: cancellationToken);
```

Top-level properties such as `Contacts`, `Companies`, `Conversations`, `Articles`, and `Admins` expose the generated request builders. Types under `Soenneker.Intercom.OpenApiClient.Models` represent request and response bodies.

HTTP failures are surfaced through Kiota exceptions. Nullable results indicate that an endpoint returned no response body.

This repository contains generated code. Put reusable helpers and behavior changes in a separate package so regeneration does not overwrite them.
