---
uid: MaintenanceSettings.SLNet.QueuedStackOverflow
---

# QueuedStackOverflow element

Specifies the maximum amount of messages that can be pending (queued) for a SLNet subscriber. If more than this amount of messages is queued, the connection will be automatically destroyed. An unlimited queue size can be selected by setting this configuration value to -1. Default: 25000.

## Content Type

nonNegativeInteger

## Parents

[SLNet](xref:MaintenanceSettings.SLNet)
