---
uid: GetSnmpManagers
---

# GetSnmpManagers

Use this method to retrieve information on the SNMP Managers in the DMS.

## Input

| Item       | Format | Description                                                                      |
|------------|--------|----------------------------------------------------------------------------------|
| Connection | String | The connection ID. See [ConnectApp](xref:ConnectApp) . |

## Output

| Item                   | Format                                                                                      | Description                                                                                                        |
|------------------------|---------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------------------|
| GetSnmpManagers­Result | Array of DMASnmpMan­ager (See [DMASnmpManager](xref:DMASnmpManager)) | A list of the SNMP Managers in the DMS, with additional information such as their IP address and community string. |

