---
uid: CommunicationGateway_change_log
---

# CommunicationGateway change log

#### 21 February - Enhancement - CommunicationGateway 3.0.1 - Error information when IP address is not formatted correctly [ID_38755]

If an IP address in the endpoint configuration is not formatted correctly, Communication Gateway will now return a *ChannelManagementHandler_ConnectRequest_CreateChannelInvalidUriFormat* error with information on what has gone wrong.

#### 5 January 2024 - New feature - CommunicationGateway 3.0.0 - Integration of middleware NuGet [ID_38151]

The OpenConfig library will now make use of the generated middleware NuGet. This means that it will no longer use the message broker and associated messages directly, which will greatly reduce the code size. This can also serve as an example for other projects that need to implement a gRPC service through the generated middleware.

#### 5 January 2024 - Fix - CommunicationGateway 2.0.2 - gRPC service calls waiting indefinitely for response and holding resources as a consequence [ID_38139]

When a request was sent out to a gRPC service, Communication Gateway would keep waiting indefinitely for a response. However, for various reasons, it could occur that the gRPC service never sent a response.

A timeout time of five seconds has now been introduced as a protection against such scenarios. When the timeout time elapses, a response with status code `DEADLINE_EXCEEDED` will be returned to the middleware. That response can be used to trigger whatever is necessary (e.g. set element into timeout, reconnect, etc.).

#### 5 January 2024 - Fix - CommunicationGateway 2.0.2 - Insufficient exception handling for outgoing gRPC service calls [ID_38071]

In some scenarios, it could happen that an exception that was thrown as a result of an outgoing gRPC service call was not processed. Because of this, no response was generated for the middleware, so it had to needlessly wait for the configured timeout time to elapse. Exception handling has now been improved so that every exception will always generate a response for the middleware.

#### 29 November 2023 - Fix - CommunicationGateway 2.0.1 - Communication Gateway tried to read response stream indefinitely when exception occurred [ID_37893]

When a subscription is created and an exception other than an RPC exception occurs with status code Unavailable, Communication Gateway tries to set up the connection with the gRPC service again, to send out the request, and to read the response stream.

However in case another exception occurred, Communication Gateway did not try to set up the connection again but just read out the stream, which would immediately fail again. This resulted in the service trying to read out the response stream over and over again, causing a high CPU load until the connector removed the subscription.

To resolve this, when an exception occurs that is not likely to be resolved with a reconnect, Communication Gateway will no longer attempt to retry. It will be up to the connector to decide when to recreate the subscription.

#### 6 November 2023 - Enhancement - CommunicationGateway 1.2.2 - Reconnect mechanism when gNMI channel goes down and there is an active subscription [ID_37411]

Previously, when there was an active subscription and the connection between the CommunicationGateway and the gNMI service went down, the subscription was not automatically created again once the connection could be restored. Now a reconnect mechanism with exponential backoff has been implemented.

This means that when the connection goes down, there will now be an attempt to reconnect after one second. In case this does not succeed, there will be another attempt in two seconds, followed by another in four seconds, in eight seconds, and so on. There is a maximum waiting time of five minutes between two reconnects, so in any case CommunicationGateway will continue to try to set up the connection again after five minutes.

> [!NOTE]
> The reconnect mechanism will only trigger when there is an active subscription. If there are no active subscriptions and the connection goes down, it will remain down until a new request is sent.

#### 31 October 2023 - New feature - CommunicationGateway 1.2.2 - Option to skip verify server certificate validation [ID_37651]

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

#### 20 September 2023 - Fix - CommunicationGateway 1.2.1 - CommunicationGateway will no longer trigger ConnectionStateChanged event when no subscriptions are active [ID_37264]

The `ConnectionStateChanged` event is triggered when the state of the connection changes. This event is then typically used in a DataMiner connector to alter the timeout state of the element.

If no subscriptions were active, eventually the connection was closed because of inactivity, which triggered this event. However, because the connection with the gRPC endpoint could still be created after a new service call, it was incorrect and confusing that this would then result in a timeout alarm. Because of this, this event will no longer be triggered when there are no subscriptions active.

#### 5 June 2023 - Enhancement - CommunicationGateway 1.2.0 - DotNet target version upgrade [ID_36579]

The Communication Gateway module now targets .NET 6.0 and no longer uses .NET 5.0, which is out of support.

#### 10 May 2023 - New feature - CommunicationGateway 1.1.0 - Added support for additional gRPC services [ID_36281]

The Communication Gateway module now supports Arista CloudVision and Mellanox Telemetry Agent gRPC services.

#### 10 May 2023 - New feature - CommunicationGateway 1.0.0 - New Communication Gateway module [ID_34945] [ID_35195] [ID_35390] [ID_35470] [ID_35575] [ID_35622] [ID_35576] [ID_35321] [ID_35711] [ID_35754] [ID_35853] [ID_36140]

A new Communication Gateway module is now available as a DxM (DataMiner Extension Module). This module makes it possible for connectors or scripts running in the DataMiner environment to communicate with devices that require a gRPC connection.

To install this DxM, follow the [installation procedure for DxMs that are not included in the DataMiner Cloud Pack](xref:Managing_cloud-connected_nodes#deploying-a-dxm-on-a-node).
