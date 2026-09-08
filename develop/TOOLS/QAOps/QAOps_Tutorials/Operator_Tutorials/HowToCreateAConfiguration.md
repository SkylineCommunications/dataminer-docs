---
uid: QAOps_Tutorials_Operator_Tutorials_How_To_Create_A_Configuration
description: Learn how to create a QAOps-hosted configuration in the QAOps Operator app, from choosing test suites and run retention to provisioning DaaS servers.
---

# Creating a QAOps configuration

> [!IMPORTANT]
> This section includes information that is only applicable to Skyline employees.

In this tutorial, you will learn how to create a new [QAOps configuration](xref:QAOps_Configuration) with the QAOps Operator app. You will create a **QAOps-hosted** configuration, where QAOps provisions DaaS servers for you. To create a configuration that uses your own servers instead, see [Adding self-hosted DataMiner servers](xref:QAOps_Tutorials_Operator_Tutorials_How_To_Add_Self_Hosted_Servers).

Expected duration: 10 minutes.

## Prerequisites

- Operator access to the [QAOps Operator app](xref:QAOps_Main_UI#qaops-operator-app) (the blue app).

- At least one existing [test suite](xref:QAOps_Test_Suite). If you do not have one yet, first follow the [Creating and managing test suites](xref:QAOps_Tutorials_Operator_Tutorials_How_To_Manage_Test_Suites) tutorial.

## Overview

- [Step 1: Open the Create Configuration dialog](#step-1-open-the-create-configuration-dialog)

- [Step 2: Choose the configuration type and enter the basics](#step-2-choose-the-configuration-type-and-enter-the-basics)

- [Step 3: Select the allowed test suites and run retention](#step-3-select-the-allowed-test-suites-and-run-retention)

- [Step 4: Configure QAOps-hosted provisioning](#step-4-configure-qaops-hosted-provisioning)

- [Step 5: Save the configuration](#step-5-save-the-configuration)

## Step 1: Open the Create Configuration dialog

1. In the QAOps Operator app, go to the *Configurations* page using the navigation pane on the left.

   ![QAOps Operator Configurations page](~/develop/images/QAOps_Operator_ConfigurationsPage.png)

1. Scroll to the bottom of the list of configuration cards.

1. Click the wide blue button with the **⊕** icon below the last card.

   The *Create Configuration* dialog will open, and a unique configuration ID (ULID) will be generated automatically.

   ![Create Configuration dialog](~/develop/images/QAOps_Operator_CreateConfiguration_Empty.png)

## Step 2: Choose the configuration type and enter the basics

1. Open the *Configuration Type* dropdown box, and select *QAOps-hosted*.

   ![Configuration Type dropdown](~/develop/images/QAOps_Operator_CreateConfiguration_TypeDropdown.png)

   - *QAOps-hosted*: QAOps deploys and manages DaaS servers to run your tests. This is the most common choice.

   - *Self-hosted*: You connect your own DataMiner servers to QAOps. See [Adding self-hosted DataMiner servers](xref:QAOps_Tutorials_Operator_Tutorials_How_To_Add_Self_Hosted_Servers).

1. Enter a *Name* for the configuration. For example, the name of your project or solution.

1. Enter a *Description* that tells other operators what this configuration is used for.

   ![Create Configuration dialog with basics filled in](~/develop/images/QAOps_Operator_CreateConfiguration_Filled.png)

## Step 3: Select the allowed test suites and run retention

1. Under *Test Suites*, select the checkbox of every test suite that is allowed to run on this configuration.

   You can use the *Filter Test Suites* box to quickly find a test suite by name.

   > [!IMPORTANT]
   > Removing a test suite later will completely clear the current test run history for this configuration from process memory. Only select the test suites you need.

1. In the *Test Runs To Keep* box, enter how many test runs (and their results) QAOps should keep in memory for this configuration.

   Set this to the lowest number you need to validate your quality gates and debug issues. Keep the product of the number of test suites and the number of test runs to keep well below 500. The maximum is 499.

1. Under *Global Categories*, optionally select one or more categories (e.g., *Standard Solutions*).

   These categories power the filter buttons in the header bar of the QAOps apps, making your configuration easier to find.

## Step 4: Configure QAOps-hosted provisioning

Because you selected *QAOps-hosted*, the dialog will show a *QAOps-Hosted Provisioning* section.

![QAOps-hosted provisioning section](~/develop/images/QAOps_Operator_CreateConfiguration_Provisioning.png)

1. Open the *Provisioning Type* dropdown box, and select how servers should be deployed:

   - *Disabled*: No servers are deployed automatically. You can still deploy servers manually with the deploy button on the configuration card.

   - *Pre-Deployed Pool*: QAOps always tries to keep a minimum number of servers available. As soon as one is used, a new one is deployed in the background. Use this for setups that need fast feedback throughout the day.

   - *On Test Deployment*: A server is deployed when a test run request comes in. This is a good fit for daily CI/CD pipelines.

1. Set *Maximum Servers* (the number of running servers will never exceed this) and *Minimum Servers* (the pool size that *Pre-Deployed Pool* provisioning tries to maintain).

1. Open the *DataMiner Version Type* dropdown box, and select which DataMiner version the deployed servers should run.

   ![DataMiner Version Type dropdown](~/develop/images/QAOps_Operator_CreateConfiguration_VersionType.png)

   For most projects, choose *Feature* (latest feature release, recommended for stable testing), *RC* (upcoming release candidate, for early compatibility checks), or *Main* (latest released version). The *(DaaS Candidate)*, *Experimental DaaS*, and *Internal Feature* options are intended for the DaaS team. See [QAOps configurations](xref:QAOps_Configuration) for details on each option.

## Step 5: Save the configuration

1. At the bottom of the dialog, click *Save Configuration*.

1. Watch the *Status* box below the button. It will indicate whether the configuration was created successfully.

1. Close the dialog by clicking the **X** in the upper-right corner.

Your new configuration will appear as a card on the *Configurations* page.

> [!NOTE]
> If you want to fully remove a configuration, contact a QAOps Administrator. The QAOps Operator app does not allow you to do this.

## Next steps

- [Updating a configuration](xref:QAOps_Tutorials_Operator_Tutorials_How_To_Update_A_Configuration)

- [Creating and managing test suites](xref:QAOps_Tutorials_Operator_Tutorials_How_To_Manage_Test_Suites)

- [Triggering a test run](xref:QAOps_Tutorials_User_Tutorials_Basic_How_To_Trigger_A_Test_Run)
