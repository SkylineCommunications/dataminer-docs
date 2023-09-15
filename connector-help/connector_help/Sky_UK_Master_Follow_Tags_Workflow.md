---
uid: Connector_help_Sky_UK_Master_Follow_Tags_Workflow
---

# Sky UK Master Follow Tags Workflow

This connector is used by enhanced services that contain elements of the protocol [Sky UK VICC](xref:Connector_help_Sky_UK_VICC) and Sky UK BSS. With this connector, alarms are generated according to predefined rules.

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

- [Sky UK VICC](xref:Connector_help_Sky_UK_VICC) (Master element)

- **Data Update Trigger**

- [Sky UK VICC](xref:Connector_help_Sky_UK_VICC) (Follow element)

  - **Data Update Trigger**
  - **Channel From User**
  - **Expected Follow Bus**

- [Sky UK BSS](xref:Connector_help_Sky_UK_VICC)

  - **Data Update Trigger**

From version 1.0.0.11 subscription parameters have changed

- **Future Events Table**

- [Sky UK VICC](xref:Connector_help_Sky_UK_VICC) (Follow element)

  - **Future Events Table**
  - **Channel From User**
  - **Expected Follow Bus**

- [Sky UK BSS](xref:Connector_help_Sky_UK_VICC)

  - **BSS Table**

## Usage

### Alarms

This page displays the **Early Warning List Table** with the alarms from each element that was configured for the service. The table displays the **Cause**, **Alarm State**, **Channel,** **Alarm Time** and **Target UI.**

### Device Data

This page contains the state of the workflow decision nodes. It displays the **Expected Follow Bus** and detection of the Master and Follow element. It also shows the value of the **Channel Bus** and the **Service Status**: when this is Off-Air, this workflow won't trigger any alarms, for other values (NA or On-Air), the workflow will run as expected.

### Subscriptions Active

Table with subscribed parameters of the service.
