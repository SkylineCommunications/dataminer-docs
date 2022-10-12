---
uid: Viewing_information_on_the_DMAs_in_a_DMS
---

# Viewing information on the DMAs in a DMS

To get information on the individual DMAs in a DMS, in DataMiner Cube, go to *Apps* > *System Center* > *Agents*.

This page contains several tabs with information and settings:

- To see the total number of DMAs in the system, check the top of the *Agents* column in the *manage* tab.

- To see the state of a specific DMA in the system, look for the DMA in the *Agents* column in the *manage* tab. The state of the DMA is displayed in parentheses next to the DMA name. Select a DMA to view detailed information on Agent alarms in the pane on the right.

  A DMA can have the following states:

  | State | Description |
  |--|--|
  | Not running | The DMA is currently not running. |
  | Running | The DMA is running. |
  | Starting | The DMA is starting up. |
  | Switching | The DMA is part of a Failover pair and a Failover switch is currently happening. See [Failover](xref:failover). |
  | Leaving Cluster | The DMA is currently leaving the DataMiner System. |
  | Joining Cluster | The DMA is currently joining the DataMiner System. |
  | Unknown | The DMA state and connection state are currently not known. |

  If the DMA state is unknown, but the connection state is known, the connection state is shown instead. A DMA can have the following connection states:

  | Connection state | Description |
  |--|--|
  | Normal | The connection is OK. |
  | Other cluster | The DMA is not part of the current cluster. This can mean that it is part of another cluster, or that it is not part of a cluster at all. |
  | Version conflict | There is a version conflict between the DMA and the DMA you are connected to. |
  | Refused | The connection with the DMA is temporarily refused. |
  | Invalid | Invalid configuration makes it impossible to communicate with the DMA. |
  | Disconnected | The DMA cannot be reached. |

  > [!NOTE]
  > For more information on how to check the exact cause for a refused connection, see [Checking or modifying the settings related to a Refused DMA state](xref:SLNetClientTest_refused_dma_state). However, note that this involves advanced settings that should only be modified by administrators, as changing these can have far-reaching consequences on the functionality of your DataMiner System.

- To view key parameters of all the DMAs in the system, such as the processor load, the server uptime, and the total number of elements per DMA, go to the *status* tab.

- To view contacts responsible for the system, for instance in case you encounter an issue and want to contact an administrator, go to the *system* tab.

- The *bpa* tab is used to run BPA tests. See [Running BPA tests](xref:Running_BPA_tests)

> [!NOTE]
> To view this page, you need the permission *Modules* > *System configuration* > *Agents* > *UI available*.
