---
uid: Connector_help_Sky_UK_Info_On_EWL_-_Live_Event_Workflow
---

# Sky UK Info On EWL - Live Event Workflow

This connector is used by enhanced services that contain elements of the protocol [Sky UK VICC](xref:Connector_help_Sky_UK_VICC). With this connector, alarms are generated according to predefined rules.

## About

To use this connector, create a service that uses it as the service definition, add the necessary element and select the parameters mentioned below.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Initial version.            |

## Installation and configuration

### Creation

#### service Main Connection

This connector uses a service connection and requires the following input during element creation:

SERVICE CONNECTION:

Elements/Parameters:

- [Sky UK VICC](xref:Connector_help_Sky_UK_VICC)

- **Channel From User**
  - **Broadcast Start Date Time**

## Usage

### Alarms

This page displays the **Early Warning List Table** with an entry for each current and future event with their PIN due status. The table displays the **Cause**, **Alarm State**, **Channel,** **Alarm Time** and **Target UI.**

### Device Data

This page displays the current values of the parameters from the subscribed VICC element that are used in the Workflow.

### Subscriptions Active

Table with subscribed parameters of the service.
