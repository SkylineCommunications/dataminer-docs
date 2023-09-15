---
uid: Connector_help_Sky_UK_Pin_Validation_Workflow
---

# Sky UK Pin Validation Workflow

This connector is used by enhanced services that contain elements of the protocol [Sky UK Pin Validation](xref:Connector_help_Sky_UK_Pin_Validation). With this connector, alarms are generated according to predefined rules.

## About

To use this connector, create a service that uses it as the service definition, add the necessary element and select the parameters mentioned below.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Initial Version.            |

## Installation and configuration

### Creation

#### service Main Connection

This connector uses a service connection and requires the following input during element creation:

SERVICE CONNECTION:

Elements/Parameters:

- [Sky UK Pin Validation](xref:Connector_help_Sky_UK_Pin_Validation)

- **PIN Protection**
  - **PIN Unexpectedly Present**
  - **Service Encryption Status**

## Usage

### Alarms

This page displays the **Alarm List Table** and the **Penalty Box Table**. Both tables displays the **Cause**, **Alarm State**, **Suggested Action** and **Alarm Target UI.**

### Device Data

This page displays the current values of the subscribed parameters that are taken into account on the Workflow.

### Subscriptions Active

Table with subscribed parameters of the service.
