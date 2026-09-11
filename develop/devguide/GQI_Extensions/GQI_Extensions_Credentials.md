---
uid: GQI_Extensions_Credentials
keywords: GQI extension credentials
description: Learn how to grant and retrieve DataMiner Credentials Library username and password credentials in a GQI extension.
---

# Using credentials in GQI extensions

The Core GQI extension API can retrieve credentials from the [DataMiner Credentials Library](xref:Credentials_Library).

Currently, the API already supports *Username and password credentials*. More credential types may be added in the future.

The credential functionality within DataMiner is available from 10.7.0 [CU0]/10.6.10.
The GQI functionality is available from DataMiner Web 10.5.0 [CU20]/10.6.0 [CU8]/10.6.11 onwards when using version 1.5.0 or later of the `Skyline.DataMiner.Core.GQI.Extensions` NuGet package. <!-- RN 46279 -->

> [!IMPORTANT]
> Credentials are only available to an extension library when they have been explicitly granted to that library.

## Granting a credential to an extension library

1. Add a credential of type *Username and password credentials* to the DataMiner Credentials Library in DataMiner Cube. For more information, see [Credentials Library](xref:Credentials_Library).

2. In the Automation module in DataMiner Cube, configure the credential for the Automation Script that contains the extension library. In the script's *CREDENTIALS* section, declare the credential as described in [Using credentials in an automation script](xref:Using_credentials_in_an_automation_script#declaring-a-set-of-credentials). Give the credential reference a name, such as `MyUserNamePasswordCredential`, and select the corresponding credential from the Credentials Library.

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

## Retrieving credentials

Call `GetUsernamePasswordCredential` with the name configured for the credential reference:

```csharp
private UsernamePasswordCredential GetCredential()
{
    return _credentialProvider
        .GetUsernamePasswordCredential("MyUserNamePasswordCredential")
        .GetAwaiter()
        .GetResult();
}
```

> [!NOTE]
> Because GQI extension lifecycle methods are synchronous and `GetUsernamePasswordCredential` returns a task, you might need to block the thread to await the result with `.GetAwaiter().GetResult()`. If you call it from an asynchronous context, you can just await the task instead.

> [!TIP]
> To reduce latency and server load, retrieve the credential once and cache it before fetching data instead of requesting it for every row or page.

> [!WARNING]
> Treat the values retrieved from the credential library as secrets: never log them, include them in query results, or add them to exception messages.
