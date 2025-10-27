---
uid: DashboardParameterPicker
---

# Parameter picker

Prior to DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12<!--RN 41141-->, this component is called the "parameter feed" component instead.

This picker component allows the user to select multiple parameters from a predefined list. At the top of the list, a box is available that allows the user to select or deselect all items in the list at once.

![Parameter picker](~/dataminer/images/Parameter_Picker.png)<br>*Parameter picker component in DataMiner 10.4.5*

> [!NOTE]
>
> - From DataMiner 10.2.4, 10.1.0 [CU13] and 10.2.0 [CU1] onwards, if the component is loaded with an initial selection, the selected items are always displayed at the top. Prior to these DataMiner versions, the *Selected only* toggle button can be used to show or hide items that are not selected.
> - From DataMiner 10.3.4/10.4.0 onwards, when an [EPM picker](xref:DashboardEPMPicker) is used to pass EPM identifiers to a parameter picker, it will also list the parameters of the enhanced elements that are linked to the EPM objects. EPM identifiers are System Type and Name data provided by an EPM picker (indicated as *EPM identifiers* in the *Data* pane). <!-- RN 35562 -->

## Configuring the component

1. Apply the necessary data. See [Adding data to a component](xref:Adding_data_to_component).

   - The component supports element and parameter data. In case a table parameter is added, an indices filter can be specified. In case all parameters or all elements are added, protocol or view data can be used as an additional filter.

   - Multiple view filters can be applied to a parameter picker. Parameters in those views will then be included as soon as they are included in one of the view filters.

   - From DataMiner 10.2.3/10.3.0 onwards, a default index filter can be applied. To do so, first add the `showAdvancedSettings=true` option to the dashboard or app URL. In the *Data* pane, a [*Parameter table filters* section](xref:Parameter_Table_Filters) will then become available where you can configure the filter.

1. Optionally, customize the following component options in the *Component* > *Settings* pane:

   - *WebSocket settings*: Allows you to customize the polling interval for this component. To do so, clear the checkbox in this section and specify the custom polling interval.

   - *Initial Selection*: Allows you to specify a default value. This is the value that will be applied in the data when the dashboard is opened, unless a custom URL is used specifying a different value.

     > [!NOTE]
     >
     > - Prior to DataMiner 10.3.6/10.4.0<!--  RN 35984 -->, this setting is called *Feed Defaults* instead.
     > - From DataMiner 10.2.12/10.3.0 onwards, parameter pickers that list EPM parameters also allow the configuration of default filters that will preselect certain parameters in the parameter picker.

   - *Auto-select all*: When this option is selected, all items will be selected according to the "Select all behavior" settings below.

     > [!NOTE]
     > From DataMiner 10.2.11/10.3.0 onwards, this option is not available if the component uses EPM identifiers as its data source.

   - *Select all behavior* > *Select all items*: If this option is selected, "Select all" will select all items. For a [partial table](xref:Table_parameters#partial-tables), only the items from the first page will be selected.

   - *Select all behavior* > *Select specific number of items*: If you select this option, a box is displayed below it. In this box, you should specify how many items "Select all" should select. For a [partial table](xref:Table_parameters#partial-tables), these items will be selected across different pages.

   - *Auto-expand parameters*: Select this option to expand all tables and groups in the component by default.

   - *Default grouping*: See [Customizing the default grouping](#customizing-the-default-grouping).

   - If a filtered list of indices is retrieved, you can specify the separator to use for this. For this you must make sure advanced dashboard settings are displayed. To do so, add the parameter *showAdvancedSettings=true* to the URL. You can then specify the separator in the *Index filter separator* box. For example, if only the indices with a primary key equal to "X" have to be retrieved, and you set the index filter separator to "Y", the indices will be retrieved using the filter PK == X OR PK == \*YXY\*.

   - To group parameters in the picker, under *Parameter groups*, click *Add parameter group*. Then specify a group name and select the parameters that should be in the group. Repeat this for every parameter group you want to configure.

     > [!NOTE]
     > From DataMiner 10.2.12/10.3.0 onwards, it is possible to group parameters in a parameter picker that lists EPM parameters.

1. Optionally, fine-tune the component layout. In the *Component* > *Layout* pane, the following options are available:

   - The default options available for all components. See [Customizing the component layout](xref:Customize_Component_Layout).

   - *Column order*: Click the up or down arrow next to a column name to change the order in which the columns of the component are displayed.

> [!NOTE]
> After selecting column parameter indices in a parameter picker, you can pass those selected indices to other components that support the same data. From DataMiner 10.2.12/10.3.0 onwards, this feature is also available for parameter pickers listing EPM parameters.
>
> 1. In the *Parameter Picker* window, select the checkboxes in front of the parameters you wish to include.
>
> 1. Available indices will appear under *Indices*. Select the checkboxes in front of the indices you wish to include. For example:
>
>    ![EPM Indices](~/dataminer/images/EPM_Indices.png)
>
> 1. In the *Data* pane, go to *All available data* > *Components* > *Parameter picker* > *Selected items* and drag *Indices* to the component of your choice. Prior to DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12<!--RN 41141-->, you can find *Indices* under *All available data* > *Feeds* > *Parameter feed* > *Selected items* instead.

## Customizing the default grouping

When other components are linked to the parameter picker, so that their content changes dynamically based on what is selected in the picker, the default way the content of those components is grouped can be configured in the parameter picker.

To configure the default grouping:

- Once data has been added to the component, go to the *Component* > *Settings* pane, and set *Default grouping* setting to the option of your choice.

  For example (in DataMiner 10.3.8):

  - Default grouping: *All together*

    ![Grouped all together](~/dataminer/images/ParameterPicker_GroupAllTogether.png)

  - Default grouping: *Parameter*

    ![Grouped by parameter](~/dataminer/images/ParameterPicker_GroupParameter.png)

  - Default grouping: *Table index*

    ![Grouped by index](~/dataminer/images/ParameterPicker_GroupIndex.png)

  - Default grouping: *Element*

    ![Grouped by element](~/dataminer/images/ParameterPicker_GroupElement.png)

  - Default grouping: *No grouping*

    ![No grouping](~/dataminer/images/ParameterPicker_NoGrouping.png)

> [!NOTE]
>
> - This default grouping is supported for the following visualizations: [State](xref:DashboardState), [Progress bar](xref:DashboardProgressBar), [Gauge](xref:DashboardGauge), [Ring](xref:DashboardRing), and [Line & area chart](xref:LineAndAreaChart).
> - It is possible to override this default grouping with the *Group by* setting of the other components.
