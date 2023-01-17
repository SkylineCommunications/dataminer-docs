---
uid: Cube_Feature_Release_10.3.3
---

# DataMiner Cube Feature Release 10.3.3 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.3.2](xref:General_Feature_Release_10.3.3).

## Highlights

*No highlights have been selected for this release yet*

## Other features

#### System Center: New DataMiner log file 'SLSmartBaselineManager.txt' [ID_35352]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 [CU0] -->

In the *Logging* section of *System Center*, you can now also consult the *SLSmartBaselineManager.txt* log file.

## Changes

### Enhancements

#### Elasticsearch: 'Request Entity Too Large (413)' errors will now be prevented when writing data in bulk [ID_34937]

<!-- MR 10.4.0 - FR 10.3.3 -->

When data was written to Elasticsearch in bulk, up to now, DataMiner would throw a `Request Entity Too Large (413)` error when the amount of data exceeded the 100 MB limit.

From now on, DataMiner will detect when too much data is being sent in a single request and will split up the data into smaller parts.

#### DataMiner Cube will now immediately be aware of any changes as to the availability of Cassandra or Elasticsearch [ID_35209]

<!-- MR 10.3.0 - FR 10.3.3 -->

Up to now, Cube would only check at startup whether Cassandra or Elasticsearch were available. From now on, it will immediately be aware of any changes as to the availability of Cassandra or Elasticsearch.

#### Dashboards - Line & area chart component: 'Show average', 'Show minimum' and 'Show maximum' options will now be taken into account when exporting trend data to CSV [ID_35311]

<!-- MR 10.4.0 - FR 10.3.3 -->

When exporting trend data to CSV, from now on, the *Show average*, *Show minimum* and *Show maximum* options will be taken into account.

> [!NOTE]
>
> - When the *Show min/max shading* option is enabled (which it is by default), minimum and maximum values will always be included when you export trend data.
> - As the *Show min/max shading* option and the *Show average* option are both enabled by default, a CSV export of trend data will by default contain all trend data values.

### Fixes

#### Alarm Console: Multiple values in property columns would incorrectly not be separated by any separator [ID_35239]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

If, in the Alarm Console, property columns are added for service or view properties, and an alarm affects more than one service or view, this can result in property columns containing multiple property values.

In the *PropertyConfiguration.xml* file, for each relevant property you can configure a *contentSeparator* tag. The separator specified in that tag will then be used to separate the values of that property.

Up to now, when a *contentSeparator* tag was left empty, the values of the property in question would incorrect not be separated by any separator. From now on, when that tag is empty, the values of the property in question will by default be separated by commas.

#### Trending: Problem when exporting a trend graph containing average trend data [ID_35290]

<!-- MR 10.3.0 - FR 10.3.3 -->

When you exported a trend graph containing average trend data to CSV, in some cases, the exported data would be parsed incorrectly.

#### ListView component: Column filter boxes incorrectly had autocomplete enabled [ID_35296]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

In a *ListView* component, you can click the filter icon of a particular column and enter a filter in the box below the column header.

Up to now, those column filter boxes incorrectly had *autocomplete* enabled.

#### Visual Overview: Problem after filtering bookings using a custom time range in ListView component or Resource Manager component [ID_35328]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When, in a ListView component or a Resource Manager component showing a bookings timeline, you had filtered the bookings using a custom time range, performance issues could start to occur after a period of time.

#### DataMiner Cube - Visual Overview: Problem when editing a discrete parameter with a 'Sequence' tag displayed in a lite parameter control [ID_35356]

<!-- MR 10.2.0 [CU12] - FR 10.3.3 -->

When a discrete parameter with a `<Sequence>` tag was displayed in a lite parameter control, its current value would neither be displayed nor selected while being edited.

#### Trending: Pattern matching tags could incorrectly be defined for discrete or string parameters [ID_35368]

<!-- MR 10.4.0 - FR 10.3.3 -->

Pattern matching does not support discrete or string parameters. However, up to now, when viewing a trend graph that showed trend information for either a discrete or a string parameter, it would incorrectly be possible to define tags for pattern matching. From now on, this will no longer be possible.
