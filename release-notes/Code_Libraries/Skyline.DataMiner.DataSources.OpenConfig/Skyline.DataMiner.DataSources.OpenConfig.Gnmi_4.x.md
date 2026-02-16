---
uid: Skyline.DataMiner.DataSources.OpenConfig.Gnmi_4.x
---

# Skyline.DataMiner.DataSources.OpenConfig.Gnmi Range 4.x

## 4.2.1

#### Enhanced performance for NATS message processing [ID 41263]

The OpenConfig library has been updated to version 3.2.3 of *Skyline.DataMiner.DataSources.CommunicationGatewayMiddleware.OpenConfig*. This update eliminates the creation of queues and workers for internal subscriptions (e.g., heartbeats), reducing unnecessary overhead. Since the volume of events on these subscriptions is predictable, they are processed immediately without queuing. Additionally, worker signaling has been improved to eliminate periodic polling, freeing up CPU resources for other tasks.

#### Improved memory efficiency for NATS message processing [ID 41033]

The OpenConfig library has been updated to version 3.2.3 of *Skyline.DataMiner.DataSources.CommunicationGatewayMiddleware.OpenConfig*. This update replaces the previous feature-rich queues and worker implementation with a solution tailored specifically to our requirements. The new design significantly improves memory efficiency, reducing the memory usage of a fully populated queue by up to 80%.

## 4.2.0

#### Extra step added to the connection process [ID 39548]

The OpenConfig library has been updated to the latest *Skyline.DataMiner.DataSources.CommunicationGatewayMiddleware.OpenConfig* version (i.e., 3.2.0). It will now initiate a `DiscoveryRequest`, and the first CommunicationGateway DxM that answers will be used to handle all further communication.

Minimum required version: [CommunicationGateway 3.2.0](xref:CommunicationGateway_change_log#26-june-2024---fix---communicationgateway-320---multiple-communicationgateway-nodes-in-cluster-setting-up-connection-with-endpoint-instead-of-only-one-id-39548)

## 4.1.0

#### Additional logging for subscriptions and overloads for Subscribe methods [ID 39077]

The OpenConfig library has been updated to the latest *Skyline.DataMiner.DataSources.CommunicationGatewayMiddleware.OpenConfig* version (i.e., 3.1.0). It will now log the error message encountered for a subscription that has gone down and also add a log entry when a subscription is restored. The event that is raised when a subscription cannot be restored is forwarded through the *GnmiClient* class with the same name: *SubscriptionLost*.

Additional overloads have also been made for the *Subscribe* methods, so that additional gNMI subscription options can be controlled: *suppressRedundant* and *heartbeatInterval* for sample-type subscriptions, and *useTargetDefined* for real-time subscriptions. For more information regarding these options, refer to the [gNMI specification](https://github.com/openconfig/reference/blob/master/rpc/gnmi/gnmi-specification.md#35152-stream-subscriptions).

## 4.0.0

#### Enhancement - Support for gNMI notifications of which the value is of type BytesVal, ProtoBytes, DecimalVal, FloatVal, or LeaflistVal [ID 38649]

Previously, when the middleware received gNMI notifications with values of type *BytesVal* or *ProtoBytes*, these were flagged as unsupported. Now these will get processed and handed over to consumers of the middleware through a `byte[]`. It is then up to the consumer to process these in the expected way.

In addition, the middleware did not yet support data sent out as *decimalVal*, as *DecimalVal* in combination with *FloatVal* is considered obsolete. However, as it is a consumer library and it is not in control over which data are sent out, support has been added for both *DecimalVal* and *FloatVal*.

Finally, *LeaflistVal* was also not yet supported. This will now be converted into a JSON string representation of the values, similar to how this is done when data is polled and enters as JSON.
