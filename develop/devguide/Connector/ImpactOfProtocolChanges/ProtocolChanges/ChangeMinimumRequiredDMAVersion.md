---
uid: ChangeMinimumRequiredDMAVersion
---

# Change minimum required DataMiner version

Changing the minimum required DataMiner version for a connector to a higher version is considered a dependency change requiring a new [System Version](xref:Protocol.VersionHistory.Branches.Branch.SystemVersions.SystemVersion).

For generic/public connectors, the minimum required DataMiner version should go in the direction of the current minimum version supported by Skyline (see [Software support lifecycles](xref:Software_support_life_cycles)).

## Impact

Users may need to update their DMS.

## Workarounds

Changing the minimum required DataMiner version for a connector to a version higher than the current minimum version supported by Skyline (see [Software support lifecycles](xref:Software_support_life_cycles)) will be approved in the following case:

- The feature needed is the only viable solution.

For all other reasons the request will generally be rejected.
