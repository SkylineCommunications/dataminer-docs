---
uid: CommunicationGateway_change_log
---

# CommunicationGateway change log

#### 23 September 2025 - Fix - CommunicationGateway 5.3.1 - Installer incorrectly selected DVD drive for log files [ID 43714]

Previously, the CommunicationGateway installer could incorrectly treat a DVD drive (when assigned as D:) as a valid location for log files.
If the C drive had less free space than the DVD drive, the installer attempted to write logs to the DVD drive, resulting in installation failures.

This update ensures the installer always prioritizes the C drive, regardless of available space on other drives.

#### 17 September 2025 - Enhancement - CommunicationGateway 5.3.0 - Configurable gRPC call timeouts [ID 43460]

gRPC calls no longer use a fixed 5-second timeout. You can now define a custom timeout for each request. If no timeout is specified, the default remains 5 seconds.

> [!NOTE]
> To configure these timeouts, connectors must reference [Skyline.DataMiner.DataSources.OpenConfig.Gnmi 7.1.0](xref:Skyline.DataMiner.DataSources.OpenConfig.Gnmi_7.x#add-support-for-configurable-timeouts-to-gnmiclient-operations-id-43460) or higher.

#### 13 February 2025 - Enhancement - CommunicationGateway 5.2.0 - Circuit breaker for repeated gRPC stream failures [ID 41971]

A circuit breaker mechanism has been implemented to prevent excessive resource consumption when a gRPC stream repeatedly fails. Previously, the system would continuously attempt to restore a stream, even if failures were caused by persistent issues such as invalid UTF-8 characters in messages. With this update, if a stream fails 5 times within 60 seconds, the circuit breaker will activate, halting further reconnection attempts. This enhancement improves system stability and reduces unnecessary processing.

#### 28 January 2025 - Enhancement - CommunicationGateway 5.1.0 - Node ID has a fixed value [ID 41784]

The node ID of a CommunicationGateway instance is now assigned a fixed value, enabling middleware to target a specific instance of its choice. This enhancement was introduced to allow middleware to prioritize the CommunicationGateway instance running on the same machine as where the middleware is hosted.

> [!NOTE]
> For this to work as intended, connectors need to reference [Skyline.DataMiner.DataSources.OpenConfig.Gnmi 6.1.0](xref:Skyline.DataMiner.DataSources.OpenConfig.Gnmi_6.x#prioritize-connection-to-the-local-communicationgateway-instance-id-41784) or higher.

#### 25 November 2024 - Enhancement - CommunicationGateway 4.0.0 - MessageBroker version 3.0.3 [ID 41467]

The CommunicationGateway DxM has been updated so that from now on it uses MessageBroker version 3.0.3.

> [!IMPORTANT]
> From CommunicationGateway 4.0.0 onwards, connectors that use the [Skyline.DataMiner.DataSources.OpenConfig.Gnmi](xref:Skyline.DataMiner.DataSources.OpenConfig.Gnmi_6.x) NuGet package need to reference [Skyline.DataMiner.DataSources.OpenConfig.Gnmi 6.x](xref:Skyline.DataMiner.DataSources.OpenConfig.Gnmi_6.x) or higher.

#### 13 November 2024 - Enhancement - CommunicationGateway 3.2.3 - SLLogCollector config file deployed with installation of CommunicationGateway DxM [ID 41004]

Up until recently, SLLogCollector was configured by default (with the *Collector-xml* configuration file) to collect the log files of the CommunicationGateway DxM, even when the DxM was not installed. This default configuration has been removed from DataMiner (see [General Feature Release 10.4.12](xref:General_Feature_Release_10.4.12#sllogcollector-will-no-longer-be-configured-by-default-to-collect-the-log-files-of-the-communicationgateway-dxm-id-41004)), and the CommunicationGateway installer will instead create the log configuration file upon installation.

#### 23 September 2024 - Enhancement - CommunicationGateway 3.2.2 - PDB files removed from installer [ID 40557]

To improve security, the CommunicationGateway installer has been updated so that it will no longer install PDB files.

#### 23 September 2024 - Fix - CommunicationGateway 3.2.2 - Incorrect version info in middleware NuGet packages [ID 40541]

Previously, it could occur that the assembly version of the middleware NuGet packages did not correspond with the release version. This has been fixed, and the file and product version info of these assemblies will now specify the release version.

#### 13 August 2024 - Enhancement - CommunicationGateway 3.2.1 - Upgrade to .NET 8 [ID 40424]

DataMiner CommunicationGateway has been upgraded to .NET 8. **Make sure .NET 8 is installed** before you upgrade to this version.

#### 26 June 2024 - Fix - CommunicationGateway 3.2.0 - Multiple CommunicationGateway nodes in cluster setting up connection with endpoint instead of only one [ID 39548]

When multiple CommunicationGateway nodes were deployed in a cluster, and an element was set up that would for instance use the OpenConfig middleware, eventually all CommunicationGateway nodes set up a connection with the endpoint, instead of only one as was intended. To prevent this, an extra step has been added to the connection process.

> [!NOTE]
> For this extra step to be initiated, connectors need to reference [Skyline.DataMiner.DataSources.OpenConfig.Gnmi 4.2.0](xref:Skyline.DataMiner.DataSources.OpenConfig.Gnmi_4.x#extra-step-added-to-the-connection-process-id-39548) or higher.

#### 27 February 2024 - Enhancement - CommunicationGateway 3.1.1 - Improved handling of exceptions encountered by gRPC streams [ID 38931]

When a gRPC stream encounters an exception, the middleware will now be notified. It will log stream state changes, and if the stream is lost, it will trigger a subscribable event called "SubscriptionLost", containing a LostSubscriptionArgs value with the Channel ID, the Subscription ID, and the error message as found in CommunicationGateway.

When a stream encounters a GrpcException of type "Internal" or "Dataloss", there will be attempts to recover it for a limited time (7.5 minutes), using a similar mechanism as for an "Unavailable" exception.

In the logging, the following information will now be recorded:

- When the stream is down but may be restored and the SubscriptionLost event is not invoked: `The stream for {subscriptionId} is down and attempts are being made to restore it. The stream went down with the error message: {message}`
- When the stream is down and cannot be restored, and the SubscriptionLost event will be invoked: `The stream for {subscriptionId} is down and no (further) attempts are being made to restore it. The stream went down with the error message: {message}`
- When the stream was down but is now up again: `The stream for {subscriptionId} is restored.`

#### 21 February 2024 - Enhancement - CommunicationGateway 3.0.1 - Error information when IP address is not formatted correctly [ID 38755]

If an IP address in the endpoint configuration is not formatted correctly, Communication Gateway will now return a *ChannelManagementHandler_ConnectRequest_CreateChannelInvalidUriFormat* error with information on what has gone wrong.

#### 5 January 2024 - New feature - CommunicationGateway 3.0.0 - Integration of middleware NuGet [ID 38151]

The OpenConfig library will now make use of the generated middleware NuGet. This means that it will no longer use the message broker and associated messages directly, which will greatly reduce the code size. This can also serve as an example for other projects that need to implement a gRPC service through the generated middleware.

#### 5 January 2024 - Fix - CommunicationGateway 2.0.2 - gRPC service calls waiting indefinitely for response and holding resources as a consequence [ID 38139]

When a request was sent out to a gRPC service, Communication Gateway would keep waiting indefinitely for a response. However, for various reasons, it could occur that the gRPC service never sent a response.

A timeout time of five seconds has now been introduced as a protection against such scenarios. When the timeout time elapses, a response with status code `DEADLINE_EXCEEDED` will be returned to the middleware. That response can be used to trigger whatever is necessary (e.g. set element into timeout, reconnect, etc.).

#### 5 January 2024 - Fix - CommunicationGateway 2.0.2 - Insufficient exception handling for outgoing gRPC service calls [ID 38071]

In some scenarios, it could happen that an exception that was thrown as a result of an outgoing gRPC service call was not processed. Because of this, no response was generated for the middleware, so it had to needlessly wait for the configured timeout time to elapse. Exception handling has now been improved so that every exception will always generate a response for the middleware.

#### 29 November 2023 - Fix - CommunicationGateway 2.0.1 - Communication Gateway tried to read response stream indefinitely when exception occurred [ID 37893]

When a subscription is created and an exception other than an RPC exception occurs with status code Unavailable, Communication Gateway tries to set up the connection with the gRPC service again, to send out the request, and to read the response stream.

However in case another exception occurred, Communication Gateway did not try to set up the connection again but just read out the stream, which would immediately fail again. This resulted in the service trying to read out the response stream over and over again, causing a high CPU load until the connector removed the subscription.

To resolve this, when an exception occurs that is not likely to be resolved with a reconnect, Communication Gateway will no longer attempt to retry. It will be up to the connector to decide when to recreate the subscription.

#### 6 November 2023 - Enhancement - CommunicationGateway 1.2.2 - Reconnect mechanism when gNMI channel goes down and there is an active subscription [ID 37411]

Previously, when there was an active subscription and the connection between the CommunicationGateway and the gNMI service went down, the subscription was not automatically created again once the connection could be restored. Now a reconnect mechanism with exponential backoff has been implemented.

This means that when the connection goes down, there will now be an attempt to reconnect after one second. In case this does not succeed, there will be another attempt in two seconds, followed by another in four seconds, in eight seconds, and so on. There is a maximum waiting time of five minutes between two reconnects, so in any case CommunicationGateway will continue to try to set up the connection again after five minutes.

> [!NOTE]
> The reconnect mechanism will only trigger when there is an active subscription. If there are no active subscriptions and the connection goes down, it will remain down until a new request is sent.

#### 31 October 2023 - New feature - CommunicationGateway 1.2.2 - Option to skip verify server certificate validation [ID 37651]

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

#### 20 September 2023 - Fix - CommunicationGateway 1.2.1 - CommunicationGateway will no longer trigger ConnectionStateChanged event when no subscriptions are active [ID 37264]

The `ConnectionStateChanged` event is triggered when the state of the connection changes. This event is then typically used in a DataMiner connector to alter the timeout state of the element.

If no subscriptions were active, eventually the connection was closed because of inactivity, which triggered this event. However, because the connection with the gRPC endpoint could still be created after a new service call, it was incorrect and confusing that this would then result in a timeout alarm. Because of this, this event will no longer be triggered when there are no subscriptions active.

#### 5 June 2023 - Enhancement - CommunicationGateway 1.2.0 - DotNet target version upgrade [ID 36579]

The Communication Gateway module now targets .NET 6.0 and no longer uses .NET 5.0, which is out of support.

#### 10 May 2023 - New feature - CommunicationGateway 1.1.0 - Added support for additional gRPC services [ID 36281]

The Communication Gateway module now supports Arista CloudVision and Mellanox Telemetry Agent gRPC services.

#### 10 May 2023 - New feature - CommunicationGateway 1.0.0 - New Communication Gateway module [ID 34945] [ID 35195] [ID 35390] [ID 35470] [ID 35575] [ID 35622] [ID 35576] [ID 35321] [ID 35711] [ID 35754] [ID 35853] [ID 36140]

A new Communication Gateway module is now available as a DxM (DataMiner Extension Module). This module makes it possible for connectors or scripts running in the DataMiner environment to communicate with devices that require a gRPC connection.

To install this DxM, follow the [installation procedure for DxMs that are not included in the DataMiner Cloud Pack](xref:Managing_cloud-connected_nodes#deploying-a-dxm-on-a-dms-node).
