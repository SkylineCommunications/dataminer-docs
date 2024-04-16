---
uid: DashboardAndAppsNavigation
---

# Linking a shape to a dashboard or app

From DataMiner 10.0.8 onwards, you can configure a shape in Visual Overview so that it opens a dashboard or low-code app filtered based on the relevant EPM feed, by specifying data input in the URL.

To do so, use a **Link** shape data field. The value has to be the dashboard or app URL, which will contain a JSON configuration. For example:

![image](~/develop/images/EPM_dashboards_navigation.png)

For detailed information about the JSON syntax, see [Specifying data input in a dashboard URL](xref:Specifying_data_input_in_a_dashboard_URL) and [Specifying data input in an app URL](xref:Specifying_data_input_in_URL).

To link to EPM objects in this JSON syntax, you will need to use the **epm-selections** field, with the DMA ID, element ID, field PID and primary key value, separated by forward slashes. This field has to be used within a component field, which means you will need to find the ID of the component. You can do so by editing the dashboard or low-code app and looking up the number in the bottom right corner of the component:

![image](~/develop/images/EPM_Retrieving_component_ID2.png)<br>
*Component ID in a dashboard in DataMiner 10.4.3*

> [!NOTE]
> While in the example above, the primary key is retrieved dynamically, it is also possible to hard-code everything in the URL. However, this is not recommended as it is not an efficient way of working in an EPM environment.

> [!TIP]
> See also:
>
> - [Linking a shape to a dashboard component](xref:Linking_a_shape_to_a_dashboard_component)
> - [Specifying data input in a dashboard URL](xref:Specifying_data_input_in_a_dashboard_URL)
> - [Specifying data input in an app URL](xref:Specifying_data_input_in_URL)
