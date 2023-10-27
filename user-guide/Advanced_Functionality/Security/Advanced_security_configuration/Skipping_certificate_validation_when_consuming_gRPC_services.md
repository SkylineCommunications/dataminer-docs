---
uid: Skipping_certificate_validation_when_consuming_gRPC_services
---

# Skipping certificate validation when consuming gRPC services

When using the [**CommunicationGateway DxM**](xref:DataMinerExtensionModules#communicationgateway) to consume gRPC services over a secure connection it is important that the server certificate is valid otherwise it will refuse to setup the connection.

In cases where you want to configure some hosts for which server certificate validation should be skipped, you can use the `SkipVerifyHosts` option in the *CommunicationGateway.gRPC.config.json* configuration file to do so.

This file should be placed next to the **CommunicationGateway** executable under *Program Files\Skyline Communications\DataMiner CommunicationGateway*.

> [!TIP]
> This file can be changed at runtime, and changes will be effective immediately without any need to restart the CommunicationGateway service.

Example:

```json
{
   "SkipVerifyHosts": [
      "dev.skyline.be",
      "pre-prod.company.org"
   ]
}
```

> [!CAUTION]
> Use this with caution, as improper certificate validation can lead to a range of different security threats such as man-in-the-middle attacks.
