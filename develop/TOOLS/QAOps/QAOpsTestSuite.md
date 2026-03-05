---
uid: QAOps_Test_Suite
---

# QAOps test suites

> [!IMPORTANT]
> This section contains information that is only applicable to Skyline employees.

A QAOps test suite is a collection of one or more [DataMiner test packages](xref:QAOps_Test_Package).

You run regression tests by running a test suite on a configuration. Over time, you can update the list of test packages in that test suite.

By default, when a test suite runs, QAOps retrieves the required test packages from the catalog and then executes them.

All results from one test suite run are collected in a single results table.

## Tips for working with test suites

Keep the number of test suites low. It is easier to add or remove test packages in an existing test suite than to change which test suites are allowed to run on a configuration.

With the [QAOps tool](xref:QAOps_Tool), you can override one or more test packages by providing package versions directly in your call instead of retrieving them from the catalog.

> [!IMPORTANT]
> Adding a test suite to an existing configuration is an impactful operation that you cannot undo.
>
> If you are not sure, create a new configuration and add the test suite to that configuration.

## Test suite settings

When you [create or edit a test suite in the QAOps Operator app](xref:QAOps_Main_UI#editing-test-suites), you can adjust the following settings:

- **Name**: Name of the test suite.

- **Description**: Description of the test suite.

- **Global categories**: Semicolon-separated list of category IDs used for UI filtering.

The *ID* column for a test suite contains a ULID that uniquely identifies the test suite. This cannot be adjusted.

> [!IMPORTANT]
> In the QAOps Operator app, remember to click the **Update** button in the table when you have finished making changes.
