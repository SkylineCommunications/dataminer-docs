---
uid: Relational_Anomaly_Detection_Tutorial
---

# Working with relational anomaly detection

This tutorial showcases DataMiner's [relational anomaly detection (RAD)](xref:Relational_anomaly_detection) feature. It show how you can use this feature to monitor the power outputs of all power amplifiers in a DAB transmitter to ensure they remain in sync. You will first need to specify the parameters that should be monitored together, and then the algorithm will automatically detect the relations between the parameters and generate suggestion events in the Alarm Console when it detects that these relations are broken.

Estimated duration: 35 minutes.

> [!NOTE]
> The content and screenshots for this tutorial have been created with DataMiner 10.6.1 and RAD Manager version 2.0.0.

## Prerequisites

- A DataMiner System [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

- DataMiner 10.6.0 main release/10.6.1 feature release or higher with [Storage as a Service (STaaS)](xref:STaaS) (recommended) or a [self-managed Cassandra-compatible database and indexing database](xref:Supported_system_data_storage_architectures).

- Relational Anomaly Detection is enabled (in DataMiner Cube: *System Center* > *System settings* > *analytics config*).

## Overview

The tutorial consists of the following steps:

- [Step 1: Install the example package from the Catalog](#step-1-install-the-necessary-packages-from-the-catalog)
- [Step 2: Check the DAB transmitter elements in Cube](#step-2-check-the-dab-transmitter-elements-in-cube)
- [Step 3: Configure your first RAD group](#step-3-configure-your-first-rad-group)
- [Step 4: Create a problem and verify if RAD detects it](#step-4-create-a-problem-and-verify-if-rad-detects-it)
- [Step 5: Tweak the advanced configuration](#step-5-tweak-the-advanced-configuration)
- [Step 6: Create a shared model group](#step-6-create-a-shared-model-group)
- [Step 7: Configure RAD groups with the API via a script](#step-7-configure-rad-groups-with-the-api-via-a-script)
- [Step 8: Play around with the Fleet Outlier Radar](#step-8-play-around-with-the-fleet-outlier-radar)
- [Step 9: Clean up your system](#step-9-clean-up-your-system)

## Step 1: Install the necessary packages from the Catalog

1. Go to the [RAD Demonstrator](https://catalog.dataminer.services/details/eeedd709-d681-448d-9a1e-2e5fbfd73740) package in the Catalog.

1. [Deploy the package](xref:Deploying_a_catalog_item) to your DataMiner Agent by clicking the *Deploy* button.

   This will create two Automation scripts:

   - Add Shared Model Group
   - Add Single Groups

   You can find them in the Automation module: the scripts are stored in the *DataMiner Catalog > RAD Demonstrator* folder.

   The package will also create the following DataMiner elements in the Cube Surveyor under *DataMiner Catalog* > *Using Relational Anomaly Detection* > *London*:

   - RAD - Commtia LON 1
   - RAD - Commtia LON 2
   - RAD - Commtia LON 3
   - RAD - Commtia LON 4
   - RAD - Commtia LON 5

	Finally, it will create 29 additional elements *Fleet-Outlier-Detection-Commtia 01*, *Fleet-Outlier-Detection-Commtia 02*,... 
until *Fleet-Outlier-Detection-Commtia 29* in the Cube Surveyor under *DataMiner Catalog* > *Using Relational Anomaly Detection* > *RAD Fleet Outlier*.

1. Go to the [RAD Manager](https://aka.dataminer.services/RAD-Manager-Catalog) package in the DataMiner Catalog and [deploy it](xref:Deploying_a_catalog_item).

1. Go to the root page of your DataMiner System, for example by clicking the *Home* button for your DMS on the [dataminer.services page](https://dataminer.services/), and check if you can see the *RAD Manager* app.

   ![RAD Manager icon on the root page](~/dataminer/images/RAD_Manager_on_root_page.png)
   
1. Open the *RAD Manager* app.
   The RAD Manager provides an overview of all the RAD groups that are configured on your system.

   ![RAD Manager first glance](~/dataminer/images/tutorial_RAD_Manager_First_Glance.png)

    > [!NOTE]
	> In case the package installation finished, you will already see a RAD Group in the RAD Manager. We will only use this in [Step 8](#step-8-play-around-with-the-fleet-outlier-radar) of the tutorial. So for now, don't delete or change it.

## Step 2: Check the DAB transmitter elements in Cube

1. In the Surveyor, open the view *DataMiner Catalog* > *Using Relational Anomaly Detection* > *London*, and select the element *RAD - Commtia LON 1*.

1. Go to the *Amplifier* > *PAs* page.

   This page provides information about the different power amplifiers (PAs) in the DAB transmitter.

1. In the *PAs* Measurements table, look at the *Output Power* column.

   All three power amplifiers should have similar output power values.

   ![Output Power](~/dataminer/images/tutorial_RAD_Output_Powers.png)

1. Next, go to the main *Amplifier* page and look at the *Tx Amplifier Output Power* parameter.

   This should be a little bit less than the sum of the previously mentioned output power values.

   ![Total Output Power](~/dataminer/images/tutorial_RAD_Total_Output_Power.png)

This gives you an idea of the parameter relations that will be used further in this tutorial: the output power of the different amplifiers in the DAB transmitter should be more or less equal, and the total output should be equal to the sum of these values with some losses.

## Step 3: Configure your first RAD group

1. Go to the RAD Manager app.

	There might already be a group called *Fleet-Outlier-Group*. Disregard it for now as we will use it later.

1. On the left side of the header bar, click *Add Single Group*.

   This will open a window where you can configure a new parameter group.

   ![Add a group](~/dataminer/images/tutorial_RAD_AddGroup.png)

1. As the *Group name*, fill in *PAs unbalanced*.

   Parameter groups should be given a meaningful name, because this name will be shown as part of the event that is triggered when the relation between the parameters is broken.

1. Add a first parameter:

   1. In the *Element* box, select *RAD - Commtia LON 1*.

   1. Make sure the *Output Power* parameter is selected.

   1. Under *Display key filter*, specify `PA*`. As we are monitoring *all* available power amplifiers, you can actually also leave this field empty.

   1. Click *Add*.

   This informs DataMiner that you want to monitor the *Output Power* of *PA1*, *PA2*, and *PA3* together.

1. Add a second parameter:

   1. Keep the *RAD - Commtia LON 1* element selected.

   1. Select the *Tx Amplifier Output Power* parameter.

   1. Keep the *Display key filter* empty.

   1. Click *Add*.

1. Override the default anomaly threshold:

   1. Select the *Override default anomaly threshold* checkbox.

   1. Fill in the value *3* in the field next to *Anomaly threshold*.

   This will make DataMiner more sensitive to deviations in the relations between the parameters. By default, an event will only be triggered when the so called *anomaly score* exceeds 6, but in this example the deviation of the parameters will be too small to lead to such a high anomaly score.

1. Override the default minimum anomaly duration:

   1. Select the *Override default minimum anomaly duration (in minutes)* checkbox.

   1. Fill in the value *000d 00h 05m* in the field next to *minimum anomaly duration (in minutes)*.

   This will make sure that DataMiner also detects short anomalies, when the relation is broken for only 5 minutes. By default, DataMiner will only trigger an event if the relation is broken for at least 15 minutes.

1. Click *Add group* to create the group.

The group entitled *PAs unbalanced* is now created and shown in the RAD Manager.

![Add a group](~/dataminer/images/tutorial_RAD_groupOverview.png)

## Step 4: Create a problem and verify if RAD detects it

1. In Cube, open the *RAD - Commtia LON 1* element.

1. Go to the *Demo Control* page.

1. Make sure *Demo Status* is set to *Ready*.

   When the element was created, it pushed some historical trend data to the database. This data is used by the algorithm to learn the relations between the parameters. The demo status will be set to *Ready* as soon as the history data is processed. This whole process should take about 5 minutes.

1. Click the *Add Degradation* button, and confirm if necessary.

   This will cause the *Output Power* of *PA3* to start deviating from the output powers of the other two amplifiers.

1. In the Alarm Console, click the lightbulb icon in the top-right corner and select the item referring to relational anomalies.

   You will see an event informing you that the relation between the *Output Power* of the amplifiers and the *Tx Amplifier Output Power* is broken.

   ![Detected Relational Anomaly](~/dataminer/images/tutorial_RAD_Detected_Anomaly.png)

1. In the RAD Manager app, select the group you created.

   The *Trend graph of parameters in selected group* graph will now display the parameters included in your group.

   ![Selected Group in RAD Manager](~/dataminer/images/tutorial_RAD_Selected_Group.png)

   > [!NOTE]
	> Note the red icon on the *PAs unbalanced* group, indicating there was an anomaly. If you don't see it immediately, refresh the *RAD Manager* page in your browser.

1. On the graph component, right hand side, click the *<* button to display the list of parameters in the group. Click the *Output Power - pa1* and *Tx Amplifier Output Power* to remove them from the graph.			

1. Above the graph, select the time range covering the last 24 hours.

   This will give you a better view of the parameter trends before and after you created the degradation.

1. Investigate the trend and anomaly score:

   - Notice how, during the last hour, the *PA3* parameter started deviating from the *PA2*.

   - In the *Anomaly score of selected group* graph, notice how the *anomaly score* went up during the last hour.

   The *anomaly score* expresses how strongly the model believes that the relations between the parameters are broken at any given time. The fact that the *anomaly score* exceeded the configured *anomaly threshold* of 3
is what led the system to trigger the RAD event in the Alarm Console in Cube.

   ![Trend and anomaly score graphs](~/dataminer/images/tutorial_RAD_trend_and_anomaly_score.png)

 1. On the top right, click the "Historical anomalies" button to open the Historical Anomalies panel.
   This panel displays all the historical anomalies detected for the selected group in the selected time range.

	![Historical Anomalies panel](~/dataminer/images/tutorial_RAD_Historical_Anomalies_panel.png)

## Step 5: Tweak the advanced configuration

Despite the fact that the algorithm is fully automatic, you can still influence its behavior by tweaking some advanced options.
In this step, you will learn how you can for instance suppress events created as a result of a short maintenance or cleaning operations.

1. In the RAD Manager, create a new group by clicking the *Add Single Group* button in the header bar.

1. In the *Group name* field, enter *PA Maintenance*.

1. Select the *RAD - Commtia LON 2* element this time.

1. As before, select the *Output Power* parameter (optionally filter on `PA*`) and click *Add*.

1. Select the *Tx Amplifier Output Power* parameter, keep the *Display key filter* empty, and click *Add*.

1. As before, select *Override default anomaly threshold* and fill in the value *3*.

1. Select the *Override default minimum anomaly duration (in minutes)* checkbox, but this time fill in the value *000d 00h 20m*.

   This means that the relation should be broken for at least 20 minutes before an event is triggered.

   ![Configuration suppressing short maintenance operations](~/dataminer/images/tutorial_RAD_Maintenance_Configuration.png)

1. Click *Add group*.

1. In Cube, open the *RAD - Commtia LON 2* element.

1. Go to the *Demo Control* page.

1. Make sure *Demo Status* is set to *Ready*.

1. Click the *Simulate Reboot* button.

   This will create a **short** deviation between the *PA2* and *PA3 output power*.

1. Check the Alarm Console: no new relational anomaly should be shown.

## Step 6: Create a shared model group

Typically, you will want to monitor not just one single DAB transmitter but multiple. To accomplish this, you could create a single RAD group for each transmitter, similarly to what we've been doing above.
An often preferred alternative is to create just one RAD group that monitors *multiple* transmitters together using a *shared model*.

Using a shared model comes with its pros and cons. The downside of using one common shared model is that the model is trained on a collection of transmitters, so it is less attuned
to the specific characteristics of each individual transmitter. This might lead to a slightly lower anomaly detection accuracy for each individual transmitter.

On the other hand, a shared model comes with several advantages:
1. you only need to create and maintain one single RAD group instead of multiple ones.
1. the model can learn from a larger dataset (data from multiple transmitters), which can lead to a more robust model that is better at generalizing and detecting anomalies.
1. Your DataMiner system will use less resources because only one model needs to be stored and updated instead of multiple ones.
1. The model can detect which individual transmitters (if any) are behaving differently from their peers. This can help you decide to prioritize maintenance on those transmitters.

In this step, we will explain how to create a *shared model group*.

1. In the header bar of the RAD Manager, click *Add Shared Model Group*.

	The following popup will appear:

   ![Add a shared model group](~/dataminer/images/tutorial_RAD_Add_Shared_Model_Group.png)

1. Set the *Group name* equal to *DAB Fleet*.

1. Set *Number of parameters per subgroup* equal to *4*	.

	As before, we will monitor the *Output Power* of the 3 different power amplifiers and the *Tx Amplifier Output Power*. 

1. To get meaningful names for the parameters, click *Edit Labels...* and assign meaningful names to each of the 4 parameters, for example:
   - PA1 Output Power
   - PA2 Output Power
   - PA3 Output Power
   - Total Tx Amplifier Output Power
  
	Click *OK* to close the labels editor.

	![Give meaningful names to the parameters](~/dataminer/images/tutorial_RAD_Give_Meaningful_Names.png)

1. Click *Add subgroup...* to add our first subgroup. 

	A popup opens where you can configure the parameters for this subgroup.

	We already used the *RAD - Commtia LON 1* and *RAD - Commtia LON 2* elements in the previous steps,
	so we will use the *RAD - Commtia LON 3*, *RAD - Commtia LON 4* and *RAD - Commtia LON 5* elements this time.

	<a name="add-subgroup-steps"></a>

	1. In the *Group name* field, fill in a meaningful name for the subgroup, for example *Commtia LON 3*.
	1. In the row for the *PA1 Output Power*, select the element *RAD - Commtia LON 3*, select the *Output Power* parameter and Display key *PA1*.
	1. Similarly, in the row for the *PA2 Output Power*, select the element *RAD - Commtia LON 3*, select the *Output Power* parameter and Display key *PA2*.
	1. Repeat the same for the *PA3 Output Power* row using the *RAD - Commtia LON 3* element and Display key *PA3*.
	1. Finally, in the *Total Tx Amplifier Output Power* row use the *RAD - Commtia LON 3* element and the *Tx Amplifier Output Power* parameter. Keep the Display Key field empty.
	1. We will not override the default anomaly threshold and minimum anomaly duration for this specific group, so leave these checkboxes unchecked.
	1. Click *OK* to add your first subgroup.

	![Configure the first subgroup](~/dataminer/images/tutorial_RAD_Configure_First_Subgroup.png)

1. Click *Add subgroup...* again to add a second subgroup. Repeat the 7 steps above, but this time use the *RAD - Commtia LON 4* element and name the subgroup *Commtia LON 4*.

1. Click *Add subgroup...* one last time to add the *Commtia LON 5* subgroup, using the element *RAD - Commtia LON 5*.

	The *Subgroups* drop down now contains the three subgroups that we defined. Selecting a subgroup will display its configuration.
1. As in [Step 3](#step-3-configure-your-first-rad-group), we will use Anomaly Threshold *3* and Minimum Anomaly Duration of *5* minutes for this shared model group. We can configure
this value once for the entire shared model group instead of for each subgroup individually.

   1. Select the *Override default anomaly threshold* checkbox and fill in the value *3*.
   1. Select the *Override default minimum anomaly duration (in minutes)* checkbox and fill in the value *000d 00h 05m*.

	> [!NOTE]
	> These settings can be overridden for individual subgroups if needed by clicking *Edit subgroup...*.

	> [!NOTE]
	> By default, the model will be trained on recent data. If instead you want to train the model on specific historical time intervals, you can check *Override default settings for model training*
     and click *Configure model training...*.

1. Click *Apply* to create the shared model group.

	![Shared model group created](~/dataminer/images/tutorial_RAD_Shared_Model_Group_Created.png)

1. Optionally, select the shared model group to explore the subgroups underneath.

1. Test the new configuration in DataMiner Cube:

   1. Go to the *Demo Control* page of say the *RAD - Commtia LON 3* element and click *Add Degradation*.

   1. Check the lightbulb icon in the Alarm Console to check that the relational anomaly was detected.

   1. Check that the anomaly becomes visible in the RAD Manager.

	   If you do not immediately see it, refresh the RAD Manager page in your browser.

   ![Shared model group anomaly detected](~/dataminer/images/tutorial_RAD_Shared_Model_Group_Anomaly_Detected.png)


## Step 7: Using the API to configure RAD groups

In case you have 100 DAB Transmitters, it can be quite tedious to create single RAD groups 
for each of them manually. The creation of a shared model group has a similar problem as you need to add
each subgroup one by one. To solve this, DataMiner provides a RAD API that allows you to create RAD groups programmatically.

Concretely, 2 automation scripts were deployed when you installed the *RAD Demonstrator* package in Step 1 of this tutorial:

1. The *Add Single Groups* script creates *single RAD groups* for all 5 *RAD - Commtia LON* elements.
1. The *Add Shared Model Group* script creates a *shared model RAD group* for all 5 *RAD - Commtia LON* elements

In case you are interested in using RAD on your system, it is recommended to take a look at the scripts.
They seem complicated because of all the boiler plate code, but the only method that you really need to implement yourself
is the *RunSafe(IEngine engine)* method. Feel free to use these scripts as a starting point for later if you decide to configure your own groups.

You can run the scripts as follows:

1. In the RAD Manager, except for the *Fleet-Outlier-Group* group that was created by the catalog package,
   remove the groups you created during this tutorial using the bin icon next to each group name.

	![Remove groups](~/dataminer/images/tutorial_RAD_Remove_Groups.png)

1. In Cube, go to Apps > Automation.
1. Choose your script in the *Automation script > DataMiner Catalog > RAD Demonstrator* folder.

   > [!TIP]
   > This is only one possible example of how you can use the RAD API. If you would like to create your own script to create a custom advanced configuration, refer to [Working with the RAD API](xref:RAD_API).

## Step 8: Play around with the Fleet Outlier Radar
An advantage of using shared model groups is that DataMiner is able to compare these groups with each other and 
detect if certain subgroups behave differently from the others. To illustrate this, our catalog package has created
a shared model group called *Fleet-Outlier-Group*:

1. Open The RAD Manager
1. Find the shared model group called *Fleet-Outlier-Group* and click it.

   This group contains 29 subgroups (DAB Transmitters) of actual data, collected in the field.

1. Scroll through the list and see if you find devices with the *Outlier Group* label.

	![Outlier Groups](~/dataminer/images/tutorial_RAD_OutlierGroups.png)

   If you don't see any groups just yet, it is likely because the algorithm is still waiting for enough real-time data to identify outliers.
   While the shared model group was created during deployment, the detection process relies specifically on live data. Since the output power parameters are polled every five minutes, it may take a little more time to process a sufficient number of data points. We recommend checking back in about an hour, by which time the results should be visible.
1. Select one of the subgroups, e.g. the *AI - RAD - Commtia LON 14*.

	![Outlier group LON 14](~/dataminer/images/tutorial_RAD_OutlierGroup14.png)

	Notice how the *Output Power - pa1* is not equal to the other 2 pa output powers! It indeed seems something is wrong here.

 > [!NOTE]
 > Note that you can order the subgroups based on their *outlier value* using the *Sorting & filtering* button.
 > This will open a popup in which you can *Sort by Is Outlier Group*. The outlier groups now appear on top.
	
## Step 9: Clean up your system

1. In the RAD Manager, remove all the groups you created using the bin icon next to each group name.
1. Delete the elements under the *DataMiner Catalog* > *Using Relational Anomaly Detection* > *London* and *RAD Fleet Outlier* views in Cube.
1. Remove the *AI - Commtia DAB* and the *Fleet-Outlier-Detection-Commtia DAB* protocols under *Apps > Protocols & Templates*.
1. Remove the automation scripts under *Apps > Automation > DataMiner Catalog > RAD Demonstrator*.

In case you would like to repeat some of the exercises, you can instead duplicate the related elements or deploy the *RAD Demonstrator* package a second time, which will overwrite the existing elements.
