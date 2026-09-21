---
uid: GQI_ICredentialProvider
description: "API reference for the ICredentialProvider interface, which retrieves credentials for GQI extension libraries."
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

Retrieves the username and password credentials identified by the configured name.

#### Parameters

- `string` `name`: The name of the credentials reference [granted to the extension library](xref:GQI_Extensions_Credentials#granting-credentials-to-an-extension-library).
- `CancellationToken` `cancellationToken`: A token that can be used to cancel the request.

#### Returns

A task whose result contains the requested [UsernamePasswordCredential](xref:GQI_UsernamePasswordCredential).

#### Exceptions

- `ArgumentNullException`: The name of the credentials reference is null.
- `GenIfException`: The extension library has not been granted access to the credentials with the specified name.
- `OperationCanceledException`: The operation is canceled.

### Task\<TokenCredential\> GetTokenCredential(string name, CancellationToken cancellationToken = default)

Retrieves the token credentials identified by the configured name.

#### Parameters

- `string` `name`: The name of the credentials reference [granted to the extension library](xref:GQI_Extensions_Credentials#granting-credentials-to-an-extension-library).
- `CancellationToken` `cancellationToken`: A token that can be used to cancel the request.

#### Returns

A task whose result contains the requested [TokenCredential](xref:GQI_TokenCredential).

#### Exceptions

- `ArgumentNullException`: The name of the credentials reference is null.
- `GenIfException`: The extension library has not been granted access to the credentials with the specified name.
- `OperationCanceledException`: The operation is canceled.
