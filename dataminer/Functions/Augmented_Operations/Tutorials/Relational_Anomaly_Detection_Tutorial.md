---
uid: Relational_Anomaly_Detection_Tutorial
---

# Working with relational anomaly detection

This tutorial showcases DataMiner's [relational anomaly detection (RAD)](xref:Relational_anomaly_detection) feature. It show how you can use this feature to monitor the power outputs of all amplifiers in a DAB transmitter to ensure they remain in sync. You will first need to specify the parameters that should be monitored together, and then the algorithm will automatically detect the relations between the parameters and generate suggestion events in the Alarm Console when it detects that these relations are broken.

Estimated duration: 25 minutes.

> [!NOTE]
> The content and screenshots for this tutorial have been created with DataMiner 10.5.11 and RAD Manager version 3.1.1.

## Prerequisites

- A DataMiner System [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

- DataMiner 10.5.7 or higher with [Storage as a Service (STaaS)](xref:STaaS) (recommended) or a [self-managed Cassandra-compatible database and indexing database](xref:Supported_system_data_storage_architectures).

- Relational Anomaly Detection is enabled (in DataMiner Cube: *System Center* > *System settings* > *analytics config*).

## Overview

The tutorial consists of the following steps:

- [Step 1: Install the example package from the Catalog](#step-1-install-the-necessary-packages-from-the-catalog)
- [Step 2: Check the DAB transmitter elements in Cube](#step-2-check-the-dab-transmitter-elements-in-cube)
- [Step 3: Configure your first RAD group](#step-3-configure-your-first-rad-group)
- [Step 4: Create a problem and verify if RAD detects it](#step-4-create-a-problem-and-verify-if-rad-detects-it)
- [Step 5: Tweak the advanced configuration](#step-5-tweak-the-advanced-configuration)
- [Step 6: Configure monitoring on devices with the same connector](#step-6-configure-monitoring-on-devices-with-the-same-connector)
- [Step 7: Configure RAD groups with the API via a script](#step-7-configure-rad-groups-with-the-api-via-a-script)
- [Step 8: Clean up your system](#step-8-clean-up-your-system)

## Step 1: Install the necessary packages from the Catalog

1. Go to the [RAD Demonstrator](https://catalog.dataminer.services/details/eeedd709-d681-448d-9a1e-2e5fbfd73740) package in the Catalog.

1. [Deploy the package](xref:Deploying_a_catalog_item) to your DataMiner Agent by clicking the *Deploy* button.

   This will create an Automation script called *Don't touch my stuff* in the Automation module, in the *DataMiner Catalog > RAD Demonstrator* folder.

   It will also create the following DataMiner elements:

   - RAD - Commtia LON 1
   - RAD - Commtia LON 2
   - RAD - Commtia LON 3
   - RAD - Commtia STH 1

   You can find these elements in the Cube Surveyor under *DataMiner Catalog* > *Using Relational Anomaly Detection*.

1. Go to the [RAD Manager](https://aka.dataminer.services/RAD-Manager-Catalog) package in the DataMiner Catalog and [deploy it](xref:Deploying_a_catalog_item).

1. Go to the root page of your DataMiner System, for example by clicking the *Home* button for your DMS on the [dataminer.services page](https://dataminer.services/), and check if you can see the *RAD Manager* app.

   ![RAD Manager icon on the root page](~/dataminer/images/RAD_Manager_on_root_page.png)

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

1. On the left side of the header bar, click *Add Group*.

   This will open a window where you can configure a new parameter group.

   ![Add a group](~/dataminer/images/tutorial_RAD_AddGroup.png)

1. As the *Group name*, fill in *PAs unbalanced*.

   Parameter groups should be given a meaningful name, because this name will be shown as part of the event that is triggered when the relation between the parameters is broken.

1. Add a first parameter:

   1. In the *Element* box, select *RAD - Commtia LON 1*.

   1. Make sure the *Output Power* parameter is selected.

   1. Under *Display key filter*, specify `PA*`.

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

   This will make DataMiner more sensitive to deviations in the relations between the parameters. By default, an event will only be triggered when the anomaly score exceeds 6, but in this example the deviation of the parameters will be too small to lead to such a high anomaly score.

1. Override the default minimum anomaly duration:

   1. Select the *Override default minimum anomaly duration* checkbox.

   1. Fill in the value *00:05* in field next to *Minimum anomaly duration (in minutes)*.

   This will make sure that DataMiner also detects short anomalies, when the relation is broken for only 5 minutes. By default, DataMiner will only trigger an event if the relation is broken for at least 15 minutes.

1. Click *Add group* to create the group.

The top table in the RAD Manager app should now display the group you have created.

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

   The *Parameters in the selected group* table will now display the parameters included in your group.

1. In the *Parameters in the selected group* table, select both the *PA2* and *PA3 Output Power* parameters by keeping Ctrl pressed when you click them.

1. Below the table, investigate the trend and anomaly score:

   - Notice how, during the last hour, the *PA3* parameter started deviating from the *PA2*.

   - In the *Inspect the anomaly score of your group* graph, notice how the *anomaly score* went up during the last hour.

   The *anomaly score* expresses how strongly the model believes that the relations between the parameters are broken at any given time. The increase in the anomaly score is what led the system to trigger the RAD event in the Alarm Console.

   ![Trend and anomaly score graphs](~/dataminer/images/tutorial_RAD_trend_and_anomaly_score.png)

## Step 5: Tweak the advanced configuration

Despite the fact that the algorithm is fully automatic, you can still influence its behavior by tweaking some advanced options.
In this step, you will learn how you can for instance suppress events created as a result of a short maintenance or cleaning operations.

1. In the RAD Manager, create a new group by clicking the *Add Group* button in the header bar.

1. In the *Group name* field, enter *PA Maintenance*.

1. Select the *RAD - Commtia LON 2* element this time.

1. As before, select the *Output Power* parameter, filter on `PA*`, and click *Add*.

1. Select the *Tx Amplifier Output Power* parameter, keep the *Display key filter* empty, and click *Add*.

1. Select the *Override default minimum anomaly duration* checkbox and fill in the value *20*.

   This means that the relation should be broken for at least 20 minutes before an event is triggered.

   ![Configuration suppressing short maintenance operations](~/dataminer/images/tutorial_RAD_Maintenance_Configuration.png)

1. Click *Add group*.

1. In Cube, open the *RAD - Commtia LON 2* element.

1. Go to the *Demo Control* page.

1. Make sure *Demo Status* is set to *Ready*.

1. Click the *Simulate Reboot* button.

   This will create a **short** deviation between the *PA2* and *PA3 output power*.

1. Check the Alarm Console: no new relational anomaly should be shown.

## Step 6: Configure monitoring on devices with the same connector

Typically, you will monitor not just one single DAB transmitter but multiple, and ideally you should not configure RAD for each transmitter separately. In this step, you will learn how to configure monitoring on all devices with the same connector.

1. In the RAD Manager, remove the two groups you created earlier:

   1. Select the groups in the table at the top while keeping Ctrl pressed.

   1. In the header bar, click *Remove Group*, and then confirm.

1. In the header bar, click *Add Group*.

1. In the *What to add?* box at the top, select *Add group for each element with given connector*.

1. Set the *Group name prefix* to *DAB Fleet*.

1. In the *Connector* field, select *Empower 2025 - AI - Commtia DAB*.

1. As before, select the *Output Power* parameter, filter on `PA*`, and click *Add*.

1. Select the *Tx Amplifier Output Power* parameter, keep the *Display key filter* empty, and click *Add*.

1. Select the *Override default anomaly threshold* checkbox and fill in the value *3*.

1. Select the *Override default minimum anomaly duration* checkbox and fill in the value *5*.

1. Click *Add group(s)*.

   This will create a group for each element with the selected connector. In this case, it will create groups for *RAD - Commtia LON 1*, *RAD - Commtia LON 2*, *RAD - Commtia LON 3*, and *RAD - Commtia STH 1*.

   ![The resulting groups](~/dataminer/images/tutorial_RAD_Resulting_groups.png)

1. Optionally, test the new configuration in DataMiner Cube:

   1. Go to the *Demo Control* page of the *RAD - Commtia STH 1* element and click *Add Degradation*.

   1. Check the lightbulb icon in the Alarm Console to see if the relational anomaly was detected.

## Step 7: Configure RAD groups with the API via a script

Using the RAD API, you can fully tailor the RAD functionality to your needs. For example, you can configure RAD to monitor only the DAB transmitters in Southampton, for instance because a different team is responsible for those in London. In this step, you will learn how to do this using the RAD API.

1. In the RAD Manager, remove all the groups you created in the previous step like before.

1. In the Cube sidebar, go to *Apps* > *Automation*.

1. in the *Automation script > DataMiner Catalog > RAD Demonstrator* folder, select the *Don't touch my stuff* Automation script.

1. Run the Automation script.

   This script will create RAD groups for all DAB transmitters containing *STH* (short for Southampton) as part of their name.

   ![The resulting groups](~/dataminer/images/tutorial_RAD_Resulting_groups_API.png)

   > [!TIP]
   > This is only one possible example of how you can use the RAD API. If you would like to create your own script to create a custom advanced configuration, refer to [Working with the RAD API](xref:RAD_API).

## Step 8: Clean up your system

In the RAD Manager, remove all the groups you created in the previous step by selecting them and clicking the *Remove Group* button.

In case you would like to repeat some of the exercises, you can duplicate the related elements or deploy the *RAD Demonstrator* package a second time, which will overwrite the existing elements.
