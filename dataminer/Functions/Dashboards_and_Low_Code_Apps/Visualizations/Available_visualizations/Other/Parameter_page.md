---
uid: DashboardParameterPage
---

# Parameter page

This component displays a particular data page of an element.

![Parameter page](~/dataminer/images/Parameter_Page.png)<br>*Parameter page component in DataMiner 10.4.5*

To configure the component:

1. Add an element or data page (recommended) that will supply the necessary data. For a data page, filter the *Parameters* item in the *Data* pane either by element or by protocol.

1. If you used element data: Click the filter button in the quick menu below the component and add a data page filter from the *Parameters* category.

   If you used a data page based on element, no additional filter is needed.

   If you used a data page based on protocol, an additional element filter is needed. You can either directly add this from the *Elements* section in the *Data* pane, or use a component. See [Adding data to a component](xref:Adding_data_to_component).

1. Optionally, to customize the polling interval for this component, expand the *Settings* \> *WebSocket settings* section, clear the checkbox in this section, and specify the custom polling interval.
