---
uid: ApplyingAlarmFiltersInTheAlarmConsole
---

# Applying alarm filters in the Alarm Console

## Using the Alarm Console quick filter box

In the lower right corner of the Alarm Console, a quick filter box is displayed.

This filter box can be used in different ways:

- Like any other quick filter in Cube, by adding text in the filter box. While you are typing, suggestions will be displayed above the box. When you empty the filter box, or return the focus to the filter box after it had been elsewhere, history items will also be displayed. To search for a suggested word or history item, select it in the list.

- Alternatively, it is also possible to add items to the quick filter box, or remove items from the quick filter box, by highlighting them in the Alarm Console. To do so, while pressing the key configured for this in the user settings (by default the left Ctrl key), click on the words you wish to add. You can also press this key and right-click a word to open a context menu with the following options:

  - *Add \[highlighted text\] to filter*

  - *Remove \[highlighted text\] from filter*: Only available if you have already added items to the filter.

  - *Exclude \[highlighted text\] in filter*: This option can only be used on an item that is not yet in the filter, and adds a negative filter for this item. This is the equivalent to adding an exclamation mark in front of an item when you type text in the filter.

  - *Search for \[selected text\] in new tab*: This option opens a new *Search alarms* tab in the Alarm Console, in which you can search through alarms using this filter. This option is only available on a DMA using at least DataMiner 10.0.0/10.0.2 with [Elasticsearch](xref:Elasticsearch_database).

    > [!NOTE]
    > Prior to DataMiner 10.0.7, to have access to this feature, you need to have the *System configuration* > *Indexing Engine* > *UI available* user permission. This user permission is only displayed if *?EnableFeature=Indexing* is added to the Cube URL. From DataMiner 10.0.7 onwards, this user permission is no longer needed.

  - *Copy \[highlighted text\]*

  - *Clear filter*: Only available if you have already added items to the filter.

  > [!TIP]
  > See also: [Cube settings](xref:User_settings#cube-settings)

When the filter is applied, the alarm tab is displayed with a blue background to indicate that it is being filtered. The total number of alarms is still indicated in the alarm bar, but the number of filtered alarms that are being displayed is added in parentheses.

## Using the Alarm Console quick filter buttons

It is possible to quickly filter an Alarm Console tab so that only alarms of a certain severity are shown.

To do so, click the button indicating the relevant severity in the alarm bar.

When the filter is applied, the alarm tab is displayed with a blue background to indicate that it is being filtered. The total number of alarms is still indicated in the alarm bar, but the number of filtered alarms that are being displayed is added in parentheses.

To quickly clear the filter again, click the leftmost field of the alarm bar, indicating the total number of alarms in the tab.

> [!NOTE]
> The UI of the Alarm Console adapts to the available space on the screen. If there is sufficient room, the different severity levels shown on the alarm tab will be written in full, with an indication of how many alarms have this severity level. If there is less space, only the severity color and the number of alarms with this severity will be displayed. In very narrow windows, a single button will be displayed, which opens a menu with the different severity levels that can be used for filtering.

## Manually applying an alarm filter in an Alarm Console tab

In the Alarm Console, you can add extra tab pages where you can specify a custom alarm filter.

> [!TIP]
> See also:
>
> - [Alarm Console – Advanced filtering](https://community.dataminer.services/video/alarm-console-advanced-filtering/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)
> - [Alarm Console – Alarm history](https://community.dataminer.services/video/alarm-console-alarm-history/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

To add such a filtered tab page:

1. Click the *+* symbol in the header of the Alarm Console.

1. Choose *Apply filters* or *Apply filter and window size*, depending on whether you want to see current alarms or history alarms, or alarms in a sliding window.

1. Specify the time for which alarms need to be retrieved:

   - For active alarms, skip this step.

   - For a history alarms, in the *From* and *To* boxes, specify the range for which alarms need to be displayed.

   - For alarms in a sliding window, specify the window size (between 1 minute and 1 day). The default window size is 60 minutes.

1. Click *Select a filter* to create or select a filter, then select the field you want to filter on.

   > [!NOTE]
   > If any filters have been saved on your DMS, you will be able to choose them in this step. See [Working with saved alarm filters](#working-with-saved-alarm-filters).

1. If you create a new filter, you will then need to specify it further, possibly using a wildcard expression or regular expressions.

   > [!NOTE]
   >
   > - For more information on wildcards, see [Searching with wildcard characters](xref:Searching_in_DataMiner_Cube#searching-with-wildcard-characters).
   > - For more information on using regular expressions in filters, see [Alarm filters using regular expressions](#alarm-filters-using-regular-expressions).
   > - From DataMiner 9.0.5 onwards, it is possible to filter the Alarm Console based on a Visual Overview session variable. To do so, create a new filtered tab displaying current alarms, and create a filter using *Matches wildcard expression*, *Does not match wildcard expression*, *Matches regular expression*, or *Does not match regular expression*. In the second part of the filter, specify the variable, in the same way as in Visio, e.g. *\[var:LoadTime\]*. For more information, see [\[var:VariableName\]](xref:Placeholders_for_variables_in_shape_data_values#varvariablename).
   > - If you create a *Services* filter in a history tab, and you want to include services that have been deleted, at the bottom of the box where you can select services to filter on, select the *Load deleted services* checkbox (available from DataMiner 10.2.0/10.1.4 onwards).

1. If you want, you can also combine several filters, using logical operators (AND, OR).

1. Optionally, limit the types of alarms displayed in the new tab by selecting or clearing the *Alarms*, *Masked alarms* and/or *Information events* checkboxes. These allow you to for example only display information events in the new tab.

1. Optionally, click *Count alarms* to check how many alarms will be shown when the tab configuration is applied.

   > [!NOTE]
   >
   > - If you chose to display history alarms, the *Count alarms* option will only work with certain filter combinations. If you configure a filter combination for which the option is not available, a notification message will appear.
   > - From DataMiner 9.6.0 \[CU25\], 10.0.0 \[CU19\], 10.1.0 \[CU8\] and 10.1.11 onwards, when you create a tab to display history alarms or alarms in a sliding window, for filters on element type, interface impact, parameter description, protocol, service impact, view ID/impact/name, or virtual function ID/impact/name, the *Count alarms* option is no longer available.

1. To see the filtered alarms in the Alarm Console tab, click *Show alarms*.

1. If you want to change filter settings after the filter has been applied, click the pencil icon next to the alarm tab name.

## Creating a search tab in the Alarm Console

When you are connected to a DMA using at least DataMiner version 10.0.0/10.0.2 with [Elasticsearch](xref:Elasticsearch_database), the Alarm Console provides an additional option to create a dynamic search tab.

> [!NOTE]
> Prior to DataMiner 10.0.7, to have access to this feature, you need to have the *System configuration* > *Indexing Engine* > *UI available* user permission. This user permission is only displayed if *?EnableFeature=Indexing* is added to the Cube URL. From DataMiner 10.0.7 onwards, this user permission is no longer needed.

To create such a tab:

1. Click the *+* symbol in the header of the Alarm Console to open a new tab.

1. At the top of the tab, next to *Search* *for alarms*, do the following:

   - Add one or more search terms in the search box. As soon as you start typing, suggestions will be displayed below the box.

   - Next to the search box, indicate the time span in which the alarms should occur. By default, this is set to *Last 24 hours*.

   - By default, different instances of the same alarm will be combined in a single alarm tree in the results. If you want them to be displayed separately instead, disable the *History tracking* checkbox.

   Press Enter or select a suggestion to begin the search. The alarms matching your search phrase will then be retrieved in batches of 50. If there are more than 50 alarms matching the search phrase, a *More results* button will be displayed at the bottom of the list.

Once the first 50 alarms have been retrieved, a graphical representation of the alarm distribution will be displayed at the bottom of the tab.

### Special keywords in the search tab

In the search box, you can use the following special keywords, followed by a colon (“:”) and a search phrase:

- Severity

- Description

- Parameter_description

- Owner

- Value

- Time of arrival

- Status

- Elementname

- Viewnames

- Parentviews

- Protocolname

- ElementProperty\_\<propertyName>

- Viewproperty\_\<PropertyName>

- ServiceProperty\_\<PropertyName>

For example, if you want to search alarms associated with elements of which the name resembles “probe”, then you can enter “Elementname:probe”.

## Filtering alarms on alarm focus

From DataMiner 10.0.0/10.0.2 onwards, the DataMiner Analytics software assigns an estimated likelihood or “alarm focus score” to each alarm, after analyzing the short-term history and current behavior of incoming alarms in real time. The alarm focus score is based on a combination of likelihood, frequency and severity.

- Likelihood scores are used to spot daily patterns. If an alarm occurs at the same time every day, it will be assigned a high likelihood value at that time.

- Frequency scores are used to detect parameters that frequently go into and out of alarm, or alarms that persist over a long time.

Depending on the focus score, an alarm can be considered unexpected. In that case, this is indicated with the following icon in the *Focus* column: ![Focus column icon](~/user-guide/images/AlarmFocus.png)

To filter the alarm list to only show such unexpected alarms, click the following button in the alarm bar: ![Focus button](~/user-guide/images/AlarmFocusFilter.png)

Please note the following regarding the alarm focus feature:

- This feature is only available if a Cassandra database is used. See [Cassandra database](xref:Cassandra_database).

- The focus icon in the alarm bar is only displayed on tabs displaying active alarms.

- Likelihood values are based on UTC time. As a result, when daylight saving time goes into or out of effect, patterns following local time might be off for approximately one week.

- Currently, no focus score is assigned to the following types of alarms: Correlation alarms, external alarms and information events.

- If an alarm template changes, all alarms of the parameters for which a change was implemented in the alarm template will be treated as unexpected.

- In case of an alarm storm, the update of focus scores of persistent alarms is postponed until after the alarm storm ends.

> [!NOTE]
> You can enable or disable the alarm focus feature via *System Center* > *System settings* > *analytics config*. However, note that if you disable alarm focus, [automatic incident tracking](xref:Automatic_incident_tracking) is automatically also disabled, and only [manual incident tracking](xref:Automatic_incident_tracking#manually-updating-an-alarm-group) can still be used. <!-- RN 33348 -->

## Applying an alarm filter by dragging an item onto the Alarm Console

Instead of manually applying a filter in a tab, you can also drag an item from the Cube UI onto the Alarm Console to create a tab filtered specifically for that item.

> [!TIP]
> See also: [Alarm Console – Alarm history](https://community.dataminer.services/video/alarm-console-alarm-history/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

To do so:

1. Drag an element, protocol, parameter, etc. onto the Alarm Console. A new tab will automatically be created.

   > [!NOTE]
   >
   > - With a redundancy group, this way of creating a filtered tab is not possible.
   > - To open a filtered tab for an element, service or view, you can also right-click the item in the Surveyor or on a card and select *Actions* > *Add tab to global Alarm Console*.

1. In the new tab, indicate the time frame for the alarms you want to display: active alarms, or a past time range.

1. In the *What* column, select whether to show non-masked alarms, information events and/or masked alarms.

1. In the next column, select the items to filter on.

   The options in this step differ depending on the type of item you dragged onto the Alarm Console. E.g. for a parameter, you may be able to click *Load more elements*, so that you can select several elements that have this parameter.

1. Click *Show alarms*.

> [!NOTE]
>
> - Alarm filters based on views also include alarm events based on aggregation rules.
> - If you want to open a filtered tab containing only alarms related to a particular DMA, this is possible from the *System Center* module. Go to the *Agents* page of System Center and select the DMA in question in the *manage* tab. Then click the *Show agent alarms* link at the top of the pane on the right. The filtered tab will then be opened in the Alarm Console. It will show all alarms on the DMA itself with severity Notice, Timeout or Error.

## Alarm filters using wildcard expressions

The example below shows a filter for elements matching a particular wildcard expression.

![Example of alarm filter with wildcard](~/user-guide/images/alarm_filter_wildcard_DM9.png)

## Alarm filters using regular expressions

If you want to filter alarms using a regular expression:

1. When creating a filter, select the *Matches Regular Expression* operator.

1. Specify a regular expression.

![Example of alarm filter with regular expression](~/user-guide/images/alarm_filter_regex_DM9.png)

### Regular expression syntax

You can use any regular expression.

For more information on how to construct regular expressions, here are a few interesting links:

- [Regular Expression Language - Quick Reference](http://msdn.microsoft.com/en-us/library/az24scfc.aspx)

- [RegExLib.com Regular Expression Cheat Sheet](http://regexlib.com/CheatSheet.aspx)

> [!NOTE]
>
> - DataMiner always wraps a regular expression in ^( and )$. This means that the expression must match the entire string.
> - The checks are executed using the invariant culture and ignoring case.

### Regular expression examples

```txt
London.*
```

- Matches ...

  - London-Amplifier-1

  - London-Amplifier-2

- Does not match ...

  - NewYork-Amplifier-1

  - East-London-Amplifier

  - Paris-Amplifier

```txt
(London|NewYork)-Amplifier-[0-9]+
```

- Matches ...

  - London-Amplifier-1

  - NewYork-Amplifier-5

- Does not match ...

  - Paris-Amplifier-7

  - London-Amplifier-XYZ

```txt
MAC-^([0-9A-F]{2}[-]){5}([0-9A-F]{2})
```

- Matches ...

  - MAC-A0-12-EF-DE-A1-C3

- Does not match ...

  - MAC-99-99-99-99-99

## Working with saved alarm filters

When you create a filter in the Alarm Console, you can save it in order to use it again later or in other DataMiner applications.

> [!NOTE]
> Up to DataMiner 9.0.4, if an alarm filter containing a service is saved, this service is stored by name. This means that if the service name changes, you will need to manually update the filter accordingly. From DataMiner 9.0.5 onwards, services in an alarm filter are stored by ID when possible. This means that a manual update is then only necessary if a filter contains wildcard expressions or regular expressions.

### Saving an alarm filter

1. Create a filter as described in [Manually applying an alarm filter in an Alarm Console tab](#manually-applying-an-alarm-filter-in-an-alarm-console-tab).

1. Before clicking *Show alarms* to apply the filter in the tab, click *Save the current filter combination*.

   > [!NOTE]
   > If the current filter combination contains a private alarm filter, it will not be possible to save the filter combination as a public or protected filter.

1. Enter a name for the alarm filter.

   > [!NOTE]
   > Alarm filters may not start or end with a space.

1. Indicate whether the filter should be private, public, or protected. See [Alarm filters](xref:Alarm_filters)

1. Optionally, add a description.

1. Click *Save*.

### Using a saved alarm filter

1. Create a filtered tab as described in steps 1 and 2 in [Manually applying an alarm filter in an Alarm Console tab](#manually-applying-an-alarm-filter-in-an-alarm-console-tab).

1. When you select a filter, as described in step 3 of the same procedure, scroll to the bottom of the list and select *Saved filters*.

1. To the right of *Saved filters*, click *\<Click to select>* and select the filter you want.

   > [!NOTE]
   > If you have selected a saved filter, but you do not have the user permission *Edit / delete protected filters*, an eye icon will be displayed next to the filter. Click this icon to view the contents of the filter.

1. Proceed as in [Manually applying an alarm filter in an Alarm Console tab](#manually-applying-an-alarm-filter-in-an-alarm-console-tab).

### Editing or deleting a saved alarm filter

1. Select the filter from the *Saved filters* as if you were going to use it.

1. Click the pencil icon to the right of the filter.

1. In the edit window, the following actions are possible:

   - Click the *Delete* button to delete the alarm filter. You will receive a warning message mentioning where the filter may be used.

     > [!NOTE]
     > It is not possible to delete an alarm filter that is currently in use.

   - Enter a description for the filter in the *Description* field.

   - Change the fields of the filter itself, or delete parts of a combined filter, in the same way as when creating a new filter.

1. To save any changes, click *OK*.
