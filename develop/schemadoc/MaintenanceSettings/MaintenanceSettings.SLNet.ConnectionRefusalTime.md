---
uid: MaintenanceSettings.SLNet.ConnectionRefusalTime
---

# ConnectionRefusalTime element

Defines how long (in min) connections to a certain Agent should be refused when a serious problem with the connection is detected. Serious problems include the case where a remote agent wants to send so many messages that events get dropped. Refusing the connection in this case will avoid constant reconnection, and allow clients to keep working on the rest of the system. An administrator can then connect on the faulty agent to resolve the problem. Minimum value is 1 min, maximum value is 60 min). Default: 10 min.

## Content Type

integer

## Parents

[SLNet](xref:MaintenanceSettings.SLNet)
