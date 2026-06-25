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

This change will only have an impact when a GQI query executed using SLHelper requests parameter trend data for discrete parameters. In that case, discrete columns containing discrete values that do not match the column type will no longer be available in the client.

#### Web apps: Redesigned datetime controls now fully support custom time zones set by the client [ID 45687]

<!-- MR 10.5.0 [CU18] / 10.6.0 [CU6] - FR 10.6.9 -->

Because of a number of enhancements, the redesigned datetime controls will now fully support any custom time zones set by the client.

This also means that these controls will now be better able to deal with transitions to and from daylight saving time.

### Fixes

*No fixes have been added yet.*
