---
uid: DashboardProgressBar
---

# Progress bar

This component shows the value of one or more analog parameters with a progress bar. It is available from DataMiner 10.2.0/10.1.7 onwards.

![Progress bar](~/dataminer/images/Progress_Bar.png)<br>*Progress bar component in DataMiner 10.4.5*

To configure the component:

1. Apply parameter data. See [Adding data to a component](xref:Adding_data_to_component).

   - Column parameter data is supported.

     > [!NOTE]
     > If no filter is specified, the number of parameter rows that can be displayed by this component is limited to 100. To display more rows or filter out specific rows, you can use a [Parameter picker](xref:DashboardParameterPicker) and link this to the state component.

   - In case parameter data included a parameter based on a protocol, a filter can be used to filter on a specific element.

1. Optionally, customize the following component options:

   - To customize the polling interval for this component, expand the *Settings* \> *WebSocket settings* section, clear the checkbox in this section, and specify the custom polling interval.

   - In case the component displays more than one item, in the *Settings* pane, select how the items should be grouped: by parameter, by element, by table index (if relevant) or by all the above together.

   - To customize the value range of the component, in the *Settings* pane, select *Fixed minimum* and/or *Fixed maximum* and specify the custom minimum and/or maximum.

1. Fine-tune the component layout. In the *Component* > *Layout* pane, the following options are available:

   - The default options available for all components. See [Customizing the component layout](xref:Customize_Component_Layout).

   - *Labels*: In this section, you can select whether the parameter name, the element name, the index (for a table parameter) and/or the value should be displayed in the component.

   - *Show minimum*: Select this option to show the minimum value of the value range. Note that this value can be customized in the component settings.

   - *Show maximum*: Select this option to show the maximum value of the value range. Note that this value can be customized in the component settings.

   - *Design*: Determines whether the text is displayed in a small or large font size.

   - *Layout flow*: If the component displays multiple parameters, this option determines whether the different parameters are displayed in rows or columns. If they are displayed in rows, they will be displayed next to each other until there is no more space and a new row is started. If they are displayed as columns, they will be displayed below each other until there is no more space and a new column is started.
