---
uid: Connector_help_Sky_UK_Commercial_Minutes_Workflow
---

# Sky UK Commercial Minutes Workflow

This connector is used by enhanced services that contain elements of the protocol [Sky UK Commercial Minutes](xref:Connector_help_Sky_UK_Commercial_Minutes). With this connector, all the alarms are gathered in a single table.

## About

To use this connector, create a service that uses it as its service definition, add the necessary elements and select the parameters to add to the service. In this case, these are alarm parameters.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

This enhanced service needs to be configured with only the following properties:

Elements:

- **Protocol**: [Sky UK Commercial Minutes](xref:Connector_help_Sky_UK_Commercial_Minutes)

Parameters:

- **Bus Address**
- **Channel Type**
- **Commercial Minutes (Current Hour)**
- **Commercial Minutes (Hour +1)**
- **Commercial Minutes (Hour +2)**
- **Commercial Minutes (Potential Breach)**
- **Commercial Minutes (Previous Hour)**

## Usage

### Early Warning List

This page displays a table with the alarms from each element that was configured for the service. The table displays the **Cause**, **Alarm State**, **Channel,** **Alarm Time** and **Target UI.** Depending on the channel type (General, Entertainment and Sports) of the element, some alarms might not be displayed.

### Device Data

This page contains information about the element **Commercial Minutes** associated with the service. It displays the state of the **Minutage Breach Current Hour**, **Minute Breach In 2 Hours**, **Minute Breach Next Hour**, **Potential Minutage Breach** and **Channel Type**.

It also shows the **Service Status** value. When this value is *Off-Air*, this workflow will not trigger any alarms. For other values (*NA* or *On-Air*), the workflow will run as expected.
