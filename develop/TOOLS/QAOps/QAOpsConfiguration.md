---
uid: QAOps_Configuration
---

# QAOps configuration

> [!IMPORTANT]
> This section contains information intended only for Skyline employees.

One or more QAOps configurations should be created for your project. Each configuration represents ownership of all testing activities for the project.

![QAOps configuration](../../../images/QAOps_Configuration.png)

A configuration can include multiple [test suites](QAOps_Test_Suite).

A configuration can be individually tailored using several available settings within the QAOps Operator App:

1. **DataMiner version:** The following options are available:

	- RC: The latest known, relatively stable release candidate of the DataMiner platform. Using this version carries some risk of instability, but it allows you to detect and address issues before a new DataMiner version is released. If you suspect that DataMiner code changes are causing test failures, you may contact the Platform Quality Coaches for follow-up.

	- Feature: The latest known feature release of DataMiner. This version is recommended for stable testing, allowing you to focus on new modules, connectors, libraries, DxMs, and other components installed on top of the DataMiner feature release.

	- Main: *Not yet supported* due to DaaS limitations. Support for this version is expected in the future.

	- RC DaaS Candidate: The release candidate of the DataMiner platform that has not passed initial DaaS health tests. Use of this version is not recommended and is primarily intended for the DaaS team.

	- Feature DaaS Candidate: The feature release of the DataMiner platform that has not passed initial DaaS health tests. Use of this version is not recommended and is primarily intended for the DaaS team.

	- Experimental DaaS: A special version of DataMiner that may contain breaking features under test by the DaaS team. Use of this version is not recommended and is primarily intended for the DaaS team.

	- Internal DaaS Candidate: The latest known internal DataMiner version before passing initial DaaS health tests. Use of this version is not recommended and is primarily intended for the DaaS team.


1. **DataMiner type:** Currently, only DaaS is supported. Support for static servers will be added in the future.

1. **Database type:** Currently, only Storage as a Service is supported. Other database options may become available in the future.

1. **Allowed test suites:** This is a comma-separated list of test suite identifiers as defined in the *Operator* app in the *Test Suites* section. Only these test suites are allowed to execute on the configuration.

	> [!IMPORTANT]
	> It is currently not possible to automatically remove test suites once they have been added. You can always add new test suites, but removal is not supported. If you need to remove a test suite and it is critical, contact the BOOST team. Be aware that this may clear the cache of previous test runs kept in memory.

1. **Test runs to keep:** This setting determines how many test runs and their results are kept in memory for fast access. Set this to the lowest number you need to validate your quality gates and debug issues. Currently, QAOps does not provide long-term storage. This feature is planned for Q3 2026.

	> [!IMPORTANT]
	> It is currently not possible to reduce this number. You can increase it, but not decrease it. If you need to reduce the number and it is critical, contact the BOOST team. Be aware that this may clear the cache of previous test runs kept in memory.

	> [!IMPORTANT]
	> Keep the product of the number of test suites and the number of test runs to keep below 1,000. For example, if you keep 100 test runs, you should have 10 test suites or fewer in a single configuration.

1. **Global categories:** This is a semicolon-separated list of category identifiers (defined in the categories table in the *Operator* app). This allows you to filter your configuration in the QAOps low-code apps using the top banner. This setting is optional but recommended if you want to use this filtering feature.


There are also several options for configuring provisioning, which determine how many servers are made available for running tests:

1. **Max total targets:** The total number of running servers for this configuration will never exceed this value, regardless of how you attempt to provision them.

1. **Automatic provisioning:**

	- Disabled: No servers are automatically deployed. You can still manually deploy a server using the *Deploy* button in the *Operator* app.

	- On test deployment: Servers are automatically deployed when a new test run request is received. This is a good setting for daily CI/CD pipelines or configurations that only occasionally need to run test suites.

	- Pre-deployed pool: This configuration always attempts to have a specified number (see *Min total targets*) of servers available. As soon as a server is used, a new one is deployed in the background. This is useful for setups that require fast feedback and frequent test runs throughout the day.

1. **Min total targets:** The total number of active servers a configuration with *Pre-deployed pool* provisioning will try to keep available. This setting is ignored for other provisioning types.

> [!IMPORTANT]
> In the Operator Low-Code App, remember to click the *Update* button in the table when you have finished making changes.
