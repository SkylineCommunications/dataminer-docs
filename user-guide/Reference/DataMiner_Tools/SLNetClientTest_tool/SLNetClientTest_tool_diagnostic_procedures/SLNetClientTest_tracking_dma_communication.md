---
uid: SLNetClientTest_tracking_dma_communication
---

# Tracking DMA communication

Via the *Follow* menu, you can activate follow mode for several aspects of DMA communication. Messages will then appear in the *Properties* tab of the main menu as the DMA communication is tracked.

To activate follow mode:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Select which aspects of communication should be followed:

   - *Events* and *Requests/Responses* are selected by default, to track events that are sent to a client and requests and responses respectively.

   - Select *Include Polling* to track all polling.

   - Select *Wire* to track events after they have been pushed over an eventing callback or returned in a polling response. This can be useful to verify that events have been pushed onto the wire in diagnostic scenarios.

1. Select what should be followed. The following options are available:

   - *Hook into Active Session*: Allows you to select a particular item to follow from the current active session, e.g. SLDataMiner.exe

   - *Hook into Custom Active Session*: Allows you to specify a particular connection ID

   - *Hook into Next Session*: Allows you to select a particular client to follow for the next session.

   - *Hook into ALL Sessions*: Follows all sessions.

1. Optionally, select the *Clone* option. This will follow a clone of the original event/request/response, to keep server-side changes to these objects from being included in the follow data. However, note that this option does increase the load on the server.

1. Click *OK*.

To save a transcript of the DMA communication, go to *File* > *Dump* > *Save*. You can later open this transcript via *File* > *Dump* > *Open*.

To stop follow mode, in the *Follow* menu, select *Stop Following*.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
