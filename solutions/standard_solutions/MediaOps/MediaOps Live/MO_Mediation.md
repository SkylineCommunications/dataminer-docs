---
uid: MediaOps.Live.Mediation
---

# Mediation Layer

The mediation layer in MediaOps Live enables the conversion of parameter values from 1 or multiple elements on the DataMiner system into connectivity relationships between endpoints. For example, when a source device generates a multicast stream that is decoded by a destination device, the mediation layer is automatically updates so that the source endpoint associated with the source device is connected to the destination endpoint associated with the destination device.

The mediation layer is subscription-based, which means that any state change in the network is immediately reflected in the mediation layer.
Conversely, the mediation layer translates a connection request between endpoints into parameter sets on the underlying elements.

## Mediation Elements

A mediation element is created on each DataMiner agent in the cluster, responsible for the local elements on that specific agent. It is mainly responsible for:

- Subscribing on the relevant parameters of the configured elements and triggering the connection handler scripts.
- Storing the (pending) connectivity between endpoints.
- Providing statistics about the configuration (number of endpoints, levels, etc.) and connection handler script executions (script duration, failures, etc.).

These mediation elements are provisioned automatically by the MediaOps Live solution.

## Connection Handler

A connection handler scripts needs to be implemented for each supported connector. This script is responsible for:

- Returning the list of elements it can support.
- Returning the parameters that need to be subscribed on.
- Converting parameter value updates into endpoint connectivity.
- Converting endpoint connection requests into parameter sets.
- Converting endpoint disconnect requests into parameter sets.

> [!TIP]
> The [Connection Handler Script page](xref:MediaOpsLive_ConnectionHandlerScript) describes the implementation of a connection handler script in more details.

## API

The mediation layer exposes an API that allows to request and subscribe to connectivity between endpoints, virtual signal groups, and also to setup new connections (or disconnects).

This API is used by the [Control Surface app](xref:MO_Control_Surface) and by the [Orchestration Events](xref:MO_Orchestration_Events#orchestration-events), but can be used by any custom script or application who needs to access mediated connectivity data or needs to trigger connections.
