[![](https://img.shields.io/nuget/v/soenneker.unified.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.unified.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.unified.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.unified.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.unified.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.unified.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.unified.httpclients/codeql.yml?style=for-the-badge&label=CodeQL)](https://github.com/soenneker/soenneker.unified.httpclients/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Unified.HttpClients

Provides a cached `HttpClient` configured for the Unified API with workspace-token authentication.

## Installation

```bash
dotnet add package Soenneker.Unified.HttpClients
```

## Configuration

```json
{
  "Unified": {
    "ApiKey": "your-workspace-api-token"
  }
}
```

The default API URL is `https://api.unified.to/`. Set `Unified:ClientBaseUrl` to `https://api-eu.unified.to/` or `https://api-au.unified.to/` when the workspace belongs to another data region.

## Registration

```csharp
using Soenneker.Unified.HttpClients.Registrars;

services.AddUnifiedOpenApiHttpClientAsSingleton();
```

Scoped registration is available through `AddUnifiedOpenApiHttpClientAsScoped()`. Each provider instance owns its cached client and removes only that client when disposed.

## Usage

```csharp
using Soenneker.Unified.HttpClients.Abstract;

public sealed class UnifiedApiCaller
{
    private readonly IUnifiedOpenApiHttpClient _clients;

    public UnifiedApiCaller(IUnifiedOpenApiHttpClient clients)
    {
        _clients = clients;
    }

    public async ValueTask<HttpResponseMessage> GetIntegrations(
        string workspaceId,
        CancellationToken cancellationToken)
    {
        HttpClient client = await _clients.Get(cancellationToken);
        string id = Uri.EscapeDataString(workspaceId);

        return await client.GetAsync(
            $"unified/integration/workspace?workspace_id={id}",
            cancellationToken);
    }
}
```

Requests include `Authorization: Bearer <ApiKey>` by default. The workspace token can access all connections in the workspace, so keep it in server-side secret storage and never send it to a browser or client application.
