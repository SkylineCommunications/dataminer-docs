---
uid: DashboardAndAppsNavigation
---

# Linking a shape to a dashboard or app

It is possible to configure a shape in Visual Overview so that it opens a dashboard or low-code app filtered based on the relevant EPM feed, by specifying data input in the URL.

To do so, use a **Link** shape data field. The value has to be the dashboard or app URL, which will contain a JSON configuration. For example:

```text
http://<DMAIP>/dashboard/#/db/Training/Station/01.%20Device%20Overview.dmadb?data={"version":1,"feed":null,"components":[{"cid":1,"select":{"epm-selections":["[param:[cardVar: _elementInfo],901]/5502/[fieldId]"]}}],"feedAndSelect":{}}
```

For detailed information about the JSON syntax, see [Specifying data input in a dashboard or app URL](xref:Specifying_data_input_in_a_URL).

To link to EPM objects in this JSON syntax, you will need to use the **epm-selections** field, with the DMA ID, element ID, field PID and primary key value, separated by forward slashes. This field has to be used within a component field, which means you will need to find the ID of the component. You can do so by editing the dashboard or low-code app and looking up the number in the lower-right corner of the component:

![Component ID location in dashboard](~/develop/images/EPM_Retrieving_component_ID2.png)<br>
*Component ID in a dashboard in DataMiner 10.4.3*

Here is an example of what this will look like in a live system:

![Example of a live system](~/develop/images/348001913-4db1ed7c-b5e7-45fc-a55b-cd7ae9f533f0.png)

> [!NOTE]
> While in the example above the primary key is retrieved dynamically, it is also possible to hard-code everything in the URL. However, this is not recommended as it is not an efficient way of working in an EPM environment.

> [!TIP]
> See also:
>
> - [Linking a shape to a dashboard component](xref:Linking_a_shape_to_a_dashboard_component)
> - [Specifying data input in a dashboard or app URL](xref:Specifying_data_input_in_a_URL)
