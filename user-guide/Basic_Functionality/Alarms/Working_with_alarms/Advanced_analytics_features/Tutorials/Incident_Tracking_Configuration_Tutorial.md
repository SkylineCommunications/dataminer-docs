---
uid: Incident_Tracking_Configuration_Tutorial
---

# Finetune incident tracking for your system

The incident tracking (aka alarm grouping) functionality automatically groups alarms related to the same root cause. This automatic grouping is governed by a set of *rules* or *grouping strategies*. In this tutorial, we will teach you how to enable/disable certain rules, tweak them or even add your own custom rules to the alarm grouping engine.

The content and screenshots for this tutorial have been created in DataMiner 10.4.10

Estimated Duration: 30 minutes


> [!TIP]
>  See also: [Kata #43: [KATA] Grouping alarms like a pro](TODO: link and video reference still to be filled in here)
## Prerequisites

- DataMiner 10.2.0/10.1.4 or higher
- Automatic Incident Tracking is enabled in DataMiner Cube: *System Center* > *System settings* > *analytics config* > *Automatic Incident Tracking*.
- Automatic Incident Tracking is enabled in the alarm console by selecting *Automatic incident tracking* in the Alarm Console hamburger menu.

 ![Enable Incident Tracking in the alarm console](~/user-guide/images/EnableAlarmGroupingInAlarmConsole.png)

## Overview
The tutorial consists of the following steps:

- [Step 1: Install the example package from the Catalog](#step-1-install-the-example-package-from-the-catalog)
- [Step 2: Find the advanced configuration file](#step-2-find-the-advanced-configuration-file)
- [Step 3: Explore the default alarm grouping rules](#step-3-explore-the-default-alarm-grouping-rules)
- [Step 4: Switch off parameter and view grouping](#step-4-switch-off-parameter-and-view-grouping)
- [Step 5: Adding your own rules to the incident tracking engine: alarm properties](#step-5-adding-your-own-rules-to-the-incident-tracking-engine-alarm-properties)
- [Step 6: Final exercise: grouping on a custom element property](#step-6-final-exercise-grouping-on-a-custom-element-property])
- [Step 7: Clean up your system](#step-7-clean-up-your-system])

## Step 1: Install the example package from the Catalog

1. On the catalog, look for the package *Kata Incident Tracking* or click the direct link: <https://catalog.dataminer.services/details/5b989f43-bdab-4774-ae00-228b097363b1>.
1. Deploy the catalog item to your DataMiner Agent by clicking the *Deploy* button.

   This will create 13 elements under the *DataMiner Catalog > Augmented Operations > Incident Tracking Tutorial* view. It will also create four automation scripts. You can easily recognize the elements and scripts because their names begin with *Incident Tracking Tutorial*.

## Step 2: Find the advanced configuration file

Automatic incident tracking groups alarms according to a set of concrete rules. These rules are listed in a somewhat hidden configuration file. To find the file on your system:

1. Use DataMiner Cube to look up the Incident Tracking Leader DataMiner ID. You can find it in the following location: *System Center* > *System settings* > *analytics config* > *Automatic Incident Tracking* > *Leader DataMiner ID*.

	The *Leader DataMiner ID* refers to the single agent in your cluster that is in charge of running the incident tracking algorithm for the entire cluster.
1. On the server running the leader DMA, find the *configuration.xml* file in the "Skyline DataMiner/Analytics" folder.

>[!NOTE]
>
>	- If you are on a DAAS system, you will not be able to access this location, but you will still be able to follow this tutorial by making use of the provided automation scripts. To have an idea of what this *configuration.xml* file looks like, we recommend fetching it from an on premise DMA.
>	- Note that every agent in the cluster has its own *configuration.xml* file, but that only the one on the leader is actually ever used. In particular, if you ever change the Leader DataMiner ID, make sure to update the configuration file on the server running the new leader.

## Step 3: Explore the default alarm grouping rules
Before exploring the rules, it is important to note that a new alarm can only be added to an existing alarm group if it occurs within 10 minutes of some alarm already in the group. This 10 minute duration is configurable in DataMiner Cube: *System Center* > *System settings* > *analytics config* > *Automatic Incident Tracking* > *Maximum time interval*.

Once alarms occur within 10 minutes of each other, the rules mentioned in the *configuration.xml* completely determine whether or not they are grouped. Let us go over them:

1. The *ServiceProperty* rule states that we will automatically group alarms on parameters of the same service. The corresponding xml item in the *configuration.xml* looks like this: 
	
	![Grouping on service](~/user-guide/images/serviceGrouping.png)
		To disable grouping based on service:
	1. Set the *enable* tag to *false* instead of *true*.
	1. Save the file.
	1. Restart the *SLAnalytics.exe* process on the leader agent (using the windows task manager for example).

1. The *RelationsProperty* rule refers to the parameter relationship data (from DataMiner 10.3.1/10.4.0 onwards) and alarm relationship data (from DataMiner 10.3.7/10.4.0 onwards) available on DataMiner Agents that are connected to dataminer.services,  have the [DataMiner Extension Module *ModelHost*](xref:DataMinerExtensionModules#modelhost) installed, and have been configured to [offload alarm and change point events to the cloud](xref:Controlling_cloudfeed_data_offloads).
   This functionality assigns a *relation score* to any 2 parameters in your system. The score is a number between 0 and 1 where the value 1 refers to a very strong relation and the value 0 to a non-existing relation.
   The rule states that alarms on parameters with relation score higher than mentioned in the *relationThreshold* tag will be grouped. The default relationThreshold is 0.7.

	![Grouping on relation strength](~/user-guide/images/relationGrouping.png)

	To tweak this rule:
	
	1. Enable or disable the rule by setting the *enable* tag to *true* or *false*.
	1. Change the relationThreshold tag to a desired value between 0 and 1.
	1. Save the file.
	1. Restart the *SLAnalytics.exe* process on the leader agent (using the windows task manager for example).

1. The *LocationProperty* rule requires usage of the [IDP Solution](xref:IDP_Tutorial_DiscoveryAndProvisioning) to enrich devices with location info.
	The rule states that alarms on devices in the same location are grouped under the condition that the fraction of devices in alarm at that location exceeds the value set in the *threshold* tag.

	![Grouping on location](~/user-guide/images/locationGrouping.png)

	To tweak this rule:
	
	1. Enable or disable the rule by setting the *enable* tag to *true* or *false*.
	1. Change the threshold tag to a desired value between 0 and 1.
	1. Save the file.
	1. Restart the *SLAnalytics.exe* process on the leader agent (using the windows task manager for example).

1. The *ParameterProperty* rule states that alarms on the same *(connector,parameter)*-pair are grouped. For example, when multiple devices using the *Microsoft Platform* driver, have an alarm on their *Total Processor Load* parameters, then those alarms are grouped.

	To see this rule in action, consider the elements *Incident Tracking Tutorial - Amplifier1_Node1* and *Incident Tracking Tutorial - Amplifier2_Node1*, sharing the same protocol. Then:
	
	1. Create an alarm on the *Incident Tracking Tutorial Amplifier1_Node1* element as follows:
	
		1. Open the element.
		1. Click the dropdown icon next to the *Forward Path* page of the element.
		1. Open the *Level Detector* page.
		1. Click the *Toggle Alarm* button.
	
	![Set an amplifier in alarm](~/user-guide/images/setAlarm.png)
	
	You should see the alarm appearing in your alarm console.
		
	2. Similarly, create an alarm on the *Incident Tracking Tutorial Amplifier2_Node1* element.
	
	You should see that the new alarm is automatically grouped with the previously created alarm as in the picture below.
	
	![Grouping on parameter](~/user-guide/images/parameterGrouping.png)

	3. Clear the alarms that you created by pressing the aforementioned *Toggle Alarm* button again on both elements.

1. The *ElementProperty* rule states that alarms on the same element are grouped.
1. The *PollingProperty* rule states that time-out alarms polling from the same IP are grouped.
1. The *ViewPropery* states that alarms on devices under the same view are grouped under the condition that the fraction of devices in alarm under that view exceeds the value in the *threshold* tag. The snippet in the *configuration.xml* that corresponds to this rule, looks like this:

	![Grouping on view](~/user-guide/images/viewGrouping.png)

	To see this in action, note that the *threshold* tag is set to 0.25, so let us make sure that the fraction of devices in alarm under the *DataMiner Catalog < Augmented Operations < Incident Tracking Tutorial < Amplifiers* view exceeds 0.25. As this view contains 10 elements, you should trigger alarms on at least 3 amplifiers.

	To avoid interference with the parameter grouping rule, create alarms on amplifiers with different protocols: e.g. *Incident Tracking Tutorial - Amplifier1_Node1*, *Incident Tracking Tutorial - Amplifier1_Node2* and *Incident Tracking Tutorial - Amplifier1_Node3*. The resulting group should look like this:

	![Grouping on view in action](~/user-guide/images/viewGroupingInAction.png)

	Do not forget to clear the alarm using the aforementioned *Toggle Alarm* button.
	
1. The *GenericProperties* rule will be discussed later.

## Step 4: Switch off parameter and view grouping

For the remainder of the exercises, we will switch off Parameter and View grouping to demonstrate our point more easily. The easiest way to do this is by running the *Incident Tracking Tutorial Scripts - Script 1 Disable View and Parameter Grouping* automation script from the catalogue package.

Alternatively, if you have access to the *configuration.xml* file you can do it manually as follows:

1. Open the *configuration.xml* file, located in "Skyline DataMiner/Analytics" on your leader agent.
1. Set the enable tag of the *ParameterProperty* rule and the *ViewProperty* rule to *false*.
1. Save the file.
1. Restart the *SLAnalytics.exe* process on the leader.

## Step 5: Adding your own rules to the incident tracking engine: alarm properties

The setup contained in the catalog package creates a *Nodes* and an *Amplifiers* view. This is inspired by EPM setups where a node  sends out a signal to a group of amplifiers which in turn amplify and forward the signal to households.

The goal of this section is to automatically group alarms on amplifiers under the same node. 

In the current setup, we have 3 nodes. We assume that *Incident Tracking Tutorial - TELESTE_NODE_x* (x is 1,2 or 3) sends a signal to the amplifiers with name ending on *Nodex*. So, for example,
 *Incident Tracking Tutorial - TELESTE_NODE_1* sends a signal to

*Incident Tracking Tutorial - Amplifier1_Node1*,

*Incident Tracking Tutorial - Amplifier2_Node1*,

*Incident Tracking Tutorial - Amplifier3_Node1* and 

*Incident Tracking Tutorial - Amplifier4_Node1*.

We have set everything up in such a way that an alarm on any of the amplifiers contains a custom property, called *ParentNode*, referring to the parent node. To see this in action:

1. Create an alarm on one of the amplifiers, e.g. *Incident Tracking Tutorial - Amplifier1_Node1*.
1. Right click the alarm and select *Properties*.
1. Notice mention of the *ParentNode* property at the bottom of the window

	![CustomAlarmProperty](~/user-guide/images/alarmProperty.png)

To configure *Incident Tracking* to group alarms whose *ParentNode* property have the same value, you should follow the steps below. In case you do not have access to the *configuration.xml* file, you can alternatively run the *Incident Tracking Tutorial Scripts - Script 2 Enable Custom Alarm Property Grouping* automation script that was added to the catalogue package.


1. Go to the [Advanced automatic incident tracking configuration](xref:Automatic_incident_tracking#advanced-configuration) page on the DataMiner user guide.
1. Scroll down to the item related to grouping on <strong> alarm property</strong>.
1. Copy the xml snippet displayed there. For completeness, we repeat it here:
```xml
  <item type="skyline::dataminer::analytics::workers::configuration::GenericAlarmPropertyVisitorConfiguration">
    <enable>true</enable>
    <name>[PROPERTY_NAME]</name>
  </item>
  ```
4. Open the *configuration.xml* file.
1. Scroll down to the *GenericProperties* item.
	
	![Grouping on custom property](~/user-guide/images/customPropertyGrouping.png)
1. Paste the aforementioned xml snippet in the *value* tag, obtaining:

	![Grouping on custom property with pasted snippet](~/user-guide/images/customPropertyGrouping2.png)
1. In the *name* tag of the pasted snippet, fill in the property name on which you want to group, ie *ParentNode*.
1. Save the file.
1. Restart *SLAnalytics.exe* (e.g. through the task manager).
1. Create alarms on the amplifiers linked to Node 1.

The alarm  group should look like this:

![Grouping on alarm property result](~/user-guide/images/GroupingOnAlarmPropertyResult.png)

8. Clear the created alarms using the aforementioned *Toggle Alarm* button.

## Step 6: Final exercise: grouping on a custom element property

In this final exerice, the goal is to group alarms on amplifiers under the same node, <strong>but only</strong> if at least 75% of the amplifiers under the node are in alarm. You should find everything you need to complete this exercise on the [Advanced automatic incident tracking configuration](xref:Automatic_incident_tracking#advanced-configuration) page on the DataMiner user guide.

To help you on your way, we recommend creating a custom element property. For each amplifier, the value of this property should refer to its parent node. 

In case you do not have access to the *configuration.xml* file and you would still like to participate:
1. Open the *Incident Tracking Tutorial Scripts - Script 3 Enable Custom Element Property Grouping* automation script.
1. Look for the string variable called *KataExercise*.
1. Set this string equal to all the xml code that you want to add to the *value* tag of the *GenericProperties* rule in the *configuration.xml*.
1. Save the file.
1. Restart *SLAnalytics.exe* through the task manager.

Finally, 

> [!IMPORTANT]
> Use the following email format to send us your solution:
>
> - Subject: Tutorial - Finetune incident tracking for your system
> - To: [ai@skyline.be](mailto:ai@skyline.be)
> - Body:
>   - Dojo account: clearly mention the email address you use to sign into your Dojo account, especially if you are using a different email address to send this email.
>	- Attachment: add a screenshot of the amplifiers you have set in alarm and of the corresponding alarm group
>
> Upon successful validation, you will be awarded 75 DevOps Points.

## Step 7: Clean up your system
1. Clear the created alarms using the aforementioned *Toggle Alarm* buttons.
1. Run the *Incident Tracking Tutorial Scripts - Script 4 Reset Configuration* automation script from the Catalogue item to revert to your original *configuration.xml*.
