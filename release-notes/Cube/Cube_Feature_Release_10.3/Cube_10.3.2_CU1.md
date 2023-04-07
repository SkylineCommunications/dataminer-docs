---
uid: Cube_Feature_Release_10.3.2_CU1
---

# DataMiner Cube Feature Release 10.3.2 CU1

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.3.2](xref:General_Feature_Release_10.3.2).

### Fixes

#### Service & Resource Management: Problem with un-initialized Capacity property on DMAs running version 10.3.1 or 10.2.12 or earlier [ID_35854]

<!-- MR 10.3.0 [CU2] - FR 10.3.2 [CU1] -->

As from DataMiner version 10.3.0/10.3.2, the *Capacity* property is no longer initialized on new resources. As a result, resources without this legacy property would cause server-side issues on DataMiner Agents running either version 10.3.1 or version 10.2.12 or earlier.

From now on, Cube will initialize the *Capacity* property if it detects that the DataMiner Agent is running one of the following versions:

- version 10.3.1 or
- version 10.2.12 or earlier.
