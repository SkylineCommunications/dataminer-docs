---
uid: DashboardQueryFilterFeed
---

# Query filter feed

> [!NOTE]
> This feature is in preview until DataMiner 10.3.9/10.4.0. If you use the preview version of the feature, its functionality may be different from what is described below. For more information, see [Soft-launch options](xref:SoftLaunchOptions).

Available from DataMiner 10.3.9/10.4.0 onwards. Prior to this, the component is available in soft launch from DataMiner 10.0.4 onwards, if the soft-launch option ReportsAndDashboardsPTP is enabled.

This dashboard feed allows the user to filter and refine data based on specific criteria. It can be used as an intermediary between the raw dataset and other components. Depending on the data type of the column, the filter can manifest as a text input field, range filter, list of checkboxes, etc. It generates an enhanced query that incorporates additional filter nodes, stemming from the original query result.

To configure this component:

1. Apply the necessary data feeds. See [Applying a data feed](xref:Apply_Data_Feed).

   > [!NOTE]
   > The assigned feed name will be visible in the bottom-right corner of the query filter component (e.g. Query filter 1).

1. Optionally, fine-tune the component layout. See [Customizing the component layout](xref:Customize_Component_Layout).

1. Optionally, customize the following component options in the *Component* > *Settings* tab:

   - *WebSocket settings*: Allows you to customize the polling interval for this component. To do so, clear the checkbox in this section and specify the custom polling interval.

   - *Filter assistance*: Determines whether the column filters will assist you by providing suggestions and other information such as units, step size, etc. By default disabled.

     > [!NOTE]
     > Depending on the size of your data, enabling this setting may impact performance.

   - *Allow color mode*: Determines whether [conditional coloring](#conditional-coloring) can be applied within the query filter. By default enabled.

- In the top-right corner of the query filter component, there is an *Active (x)* toggle button. If you enable this button, the component displays only the active filter options, and the button itself indicates the number of active options.

- Next to columns containing discrete values of type string or number, you can find a button that allows you to change how the possible values are displayed when you hover your mouse over it:

  - Select the *Toggle free form* button to display a text box in which you can type a value.

  - Select the *Toggle checklist* button to list all possible values as a checklist.

- When a node edge graph is exclusively filtered by node, edges will only be highlighted when both the source and destination are highlighted. Alternatively, when a node edge graph is exclusively filtered by edge, the source and/or destination attached to the highlighted edge segments will be highlighted.

## Linking a component to the query filter

When linked to a component using a feed, the query filter component allows real-time filtering of that associated component.

Two methods exist for linking a query filter:

- [Feeding queries as data](#feeding-queries-as-data)

- [Feeding query columns as filter](#feeding-query-columns-as-filter)

### Feeding queries as data

After configuring the query filter component:

1. Add a table component to your dashboard.

   > [!NOTE]
   > In this example, we are using a table component. However, any component capable of receiving a query can be linked to the query filter.

1. In the *Data* tab, go to *All available data > Feeds*. Expand the feed linked to the query filter and drag *Queries* onto the table component.

   Each time you change the query filter, a new query is fed to the table, displaying only rows that match the filter settings.

### Feeding query columns as filter

After configuring the query filter component:

1. Add a table component to your dashboard.

   > [!NOTE]
   > In this example, we are using a table component. However, any component capable of receiving a query can be linked to the query filter.

1. In the *Data* tab, go to *All available data > Queries*. Drag the query you created earlier onto the table component.

1. In the *Data* tab, go to *All available data > Feeds*. Expand the feed linked to the query filter and drag *Query columns* onto the yellow filter drop area of the table component.

   Each time you change the query filter, the data inside the table is filtered according to the filter settings in the query filter. No new query is fed to the table. The latter keeps displaying all rows, but those that do not match the filter will turn gray.

## Conditional coloring

If the *Allow color mode* setting is enabled, a color marker icon will be available in the top-right corner of the filter query component.

Click the color marker icon to see a color legend to the right of the filter options. For each option, you can configure a custom color (default color: green).

> [!NOTE]
> When you deactivate the *Allow color mode* setting, any previously configured colors remain visible and applied.

> [!TIP]
> See also: [The query filter component: A versatile building block for your dashboards and low-code apps!](https://community.dataminer.services/the-query-filter-component-a-versatile-building-block-for-your-dashboards-and-low-code-apps/)
