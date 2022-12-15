---
uid: WS_Methods_v0
---

# Methods (v0)

> [!WARNING]
> From DataMiner 10.2.0/10.1.6 onwards, the Web Services API v0 is considered obsolete. By default, the v0 interface is disabled from these DataMiner versions onwards.

## Overview of the methods (v0)

| Method | Description |
|--|--|
| [CleanupConnections](xref:CleanupConnections) | Closes all connections that have been idle for a specific period of time. |
| [Connect](xref:Connect) | Logs on to the DataMiner System and requests authentication. |
| [CreateAutomationScript](xref:CreateAutomationScript) | Creates DataMiner Automation scripts consisting of statements that each contain a C# code block. |
| [GetActiveAlarmsFromElement](xref:GetActiveAlarmsFromElement) | Retrieves a list of all the alarms of a specific element (referenced by name). |
| [GetActiveAlarmsFromView](xref:GetActiveAlarmsFromView) | Retrieves a list of all the alarms of a specific view (referenced by name). |
| [GetElementByPollingIp](xref:GetElementByPollingIp) | Retrieves a list of all the elements that poll a specific IP address. |
| [GetElementNameByPollingIp](xref:GetElementNameByPollingIp) | Retrieves a list of all the elements that poll a specific IP address (element names only). |
| [GetElementStateByID](xref:GetElementStateByID) | Retrieves the current state of an element (referenced by ID). |
| [GetElementStateByName](xref:GetElementStateByName) | Retrieves the current state of an element (referenced by name). |
| [GetElements](xref:GetElements) | Retrieves a list of all the elements in the DMS. |
| [GetElementsFiltered](xref:GetElementsFiltered) | Retrieves a specified series of elements. |
| [GetElementsFromView](xref:GetElementsFromView) | Retrieves a list of all the elements in a specific view. |
| [GetParameterValueByElementID](xref:GetParameterValueByElementID) | Retrieves the current state and current value(s) of specific parameters of an element (referenced by ID). |
| [GetParameterValueByElementName](xref:GetParameterValueByElementName) | Retrieves the current state and current value(s) of specific parameters of an element (referenced by name). |
| [GetParameterValueByIds](xref:GetParameterValueByIds) | Retrieves the value of a specific parameter (referenced by DataMiner Agent ID, element ID, and parameter ID). |
| [GetProtocolForElement](xref:GetProtocolForElement) | Retrieves all information regarding the protocol of a specific element. |
| [GetServiceElementListByID](xref:GetServiceElementListByID) | Retrieves a list of all the elements and services in a specific service (referenced by ID). |
| [GetServiceElementListByName](xref:GetServiceElementListByName) | Retrieves a list of all the elements and services in a specific service (referenced by name). |
| [GetServicePropertiesByID](xref:GetServicePropertiesByID) | Retrieves the properties of a specific service (referenced by ID). |
| [GetServicePropertiesByName](xref:GetServicePropertiesByName) | Retrieves the properties of a specific service (referenced by name). |
| [GetServices](xref:GetServices) | Retrieves a list of all the services in the DMS. |
| [GetServicesAlarmStateByID](xref:GetServicesAlarmStateByID) | Retrieves the current alarm state of a specific service (referenced by ID). |
| [GetServicesAlarmStateByName](xref:GetServicesAlarmStateByName) | Retrieves the current alarm state of a specific service (referenced by name). |
| [GetSubViews](xref:GetSubViews) | Retrieves the names of all subviews of a specified view. |
| [RequestLoginAsTicket](xref:RequestLoginAsTicket1) | Retrieves a logon ticket that can then be added to e.g. a DataMiner Maps URL. |
| [SetParameterValueByElementID](xref:SetParameterValueByElementID) | Updates the value of a parameter linked to an element (referenced by ID). |
