---
uid: Getting_started_with_alarm_templates
---

# Getting started with alarm templates

This tutorial explains how to get started with alarm templates.

Expected duration: 15 minutes

> [!TIP]
> See also: [Kata #34: Master alarm templates](https://community.dataminer.services/courses/kata-34/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

## Prerequisites

A DataMiner System that is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

> [!TIP]
> A [new DataMiner as a Service](xref:Creating_a_DMS_on_dataminer_services) system comes with a cloud connection out of the box, so it automatically meets this requirement.

## Overview

- [Step 1: Deploy the simulation element](#step-1-deploy-the-simulation-element)
- [Step 2: Alarm on a parameter using normal thresholds](#step-2-alarm-on-a-parameter-using-normal-thresholds)
- [Step 3: Define hysteresis](#step-3-define-hysteresis)
- [Step 4: Alarm on a parameter using rate thresholds](#step-4-alarm-on-a-parameter-using-rate-thresholds)
- [Step 5: Alarm on a parameter using relative thresholds](#step-5-alarm-on-a-parameter-using-relative-thresholds)
- [Step 6: Alarm on a parameter using absolute thresholds](#step-6-alarm-on-a-parameter-using-absolute-thresholds)
- [Step 7: Define a condition to disable alarming](#step-7-define-a-condition-to-disable-alarming)

## Step 1: Deploy the simulation element

1. For this tutorial we created a simulation protocol that allows us to simulates some practical use cases. Use the Catalog to deploy the [Generic Data Simulator](https://catalog.dataminer.services/details/4f30b72c-b395-49d6-986b-e540b58754e6).

   > [!TIP]
   > If you are new to deploying items from the catalog, refer to [Deploying a Catalog item to your system](xref:Deploying_a_catalog_item)

1. Open DataMiner Cube and verify that the protocol is available under *Protocols & Templates*.

1. To avoid having to create an alarm template for every new version of the connector we will create our alarm template on a production version. This way alarm templates remain even after setting a new version as production. Configure the deployed version as production so it is available when creating the element.

1. Create a new element in your DMS that uses the production version of the Generic Data Simulator.

## Step 2: Alarm on a parameter using normal thresholds

1. Right-click the newly created element and select *Protocols & Templates > Assign alarm template > \<New alarm template\>* to create a new alarm template. In this tutorial we are naming our alarm template *Default*.

1. Check the *CPU* parameter and apply the click *OK*.

In the element, you should now see that the *CPU* parameter under the *General* page is alarmed. You can play around with the *Simulation Mode* to simulate alarms.

![Create an alarm template](~/user-guide/images/KataAlarmTemplatesNewAlarmTemplate.gif)

## Step 3: Define hysteresis

When using the *Spikes* mode, you will see that alarms can exist for short periods of time which might make it difficult for operators to notice the alarm or it might not be relevant as operators might only be interested if the threshold is being violated for longer periods of time. For this we can play with hysteresis to make the alarm console more digestible for operators.

1. Right-click the element and select *Protocols & Templates > View alarm template 'Default'* to open the alarm template.

1. Configure in the *HYST ON* column for the *CPU* parameter *10s* to avoid that alarms are being generated when the CPU is only high for a brief moment (*Spikes* mode).

1. Configure in the *HYST OFF* column for the *CPU* parameter *20s* to ensure operators have more time to notice the alarms. When changing from *High Load* to *Low Load* you will notice that the alarm is present for *20s* longer after the value drops below the alarm threshold.

> [!TIP]
> Be mindful of the polling interval of the parameters when defining hysteresis. If your parameter is only being updated every *5s*, you need to configure at least *10s* (two updates) for the hysteresis to make a difference.

## Step 4: Alarm on a parameter using rate thresholds

When you have counter that continuously go (e.g. received packets on a network interface) it is not possible to define thresholds. For these type of parameters we have the *Rate* option.

1. Right-click the element and select *Protocols & Templates > View alarm template 'Default'* to open the alarm template.

1. Select *Only protocol parameters* at the right top.

1. Check the *Counter Parameter*.

1. Select *Rate* as Type and define *3* under *CRIT HI*.

1. Click *OK* to save the changes.

In the element, you should now see that the *Counter Parameter* under the *General* page is alarmed. When selecting *High Load* the parameter will increment with five on every update and therefor be in alarm. When going back to *Low Load* the alarm will be cleared again as the parameter will increment with one.

## Step 5: Alarm on a parameter using relative thresholds

With relative alarming it is possible to define a baseline to which the value can deviate percentage wise. This can very helpful especially in tables where every row can have a different baseline value.

1. Right-click the element and select *Protocols & Templates > View alarm template 'Default'* to open the alarm template.

1. Select *Only protocol parameters* at the right top.

1. Check the *Bitrate* parameter.

1. Select *Relative* as Type and define *20%* under *CRIT LO* and *CRIT HI*.

1. Click on *[Baseline]* under *Normal* and configure the baseline value that is to be considered normal.

1. Click *OK* to save the changes.

In the element, the *Bitrate* column in the *Interfaces* page/table is now alarmed. The *Bitrate Baseline* column together with the *Bitrate Variance* columns can be used to simulate alarms. Keep in mind that changing the *Bitrate Baseline* value will only change the behavior of the simulation, this will not change the baseline value of the alarm template.

> [!TIP]
> There is an option to automatically update the baseline values used for alarming based on the history. For this trending has to be enabled for at least the number of days configured in the alarm template.

![Configure relative alarming](~/user-guide/images/KataAlarmTemplatesRelativeAlarming.gif)

## Step 6: Alarm on a parameter using absolute thresholds

In some cases it is easier to define in absolute numbers how much a value can deviate from the baseline (e.g. when the baseline is close to zero).

1. Right-click the element and select *Protocols & Templates > View alarm template 'Default'* to open the alarm template.

1. Duplicate the row for the *Bitrate* parameter.

1. Configure the first rule of the two to filter on *Ethernet1/1*.

   > [!IMPORTANT]
   > Ensure that the most strict rule is always on top as the first rule that matches the filter will be used and no other rules will be checked below it.

1. Select *absolute* as Type and define *0.5* under *CRIT LO* and *CRIT HI*.

1. Click on *[Baseline]* under *Normal* and configure the baseline value for *Ethernet1/1* as *0*.

1. Click *OK* to save the changes.

1. Change the simulated bitrate for *Ethernet1/1* to fluctuate around *0*, by setting the *Bitrate Baseline* to *0* in the *Interfaces* table under the *Interfaces* page of the element.

![Configure relative alarming](~/user-guide/images/KataAlarmTemplatesAbsoluteAlarming.gif)

## Step 7: Define a condition to disable alarming

By defining alarm conditions it is possible to dynamically enable/disable alarming based on other values.

1. Right-click the element and select *Protocols & Templates > View alarm template 'Default'* to open the alarm template.

1. Select *\<New\>* under the *CONDITION* column for the bitrate parameter.

1. Configure the condition as in below screenshot.

   ![Alarm hysteresis](~/user-guide/images/KataAlarmTemplatesCondition.png)

1. Apply the condition on both *Bitrate* alarm rules.

1. Click *OK* to save the changes.

1. Change the *Admin State* for some interfaces to validate that the conditional alarming works properly.

![Configure relative alarming](~/user-guide/images/KataAlarmTemplatesConditonalAlarming.gif)