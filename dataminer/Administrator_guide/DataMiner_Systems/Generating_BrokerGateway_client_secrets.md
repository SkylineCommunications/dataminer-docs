---
uid: Generating_BrokerGateway_client_secrets
---

# Generating BrokerGateway client secrets

From DataMiner 10.5.0 [CU13]/10.6.0 [CU1]/10.6.4 onward, it is possible to generate BrokerGateway client secrets. These are designed for DxMs or other clients connecting to the DataMiner NATS bus from a server without a local DataMiner installation. The secrets enable secure authentication with BrokerGateway, which then provides the necessary connection details for the NATS bus.

Using internal BrokerGateway Administrator keys for these connections is discouraged, as these keys may be refreshed during cluster maintenance or because of other actions. By contrast, user-generated client secrets persist throughout the cluster's lifecycle and are immediately distributed to all BrokerGateway instances for cluster-wide availability.

Common examples of clients requiring this setup include the [Data Aggregator DxM](xref:Data_Aggregator_DxM) and [Dashboard Gateway](xref:Dashboard_Gateway_installation).

> [!IMPORTANT]
> Using client secrets prevents the root certificate authority from being cycled during DataMiner Agent removals or NATSRepair calls. This is done to ensure that external clients maintain stable connectivity with the cluster, without having to change credentials or trusted root certificates.

## API calls

API calls are available to manage the BrokerGateway client secrets.

| Method | Route |  Description |
| --- | --- | --- |
| `POST` | `/api/clientSecret/generate` | Generates a new random API key associated with a specific client name. The key is returned in the response body. |
| `DELETE` | `/api/clientSecret/delete` | Deletes the client secret associated with the specified `clientName` argument. |
| `GET` | `/api/clientSecret/list` | Retrieves a list of all existing client secrets with their respective names. **Note:** The sensitive key values are redacted in the response (e.g., `abcd****************`) for security purposes. |

In order to perform these API calls on a BrokerGateway instance, you will need the Administrator key. You can find this key in the file `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\appsettings.runtime.json`. In the file, look for an entry in `APIKeys` with the name *Administrator*. The *key* property is the administrator key.

You can execute the API calls by calling the REST API via PowerShell, as detailed below.

### Generating a client secret

Executing the following PowerShell script will generate a new client secret, which will be returned in `$response`.

```powershell
$clientname = "external client" # The name of the client secret to generate.
$uri = "..." # Change to FQDN of the Agent.
$adminKey = "..." # The administrator API key for the BrokerGateway instance of $uri.

$headers = New-Object "System.Collections.Generic.Dictionary[[String],[String]]"
$headers.Add("BrokerGateway-Api-Key", $adminKey)

$response = Invoke-RestMethod "https://$uri/BrokerGateway/api/clientSecret/generate?clientName=$clientName" -Method 'POST' -Headers $headers -ContentType 'text/plain'
$response
```

Client secret names need to be unique. These are case-sensitive.

It is not possible to overwrite a client secret with a new key. Instead, you will need to remove the secret and recreate it.

> [!NOTE]
> Client secrets are not automatically revoked. It is up to the user to delete these again.

### Deleting a client secret

Executing the following PowerShell script will remove a chosen client secret. The name is case-sensitive.

```powershell
$clientname = "external client" # The name of the client secret to remove.
$uri = "..." # Change to FQDN of the Agent.
$adminKey = "..." # The administrator API key for the BrokerGateway instance of $uri.

$headers = New-Object "System.Collections.Generic.Dictionary[[String],[String]]"
$headers.Add("BrokerGateway-Api-Key", $adminKey)

Invoke-RestMethod "https://$uri/BrokerGateway/api/clientSecret/delete?clientName=$clientName" -Method 'DELETE' -Headers $headers
```

### Listing all generated client secrets

This API call lists up all generated client secrets. The keys are redacted for security reasons. Only the first four characters will be visible.

```powershell
$uri = "..." # Change to FQDN of the Agent.
$adminKey = "..." # The administrator API key for the BrokerGateway instance of $uri.

$headers = New-Object "System.Collections.Generic.Dictionary[[String],[String]]"
$headers.Add("BrokerGateway-Api-Key", $adminKey)

$response = Invoke-RestMethod "https://$uri/BrokerGateway/api/clientSecret/list" -Method 'GET' -Headers $headers
$response
```

## Using the client secrets

Some steps need to be taken on the server where no DataMiner Agent is installed:

1. Copy the file `C:\ProgramData\Skyline Communications\DataMiner Security\ca.pem` from any DataMiner Agent to a temporary folder on the server hosting the client application.

1. Rename `ca.pem` to `ca.crt` and open the file by double-clicking it.

1. Install the certificate on the local machine, using the default options.

   This is the root certificate authority that needs to be trusted by the server for SSL/TLS communication with BrokerGateway.

1. When the certificate has been installed, remove the `ca.crt` file again.

1. Create a new client secret file with the content shown below, making sure to replace the placeholders indicated with "<...>" with values for your own setup.

   A common place to save this file is in the folder `C:\ProgramData\Skyline Communications\DataMiner`.

   The key here is generated via the [API](#generating-a-client-secret).

    ```json
    {
        "APIKeys": [
            {
            "Key": "<generated client secret>",
            "Name": "ClientSecret"
            }
        ]
    }
    ```

1. Create a file `MessageBrokerConfig.json` in the folder `C:\ProgramData\Skyline Communications\DataMiner\`, using the content illustrated below.

   Make sure to replace the placeholders noted with "<...>" with values from your own setup:

   ```json
   {
       "BrokerGatewayConfig": {
           "CredentialsUrl": "https://<FQDN where DataMiner is installed>/BrokerGateway/api/natsconnection/getnatsconnectiondetails",
           "APIKeyPath": "<chosen full file path for client secret file>"
       }
   }
   ```

From this point on, any client on this server can communicate with the DataMiner cluster over NATS.

If the targeted DataMiner Agent is removed from the cluster, the clients on the server will no longer be able to communicate over NATS. To resolve this, replace the FQDN in `MessageBrokerConfig.json` to point to another Agent that is still in the cluster. When another Agent is removed from the cluster, the clients will keep on functioning as normal and no extra action needs to be taken.

> [!NOTE]
> The DataMiner Agent specified in `MessageBrokerConfig.json` must stay reachable for the external clients to be able to communicate.

## Behavioral changes when client secrets are configured

There is a difference in how the **Root Certificate Authority (CA)** is managed when client secrets have been configured.

- **Default behavior:**

  When a DataMiner Agent is removed, the system generates a new root CA and new certificates for all remaining nodes. This effectively "locks out" the removed node because its certificates are signed by the old, now-invalid CA.

- **Behavior with client secrets:**

  The root CA is **not cycled during node removal**. External clients depend on the root CA to validate the server. Changing the root CA would break connectivity for these external clients.
