---
uid: Parameter_Data
---

# Parameter data

The *Parameters* data category allows you to use data from [parameters](xref:parameters) in your DataMiner System as input for components in your dashboards or low-code apps.

When you expand the *Parameters* section in the *Data* pane, you first need to select an element, service, view, or protocol. When this is done, all available parameters for that source are listed.

The type of parameter you select determines how the data is interpreted:

- Element parameters represent metrics for a specific element in your system.

- Service parameters represent metrics for [enhanced services](xref:About_services#enhanced-services).

- View parameters represent [aggregation metrics](xref:Aggregation).

- Protocol parameters represent metrics defined by a protocol, but are not tied to any particular element. If you use protocol parameters, make sure to also add an [element data source](xref:Element_Data) as a filter, so the visualization knows which element to get data from.

You can select a specific parameter by first selecting *Element*, *Service*, or *View* in the *From* box and then specifying a filter. Alternatively, you can select a parameter by first selecting *Protocol* in the *From* box and then specifying a protocol in the filter.

> [!NOTE]
> Prior to DataMiner 10.3.9/10.4.0, table column parameter data objects do not include indices, which means you also need to add an indices data object as a filter for this data in order to display specific cells. From DataMiner 10.3.9/10.4.0 onwards, the cells associated with a table column are included under a table column data node in the *Data* pane, so that you can add specific cells directly. By default, only the first 100 entries are displayed, but you can use a filter box to find other entries if necessary.<!-- RN 36724 -->

To help locate a specific parameter, click the filter icon. You can then filter by one of the following preset parameter types:

- Button

- Column

- Monitored

- Range

- Read

- Single

- Table

- Trended

To use an entire data page as data input, select a data page (indicated by the ![page icon](~/dataminer/images/Page_Icon.png) icon) from the *Parameters* section and drag it onto a compatible visualization.

> [!NOTE]
> If you configured a [parameter page component](xref:DashboardParameterPage) using element data, you will need to add a data page filter from the *Parameters* data category.
