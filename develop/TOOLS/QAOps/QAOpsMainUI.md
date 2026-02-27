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

As a QAOps User, you use the *QAOps User* application.

This application contains three main pages, which you can select in the navigation pane on the left: [Overview](#qaops-user-overview), [Configuration](#qaops-user-configurations), and [Tokens](#qaops-user-tokens).

### QAOps user overview

The *Overview* page provides a high-level overview of all known configurations, test suites, servers, and active test runs in the QAOps system.

When you request a new test run, the *Overview* page is the first place where you can confirm that QAOps has received your request.

Active test runs are filtered based on the `Tags` attribute included when the test run was requested.

With the filter component at the top of the page, you can filter on these tags to find your test run more easily and to see which configuration, test suite, and server are involved.

![QAOps user overview](~/develop/images/QAOps_UI_User_Overview.png)

### QAOps user configurations

The *Configurations* page displays test run results, organized by configuration and test suite.

By selecting your configuration and test suite, you can quickly filter and browse test runs to view both detailed test results and summary metrics in the top-right corner.

You can also see which server was used to run these tests, unless that server has already been undeployed.

Server information allows you to use RDP to investigate failed tests directly on the machine where they were executed.

![QAOps user test results by configuration and test suite](~/develop/images/QAOps_UI_User_TestResults_In_Configuration_And_TestSuite.png)

### QAOps user tokens

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

As a QAOps operator, you manage configurations and test suites by using the *QAOps Operator* application.

This application is intended to view, create, and edit all configurations, test suites, running tests, and global categories.

Deletion of these items is not available in this application and must be done by a QAOps Administrator in the *QAOps Administrator* application.

Contact a QAOps Administrator if something must be deleted.

This application contains four main sections, which you can select from the left-side navigation.

### QAOps operator configurations

This section shows all known configurations and their setup.

When you select a configuration, an overview of all known servers is shown on the right.

On this page, you can also manually attempt to deploy an extra DaaS for a configuration.

To do this, click the dark blue button with an upward-facing arrow.

You can click this button multiple times to start several deployments.

![QAOps operator configurations](~/develop/images/QAOps_UI_Configurations.png)

> [!IMPORTANT]
> It can take up to 10 seconds before deployments begin and become visible in the low-code app.

#### QAOps operator configurations edit mode

For security reasons, all editing is hidden behind *Edit Mode*, which you can click at the bottom right of the page.

This opens a table view of all configurations with editable columns.

When you finish making changes, select *Update* in the *Actions* column.

This pushes your changes through the QAOps system.

For more information about available settings, see [QAOps configuration](xref:QAOps_Configuration).

You can move between different pages without losing your changes.

This is convenient when you need to find test suite IDs and then return to configuration edit mode to continue setup.

![QAOps operator edit mode with Update button](~/develop/images/QAOps_UI_EditMode_Update_Button.png)

### QAOps operator test suites

This section shows all known test suites.

When you select a test suite, you also get an overview of all [test packages](xref:QAOps_Test_Package) in that test suite.

Each package shows a number in the top-right corner that indicates the execution order when the test suite is activated.

Each package includes an *Open* button that opens the Catalog information for that package.

On this page, you can also find the QAOps package identifiers, which are different from Catalog identifiers.

The QAOps package identifier is used when [triggering a test run with an unreleased test package](xref:QAOps_Tutorials_User_Tutorials_Advanced_Trigger_Test_Run_With_Unreleased_Test_Package).

![QAOps operator test suites](~/develop/images/QAOps_UI_TestSuites.png)

#### QAOps operator test suites edit mode

For security reasons, all editing is hidden behind *Edit Mode*, which you can click at the bottom right of the page.

This opens a table view of all test suites with editable columns.

When you finish making changes, select *Update* in the *Actions* column.

This pushes your changes through the QAOps system.

For more information about available settings, see [QAOps test suites](xref:QAOps_Test_Suite).

You can move between different pages without losing your changes.

This is convenient when you need to find test suite IDs and then return to configuration edit mode to continue setup.

This page can also be used to add new test packages to a test suite.

Select the test suite in the top table.

This filters the lower table to show all known test packages included in that test suite.

Enter a value in *Add Catalog ID to selected test suite*, and then click the erlenmeyer button.

### Running Tests

This section shows a table with all known test requests.

It is mostly intended as an alternative to the *Overview* page in the *QAOps User* application.

### Global Categories

This section allows you to add or adjust known global categories.

![QAOps global categories](~/develop/images/QAOps_UI_GlobalCategories.png)

These categories appear as buttons in the top banner of the *QAOps User* and *QAOps Operator* applications and can reduce UI clutter by filtering specific configurations and test suites.

This is currently the only section in the *QAOps Operator* application that allows deletion.

> [!IMPORTANT]
> Do not adjust or delete *All* with ULID *00000000000000000000000000*.
