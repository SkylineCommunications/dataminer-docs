---
uid: RAD_manager
---

# Working with the RAD Manager

The *RAD Manager* is a low-code app, available in the DataMiner Catalog, that allows you to easily configure relational anomaly detection and visualize the anomaly scores it calculates. The app requires DataMiner 10.5.4/10.6.0 or higher.

## Installing the RAD Manager

To install the *RAD Manager*, go to <https://catalog.dataminer.services/details/174b9848-43c8-470d-afc2-1b1722f05e74> and deploy the app to your DataMiner System by clicking the *Deploy* button.

You can then find the *RAD Manager* app on your DataMiner landing page at `https://[Your DMA]/root`. See also [Accessing the Low-Code Apps module](xref:Accessing_custom_apps).

## Inspecting the configured parameter groups

The main window of the RAD Manager app shows the groups currently monitored by RAD. It allows you to view the configuration options for each group, the parameters in the group, the trend graph of each parameter, and the historical anomaly scores that RAD has calculated.

![The main window of the RAD app](~/user-guide/images/RAD_Manager.png)

The table under *Your Relational Anomaly Groups*, near the top of the app, shows all parameter groups that are currently being monitored by RAD, along with the parameters belonging to those groups and various [configuration options](xref:Relational_anomaly_detection#options-for-parameter-groups). When you first start the app, this table will likely be empty. To add a new group, select [*Add Group*](#adding-a-parameter-group) in the header bar.

After selecting a group in the table at the top, the *Group Information* table below it shows information about all parameters that belong to that group. You can select one or more parameters in that table to view their trend graph below.

The line graph at the bottom, under *Inspect the anomaly score of your group*, shows the anomaly score that RAD gives to the parameter group at any given time. A high score indicates that RAD considers the behavior of the parameters anomalous, whereas a low score suggests normal behavior. By default, an anomaly score greater than 3 is considered anomalous. If such a score is detected in new data, a *Suggestion event* will be created which is visible in the *Suggestion events* tab in the Alarm Console in Cube. See also [Relational anomalies in the Alarm Console](xref:Relational_anomaly_detection#relational-anomalies-in-the-alarm-console).

## Adding a parameter group

To add a new parameter group, select *Add Group* in the header bar at the top left. This will open a pop-up where you can configure the group you want to add.

Under *What to add?*, you have two options:

- [*Add single group*](#adding-a-single-group): allows you to add a single group of parameters.
- [*Add group for each element with given connector*](#adding-groups-for-each-element-with-a-given-connector): allows you to add a group for each element using a specified connector.

### Adding a single group

![Pop-up to add a new single parameter group](~/user-guide/images/RAD_Manager_AddSingleParameterGroup.png)

To add a single group, specify the name of the group and add at least two parameter instances. This name will be used when listing the configured groups in the main window and in suggestion events generated when an anomaly is detected.

To add a parameter instance, first select the correct element from the dropdown under *Element*, then select the parameter and, in case of a table parameter, specify the display key of the parameter instance under *Display key filter*. Finally, press the *Add* button. Repeat the process to add additional parameters. You can specify multiple instances for the same parameter by using wildcards characters \* and ? under *Display key filter*. See also [Searching with wildcard characters](xref:Searching_in_DataMiner_Cube#searching-with-wildcard-characters).

In addition to the name and parameter instances, you can also specify several other options. For more information, see [Options for Parameter Groups](xref:Relational_anomaly_detection#options-for-parameter-groups). When finished, press *Add Group*.

> [!NOTE]
> Only parameters that meet the limitations and prerequisites mentioned [here](xref:Relational_anomaly_detection) are shown in the pop-up.

### Adding groups for each element with a given connector

The *Add group for each element with given connector* option allows you to create similar groups for each element using a specified connector and connector version. After selecting the connector, connector version, and relevant parameters, the app will create a group with the specified parameters for each element in your DataMiner System that uses the given connector and version.

![Pop-up to add a new parameter group for each element with a given connector](~/user-guide/images/RAD_Manager_AddParameterGroupPerProtocol.png)

Next to *Group Name Prefix*, specify a prefix that will be used to generate the names of the resulting parameter groups. Each element will have a parameter group named `[PREFIX] ([ELEMENT_NAME])`. As before, these names will be used when listing configured groups in the main window and in suggestion events generated for detected anomalies.

Under the *Group name prefix*, you can specify the connector and connector version. Once you have selected these, you must add at least two parameter instances to the group. As before, you can specify multiple instances for the same parameter by using wildcards characters \* and ? under *Display key filter*, see [Searching with wildcard characters](xref:Searching_in_DataMiner_Cube#searching-with-wildcard-characters). Press *Add* to add the parameter instance to the group. Note that if a particular instance only exists on certain elements, the corresponding instance will only be added to the parameter groups of those elements.

In addition to the name and the parameter instances, you can also specify several other options. For more information on these options, see [Options for parameter groups](xref:Relational_anomaly_detection#options-for-parameter-groups).

At the bottom of the pop-up, an overview displays the parameter groups that will be added. When finished, press *Add Group(s)*.

## Editing a parameter group

To edit an existing group, select it in the table under *Your Relational Anomaly Groups* and click *Edit Group* in the header bar. This will open a pop-up where you can change the group name, add or remove parameters, and modify group options. See [Adding a Single Group](#adding-a-single-group) for details on each option.

## Removing a parameter group

Click *Remove Group* in the header bar to delete the selected group(s) from *Your Relational Anomaly Groups*. Once removed, the group will no longer be monitored by RAD, and all currently active suggestion events will be cleared.

## Specifying the training range

In some cases, retraining RAD's internal model can be beneficial. This allows you to specify periods during which a parameter group was behaving as expected, helping RAD better identify deviations in the future. By default, RAD trains each group upon creation using all available five-minute average trend data (up to a maximum of two months). If this initial training range contained anomalous data, had limited data available, or if the parameters’ behavior has changed, retraining using a specified time range can be useful.

![Pop-up to specify the training range for a given parameter group](~/user-guide/images/RAD_Manager_SpecifyTrainingRange.png)

To retrain a model of a group, select the group in the table under *Your Relational Anomaly Groups* and click *Specify Training Range* in the header bar. A pop-up will open where you can specify one or more time ranges that will be used to retrain the selected parameter group. To add a time range, select the desired start and end time in the pickers near *From* and *to*, and then press *Add*. Repeat the process to add additional time ranges. Once you have added the desired time ranges, you can press *Retrain*. This will immediately retrain the parameter group, and you will see the resulting anomaly scores in the main window under *Inspect the anomaly score of your group*.
