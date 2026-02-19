---
uid: NodeRecovery_API
---

# NodeRecovery API

> [!NOTE]
> The API over NATS is only to be used internally between DataMiner processes. Not to be documented for external use.

NodeRecovery exposes certain information over an API. The API can be accessed over SLNet (ideal for remote clients and automation scripts) as well as over NATS (ideal for DataMiner processes and DxMs)

## Local Cluster State

> [!NOTE]
> This API call requires DataMiner version 10.6.0/10.6.2 or higher.

When requested from a node in the cluster, the node will share its local view on the cluster by providing a list of nodes along with the observed [state](xref:NodeRecovery_States) for each of these.

### Local Cluster State over SLNet

Send a `LocalClusterStateRequest` message and specify the target node ID in the `TargetDataMinerID` property. The response will be a `LocalClusterStateResponse`. If no node ID was specified (<= 0), the information will be requested from the DMA to which the request was sent.

Exceptions are thrown when the target DMA does not exist or is unreachable.

### Local Cluster State over NATS

> [!NOTE]
> Only to be used internally between DataMiner processes. Not to be documented for external use.

Send a `LocalClusterStateRequest` message to topic `NodeRecovery.API.xxxx.LocalClusterState` where xxxx is the ID of the node from which the local state is requested.

The response is a `LocalClusterStateResponse` response.

See [Protobuf definitions](#protobuf-definitions) for more info on these types.

## Global Cluster State

> [!NOTE]
> This API call requires DataMiner version 10.6.0/10.6.3 or higher.

When requested, the leader node will provide the global cluster state, which represents the cluster-wide consensus on node states. Unlike local cluster state which shows one node's view, the global cluster state aggregates information from all reachable nodes.

### Global Cluster State over SLNet

Send a `GlobalClusterStateRequest` message. The response will be a `GlobalClusterStateResponse` containing the global consensus view of all node states.

### Global Cluster State over NATS

> [!NOTE]
> Only to be used internally between DataMiner processes. Not to be documented for external use.

Send a `GlobalClusterStateRequest` message to topic `NodeRecovery.API.GlobalClusterState`. The request will be handled by the leader node. If there is currently no leader, a timeout will occur.

The response is a `GlobalClusterStateResponse` response.

See [Protobuf definitions](#protobuf-definitions) for more info on these types.

## Setting Maintenance Mode

> [!NOTE]
> This API call requires DataMiner version 10.6.0/10.6.2 or higher.

From any node in the cluster, it is possible to set or unset maintenance mode for any other node in the cluster.

### Setting Maintenance Mode over SLNet

Send a `SetMaintenanceRequest` message which specifies the node ID to set maintenance mode for as well as whether to enable or disable maintenance mode. The response will be a `SetMaintenanceResponse`.

The request will be handled through the NodeRecovery module on the DMA to which the request was sent.

### Setting Maintenance Mode over NATS

> [!NOTE]
> Only to be used internally between DataMiner processes. Not to be documented for external use.

Send a `SetMaintenanceRequest` message to topic `NodeRecovery.API.xxxx.SetMaintenance` where xxxx is the ID of the node through which the maintenance mode should be set. In the request, specify the node ID to set maintenance mode for as well as whether to enable or disable maintenance mode.

The response is a `SetMaintenanceResponse` response.

See [Protobuf definitions](#protobuf-definitions) for more info on these types.

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

### Diagnostics over SLNet

Send a `DiagnosticInfoRequest` message and specify the target node ID in the `TargetDataMinerID` property. The response will be a `DiagnosticInfoResponse`. If no node ID was specified (<= 0), the information will be requested from the DMA to which the request was sent.

Exceptions are thrown when the target DMA does not exist or is unreachable.

### Diagnostics over NATS

> [!NOTE]
> Only to be used internally between DataMiner processes. Not to be documented for external use.

Send a `DiagnosticsRequest` message to topic `NodeRecovery.API.xxxx.Diagnostics` where xxxx is the ID of the node from which the diagnostics are requested.

The response is a `DiagnosticsResponse` message.

See [Protobuf definitions](#protobuf-definitions) for more info on these types.

## Protobuf definitions

> [!NOTE]
> Only to be used internally between DataMiner processes. Not to be documented for external use.

To access the requests over the NATS bus, these Protobuf definitions are required:

```protobuf
syntax = "proto3";

import "google/protobuf/timestamp.proto";

package skyline.dataminer.noderecovery;

option csharp_namespace = "Skyline.DataMiner.NodeRecovery.API.Proto";

enum NodeState {

  NODESTATE_UNKNOWN = 0;
  NODESTATE_HEALTHY = 1;
  NODESTATE_OUTAGE = 2;
}

message NodeStateInfo {

  // Unique node identifier
  int32 node_id = 1;
  
  // State of the node
  NodeState state = 2;
  
  // True if the node is in maintenance mode, false otherwise
  bool in_maintenance = 3;
}

message LocalClusterStateRequest {

  // Empty request - no parameters needed
}

message LocalClusterStateResponse {

  // Node responding with the state of all nodes for its viewpoint
  int32 node_id = 1;
  
  // List states of all nodes in the cluster
  repeated NodeStateInfo node_states = 2;
}

message SetMaintenanceRequest {

  // Node ID to set maintenance state for
  int32 node_id = 1;
  
  // True to set the node in maintenance mode, false otherwise
  bool in_maintenance = 2;
}

message SetMaintenanceResponse {

  // Empty response - no data needed
}

message DiagnosticsRequest {

  // Empty request - no parameters needed
}

message NodeDiagnosticInfo {

  // Unique node identifier
  int32 node_id = 1;
  
  // Local observed state of this node
  NodeState local_observed_state = 2;

  // Last local state change timestamp
  google.protobuf.Timestamp local_observed_state_changed = 3;
  
  // Global observed state of this node (only populated when diagnostics are requested from the leader node)
  optional NodeState global_observed_state = 4;

  // Last global state change timestamp
  optional google.protobuf.Timestamp global_observed_state_changed = 5;
  
  // Last heartbeat received timestamp
  google.protobuf.Timestamp last_heartbeat_received = 6;
  
  // True if the node is in maintenance mode, false otherwise
  bool in_maintenance = 7;
}

message DiagnosticsResponse {

  // Local node identifier
  int32 local_node_id = 1;
  
  // Current leader node identifier. -1 if there is none
  int32 leader_node_id = 2;
  
  // Detailed diagnostic information for each node in the cluster
  repeated NodeDiagnosticInfo node_diagnostics = 3;

  // DxM version
  string version = 4;

  // DxM startup time
  google.protobuf.Timestamp startup_time = 5;
}  

message GlobalClusterStateRequest {

  // Empty request - no parameters needed
  // Request will be automatically routed to the leader node
}

message GlobalClusterStateResponse {

  // Leader node ID that calculated the global state
  int32 leader_node_id = 1;
  
  // Global consensus state of all nodes in the cluster
  repeated NodeStateInfo node_states = 2;
}
```
