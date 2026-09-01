---
uid: QAOps_Tutorials_Operator_Tutorials_How_To_Update_A_Configuration
description: Learn how to update an existing QAOps configuration with the Edit Configuration dialog or make quick inline edits across configurations in Table Mode.
---

# Updating a QAOps configuration

> [!IMPORTANT]
> This section includes information that is only applicable to Skyline employees.

In this tutorial, you will learn the two ways to update an existing [QAOps configuration](xref:QAOps_Configuration) in the QAOps Operator app: with the *Edit Configuration* dialog on a configuration card, and with *Table Mode* for quick inline edits across many configurations.

Expected duration: 10 minutes.

## Prerequisites

- Operator access to the [QAOps Operator app](xref:QAOps_Main_UI#qaops-operator-app) (the blue app).

- An existing configuration you are allowed to change. If you do not have one, first follow [Creating a QAOps configuration](xref:QAOps_Tutorials_Operator_Tutorials_How_To_Create_A_Configuration).

## Overview

- [Step 1: Open the Edit Configuration dialog](#step-1-open-the-edit-configuration-dialog)

- [Step 2: Change the settings and save](#step-2-change-the-settings-and-save)

- [Step 3: Update configurations in Table Mode](#step-3-update-configurations-in-table-mode)

## Step 1: Open the Edit Configuration dialog

1. In the QAOps Operator app, go to the *Configurations* page.

1. Locate the card of the configuration you want to change. Scroll through the card list if needed.

1. Click the gear icon next to the configuration name on the card.

   The *Edit Configuration* dialog opens, pre-filled with the current settings. The *Status* box at the bottom shows *Editing existing configuration*.

   ![Edit Configuration dialog](~/develop/images/QAOps_Operator_EditConfiguration.png)

## Step 2: Change the settings and save

1. Adjust the settings you need. The fields are the same as when creating a configuration; see [QAOps configurations](xref:QAOps_Configuration) for the meaning of each setting.

   > [!IMPORTANT]
   >
   > - Removing a test suite or reducing *Test Runs To Keep* will completely clear the current test-run history for this configuration from process memory.
   > - Changing the *Configuration Type* is an impactful operation: switching away from *QAOps-hosted* undeploys the hosted servers, and switching away from *Self-hosted* removes the registered self-hosted servers.

1. Click *Save Configuration* at the bottom of the dialog.

1. Verify in the *Status* box that the update was accepted.

1. Close the dialog with the **X** in the upper-right corner.

## Step 3: Update configurations in Table Mode

For quick changes to individual fields, or to edit several configurations in one place, use Table Mode:

1. On the *Configurations* page, scroll down and click the *Table Mode* button in the lower-right corner.

   A table view of all configurations opens, with a *Servers* table below it.

   ![Table Mode](~/develop/images/QAOps_Operator_TableMode.png)

1. Use the magnifying glass in the upper-right corner of the table to search for your configuration by name.

1. Click the pencil icon next to the value you want to change (for example, the description).

   The cell becomes editable, with a confirm (✓) and cancel (✗) button next to it.

   ![Inline editing a description in Table Mode](~/develop/images/QAOps_Operator_TableMode_EditDescription.png)

1. Enter the new value and click the **✓** button to push the change through the QAOps system.

> [!TIP]
> You can navigate to other pages without losing unconfirmed table changes. This is convenient when you need to look up a test suite ID or a global category and then return to finish your edit.

## Next steps

- [Creating and managing test suites](xref:QAOps_Tutorials_Operator_Tutorials_How_To_Manage_Test_Suites)

- [Adding self-hosted DataMiner servers](xref:QAOps_Tutorials_Operator_Tutorials_How_To_Add_Self_Hosted_Servers)
