---
uid: Generating_BrokerGateway_client_secrets
---

# Generating BrokerGateway client secrets
This feature is available from DataMiner 10.5.0 [CU13]/10.6.0 [CU1]/10.6.4 on.

## Overview
This feature introduces the ability for users to manage client secrets for NATS authentication. Unlike internal cluster keys, these user managed client secrets are preserved throughout the lifecycle of the cluster. The presence of these secrets prevents the root certificate authority from being cycled during DataMiner agent removals or NATSRepair calls. This is done to ensure that external clients maintain stable connectivity with the same trusted root certificates.

These client secrets should be used when DxMs or other clients that use the NATS bus of DataMiner are on a server that does not have DataMiner installed.
Common examples of these are [Data Aggregator DxM](xref:Data_Aggregator_DxM) or [Dashboard Gateway](xref:Dashboard_Gateway_installation).

## API calls

API calls are made available to manage these BrokerGateway client secrets.

| Method | Route |  Description |
| :--- | :--- |  :--- |
| `POST` | `/api/ClientSecret/generateclientsecret` | Generates a new random API key associated with a specific client name. The key is returned in the response body. |
| `DELETE` | `/api/ClientSecret/deleteclientsecret` | Deletes the client secret associated with the specified `clientName` argument. |
| `GET` | `/api/ClientSecret/listclientsecrets` | Retrieves a list of all existing client secrets. **Note:** The sensitive key values are redacted in the response (e.g., `abcd****************`) for security purposes. |

In order to perform these API calls on a BrokerGateway, the Administrator key is needed.
This key can be found in here: `C:\Program Files\Skyline Communications\DataMiner BrokerGateway\appsettings.runtime.json`.
In the file, look for an entry in APIKeys that has the name *Administrator*. The *key* property is the administrator key.

The API calls can be executed by calling the REST API via Powershell:

### Generating a client secret
Executing the following powershell script will generate a new client secret and will be returned in `$response`.

```powershell
$clientname = "external client" # The name of client secret to generate
$adminKey = "..." # The adminstrator API key for the BrokerGateway of $uri.
$uri = "localhost" # change to FQDN of the agent

$headers = New-Object "System.Collections.Generic.Dictionary[[String],[String]]"
$headers.Add("BrokerGateway-Api-Key", $adminKey)

$response = Invoke-RestMethod "https://$uri/BrokerGateway/api/clientsecret/generateclientsecret?clientName=$clientName" -Method 'POST' -Headers $headers -ContentType 'text/plain'
$response
```

Client secret names need to be unique. These are case-sensitive.
It is not possible to overwrite a client secret with a new key. To do so, remove the secret and readd it.

> [!NOTE]
> Client secrets are not automatically revoked. This is up to the user to delete these again.

### Deleting a client secret
Executing the following powershell script will remove a chosen client secret. The name is case-sensitive.

```powershell
$clientname = "external client" # The name of client secret to remove
$adminKey = "..." # The adminstrator API key for the BrokerGateway of $uri.
$uri = "localhost" # change to FQDN of the agent

$headers = New-Object "System.Collections.Generic.Dictionary[[String],[String]]"
$headers.Add("BrokerGateway-Api-Key", $adminKey)

Invoke-RestMethod "https://$uri/BrokerGateway/api/clientsecret/deleteclientsecret?clientName=$clientName" -Method 'DELETE' -Headers $headers
```

### Listing all generated client secrets
This API call lists up all generated client secrets. The keys are redacted for security reasons. Only the first four characters will be visible.

```powershell
$adminKey = "..." # The adminstrator API key for the BrokerGateway of $uri.
$uri = "localhost" # change to FQDN of the agent

$headers = New-Object "System.Collections.Generic.Dictionary[[String],[String]]"
$headers.Add("BrokerGateway-Api-Key", $adminKey)

$response = Invoke-RestMethod "https://$uri/BrokerGateway/api/clientsecret/listclientsecrets" -Method 'GET' -Headers $headers
$response
```

## Using the client secrets
Some steps need to be take on the server where no DataMiner agent is installed:

- Open the `C:\ProgramData\Skyline Communications\DataMiner Security\ca.pem` file from any DataMiner agent on the server by renaming ca.pem to ca.crt and double clicking it.
Install the certificate on the Local machine. All other options can be left default. This is the root certificate authority that needs to be trusted by the server for SSL/TLS communication to BrokerGateway.
- create a file in this specific location: `C:\ProgramData\Skyline Communications\DataMiner\MessageBrokerConfig.json`.
    The contents of this file should be the following:
    ```json
    {
        "BrokerGatewayConfig": {
            "CredentialsUrl": "https://<FQDN where DataMiner is installed>/BrokerGateway/api/natsconnection/getnatsconnectiondetails",
            "APIKeyPath": "<chosen path for client secret file>"
        }
    }
    ```
- Create a new client secret file with this content:
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

From this point on, any client on this server can communicate over NATS.
Keep in mind, that the DataMiner agent filled in into `MessageBrokerConfig.json` needs to stay reachable for the external clients to be able to communicate.
If this DataMiner agent is removed from the cluster, the clients on the server will no longer be able to communicate over NATS. Replace the FQDN to an agent that is still in the cluster to resolve this.
When another agent is removed from the cluster, the clients will keep on functioning as normal and no extra action needs to be taken.

## Behavioural changes

The most significant architectural change involves how the **Root Certificate Authority (CA)** is handled when the cluster topology changes, like removing a DataMiner agent.

-   **Default Behavior:**
    When a DataMiner agent is removed, the system generates a new Root CA and new certificates for all remaining nodes. This effectively "locks out" the removed node because its certificates are signed by the old, now-invalid CA.

-   **Behavior with Client Secrets:**
    The system now checks if *any* user managed client secrets exist.
    The Root CA is **NOT** cycled during node removal. External clients depend on the Root CA to validate the server. changing the Root CA would break connectivity for all external clients.