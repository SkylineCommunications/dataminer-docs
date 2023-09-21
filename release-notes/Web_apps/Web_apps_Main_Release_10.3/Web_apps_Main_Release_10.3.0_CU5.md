---
uid: Web_apps_Main_Release_10.3.0_CU5
---

# DataMiner web apps Main Release 10.3.0 CU5

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Main Release 10.3.0 CU5](xref:General_Main_Release_10.3.0_CU5).

### Enhancements

#### Low-Code Apps - Action editor: 'Which scheduler?' button has now been renamed to 'Which timeline?' [ID_36530]

<!-- MR 10.3.0 [CU5] - FR 10.3.8 -->

In the action editor, the *Which scheduler?* button has now been renamed to *Which timeline?*.

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

#### GQI - 'Get parameters for elements where' data source: columnInfo object of columns of type 'discrete' will now contain the possible values [ID_36702]

<!-- MR 10.3.0 [CU5] - FR 10.3.8 -->

For each of the columns of type "discrete" in the *Get parameters for elements where* data source (InterElementAdapter), the possible values will now be available in their columnInfo object.

### Fixes

#### Low-Code Apps: Application would be updated each time you hit a key after changing a page name [ID_36479]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

When you changed the name of a low-code app page, the application would incorrectly be updated each time you hit a key. From now on, the application will be updated 250 ms after the last keystroke.

#### Dashboards app & Low-Code Apps: Problem when migrating a query to the current GQI version [ID_36552]

<!-- MR 10.3.0 [CU5] - FR 10.3.8 -->

When you opened a query that was created using an older GQI version, and that query was configured to start from another query recursively in combination with joins, in some cases, it would incorrectly be migrated to the current GQI version.

#### Dashboards app & Low-Code Apps: Problem when sending updates to the Web API when the user did not have edit rights [ID_36571]

<!-- MR 10.3.0 [CU5] - FR 10.3.7 [CU0] -->

When a pie chart or a bar chart had its settings changed automatically, in some cases, an update would be triggered in the background, causing the Web API to throw an error when the user did not have edit rights. From now on, when the user does not have edit rights, updates will no longer be sent to the Web API.

#### Dashboards app: Problem when a pie or bar chart was updated in the background on a volatile dashboard [ID_36576]

<!-- MR 10.3.0 [CU5] - FR 10.3.8 -->

When a pie chart or a bar chart on a volatile dashboard had its settings changed automatically, in some cases, an update would be triggered in the background, causing the Web API to throw an error.

#### Dashboards app & Low-Code Apps: Pie chart components would not update properly [ID_36612]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

Pie chart components would not update properly while visualizing data from a query with variable input, especially when the number of rows returned by the query changed.

#### Dashboards app & Low-Code Apps: Changes in grouped feed data would not get detected [ID_36615]

<!-- MR 10.3.0 [CU5] - FR 10.3.8 -->

When the feed data linked to a query was grouped, changes to that feed data would not get detected by the query. In other words, the GQI components showing the result of the query would not update when data selection changed in the feed.

#### Dashboards app & Low-Code Apps: Problem with large tables in PDF reports [ID_36616]

<!-- MR 10.3.0 [CU5] - FR 10.3.7 [CU0] -->

When you generated a PDF report of a dashboard that contained a large table, in the PDF report, the table would incorrectly not contain all rows. Moreover, the rows in the table would all show a loading state.

#### Dashboards app & Low-Code Apps - Numeric input component: Input field would incorrectly be set to the minimum value after a refresh [ID_36677]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

Up to now, when a numeric input component had a non-zero minimum value set, the input field would automatically be set to that minimum value after a refresh. From now on, the input field will remain empty after a refresh, even when a minimum value is configured.
