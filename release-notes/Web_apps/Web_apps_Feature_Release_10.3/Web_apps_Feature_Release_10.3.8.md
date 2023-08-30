---
uid: Web_apps_Feature_Release_10.3.8
---

# DataMiner web apps Feature Release 10.3.8

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.3.8](xref:General_Feature_Release_10.3.8).

## Features

#### Dashboards app & Low-Code Apps - Table component: Selecting whether to export raw values or display values to CSV [ID_36467]

<!-- MR 10.4.0 - FR 10.3.8 -->

You can export the data displayed by a table component by clicking the ... button in the top-right corner of the component and selecting *Export to CSV*. From now on, a pop-up window will open where you can select whether the raw values or the display values from the table should be exported.

Exporting the display values will result in a CSV file that contains all the values as they are seen in the table, formatted and with units. If you export the raw values, no formatting will be applied to them. The only exception are discrete values, for which the corresponding display values will always be exported.

If no rows are selected in the table, the entire table will be exported; otherwise only the selected rows will be exported.

## Changes

### Enhancements

#### Monitoring app: Parameter values that are URLs will now be rendered as clickable hyperlinks [ID_36423]

<!-- MR 10.4.0 - FR 10.3.8 -->

From now on, when a parameter value is a URL starting with one of the following prefixes it will be rendered as a clickable hyperlink:

- file://
- ftp://
- http://
- https://
- mailto://

#### GQI: Enhanced behavior of aggregations applied on empty Elasticsearch tables [ID_36490]

<!-- MR 10.3.0 [CU6] - FR 10.3.8 -->

Up to now, when an aggregation (min, max, average) was applied on an empty Elasticsearch table, the following exception would be thrown:

`Error trapped: Elastic returned unexpected value ''.`

From now on, when an aggregation (min, max, average) is applied on an empty Elasticsearch table, an empty cell will be returned instead.

Because of this change, the behavior of aggregations applied on all types of empty tables becomes more consistent:

| Type | RawValue | DisplayValue |
|------|----------|--------------|
| Avg/Min/Max/Median | null | "Not applicable" |
| (Distinct) Count   | 0    | 0                |
| Std dev/Percentile | null | "Not applicable" |
| Sum                | 0    | 0                |

#### Low-Code Apps - Action editor: 'Which scheduler?' button has now been renamed to 'Which timeline?' [ID_36530]

<!-- MR 10.3.0 [CU5] - FR 10.3.8 -->

In the action editor, the *Which scheduler?* button has now been renamed to *Which timeline?*.

#### Dashboards app & Low-Code Apps - Clock components: Custom time zone [ID_36534]

<!-- MR 10.4.0 - FR 10.3.8 -->

When configuring an analog or digital *Clock* component, you can now make the clock display the date and time in a specific time zone.

To do so, select the *Custom time zone* option, and select a time zone from the *Time zone* selection box.

#### DataMiner Comparison tool: Enhancements [ID_36570]

<!-- MR 10.4.0 - FR 10.3.8 -->

A number of enhancements have been made to the DataMiner Comparison tool. This web application allows you to compare the values of two string parameters on a character-by-character basis and to immediately spot the differences (additions, modifications, and deletions).

#### Monitoring app: A new type of datetime boxes will now be used on parameter pages [ID_36606]

<!-- MR 10.4.0 - FR 10.3.8 -->

In the *Monitoring* app, a new type of datetime boxes will now be used on parameter pages.

**BREAKING CHANGE**: When the value of a date or datetime parameter is set using one of the following API methods, that value must now be passed as a Unix timestamp in milliseconds instead of an OLE Automation date.

- SetParameter
- SetParameterRow

**BREAKING CHANGE**: When values of date or datetime parameters are retrieved using one of the following API methods, those values will now be Unix timestamps in milliseconds instead of OLE Automation dates.

- GetEditParameter
- GetEditParameterTable
- GetMonitoredParametersForElement
- GetMonitoredParametersForService
- GetParameter
- GetParameterByName
- GetParameterForService
- GetParameterForServiceWithDynamicUnits
- GetParameters
- GetParametersByPageForElement
- GetParametersByPageForElementCached
- GetParametersByPageForElementSorted
- GetParametersByPageForServiceElement
- GetParametersForElement
- GetParametersForElementFiltered
- GetParametersForElementSorted
- GetParametersForService
- GetParametersForServiceSorted
- GetParametersSorted
- GetParameterWithDynamicUnits
- ObserveParameter

#### Dashboards app & Low-Code Apps: Enhanced error handling while exporting trend data to a CSV file [ID_36627]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

A number of enhancements have been made with regard to error handling while exporting trend data to a CSV file.

#### GQI session recording: Time and disk space limits [ID_36642]

<!-- MR 10.3.0 [CU5] - FR 10.3.8 -->

GQI session recording is a debugging feature that allows you to save GQI communication and replay it in a lab environment. This feature is disabled by default.

To create a recording:

1. On the DataMiner Agent, create the folder `C:\Skyline DataMiner\logging\genif`.
1. Perform the operation that needs to be recorded.
1. Save the files written to `C:\Skyline DataMiner\logging\genif`.
1. Delete the folder to disable recording.

As a precaution against these recordings taking too much disk space, the following limits will now be enforced:

- A time limit of *1 hour*

  When a new recording is created, all previous recordings older than 1 hour will be deleted.

- A disk space limit of *100 MB*

  When a new recording is created, older recordings will be deleted until the total size of the `C:\Skyline DataMiner\logging\genif` folder is less than 100 MB. The oldest recordings will be deleted first.

