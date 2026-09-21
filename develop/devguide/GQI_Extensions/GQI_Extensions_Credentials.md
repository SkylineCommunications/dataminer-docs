---
uid: GQI_Extensions_Credentials
keywords: GQI extension credentials
description: Learn how to grant and retrieve Credentials Library credentials in GQI extensions. The currently supported types are "username and password" and "token".
---

# Using credentials in GQI extensions

## Prerequisites

- DataMiner 10.7.0 [CU0]/10.6.10 or later for the Credentials Library. <!-- RN44282 -->
- DataMiner Web 10.5.0 [CU20]/10.6.0 [CU8]/10.6.11 or later. <!-- RN 46279 --> <!-- RN46526 -->
- [GQI extensions API](xref:GQI_Extension_API) version 1.5.0 or later. <!-- RN 46279 --> <!-- RN46526 -->

## Supported types of credentials

The Core GQI extension API can retrieve credentials from the [DataMiner Credentials Library](xref:Credentials_Library).

The API currently supports the following types of credentials:

- *Username and password credentials*: Contain a username and password and are returned as a [UsernamePasswordCredential](xref:GQI_UsernamePasswordCredential).
- *Token credentials*: Contain an access token and are returned as a [TokenCredential](xref:GQI_TokenCredential).

## Granting credentials to an extension library

> [!IMPORTANT]
> Credentials are only available to an extension library when they have been explicitly granted to the library.

Configure a set of credentials in the [Credentials Library](xref:Credentials_Library), then declare a reference to it in the *CREDENTIALS* section of the automation script that contains the extension library. For the procedure, see [Declaring a set of credentials](xref:Using_credentials_in_an_automation_script#declaring-a-set-of-credentials).

Use the name assigned to the credentials reference when requesting the corresponding credentials in the GQI extension.

The type of the credentials reference must match the method used to retrieve the credentials:

- `UserNameAndPassword`: Retrieve the credentials with `GetUsernamePasswordCredential`.
- `Token`: Retrieve the credentials with `GetTokenCredential`.

## Injecting the credential provider

The `ICredentialProvider` service is registered automatically by GQI. Request it as a constructor parameter in an ad hoc data source, custom operator, or [GQI service](xref:GQI_Extensions_Services):

```csharp
using System;
using Skyline.DataMiner.Core.GQI.Extensions;

public sealed class ExternalDataSource : IGQIDataSource
{
    private readonly ICredentialProvider _credentialProvider;

    public ExternalDataSource(ICredentialProvider credentialProvider)
    {
        _credentialProvider = credentialProvider;
    }

    // Implement the IGQIDataSource lifecycle methods.
}
```

## Retrieving credentials

> [!NOTE]
> Because GQI extension lifecycle methods are synchronous and the credential retrieval methods return a task, you might need to block the thread to await the result with `.GetAwaiter().GetResult()`. If you call them from an asynchronous context, you can just await the task instead.

> [!TIP]
> To reduce latency and server load, retrieve the credentials once and cache them before fetching data instead of requesting them for every row or page.

> [!WARNING]
> Treat the values retrieved from the Credentials Library as secrets: never log them, include them in query results, or add them to exception messages.

### Retrieving username and password credentials

Call `GetUsernamePasswordCredential` with the name configured for the *Username and password* credentials reference:

```csharp
private UsernamePasswordCredential GetUsernamePasswordCredential()
{
    return _credentialProvider
        .GetUsernamePasswordCredential("MyUserNamePasswordCredential")
        .GetAwaiter()
        .GetResult();
}
```

### Retrieving token credentials

Call `GetTokenCredential` with the name configured for the *Token* credentials reference:

```csharp
private TokenCredential GetTokenCredential()
{
    return _credentialProvider
        .GetTokenCredential("MyTokenCredential")
        .GetAwaiter()
        .GetResult();
}
```
