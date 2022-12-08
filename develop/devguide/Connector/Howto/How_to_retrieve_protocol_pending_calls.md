---
uid: How_to_retrieve_protocol_pending_calls
---

# How to retrieve protocol pending calls

Below, you can learn how to retrieve the pending calls of a running element in DataMiner.

## User skills required

- Basic knowledge of drivers.
- Basic knowledge of the inner workflow of drivers.

## Why retrieve pending calls?

Pending calls indicate the currently running logic of the driver linked to the element. Retrieving these calls is useful to detect which logic component is running for a longer time and could affect the responsiveness of the driver.

## Retrieving pending calls with SLNetClientTest tool

> [!CAUTION]
> Use the SLNetClientTest tool with caution, as it can have a big impact on the functionality of the DataMiner System. We recommend to only perform read operations, and to only use this tool on a DataMiner Agent that is dedicated to testing. Always ask for support in case you need to use this tool and something is not clear.

1. Open SLNetClientTest tool from the DataMiner Taskbar Utility by selecting *Launch > Tools > Client Test*.
1. Connect to the DataMiner Agent hosting the element by selecting *Connection > Connect*.
1. Request the pending calls by selecting *Diagnostics > DMA > Protocol Pendingcalls* and entering the DMA ID/Element ID (e.g. 101/2) of the element you want to investigate.

> [!NOTE]
>
> - When the logging levels of the element are set to Level 2, some additional information will be available.
> - If you use the *Protocol Pendingcalls* option for an element that is stuck, you will not get any diagnostics info, because this feature will try to add a lock on the element and that will fail, since it is stuck. If you use the *Protocol Pendingcalls[no lock]* option instead, you will get some diagnostics info.

For more information on how to use SLNetClientTest tool, see [SLNetClientTest tool](xref:SLNetClientTest_tool).

## Investigating pending calls

After you have requested the pending calls, an info line will appear in the main overview of the tool. The *Message Info* column will have an entry in the following format:

```txt
ProtocolThread ID = xxxx
```

Double-clicking this entry will open a pop-up window where you can enable and configure the refresh rate of the pending calls (default: 5 seconds). We recommend not to set this to a value lower than 1 second, to avoid a high impact on a running system. Keep in mind that the pending calls request will be sent at this rate.

In the pop-up window, the running timer(s), group(s) and QAction(s) will be shown with the number of seconds they have been active.

For example, when button 1 is pressed, logic will run. This logic takes 1 minute to complete. In case this logic is linked to 1 group, it will be displayed in the pending calls for 1 minute.

The longer a group is active in a protocol thread, the longer other groups will be delayed.
