---
uid: MediaOps.Live.Mediation
---

# Mediation layer

The mediation layer in MediaOps Live enables the conversion of parameter values from one or more elements in the DataMiner System into connectivity relationships between endpoints.

For example, when a source device generates a multicast stream that is decoded by a destination device, the mediation layer automatically updates so that the source endpoint associated with the source device is connected to the destination endpoint associated with the destination device.

The mediation layer is subscription-based, which means that any state change in the network is immediately reflected in the mediation layer. Conversely, the mediation layer also translates a connection request between endpoints into parameter sets on the underlying elements.

## Mediation elements

A mediation element is created on each DataMiner Agent in the cluster. It is responsible for the local elements on that specific Agent.

These are the main things a mediation element does:

- Subscribing on the relevant parameters of the configured elements and triggering the connection handler scripts.
- Storing the (pending) connectivity between endpoints.
- Providing statistics about the configuration (number of endpoints, levels, etc.) and connection handler script executions (script duration, failures, etc.).

Mediation elements are provisioned automatically by the MediaOps Live solution.

## Connection handler scripts

A connection handler script needs to be implemented for each supported connector.

This script is responsible for the following things:

- Returning the list of elements it can support.
- Returning the parameters that need to be subscribed on.
- Converting parameter value updates into endpoint connectivity.
- Converting endpoint connection requests into parameter sets.
- Converting endpoint disconnect requests into parameter sets.

> [!TIP]
> For details on how to implement a connection handler script, refer to [Connection handler script](xref:MediaOpsLive_ConnectionHandlerScript).

## API

The mediation layer exposes an API that allows you to request and subscribe to connectivity between endpoints and virtual signal groups, and also to set up new connections (or disconnections).

This API is used by the [Control Surface app](xref:MO_Control_Surface) and by the [Orchestration Events](xref:MO_Orchestration_Events#orchestration-events) app, but it can be used by any custom script or application that needs to access mediated connectivity data or that needs to trigger connections.
