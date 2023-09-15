---
uid: Connector_help_Sky_UK_Watershed_Alarming_Workflow
---

# Sky UK Watershed Alarming Workflow

This connector is used by enhanced services that contain elements of the protocol [Sky UK VICC](xref:Connector_help_Sky_UK_VICC). With this connector, alarms are generated according to predefined rules.

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

Elements:

- **Protocol**: [Sky UK VICC](xref:Connector_help_Sky_UK_VICC)

Parameters:

- **Data Update Trigger**
- **Channel From User**

## Usage

### Alarms

This page displays the **Early Warning List Table** with an entry for each current and future event. When the service has a +1 variant, it also displays the entries for that variant. The table displays the **Cause**, **Alarm State**, **Channel,** **Alarm Time** and **Target UI.**

### Device Data

This page contains some internal parameters. First one should configure if this channel is a +1 variant using the toggle button. Second, the **VICC Update** parameter is the last update trigger received from the VICC and will also trigger internal processing. Third, the **VICC DMA-Elem ID** parameter is the reference to the VICC element configured in the service, it is used to find the correct element to request data from and is automatically filled in. Finally, it also shows the value of the **Channel Bus** and the **Service Status**: when this is Off-Air, this workflow won't trigger any alarms, for other values (NA or On-Air), the workflow will run as expected.

### Subscriptions Active

Table with subscribed parameters of the service.
