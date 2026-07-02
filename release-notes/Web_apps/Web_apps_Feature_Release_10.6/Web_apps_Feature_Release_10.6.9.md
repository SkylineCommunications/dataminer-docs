---
uid: Web_apps_Feature_Release_10.6.9
---

# DataMiner web apps Feature Release 10.6.9 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner web applications contains the same new features, enhancements, and fixes as DataMiner web apps Main Release 10.6.0 [CU6].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.9](xref:General_Feature_Release_10.6.9).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.9](xref:Cube_Feature_Release_10.6.9).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### GQI components / Web API: Discrete column values will now be objects containing possible values and an 'IsStrict' flag [ID 45388]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

From now on, discrete column values in a GQI query result will no longer be arrays of possible values. Instead, they will be objects containing possible values and an `IsStrict` flag.

This change will only have a functional impact when columns are requested for parameter trend data of discrete parameters using GQI via SLHelper. In that case, discrete columns containing discrete values that do not match the column type will no longer be available in the client.

#### Web apps: Redesigned datetime controls now fully support custom time zones set by the client [ID 45687]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

Because of a number of enhancements, the redesigned datetime controls will now fully support any custom time zones set by the client.

This also means that these controls will now be better able to deal with transitions to and from daylight saving time.

#### GQI DxM - 'Get parameters for elements where': Possible to select either a full table or a subset of columns [ID 45692]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

Up to now, when you selected the parameter(s) for the *Get parameters for elements where* data source, it would only be possible to select standalone parameters and table parameters. It was not possible to select specific columns of a table.

From now on, when selecting a table parameter, it will be possible to select either the full table or a subset of columns.

> [!NOTE]
> It is not possible to mix columns from different tables or to combine a table with standalone parameters.

#### Web apps: About box will now also show the version of the DataMiner Assistant DxM [ID 45833]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

From now on, the About box will also show the version of the DataMiner Assistant DxM.

If this DxM is not installed or not enabled, "Not installed" will be displayed instead of the version.

#### Web apps - Help menu: Feedback command replaced by a feedback submenu [ID 45853]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

In the help menu of the web apps, the *Feedback* command has been replaced by a submenu with the following two commands:

- [Share your experience](https://aka.dataminer.services/help-feedback-root)
- [Report an issue](https://aka.dataminer.services/ReportAnIssue)

### Fixes

#### Dashboards/Low-Code Apps - Table component: Correct column widths would not be applied after the table had been resized or updated [ID 45765]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

In some rare cases, a *Table* component would incorrectly not apply the correct column widths after the table had been resized or updated. This led to columns being hidden when they had to be visible.

#### GQI DxM could become unrecoverable when the initial DataMiner state subscription failed [ID 45830]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

When the GQI DxM established an SLNet connection but failed to set up the initial DataMiner state subscription, it could remain in an unrecoverable state.

Now, the subscription step is treated as part of connection establishment. If that step fails, the connection is considered failed and is retried.
