---
uid: MaintenanceSettings.SLNet.FlushQueuedMessagesInterval
---

# FlushQueuedMessagesInterval element

Specifies the interval (in ms) between the flushing of pending messages to clients through the callback connection. The larger this interval, the fewer calls will be made, but the longer the delay will be between events being generated and clients receiving them. Default: 100 ms.

## Content Type

integer

## Parents

[SLNet](xref:MaintenanceSettings.SLNet)
