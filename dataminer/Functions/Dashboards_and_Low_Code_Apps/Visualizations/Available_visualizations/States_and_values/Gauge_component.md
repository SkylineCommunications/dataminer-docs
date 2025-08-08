---
uid: DashboardGauge
---

# Gauge

This component displays a numeric parameter value as a gauge.

![Gauge](~/dataminer/images/Gauge.png)<br>*Gauge component in DataMiner 10.4.5*

To configure the component:

1. [Add data to the component](xref:Adding_data_to_component).

   - Column parameter data is supported.

     > [!NOTE]
     > If no filter is specified, the number of parameter rows that can be displayed by this component is limited to 100. To display more rows or filter out specific rows, you can use a [Parameter picker](xref:DashboardParameterPicker) and link this to the state component.

   - In case parameter data included a parameter based on a protocol, a filter can be used to filter on a specific element.

   > [!NOTE]
   > From DataMiner 10.2.0/10.1.6 onwards, once this component has been configured with data input, the component is available in the *Components* section of the *Data* pane so that it can be used as data for other components. This way, if the input for this component changes, it will also change for all other components using this component as their data. However, note that this is only supported for query data input from DataMiner 10.1.7 onwards.

1. Optionally, customize the following component options:

   - To customize the polling interval for this component, expand the *Settings* \> *WebSocket settings* section, clear the checkbox in this section, and specify the custom polling interval.

   - In case the component displays more than one item, in the *Settings* pane, select how the items should be grouped: by parameter, by element, by table index (if relevant) or by all the above together.

   - To customize the value range of the component, in the *Settings* pane, select *Fixed minimum* and/or *Fixed maximum* and specify the custom minimum and/or maximum. This option is available from DataMiner 10.2.0/10.1.6 onwards.

1. Fine-tune the component layout. In the *Component* > *Layout* pane, the following options are available:

   - The default options available for all components. See [Customizing the component layout](xref:Customize_Component_Layout).

   - If parameter data input is used, in the *Labels* section, you can select whether the parameter name, the element name, the index (for a table parameter) or the value should be displayed in the component.

   - In case the component displays more than one parameter, in the *Advanced* > *Layout* section, you can adjust the way the different items are displayed:

     - *Layout flow*: Determines whether the different items are displayed next to each other or below each other. However, note that when the items are viewed on a small screen, they will always be displayed below each other.

     - *Maximum rows per page*: Determines how many items can at most be displayed below each other on a single page.

     - *Maximum columns per page*: Determines how many items can at most be displayed next to each other on a single page.

     > [!NOTE]
     > Data with multiple elements, services, views, or redundancy groups are supported, but they have a fixed scroll configuration that cannot be adjusted in the *Layout* pane.

   - In the *Style* section, the following options are available:

     - *Align font sizes*: Only available if *Design* is set to *Auto Size*. This option causes the font size to be aligned with the font size of other components using this option. If the option is not selected, the text is simply displayed as large as possible within the component.

     - *Show progress*: Available from DataMiner 10.2.0/10.1.6 onwards. Only available if the component displays an analog parameter. In that case, a darker color within the gauge will indicate the current parameter value.

     - *Show minimum*: Available from DataMiner 10.2.0/10.1.6 onwards. Select this option to show the minimum value of the value range below the gauge. Note that this value can be customized in the component settings.

     - *Show maximum*: Available from DataMiner 10.2.0/10.1.6 onwards. Select this option to show the maximum value of the value range below the gauge. Note that this value can be customized in the component settings.

     - *Show icon*: Determines whether an icon is displayed for the parameter. You can select which icon is displayed in a drop-down list.

       For trended parameters, by default a trend icon is displayed. Clicking this icon will open the corresponding trend graph in the Monitoring app.

     - *Design*: Available from DataMiner 10.2.0/10.1.6 onwards. Determines how the text in the component is displayed. The options *Small* and *Large* show the text in a small and large font size, respectively. If you select *Auto size*, the font size will automatically be adjusted to fit in the available space.

     - *Gauge/Vertical alignment*: Only available up to DataMiner 10.1.5. Determines whether the gauge should be aligned at the top or the center of the component.

     - Alignment: Available from DataMiner 10.2.0/10.1.6 onwards. Only displayed if *Design* is set to *Small* or *Large*. Allows you to align the contents of the components to the left, in the center or to the right.
