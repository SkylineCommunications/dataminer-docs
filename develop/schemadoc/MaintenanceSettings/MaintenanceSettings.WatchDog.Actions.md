---
uid: MaintenanceSettings.WatchDog.Actions
---

# Actions element

Specifies the action to perform. Possible values: alarm, restart, switch. Multiple values must be separated by a semicolon (";").

## Type

string

## Content Type

string

## Parents

[WatchDog](xref:MaintenanceSettings.WatchDog)

## Attributes

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [restartElementOnProtocolRTE](xref:MaintenanceSettings.WatchDog.Actions-restartElementOnProtocolRTE) | boolean |  | When set to "true", initiates an element restart in case of a runtime error on an element-related SLProtocol thread. |
