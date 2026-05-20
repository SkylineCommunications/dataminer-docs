---
uid: DashboardDropdown
---

# Dropdown

This basic control allows you to select an item in a dropdown list. The selectable items can be based on any data.

![Dropdown](~/dataminer/images/Dropdown.png)<br>*Dropdown component in DataMiner 10.4.6*

> [!NOTE]
> Prior to DataMiner 10.3.5/10.4.0<!--  RN 35902 -->, this component is available under *Feeds*.

## Using a dropdown as a filter for other components



## Configuration options

### Dropdown layout

In the *Layout* pane, you can find the default options available for all components. See [Customizing the component layout](xref:Customize_Component_Layout).

Additionally, the following layout options are also available:

| Section | Option | Description |
|--|--|--|
| Advanced | Display column | Available from DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4 onwards<!--RN 38811-->. Select a column that should be picked to display the name of an item in the dropdown box. This setting is only available when a single query data source or *Tables* component data source was applied. |
| Advanced | Label | Add text that will be displayed next to the dropdown box. |

### Dropdown settings

In the *Settings* pane for this component, you can customize its behavior to suit your requirements.

| Section | Option | Description |
|--|--|--|
| WebSocket settings | Inherit WebSocket settings from page/panel | Clear the checkbox to use a custom polling interval for this component. When cleared, you can specify a different polling interval (in seconds). |
| Initial selection | Select first item by default | Available from DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4 onwards<!--RN 38775-->. Toggle the switch to determine whether the first item is selected by default. When enabled this is the value that will be applied in the data when the data in the dropdown is refreshed, unless a custom URL is used specifying a different value. This setting is enabled by default. |
| Initial Selection | Select item by default, or<br>Initial Selection (Prior to DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4<!--RN 38775-->), or <br>Feed Defaults (Prior to DataMiner 10.3.6/10.4.0<!--  RN 35984) | Specify a default value. This is the value that will be applied in the data when the dashboard is opened, unless a custom URL is used specifying a different value. From DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4 onwards<!--RN 38775-->, this setting is only available when the *Select first item by default* setting is disabled. |
| Data retrieval | Update data | Available from DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4 onwards<!--RN 38811-->. Toggle the switch to determine whether the values displayed in the component should be updated automatically (provided this is supported by the data source). See [Query updates](xref:Query_updates)<!--RN 37269-->. This setting is only available when a single query data source or an indices dataset was applied. This setting is disabled by default. |
| Clear selection | Allow clearing the selection | Available from DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4 onwards<!--RN 38758-->. Toggle the switch to determine whether the selected values in the component can be cleared by clicking the X button in the upper-right corner of the filter box. This setting is disabled by default. |

> [!NOTE]
>
> - From DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4 onwards<!--RN 38811-->, when you apply a single query data source or *Tables* data source, individual rows from that query or table are listed instead of the query or table itself. Additionally, if you want to use this dropdown component as data, the entry will be listed as *Tables* or *Query rows* in the *Data* pane (depending on your DataMiner version<!--RN 41075-->). When you apply multiple query data sources or *Tables* data sources, the queries or tables themselves are listed as data. Prior to DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4, when you apply a single query data source, the query itself is listed as data. If you use this dropdown component as data, the entry will be listed as *Queries* in the *Data* pane.
> - You can use the *Tables* data source for this component from DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12 onwards.<!--RN 41161-->
