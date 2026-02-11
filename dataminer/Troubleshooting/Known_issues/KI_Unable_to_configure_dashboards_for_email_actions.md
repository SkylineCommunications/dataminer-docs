---
uid: KI_Unable_to_configure_dashboards_included_in_email_actions
---

# Unable to configure dashboards included in 'Email' actions for automation scripts, scheduled tasks, and correlation rules

## Affected versions

From DataMiner Cube 10.4.0 [CU10]/10.5.0/10.5.1 onwards.

## Cause

In DataMiner Cube 10.4.0 [CU10]/10.5.0/10.5.1 (RN 41364), a new feature was introduced that highlights dashboards that no longer exist by displaying them in red when an *Email* action is edited. However, the user interface may not always reflect updates made in the business logic, leading to occasional inconsistencies. As a result, users might be unable to configure dashboards for the *Email* action.

## Fix

Available from DataMiner Cube 10.4.0 [CU12]/10.5.0/10.5.3<!--RN 42240--> onwards.

## Description

When you select the *Include report or dashboard* option while configuring an *Email* action in an Automation script, scheduled task, or Correlation rule, the *Configure* button, which allows you to open a window where you can further configure the dashboard, is no longer available.

![*Configure* button](~/dataminer/images/Configure_button_missing.png)

This prevents you from successfully implementing *Email* actions that include dashboards.
