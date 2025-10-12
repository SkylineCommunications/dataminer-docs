---
uid: MaintenanceSettings.SLNet.FlushQueuedMessagesInterval
---

# FlushQueuedMessagesInterval element

Specifies the interval (in ms) at which pending messages are flushed to clients through the callback connection. The larger this interval, the less calls will be made, but the longer the delay will be between events being generated and clients receiving them. Default: 100ms.

## Content Type

integer

## Parents

[SLNet](xref:MaintenanceSettings.SLNet)
