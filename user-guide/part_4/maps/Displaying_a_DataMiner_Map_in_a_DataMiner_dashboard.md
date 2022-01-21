---
uid: Displaying_a_DataMiner_Map_in_a_DataMiner_dashboard
---

## Displaying a DataMiner Map in a DataMiner dashboard

Using the new *Dashboards* app (from DataMiner 9.6.11 onwards):

1. Select a dashboard and click the *Start editing* button in the header bar.

    > [!TIP]
    > See also:
    > [Dashboards app](../newR_D/newR_D.md#dashboards-app)

2. Drag the *Generic Map* component onto the dashboard from the panel with available components on the left.

3. In the *Settings* tab, select a map configuration file.

    > [!NOTE]
    > - For more information on the configuration files, see [Configuring the DataMiner Maps](Configuring_the_DataMiner_Maps.md).
    > - If no map configuration files are found, make sure the *ServerConfig.xml* file is configured correctly. See [Configuring the DataMiner Maps host servers](Configuring_the_DataMiner_Maps_host_servers.md).

4. Configure any additional parameters that have become available. These parameters and the way they need to be configured depend on the map configuration file.

5. When ready, click *Stop editing*.

Using the legacy Reports & Dashboards module (prior to DataMiner 9.6.11):

1. Open a DataMiner dashboard (using the legacy Reports & Dashboards module) and choose *Actions \> Add/Remove Components*.

    > [!TIP]
    > See also:
    > [DMS Dashboards](../dashboards/dashboards.md#dms-dashboards)

2. In the *Add/Remove Components* pane, click *Other*.

3. In the *Other* pane, do the following:

    1. Select the DataMiner Map component.

    2. In the *Add to* selection box, select the dashboard section to which to add the component.

    3. Click *Add*.

4. On the newly added DataMiner Map component, click *Configure*.

5. In the *Configure Components* pane, enter the name of the configuration file (without the ”.xml” extension) in the *Configuration box*.

    > [!NOTE]
    > For more information on the configuration files, see [Configuring the DataMiner Maps](Configuring_the_DataMiner_Maps.md).

6. Configure the following options if necessary:

    - In the *Custom Height* box, enter a different custom height.

    - In the *Extra Variables* box, add any extra variables to add to the map URL.

        For example, if you declared a variable in the DataMiner Map configuration file called “dmyElement”, you can pass a value for that variable to the DataMiner Map by specifying the following in the *Extra Variables* box: dmyElement=7/46840.
        You can also use the following placeholders in this box:

        | Placeholder                 | Description                                                                                               |
        |-------------------------------|-----------------------------------------------------------------------------------------------------------|
        | \[param:dmaid/eid:pid:idx\]   | Reference to a parameter of an element specified by its DmaID/ElementID combination.                      |
        | \[param:elementname:pid:idx\] | Reference to a parameter of an element specified by its name.                                             |
        | \[this service\]              | Reference to a service specified elsewhere in the box by e.g. a “dMyService=...” construction.            |
        | \[this row\]                  | Reference to the dynamic table row specified elsewhere in the box by e.g. a “\[param:...\]” construction. |
        | \[login\]                     | Reference to the username of the user who is currently logged in.                                         |

        > [!NOTE]
        > For more info on how to add variables in the map configuration, see:
        > - [Passing ParametersSourceInfo data along in the map’s URL](ParametersSourceInfo.md#passing-parameterssourceinfo-data-along-in-the-maps-url)
        > - [Passing PropertiesSourceInfo data along in the map’s URL](PropertiesSourceInfo.md#passing-propertiessourceinfo-data-along-in-the-maps-url)
        > - [Passing TableSourceInfo data along in the map’s URL](TableSourceInfo.md#passing-tablesourceinfo-data-along-in-the-maps-url)

    - In the *Fixed Width* box, enter a fixed width for the map.

    - To change the title of the component, enter the new title in the *Title* box.

    - To display the title in the component, select *Display Title*.

    - To display a border around the component, select *Display Border*.

7. Click *OK* to finish configuring the component.

8. Click *Close Edit Mode*.
