---
uid: MaintenanceSettings.SLNet.ConnectionRefusalTime
---

# ConnectionRefusalTime element

Defines how long (in minutes) connections to a certain Agent should be refused when a serious problem with the connection is detected. Serious problems include cases where a remote Agent wants to send so many messages that events get dropped. Refusing the connection in this case will avoid constant reconnection, and it will allow clients to keep working on the rest of the system. An administrator can then connect to the faulty Agent to resolve the problem. Minimum value: 1 minute. Maximum value: 60 minutes. Default: 10 minutes.

## Content Type

integer

## Parents

[SLNet](xref:MaintenanceSettings.SLNet)
