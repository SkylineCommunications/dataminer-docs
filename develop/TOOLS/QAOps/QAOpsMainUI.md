---
uid: QAOps_Main_UI
---


# QAOps main UI

> [!IMPORTANT]
> This section contains information that is only applicable to Skyline employees.

You can access the QAOps system at Skyline Communications using the following links:

- [QAOps production](https://qaops-skyline.on.dataminer.services/root/)

- [QAOps staging](https://qaopsstaging-skyline.on.dataminer.services/root/)

There are three applications available, listed in order of increasing security level.

- QAOps User (green app)

- QAOps Operator (blue app)

- QAOps Administrator (red app)

## QAOps User

As a QAOps User, you will use the *QAOps User* application.

This application contains three main sections, which you can select on the left.

### Overview

This section provides a high-level overview of all known configurations, test suites, servers, and any active test runs in the QAOps system. When you request a new test run, the *Overview* page is the first place where you will see confirmation that the QAOps system has received your request.

Active test runs are filtered based on the *Tags* attribute included when the test run was requested. You can use this tag with the filter component at the top to find your test run more easily and to see which configuration, test suite, and server are involved.

### Configurations

This section displays test run results, organized by configuration and test suite.

By selecting your configuration and test suite, you can quickly filter and browse every test run to view both the test results and summary test run metrics in the top right corner. You can also see which server was used to run these tests, unless the server has already been undeployed.

The server information allows you to use RDP to investigate any failed tests directly on the machine where they were executed.

### Tokens

This section allows you to create tokens that can be used to trigger test runs using the [QAOps DotNet Tool](QAOps_Tool).

At the top left, in the banner, select *Create Token* to create a new token.

You must provide a name and expiration date. Optionally, you can disable the *Unlimited Token Usage* toggle button and enter a maximum token usage number.

Each token can be scoped to allow it to trigger test runs only on specific configurations.

**Important:** You must select one or more scopes, or the token will not allow any test execution.

When creating the token, wait a few seconds while the QAOps system prepares it. The token will appear after a short delay. Make sure to copy and save the token value at this time, as this is the only opportunity to view it.

## QAOps Operator

As a QAOps Operator you are in control of configurations and test suites, you will use the *QAOps Operator* application.

This application is intended to see, create and edit all the Configurations, Test Suites, Running Tests and Global Categories.
Deletion of any of these is not possible and must be done by a QAOps Administrator within the Administrator App.

This application contains four main sections, which you can select on the left.