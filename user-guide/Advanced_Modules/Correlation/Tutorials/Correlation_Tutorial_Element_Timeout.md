---
uid: Correlation_Tutorial_Element_Timeout
---

# Responding to element timeouts using Correlation

In this tutorial, you will learn how to use Correlation to take action when an element is in timeout for longer than 5 minutes.

Expected duration: 15 minutes

The tutorial consists of the following steps:

- [Responding to element timeouts using Correlation](#responding-to-element-timeouts-using-correlation)
    - [Step 1: Create the setup needed for this tutorial](#step-1-create-the-setup-needed-for-this-tutorial)
      - [Step 1.1: Lookup the "Correlation KATA Switch Timeout" item from the DataMiner Catalog](#step-11-lookup-the-correlation-kata-switch-timeout-item-from-the-dataminer-catalog)
      - [Step 1.2: Deploy the item](#step-12-deploy-the-item)
    - [Step 2: Create the Correlation rule](#step-2-create-the-correlation-rule)
      - [Step 2.1: Add an alarm filter that filters on alarms from the element "Network Switch"](#step-21-add-an-alarm-filter-that-filters-on-alarms-from-the-element-network-switch)
      - [Step 2.2: Add a Rule Condition that triggers when the Severity is equal to Timeout](#step-22-add-a-rule-condition-that-triggers-when-the-severity-is-equal-to-timeout)
      - [Step 2.3: Select the "Persistent event" trigger mechanism and fill in 5 minutes](#step-23-select-the-persistent-event-trigger-mechanism-and-fill-in-5-minutes)
      - [Step 2.4: Add the RunScript action and select the "Generate Information Event (network switch timed out)" script](#step-24-add-the-runscript-action-and-select-the-generate-information-event-network-switch-timed-out-script)
      - [Step 2.5: Add the Send email action (optional)](#step-25-add-the-send-email-action-optional)
      - [Step 2.6: Add other rule actions (optional)](#step-26-add-other-rule-actions-optional)
    - [Step 3: Go to the element "Network Switch" and generate a timeout](#step-3-go-to-the-element-network-switch-and-generate-a-timeout)
    - [Step 4: Five minutes after the element went into timeout, verify whether the rule actions were executed](#step-4-five-minutes-after-the-element-went-into-timeout-verify-whether-the-rule-actions-were-executed)
  - [Getting those sweet DevOps points](#getting-those-sweet-devops-points)
  - [Summary](#summary)

### Step 1: Create the setup needed for this tutorial

#### Step 1.1: Lookup the "Correlation KATA Switch Timeout" item from the DataMiner Catalog

See [looking up an item in the catalog](xref:Looking_up_an_item_in_the_catalog).

#### Step 1.2: Deploy the item

See [deploying a catalog item](xref:Deploying_a_catalog_item).

### Step 2: Create the Correlation rule

Correlation can be found in DataMiner Cube under Apps > Modules > Correlation.

#### Step 2.1: Add an alarm filter that filters on alarms from the element "Network Switch"

See [filtering and grouping base alarms for Correlation rules](xref:Filtering_and_grouping_base_alarms_for_Correlation_rules) for more information.

#### Step 2.2: Add a Rule Condition that triggers when the Severity is equal to Timeout

See [adding rule conditions in Correlation rules](xref:Adding_rule_conditions_in_Correlation_rules) for more information.

#### Step 2.3: Select the "Persistent event" trigger mechanism and fill in 5 minutes

The Correlation Rule will wait until the rule conditions are met for 5 minutes before acting and executing its actions.
See [adding rule conditions in Correlation rules](xref:Adding_rule_conditions_in_Correlation_rules) for more information.

#### Step 2.4: Add the RunScript action and select the "Generate Information Event (network switch timed out)" script

This automation script will generate an information event when executed. Note that these scripts also can do other things.
See [adding a RunScript action](xref:Running_an_Automation_script_from_a_Correlation_rule) for more information.

#### Step 2.5: Add the Send email action (optional)

See [sending an email](xref:Sending_an_email) for more information on how to do this.
Note that this is optional for completing the tutorial.

#### Step 2.6: Add other rule actions (optional)

For more information on how to add rule actions, go to [adding rule actions in Correlation rules](xref:Adding_rule_actions_in_Correlation_rules).
Note that this is optional for completing the tutorial.

[!NOTE]
Make sure to have a look at some [best practices when making Correlation Rules](xref:Best_Practices_When_Creating_Correlation_Rules).
Correlation is a powerful tool but can impact your system if setup in the wrong way.

### Step 3: Go to the element "Network Switch" and generate a timeout

Note that the element will not get the Timeout alarm for 30s after clicking the button "Generate Timeout" because if an element does not respond, DataMiner 
by default waits 30s before generating a Timeout alarm for the element.

### Step 4: Five minutes after the element went into timeout, verify whether the rule actions were executed

If configured correctly, you should see an information event in the Alarm Console generated by the automation script the Correlation rule triggers.
If you added the Send email action to the Correlation rule and you have a mail server configured, you should have received a mail.

## Getting those sweet DevOps points 

Take a screenshot of your Correlation Rule and Alarm Console displaying the generated information event. Submit it on Dojo and receive 75 DevOps Points. 
An extra 75 DevOps Points are awarded if you manage to complete the challenge within the week after the tutorial released (10 May 2024).

## Summary

This Correlation Rule will take alarms from the element "Network Switch". 
If the element is in timeout for longer than 5 minutes, the Rule will take action. An automation script will generate an information event and DataMiner will send an email.
