---
uid: DashboardTree
---

# Tree

With the tree component, you can **select one or more items in a tree view**. The selectable items can be based on any data.

## How data is displayed in the tree

The way items are listed in the component depends on the type and number of data sources applied:

- Built-in data sources (such as *Elements* or *Protocols*):

  - When you apply a single data source, the tree shows the individual items from each data source.

  - If multiple data sources are applied, the items are grouped per data source in the tree. For example, protocol items may be listed first, followed by an *Elements* heading and the elements items.

- Query and *Tables* data sources:

  - When you apply a single query data source or *Tables* data source, the tree shows the individual rows from that query or table. Each row becomes a selectable item.

    > [!NOTE]
    > Prior to DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4<!--RN 38811-->, when you apply a single query data source, the query itself is listed as data.

  - When you apply multiple query data sources or *Tables* data sources, the tree instead shows the queries or tables themselves.

## Filtering tree content

You can filter the contents of a tree component using one of two available methods:

- Use the **filter box** at the top of the component.

- Pass a **text string** to the tree component, for example by using a text input component (supported from DataMiner Web 10.5.0 [CU16]/10.6.0 [CU4]/10.6.7 onwards<!--RN 45485-->).

  You can filter based on a text string in several different ways, for example:

  - Use a text input or search input component:

    1. Add a [text input](xref:DashboardTextInput) or [search input](xref:DashboardSearchInput) component to your dashboard or app.

    1. Hover over the tree component, click the filter icon, and then add a filter from the *All available data* > *Components* > *[Page/Panel name]* > *Text input/Search input* > *Value* > *Texts* section of the *Data* pane.

    When you input text in the published version of the dashboard or app, the tree component will automatically filter based on this input, and the value will appear in the tree's search box.

  - Specify a **text string in the dashboard or app URL**:

    1. Hover over the component, click the filter icon, and then add a filter from the *URL > Texts* section of the *Data* pane.

    1. Pass a string data object within the URL, as explained in [Specifying data input in a dashboard or app URL](xref:Specifying_data_input_in_a_URL).

       This URL will automatically display a filtered version of the tree when the dashboard or app is opened.

       In the following example, the text string "test" is sent to the component with component ID 1:

       `https://<dma>/<app-id>?data={"components": [{"cid":1, "select":{"strings": ["test"]}}]`

## Configuration options

### Tree layout

In the *Layout* pane, you can find the default options available for all components. See [Customizing the component layout](xref:Customize_Component_Layout).

Additionally, the following layout options are also available:

| Section | Option | Description |
|--|--|--|
| Advanced | Display column | Available from DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4 onwards<!--RN 38811-->. Select the column whose values are shown in the tree. Only available when a single query data source or *Tables* component data source was applied. |

### Tree settings

In the *Settings* pane for this component, you can customize its behavior to suit your requirements.

| Section | Option | Description |
|--|--|--|
| WebSocket settings | Inherit WebSocket settings from page/panel | Clear the checkbox to use a custom polling interval for this component. When cleared, you can specify a different polling interval (in seconds). |
| Initial selection | Select first item by default | Available from DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4 onwards<!--RN 38775-->. When enabled, the first item is automatically selected when the data in the tree is refreshed, unless a custom URL is used specifying a different value. This setting is enabled by default. |
| Initial Selection | Select item by default | Specify a fixed default value, which is automatically selected when the data in the tree is refreshed, unless a custom URL is used specifying a different value. From DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4 onwards<!--RN 38775-->, this setting is only available when the *Select first item by default* setting is disabled.<br><br>Formerly known as:<br>- *Initial Selection* (Prior to DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4<!--RN 38775-->)<br>- *Feed Defaults* (Prior to DataMiner 10.3.6/10.4.0<!--RN 35984-->)|
| Data retrieval | Update data | Available from DataMiner 10.3.0 [CU13]/10.4.0 [CU1]/10.4.4 onwards<!--RN 38811-->. Toggle the switch to determine whether the values displayed in the component should be updated automatically (provided this is supported by the data source). See [Query updates](xref:Query_updates)<!--RN 37269-->. This setting is only available when a single query data source or an indices dataset was applied. This setting is disabled by default. |
