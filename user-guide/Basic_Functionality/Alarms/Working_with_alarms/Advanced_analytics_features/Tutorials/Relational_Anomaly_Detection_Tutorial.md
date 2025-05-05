---
uid: Relational_Anomaly_Detection_Tutorial
---

# Working with Relational Anomaly Detection

This tutorial showcases DataMiner's [Relational Anomaly Detection](xref:Relational_anomaly_detection) feature.
Relational Anomaly Detection, or RAD for short, enables you to automatically monitor the relationship between multiple parameters and detect when this relationship is broken.

Estimated duration: 25 minutes.

## Use cases for relational anomaly detection
*Main/Backup Transcoders (Xcoders)*:
monitor output bit rate differences between main and backup transcoders to guard that your backup remains synced with the main.

*Bonded Interfaces*:
spot differences in bit rates across bonded interfaces. This can provide early warnings for failures in the load balancing circuit or for issues with individual interfaces or fibers.

*UPS Management*:
decide on the best time to replace your battery.
Go to [UPS Management Use Case](https://community.dataminer.services/cut-ups-costs-and-prevent-outages-with-ai-powered-monitoring/) for the full use case description.

*Power Amplifiers in DAB Transmitters*:
monitor the power outputs of all amplifiers in a DAB transmitter to ensure they remain in sync. This helps identify faults in the transmitter or the antenna system.

*Monitoring temperatures vs fan speeds*: monitor that the fan speed of a device is in sync with the temperature of the device. This can help identify faults in the cooling system or in the device itself.

*And many more...*

During this tutorial, we will focus on the *Power Amplifiers in DAB Transmitters* use case.

## Introduction

The RAD functionality works in 3 different steps:
- **Specify Parameters:**  The user specifies the parameters that should be monitored together: e.g. a main bit rate and backup bit rate. This can be done using the [RAD Manager](https://aka.dataminer.services/RAD-Manager-Catalog) app or the [RAD API](xref:RAD_API).
- **Let the algorithm learn the relations:**  The system learns the relations between the parameters: e.g. it learns that main and backup are typically equal. This is done automatically by the system, but you can manually specify a training range.
- **Observe the events that are triggered:**  When the system detects that the relations between the parameters is broken (e.g. the main is no longer equal to the backup), 
an event appears in the [Alarm Console](xref:Working_with_the_Alarm_Console).
 
![The 3 steps of the RAD algorithm](~/user-guide/images/tutorial_RAD_Overview_Algorithm.jpg)

As the 2 latter steps are completely automatic, this tutorial focuses on the *Specify Parameters* step.

## Prerequisites

- DataMiner 10.5.4 or higher with [Storage as a Service (STaaS)](xref:STaaS) (recommended) or a [self-managed Cassandra-compatible database and indexing database](xref:Supported_system_data_storage_architectures).

- Relational Anomaly Detection is enabled (in DataMiner Cube: *System Center* > *System settings* > *analytics config*).

- The RAD Manager app is deployed. You can find it in the DataMiner Catalog by searching for "RAD Manager" or by clicking <https://aka.dataminer.services/RAD-Manager-Catalog>.

The content and screenshots for this tutorial have been created in DataMiner 10.5.4.


## Overview

The tutorial consists of the following steps:

- [Step 1: Install the example package from the Catalog](#step-1-install-the-example-package-from-the-catalog)

- [Step 2: Install the RAD Manager from the Catalog](#step-2-install-the-rad-manager-from-the-catalog)

- [Step 3: Introducing the use case: exploring a DAB Transmitter](#step-3-introducing-the-use-case-exploring-a-dab-transmitter)

- [Step 4: Configuring our first RAD Group](#step-4-configuring-our-first-rad-group)

- [Step 5: Create a problem and verify that RAD detects it](#step-5-create-a-problem-and-verify-that-rad-detects-it)

- [Step 6: Advanced Configurations](#step-6-advanced-configurations)

- [Step 7: Configure monitoring on devices with the same connector](#step-7-configure-monitoring-on-devices-with-the-same-connector)

- [Step 8: Don't touch my stuff!](#step-8-dont-touch-my-stuff)

- [Step 9: Clean up your system](#step-9-clean-up-your-system)

## Step 1: Install the example package from the Catalog

1. Go to the [RAD Demonstrator catalog Package](https://catalog.dataminer.services/details/eeedd709-d681-448d-9a1e-2e5fbfd73740)

1. Deploy the catalog item to your DataMiner Agent by clicking the *Deploy* button.

   This will create an automation script called "Don't touch my stuff" in the Cube Automation app: it will be placed in the *DataMiner Catalog > RAD Demonstrator* folder.
 
    It will also create the following DataMiner elements: "RAD - Commtia LON 1", "RAD - Commtia LON 2", "RAD - Commtia LON 3", and "RAD - Commtia STH 1". You can find these elements in the Cube surveyor under the *DataMiner Catalog* > *Using Relational Anomaly Detection* view.

## Step 2: Install the RAD Manager from the Catalog

1. You can find the RAD Manager in the DataMiner Catalog by searching for "RAD Manager" or by simply clicking [RAD Manager](https://aka.dataminer.services/RAD-Manager-Catalog).

1. Deploy and Access the RAD Manager by following the steps on the picture below.

![Deploying and accessing the RAD Manager](~/user-guide/images/tutorial_RAD_Deploy_RAD_Manager.png)

## Step 3: Introducing the use case: exploring a DAB Transmitter

Our Catalog package has created a number of dummy DAB Transmitter elements in your system. 
1. In the Surveyor, open the element *RAD - Commtia LON 1*, located under the *DataMiner Catalog > Using Relational Anomaly Detection*  view.
1. Click the dropdown icon next to the *Amplifier* page and select *PAs*.
   
    This page provides information about the different PAs or power amplifiers in the DAB transmitter.
1. In the *PAs* Measurements table, look at the *Output Power* column. 
   All three power amplifiers should have similar output power values.

   ![Output Power](~/user-guide/images/tutorial_RAD_Output_Powers.jpg)

1. Next, go to the main *Amplifier* page and look at the *Tx Amplifier Output Power* parameter.  
    Up to some losses, this should be equal to the sum of the previously mentioned output power values.

   ![Total Output Power](~/user-guide/images/tutorial_RAD_Total_Output_Power.jpg)

During this tutorial, we will focus on the fact that the output powers of the different amplifiers in the DAB transmitter should be more or less equal
and that their sum should be equal to the total output power up to some losses.
In the next step, we will configure RAD to monitor these relations.

## Step 4: Configuring our first RAD Group    

1. Go to the RAD Manager App.
1. At the top left, click "Add Group".

    A popup will appear where you can configure the group.
    ![Add a group](~/user-guide/images/tutorial_RAD_AddGroup.jpg)
1. As the *Group name*, fill in *PA's unbalanced*. 

      It is best to give the group a meaningful name as the name will appear as part of the event that is triggered when the relation between the output powers is broken.

1. Under element, select *RAD - Commtia LON 1*.
1. Select *Output Power* under *Parameter*. Under *Display key filter*, type *PA**. Click Add.

   This informs DataMiner that we want to monitor the *Output Powers* of *PA1, PA2* and *PA3* together.
1. Select *Tx Amplifier Output Power* under *Parameter*. Keep the *Display key filter* empty and click Add.
1. Finally, click *Add group* to create the group.
    
    The top table in the RAD Manager should display the group that was just created.
   ![Add a group](~/user-guide/images/tutorial_RAD_groupOverview.jpg)


## Step 5: Create a problem and verify that RAD detects it

1. In Cube, open the *RAD - Commtia LON 1* element.
1. Go to the *Demo Control* page.
1. Make sure *Demo Status* is set to *Ready*.

    When the element was created, it pushed some historical trend data to the database. This data is used by the algorithm to learn the relations between the parameters. The demo status will be set to *Ready* as soon as the history data is processed. This whole process should take about 5 minutes.
1. Click the *Add Degradation* button. 

    This will cause the *Output Power* of *PA3* to start deviating from the output powers of the other two amplifiers.
1. Click the lightbulb icon on the top right of the alarm console and select the item referring to *relational anomalies*.

    You will see an event informing you that the relation between the *Output Powers* of the amplifiers and the *Tx Amplifier Output Power* is broken.
    ![Detected Relational Anomaly](~/user-guide/images/tutorial_RAD_Detected_Anomaly.jpg)  
1. In the RAD Manager App, select the group you created.

    This will populate the *Group Information* table with the parameters included in your group.
1. Select the *PA2* and *PA3 Output Power* parameters and investigate the trend and anomaly score:
    -notice how, during the last hour, the *PA3* parameter started deviating from the *PA2*.
   
    -on the *Inspect the anomaly score of your group* graph, notice how the *anomaly score* went up during the last hour.
    The *anomaly score* expresses how strongly the model believes that the relations between the parameters are broken at any given time. The increase in the anomaly score is what led the system to trigger the RAD event in the alarm console.
## Step 6: Advanced Configurations

Despite the fact that the algorithm is fully automatic, you can still influence its behavior by doing some advanced configurations.
Let's dive deeper into the advanced configurations of the RAD Manager and learn how we can suppress events created as a result of a short maintenance or cleaning operations.

1. In the RAD Manager, create a new group by clicking the *Add Group* button.

    Note that the pop-up shows three checkboxes.    
    - Checking the *Update model on new data* checkbox means that the model will be updated when new data is available.
    This is useful when monitoring parameters that you would like to see changing over time: the model can then adapt to this new behavior. The idea is 
    that only more pronounced breaks in relations will be detected. If your relation is static (e.g. 2 parameters that should remain equal, forever), it is best to keep this checkbox unchecked.
    - The "Override default anomaly threshold" allows you to make the algorithm more sensitive (lower value) or less sensitive (higher value) to anomalies. The default value is 3.
    - Finally, the *Override default minimum anomaly duration* is a setting similar to [Alarm hysteresis](xref:Alarm_hysteresis). It allows you to specify how long the relation should be broken before an event is triggered. The default value is 5 minutes.

1. In the *Group name* field, enter *PA Maintenance*.
1. Select the *RAD - Commtia LON 2* element this time.
1. As before, select the *Output Power* parameter and filter on *PA**. Click *Add*.
1. Select the *Tx Amplifier Output Power* parameter and keep the *Display key filter* empty. Click *Add*.
1. Select the *Override default minimum anomaly duration* checkbox and fill in the value *15*.
   This means that the relation should be broken for at least 15 minutes before an event is triggered. It should look like this
    ![Configuration suppressing short maintenance operations](~/user-guide/images/tutorial_RAD_Maintenance_Configuration.jpg)
1. Click Add group.
1. In Cube, open the *RAD - Commtia LON 2* element.
1. Go to the *Demo Control* page.
1. Make sure *Demo Status* is set to *Ready*.
1. Click the *Simulate Reboot* button.  
This will create a **short** deviation between the *PA2* and *PA3 output power*.
1. Notice that no new Relational Anomaly appears in the alarm console.

## Step 7: Configure monitoring on devices with the same connector.
Typically, operators are not just monitoring one single DAB Transmitter, but multiple. It would not be ideal to configure RAD for each transmitter separately.
In this step, we will show you how to configure monitoring on all devices with the same connector.

1. In the RAD Manager, start by removing the two previously created groups by selecting them and clicking the *Remove Group* button.
1. Click the *Add Group* button.
1. In the pop-up, in the *What to add?* menu, select *Add group for each element with given connector*.
1. Set the *Group name prefix* equal to *DAB Fleet*.
1. In the *Connector* field, select *Empower 2025 - AI - Commtia DAB*.
1. As before, select the *Output Power* parameter and filter on *PA**. Click *Add*.
1. Select the *Tx Amplifier Output Power* parameter and keep the *Display key filter* empty. Click *Add*.
1. Click the *Add group* button.
    
    This will create a group for each element with the selected connector. In this case, it will create groups for *RAD - Commtia LON 1*, *RAD - Commtia LON 2*, *RAD - Commtia LON 3* and *RAD - Commtia STH 1*.
1. Take a screen shot of the 4 newly created groups in the RAD Manager. Upload it later to collect devops points!
1. Optionally, in Cube: click *Add Degradation* in the *Demo Control* page of the *RAD - Commtia STH 1* element to verify that DataMiner picks up on the relational anomaly. Leave the *RAD - Commtia LON 3* element alone for a later exercise.

## Step 8: Don't touch my stuff!
Using the RAD API, you can fully tailor the RAD functionality to your needs. For example, what if you would like to configure RAD to monitor your DAB transmitters, but only those in Southampton
(because maybe a different team is responsible for those in London). Let us show you how to do this using the RAD API.

1. In the RAD Manager, remove all the groups you created in the previous step by selecting them and clicking the *Remove Group* button.
1. In Cube, open the *Automation App*.
1. Select the *Don't touch my stuff* automation script in the *Automation script > DataMiner Catalog > RAD Demonstrator* folder.
   
    Notice how the code creates RAD groups for all DAB Transmitters containing *STH* (short for Southampton) as part of their name.
    If your naming conventions do not contain the location, you could add location info to the elements using element properties, manually or by using [IDP](xref:SolIDP).
1. Run the automation script.
1. In Cube, click *Add Degradation* in the *Demo Control* page of the *RAD - Commtia LON 3* element. 
1. Notice that no new relational anomaly appears in the alarm console as the script only configured RAD for the DAB Transmitters situated in Southampton.

## Step 9: Optionally, clean up your system

1. In the RAD Manager, remove all the groups you created in the previous step by selecting them and clicking the *Remove Group* button.
1. In case you would like to repeat some of the exercises, you can duplicate the related elements 
or deploy the *RAD Demonstrator* catalog package a second time. It will overwrite the existing elements.

