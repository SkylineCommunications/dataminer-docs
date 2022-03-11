---
uid: DMAElementLite
---

# DMAElementLite

| Item              | Format  | Description                                                               |
|-------------------|---------|---------------------------------------------------------------------------|
| DataMinerID       | Integer | The ID of the DataMiner Agent.                                            |
| ID                | Integer | The ID of the element, if relevant.                                       |
| Name              | String  | The name of the element, if relevant.                                     |
| ProtocolName      | String  | The name of the protocol, if relevant.                                    |
| ProtocolVersion   | String  | The version of the protocol, if relevant.                                 |
| State             | String  | The current state of the element, if relevant.                            |
| IsCPE             | Boolean | Indicates whether the object is a CPE element.                            |
| IsSLA             | Boolean | Indicates whether the object is an SLA element.                           |
| IsDVE             | Boolean | Indicates whether the object is a DVE element.                            |
| IsDerived         | Boolean | Indicates whether the object is a derived element.                        |
| IsSpectrum        | Boolean | Indicates whether the object is a spectrum element.                       |
| HasTrendTemplate  | Boolean | Indicates whether a trend template has been assigned to the object.       |
| Type              | String  | Indicates the type of object: “Element”, “Service” or “Redundancy Group”. |
| IsEnhancedService | Boolean | Indicates whether the object is an enhanced service.                      |
| IsServiceTemplate | Boolean | Indicates whether the object is a service template.                       |
