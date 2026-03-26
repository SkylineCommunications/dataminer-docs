---
uid: Getting_started_with_alarm_templates
---

# Getting started with alarm templates

This tutorial explains how to get started with alarm templates.

Expected duration: 15 minutes

> [!NOTE]
> The content and images for this tutorial have been created using DataMiner version 10.4.6.

> [!TIP]
> See also: [Kata #33: Master alarm templates](https://community.dataminer.services/courses/kata-33/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)

## Prerequisites

A DataMiner System that is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

> [!TIP]
> A [new DataMiner as a Service](xref:Creating_a_DMS_on_dataminer_services) system comes with a dataminer.services connection out of the box, so it automatically meets this requirement.

## Overview

- [Step 1: Deploy the simulation element](#step-1-deploy-the-simulation-element)
- [Step 2: Configure alarm monitoring using normal thresholds](#step-2-configure-alarm-monitoring-using-normal-thresholds)
- [Step 3: Configure hysteresis](#step-3-configure-hysteresis)
- [Step 4: Configure alarm monitoring using rate thresholds](#step-4-configure-alarm-monitoring-using-rate-thresholds)
- [Step 5: Configure alarm monitoring using relative thresholds](#step-5-configure-alarm-monitoring-using-relative-thresholds)
- [Step 6: Configure alarm monitoring using absolute thresholds](#step-6-configure-alarm-monitoring-using-absolute-thresholds)
- [Step 7: Define a condition to disable alarm monitoring](#step-7-define-a-condition-to-disable-alarm-monitoring)

## Step 1: Deploy the simulation element

For this tutorial, a simulation protocol is available that allows you to simulate some practical use cases. In this first step, you will deploy this protocol and then create an element using the protocol.

1. Look up the [Generic Data Simulator](https://catalog.dataminer.services/details/4f30b72c-b395-49d6-986b-e540b58754e6) in the Catalog.

1. Deploy the protocol to your DataMiner Agent by clicking the *Deploy* button.

   > [!TIP]
   > See also: [Deploying a Catalog item to your system](xref:Deploying_a_catalog_item)

1. In DataMiner Cube, go to *Apps* > *Protocols & Templates* and verify whether the protocol is available.

1. In the *Versions* column, right-click the deployed version of the protocol and select *Set as production*.

   Creating the alarm template for the production version will have the advantage that there will be no need to create a new alarm template for every new version of the protocol. Even when a new version is set as production, the same alarm template will continue to apply.

1. Make sure the *Production* version is selected, right-click the *Elements* column on the right, and select *New element*.

1. Create a new element with a name of your choice.

   The production version of the *Generic Data Simulator* protocol should automatically be selected in the element editor.

   > [!TIP]
   > See also: [Adding elements](xref:Adding_elements)

## Step 2: Configure alarm monitoring using normal thresholds

1. Look up the newly created element in the Cube Surveyor.

1. Right-click the element and select *Protocols & Templates* > *Assign alarm template* > *\<New alarm template\>*.

1. In the dialog, keep the *Alarm template* option selected, specify the name *Default*, and click *OK*.

1. Select the *CPU* parameter, and click *OK* at the bottom of the window.

   In the element, you should now see the alarm severity color displayed next to the *CPU* parameter on the *General* page.

1. Set *Simulation Mode* to a different value and check what happens.

   The different modes simulate situations that can trigger alarms, so the alarm severity color next to *CPU* will change accordingly, and an alarm may be generated in the Alarm Console.

![Create an alarm template](~/dataminer/images/KataAlarmTemplatesNewAlarmTemplate.gif)

## Step 3: Configure hysteresis

When *Simulation Mode* is set to *Spikes*, alarms will exist for short periods of time, which might make it difficult for operators to notice the alarms. The alarms might also not be relevant, as it could be that operators are only interested if the threshold is violated for longer periods of time. To deal with this, you can configure the hysteresis feature in the alarm template.

1. Right-click the element in the Surveyor, and select *Protocols & Templates* > *View alarm template 'Default'*.

   This will open the alarm template again.

1. In the *HYST ON* column for the *CPU* parameter, specify *10*.

   An alarm will now only be generated if the CPU value remains high for 10 seconds.

1. In the *HYST OFF* column for the *CPU* parameter, specify *20*.

   The alarm will now remain present for 20 seconds longer after the CPU value drops below the alarm threshold, ensuring that operators have more time to notice it.

1. Click *OK* to save your changes.

## Step 4: Configure alarm monitoring using rate thresholds

If a parameter is a counter that continuously increases (e.g., received packets on a network interface), it is not possible to define regular alarm thresholds. For such a parameter, you can use rate thresholds instead.

1. Right-click the element in the Surveyor, and select *Protocols & Templates* > *View alarm template 'Default'*.

1. At the top of the template, click *Only monitored parameters* and select *Only protocol parameters* instead.

   All the parameters included in the protocol will now be displayed.

1. Select the *Counter Parameter*.

1. In the *Type* box, select *Rate*.

1. In the *CRIT HI* column, specify *3*.

   With this configuration, when the current value of the parameter will increase by 3 or more compared to the previously measured value, a critical alarm will be triggered.

1. Click *OK* to save your changes.

   *Counter Parameter* will now also be monitored.

1. Set *Simulation Mode* to *High Load*.

   The parameter value will now increase by 5 on every update, so a critical alarm will be triggered.

1. Set *Simulation Mode* back to *Low Load*.

   The alarm will be cleared again, as the parameter value will now increase by 1 on every update.

## Step 5: Configure alarm monitoring using relative thresholds

With relative alarm thresholds, you can define a baseline from which the value can deviate percentage-wise. This can especially be useful for tables where every row can have a different baseline value.

1. Right-click the element in the Surveyor, and select *Protocols & Templates* > *View alarm template 'Default'*.

1. At the top of the template, click *Only monitored parameters* and select *Only protocol parameters* instead.

1. Select the *Interfaces: Bitrate* parameter.

1. In the *Type* box, select *Relative*.

1. In the *CRIT LO* and *CRIT HI* column, specify *20*.

   With this configuration, if the parameter decreases or increases by 20% compared to the baseline value, an alarm will be triggered.

1. In the *NORMAL* column, click *[Baseline]*.

1. Right-click each cell in the *Current value* column, and select *Use current value as baseline value*.

   The value that are currently in the table will now be considered the normal values to compare against.

   > [!NOTE]
   > With the *Automatically update the baselines* option at the bottom, the baseline values can be updated automatically based on the parameter history. However, you can only use this option if trending has been enabled on the parameter for at least the number of days mentioned in the *Trend window* box.

1. Click *Close* and then *OK* to save the changes.

1. Go to the *Interfaces* data page of the simulation element.

   You will see that the *Bitrate* column of the *Interfaces* table is colored according to the current alarm severity.

1. Change the values in the *Bitrate Baseline* and *Bitrate Variance* columns to simulate alarms.

   Keep in mind that changing the *Bitrate Baseline* value will only change the behavior of the simulation. This will not change the baseline value of the alarm template.

![Configure relative alarming](~/dataminer/images/KataAlarmTemplatesRelativeAlarming.gif)

## Step 6: Configure alarm monitoring using absolute thresholds

In some cases, it can be easier to define in absolute numbers how much a value can deviate from the baseline (e.g., when the baseline is close to zero).

1. Right-click the element in the Surveyor, and select *Protocols & Templates* > *View alarm template 'Default'*.

1. Hover the mouse pointer over the *Interfaces:Bitrate* parameter, and click the + icon to duplicate the parameter.

1. In the filter box of the first instance of the duplicated parameter, specify the filter rule *Ethernet1/1*.

   > [!IMPORTANT]
   > When you duplicate parameters in an alarm template and apply different monitoring based on filters, make sure that the most strict rule is always at the top, because the first rule for which a match is found will be used, and the rules below it will no longer be checked.

1. In the *Type* box, select *Absolute*.

1. In the *CRIT LO* and *CRIT HI* column, specify *0.5*.

1. In the *NORMAL* column of the row with the Ethernet1/1 filter, click *[Baseline]*.

1. In the *Baseline value* column for *Ethernet1/1*, set the value to *0*.

1. Click *Close* and then *OK* to save the changes.

1. In the *Interfaces* table of the simulation element, set the *Bitrate Baseline* value for *Ethernet1/1* to *0*, to simulate a bitrate fluctuating around 0.

![Configure relative alarming](~/dataminer/images/KataAlarmTemplatesAbsoluteAlarming.gif)

## Step 7: Define a condition to disable alarm monitoring

By defining alarm conditions, you can dynamically enable and disable alarm monitoring based on other values.

1. Right-click the element in the Surveyor, and select *Protocols & Templates* > *View alarm template 'Default'*.

1. In the *CONDITION* column for the first *Bitrate* parameter instance, select *\<New\>*.

1. Configure the condition as illustrated below, and click *OK*:

   ![Alarm hysteresis](~/dataminer/images/KataAlarmTemplatesCondition.png)

1. Select the same condition for the other *Bitrate* parameter instance.

1. Click *OK* to save your changes.

1. In the *Interfaces* table of the simulation element, switch the *Admin State* for some interfaces to *Down*.

   The alarm severity color should no longer be displayed for those interfaces.

![Configure relative alarming](~/dataminer/images/KataAlarmTemplatesConditonalAlarming.gif)

## Related documentation

- [Configuring normal alarm thresholds](xref:Configuring_normal_alarm_thresholds)
- [Configuring hysteresis in an alarm template](xref:Configuring_alarm_hysteresis)
- [Configuring dynamic alarm thresholds](xref:Configuring_dynamic_alarm_thresholds)
- [Using conditions in an alarm template](xref:Using_conditions_in_an_alarm_template)
