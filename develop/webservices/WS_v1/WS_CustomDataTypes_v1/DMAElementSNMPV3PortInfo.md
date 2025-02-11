---
uid: DMAElementSNMPV3PortInfo
---

# DMAElementSNMPV3PortInfo

| Item | Format | Description |
|------|--------|-------------|
| AuthPassword  | String  | The password used for authentication. |
| AuthType      | String  | The type of authentication used: "HMAC_MD5" or "HMAC_SHA". |
| DeviceAddress | String  | The address of the device itself, in case a gateway IP address is specified in *IPAddress*. |
| IPAddress     | String  | The IP address of the device. |
| Network       | String  | Determines whether the device is accessible through the first or second network interface of the DMA, or if this is automatically selected. |
| PortNumber    | Integer | The SNMP port number. |
| PrivPassword  | String  | The encryption password. |
| PrivType      | String  | The privacy type used: "DES" or "AES128". |
| SecurityLevel | String  | The security level used: "authPriv", "authNoPriv", or "noAuthNoPriv". |
| Username      | String  | The name of the user. |
