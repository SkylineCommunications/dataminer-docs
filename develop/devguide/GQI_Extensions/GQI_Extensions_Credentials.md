---
uid: GQI_Extensions_Credentials
keywords: GQI extension credentials
description: Learn how to grant and retrieve Credentials Library credentials in GQI extensions. Currently supported types are "username and password" and "token".
---

# Using credentials in GQI extensions

The Core GQI extension API can retrieve credentials from the [DataMiner Credentials Library](xref:Credentials_Library).

The API supports the following credential types:

- *Username and password*: Contains a username and password and is returned as a [UsernamePasswordCredential](xref:GQI_UsernamePasswordCredential).
- *Token*: Contains an access token and is returned as a [TokenCredential](xref:GQI_TokenCredential).

The credential functionality within DataMiner is available from 10.7.0 [CU0]/10.6.10 onwards.
The GQI functionality is available from DataMiner Web 10.5.0 [CU20]/10.6.0 [CU8]/10.6.11 onwards when using version 1.5.0 or later of the `Skyline.DataMiner.Core.GQI.Extensions` NuGet package. <!-- RN 46279 -->

> [!IMPORTANT]
> Credentials are only available to an extension library when they have been explicitly [granted to the library](#granting-a-credential-to-an-extension-library).

## Granting a credential to an extension library

Configure the credential in the [Credentials Library](xref:Credentials_Library), then declare a reference to it in the *CREDENTIALS* section of the automation script that contains the extension library. For the procedure, see [Declaring a set of credentials](xref:Using_credentials_in_an_automation_script#declaring-a-set-of-credentials).

Use the name assigned to the credential reference when requesting the credential in the GQI extension.

The type of the credential reference must match the method used to retrieve it:

- `UserNameAndPassword`: Retrieve the credential with `GetUsernamePasswordCredential`.
- `Token`: Retrieve the credential with `GetTokenCredential`.

## Injecting the credential provider

The `ICredentialProvider` service is registered automatically by GQI. Request it as a constructor parameter in an ad hoc data source or custom operator:

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

## Retrieving a username and password credential

Call `GetUsernamePasswordCredential` with the name configured for the *Username and password* credential reference:

```csharp
private UsernamePasswordCredential GetUsernamePasswordCredential()
{
    return _credentialProvider
        .GetUsernamePasswordCredential("MyUserNamePasswordCredential")
        .GetAwaiter()
        .GetResult();
}
```

## Retrieving a token credential

Call `GetTokenCredential` with the name configured for the *Token* credential reference:

```csharp
private TokenCredential GetTokenCredential()
{
    return _credentialProvider
        .GetTokenCredential("MyTokenCredential")
        .GetAwaiter()
        .GetResult();
}
```

> [!NOTE]
> Because GQI extension lifecycle methods are synchronous and the credential retrieval methods return a task, you might need to block the thread to await the result with `.GetAwaiter().GetResult()`. If you call them from an asynchronous context, you can just await the task instead.

> [!TIP]
> To reduce latency and server load, retrieve the credential once and cache it before fetching data instead of requesting it for every row or page.

> [!WARNING]
> Treat the values retrieved from the Credentials Library as secrets: never log them, include them in query results, or add them to exception messages.
