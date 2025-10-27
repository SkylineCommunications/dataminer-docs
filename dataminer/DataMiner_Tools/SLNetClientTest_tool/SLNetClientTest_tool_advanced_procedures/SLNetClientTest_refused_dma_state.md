---
uid: SLNetClientTest_refused_dma_state
---

# Checking or modifying the settings related to a Refused DMA state

When the state of a DMA is "Refused" on the *Agents* page in System Center (see [Viewing information on the DMAs in a DMS](xref:Viewing_information_on_the_DMAs_in_a_DMS)), this means that the DMA is actively refusing incoming connections. This is a state that should automatically disappear after some time, if the conditions that caused the refusal are resolved.

The exact cause of the refusal can be found in the SLNet logging. Overall, there can be two reasons:

- There have been too many connections with the DMA in the past hours, as defined in the *MaxAgentConnectsPerHour* setting.

- The threshold in the *QueuedStackOverflow* setting is exceeded and the DMA is consequently dropping events.

With the SLNetClientTest tool, you can check and modify the thresholds defined for these settings. To do so:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to *Advanced* > *Options* > *SLNet Options*.

1. In the drop-down list at the top of the window, select an option and then configure it using the right-click menu in the pane below.

   - *MaxAgentConnectsPerHour*: The maximum number of connections SLNet is allowed to set up with a DMA within one hour. If more connections have been made, further connections are refused for 30 minutes.
   - *QueuedStackOverflow*: The maximum number of messages that can be pending for an SLNet subscriber. If more messages are queued than this maximum, the connection is destroyed.

If the underlying issue is resolved, you can also clear the refusal state using SLNetClientTest tool:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to *Info* > *A - M* > *DataMinerInfo*.

1. Right-click the DMA with the "Refused" connection state and select *Clear Connection Refusal*.

1. Click *OK* to close the pop-up window.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
