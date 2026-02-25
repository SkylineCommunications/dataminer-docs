---
uid: QAOps_Test_Suite
---

# QAOps test suite

> [!IMPORTANT]
> This section contains information intended only for Skyline employees.

A QAOps test suite is a collection of one or more [DataMiner test packages](QAOps_Test_Package).

You run regression tests by running a test suite on a configuration. Over time, you can update the list of test packages in that test suite.

Keep the number of test suites low. It is easier to add or remove test packages in an existing test suite than to change which test suites are allowed to run on a configuration.

All results from one test suite run are collected in a single results table.

By default, when a test suite runs, QAOps retrieves the required test packages from the catalog and then executes them.

With the [QAOps tool](QAOps_Tool), you can override one or more test packages by providing package versions directly in your call instead of retrieving them from the catalog.

> [!IMPORTANT]
> Adding a test suite to an existing configuration is an impactful operation that you cannot undo.
>
> If you are not sure, create a new configuration and add the test suite to that configuration.

A test suite has the following options:

- ID: ULID that uniquely identifies the test suite.

- Name: Name of the test suite.

- Description: Description of the test suite.

- Global categories: Semicolon-separated list of category IDs used for UI filtering.

> [!IMPORTANT]
> In the Operator Low-Code App, remember to click the *Update* button in the table when you have finished making changes.
