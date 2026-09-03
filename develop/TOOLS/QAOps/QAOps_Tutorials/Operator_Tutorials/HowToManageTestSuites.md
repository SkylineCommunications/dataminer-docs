---
uid: QAOps_Tutorials_Operator_Tutorials_How_To_Manage_Test_Suites
description: Learn how to create a QAOps test suite, add test packages from the DataMiner Catalog, and manage the packages with the QAOps Operator app.
---

# Creating and managing test suites

> [!IMPORTANT]
> This section includes information that is only applicable to Skyline employees.

In this tutorial, you will learn how to create a [QAOps test suite](xref:QAOps_Test_Suite), add [test packages](xref:QAOps_Test_Package) to it from the DataMiner Catalog, and manage the packages (reorder, open, remove) with the QAOps Operator app.

Expected duration: 15 minutes.

## Prerequisites

- Operator access to the [QAOps Operator app](xref:QAOps_Main_UI#qaops-operator-app) (the blue app).

- The Catalog ID of at least one test package published in the [DataMiner Catalog](https://catalog.dataminer.services/browse?t=Test%20Package). To create your own test package, see [Creating a test package](xref:QAOps_Tutorials_User_Tutorials_Advanced_Creating_Test_Packages).

## Overview

- [Step 1: Explore the Test Suites page](#step-1-explore-the-test-suites-page)

- [Step 2: Create a test suite](#step-2-create-a-test-suite)

- [Step 3: Add a test package from the Catalog](#step-3-add-a-test-package-from-the-catalog)

- [Step 4: Manage the packages in a test suite](#step-4-manage-the-packages-in-a-test-suite)

- [Step 5: Allow the test suite on a configuration](#step-5-allow-the-test-suite-on-a-configuration)

## Step 1: Explore the Test Suites page

1. In the QAOps Operator app, go to the *Test Suites* page using the navigation pane on the left.

   ![Test Suites page](~/develop/images/QAOps_Operator_TestSuitesPage.png)

1. Select a test suite card.

   The *Catalog Test Packages* panel on the right shows every test package in the suite. The number in the upper-right corner of each package card is its execution order. The *Open* button takes you to the package's Catalog page.

   ![Test suite with its packages](~/develop/images/QAOps_Operator_TestSuite_Packages.png)

## Step 2: Create a test suite

1. Scroll to the bottom of the test suite card list, and click the **⊕** button.

   The *Create QAOps Test Suite* dialog will open with an automatically generated *Test Suite ID* (ULID).

   ![Create Test Suite dialog](~/develop/images/QAOps_Operator_CreateTestSuite_Empty.png)

1. Enter a *Name* and a *Description*.

1. Optionally select one or more *Global Categories* to make the suite easier to find with the header bar filter buttons.

   ![Create Test Suite dialog filled in](~/develop/images/QAOps_Operator_CreateTestSuite_Filled.png)

1. Click *Create Test Suite*.

   The *Status* box will confirm with *Test Suite created. Package selection is now available.*, and the button will change to *Save Test Suite* for further edits.

   ![Test suite created status](~/develop/images/QAOps_Operator_CreateTestSuite_Created.png)

## Step 3: Add a test package from the Catalog

After the suite is created, the *Test Package Selection* section will become available in the same dialog box.

1. If you do not know the Catalog ID of your test package yet, click *Browse Catalog*.

   This will open the DataMiner Catalog filtered on test packages in a new tab. Open your package there, and copy its Catalog ID (a GUID) from the page URL or details.

1. Paste the GUID in the *Catalog ID* box.

1. Keep *Version* set to `*` to always use the latest stable version, or enter a version filter. The version filter accepts NuGet-style wildcards, e.g., `1.2.*`; see [version filters for test packages](xref:QAOps_Main_UI#version-filters-for-test-packages).

1. Set *Allow Prerelease* to *Yes* if prerelease versions may be used.

   ![Add package fields filled in](~/develop/images/QAOps_Operator_TestSuite_AddPackage.png)

1. Click *Add Package*.

   The *Status* box will confirm with *Test Package added.*, and the package will appear in the table.

   ![Package added confirmation](~/develop/images/QAOps_Operator_TestSuite_PackageAdded.png)

## Step 4: Manage the packages in a test suite

You can manage packages of an existing suite at any time. On the *Test Suites* page, click the gear icon on the suite card to open the *Edit QAOps Test Suite* dialog box.

![Edit Test Suite dialog](~/develop/images/QAOps_Operator_EditTestSuite.png)

In the package table at the bottom of the dialog:

![Package row with actions](~/develop/images/QAOps_Operator_TestSuite_PackageRow.png)

- The **#** column will show the execution order in which packages will run when the suite is triggered.

- Use the **▲** and **▼** buttons to move a package up or down in the execution order.

- Click *Open* to go to the package's Catalog page.

- Click *Remove* to remove the package from the suite.

When you are done, click *Save Test Suite*, and check the *Status* box for confirmation.

> [!IMPORTANT]
> Deleting an entire test suite is something only a QAOps Administrator is allowed to do. Click the *Remove Test Suite* button to request a removal. Be aware that removing a suite that is still allowed on a configuration will clear that configuration's test run history.

## Step 5: Allow the test suite on a configuration

A test suite only runs on configurations that explicitly allow it:

1. Go to the *Configurations* page.

1. Click the gear icon on your configuration card.

1. Under *Test Suites*, select the checkbox of your new suite.

1. Click *Save Configuration*.

> [!IMPORTANT]
> Adding a test suite to an existing configuration is an impactful operation that you cannot undo yourself. If you are not sure, create a new configuration, and add the test suite there. See [QAOps test suites](xref:QAOps_Test_Suite).

## Next steps

- [Creating a QAOps configuration](xref:QAOps_Tutorials_Operator_Tutorials_How_To_Create_A_Configuration)

- [Triggering a test run](xref:QAOps_Tutorials_User_Tutorials_Basic_How_To_Trigger_A_Test_Run)
