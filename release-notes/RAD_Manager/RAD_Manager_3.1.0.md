---
uid: RAD_Manager_3.1.0
---

# RAD Manager 3.1.0

> [!NOTE]
> DataMiner server versions 10.5.11 and newer require at least this version of RAD Manager.

## Changes

### Enhancements

#### Removed DataMiner ID column from relational anomaly groups table [ID 43744]

The *DataMiner ID* column has been removed from the relational anomaly groups table. This column was originally used to identify which DataMiner Agent hosted a given relational anomaly group and thus which agents' parameters it could monitor. However, since DataMiner 10.5.11, <!--RN43686--> relational anomaly groups can contain parameters from multiple DataMiner systems, making the DataMiner ID column less relevant.

### Fixes

#### Made RAD Manager compatible with DataMiner 10.5.11 and newer [ID 43744]

RAD Manager has been updated to ensure compatibility with DataMiner versions 10.5.11 and newer <!--RN43440-->. This update addresses platform changes to maintain seamless functionality and performance of RAD Manager.
