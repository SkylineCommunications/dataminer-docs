---
uid: Component_Data
keywords: feeds
---

# Component data

> [!NOTE]
> Prior to DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12<!--RN 41141-->, component data is referred to as "feeds" instead.

Many components in dashboards and low-code apps can be configured to be linked to component data, i.e., data that is made available by other components in the dashboard or app. This way, their content can be dynamically adjusted by users.

## Configuration

To have a component in your dashboard or app updated based on component data:

1. [Add a new component](xref:Configuring_components), such as a time range component, to the dashboard or low-code app.

   After doing so, a new data entry will appear in the *Components* section of the *Data* pane. Prior to DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12<!--RN 41141-->, this entry is located under *Feeds* in the *Data* pane.

   > [!NOTE]
   > For some components, you may need to interact with the component before a new data entry appears in the *Components* section. For example:
   >
   > - In a table component, select a row to make the *Table* > *Selected rows* data available.
   > - In a grid component, select a cell to make the *Grid* > *Selected items* data available.

1. Select the data entry and drag it onto the component you wish to link it to.

   The component will now depend on the selected component data for its input.

![Component data](~/dataminer/images/Component_Data.gif)<br>*Low-Code Apps module in DataMiner 10.4.12*

> [!NOTE]
>
> - You can also have a [dashboard or app depend on data in a URL without containing any dedicated components](xref:URL_data).
> - For more information on configuring query (GQI) data, see [Creating a GQI query](xref:Creating_GQI_query).

## Selection-dependent component data

Some component data is only available **when data is selected in the original component**, e.g., the *Grid* > *Selected items* > *Tables* data object. This data is dependent on the selection in the original component, and when passed to a linked component, the data displayed will update based on the current selection.

For example, if a specific cell is selected in a grid component and a table component has been passed the *Grid* > *Selected items* > *Tables* data object, the table will display data corresponding to the selected cell. If you then select a different cell in the grid, the table will update to reflect the new selection.

You can **pass multiple data entries to a linked component** by holding down CTRL while selecting data in the original component. From DataMiner 10.4.0 [CU12]/10.5.0 [CU1]/10.5.4 onwards<!--RN 42163-->, these entries are passed in chronological order. For example, selecting an additional cell in a grid component will add a new row at the bottom of the linked table component. In earlier versions, the order of new data entries varies, with new entries sometimes appearing before or between older ones.

![Component data](~/dataminer/images/ComponentData.gif)<br>*Low-Code Apps in DataMiner 10.5.4*
