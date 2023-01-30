---
uid: Configuring_dashboard_components
---

# Configuring dashboard components

Each dashboard component consists of **a visualization and a data feed**.

When a dashboard is in edit mode, visualizations are available via the green panel on the left, and data feeds are available via the *Data* pane on the right.

There are several ways to add a component:

- **Drag a visualization** from the pane on the left onto an empty section of the dashboard. A data feed will then need to be applied to the component.

- **Drag a data feed** from the *Data* pane on the right onto an empty section of the dashboard. A visualization will then still need to be applied to the component.

The following actions are then possible to configure the component:

- [Applying a visualization](#applying-a-visualization)

- [Applying a data feed](#applying-a-data-feed)

- [Customizing the component layout](#customizing-the-component-layout)

- [Deleting a component](#deleting-a-component)

In addition, depending on the visualization, additional configuration options may be available. For more information, refer to the relevant section in [Available visualizations](xref:Available_visualizations).

## Applying a visualization

To apply a visualization to a component or change the visualization of a component:

1. Click on the component or hover the mouse over the component and **click the ![Visualization icon](~/user-guide/images/DashboardsX_visualizations00095.png) icon**.

1. **Select the visualization** you want to apply from the options displayed below the component.

   As soon as the mouse pointer hovers over the different visualizations, a preview will be displayed in the component.

## Applying a data feed

To apply a data feed or change the data feed of a component:

1. Click on the component or hover the mouse over the component and **click the ![Data feed icon](~/user-guide/images/dashboards_data.png) icon**.

   In the data pane on the right, any data feeds that do not match the visualization of the component will become unavailable. Data feeds that are compatible with the component will be marked with the following icon: ![Compatible data feed icon](~/user-guide/images/NewRD_datafeed.png)

1. **Drag the compatible data feed** onto the component.

   - To find specific data more quickly, you can use the **filter box** at the top of each data section.

     - For **parameters**, you can select a specific parameter by first selecting *Element* or *Service* in the *From* box and then specifying a filter. Alternatively, you can select a parameter by first selecting *Protocol* in the *From* box and then specifying a protocol in the filter.

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

   - A data feed can also be provided by a **feed component**. When such a component has been added to the dashboard, the *Feeds* section is added to the available data in the *Data* pane. You can then drag an entry from this section to a component in order to link the component to the feed component.

   - Some components allow you to specify **multiple data feeds**. For example, for a *State* component and a *Line chart* component, multiple parameters can be dragged onto the component.

     > [!NOTE]
     > From DataMiner 10.0.12 onwards, for some visualizations that use multiple data feeds (e.g. Parameter table, State), you can modify the order in which these data feeds are displayed.
     >
     > To do so, in the *Data in component* section of the data pane, click the arrow icons next to the data feeds to place them higher or lower in the order.

   - If you try to add a data feed that is **not compatible** with the component, a red icon will be displayed on the component when you try to drag the data onto it.

1. Some visualizations and data feeds allow you to specify an **additional filter feed**. In that case, a yellow filter icon will be displayed below the component when you select it or hover the mouse over it: ![Filter icon](~/user-guide/images/DashboardsX_filter.png)

   After you click this icon, compatible filter feeds will be marked with this icon in the data pane, and you will be able to drag these onto the component just like a data feed.

## Customizing the component layout

Each component in a dashboard has a number of default options. By default, the configuration of these options is determined on [dashboard level](xref:Configuring_the_dashboard_layout). However, it is possible to override this. The way this can be done depends on the DataMiner version.

### [From DataMiner 10.0.8 onwards](#tab/tabid-1)

1. Select the component and go to the ***Layout*** tab on the right.

1. In the ***Styles*** section, you can then change the component theme in different ways:

   - To **change the component theme** to one of the different existing component themes for your current dashboard theme, click the current theme and select a different theme in the drop-down list.

   - To **customize the component theme**, enable the *Customize* toggle button to customize the currently selected theme.

     - In the *Title* section, specify the following:

       - *Font*: Select a font type in the drop-down list

       - *Font size*: The size (in pixels) of the title

       - *Alignment*: Left, center, right, or justify

       You can also further customize your title with *Bold*, *Italics*, and *Underline*.

     - In the *Colors* section, specify a custom background color and/or font color, either by specifying the color in RGB format or by using the color picker box on the right.

       From DataMiner 10.0.12 onwards, under *Colors* > *Color palette*, you can customize additional component colors, e.g. for the lines in a line chart.

     - In the *Spacing* section, specify the following:

       - *Vertical margin*: The amount of space (in pixels) above the component.

       - *Horizontal margin*: The amount of space (in pixels) next to the component.

       - *Vertical padding*: The amount of space (in pixels) that should be left free at the top of the bottom inside the component.

       - *Horizontal padding*: The amount of space (in pixels) that should be left free on the left and right side of the component.

       > [!NOTE]
       > If a smaller value than the dashboard’s default value is configured for these settings, it will not be taken into account.

     - In the *Border* section, specify the following:

       - *Roundness*: The roundness (in pixels) of the border that should be displayed around the components.

       - *Style*:

         - No border

         - Line

         - Dashes

         - Dots

       - *Sides*: Select which sides of the component border should be shown (from DataMiner 10.0.9 onwards).

       - *Thickness*: The thickness (in pixels) of the border that should be displayed around the components.

       - *Color*: Specify a custom border color, either by specifying the color in RGB format or by using the color picker box on the right.

     - In the *Shadow* section, select the size of the shadow displayed behind the components.

     > [!NOTE]
     > When you have customized a component theme, you can also save it, so that it becomes available with the other component themes for the current dashboard theme. To do so, click *Save as component theme* and specify the name of the theme. However, note that this is only possible if the dashboard is currently using a saved dashboard theme. If it is not, you will first need to save the dashboard theme before you can save the component theme.

### [Prior to DataMiner 10.0.8](#tab/tabid-2)

1. Select the component and go to the *Layout* tab on the right.

1. Clear the checkbox *Inherit from dashboard*.

1. Configure the following options in the expandable sections according to your preference:

    - In the *Title* section, select the alignment for the component title and specify whether a border should be displayed around the title.

    - In the *Colors* section specify a custom background color and/or font color, either by specifying the color in RGB format or by using the color picker box on the right.

    - In the *Container* section, specify the following:

        - *Vertical margin*: The amount of space (in pixels) above the component.

        - *Horizontal margin*: The amount of space (in pixels) next to the component.

        - *Vertical padding*: The amount of space (in pixels) that should be left free at the top of the bottom inside the component.

        - *Horizontal padding*: The amount of space (in pixels) that should be left free on the left and right side of the component.

        > [!NOTE]
        > If a smaller value than the dashboard’s default value is configured for these settings, it will not be taken into account.

    - In the *Borders* section, select the type of border that should be displayed around the components.

    - In the *Shadow* section, select the size of the shadow displayed behind the components.

Depending on the visualization, additional layout options may be available. For more information, refer to the relevant section in [Available visualizations](xref:Available_visualizations).

***

## Deleting a component

You can delete a dashboard component as follows:

- Click on the component or hover the mouse over the component and click the red recycle bin icon.

- Select the component and click *Delete component* in the header bar of the app.

- Select the component and press the *Delete* key (supported from DataMiner 10.2.0/10.1.1 onwards).
