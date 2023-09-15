---
uid: Connector_help_Aurora_Network_CX3001_-_NC_4000_Single_DT_REV_B
---

# Aurora Network CX3001 - NC 4000 Single DT REV B

The Aurora Network Node NC4000 Single DT REV B connector is used by DVEs created by the Aurora Network CX3001 connector.

A DVE is created for each Digital Transceiver Module Revision B Type that is part of the NC 4000 chassis.

The types that are defined as Type B are:

- DT4012S

## About

The Dynamic Virtual Element has five pages:

- The **General** page contains a list of the nodes currently used by the transceiver, as well as general information about this particular module.
- The **Transceiver** page contains information regarding the **status** and **primary channel** of the transceiver module.
- The **Node Monitor** page contains information regarding the power supplies and power supplies alarm monitoring of the device.
- The **Converters** page contains information related to the **Slot D Converters** and **Slot E Converters**.
- The **Modules** page contains a table with information related to the module nodes.

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 2.0.1.x          | Unknown                     |

## Installation and configuration

### Creation

This connector is used by DVE child elements that are **automatically created** by the parent connector [Aurora Network CX3001](xref:Connector_help_Aurora_Network_CX3001), from version 2.0.1.x onwards. For each digital transceiver found in the system, a virtual element will be created.

## Usage

### General

This page contains information related to the device's node. There is also a **Normalize** button. When this button is clicked, the current values of the parameters listed below are saved in the **Normalized Alarms Table** and used for absolute alarm monitoring. The parameters that can be normalized are the following:

- Transceiver RX Optical Power
- Transceiver TX Optical Power
- Receiver B Optical Power
- Receiver C Optical Power
- Receiver D Optical Power
- Receiver E Optical Power
- Node Chain Number
- Slot D DX Input
- Slot D DX Output
- Slot E DX Input
- Slot E DX Output

### Transceiver

This page displays information related to the **Status** and the **Primary Channel**. It also contains **Transceiver Slot A** information.

### Node Monitor

This page contains information regarding voltages, power and currents.

### Converters

This page displays information related to the **Slot D Converters** and **Slot E Converters**.

### Modules

This page contains a table with information related to the module nodes.
