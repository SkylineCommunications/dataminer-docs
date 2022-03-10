---
uid: DMAInfo
---

# DMAInfo

| Item          | Format       | Description                                                                                             |
|---------------|--------------|---------------------------------------------------------------------------------------------------------|
| ID            | Integer      | The ID of the DataMiner Agent.                                                                          |
| Name          | String       | The name of the DataMiner Agent.                                                                        |
| PrimaryIP     | String       | The primary IP address of the DataMiner Agent.                                                          |
| Cluster       | String       | The name of the DMS cluster.                                                                            |
| Status        | String       | The status of the DMA: "Disconnected", "Running", "Starting", "Unknown" or "Switching".                 |
| IsFailOver    | Boolean      | Whether or not the DataMiner Agent is a member of a redundant pair of DataMiner Agents.                 |
| LastChangeUTC | Long integer | The time when the object last changed, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
