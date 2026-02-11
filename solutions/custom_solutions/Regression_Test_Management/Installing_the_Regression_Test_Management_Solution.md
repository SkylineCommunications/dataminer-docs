---
uid: Installing_the_Regression_Test_Management_Solution
---

# Installing the Regression Test Management Solution

## Prerequisites

Before deploying this solution, ensure the following:

- Your system is running DataMiner 10.3.0 or higher.
- Your regression tests are available as automation scripts in DataMiner.

> [!TIP]
> To get started with new regression test scripts, we recommend using the [Regression Test Template on GitHub](https://github.com/SkylineCommunications/Skyline.DataMiner.GithubTemplate.RegressionTest).

## Deploying the solution from the Catalog

1. In the DataMiner Catalog, go to the [Regression Test Management package](https://catalog.dataminer.services/details/27636bb4-e3ce-4a2a-bd28-fe514a4ac5e7).

1. Click *Deploy*, and then select the DataMiner System you want to deploy the package to.

1. Once the deployment finishes:

   - A new view called *Regression Tests* is created.
   - An element named *Regression Test Results* is added to the view.
   - The *Skyline Regression Test Result Collector* connector and Visio file are deployed.
   - The *RegressionTestRunner* Automation script is installed.
   - Default alarm and trend templates are assigned to the element.

   ![Element in the Surveyor](~/solutions/images/Regression_Test_Element_Path.png)

1. In DataMiner Cube, open the *Regression Test Results* element to begin the configuration.

> [!TIP]
> You can relocate or rename the element and view after installation based on your naming conventions.

## Package components

The following components are included in the solution package:

- *Skyline Regression Test Result Collector* connector
- *Regression Test Result Collector Visio* visual overview
- *RegressionTestRunner* Automation script
- Optional default alarm and trend templates for visual feedback and notifications
