---
uid: MessageBrokerConfig_ForcedEndpoints
---

# Configuring forced NATS endpoints

The `ForcedEndpoints` setting allows all processes on a server to connect to specific custom NATS endpoints instead of the ones automatically provided by BrokerGateway.
The `CredentialsUrl` is still used to fetch credentials from BrokerGateway, but the endpoints returned in that response are ignored.
This setting can be configured in `MessageBrokerConfig.json`. 

This is useful in scenarios where a process must reach NATS through a fixed set of endpoints — for example, when connecting through a proxy, a DMZ, or a load balancer.

> [!NOTE]
> - From DataMiner 10.6.7<!-- RN 45491 --> onwards, this is supported for DataMiner server processes.
> - For DxMs, check the release notes of the specific DxM to find out from which version this is supported.

## Configuration

To override the NATS endpoints for all processes on a server, add a `ForcedEndpoints` array to the `BrokerGatewayConfig` section in `C:\ProgramData\Skyline Communications\DataMiner\MessageBrokerConfig.json`:

```json
{
  "BrokerGatewayConfig": {
    "CredentialsUrl": "https://<hostname>/BrokerGateway/api/natsconnection/getnatsconnectiondetails",
    "APIKeyPath": "C:\\Program Files\\Skyline Communications\\DataMiner BrokerGateway\\appsettings.runtime.json",
    "ForcedEndpoints": [ "custom-host-1:4222", "custom-host-2:4222", "custom-host-3" ]
  }
}
```

Each entry in `ForcedEndpoints` can be a string in the format `"host:port"` or `"host"`.

When `ForcedEndpoints` is set, the process will:

- Still call `CredentialsUrl` to retrieve the NATS credentials.
- Use only the endpoints listed in `ForcedEndpoints` to connect to NATS, ignoring any endpoints returned by BrokerGateway. 
  - The order of endpoints determines the connection preference and fallback order.
  - These endpoints do not need to be a subset of the known IPs of BrokerGateway.

When `ForcedEndpoints` is absent or empty, normal behavior applies and the endpoints are resolved through BrokerGateway.
