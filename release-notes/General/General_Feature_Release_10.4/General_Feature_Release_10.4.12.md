---
uid: General_Feature_Release_10.4.12
---

# General Feature Release 10.4.12 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.4.12](xref:Cube_Feature_Release_10.4.12).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.4.12](xref:Web_apps_Feature_Release_10.4.12).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

#### Interactive Automation scripts: New option to skip the confirmation window when aborting [ID 40683]

<!-- MR 10.5.0 - FR 10.4.12 -->

`UIBuilder` now has a new `SkipAbortConfirmation` property. When set to true, the confirmation window will not be displayed when the interactive Automation script is aborted. By default, this property will be set to false.

Example:

```csharp
UIBuilder uib = new UIBuilder();
uib.SkipAbortConfirmation = true;
```

> [!TIP]
> See also: [Interactive Automation scripts: New option to skip the confirmation window when aborting [ID 40720]](xref:Cube_Feature_Release_10.4.12#interactive-automation-scripts-new-option-to-skip-the-confirmation-window-when-aborting-id-40720)

## Changes

### Enhancements

#### OpenSearch: Enhanced performance of alarm queries [ID 40674]

<!-- MR 10.4.0 [CU9] - FR 10.4.12 -->

Alarm filters containing brackets can now be translated to OpenSearch queries. This will considerably improve overall performance of alarm queries against OpenSearch databases.

### Fixes

#### Problem with alarm severity of a service not being updated correctly [ID 40840]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

In some cases, the alarm severity of a service would not be updated correctly when, during a row update, both the display key and the monitored value had been changed.

#### Failover: Problem with SLSNMPManager at startup [ID 40883]

<!-- MR 10.3.0 [CU21]/10.4.0 [CU9] - FR 10.4.12 -->

When a DataMiner Agent that was part of a Failover setup started up, in some cases, SLSNMPManager could stop working.
