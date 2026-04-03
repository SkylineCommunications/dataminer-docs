---
uid: NodeRecovery_API
---

# Node Recovery API

NodeRecovery exposes certain information over an API. The API can be accessed over SLNet and requires the `AdminTools` permission.

## Requesting the local cluster state

When this is requested from a node in the cluster, a node will share its local view on the cluster by providing a list of nodes along with the observed [node state](xref:NodeRecovery_States) for each of these.

To request this information, send a [LocalClusterStateRequest](xref:Skyline.DataMiner.Net.NodeRecovery.Requests.LocalClusterStateRequest) message and specify the target node ID in the [TargetDataMinerId](xref:Skyline.DataMiner.Net.NodeRecovery.Requests.LocalClusterStateRequest.TargetDataMinerId) property. The response will be a [LocalClusterStateResponse](xref:Skyline.DataMiner.Net.NodeRecovery.Requests.LocalClusterStateResponse). If no node ID was specified (<= 0), the information will be requested from the DMA to which the request was sent.

Exceptions are thrown when the target DMA does not exist or is unreachable.

## Requesting the global cluster state

When this is requested, the leader node will provide the global cluster state, which represents the cluster-wide consensus on node states. Unlike the local cluster state, which shows one node's view, the global cluster state aggregates information from all reachable nodes.

To request this information, send a [GlobalClusterStateRequest](xref:Skyline.DataMiner.Net.NodeRecovery.Requests.GlobalClusterStateRequest) message. The response will be a [GlobalClusterStateResponse](xref:Skyline.DataMiner.Net.NodeRecovery.Requests.GlobalClusterStateResponse) containing the global consensus view of all node states.

> [!NOTE]
> When the leader node is unreachable or when no leader is elected, this request will fail with an exception, as the global cluster state cannot be retrieved in those scenarios.

## Setting maintenance mode

From any node in the cluster, it is possible to set or unset maintenance mode for any other node in the cluster.

To do so, send a [SetMaintenanceRequest](xref:Skyline.DataMiner.Net.NodeRecovery.Requests.SetMaintenanceRequest) message that specifies a node ID as well as whether to enable or disable maintenance mode for that node. The response will be a [SetMaintenanceResponse](xref:Skyline.DataMiner.Net.NodeRecovery.Requests.SetMaintenanceResponse).

The request will be handled through the NodeRecovery module on the DMA to which the request was sent.

## Retrieving diagnostics from a node

When you retrieve diagnostic information from a specific node in the cluster, the response will include the following:

- The ID of the queried node.
- The ID of the leader node (as known by the queried node).
- The process startup time.
- The version of the NodeRecovery DxM.
- For every known node in the cluster:
  - The ID of the node.
  - The local state (as observed by the queried node).
  - The timestamp of the last local state change.
  - The global state (only if the queried node is the leader).
  - The timestamp of the last global state change (only if the queried node is the leader).
  - The most recent heartbeat timestamp.
  - The maintenance state (as known by queried node).

To retrieve this information, send a [DiagnosticInfoRequest](xref:Skyline.DataMiner.Net.NodeRecovery.Requests.DiagnosticInfoRequest) message and specify the target node ID in the [TargetDataMinerId](xref:Skyline.DataMiner.Net.NodeRecovery.Requests.DiagnosticInfoRequest.TargetDataMinerId) property. The response will be a [DiagnosticInfoResponse](xref:Skyline.DataMiner.Net.NodeRecovery.Requests.DiagnosticInfoResponse). If no node ID was specified (<= 0), the information will be requested from the DMA to which the request was sent.

Exceptions are thrown when the target DMA does not exist or is unreachable.

This API call requires DataMiner version 10.6.0 CU1/10.6.4 or higher.
