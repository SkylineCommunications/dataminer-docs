---
uid: GQI_ICredentialProvider
description: Reference for the ICredentialProvider interface, which retrieves username and password credentials granted to a GQI extension library.
---

# ICredentialProvider interface

## Definition

- Namespace: `Skyline.DataMiner.Core.GQI.Extensions`
- Assembly: `Skyline.DataMiner.Core.GQI.Extensions.dll`

Provides access to username and password credentials that have been granted to a GQI extension library.

Available from DataMiner Web 10.5.0 [CU20]/10.6.0 [CU8]/10.6.11 onwards when using version 1.5.0 or later of the `Skyline.DataMiner.Core.GQI.Extensions` NuGet package. <!-- RN 46279 -->

> [!TIP]
> See [Using credentials in GQI extensions](xref:GQI_Extensions_Credentials) for information about granting and retrieving credentials.

## Methods

### Task\<UsernamePasswordCredential\> GetUsernamePasswordCredential(string name, CancellationToken cancellationToken = default)

Retrieves a username and password credential by its configured name.

#### Parameters

- `string` `name`: The name of the credential reference granted to the extension library.
- `CancellationToken` `cancellationToken`: A token that can be used to cancel the credential request.

#### Returns

A task whose result contains the requested [UsernamePasswordCredential](xref:GQI_UsernamePasswordCredential).

#### Exceptions

- `ArgumentNullException`: The credential name is null.
- `GenIfException`: The named credential has not been granted to the extension library.
- `OperationCanceledException`: The operation is canceled.
