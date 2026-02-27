---
uid: NodeRecovery_API
---

# NodeRecovery API

NodeRecovery exposes certain information over an API. The API can be accessed over SLNet.

## Local Cluster State

> [!NOTE]
> This API call requires DataMiner version 10.6.0/10.6.2 or higher.

When requested from a node in the cluster, the node will share its local view on the cluster by providing a list of nodes along with the observed [state](xref:NodeRecovery_States) for each of these.

Send a [LocalClusterStateRequest](xref:Skyline.DataMiner.Net.NodeRecovery.Requests.LocalClusterStateRequest) message and specify the target node ID in the [TargetDataMinerId](xref:Skyline.DataMiner.Net.NodeRecovery.Requests.LocalClusterStateRequest.TargetDataMinerId) property. The response will be a [LocalClusterStateResponse](xref:Skyline.DataMiner.Net.NodeRecovery.Requests.LocalClusterStateResponse). If no node ID was specified (<= 0), the information will be requested from the DMA to which the request was sent.

Exceptions are thrown when the target DMA does not exist or is unreachable.

## Global Cluster State

> [!NOTE]
> This API call requires DataMiner version 10.6.0/10.6.3 or higher.

When requested, the leader node will provide the global cluster state, which represents the cluster-wide consensus on node states. Unlike local cluster state which shows one node's view, the global cluster state aggregates information from all reachable nodes.

Send a [GlobalClusterStateRequest](xref:Skyline.DataMiner.Net.NodeRecovery.Requests.GlobalClusterStateRequest) message. The response will be a [GlobalClusterStateResponse](xref:Skyline.DataMiner.Net.NodeRecovery.Requests.GlobalClusterStateResponse) containing the global consensus view of all node states.

> [!NOTE]
> When the leader node is unreachable or when no leader is elected, this request will fail with an exception, as the global cluster state cannot be retrieved in these scenarios.

## Setting Maintenance Mode

> [!NOTE]
> This API call requires DataMiner version 10.6.0/10.6.2 or higher.

From any node in the cluster, it is possible to set or unset maintenance mode for any other node in the cluster.

Send a [SetMaintenanceRequest](xref:Skyline.DataMiner.Net.NodeRecovery.Requests.SetMaintenanceRequest) message which specifies the node ID to set maintenance mode for as well as whether to enable or disable maintenance mode. The response will be a [SetMaintenanceResponse](xref:Skyline.DataMiner.Net.NodeRecovery.Requests.SetMaintenanceResponse).

The request will be handled through the NodeRecovery module on the DMA to which the request was sent.

## Diagnostics

> [!NOTE]
> This API call requires DataMiner version 10.6.0 CU1/10.6.4 or higher.

Use this request to retrieve diagnostic information from a specific node in the NodeRecovery cluster.

The response includes:

- ID of the queried node
- ID of the leader node (as known by the queried node)
- Process startup time
- NodeRecovery version
- For every known node in the cluster:
  - ID of the node
  - Local state (as observed by the queried node)
  - TImestamp of the last local state change
  - Global state (only present when queried node is the leader)
  - Timestamp of the last global state change (only present when queried node is the leader)
  - Most recent heartbeat timestamp
  - Maintenance state (as known by queried node)

Send a [DiagnosticInfoRequest](xref:Skyline.DataMiner.Net.NodeRecovery.Requests.DiagnosticInfoRequest) message and specify the target node ID in the [TargetDataMinerId](xref:Skyline.DataMiner.Net.NodeRecovery.Requests.DiagnosticInfoRequest.TargetDataMinerId) property. The response will be a [DiagnosticInfoResponse](xref:Skyline.DataMiner.Net.NodeRecovery.Requests.DiagnosticInfoResponse). If no node ID was specified (<= 0), the information will be requested from the DMA to which the request was sent.

Exceptions are thrown when the target DMA does not exist or is unreachable.
