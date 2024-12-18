---
uid: D-DOCSIS_parameters_ds_service_group
---

# D-DOCSIS parameters – DS Service Group

This page contains an overview of the DS Service Group parameters available in the D-DOCSIS branch of the EPM Solution.

## KPIs & KQIs

- **Name \[IDX]**: Direct value. The CCAP core name concatenated with system name.

  Retrieved using the call "v1/smartphycache/rpd/details/active/1".

- **System ID**: Direct value. Last period-separated value in instance data.

  MIB OID: 1.3.6.1.4.1.4491.2.1.20.1.12.

- **System Name**: Direct value. This is a similar string from the US and DS service group prefixed with the fiber node name.

  Retrieved using the call "v1/smartphycache/rpd/details/active/1".

- **FN Name**: Converted. The fiber node name.

  This is the node status table index converted to ASCII format.

  Node Status table OID: 1.3.6.1.4.1.4491.2.1.20.1.12.

- **DS SG Name**: Direct value. The DS service name from the RPD.

  Retrieved using the call "v1/smartphycache/rpd/details/active/1".

- **CCAP Name**: Direct value. The name of the CCAP where the service group resides.

  Retrieved from OID 1.3.6.1.2.1.1.5.