> [!NOTE]
>
> - Currently, the above-mentioned limits are hard-coded. However, in one of the following releases, they will become configurable.
> - These enhancements will now prevent the following known issue from occurring: [GenIf folder takes up too much disk space](xref:KI_GenIf_Folder_Growing_In_Size).
> - See also [Keeping a DMA from running out of disk space](xref:Keeping_a_DMA_from_running_out_of_disk_space)

#### Dashboards app - GQI: Change detection in 'Start from' queries [ID_36690]

<!-- MR 10.4.0 - FR 10.3.8 -->

Up to now, queries that were built upon another query that was linked to feeds would not get updated when one of those feeds changed its value. Neither would queries built upon a base query be updated when the base query was changed.

From now on, when a base query is changed in any way, all queries that use that base query will automatically be updated as well.

#### GQI - 'Get parameters for elements where' data source: columnInfo object of columns of type 'discrete' will now contain the possible values [ID_36702]

<!-- MR 10.3.0 [CU5] - FR 10.3.8 -->

For each of the columns of type "discrete" in the *Get parameters for elements where* data source (InterElementAdapter), the possible values will now be available in their columnInfo object.

### Fixes

#### Dashboards app & Low-Code Apps: Only one of the tables sharing an empty query would show a visual replacement [ID_36233]

<!-- MR 10.4.0 - FR 10.3.8 -->

When an empty query was used by more than one table component, in some rare cases, only one of those components would display a visual replacement.

#### Low-Code Apps: Not possible to save empty DOM fields [ID_36276]

<!-- MR 10.4.0 - FR 10.3.8 -->

When a DOM instance was created or edited in a low-code app, empty fields would incorrectly not be sent to the server. This meant that it was not possible to clear a non-empty field.

#### Low-Code Apps: A blank screen would appear when users without permission to access a low-code app tried to log on [ID_36422]

<!-- MR 10.4.0 - FR 10.3.8 -->

When users without permission to access a low-code app tried to log on to that app, an error would be thrown and a blank screen would appear. From now on, when users without permission to access a low-code app try to log on to that app, an appropriate message will appear instead.

#### Low-Code Apps: Application would be updated each time you hit a key after changing a page name [ID_36479]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

When you changed the name of a low-code app page, the application would incorrectly be updated each time you hit a key. From now on, the application will be updated 250 ms after the last keystroke.

#### Dashboards app & Low-Code Apps: Problem when migrating a query to the current GQI version [ID_36552]

<!-- MR 10.3.0 [CU5] - FR 10.3.8 -->

When you opened a query that was created using an older GQI version, and that query was configured to start from another query recursively in combination with joins, in some cases, it would incorrectly be migrated to the current GQI version.

#### Dashboards app: Problem when a pie or bar chart was updated in the background on a volatile dashboard [ID_36576]

<!-- MR 10.3.0 [CU5] - FR 10.3.8 -->

When a pie chart or a bar chart on a volatile dashboard had its settings changed automatically, in some cases, an update would be triggered in the background, causing the Web API to throw an error.

#### Dashboards app & Low-Code Apps: Bar and pie chart components would display incorrect data [ID_36601]

<!-- MR 10.4.0 - FR 10.3.8 -->
<!-- Not added to MR 10.4.0 -->

In DataMiner feature version 10.3.7, when a dashboard or a low-code app contained bar or pie chart components that displayed GQI data, in some cases, those charts would display incorrect data due to a settings issue.

#### Dashboards app & Low-Code Apps: Pie chart components would not update properly [ID_36612]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

Pie chart components would not update properly while visualizing data from a query with variable input, especially when the number of rows returned by the query changed.

#### Dashboards app & Low-Code Apps: Changes in grouped feed data would not get detected [ID_36615]

<!-- MR 10.3.0 [CU5] - FR 10.3.8 -->

When the feed data linked to a query was grouped, changes to that feed data would not get detected by the query. In other words, the GQI components showing the result of the query would not update when data selection changed in the feed.

#### Authentication app: Problem with 'Keep me logged in' option [ID_36647]

<!-- MR 10.4.0 - FR 10.3.8 -->
<!-- Not added to MR 10.4.0 -->

When you logged in to a web app with the *Keep me logged in* option enabled, then the authentication app would log you back in automatically only once. After that, you had to log back in manually.

#### Monitoring app: Problem when receiving parameter table updates via polling [ID_36660]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.8 -->

When, in the *Monitoring* app, a parameter table received updates via polling, the table would display `There is no data to display`.

#### Dashboards app & Low-Code Apps - Table component: Problem when trying to display null values returned by the query [ID_36669]

<!-- MR 10.4.0 - FR 10.3.8 -->

When a query linked to a table component returned null values, errors would be thrown when the table component tried to display those null values.

#### Dashboards app: An empty menu would open when users with only 'View dashboards' permission clicked the '...' button [ID_36671]

<!-- MR 10.4.0 - FR 10.3.8 -->

When users who only had permission to view dashboards clicked the *...* button in the top-right corner of the navigation pane, an empty menu would open.

From now on, users who only have permission to view dashboards will not see any *...* button in the top-right corner of the navigation pane.

#### Dashboards app & Low-Code Apps - Numeric input component: Input field would incorrectly be set to the minimum value after a refresh [ID_36677]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

Up to now, when a numeric input component had a non-zero minimum value set, the input field would automatically be set to that minimum value after a refresh. From now on, the input field will remain empty after a refresh, even when a minimum value is configured.

#### Dashboards app: Problem when making changes to a dashboard when having that same dashboard open in two separate windows [ID_36718]

<!-- MR 10.4.0 - FR 10.3.8 -->

When you had opened the same dashboard in edit mode in two separate windows, the moment you made a change in one of the windows, a number of popup windows displaying "New version is available" would appear on top of the other window.
