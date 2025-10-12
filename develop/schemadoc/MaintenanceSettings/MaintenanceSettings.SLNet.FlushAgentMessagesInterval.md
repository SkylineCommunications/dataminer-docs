---
uid: MaintenanceSettings.SLNet.FlushAgentMessagesInterval
---

# FlushAgentMessagesInterval element

As a performance enhancement, received events for element connections are forwarded in groups (max size = MaxAgentMessagesQueueCount). When there are not enough messages queued after “FlushAgentMessagesInterval” ms, the package is sent anyway. Minium value: 100. Default: 1000.

## Content Type

integer

## Parents

[SLNet](xref:MaintenanceSettings.SLNet)
