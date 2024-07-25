---
uid: DMAServiceParametersElement
---

# DMAServiceParametersElement

| Item | Format | Description |
|--|--|--|
| DataMinerID     | Integer | The ID of the DataMiner Agent. |
| ElementID       | Integer | The ID of the element. |
| Name            | String | The name of the element. |
| Alias           | String | The alias name of the element in the service. |
| ProtocolName    | String | The name of the protocol. |
| ProtocolVersion | String | The version of the protocol. |
| Parameters      | Array of [DMAServiceParameter](xref:DMAServiceParameter) | The service parameters. |
| LastChangeUTC   | Long integer | The time when the object last changed, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
