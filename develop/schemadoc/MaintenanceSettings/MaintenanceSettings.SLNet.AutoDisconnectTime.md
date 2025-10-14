---
uid: MaintenanceSettings.SLNet.AutoDisconnectTime
---

# AutoDisconnectTime element

If a client has had no activity for duration specified in this element and does not have a valid callback, its object will be destroyed. A client is considered active whenever an incoming message enters or a successful callback was made. Minimum value: 60 seconds. Maximum value: 30 minutes. Default: 120 seconds.

## Content Type

integer

## Parents

[SLNet](xref:MaintenanceSettings.SLNet)
