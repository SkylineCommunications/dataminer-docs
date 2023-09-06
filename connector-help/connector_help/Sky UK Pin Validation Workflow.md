---
uid: Connector_help_Sky_UK_Pin_Validation_Workflow
---

# Sky UK Pin Validation Workflow

This driver is used by enhanced services that contain elements of the protocol [Sky UK Pin Validation](xref:Connector_help_Sky_UK_Pin_Validation). With this driver, alarms are generated according to predefined rules.

## About

To use this driver, create a service that uses it as the service definition, add the necessary element and select the parameters mentioned below.

### Ranges of the driver

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | Initial Version.            |

## Installation and configuration

### Creation

#### service Main Connection

This driver uses a service connection and requires the following input during element creation:

SERVICE CONNECTION:

Elements/Parameters:

- [Sky UK Pin Validation](xref:Connector_help_Sky_UK_Pin_Validation)

- **PIN Protection**
  - **PIN Unexpectedly Present**
  - **Service Encryption Status**

## Usage

### Alarms

This page displays the **Alarm List Table** and the **Penalty Box Table**. Both tables displays the **Cause**, **Alarm State**, **Suggested Action**and **Alarm Target UI.**

### Device Data

This page displays the current values of the subscribed parameters that are taken into account on the Workflow.

### Subscriptions Active

Table with subscribed parameters of the service.
