---
uid: Connector_help_Sky_UK_Info_On_EWL_-_Live_Event_Workflow
---

# Sky UK Info On EWL - Live Event Workflow

This driver is used by enhanced services that contain elements of the protocol [Sky UK VICC](xref:Connector_help_Sky_UK_VICC). With this driver, alarms are generated according to predefined rules.

## About

To use this driver, create a service that uses it as the service definition, add the necessary element and select the parameters mentioned below.

### Ranges of the driver

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | Initial version.            |

## Installation and configuration

### Creation

#### service Main Connection

This driver uses a service connection and requires the following input during element creation:

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
