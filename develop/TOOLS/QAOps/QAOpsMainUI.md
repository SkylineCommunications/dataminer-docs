---
uid: QAOps_Main_UI
---

# QAOps main UI

> [!IMPORTANT]
> This section contains information that is only applicable to Skyline employees.

You can access the QAOps system at Skyline Communications by using the following links:

- [QAOps production](https://qaops-skyline.on.dataminer.services/root/)

- [QAOps staging](https://qaopsstaging-skyline.on.dataminer.services/root/)

Three applications are available, listed in order of increasing security level:

- [QAOps User](#qaops-user-app) (green app)

- [QAOps Operator](#qaops-operator-app) (blue app)

- QAOps Administrator (red app)

## QAOps User app

As a QAOps User, you use the **QAOps User** application.

This application contains three main pages, which you can select in the navigation pane on the left: [Overview](#qaops-user---overview), [Configuration](#qaops-user---configurations), and [Tokens](#qaops-user---tokens).

> [!TIP]
> To get started with a first quick tour of the app, follow the tutorial [Getting started with the QAOps User app](xref:QAOps_Tutorials_User_Tutorials_Basic_What_Is_QAOps).

### QAOps User - Overview

The *Overview* page provides a high-level overview of all known configurations, test suites, servers, and active test runs in the QAOps system.

When you request a new test run, the *Overview* page is the first place where you can confirm that QAOps has received your request.

Active test runs are filtered based on the `Tags` attribute included when the test run was requested.

With the filter component at the top of the page, you can filter on these tags to find your test run more easily and to see which configuration, test suite, and server are involved.

![QAOps user overview](~/develop/images/QAOps_UI_User_Overview.png)

### QAOps User - Configurations

The *Configurations* page displays test run results, organized by configuration and test suite.

By selecting your configuration and test suite, you can quickly filter and browse test runs to view both detailed test results and summary metrics in the top-right corner.

You can also see which server was used to run these tests, unless that server has already been undeployed.

Server information allows you to use RDP to investigate failed tests directly on the machine where they were executed.

![QAOps user test results by configuration and test suite](~/develop/images/QAOps_UI_User_TestResults_In_Configuration_And_TestSuite.png)

### QAOps User - Tokens

The *Tokens* page allows you to create tokens that can be used to trigger test runs by using the [QAOps DotNet Tool](xref:QAOps_Tool).

To create a new token:

1. Select *Create Token* in the top-left corner.

1. Provide a name and expiration date for the token.

1. Optionally, disable *Unlimited Token Usage* and enter a maximum number of token uses.

1. Select one or more scopes for the token.

   These scopes determine which configurations are used for the test runs. At least one must be selected, as otherwise the token cannot trigger test execution.

   ![Fields to fill in when creating a token in the QAOps User app](~/develop/images/QAOps_User_CreateToken.png)

1. Click *Generate Token*.

1. Wait a few seconds while QAOps prepares the token.

1. When the token is displayed, **copy and save the token value immediately**, because this will be the only time it is shown.

## QAOps Operator app

As a QAOps operator, you manage configurations and test suites using the **QAOps Operator** application. This application is intended to view, create, and edit all configurations, test suites, running tests, and global categories.

However, deleting these items is not possible in the app. This must be done by a QAOps Administrator in the *QAOps Administrator* application.

This application contains four main pages, which you can select in the navigation pane on the left: [Configurations](#qaops-operator---configurations), [Test Suites](#qaops-operator---test-suites), [Running Tests](#qaops-operator---running-tests), and [Global Categories](#qaops-operator---global-categories).

This QAOps Operator application contains four main sections, which you can select from the left-side navigation.

### QAOps Operator - Configurations

The *Configurations* page shows all known configurations and their setup.

When you select a configuration, an overview of all known servers is shown on the right.

On this page, you can also manually attempt to deploy an extra DaaS for a configuration. To do so, click the dark blue button with an upward-facing arrow. You can click this button multiple times to start several deployments.

![QAOps operator configurations](~/develop/images/QAOps_UI_Configurations.png)

> [!NOTE]
> It can take up to 10 seconds before deployments begin and become visible in the low-code app.

#### Editing configurations

For security reasons, you will only be able to access editing functionality after you go to *Edit Mode* by clicking the button in the lower-right corner. This will open a table view of all configurations with editable columns.

When you finish making changes, select *Update* in the *Actions* column. This pushes your changes through the QAOps system.

For more information about available settings, see [QAOps configuration](xref:QAOps_Configuration).

Note that you can go to different pages without losing your changes. This can for example be convenient when you need to find test suite IDs and then return to configuration edit mode to continue your setup.

![QAOps operator edit mode with Update button](~/develop/images/QAOps_UI_EditMode_Update_Button.png)

### QAOps Operator - Test Suites

The *Test Suites* page shows all known test suites. When you select a test suite, you will also get an overview of all [test packages](xref:QAOps_Test_Package) in that test suite.

Each test package shows a number in the top-right corner that indicates the execution order when the test suite is activated. With the *Open* button for a test package, you can go directly to the Catalog page for that package.

![QAOps operator test suites](~/develop/images/QAOps_UI_TestSuites.png)

Each package also shows its QAOps package identifier, which is different from its Catalog identifier. For example:

![QAOps package identifier](~/develop/images/QAOps_TestSuites_package_identifier.png)

The QAOps package identifier is used when [triggering a test run with an unreleased test package](xref:QAOps_Tutorials_User_Tutorials_Advanced_Creating_Test_Packages).

#### Editing test suites

For security reasons, you will only be able to access editing functionality after you go to *Edit Mode* by clicking the button in the lower-right corner. This will open a table view of all test suites with editable columns.

When you finish making changes, select *Update* in the *Actions* column. This pushes your changes through the QAOps system.

For more information about available settings, see [QAOps test suites](xref:QAOps_Test_Suite).

Note that you can go to different pages without losing your changes. This can for example be convenient when you need to find global category instances and then return to test suites edit mode to continue your setup.

You can also add new test packages to a test suite here:

1. Select the test suite in the table at the top.

   This filters the lower table to show all known test packages included in that test suite.

1. Specify the Catalog ID of the test package in the *Add Catalog ID to selected test suite* box.

1. Click the ![erlenmeyer button](~/develop/images/QAOps_Erlenmeyer.png) button to add the package.

### QAOps Operator - Running Tests

The *Running Tests* page shows a table with all known test requests.

This page is intended as an alternative to the *Overview* page in the *QAOps User* application.

### QAOps Operator - Global Categories

The *Global Categories* page allows you to add or adjust known global categories.

![QAOps global categories](~/develop/images/QAOps_UI_GlobalCategories.png)

These categories are shown as buttons in the header bar of the *QAOps User* and *QAOps Operator* applications and can reduce UI clutter by filtering specific configurations and test suites.

This is currently the only section in the *QAOps Operator* application that allows deletion.

> [!IMPORTANT]
> Do not adjust or delete *All* with ULID *00000000000000000000000000*.
