---
uid: DMAElementSNMPPortInfo
---

# DMAElementSNMPPortInfo

| Item | Format | Description |
|------|--------|-------------|
| DeviceAddress | String  | The address of the device itself, in case a gateway IP address is specified in *IPAddress*. |
| GetCommunity  | String  | The community string used to retrieve values. |
| IPAddress     | String  | The IP address of the device. |
| Network       | String  | Determines whether the device is accessible through the first or second network interface of the DMA, or if this is automatically selected. |
| PortNumber    | Integer | The SNMP port number. |
| SetCommunity  | String  | The community string used to write values. |
