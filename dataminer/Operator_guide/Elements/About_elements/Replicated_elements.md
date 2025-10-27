---
uid: Replicated_elements
---

# Replicated elements

With [element replication](xref:Replicating_elements), elements managed by one DMS can be visualized in another DMS.

A replicated, “foreign” element is visualized just like a locally managed element. It can be assigned alarm templates, trend templates, etc. It can even be included in services.

Unlike a locally managed element, however, a replicated element is not polled. It simply inherits all parameter statuses from its “real” counterpart in the other DataMiner System.

If the target DMA uses gRPC, all information about the remote element is retrieved using gRPC (default port: 443).<!-- RN 36262 --> If .NET Remoting is used instead, all information about the remote element is retrieved by means of the .NET Remoting protocol (default port: 8004). In order to optimize communication, only parameter changes are sent to the replicated element.

> [!NOTE]
>
> - The source and replication DMA must use the same DataMiner version.
> - A replicated element will go into timeout state both if the element that is being replicated goes into timeout state and when that element is not reachable.
> - The default connection checking interval is 30 seconds.
