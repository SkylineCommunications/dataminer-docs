---
uid: InfraOps_1.2.0_CU1
---

# InfraOps 1.2.0 CU1

## Fixes

#### Reference resolution conflicts caused by legacy MSBuild elements in ProjectReference entries [ID 45820]

Previously, redundant legacy MSBuild elements, specifically the legacy `<Project>` GUID and `<Name>` sub-elements, in `ProjectReference` entries for the InfraOps.Common and MediaOps.Common shared libraries could cause reference resolution conflicts during solution deployment. These elements have now been removed, resolving the issue.

Additionally, the Skyline DataMiner SDK has been updated from version 2.4.7 to 2.5.2.
