---
uid: SRM_10.3.0.3
---

# SRM 10.3.0.3

> [!NOTE]
> This version requires that **DataMiner 10.3.0 [CU0] or higher** is installed. The DataMiner Feature Release track is not supported.

## Enhancements

#### Improved logging in case of invalid entry in Generic DVE Table [ID 38091]

Logging has been improved in case there is an invalid entry in the *Generic DVE Table* when the *SRM_DiscoverResources* script is used (i.e., when resources are provisioned). An error will be shown specifying which entry is invalid.

## Fixes

#### DTR not running correctly for auto-selected resource in silent booking [ID 37956]

In some cases, when data transfer rules (DTR) were triggered on automatic resource selection in a silent booking, and the DTR script had to retrieve the auto-selected resource, it could occur DTR did not run correctly.
