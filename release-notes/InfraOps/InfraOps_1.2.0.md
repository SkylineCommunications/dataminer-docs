---
uid: InfraOps_1.2.0
---

# InfraOps 1.2.0

## Changes

### Breaking changes

#### Shared library namespace redesign [ID 45699]

The InfraOps shared library has been redesigned with a unified namespace structure. All shared classes are now consolidated under `Skyline.DataMiner.Utils.InfraOps.Common.DOM_Classes.DOM.Applications.*`.

> [!IMPORTANT]
> Custom scripts or connectors referencing the old `InfraOpsShared.DOM_Classes.*` namespaces will need to be updated.

### Enhancements

#### Automatic SDM registration on installation [ID 45558]

InfraOps now automatically registers itself with the DataMiner Software-Defined Management (SDM) catalog each time the solution is installed or upgraded. A new Automation script, i.e. *InfraOps - Register Solutions*, is invoked as part of the standard installation flow and records the solution's unique catalog identifier, display name, and current version in the SDM system.

The installed version of InfraOps is reported to the SDM registry automatically upon deployment, enabling consistent version visibility and catalog management across all DataMiner environments.

No configuration changes or manual steps are required by operators. The registration runs transparently during installation using the Skyline.DataMiner.SDM.Registration.Automation library, and it correctly handles both fresh installations and upgrades by creating a new registration entry or updating an existing one.

#### Plan and Build job types removed from default data generation [ID 45698]

The *InfraOps - Generate Default Data* script no longer imports Plan and Build job types as part of the default data installation process. Previously, running this script would automatically populate Plan and Build job types alongside other default data such as cable types, port types, and device types. This step has been removed so that Plan and Build job type data is decoupled from the general default data setup.

Environments that rely on this script to generate initial data will no longer receive Plan and Build job types automatically. If Plan and Build job types are required, they must be set up separately through the dedicated Plan and Build tooling.

### Fixes

#### Asset Manager: Incorrect default date for asset class lifecycle fields [ID 45697]

Up to now, the End of Life and End of Service fields in the asset class lifecycle editor by default showed a minimum date value when no value had been previously set. These fields now correctly show the current UTC date and time by default.
