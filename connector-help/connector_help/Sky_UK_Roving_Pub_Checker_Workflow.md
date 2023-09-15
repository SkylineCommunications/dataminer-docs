---
uid: Connector_help_Sky_UK_Roving_Pub_Checker_Workflow
---

# Sky UK Roving Pub Checker Workflow

This is enhanced services that contains elements with the protocol Sky UK SSR, Sky UK VICC and Snell Wilcox IQSRT10. There can be multiple VICC connected to this service. The alarms will trigger depending on the predefined workflow

## About

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | False                   |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### Service Main Connection

This connector uses a service connection and requires the following input during element creation:

SERVICE CONNECTION:

Elements/Parameters:

- Sky UK SSR

- Sky UK VICC

- Snell Wilcox IQSRT10 (Router 8x2)

- Output 1, Output 2

## Usage

### Alarms

This page displays the **ALPB** **Table**, besides the the four alarm specified in the worflow, there are more rows depending on the number of VICC elements associated with the service, there is also one row for each router output.

### Device Data

This page shows the current **Service Key Name**. There is also a configurable table for each VICC in the service, is it also possible to edit some values in each row and also add new rows, such has **Automation/System Name**, **Pub Bus Name** and **Master Bus Name** (this value will be set in the current active VICC Element)

### Router

The page shows the current TV channel in each output of the router associated with the current active VICC Element System Name where is possible to configure the input and output for each key.

### Admin

This shows the **Protocol Element ID Table** where you can find detailed information regarding each element associated with the service, there is also a button to reset and reinitialize the subscriptions and the tables.
