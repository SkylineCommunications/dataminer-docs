---
uid: Connector_help_Sky_UK_Format_Alarms_Workflow
---

# Sky UK Format Alarms Workflow

This connector is used by enhanced services that contain elements of the protocol [Sky UK VICC](xref:Connector_help_Sky_UK_VICC) ,Sky UK SSR and Imagine Communications EPIC MV. With this connector, alarms are generated according to predefined rules.

## About

To use this connector, create a service that uses it as the service definition, add the necessary element and select the parameters mentioned below.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | Yes                     |

## Installation and configuration

### Creation

#### service Main Connection

This connector uses a service connection and requires the following input during element creation:

SERVICE CONNECTION:

Elements/Parameters:

- Imagine Communications EPIC MV

- **Video AFD Missing State (PiP)**
  - **Video AFD Format State (PiP)**

- [Sky UK VICC](xref:Connector_help_Sky_UK_VICC) (Follow element)
  - **Type of Material**
  - **Widescreen Signaling Format**
  - **Widescreen Signaling Mode**

- [Sky UK SSR](xref:Connector_help_Sky_UK_VICC)
  - **Wide Screen (Current Events)**

## Usage

### Alarms

This page displays the **ALPB Table** with the alarms from each element that was configured for the service. The table displays the **Cause**, **Alarm State**, **Channel,** **Suggested Action** and **Target UI.**

### Device Data

This page contains the state of the workflow decision nodes. It displays the values of the subscribed parameters.

### Subscriptions Active

Table with subscribed parameters of the service.
