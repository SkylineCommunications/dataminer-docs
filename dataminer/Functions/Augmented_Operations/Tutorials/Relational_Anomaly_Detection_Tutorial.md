---
uid: Relational_Anomaly_Detection_Tutorial
---

# Working with relational anomaly detection

This tutorial showcases DataMiner's [relational anomaly detection (RAD)](xref:Relational_anomaly_detection) feature. It show how you can use this feature to monitor the power outputs of all power amplifiers in a DAB transmitter to ensure they remain in sync. You will first need to specify the parameters that should be monitored together, and then the algorithm will automatically detect the relations between the parameters and generate suggestion events in the Alarm Console when it detects that these relations are broken.

Estimated duration: 35 minutes.

> [!NOTE]
> The content and screenshots for this tutorial have been created with DataMiner 10.6.1 and RAD Manager version 4.0.0.

## Prerequisites

- A DataMiner System [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

- DataMiner 10.6.0/10.6.1 or higher with [Storage as a Service (STaaS)](xref:STaaS) (recommended) or a [self-managed Cassandra-compatible database and indexing database](xref:Supported_system_data_storage_architectures).

- Relational Anomaly Detection is enabled (in DataMiner Cube: *System Center* > *System settings* > *analytics config*).

## Overview

The tutorial consists of the following steps:

- [Step 1: Install the example package from the Catalog](#step-1-install-the-necessary-packages-from-the-catalog)
- [Step 2: Check the DAB transmitter elements in Cube](#step-2-check-the-dab-transmitter-elements-in-cube)
- [Step 3: Configure your first RAD group](#step-3-configure-your-first-rad-group)
- [Step 4: Create a problem and verify if RAD detects it](#step-4-create-a-problem-and-verify-if-rad-detects-it)
- [Step 5: Tweak the advanced configuration](#step-5-tweak-the-advanced-configuration)
- [Step 6: Create a shared model group](#step-6-create-a-shared-model-group)
- [Step 7: Use the API to configure RAD groups](#step-7-use-the-api-to-configure-rad-groups)
- [Step 8: Play around with the Fleet Outlier Radar](#step-8-play-around-with-the-fleet-outlier-radar)
- [Step 9: Clean up your system](#step-9-clean-up-your-system)

## Step 1: Install the necessary packages from the Catalog

1. Go to the [RAD Demonstrator](https://catalog.dataminer.services/details/eeedd709-d681-448d-9a1e-2e5fbfd73740) package in the Catalog.

1. [Deploy the package](xref:Deploying_a_catalog_item) to your DataMiner Agent by clicking the *Deploy* button.

   This will create two automation scripts, which you can find in the folder *DataMiner Catalog* > *RAD Demonstrator* in the Automation module:

   - *Add Shared Model Group*
   - *Add Single Groups*

   The package will also create the following DataMiner elements in the Cube Surveyor under *DataMiner Catalog* > *Using Relational Anomaly Detection* > *London*:

   - RAD - Commtia LON 1
   - RAD - Commtia LON 2
   - RAD - Commtia LON 3
   - RAD - Commtia LON 4
   - RAD - Commtia LON 5

   Finally, it will create 13 additional elements, *Fleet-Outlier-Detection-Commtia 01*, *Fleet-Outlier-Detection-Commtia 02*, etc. up to *Fleet-Outlier-Detection-Commtia 13*, in the Cube Surveyor under *DataMiner Catalog* > *Using Relational Anomaly Detection* > *RAD Fleet Outlier*.

1. Go to the [RAD Manager](https://aka.dataminer.services/RAD-Manager-Catalog) package in the DataMiner Catalog and [deploy it](xref:Deploying_a_catalog_item).

1. Go to the root page of your DataMiner System, for example by clicking the *Home* button for your DMS on the [dataminer.services page](https://dataminer.services/), and check if you can see the *RAD Manager* app.

   ![RAD Manager icon on the root page](~/dataminer/images/RAD_Manager_on_root_page.png)

1. Open the *RAD Manager* app.

   The RAD Manager provides an overview of all the RAD groups that are configured on your system. If you have not configured any groups yet, this list will be empty. In this tutorial, you will learn how to create and configure several RAD groups using this application.

   ![RAD Manager first glance](~/dataminer/images/tutorial_RAD_Manager_First_Glance.png)

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

1. On the left side of the header bar, click *Add Single Group*.

   This will open a window where you can configure a new parameter group.

   ![Add a group](~/dataminer/images/tutorial_RAD_AddGroup.png)

1. As the *Group name*, fill in *PAs unbalanced*.

   Parameter groups should be given a meaningful name, because this name will be shown as part of the event that is triggered when the relation between the parameters is broken.

1. Add a first parameter:

   1. In the *Element* box, select *RAD - Commtia LON 1*.

   1. Make sure the *Output Power* parameter is selected.

   1. Under *Display key filter*, specify `PA*`.

      Note that as the group will be used to monitor *all* available power amplifiers, you could actually also leave this field empty.

   1. Click *Add*.

   This informs DataMiner that you want to monitor the *Output Power* of *PA1*, *PA2*, and *PA3* together.

1. Add a second parameter:

   1. Keep the *RAD - Commtia LON 1* element selected.

   1. Select the *Tx Amplifier Output Power* parameter.

   1. Keep the *Display key filter* empty.

   1. Click *Add*.

1. Override the default anomaly threshold:

   1. Select the *Override default anomaly threshold* checkbox

   1. Fill in *3* in the box next to the checkbox.

   This will make DataMiner more sensitive to deviations in the relations between the parameters. By default, an event will only be triggered when the "anomaly score" exceeds 6, but in this example the deviation of the parameters will be too small to lead to such a high anomaly score.

1. Override the default minimum anomaly duration:

   1. Select the *Override default minimum anomaly duration (in minutes)* checkbox.

   1. Fill in the value *000d 00h 05m* in the box next to the checkbox.

   This will make sure that DataMiner also detects short anomalies, when the relation is broken for only 5 minutes. By default, DataMiner will only trigger an event if the relation is broken for at least 15 minutes.

1. Click *Add group* to create the group.

The group entitled *PAs unbalanced* will now be created and shown in the RAD Manager.

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
   > Note the red icon on the *PAs unbalanced* group, indicating there was an anomaly. If you do not see this icon yet, refresh the *RAD Manager* page in your browser.

1. On the trend graph component on the right, click the *<* button to display the list of parameters in the group, and click the *Output Power - pa1* and *Tx Amplifier Output Power* to remove them from the graph.

1. Above the graph, select the time range covering the last 24 hours.

   This will give you a better view of the parameter trends before and after you created the degradation.

1. Investigate the trend and anomaly score:

   - Notice how, during the last hour, the *PA3* parameter started deviating from the *PA2*.

   - In the *Anomaly score of selected group* graph, notice how the anomaly score went up during the last hour.

   The anomaly score expresses how strongly the model believes that the relations between the parameters are broken at any given time. The fact that the anomaly score exceeded the configured anomaly threshold of 3 is what led the system to trigger the RAD event in the Alarm Console in Cube.

   ![Trend and anomaly score graphs](~/dataminer/images/tutorial_RAD_trend_and_anomaly_score.png)

1. In the top-right corner, click the *Historical anomalies* button.

   This will open a panel that displays all the historical anomalies detected for the selected group in the selected time range.

   ![Historical Anomalies panel](~/dataminer/images/tutorial_RAD_Historical_Anomalies_panel.png)

## Step 5: Tweak the advanced configuration

Despite the fact that the algorithm is fully automatic, you can still influence its behavior by tweaking some advanced options.
In this step, you will learn how you can for instance suppress events created as a result of a short maintenance or cleaning operations.

1. In the RAD Manager, create a new group by clicking the *Add Single Group* button in the header bar.

1. In the *Group name* field, enter *PA Maintenance*.

1. Select the *RAD - Commtia LON 2* element this time.

1. As before, select the *Output Power* parameter,optionally filter on `PA*`, and click *Add*.

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

Typically, you will want to monitor not just one single DAB transmitter but multiple transmitters. To accomplish this, you could create a single RAD group for each transmitter, similarly to what you have done above. However, an often preferred alternative is to create just one RAD group that monitors multiple transmitters together using a shared model.

On the one hand, the downside of using one common shared model is that the model is trained on a collection of transmitters, so it is less attuned to the specific characteristics of each individual transmitter. This might lead to a slightly lower anomaly detection accuracy for each individual transmitter.

On the other hand, a shared model comes with several advantages:

1. You only need to create and maintain one single RAD group instead of multiple ones.

1. The model can learn from a larger dataset (data from multiple transmitters), which can lead to a more robust model that is better at generalizing and detecting anomalies.

1. Your DataMiner System will use less resources because only one model needs to be stored and updated instead of multiple ones.

1. The model can detect which individual transmitters (if any) are behaving differently from their peers. This can help you decide to prioritize maintenance on those transmitters.

In this step, you will learn how to create a shared model group.

1. In the header bar of the RAD Manager, click *Add Shared Model Group*.

   This will open the following window:

   ![Add a shared model group](~/dataminer/images/tutorial_RAD_Add_Shared_Model_Group.png)

1. Set the *Group name* equal to *DAB Fleet*.

1. Set *Number of parameters per subgroup* to *4*.

   The group will monitor the *Output Power* of the three different power amplifiers and the *Tx Amplifier Output Power*.

1. To get meaningful names for the parameters, click *Edit Labels* and assign meaningful names to each of the parameters, for example:

   - PA1 Output Power
   - PA2 Output Power
   - PA3 Output Power
   - Total Tx Amplifier Output Power

   Click *OK* to close the labels editor.

   ![Give meaningful names to the parameters](~/dataminer/images/tutorial_RAD_Give_Meaningful_Names.png)

1. Click *Add subgroup* to add a first subgroup.

   This will open a window where you can configure the parameters for this subgroup, which this time will be from the *RAD - Commtia LON 3*, *RAD - Commtia LON 4*, and *RAD - Commtia LON 5* elements:

   1. In the *Group name* field, fill in a meaningful name for the subgroup, for example *Commtia LON 3*.

   1. In the row for the each *Output Power* parameter, select the element *RAD - Commtia LON 3*, select the *Output Power* parameter, and select the corresponding display key (for example, *PA1* for the parameter *PA1 Output Power*).

   1. In the *Total Tx Amplifier Output Power* row, use the *RAD - Commtia LON 3* element and the *Tx Amplifier Output Power* parameter.

   1. Leave the default anomaly threshold and minimum anomaly duration checkboxes unselected, so these are not overridden for this group.

   1. Click *OK* to add the subgroup.

   ![Configure the first subgroup](~/dataminer/images/tutorial_RAD_Configure_First_Subgroup.png)

1. Click *Add subgroup* again to add a second subgroup, repeating the steps above, but this time with the *RAD - Commtia LON 4* element and the subgroup name *Commtia LON 4*.

1. Click *Add subgroup* one last time to add the *Commtia LON 5* subgroup, using the element *RAD - Commtia LON 5*.

   The *Subgroups* dropdown will now contain the three subgroups you have defined. Selecting a subgroup will display its configuration.

1. As in [Step 3](#step-3-configure-your-first-rad-group), configure your RAD group with an anomaly threshold of *3* and minimum anomaly duration of *5* minutes.

   As these settings are the same for each subgroup, you can configure the settings on the shared model group level. If necessary, it is possible to override settings for individual subgroups via the *Edit subgroup* button.

1. Click *Apply* to create the shared model group.

   ![Shared model group created](~/dataminer/images/tutorial_RAD_Shared_Model_Group_Created.png)

1. Optionally, select the shared model group to explore the subgroups underneath.

1. Test the new configuration in DataMiner Cube:

   1. Go to the *Demo Control* page of say the *RAD - Commtia LON 3* element and click *Add Degradation*.

   1. Check the lightbulb icon in the Alarm Console to check that the relational anomaly was detected.

   1. Check if the anomaly becomes visible in the RAD Manager.

      If you do not immediately see it, refresh the RAD Manager page in your browser.

   ![Shared model group anomaly detected](~/dataminer/images/tutorial_RAD_Shared_Model_Group_Anomaly_Detected.png)

## Step 7: Use the API to configure RAD groups

In case you have 100 DAB transmitters, it can be quite tedious to create single RAD groups for each of them manually. The creation of a shared model group has a similar problem as you need to add each subgroup one by one. To solve this, DataMiner provides a RAD API that allows you to create RAD groups programmatically.

In [step 1](#step-1-install-the-necessary-packages-from-the-catalog) of this tutorial, two scripts were deployed that can be used for this:

- The *Add Single Groups* script creates *single RAD groups* for all five *RAD - Commtia LON* elements.

- The *Add Shared Model Group* script creates a *shared model RAD group* for all five *RAD - Commtia LON* elements

If you are interested in using RAD on your system, these scripts can be a useful example. They may seem complicated because of all the boiler plate code, but the only method that you really need to implement yourself is the *RunSafe(IEngine engine)* method. Feel free to use these scripts as a starting point for later if you decide to configure your own groups.

You can run the scripts as follows:

1. In the RAD Manager app, remove the groups you created during this tutorial using the garbage can icon next to each group name.

   ![Remove groups](~/dataminer/images/tutorial_RAD_Remove_Groups.png)

1. In Cube, go to *Apps* > *Automation*.

1. Select the script of your choice in the *Automation script > DataMiner Catalog > RAD Demonstrator* folder.

> [!TIP]
> This is only one possible example of how you can use the RAD API. To create your own script to create a custom advanced configuration, refer to [Working with the RAD API](xref:RAD_API).

## Step 8: Play around with the Fleet Outlier Radar

Shared model groups allow DataMiner to compare subgroups and identify when certain subgroups behave differently from the rest. To demonstrate this, use the *Add Fleet Outlier Detection Group* script to create a shared model group containing a larger number of subgroups.

1. In the *Automation* module, go to the *Automation Scripts* > *DataMiner Catalog* > *RAD Demonstrator* folder, select the *Add Fleet Outlier Detection Group* script, and execute it.

   A new RAD group named *Fleet-Outlier-Group* is created on your system.

   > [!NOTE]
   > It may take a short while for the group to be created and for all analysis results to become available. If the group or its results are not immediately visible, wait a moment and refresh the view if necessary.

1. In the RAD Manager app, select this new shared model group.

   In the pane on the left, the group's subgroups (DAB transmitters) become visible. The group contains 13 subgroups with actual data collected in the field.

1. Scroll through the list and see if you find devices with the *Outlier Group* label.

   ![Outlier Groups](~/dataminer/images/tutorial_RAD_OutlierGroups.png)

   To quickly find a group with this label, you can use the *Sorting & filtering* button and select to sort by *Is Outlier Group*.

1. Select one of the subgroups. For example, in the outlier group shown below, the *Output Power – PA1* differs from the other two PA output power values. This may indicate an issue.

   ![Outlier group LON 14](~/dataminer/images/tutorial_RAD_OutlierGroup14.png)

   In another outlier group, the *Total Tx Amplifier Output Power* deviates more than usual from the sum of the output power values of the three individual power amplifiers.

## Step 9: Clean up your system

1. In the RAD Manager, remove all the groups you created using the garbage can icon next to each group name.

1. Delete the elements under the *DataMiner Catalog* > *Using Relational Anomaly Detection* > *London* and *RAD Fleet Outlier* views in Cube.

1. Remove the *AI - Commtia DAB* and the *Fleet-Outlier-Detection-Commtia DAB* protocols under *Apps > Protocols & Templates*.

1. Remove the automation scripts under *Apps* > *Automation* > *DataMiner Catalog* > *RAD Demonstrator*.

In case you would like to repeat some of the exercises, you can instead duplicate the related elements or deploy the *RAD Demonstrator* package a second time, which will overwrite the existing elements.
