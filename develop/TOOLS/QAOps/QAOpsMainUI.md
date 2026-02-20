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

- QAOps User (green app)

- QAOps Operator (blue app)

- QAOps Administrator (red app)

## QAOps user

As a QAOps User, you use the *QAOps User* application.

This application contains three main sections, which you can select from the left-side navigation.

### QAOps user overview

This section provides a high-level overview of all known configurations, test suites, servers, and active test runs in the QAOps system.

When you request a new test run, the *Overview* page is the first place where you can confirm that QAOps has received your request.

Active test runs are filtered based on the *Tags* attribute included when the test run was requested.

You can use this tag with the filter component at the top of the page to find your test run more easily and to see which configuration, test suite, and server are involved.

### QAOps user configurations

This section displays test run results, organized by configuration and test suite.

By selecting your configuration and test suite, you can quickly filter and browse test runs to view both detailed test results and summary metrics in the top-right corner.

You can also see which server was used to run these tests, unless that server has already been undeployed.

Server information allows you to use RDP to investigate failed tests directly on the machine where they were executed.

### QAOps user tokens

This section allows you to create tokens that can be used to trigger test runs by using the [QAOps DotNet Tool](QAOps_Tool).

At the top left of the banner, select *Create Token* to create a new token.

You must provide a name and expiration date.

Optionally, you can disable *Unlimited Token Usage* and enter a maximum number of token uses.

Each token can be scoped to allow test runs only on specific configurations.

> [!IMPORTANT]
> You must select one or more scopes. Otherwise, the token cannot trigger test execution.

After you create the token, wait a few seconds while QAOps prepares it.

The token appears after a short delay.

Copy and save the token value immediately, because this is the only time it is shown.

## QAOps operator

As a QAOps Operator, you manage configurations and test suites by using the *QAOps Operator* application.

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

> [!IMPORTANT]
> It can take up to 10 seconds before deployments begin and become visible in the low-code app.

#### QAOps operator configurations edit mode

For security reasons, all editing is hidden behind *Edit Mode*, which you can click at the bottom right of the page.

This opens a table view of all configurations with editable columns.

When you finish making changes, select *Update* in the *Actions* column.

This pushes your changes through the QAOps system.

For more information about available settings, see [QAOps configuration](QAOps_Configuration).

You can move between different pages without losing your changes.

This is convenient when you need to find test suite IDs and then return to configuration edit mode to continue setup.

### QAOps operator test suites

This section shows all known test suites.

When you select a test suite, you also get an overview of all [test packages](QAOps_Test_Package) in that test suite.

Each package shows a number in the top-right corner that indicates the execution order when the test suite is activated.

Each package includes an *Open* button that opens the Catalog information for that package.

On this page, you can also find the QAOps package identifiers, which are different from Catalog identifiers.

The QAOps package identifier is used when [triggering a test run with an unreleased test package](QAOps_Tutorials_User_Tutorials_Advanced_Trigger_Test_Run_With_Unreleased_Test_Package).

#### QAOps operator test suites edit mode

For security reasons, all editing is hidden behind *Edit Mode*, which you can click at the bottom right of the page.

This opens a table view of all test suites with editable columns.

When you finish making changes, select *Update* in the *Actions* column.

This pushes your changes through the QAOps system.

For more information about available settings, see [QAOps test suites](QAOps_Test_Suite).

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

These categories appear as buttons in the top banner of the *QAOps User* and *QAOps Operator* applications and can reduce UI clutter by filtering specific configurations and test suites.

This is currently the only section in the *QAOps Operator* application that allows deletion.

> [!IMPORTANT]
> Do not adjust or delete *All* with ULID *00000000000000000000000000*.
