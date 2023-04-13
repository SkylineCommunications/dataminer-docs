---
uid: DashboardParameterFeed
---

# Parameter feed

This dashboard feed allows the user to select multiple parameters from a predefined list. At the top of the list, a box is available that allows the user to select or deselect all items in the list at once.

> [!NOTE]
>
> - From DataMiner 10.2.4, 10.1.0 [CU13] and 10.2.0 [CU1] onwards, if the component is loaded with an initial selection, the selected items are always displayed at the top. Prior to these DataMiner versions, the *Selected only* toggle button can be used to show or hide items that are not selected.
> - From DataMiner 10.3.4/10.4.0 onwards, when an EPM feed is used to feed EPM identifiers to a parameter feed, it will also list the parameters of the enhanced elements that are linked to the EPM objects. EPM identifiers are System Type and Name data provided by an EPM feed (indicated as *EPM identifiers* in the data pane). <!-- RN 35562 -->

To configure this component:

1. Apply the necessary data feeds. See [Applying a data feed](xref:Configuring_dashboard_components#applying-a-data-feed).

   - The component supports element and parameter data feeds. In case a table parameter is added, an indices filter can be specified. In case all parameters or all elements are added, a protocol or view feed can be used as an additional filter.

   - From DataMiner 10.0.0/10.0.2 onwards, multiple view filters can be applied to a parameter feed. Parameters in those views will then be included as soon as they are included in one of the view filters.

   - From DataMiner 10.2.3/10.3.0 onwards, a default index filter can be applied. To do so, first add the `showAdvancedSettings=true` option to the dashboard URL. In the *Data* pane, a *Parameter table filters* section will then become available where you can configure the filter.

1. Optionally, customize the following component options in the *Component* > *Settings* tab:

   - *WebSocket settings*: Allows you to customize the polling interval for this component. To do so, clear the checkbox in this section and specify the custom polling interval.

   - *Initial Selection*: Allows you to specify a default value. This is the value that will be applied in the feed when the dashboard is opened, unless a custom URL is used specifying a different value.

     > [!NOTE]
     >
     > - Prior to DataMiner 10.3.6/10.4.0<!--  RN 35984 -->, this setting is called *Feed Defaults* instead.
     > - From DataMiner 10.2.12/10.3.0 onwards, parameter feeds that list EPM parameters also allow the configuration of default filters that will preselect certain parameters in the parameter feed.

   - *Auto-select number of indices*: Available up to DataMiner 10.0.12. To automatically include a specific number of indices when at least one element and one parameter have been selected in the component, specify the number in this box. If the number of indices specified is greater than the number of indices that are being displayed, the indices that are not shown will be selected in memory.

   - *Auto-select all indices*: Available up to DataMiner 10.0.12. Select this option to automatically include all indices when at least one element and one parameter have been selected in the component.

   - *Auto-select all*: Available from DataMiner 10.0.13 onwards. Replaced the previous auto-select options. When this option is selected, all items will be selected according to the “Select all behavior” settings below.

     > [!NOTE]
     > From DataMiner 10.2.11/10.3.0 onwards, this option is not available if the component uses EPM identifiers as its data source.

   - *Select all behavior* > *Select all items*: Available from 10.0.13 onwards. If this option is selected, "Select all" will select all items. For a [partial table](xref:Table_parameters#partial-tables), only the items from the first page will be selected.

   - *Select all behavior* > *Select specific number of items*: Available from 10.0.13 onwards. If you select this option, a box is displayed below it. In this box, you should specify how many items “Select all” should select. For a [partial table](xref:Table_parameters#partial-tables), these items will be selected across different pages.

   - *Auto-expand parameters*: Select this option to expand all tables and groups in the component by default.

   - To customize the default way the content of components based on the selector is grouped, in the *Default grouping* drop-down list, select if grouping should be done by element, parameter, parameter group, etc.

   - If a filtered list of indices is retrieved, you can specify the separator to use for this. For this you must make sure advanced dashboard settings are displayed. To do so, add the parameter *showAdvancedSettings=true* to the URL. You can then specify the separator in the *Index filter separator* box (available from DataMiner 10.0.9 onwards). For example, if only the indices with a primary key equal to "X" have to be retrieved, and you set the index filter separator to “Y”, the indices will be retrieved using the filter PK == X OR PK == \*YXY\*.

   - To group parameters in the selector, under *Parameter groups*, click *Add parameter group*. Then specify a group name and select the parameters that should be in the group. Repeat this for every parameter group you want to configure.

     > [!NOTE]
     > From DataMiner 10.2.12/10.3.0 onwards, it is possible to group parameters in a parameter feed that lists EPM parameters.

1. Optionally, fine-tune the component layout. In the *Component* > *Layout* tab, the following options are available:

   - The default options available for all components. See [Customizing the component layout](xref:Configuring_dashboard_components#customizing-the-component-layout).

   - *Column order*: Click the up or down arrow next to a column name to change the order in which the columns of the component are displayed. Available from DataMiner 9.6.13 onwards.

> [!NOTE]
> After selecting column parameter indices in a parameter feed, you can feed those selected indices to other components that support the same data. From DataMiner 10.2.12/10.3.0 onwards, this feature is also available for parameter feeds listing EPM parameters.
>
> 1. In the *Parameter Feed* window, select the checkboxes in front of the parameters you wish to include.
>
> 1. Available indices will appear under *Indices*. Select the checkboxes in front of the indices you wish to include. For example:
>
>    ![EPM Feed Indices](~/user-guide/images/EPM_Feed_Indices.png)
>
> 1. In the *Data* pane, select *Feeds* under *All available data*. Expand *Parameter feed* and drag *Indices* to the component of your choice.
