---
uid: GQI_ICredentialProvider
description: "API reference for the ICredentialProvider interface used to retrieve username/password and token credentials granted to DataMiner GQI extension libraries."
---

# ICredentialProvider interface

## Definition

- Namespace: `Skyline.DataMiner.Core.GQI.Extensions`
- Assembly: `Skyline.DataMiner.Core.GQI.Extensions.dll`

Provides access to credentials that have been granted to a GQI extension library.

Available starting from DataMiner Web 10.5.0 [CU20]/10.6.0 [CU8]/10.6.11 and API version 1.5.0. <!-- RN 46279 -->

> [!TIP]
> See [Using credentials in GQI extensions](xref:GQI_Extensions_Credentials) for information about granting and retrieving credentials.

## Methods

### Task\<UsernamePasswordCredential\> GetUsernamePasswordCredential(string name, CancellationToken cancellationToken = default)

Retrieves a set of username and password credentials by its configured name.

#### Parameters

- `string` `name`: The name of the credentials reference [granted to the extension library](xref:GQI_Extensions_Credentials#granting-a-credential-to-an-extension-library).
- `CancellationToken` `cancellationToken`: A token that can be used to cancel the credentials request.

#### Returns

A task whose result contains the requested [UsernamePasswordCredential](xref:GQI_UsernamePasswordCredential).

#### Exceptions

- `ArgumentNullException`: The credentials name is null.
- `GenIfException`: The named credential has not been granted to the extension library.
- `OperationCanceledException`: The operation is canceled.

### Task\<TokenCredential\> GetTokenCredential(string name, CancellationToken cancellationToken = default)

Retrieves a set of token credentials by its configured name.

#### Parameters

- `string` `name`: The name of the credentials reference [granted to the extension library](xref:GQI_Extensions_Credentials#granting-a-credential-to-an-extension-library).
- `CancellationToken` `cancellationToken`: A token that can be used to cancel the credentials request.

#### Returns

A task whose result contains the requested [TokenCredential](xref:GQI_TokenCredential).

#### Exceptions

- `ArgumentNullException`: The credentials name is null.
- `GenIfException`: The named credential has not been granted to the extension library.
- `OperationCanceledException`: The operation is canceled.
