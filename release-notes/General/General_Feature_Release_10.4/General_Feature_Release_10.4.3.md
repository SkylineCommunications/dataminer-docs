---
uid: General_Feature_Release_10.4.3
---

# General Feature Release 10.4.3 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!IMPORTANT]
> When downgrading from DataMiner Feature Release version 10.3.8 (or higher) to DataMiner Feature Release version 10.3.4, 10.3.5, 10.3.6 or 10.3.7, an extra manual step has to be performed. For more information, see [Downgrading a DMS](xref:MOP_Downgrading_a_DMS).

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.4.3](xref:Cube_Feature_Release_10.4.3).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.4.3](xref:Web_apps_Feature_Release_10.4.3).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected yet.*

## New features

#### DataMiner Maps: ForeignKeyRelationsSourceInfo tag now supports an elementVar attribute [ID_38274]

<!-- MR 10.4.0 - FR 10.4.3 -->

In a `<ForeignKeyRelationsSourceInfo>` tag, it is now possible to specify an *elementVar* attribute.

```xml
<ForeignKeyRelationsSourceInfo elementVar="myElement">
...
</ForeignKeyRelationsSourceInfo>
```

This will allow you to pass an element in the map's URL. See the URL examples below (notice the “d” in front of the parameter name!):

```txt
maps.aspx?config=MyConfigFile&dmyElement=7/46840
maps.aspx?config=MyConfigFile&dmyElement=VesselData
```

## Changes

### Enhancements

#### SLAnalytics - Alarm focus: Alarm occurrences will now be identified using a combination of element ID, parameter ID and primary key  [ID_38184]

<!-- MR 10.4.0 - FR 10.4.3 -->

When calculating alarm likelihood (i.e. focus score), up to now, the alarm focus feature used a combination of element ID, parameter ID and display key (if applicable) to identify previous occurrences of the same alarm. From now on, previous alarm occurrences will be identified using a combination of element ID, parameter ID and primary key.

#### DataMiner Object Models: Required list fields can no longer be set to an empty list [ID_38238]

<!-- MR 10.5.0 - FR 10.4.3 -->

From now on, when the value of a required list field is set to an empty list, one of the following errors will be thrown:

- `DomInstanceHasMissingRequiredFieldsForCurrentStatus` (when using the DOM status system)
- `DomInstanceDoesNotContainAllRequiredFieldsForSectionDefinition` (when not using the DOM status system)

#### Security enhancements [ID_38263]

<!-- 38263: MR 10.5.0 - FR 10.4.3 -->

A number of security enhancements have been made.

### Fixes

#### Correlation: Alarm buckets would not get cleaned up when alarms were cleared before the end of the time frame specified in the 'Collect events for ... after first event, then evaluate conditions and execute actions' setting [ID_38292]

<!-- MR 10.3.0 [CU12]/10.4.0 [CU0] - FR 10.4.3 -->

Up to now, when alarms were cleared before the end of the time frame specified in the *Collect events for ... after first event, then evaluate conditions and execute actions* correlation rule setting, the alarm buckets would not get cleaned up.

From now on, when a correlation rule is configured to use the *Collect events for ... after first event, then evaluate conditions and execute actions* trigger mechanism, all alarm buckets will be properly cleaned up, unless there are actions that need to be executed either when the base alarms are updated or when alarms are cleared.
