---
uid: Eventing_or_polling
---

## Eventing or polling

In a DataMiner System, connections between a client application and a DMA as well as connections between two DMAs are established via a single user-defined TCP port over .NET Remoting.

DMAs can send notifications toward client applications by means of two different methods:

- **Eventing**: Default method. The DMA will send server-initiated notifications to the client. As such, when a client application (e.g. DataMiner Cube) connects to a DMA, it will open a random port on the client to which the DMA will send its notifications. This method offers the best performance, but is not firewall-friendly.

- **Polling**: The DMA will not send server-initiated notifications to the client. Instead, the client application will continuously poll the DataMiner Agent for notifications. Use this method if there are firewalls in your network or if NAT is being used.

> [!NOTE]
> Within a DataMiner System, some connections can be configured to use eventing, while others can be configured to use polling.

> [!TIP]
> See also:
> [Configuring client communication settings](xref:DMA_configuration_related_to_client_applications#configuring-client-communication-settings)
