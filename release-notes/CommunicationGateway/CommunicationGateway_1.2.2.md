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

## Changes

### Enhancements

#### Reconnect mechanism when gNMI channel goes down and there is an active subscription [ID_37411]

Up to now, when there was an active subscription and the connection between the CommunicationGateway and the gNMI service would go down, the subscription would not be automatically created again once the connection could be restored.

From now on, there is a reconnect mechanism with exponential backoff in place. Meaning that once the connection goes down, it will try to reconnect after one second. In case it did not succeed, it will try again in two seconds followed by four seconds, eight seconds and so on. There is a maximum waiting time of five minutes between two reconnects so if the exponential backoff would be more than five, in any case it will continue to try to set up connection again after five minutes.

> [!NOTE]
> The reconnect mechanism will only trigger when there is an active subscription. If there are no active subscriptions and the connection goes down, it will remain down until a new request is sent.
