---
uid: InfraOps_1.2.0
---

# InfraOps 1.2.0

## Changes

### Enhancements

#### Automatic SDM registration on installation [ID 45558]

InfraOps now automatically registers itself with the DataMiner Software-Defined Management (SDM) catalog each time the solution is installed or upgraded. A new Automation script, i.e. *InfraOps - Register Solutions*, is invoked as part of the standard installation flow and records the solution's unique catalog identifier, display name, and current version in the SDM system.

The installed version of InfraOps is reported to the SDM registry automatically upon deployment, enabling consistent version visibility and catalog management across all DataMiner environments.

No configuration changes or manual steps are required by operators. The registration runs transparently during installation using the Skyline.DataMiner.SDM.Registration.Automation library, and it correctly handles both fresh installations and upgrades by creating a new registration entry or updating an existing one.
