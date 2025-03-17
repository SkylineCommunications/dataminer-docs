---
uid: Component_Data
keywords: feeds
---

# Component data

> [!NOTE]
> Prior to DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12<!--RN 41141-->, component data is referred to as "feeds" instead.

Many components in dashboards and low-code apps can be configured to be linked to component data, so that their content can be dynamically adjusted by the users.

To have a component in your dashboard or app updated based on component data:

1. [Add a new component](xref:Configuring_components), such as a time range component, to the dashboard or low-code app.

   After doing so, a new data entry will appear in the *Components* section of the *Data* pane. Prior to DataMiner 10.3.0 [CU21]/10.4.0 [CU9]/10.4.12<!--RN 41141-->, this entry is located under *Feeds* in the *Data* pane.

1. Select the data entry and drag it onto the component you wish to link it to.

   The component will now depend on the selected component data for its input.

![Component data](~/user-guide/images/Component_Data.gif)<br>*Low-Code Apps module in DataMiner 10.4.12*

> [!NOTE]
>
> - You can also have a [dashboard or app depend on data in a URL without containing any dedicated components](xref:URL_data).
> - For more information on configuring query (GQI) data, see [Creating a GQI query](xref:Creating_GQI_query).

## Notes on component data

- 