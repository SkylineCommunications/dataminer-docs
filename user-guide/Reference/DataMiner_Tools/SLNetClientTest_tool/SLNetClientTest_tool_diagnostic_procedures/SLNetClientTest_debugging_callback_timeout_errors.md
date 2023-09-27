---
uid: SLNetClientTest_debugging_callback_timeout_errors
---

# Debugging callback timeout errors

When clients connect to a DataMiner Agent via eventing, the server can throw out the client when it takes longer than a particular number of seconds (default: 30) to send a packet of events to that client over the callback connection. In that case, a "callback timeout (waited 30 s)" type error is generated. This mechanism also applies to connections between DataMiner Agents. Possible reasons for such callback timeouts could be an unreachable destination (e.g. client was stopped, or firewall intervened), or also that the packet of data being forwarded is too large.

To debug such errors, you can do the following:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. In the *Diagnostics* menu, select *Runtime Logging*.

1. Select *Hidden Messages*, and click *Apply*.

   The "callback timeout (30 s)" type error will now contain extra information, e.g. "callback timeout (waited 30 s; 251 messages; 570 KB)". A line of logging will also be generated in the SLNet log file.

1. In the *Advanced* menu, select *Options* > *SLNet Flags*.

1. In the *SLNet RunTime Flags* window, double-click *dumpCallbackTimeoutData*.

   Whenever a callback timeout is encountered, the packet of messages will now be dumped into an .slnetdump file in the following folder: *C:\\Skyline DataMiner\\logging\\CallbackTimeoutDumps*. You can open this file in the SLNetClientTest tool by going to *File* > *Dump* > *Open*.

> [!NOTE]
> These options are not remembered across SLNet restarts, and apply to one DataMiner Agent only.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
