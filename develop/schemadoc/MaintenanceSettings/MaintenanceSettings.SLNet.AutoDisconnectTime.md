---
uid: MaintenanceSettings.SLNet.AutoDisconnectTime
---

# AutoDisconnectTime element

If a client has had no activity for AutoDisconnectTime and does not have a valid callback, its object will be destroyed. A client is considered active whenever an incoming message enters or a successful callback was made. Minimum value is 60 seconds, maximum value is 30 minutes. Default: 120s.

## Content Type

integer

## Parents

[SLNet](xref:MaintenanceSettings.SLNet)
