---
uid: DashboardAndAppsNavigation
---

# Dashboards/Apps Navigation

You can navigate to a dashboard already filtered on the EPM Feed by specifying the data input passed in the URL, this will consist of data option in the URL that will contain a JSON. This is an example of the URL and JSON.

  ```xml
      url?data=<URL-encoded JSON object>

      {
        "version": 1,
        "feedAndSelect": <data>, (optional)
        "feed": <data>, (optional)
        "select": <data>, (optional)
        "components": <component-data>
      }
  ```

For EPM you will use an attribute epm-selections within the component property that expects DMA ID/Element ID/Field PID/Primary Key Value. This has to be used within a component object select field, therefore you will need to know the ID of the Dashboard component. An example of the syntax is:

![image](~/develop/images/EPM_dashboards_navigation.png)

> [!NOTE]
> The above shows a dynamic way of retrieving the Primary Key, but it is also possible to hardcode everything, this is not recommended as it will not be ideal in an EPM environment.

## Retrieving the component ID for the web apps

![image](~/develop/images/EPM_Retrieving_component_ID1.png)

![image](~/develop/images/EPM_Retrieving_component_ID2.png)

For more detailed information, see [Specifying data input in a dashboard URL](xref:Specifying_data_input_in_a_dashboard_URL).
