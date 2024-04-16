---
uid: DIS_2.48
---

# DIS 2.48

> [!IMPORTANT]
> This will be the last version that has support for Visual Studio 2019.
>
> Visual Studio 2019 went out of support on April 9, 2024: [Support Dates](https://learn.microsoft.com/en-us/lifecycle/products/visual-studio-2019)

## New features

### IDE

#### Show message when package is being uploaded [ID_38846]

When publishing a connector or automation script an overlay will be shown to indicate that the package is being uploaded.

### Validator

DIS is using [Validator version 1.1.3](https://github.com/SkylineCommunications/Skyline.DataMiner.CICD.Validators/releases/tag/1.1.3).

## Changes

### Enhancements

#### Improved Settings > Account tab with clearer statuses [ID_39419]

In the *Settings* menu under the *Account* tab, new statuses have been added to give a clearer indication if something goes wrong when signing in in DIS.

- *SkylineAPI status*: Is api.skyline.be reachable?
- *Account login status*: Can the user authenticate to api.skyline.be?
- *Account status*: Is the license correct?

In addition all mentions of the DIS license has been renamed to account or authorization as it was often confusing for users to see a failed license check whilst DIS was free and the issue wasn't related to the license.
