---
uid: SLNetClientTest_tracking_dma_communication
keywords: Cube follow
---

# Tracking DMA communication

Via the *Follow* menu, you can activate follow mode for several aspects of DMA communication, for example to [follow a DataMiner Cube session](#following-a-dataminer-cube-session). Messages will then appear in the *Properties* tab of the main menu as the DMA communication is tracked.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

## Activating follow mode

In general, this is how you activate follow mode:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. In the menu bar at the top, select *Follow* > *Follow*.

   This will open a new window.

1. In the new window, select which aspects of communication should be followed:

   - *Events* and *Requests/Responses* are selected by default, to track events that are sent to a client and requests and responses respectively.

   - Select *Include Polling* to track all polling.

   - Select *Wire* to track events after they have been pushed over an eventing callback or returned in a polling response. This can be useful to verify that events have been pushed onto the wire in diagnostic scenarios.

1. Select what should be followed. The following options are available:

   - *Hook into Active Session*: Allows you to select a particular item to follow from the current active session, e.g., SLDataMiner.exe

   - *Hook into Custom Active Session*: Allows you to specify a particular connection ID

   - *Hook into Next Session*: Allows you to select a particular client to follow for the next session.

   - *Hook into ALL Sessions*: Follows all sessions.

1. Optionally, select the *Clone* option. This will follow a clone of the original event/request/response, to keep server-side changes to these objects from being included in the follow data. However, note that this option does increase the load on the server.

1. Click *OK*.

To save a transcript of the DMA communication, go to *File* > *Dump* > *Save*. You can later open this transcript via *File* > *Dump* > *Open*.

To stop follow mode, in the *Follow* menu, select *Stop Following*.

## Following a DataMiner Cube session

Below you can find how you can activate follow mode specifically to follow a DataMiner Cube session for troubleshooting purposes. This is similar to what is outlined above, but here the specific options are described that you need to select for the purpose of following Cube only.

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. In the menu bar at the top, select *Follow* > *Follow*.

1. In the *Who to follow* window:

   1. Select *Hook Into Active Session* and select the Cube session.

   1. In the *Quick Filter* box, specify the name of the user whose Cube session you want to follow.

   1. Under *What to Follow*, select *Requests* and *Responses*.

   1. Click *OK*.

   ![Who to Follow window](~/dataminer/images/Who_to_follow_window.png)

1. In DataMiner Cube, reproduce the issue you are trying to troubleshoot.

1. Save a transcript by going to *File* > *Dump* > *Save*.
