---
uid: EpmIntegrationTrainingAggregations
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
For EPM you will use an attribute epm-selections within the component property that expects DMA ID/Element ID/Field PID/Primar Key Value. This has to be used within a component object select field, therefore you will need to know the ID of the Dashboard component. An example of the syntax is:
![image](https://github.com/Daniela-Prada/dataminer-docs/assets/102039927/8ba53c8c-76ab-449e-862c-eaa4681a27d1)

>[!NOTE]
>The above shows a dynamic way of retrieving the Primary Key, but it is also possible to hardcode everything, this is not recommended as it will not be ideal in an EPM environment.

# Retrieve Component ID for Web Apps
![image](https://github.com/Daniela-Prada/dataminer-docs/assets/102039927/104977c1-1f0a-4887-b88e-8408a0ea4f01)
![image](https://github.com/Daniela-Prada/dataminer-docs/assets/102039927/14cb3c3d-9314-4186-acd6-54d7eab037da)
