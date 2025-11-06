---
uid: ConnectorBestPracticesReservedParameterNames
---

# Reserved parameter names

The following strings must not be used as parameter names or parameter descriptions. Note that the items in the table should be considered case-insensitive (E.g. \_clients_connected must also not be used).

|                                        |                                            |                                |
|----------------------------------------|--------------------------------------------|--------------------------------|
| \_\_Clients_connected                  | DMA Redundancy Status                      | Redundancy Group added         |
| \_\_Communication_DataMiner_RX         | DMS Revisioned                             | Scheduler info                 |
| \_\_Communication_DataMiner_TX         | Document added                             | Scheduled Task Created         |
| \_\_Communication_Device               | Document edited                            | Scheduled Task Updated         |
| \_\_Communication_Device_DataMiner_RX  | Document removed                           | Scheduled Task Deleted         |
| \_\_Communication_Device_Iteration     | Edited                                     | Security Edited                |
| \_\_Communication_Device_RTT           | Element alarm state                        | Service Templates              |
| \_\_Communication_info_state           | Element Connections Edited                 | Script Added                   |
| \_\_Communication_Message_Drops        | Element created                            | Script Deleted                 |
| \_\_Communication_Session_DataMiner_TX | Element disconnection                      | Script Edited                  |
| \_\_Communication info                 | Element masked                             | Script execution failure       |
| \_\_Element id                         | Element unmasked                           | Script started                 |
| \_\_Element Latch state                | Entered Prioritized Mode                   | Service added                  |
| \_\_Element Latch state                | Error during synchronization               | Service path changed           |
| \_\_Element_Priority                   | File changed                               | Set as production protocol     |
| \_\_Element_Priority                   | Filter added                               | Set Parameter                  |
| \_\_Element RCA Level                  | Filter edited                              | SMS Received                   |
| \_\_Increment_PID                      | Filter deleted                             | SMS Sent                       |
| \_\_Last_reset_time_pi_alarm           | GSM Signal Strength                        | SNMP-Managers edited           |
| \_\_Nbr_of_alarms                      | GSM General Information                    | SNMPAgent                      |
| \_\_PID                                | Import elements                            | Spectrum Monitor Created       |
| \_\_Reset_alarms                       | Information.xml assigned                   | Spectrum Monitor Deleted       |
| \_\_Start_time_first_alarm             | Information Added                          | Spectrum Monitor Edited        |
| \_\_Start_time_last_alarm              | Information Deleted                        | Spectrum Monitor Failure       |
| \_\_Timer_base                         | Information Edited                         | Spectrum Script Added          |
| \_\_Properties                         | IP Settings                                | Spectrum Script Edited         |
| \_\_Property name                      | Latch reset info                           | Spectrum Script Deleted        |
| \_\_Property type                      | Left Prioritized Mode                      | Start Element Failed           |
| \_\_Property value                     | Link file                                  | Start synchronization          |
| \_\_Read out properties                | Linked to                                  | Startup DataMiner Agent        |
| Alarm colors edited                    | Load Element Failed                        | Startup error                  |
| Alarm Template Added                   | Load Protocol Failed                       | STATE                          |
| Alarm Template Assigned                | lock_status                                | State change                   |
| Alarm Template Deleted                 | lock_status                                | Stop DataMiner                 |
| Alarm Template Edited                  | lock_owner                                 | Synchronization finished       |
| Annotations Edited                     | Map Configuration                          | Table Repair                   |
| Asset Manager Configuration            | Mobile gateway                             | Task started                   |
| Automation info                        | Mobile Gateway lost contact with DataMiner | TIMEOUT                        |
| Backup status                          | Nbr of alarms                              | TotalNbrOfActiveAlarms         |
| Client disconnected                    | New client registered                      | TotalNbrOfActiveCriticalAlarms |
| Client Eventing                        | New Element connection                     | TotalNbrOfActiveMajorAlarms    |
| Client notification                    | No connection with DMA                     | TotalNbrOfActiveMaskedAlarms   |
| Collaboration Message                  | Notification                               | TotalNbrOfActiveMinorAlarms    |
| Connection established with DMA        | Parameter descriptions                     | TotalNbrOfActiveWarningAlarms  |
| Correlation engine                     | Preset Created                             | Trending Template Added        |
| Database                               | Preset Edited                              | Trending Template Assigned     |
| Database optimization                  | Preset Renamed                             | Trending Template Deleted      |
| Database stack                         | Preset Deleted                             | Trending Template Edited       |
| DataMiner Agent found                  | Protocol Added                             | User settings                  |
| DataMiner Agent lost                   | Protocol Deleted                           | VDX Deleted                    |
| DataMiner runtime                     | Protocol Edited                            | VDX Added                      |
| Database settings edited               | Protocol Replaced                          | VDX Edited                     |
| Deleted                                | Real-time TCP Socket                       | Views Edited                   |
