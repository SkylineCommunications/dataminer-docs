---
uid: Viewing_information_on_the_DMAs_in_a_DMS
description: "Discover where to find information about the individual nodes in a DataMiner cluster, including their state, key parameters, and BPA test results."
---

# Viewing information about DataMiner nodes

To get information on the individual DataMiner nodes (also known as DataMiner Agents) in a cluster, in DataMiner Cube, go to *Apps* > *System Center* > *Agents*.

This page contains several tabs with information and settings:

- To see the total number of nodes in the cluster, check the top of the *Agents* column in the *manage* tab.

- To see the state of a specific node in the cluster, look for the node in the *Agents* column in the *manage* tab. The state of the node is displayed in parentheses next to its name. Select a node to view detailed information on alarms for this node in the pane on the right.

  A node can have the following states:

  | State | Description |
  |--|--|
  | Not running | The node is currently not running. |
  | Running | The node is running. |
  | Starting | The node is starting up. |
  | Switching | The node is part of a Failover pair and a Failover switch is currently happening. See [Failover](xref:failover). |
  | Leaving Cluster | The node is currently leaving the cluster. |
  | Joining Cluster | The node is currently joining the cluster. |
  | Unknown | The node state and connection state are currently not known. |

  If the state of the node is unknown, but the connection state is known, the connection state is shown instead. A node can have the following connection states:

  | Connection state | Description |
  |--|--|
  | Normal | The connection is OK. |
  | Other cluster | The node is not part of the current cluster. This can mean that it is part of another cluster, or that it is not part of a cluster at all. |
  | Version conflict | There is a version conflict between the node and the node you are connected to. |
  | Refused | The connection with the node has been temporarily refused. |
  | Invalid | Invalid configuration makes it impossible to communicate with the node. |
  | Disconnected | The node cannot be reached. |

  > [!NOTE]
  > For more information on how to check the exact cause for a refused connection, see [Checking or modifying the settings related to a Refused DMA state](xref:SLNetClientTest_refused_dma_state). However, note that this involves advanced settings that should only be modified by administrators, as changing these can have far-reaching consequences on the functionality of your DataMiner System.

- To view key parameters of all the nodes in the system, such as the processor load, the server uptime, and the total number of elements per node, go to the *status* tab.

- To view contacts responsible for the system, for instance in case you encounter an issue and want to contact an administrator, go to the *system* tab.

- The *bpa* tab is used to run BPA tests. See [Running BPA tests](xref:Running_BPA_tests)

> [!NOTE]
> To view this page, you need the permission *Modules* > *System configuration* > *Agents* > *UI available*.
