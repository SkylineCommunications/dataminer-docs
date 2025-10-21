---
uid: RAD_Manager_3.1.0
---

# RAD Manager 3.1.0

> [!NOTE]
> If you are using DataMiner 10.5.11/10.6.0 or higher, this is the minimum supported version of RAD Manager.

## Changes

### Enhancements

#### Removed DataMiner ID column from relational anomaly groups table [ID 43744]

The *DataMiner ID* column has been removed from the relational anomaly groups table. This column was originally used to identify which DataMiner Agent hosted a given relational anomaly group and consequently which Agent's parameters it could monitor. However, as of DataMiner 10.5.11/10.6.0, <!--RN43686--> relational anomaly groups can contain parameters from multiple DataMiner Systems, making the *DataMiner ID* column less relevant.

#### Compatibility with DataMiner 10.5.11/10.6.0 and higher [ID 43744]

RAD Manager has been updated to ensure compatibility with DataMiner versions 10.5.11/10.6.0 and higher.<!--RN 43440--> This update addresses platform changes to maintain seamless functionality and performance of RAD Manager.
