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

#### Trending: Light bulb in top-right corner of trend graphs is now better visible in the Skyline Black theme [ID_40059]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

The color of the light bulb in the top-right corner of trend graphs has been made brighter to make the light bulb better visible in the Skyline Black theme.

#### Alarm templates & trend templates: Analytics trending features can no longer be configured for general parameters [ID_40086]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

Since the analytics trending features cannot be used for general parameters, from now on, the options to configure these features will no longer be available when you are configuring general parameters in an alarm template or a trend template.

Also, when a general parameter is being trended, it will no longer be possible to create a trend pattern for that parameter.

### Fixes

#### Visual Overview: 'Get Protocol' requests would be sent in an incorrect thread [ID_39543]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When *Children* shapes were being used, in some cases, *Get protocol* requests would be sent in an incorrect thread.

#### System Center - Agents: BPA tests would incorrectly show 'Execution failed' when connected to a DaaS system [ID_39929]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When DataMiner Cube was connected to a DaaS system, up to now, the test result of BPA tests than could not be run on a DaaS system would incorrectly be set to "Execution failed". From now on, BPA tests can have the status "Not applicable". If a BPA test cannot be run on a DaaS system, it will now correctly be flagged as "Not applicable".

For example, the *Minimum Requirements Check*, which cannot be run on a DaaS system, will now be set to "Not applicable" when Cube is connected to a DaaS system.

#### Alarm templates and trend templates: Incorrectly possible to configure analytics features for parameters that did not support those features [ID_39952]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When configuring alarm templates and trend templates, up to now, it would incorrectly be possible to configure behavioral anomaly detection, proactive cap detection and trend icons for parameters that did not support those features.

#### Visual Overview: DCF connections would incorrectly be drawn from the center of the shapes when dynamic values were used [ID_39957]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When dynamic values were used in interface shapes that were child shapes on an element group, and those shapes did not have the *AllowCentralConnectivity* option enabled, in some cases, the DCF connections would incorrectly be drawn from the center of the shapes instead of their interfaces.

#### Router Control: Problem when connecting an already connected output to a new input [ID_40076]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When, in the *Router Control* module, you connect an already connected output to a new input, the output first needs to be disconnected. Up to now, Cube would then send two messages: one to disconnect the output and another one to connect the output to the input. In some cases, those messages would be processed in the wrong order, causing the operation to fail.

From now on, disconnecting the output and connecting the output to the input will be performed in one single message.
