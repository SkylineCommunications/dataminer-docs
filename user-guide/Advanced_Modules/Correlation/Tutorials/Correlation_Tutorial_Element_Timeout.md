---
uid: Correlation_Tutorial_Element_Timeout
---

# Responding to element timeouts using Correlation

In this tutorial, you will learn how to use Correlation to take action when an element is in timeout for longer than 5 minutes.

Expected duration: 15 minutes

## Prerequisites

- A DataMiner System that is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

## Overview

This tutorial consists of the following steps:

- [Step 1: Deploy the 'Correlation KATA Switch Timeout' item from the DataMiner Catalog](#step-1-deploy-the-correlation-kata-switch-timeout-item-from-the-dataminer-catalog)
- [Step 2: Create the Correlation rule](#step-2-create-the-correlation-rule)
- [Step 3: Generate a timeout alarm](#step-3-generate-a-timeout-alarm)
- [Step 4: Verify whether the rule actions have been executed](#step-4-verify-whether-the-rule-actions-have-been-executed)

## Step 1: Deploy the 'Correlation KATA Switch Timeout' item from the DataMiner Catalog

1. Look up the 'Correlation KATA Switch Timeout' item in the DataMiner Catalog.

1. Deploy the catalog item to your DataMiner Agent by clicking the *Deploy* button.

   > [!TIP]
   > See also: [Deploying a Catalog item to your system](xref:Deploying_a_catalog_item)

## Step 2: Create the Correlation rule

In this step, you will create a Correlation Rule that will trigger based on alarms from the *Network Switch* element. If the element is in timeout for longer than 5 minutes, the rule will take action, and an Automation script will generate an information event.

1. In DataMiner Cube, go to *Apps* > *Modules* > *Correlation* to open the Correlation module.

1. Add an alarm filter that filters on alarms from the element "Network Switch".

   See [filtering and grouping base alarms for Correlation rules](xref:Filtering_and_grouping_base_alarms_for_Correlation_rules) for more information.

1. Add a rule condition that triggers when the severity is equal to "Timeout".

   See [adding rule conditions in Correlation rules](xref:Adding_rule_conditions_in_Correlation_rules) for more information.

1. Select the "Persistent event" trigger mechanism and fill in 5 minutes.

   The Correlation Rule will wait until the rule conditions are met for 5 minutes before acting and executing its actions.

   See [adding rule conditions in Correlation rules](xref:Adding_rule_conditions_in_Correlation_rules) for more information.

1. Add the RunScript action and select the "Generate Information Event (network switch timed out)" script.

   This Automation script will generate an information event when executed. Note that these scripts also can do other things.

   See [adding a RunScript action](xref:Running_an_Automation_script_from_a_Correlation_rule) for more information.

1. Optionally, add the Send email action.

   See [sending an email](xref:Sending_an_email) for more information on how to do this.

   > [!NOTE]
   > This action will only work if a mail server has been configured. See [Configuring outgoing email](xref:Configuring_outgoing_email)

1. Optionally, add other rule actions according to your preference.

   For more information on how to add rule actions, go to [adding rule actions in Correlation rules](xref:Adding_rule_actions_in_Correlation_rules).

> [!NOTE]
> Make sure to have a look at some [best practices when making Correlation Rules](xref:Best_Practices_When_Creating_Correlation_Rules). Correlation is a powerful tool, but can have a negative impact on your system if set up the wrong way.

## Step 3: Generate a timeout alarm

1. In the Surveyor, select the *Network Switch* element.

1. Click the *Generate Timeout* button and wait 30 seconds (i.e. the default duration DataMiner waits when an element does not respond before generating a timeout alarm).

   A timeout alarm will then be generated.

## Step 4: Verify whether the rule actions have been executed

1. Wait for five minutes after the alarm has gone into timeout.

1. Check whether an information event has been generated in the Alarm Console.

   This information event should have been created by the Automation script triggered by the Correlation rule, if you configured everything correctly.

1. If you added the Send email action to the Correlation rule, check whether you have received an email.

> [!NOTE]
> To be granted DevOps points for taking this tutorial, take a screenshot of your Correlation rule and of the Alarm Console displaying the generated information event. Submit it on Dojo and receive 75 DevOps Points. An extra 75 DevOps Points are awarded if you manage to complete the challenge within a week after the Kata is released.
