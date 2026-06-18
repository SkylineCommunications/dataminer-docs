---
uid: MediaOps_Plan_1.7.0
---

# MediaOps Plan 1.7.0 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

> [!NOTE]
> This version requires:
>
> - DataMiner 10.6.4/10.7.0 or higher.
> - The [GQI DxM](xref:GQI_DxM), which must be installed and enabled.
> - [Standard Data Model Registration](https://catalog.dataminer.services/details/52173e49-9185-4772-9b60-c186ee365a81) 2.0.0 or higher.
> - [Categories](https://catalog.dataminer.services/details/c9666f3a-be26-42fd-83f2-6ee7fab4f11e) 1.1.0 or higher.

> [!TIP]
> Installing [MediaOps Live](https://catalog.dataminer.services/details/213031b9-af0b-488c-be20-934912b967c0) alongside MediaOps Plan allows you to orchestrate jobs and workflows and fully automate the setup and teardown processes.

## New features

*No new features have been added to this release yet.*

## Changes

### Enhancements

#### DevPack: API enhancement to improve type-checking and casting for Capacity and Configuration classes [ID 45715]

New helper methods have been introduced for safe type-checking and casting of Capacity and Configuration instances to their specific derived types, with comprehensive XML documentation.

- In **Capacity.cs**, the following methods have been added:

  - IsNumberCapacity
  - IsRangeCapacity

- In **Configuration.cs**, the following methods have been added:

  - IsNumberConfiguration
  - IsDiscreteNumberConfiguration
  - IsTextConfiguration
  - IsDiscreteTextConfiguration

### Fixes

*No fixes have been added to this release yet.*
