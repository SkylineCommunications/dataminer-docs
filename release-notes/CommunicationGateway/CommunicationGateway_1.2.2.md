---
uid: CommunicationGateway_1.2.2
---

# Communication Gateway 1.2.2

## New features

#### Option to skip verify server certificate validation [ID_37651]

When the CommunicationGateway DxM is used to consume gRPC services over a secure connection, it is important that the server certificate is valid, as otherwise it will not be possible to set up the connection. In cases where you want to configure some hosts for which server certificate validation should be skipped, you can now use the `SkipVerifyHosts` option in the *CommunicationGateway.gRPC.config.json* configuration file to do so.

Place this configuration file next to the *CommunicationGateway* executable in the folder `C:\Program Files\Skyline Communications\DataMiner CommunicationGateway`. You can change this file at runtime. Changes will be effective immediately without any need to restart the CommunicationGateway service.

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
