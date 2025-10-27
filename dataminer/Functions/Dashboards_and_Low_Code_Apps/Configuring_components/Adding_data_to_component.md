---
uid: Adding_data_to_component
---

# Adding data to a component

To add data or change the data of a component:

1. Click on the component or hover the mouse pointer over the component and **click the ![Data icon](~/dataminer/images/dashboards_data.png) icon**.

   In the *Data* pane on the right, any data that does not match the visualization of the component will become unavailable. Data that is compatible with the component will be marked with the following icon: ![Compatible data icon](~/dataminer/images/NewRD_data.png)

1. **Drag the compatible data entry** onto the component.

   - To find specific data more quickly, you can use the **filter box** at the top of each data section.

     - For **parameters**, you can select a specific parameter by first selecting *Element* or *Service* in the *From* box and then specifying a filter. Alternatively, you can select a parameter by first selecting *Protocol* in the *From* box and then specifying a protocol in the filter.

       > [!NOTE]
       > Prior to DataMiner 10.3.9/10.4.0, table column parameter data objects do not include indices, which means you also need to add an indices data object as a filter for this data in order to display specific cells. From DataMiner 10.3.9/10.4.0 onwards, the cells associated with a table column are included under a table column data node in the *Data* pane, so that you can add specific cells directly. By default, only the first 100 entries are displayed, but you can use a filter box to find other entries if necessary.<!-- RN 36724 -->

     - For **elements**, from DataMiner 10.2.5/10.3.0 onwards, you can click the filter icon next to the filter box at the top to get additional filtering options:

       - Specify a view in the *View* bow to only load elements in that view (and its subviews)

       - Specify a protocol in the *Protocol* box to only load elements using that protocol.

       - Select the *EPM managers* checkbox to only load EPM Manager elements.

       - Select the *Spectrum analyzers* checkbox to only load Spectrum elements.

       > [!NOTE]
       > These filters are applied server-side, so if your DMS has many elements, these can help you load the elements you need much faster.

   - For some components, you can add the **complete set** of a certain type of items. In that case, the ![Data](~/dataminer/images/dashboards_data.png) icon will be displayed in front of the group in the *Data* pane, and you will be able to drag the entire group onto the component.

     > [!NOTE]
     >
     > - If you add the entire *Bookings* dataset to a dropdown, list, or tree component, you will also need to link this to a time range component.
     > - From DataMiner 10.2.11/10.3.0 onwards, you can filter on all versions of a protocol by adding the protocol itself to the component. In earlier versions, only the first of the available versions will be added in that case.

   - Data input can also be provided by any another component. When a component has been added to the dashboard or low-code app, the *Components* or *Feeds* section (depending on your DataMiner version<!--RN 41141-->) is added to the available data in the *Data* pane. You can then drag an entry from this section to a different component in order to link it to the component. For more information, see [Component data](xref:Component_Data).

   - From DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12 onwards<!--RN 41039-->, data can also be provided by a **variable**. [Variables](xref:Variables) are reusable data objects that can be dynamically updated.

   - Some components allow you to specify **multiple data entries**. For example, for a state component and a line chart component, multiple parameters can be dragged onto the component.

     > [!NOTE]
     > For some visualizations that use multiple data entries (e.g. parameter table, state), you can modify the order in which these data entries are displayed. To do so, in the *Data used in component* section of the *Data* pane, click the arrow icons next to the data entries to place them higher or lower in the order.

   - If you try to add data that is **not compatible** with the component, a red icon will be displayed on the component when you try to drag the data onto it.

1. Some visualizations and data allow you to specify an **additional filter**. In that case, a yellow filter icon will be displayed below the component when you select it or hover the mouse pointer over it: ![Filter icon](~/dataminer/images/DashboardsX_filter.png)

   After you click this icon, compatible filters will be marked with this icon in the *Data* pane, and you will be able to drag these onto the component just like data.
