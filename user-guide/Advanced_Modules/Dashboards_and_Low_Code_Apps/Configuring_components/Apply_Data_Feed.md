---
uid: Apply_Data_Feed
---

# Applying a data feed

To apply a data feed or change the data feed of a component:

1. Click on the component or hover the mouse pointer over the component and **click the ![Data feed icon](~/user-guide/images/dashboards_data.png) icon**.

   In the data pane on the right, any data feeds that do not match the visualization of the component will become unavailable. Data feeds that are compatible with the component will be marked with the following icon: ![Compatible data feed icon](~/user-guide/images/NewRD_datafeed.png)

1. **Drag the compatible data feed** onto the component.

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

   - For some components, you can add the **complete set** of a certain type of items. In that case, the data feed icon will be displayed in front of the group in the data pane, and you will be able to drag the entire group onto the component.

     > [!NOTE]
     >
     > - If you add the entire *Bookings* data set to a *Drop-down*, *List* or *Tree* feed, you will also need to link this to a *Time range* feed.
     > - From DataMiner 10.2.11/10.3.0 onwards, you can filter on all versions of a protocol by adding the protocol itself to the component. In earlier versions, only the first of the available versions will be added in that case.

   - A data feed can also be provided by a **feed component**. When such a component has been added to the dashboard or low-code app, the *Feeds* section is added to the available data in the *Data* pane. You can then drag an entry from this section to a component in order to link the component to the feed component.

   - Some components allow you to specify **multiple data feeds**. For example, for a *State* component and a *Line chart* component, multiple parameters can be dragged onto the component.

     > [!NOTE]
     > From DataMiner 10.0.12 onwards, for some visualizations that use multiple data feeds (e.g. Parameter table, State), you can modify the order in which these data feeds are displayed.
     >
     > To do so, in the *Data in component* section of the data pane, click the arrow icons next to the data feeds to place them higher or lower in the order.

   - If you try to add a data feed that is **not compatible** with the component, a red icon will be displayed on the component when you try to drag the data onto it.

1. Some visualizations and data feeds allow you to specify an **additional filter feed**. In that case, a yellow filter icon will be displayed below the component when you select it or hover the mouse pointer over it: ![Filter icon](~/user-guide/images/DashboardsX_filter.png)

   After you click this icon, compatible filter feeds will be marked with this icon in the data pane, and you will be able to drag these onto the component just like a data feed.
