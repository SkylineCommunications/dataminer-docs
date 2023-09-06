---
uid: Connector_help_Skyline_Regression_Test_Result_Collector
---

# Skyline Regression Test Result Collector

The Skyline Regression Test Result Collector is a connector that will aggregate the results from regression tests that are run using the Regression Test Runner Automation script. This script provides a UI for users to manually run a subset of regression tests. It can also be run without user interaction, for example through a scheduled task.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                  | **Exported Components** |
|-----------|---------------------|-------------------------|----------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | RegressionTestRunner Automation script | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

No additional configuration of parameters is necessary in a newly created element.

### Redundancy

No redundancy is defined in the connector.

## How to Use

Whenever a regression test is run using the Regression Test Runner script, the results of the test will be pushed to an element running this connector.
