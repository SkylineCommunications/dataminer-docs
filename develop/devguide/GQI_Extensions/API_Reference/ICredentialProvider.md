---
uid: GQI_ICredentialProvider
---

# ICredentialProvider interface

## Definition

- Namespace: `Skyline.DataMiner.Core.GQI.Extensions`
- Assembly: `Skyline.DataMiner.Core.GQI.Extensions.dll`

Provides access to username and password credentials that have been granted to a GQI extension library.

Available from DataMiner 10.6.11/10.7.0 [CU0] onwards.

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

- `GenIfException`: The credential name is empty or the named credential has not been granted to the extension library.
- `OperationCanceledException`: The operation is canceled.
