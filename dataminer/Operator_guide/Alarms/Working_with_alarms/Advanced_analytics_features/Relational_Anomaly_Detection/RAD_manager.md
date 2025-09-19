---
uid: RAD_manager
---

# Working with the RAD Manager

The RAD Manager is a low-code app, available in the Catalog, that allows you to easily configure [relational anomaly detection](xref:Relational_anomaly_detection) and visualize the anomaly scores it calculates. The app requires DataMiner 10.5.4/10.6.0 or higher.

## Installing the RAD Manager

To install the RAD Manager app, go to [RAD Manager](https://catalog.dataminer.services/details/174b9848-43c8-470d-afc2-1b1722f05e74) in the Catalog and deploy the app to your DataMiner System by clicking the *Deploy* button.

You can then find the RAD Manager app on your DataMiner landing page at `https://[Your DMA]/root`.

> [!TIP]
> See also [Accessing the web apps](xref:Accessing_the_web_apps).

## Inspecting the configured relational anomaly parameter groups

The main window of the RAD Manager app shows the groups currently monitored by RAD. It allows you to view the configuration options for each group, the parameters in the group, the trend graph of each parameter, and the historical anomaly scores that RAD has calculated.

![The main window of the RAD Manager app](~/dataminer/images/RAD_Manager.png)

The table under *Your Relational Anomaly Groups*, near the top of the app, shows all parameter groups that are currently being monitored by RAD, along with the parameters belonging to those groups and various [configuration options](xref:Relational_anomaly_detection#options-for-rad-parameter-groups). When you first start the app, this table will likely be empty. To add a new group, select [*Add Group*](#adding-a-relational-anomaly-group) in the header bar.

When a group is selected in the table at the top, the *Group Information* table below it shows information about all parameters that belong to that group. You can select one or more parameters in that table to view their trend graph below.

The line graph at the bottom, under *Inspect the anomaly score of your group*, shows the anomaly score that RAD gives to the parameter group at any given time. A high score indicates that RAD considers the behavior of the parameters anomalous, while a low score suggests normal behavior. By default, an anomaly score greater than 3 is considered anomalous. If such a score is detected in new data, a suggestion event will be created, which you can find in the [*Suggestion events* tab in the Alarm Console](xref:Relational_anomaly_detection#relational-anomalies-in-the-alarm-console) in Cube.

## Adding a relational anomaly group

To add a new relational anomaly parameter group, select *Add Group* in the top-left corner of the app. This will open a window where you can configure the group you want to add.

Under *What to add?*, you can select one of the following options, as detailed below:

- [*Add single group*](#adding-a-single-group): Allows you to add a single group of parameters.
- [*Add group for each element with given connector*](#adding-groups-for-each-element-with-a-given-connector): Allows you to add a group for each element that uses a specified connector.

### Adding a single group

If you have selected to add a single group, you can configure it as follows:

1. Specify the name of the group.

   The group name will be used when listing the configured groups in the main window and in suggestion events generated when an anomaly is detected.

1. Add at least two parameter instances:

   1. Select the correct element in the *Element* dropdown.

   1. Select the parameter.

   1. If you have selected a table parameter, specify the display key of the parameter instance under *Display key filter*.

   1. Click the *Add* button.

   1. Repeat the previous steps until you have added all the parameter instances you want.

      You can specify multiple instances for the same parameter by using wildcard characters \* and ? under *Display key filter*. (See [Searching with wildcard characters](xref:Searching_in_DataMiner_Cube#searching-with-wildcard-characters).)

   > [!NOTE]
   > Only parameters that meet the [limitations and prerequisites for RAD](xref:Relational_anomaly_detection) are shown in the *Add Parameter Group* window.

1. Optionally, select different [options for the relational anomaly group](xref:Relational_anomaly_detection#options-for-rad-parameter-groups).

1. When you have fully configured the group, click *Add Group*.

![Adding a single group](~/dataminer/images/RAD_Manager_AddSingleParameterGroup.png)

### Adding groups for each element with a given connector

If you have selected to add a group for each element with a given connector, you can configure the groups as follows:

1. Next to *Group Name Prefix*, specify a prefix that will be used to generate the names of the resulting relational anomaly parameter groups.

   For each relevant element, a relational anomamy group will be created with the name `[PREFIX] ([ELEMENT_NAME])`. These names will be used when listing configured groups in the main window and in suggestion events generated for detected anomalies.

1. Select the connector and connector version.

1. Add at least two parameter instances to the group:

   1. In the *Parameter* dropdown, select the parameter you want to add.

   1. If you have selected a table parameter, specify the display key of the parameter instance under *Display key filter*.

   1. Click the *Add* button.

   1. Repeat the previous steps until you have added all the parameter instances you want.

      You can specify multiple instances for the same parameter by using wildcard characters \* and ? under *Display key filter*. (See [Searching with wildcard characters](xref:Searching_in_DataMiner_Cube#searching-with-wildcard-characters).)

      At the bottom of the window, an overview will be displayed of all the parameter groups that will be added.

   > [!NOTE]
   > If a particular instance only exists on certain elements, the corresponding instance will only be added to the parameter groups of those elements.

1. Optionally, select different [options for the relational anomaly group](xref:Relational_anomaly_detection#options-for-rad-parameter-groups).

1. When you have fully configured the group, click *Add Group(s)*.

   The app will create a group with the specified parameters for each element in your DataMiner System that uses the given connector and version.

![Adding groups for each element with a given connector](~/dataminer/images/RAD_Manager_AddParameterGroupPerProtocol.png)

## Editing a relational anomaly parameter group

To edit an existing group, select it in the table under *Your Relational Anomaly Groups* and click *Edit Group* in the header bar.

This will open a window where you can change the group name, add or remove parameters, and modify group options. For more details, refer to [Adding a single group](#adding-a-single-group).

## Removing a relational anomaly parameter group

To delete one or more groups, select them in the table under *Your Relational Anomaly Groups* and click *Remove Group* in the header bar.

When a group is removed, it will no longer be monitored by RAD. From DataMiner 10.5.6/10.6.0 onwards<!--RN 42602-->, all active suggestion events linked to the group will automatically be cleared.

## Specifying the training range

In some cases, retraining RAD's internal model can be beneficial. This allows you to specify periods during which a relational anomaly group was behaving as expected, helping RAD better identify deviations in the future. By default, RAD trains each group upon creation using all available five-minute average trend data (up to a maximum of two months). If this initial training range contained anomalous data, had limited data available, or if the parameters’ behavior has changed, retraining using a specified time range can be useful.

To retrain the model of a group:

1. Select the group in the table under *Your Relational Anomaly Groups* and click *Specify Training Range* in the header bar.

   A window will open where you can specify one or more time ranges that will be used to retrain the selected relational anomaly group.

1. To add a time range, select the desired start and end time in the pickers near *From* and *to*, and then click *Add*.

1. Repeat the process to add additional time ranges.

1. Once you have added the desired time ranges, click *Retrain*.

   This will immediately retrain the relational anomaly group, and you will see the resulting anomaly scores in the main window under *Inspect the anomaly score of your group*.

![Specifying the training range for a given parameter group](~/dataminer/images/RAD_Manager_SpecifyTrainingRange.png)
