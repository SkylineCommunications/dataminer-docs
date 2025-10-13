---
uid: DashboardList
---

# List

This component allows the user to select one or more items in a list. The selectable items can be based on any data.

![List](~/dataminer/images/List.gif)<br>*List component in DataMiner 10.4.6*

To configure the component:

1. Apply the necessary data. See [Adding data to a component](xref:Adding_data_to_component).

   > [!NOTE]
   >
   > - From DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4 onwards<!--RN 38811-->, when you apply a single query data source or *Tables* data source, individual rows from that query or table are listed instead of the query or table itself. Additionally, if you want to use this list component as data, the entry will be listed as *Tables* or *Query rows* in the *Data* pane (depending on your DataMiner version<!--RN 41075-->). When you apply multiple query data sources or *Tables* data sources, the queries or tables themselves are listed as data. Prior to DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4, when you apply a single query data source, the query itself is listed as data. If you use this list component as data, the entry will be listed as *Queries* in the *Data* pane.
   > - You can use the *Tables* data source for this component from DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12 onwards.<!--RN 41161-->

1. Optionally, fine-tune the component layout. In the *Component* > *Layout* pane, the following options are available:

   - The default options available for all components. See [Customizing the component layout](xref:Customize_Component_Layout).

   - *Display column*: Available from DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4 onwards<!--RN 38811-->. Allows you to select a column that should be picked to display the query rows items. This setting is only available when a single query data source or *Tables* component data source was applied.

1. Optionally, customize the following component options in the *Component* > *Settings* pane:

   - *WebSocket settings*: Allows you to customize the polling interval for this component. To do so, clear the checkbox in this section and specify the custom polling interval.

   - *Initial Selection > Select first item by default*: Available from DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4 onwards<!--RN 38775-->. Sets the first item as the value that will be applied in the data when the dashboard is opened, unless a custom URL is used specifying a different value. This setting is enabled by default.

   - *Initial Selection > Select item by default*: Allows you to specify a default value. This is the value that will be applied in the data when the dashboard is opened, unless a custom URL is used specifying a different value. From DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4 onwards<!--RN 38775-->, this setting is only available when the *Select first item by default* setting is disabled.

     > [!NOTE]
     >
     > - Prior to DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4<!--RN 38775-->, this setting is called *Initial Selection* instead.
     > - Prior to DataMiner 10.3.6/10.4.0<!--  RN 35984 -->, this setting is called *Feed Defaults* instead.

   - *Data retrieval > Update data*: Available from DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4 onwards<!--RN 38811-->. Allows the values displayed in the component to be updated in real time, if the data supports this (see [Query updates](xref:Query_updates)). This setting is only available when a single query data source or an index dataset was applied. This setting is disabled by default.
