---
uid: Incident_Tracking_Configuration_Tutorial
---

# Fine-tuning incident tracking in your system

The incident tracking (a.k.a. alarm grouping) functionality automatically groups alarms related to the same root cause. This automatic grouping is governed by a set of **rules** or **grouping strategies**. In this tutorial, you will learn how to enable and disable certain rules, tweak them, and even add your own custom rules to the alarm grouping engine.

The content and screenshots for this tutorial have been created in DataMiner 10.4.10.

Estimated duration: 30 minutes

<!-- > [!TIP]
> See also: [Kata #43: [KATA] Grouping alarms like a pro](TODO: link and video reference still to be filled in here) -->

## Prerequisites

- DataMiner 10.2.0/10.1.4 or higher with [Storage as a Service (STaaS)](xref:STaaS) or a [self-hosted Cassandra database](xref:Supported_system_data_storage_architectures).

- Automatic incident tracking is enabled in DataMiner Cube: *System Center* > *System settings* > *analytics config* > *Automatic incident tracking*.

- Automatic incident tracking is enabled in the Alarm Console.

  To check if this is enabled, check if *Automatic incident tracking* is selected in the Alarm Console hamburger menu.

  ![Enable Incident Tracking in the Alarm Console](~/user-guide/images/EnableAlarmGroupingInAlarmConsole.png)

## Overview

The tutorial consists of the following steps:

- [Step 1: Install the example package from the Catalog](#step-1-install-the-example-package-from-the-catalog)
- [Step 2: Find the advanced configuration file](#step-2-find-the-advanced-configuration-file)
- [Step 3: Explore the default alarm grouping rules](#step-3-explore-the-default-alarm-grouping-rules)
- [Step 4: Switch off parameter and view grouping](#step-4-switch-off-parameter-and-view-grouping)
- [Step 5: Add your own rules to the incident tracking engine](#step-5-add-your-own-rules-to-the-incident-tracking-engine)
- [Step 6: Group on a custom element property](#step-6-group-on-a-custom-element-property)
- [Step 7: Clean up your system](#step-7-clean-up-your-system)

## Step 1: Install the example package from the Catalog

1. Go to <https://catalog.dataminer.services/details/5b989f43-bdab-4774-ae00-228b097363b1>.

1. Deploy the Catalog item to your DataMiner Agent by clicking the *Deploy* button.

   This will create 13 elements under the *DataMiner Catalog > Augmented Operations* > *Incident Tracking Tutorial* view. It will also create four Automation scripts. The names of all added elements and scripts starts with *Incident Tracking Tutorial*.

   > [!NOTE]
   > If the package has been fully deployed, but not everything mentioned above is visible in Cube, close and reopen Cube.

## Step 2: Find the advanced configuration file

Automatic incident tracking groups alarms according to a set of rules, which are listed in a configuration file. To locate the file in your system:

1. Go to *Apps* > *System Center* > *System settings* > *analytics config*.

1. Under *Automatic Incident Tracking*, check which ID is mentioned in the box *Leader DataMiner ID*.

   This is the ID of the DataMiner Agent within your DMS that is in charge of running the incident tracking algorithm for the entire DMS.

1. On the server running the leader DMA, go to the folder `C:\Skyline DataMiner\Analytics`.

   Within this folder, you will find the *configuration.xml* file.

> [!NOTE]
> If you are using [DaaS](xref:Creating_a_DMS_in_the_cloud), you will not be able to access this location. However, you can use the Automation scripts that were included in the package instead in order to follow this tutorial. To get an idea of what this *configuration.xml* file looks like, we recommend taking a look at the file on an on-premises DMA.

## Step 3: Explore the default alarm grouping rules

By default, a new alarm can only be added to an existing alarm group if it occurs within 10 minutes of another alarm that is already in the group. You can customize this 10-minute interval in DataMiner Cube via *System Center* > *System settings* > *analytics config* > *Automatic Incident Tracking* > *Maximum time interval*. Once alarms occur within this interval, the rules in the *configuration.xml* will determine whether or not they are grouped.

1. Open the *configuration.xml* file, and take a look at the different rules.

   You should be able to spot the following rules:

   - The *ServiceProperty* rule, which determines whether alarms will be automatically grouped on parameters from the same service. The corresponding XML item in *configuration.xml* looks like this:

     ![Grouping on service](~/user-guide/images/serviceGrouping.png)

     > [!TIP]
     > See also: [Enabling or disabling service-based alarm grouping](xref:Customizing_alarm_grouping_rules#enabling-or-disabling-service-based-alarm-grouping)

   - The *RelationsProperty* rule, which refers to parameter and alarm relationship data.

     ![Grouping on relation strength](~/user-guide/images/relationGrouping.png)

     > [!TIP]
     > See also: [Fine-tuning alarm grouping based on parameter and alarm relations](xref:Customizing_alarm_grouping_rules#fine-tuning-alarm-grouping-based-on-parameter-and-alarm-relations)

   - The *LocationProperty* rule, which requires DataMiner IDP and determines whether alarms are grouped based on location.

     ![Grouping on location](~/user-guide/images/locationGrouping.png)

     > [!TIP]
     > See also: [fine-tuning location-based alarm grouping](xref:Customizing_alarm_grouping_rules#fine-tuning-location-based-alarm-grouping)

   - The *ParameterProperty* rule, which determines the grouping of alarms for the same parameter of a specific protocol.

     For example, when multiple elements using the *Microsoft Platform* protocol have an alarm on their *Total Processor Load* parameter, then those alarms are grouped.

   - The *ElementProperty* rule, which determines whether alarms on the same element are grouped.

   - The *PollingProperty* rule, which determines whether timeout alarms polling from the same IP are grouped.

   - The *ViewProperty* rule, which determines whether alarms on elements within the same view are grouped.

     ![Grouping on view](~/user-guide/images/viewGrouping.png)

   - The *GenericProperties* rule, which allows you to define custom properties.

     You will find out more about this rule in [step 5](#step-5-add-your-own-rules-to-the-incident-tracking-engine).

1. Test the *ParameterProperty* rule:

   1. Open the *Incident Tracking Tutorial Amplifier1_Node1* element in DataMiner Cube.

   1. Go to the *Forward Path* > *Level Detector* page of the element.

   1. Click the *Toggle Alarm* button in the top-right corner.

      ![Set an amplifier in alarm](~/user-guide/images/setAlarm.png)

      This will add an alarm for this element in the Alarm Console.

   1. Do the same for the *Incident Tracking Tutorial Amplifier2_Node1* element.

      This way, you will add an alarm for the same parameter of an element using the same protocol. You should see that the new alarm is automatically grouped with the previously created alarm.

      ![Grouping on parameter](~/user-guide/images/parameterGrouping.png)

      > [!NOTE]
      > If no alarm group is formed, check whether *Automatic incident tracking* is enabled in the Alarm Console and whether you have triggered the alarm for the correct element. Not all of the elements added for this tutorial use the same protocol, so if you used a different element than mentioned above, the rule may not be triggered.

   1. In both elements, click the *Toggle Alarm* button again to clear the alarms again.

1. Test the *ViewProperty* rule:

   1. In the same way as before, trigger an alarm on the elements *Incident Tracking Tutorial - Amplifier1_Node1*, *Incident Tracking Tutorial - Amplifier1_Node2*, and *Incident Tracking Tutorial - Amplifier1_Node3*.

      As the threshold in *configuration.xml* is by default set to 0.25 for this property, and the view containing the amplifier elements contains 10 elements, this will make the fraction of devices in alarm within the view exceed the configured threshold value. The three amplifier elements mentioned above use different protocols, so that the *ParameterProperty* rule does not get triggered here.

      The resulting group should look like this:

      ![Grouping on view in action](~/user-guide/images/viewGroupingInAction.png)

   1. Clear the alarms again using the *Toggle Alarm* button for each element.

## Step 4: Switch off parameter and view grouping

To make it easier to see the effect of the next steps, temporarily switch off parameter and view grouping. There are two ways you can do this:

- The easiest way (and the only way in case you are using DaaS) is by running the Automation script *Incident Tracking Tutorial Scripts - Script 1 Disable View and Parameter Grouping* .

  This script is included in the package you installed in step 1.

- Alternatively, if you are not using DaaS and you want to get familiar with making manual changes to the configuration, you can edit the *configuration.xml* file:

  1. Open the *configuration.xml* file, after locating it as described in [step 2](#step-2-find-the-advanced-configuration-file).
  1. Set the `<enable>` tag of the *ParameterProperty* rule and the *ViewProperty* rule to *false*.
  1. Save the file.
  1. Restart the *SLAnalytics.exe* process on the leader Agent.

## Step 5: Add your own rules to the incident tracking engine

When you deployed the Catalog package earlier, elements were added in a *Nodes* and an *Amplifiers* view. This is inspired by EPM setups where a node sends out a signal to a group of amplifiers which in turn amplify and forward the signal to households. In this step, you will add a rule to automatically group alarms on amplifiers under the same node.

In the current setup, there are three nodes, named *Incident Tracking Tutorial - TELESTE_NODE_x*, where "x" is 1, 2, or 3. Each node sends a signal to the amplifiers with the name ending in the same number. For example, *Incident Tracking Tutorial - TELESTE_NODE_1* sends a signal to *Incident Tracking Tutorial - Amplifier1_Node1*, *Incident Tracking Tutorial - Amplifier2_Node1*, *Incident Tracking Tutorial - Amplifier3_Node1*, and *Incident Tracking Tutorial - Amplifier4_Node1*.

The package was configured so that an alarm on any of the amplifiers will contain a custom property called *ParentNode*, referring to the parent node. To see this property, you can generate an alarm on one of the amplifiers, and then right-click the alarm in the Alarm Console and select *Properties*.

![CustomAlarmProperty](~/user-guide/images/alarmProperty.png)

1. With this in mind, create a rule to group alarms of which the *ParentNode* property has the same value:

   1. Open the *configuration.xml* file.

   1. Scroll down to the *GenericProperties* property.

      ![Grouping on custom property](~/user-guide/images/customPropertyGrouping.png)

   1. Within the `<Value>` tags for this property, paste the following snippet:

      ```xml
        <item type="skyline::dataminer::analytics::workers::configuration::GenericAlarmPropertyVisitorConfiguration">
          <enable>true</enable>
          <name>[PROPERTY_NAME]</name>
        </item>
      ```

      The result should look like this:

      ![Grouping on custom property with pasted snippet](~/user-guide/images/customPropertyGrouping2.png)

   1. In the *name* tag of the pasted snippet, fill in the property name on which you want to group, i.e. *ParentNode*.

   1. Save the file.

   1. Restart *SLAnalytics.exe* (e.g. through the task manager).

   > [!NOTE]
   > If you do not have access to the *configuration.xml* file, instead run the Automation script *Incident Tracking Tutorial Scripts - Script 2 Enable Custom Alarm Property Grouping* to apply the same configuration.

   > [!TIP]
   > For more detailed information about adding custom rules, see [Defining custom properties for grouping](xref:Customizing_alarm_grouping_rules#defining-custom-properties-for-grouping).

1. On the amplifier elements ending in *Node1*, go to the *Forward Path* > *Level Detector* page and click *Toggle Alarm* to generate alarms.

1. In the Alarm Console, check whether an alarm group has been created.

   The resulting alarm group should look like this:

   ![Grouping on alarm property result](~/user-guide/images/GroupingOnAlarmPropertyResult.png)

1. Clear the created alarms by clicking the *Toggle Alarm* buttons again.

## Step 6: Group on a custom element property

In this step, you will create a rule to group alarms on amplifiers under the same node, but only if **at least 75%** of the amplifiers under the node are in alarm.

You should find everything you need to complete this exercise on the [Customizing alarm grouping rules](xref:Customizing_alarm_grouping_rules) page.

To help you on your way, we recommend creating a custom element property. For each amplifier, the value of this property should refer to its parent node.

In case you do not have access to the *configuration.xml* file and you would still like to participate:

1. Open the *Incident Tracking Tutorial Scripts - Script 3 Enable Custom Element Property Grouping* automation script.
1. Look for the string variable called *KataExercise*.
1. Set this string equal to all the xml code that you want to add to the *value* tag of the *GenericProperties* rule in the *configuration.xml*.
1. Save the file.
1. Restart *SLAnalytics.exe* through the task manager.
1. Send us a screenshot to be awarded DevOps Points.

   > [!IMPORTANT]
   > Use the following email format to send us your screenshot:
   >
   > - Subject: Tutorial - Fine-tune incident tracking in your system
   > - To: [ai@skyline.be](mailto:ai@skyline.be)
   > - Body:
   >   - Dojo account: Clearly mention the email address you use to sign into your Dojo account, especially if you are using a different email address to send this email.
   >   - Attachment: Add a screenshot of the amplifiers you have set in alarm and of the corresponding alarm group.
   >
   > Upon successful validation, you will be awarded 75 DevOps Points.

## Step 7: Clean up your system

1. Clear the created alarms using the *Toggle Alarm* buttons of each element.

1. Run the *Incident Tracking Tutorial Scripts - Script 4 Reset Configuration* Automation script to revert to your original *configuration.xml*.
