---
uid: Correlation_Tutorial_Element_Timeout
---

# Responding to element timeouts using Correlation

In this tutorial, you will learn how to use DataMiner Correlation to take action when an element is in timeout for longer than 5 minutes.

Expected duration: 15 minutes

> [!NOTE]
> The content and screenshots for this tutorial were created in DataMiner 10.4.6.

> [!TIP]
> See also: [Kata #31: Master correlation rules](https://community.dataminer.services/courses/kata-31/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)

## Prerequisites

- A DataMiner System that is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

## Overview

This tutorial consists of the following steps:

- [Step 1: Deploy the 'Correlation KATA Switch Timeout' item from the Catalog](#step-1-deploy-the-correlation-kata-switch-timeout-item-from-the-catalog)
- [Step 2: Create the correlation rule](#step-2-create-the-correlation-rule)
- [Step 3: Generate a timeout alarm](#step-3-generate-a-timeout-alarm)
- [Step 4: Verify whether the rule actions have been executed](#step-4-verify-whether-the-rule-actions-have-been-executed)

## Step 1: Deploy the 'Correlation KATA Switch Timeout' item from the Catalog

1. Look up the [Correlation_KATA_Switch_Timeout](https://catalog.dataminer.services/details/22cd5be6-c814-4ed8-a122-670f6c6b7934) package in the Catalog.

1. Deploy the latest version of the package to your DataMiner Agent by clicking the *Deploy* button.

   > [!TIP]
   > See also: [Deploying a Catalog item to your system](xref:Deploying_a_catalog_item)

When the package has been deployed, the automation script *Correlation KATA switch timeout Script* and the element *Correlation KATA Switch Timeout - Network Switch* will become available in the DataMiner System. You can find the element in the Surveyor under *DataMiner Catalog* > *Correlation KATA* > *Network Switch Timeout*.

## Step 2: Create the correlation rule

In this step, you will create a correlation rule that will trigger based on alarms from the *Correlation KATA Switch Timeout - Network Switch* element. If the element is in timeout for longer than 5 minutes, the rule will take action, and an automation script will generate an information event.

1. In DataMiner Cube, go to *Apps* > *Modules* > *Correlation* to open the Correlation module.

1. In the lower-left corner, click *Add rule* to add a new Correlation rule.

1. In the *Name* box on the right, specify a name of your choice, e.g. `Correlation tutorial`.

1. Under *ALARM FILTER*, configure a filter so that the correlation rule will only be applied for alarms from the element *Correlation KATA Switch Timeout - Network Switch*:

   1. Click *Select a filter*.

   1. In the dropdown list, select *Element*.

   1. Click the field to the right of *Equal to*.

      This will open a pane where you can select an element.

   1. In the pane, select *Correlation KATA Switch Timeout - Network Switch*, click *ADD >>*, and then click *Close*.

      ![Adding an alarm filter](~/dataminer/images/Correlation_Adding_Alarmfilters.png)

1. Under *RULE CONDITION*, add a rule condition that will trigger the rule when the severity is equal to *Timeout*.

   1. Click *Select a filter*, and select *Filter condition*.

   1. To the right, click *Select a filter*, and then select *Severity* on the dropdown list.

   1. Click the field to the right of *Equal to*, select *Timeout*, click *ADD >>*, and then click *Close*.

      ![Adding a rule condition](~/dataminer/images/Correlation_Adding_RuleConditions.png)

1. Below the rule condition configuration, select the *Persistent event* trigger mechanism and fill in 5 minutes.

   With this configuration, the correlation rule will wait until the rule conditions have been met for 5 minutes before acting and executing its actions.

   ![Configuring *persistent event time*](~/dataminer/images/Correlation_PersistentEvent.png)

1. Under *RULE CONDITION*, configure an action to run a script that will generate an information event:

   1. Click *Add action* and select *Run script*.

   1. Next to *Run script*, click *\<empty>* and select the script *Correlation KATA switch timeout Script*.

      This Automation script will generate an information event when executed.

      ![Adding the *run script* action](~/dataminer/images/Correlation_Add_Run_Script_Action.png)

   > [!NOTE]
   > Generating an information event is just one example of what you can do with this functionality. There are many, many more possibilities. However, when you explore these further outside the scope of this tutorial, make sure to keep the [best practices for Correlation](xref:Best_Practices_For_Correlation) in mind to avoid creating a correlation rule that could have a negative impact on your system.

1. Optionally, add another action to send an email to your account when the rule is triggered:

   1. Click *Add action* and select *Send email*.

   1. Fill in the *To* and *Subject* fields, and optionally fill in a message.

      ![Adding the *send mail* action](~/dataminer/images/Correlation_Add_Send_Mail_Action.png)

   > [!IMPORTANT]
   > This action will only work if a mail server has been configured. See [Configuring outgoing email](xref:Configuring_outgoing_email)

1. Optionally, add other rule actions according to your preference.

   > [!TIP]
   > See [adding rule actions in correlation rules](xref:Adding_rule_actions_in_Correlation_rules).

1. At the top of the rule configuration pane, select *Enable this rule*.

   By default, a new Correlation rule is not active, so this step is important to make sure that the rule will actually take action when needed.

1. In the lower-right corner, click *Apply* to save your changes.

## Step 3: Generate a timeout alarm

1. In the Surveyor, select the element *Correlation KATA Switch Timeout - Network Switch*.

1. Click the *Create Timeout* button and wait 30 seconds (i.e. the default duration DataMiner waits when an element does not respond before generating a timeout alarm).

   A timeout alarm will then be generated.

## Step 4: Verify whether the rule actions have been executed

1. Wait for five minutes after the alarm has gone into timeout.

1. Check whether an information event has been generated in the Alarm Console.

   This information event should have been created by the automation script triggered by the correlation rule, if you configured everything correctly.

1. If you added the *Send email* action to the correlation rule, check whether you have received an email.

## Related documentation

- [Filtering and grouping base alarms for correlation rules](xref:Filtering_and_grouping_base_alarms_for_Correlation_rules)
- [Adding rule conditions in correlation rules](xref:Adding_rule_conditions_in_Correlation_rules)
- [Adding rule actions in correlation rules](xref:Adding_rule_actions_in_Correlation_rules)
