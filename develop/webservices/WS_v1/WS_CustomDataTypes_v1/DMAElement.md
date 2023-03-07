---
uid: DMAElement
---

# DMAElement

| Item | Format | Description |
|--|--|--|
| DataMinerID | Integer | The ID of the DataMiner Agent. |
| ID | Integer | The ID of the element. |
| Name | String | The name of the element. |
| Description | String | The description of the element. |
| AlarmState | String | The current alarm state of the element. |
| AlarmStateCappedIncluded | String | The maximum alarm severity when the element is included (only for elements that are part of a service). |
| AlarmStateCappedNotUsed | String | The maximum alarm severity when the element is not used (only for elements that are part of a service). |
| IsTimeout | Boolean | Whether the element is in timeout. |
| Views | Array of [DMAObject](xref:DMAObject) | The list of views in which the element can be found. |
| Services | Array of [DMAObject](xref:DMAObject) | The list of services of which the element is a part. |
| ProtocolName | String | The name of the protocol. |
| ProtocolVersion | String | The version of the protocol. |
| State | String | The current state of the element. |
| IsCPE | Boolean | Whether the element is a CPE element. |
| IsSLA | Boolean | Whether the element is an SLA element. |
| IsSpectrum | Boolean | Whether the element is a spectrum element. |
| IsDVE | Boolean | Whether the element is a DVE element. |
| IsDerived | Boolean | Whether the element is a derived element. |
| IsMonitored | Boolean | Whether an alarm template has been assigned to the element. |
| HasTrendTemplate | Boolean | Whether a trend template has been assigned to the element. |
| HideParameters | Boolean | Only used for CPE elements. If the “CPEOnly” option is used in the element protocol, *HideParameters* will be true, indicating that only the CPE UI should be displayed in the client, and not the Data Display pages. However, clients can ignore this property if necessary, as it is still possible to retrieve parameters with the web APIs even when *HideParameters* is true. |
| Type | String | “Element”, “Service” or “Redundancy Group”. |
| PollingIP | String | The polling IP of the element. |
| ProtocolType | String | The protocol type as defined in the protocol (DMAElement.Type is either "Element" or "Service"). |
| LastChangeUTC | Long integer | The time when the element was last changed, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| IsEnhancedService | Boolean | Whether the element is an enhanced service. |
| IsServiceTemplate | Boolean | Whether the element is a service template. |
