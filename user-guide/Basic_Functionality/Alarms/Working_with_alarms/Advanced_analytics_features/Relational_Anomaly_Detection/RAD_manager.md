---
uid: RAD_manager
---

# Working with the RAD Manager

The *RAD Manager* is a low-code app, available in the DataMiner Catalog, that allows you to easily configure relational anomaly detection and visualize the anomaly scores it calculates.

## Installing the RAD Manager

To install the *RAD Manager*, go to <https://catalog.dataminer.services/details/174b9848-43c8-470d-afc2-1b1722f05e74> and deploy the app to your DataMiner System by clicking the *Deploy* button.

You can then find the *RAD Manager* app on your DataMiner landing page at `https://[Your DMA]/root` and logging in, see also [Accessing the Low-Code Apps module](xref:Accessing_custom_apps).

## Inspecting the configured parameter groups

The main window of the RAD Manager app shows the groups that are currently being monitored by RAD. It allows you to view the trend graph of each of the parameters in each of the groups, as well as the historical anomaly scores that RAD has calculated.

![The main window of the RAD app](~/user-guide/images/RAD_Manager.png)

The table under *Your Relational Anomaly Groups*, near the top of the app, shows the all parameter groups that are currently being monitored by RAD. When you first start the app, this will probably be empty. To add a new group, select [*Add Group*](#adding-a-parameter-group) in the header bar. For each group, the table shows the name of the group, a list of parameters that belong to the group, and various configuration options.

After selecting a group in the table above, the *Group Information* table below shows information about all parameters that belong to that group. You can select one or more parameters in this table to display their trend graph below.

The line graph at the bottom, under *Inspect the anomaly score of your group*, shows the anomaly score that RAD gives to the parameter group at any given time. If this score is high, then RAD considers the behavior of the parameter at that time to be anomalous; if it is low, then it considers the behavior to be normal. By default, an anomaly score greater than 3 is considered anomalous. If such a score is detected on new data, a *Suggestion event* will be created, which is visible in the *Suggestion events* tab in the Alarm Console in Cube.

## Adding a parameter group

Select *Add Group* in the header bar on the top-left to add a new parameter group to be monitored by RAD. This will open a pop-up where you can configure the parameter group you want add.

Under *What to add?*, you have two options.

- *Add single group*: allows you to add a single group of parameters.
- *Add group for each element with given connector*: allows you to add a group for each element using a given connector.

### Adding a single group

![Pop-up to add a new single parameter group](~/user-guide/images/RAD_Manager_AddSingleParameterGroup.png)

To add a single group, you have to specify the name of the group and add at least two parameter instances. This name will be used when listing the configured groups in the main window and in the suggestion events that are generated when an anomaly on this group of parameters is detected.

To add a parameter instance, first select the correct element from the dropdown under *Element*, then select the parameter and, in case of a table parameter, specify the display key of the parameter instance under *Display key filter*. Finally, press the *Add* button. Repeat the process to add additional parameters. You can specify multiple instances for the same parameter by using wildcards characters \* and ? under *Display key filter*, see [Searching with wildcard characters](xref:Searching_in_DataMiner_Cube#searching-with-wildcard-characters).

In addition to the name and the parameter instances, you can also specify several other options. For more information on these options, see [Options for parameter groups](xref:Relational_anomaly_detection#options-for-parameter-groups). When finished, press the *Add group* button.

> [!NOTE]
> Only parameters that fulfill the limitation and prerequisites mentioned [here](xref:Relational_anomaly_detection) are shown in the pop-up.

### Adding groups for each element with a given connector

The *Add group for each element with given connector* option allows you to create similar groups for each element with a given connector and connector version. After specifying the connector, the connector version and several parameters of that connector and pressing *Add group(s)*, and the app will create a group with the given parameters for each element on your DataMiner System that uses the given connector and connector version.

![Pop-up to add new parameter group for each element with given connector](~/user-guide/images/RAD_Manager_AddParameterGroupPerProtocol.png)

Near *Group name prefix* you need to specify a prefix that will be used to form the name of the resulting parameter groups: for each element, the parameter group name will be `[PREFIX] (ELEMENT_NAME)`. As before, the name of these parameter groups will be used when listing the configured groups in the main window and in the suggestion events that are generated when an anomaly on this group of parameters is detected.

Under the *Group name prefix*, you can specify the connector and connector version. Once you have selected these, you must add at least two parameter instances to the group. As before, you can specify multiple instances for the same parameter by using wildcards characters \* and ? under *Display key filter*, see [Searching with wildcard characters](xref:Searching_in_DataMiner_Cube#searching-with-wildcard-characters). Press *Add* to add the parameter instance to the group. Note that if a particular instance only exists on certain elements using the specified connector, the corresponding instance will only be added to the parameter groups of those elements.

In addition to the name and the parameter instances, you can also specify several other options. For more information on these options, see [Options for parameter groups](xref:Relational_anomaly_detection#options-for-parameter-groups).

At the bottom of the pop-up an overview is given of the parameters groups that will be added to your configuration. When finished, press *Add group(s)*.

## Editing a parameter group

To edit an existing group, select that group in the table under *Your Relational Anomaly Groups* and select the *Edit Group* button in the header bar. This will open a pop-up that allows you to change the name of the group, add or remove parameters and/or change the options of the group. See [Adding a single group](#adding-a-single-group) for more information on each of the options.

## Removing a parameter group

The *Remove Group* button in the header bar removes the group(s) selected in the table under *Your Relational Anomaly Groups*. After removing a group, it will no longer be monitored by RAD and all currently active suggestion events will be cleared.

## Specifying the training range

In some cases, it can be useful to retrain the internal model used by RAD. This allows you to indicate the periods during which a parameter group was behaving as expected, so that RAD can better identify when the parameters deviate from that expected behavior in the future. By default, RAD uses all 5-min average trend data (with a maximum of 2 months) that was available when the group was first added. If this default time range contains anomalous data, if only limited data was available when the group was added, or if one or more parameters have changed behavior since the initial training, it can be useful to retrain the parameter group using a specified time range.

![Pop-up to specify the training range for a given parameter group](~/user-guide/images/RAD_Manager_SpecifyTrainingRange.png)

In order to retrain the model of a group, select the group the table under *Your Relational Anomaly Groups* and then press *Specify Training Range*. A pop-up will open where you can specify one or more time ranges that will be used for training the selected parameter group. To add a time range, select the desired start and end time in the pickers near *From* and *to*, and then press *Add*. Repeat the process to add additional time ranges. Once you have added the desired time ranges, you can press the *Retrain* button. This will immediately retrain the parameter group, and you will see the resulting anomaly scores in the main window under *Inspect the anomaly score of your group*.
