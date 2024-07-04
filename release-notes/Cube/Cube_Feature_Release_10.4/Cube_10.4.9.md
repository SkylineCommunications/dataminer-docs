---
uid: Cube_Feature_Release_10.4.9
---

# DataMiner Cube Feature Release 10.4.9 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.4.9](xref:General_Feature_Release_10.4.9).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### System Center - Agents: Some buttons will no longer be visible when Cube is connected to a DaaS system [ID_40013]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When Cube is connected to a DaaS system, the following buttons will no longer be visible in the *Agents* section of *System Center*:

- *Stop*
- *Shut down*
- *Reboot*
- *Failover...*

Also, the user permissions that control access to these buttons will no longer be visible:

- *Modules > System configuration > Agents > Stop*
- *Modules > System configuration > Agents > Shut down*
- *Modules > System configuration > Agents > Reboot*
- *Modules > System configuration > Agents > Configure Failover*

### Fixes

#### Visual Overview: 'Get Protocol' requests would be sent in an incorrect thread [ID_39543]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When *Children* shapes were being used, in some cases, *Get protocol* requests would be sent in an incorrect thread.

#### Alarm templates and trend templates: Incorrectly possible to configure analytics features for parameters that did not support those features [ID_39952]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When configuring alarm templates and trend templates, up to now, it would incorrectly be possible to configure behavioral anomaly detection, proactive cap detection and trend icons for parameters that did not support those features.

#### Visual Overview: DCF connections would incorrectly be drawn from the center of the shapes when dynamic values were used [ID_39957]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When dynamic values were used in interface shapes that were child shapes on an element group, and those shapes did not have the *AllowCentralConnectivity* option enabled, in some cases, the DCF connections would incorrectly be drawn from the center of the shapes instead of their interfaces.
