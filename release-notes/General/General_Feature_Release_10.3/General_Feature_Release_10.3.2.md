---
uid: General_Feature_Release_10.3.2
---

# General Feature Release 10.3.2 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.3.2](xref:Cube_Feature_Release_10.3.2).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## Highlights

*No highlights have been selected for this release yet*

## Other features

#### All DOM objects now have 'LastModified', 'LastModifiedBy', 'CreatedAt' and 'CreatedBy' properties [ID_34980]

<!-- MR 10.4.0 - FR 10.3.2 -->

All DOM objects (DomInstance, DomTemplate, DomDefinition, DomBehaviorDefinition, SectionDefinition and ModuleSettings) will now contain the following additional properties:

- *LastModified*: Date/time (UTC) at which the object was last modified.
- *LastModifiedBy*: Full username of the user who last modified the object.
- *CreatedAt*: Date/time (UTC) at which the object was created.
- *CreatedBy*: Full username of the user who created the object.

> [!NOTE]
>
> - *CreatedAt* and *CreatedBy* are automatically populated when the object is created. Any value assigned to these two fields by a user will always be discarded.
> - *LastModified* and *LastModifiedBy* are automatically updated when the object is updated on the server. Any value assigned to these two fields by a user will always be discarded. When an object is created, these fields will contain the same values as *CreatedAt* and *CreatedBy*.
> - These four fields are not directly accessible on the object. You first need to cast them to either *ITrackBase* or their individual interfaces (*ITrackLastModified*, *ITrackLastModifiedBy*, *ITrackCreatedAt* and *ITrackCreatedBy*).
>
>   `string createdBy = ((ITrackBase) domInstance).CreatedBy;`
>
> - These four fields can all be used in a filter.
> - In the Elasticsearch database, existing data will not contain values for these new fields (except the *LastModified* field for all but *ModuleSettings*).
> - All four fields are also available in the GQI data source *Object Manager Instances*. The *Last Modified* and *Created At* columns should show the time in the time zone of the browser.

#### Dashboards app - GQI: New 'Get trend data patterns' data source [ID_35024]

<!-- MR 10.3.0 - FR 10.3.2 -->

In the Generic Query Interface, a new *Get trend data patterns* data source is now available. It will return all trend data patterns in the DMS.

## Changes

### Enhancements

#### SLLogCollector will now first check for default.xml files in the LogConfig folder in the same location as SL_LogCollector.exe [ID_34739]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

Up to now, SLLogCollector expected custom collector configuration files named `default.xml` to always be placed in the `C:\Skyline DataMiner\Tools\SLLogCollector\LogConfigs` folder.

From now on, it will first check the `LogConfig` folder in the same location as `SL_LogCollector.exe`. If that `LogConfig` folder does not exist, if the folder is empty or if the `default.xml` file in that folder cannot be deserialized, it will fall back on the `default.xml` file in the `C:\Skyline DataMiner\Tools\SLLogCollector\LogConfigs` folder.

#### Web apps - Interactive Automation scrips: Fields containing invalid values will now be indicated more clearly [ID_34962]

<!-- MR 10.4.0 - FR 10.3.2 -->

When, in an Automation script launched from a web app, an input field contains an invalid value, the border of that field will turn red. This red border will now be wider in order to be more visible.

#### GQI: Enhanced performance of GQI queries [ID_34977]

<!-- MR 10.4.0 - FR 10.3.2 -->

Because of a number of enhancements, overall performance of GQI queries has increased, especially when those queries contain join operations.

#### NAS service will now have a quoted image path [ID_34989]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

Up to now, the NAS service had an unquoted image path. From now on, it will instead be installed with a quoted path.

When you want the NAS service on existing setups to have a quoted path, do the following:

1. Execute the following command:

   `sc config NAS binPath="\"C:\Skyline DataMiner\NATS\nats-account-server\nssm.exe\""`

1. Restart NAS and NATS.

#### GQI: Enhanced performance of GQI queries using the 'Get parameters for elements where' data source [ID_35005]

<!-- MR 10.4.0 - FR 10.3.2 -->

Because of a number of enhancements, overall performance of GQI queries using the *Get parameters for elements where* data source has increased.

#### Dashboards app - Line & area chart: Multiple timespans will now be converted to one single time range [ID_35008]

<!-- MR 10.4.0 - FR 10.3.2 -->

When a line & area chart component is fed a collection of timespans, it will now convert those timespans to one single time range.

For example, when a line & area chart component is fed the following timespans...

- *01/01/2022 9:00:00 > 01/01/2022 10:00:00*
- *01/01/2022 9:30:00 > 01/01/2022 10:30:00*

... it will convert those timespans into the following time range:

- *01/01/2022 9:00:00 > 01/01/2022 10:30:00*

#### Service & Resource Management: Enhanced performance when adding and updating bookings [ID_35016]

<!-- MR 10.3.0 - FR 10.3.2 -->

Because of a number of enhancements, overall performance has increased when creating and updating bookings.

### Fixes

#### Problem with Elasticsearch health monitoring [ID_34744]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When an Elasticsearch cluster used by DataMiner was hosted on servers that host IPv6 addresses, the Elasticsearch health monitoring in DataMiner would fail to assess the Elasticsearch cluster state and conclude that the indexing database was unavailable.

#### Problem with SLDataMiner when loading an alarm template schedule failed [ID_34988]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

In some cases, an error could occur in SLDataMiner when loading an alarm template schedule failed.

#### Dashboards app: Button to restore the initial view would incorrectly appear on all tables after sorting or filtering a table [ID_35003]

<!-- MR 10.3.0 - FR 10.3.2 -->

When, on a dashboard, you sorted or filtered a table, a button to restore the initial view would incorrectly appear on all tables on that dashboard. Also, when you clicked one of those buttons, they would all disappear. From now on, when you sort or filter a table on a dashboard, a button to restore the initial view will only appear on that particular table.

#### Web apps - Visual Overview: Certain actions would no longer work [ID_35012]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

In some cases, *Card*, *Script*, *Link* and *Popup* actions would no longer work in visual overviews opened in web apps.

#### SLLogCollector would only take a dump of the first process when multiple processes were specified in the -d command-line option [ID_35074]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When you ran SLLogCollector via the command line and specified multiple processes for which dumps had to be taken (e.g. `SL_LogCollector.exe -c -d=46436,61652`), it would incorrectly only take a dump of the first process.

#### Monitoring app: Problem when opening the histogram page of a view [ID_35081]

<!-- MR 10.3.0 - FR 10.3.2 -->

When, in the *Monitoring* app, you selected a view and opened the histogram page, in some cases, a `Maximum call stack size exceeded` error would appear.

#### Automation: Memory leak when using the engine.AddScriptOutput method to pass script output of type string [ID_35119]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When an engine.AddScriptOutput method was used to pass output data of type string from a script to the application that executed it or from a subscript to the script that executed that subscript, that output data of type string would incorrectly not get cleared from memory.
