---
uid: DMAElementBasePortInfo
---

# DMAElementBasePortInfo

This array can contain one or more of the 3 sub-arrays DMASerialPortInfo, DMAElementSNMPPortInfo, and DMAElementSNMPV3PortInfo, depending on the ports specified in the protocol.

| Item                     | Format  | Description                                                                                                                    |
|--------------------------|---------|--------------------------------------------------------------------------------------------------------------------------------|
| ElementTimeoutTime       | Integer | The number of seconds after which the element goes into timeout.                                                               |
| TimeoutTime              | Integer | The number of seconds after which the element goes into slow poll mode.                                                        |
| Retries                  | Integer | The number of retries after which the element goes into slow poll mode.                                                        |
| DMASerialPortInfo        | Array   | Element configuration info when using a serial connection. See [DMASerialPortInfo](xref:DMASerialPortInfo).                      |
| DMAElementSNMPPortInfo   | Array   | Element configuration info when using an SNMPv1 or SNMPv2 connection. See [DMAElementSNMPPortInfo](xref:DMAElementSNMPPortInfo). |
| DMAElementSNMPV3PortInfo | Array   | Element configuration info when using an SNMPv3 connection. See [DMAElementSNMPV3PortInfo](xref:DMAElementSNMPV3PortInfo).       |
