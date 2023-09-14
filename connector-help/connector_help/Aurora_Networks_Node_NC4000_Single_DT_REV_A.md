---
uid: Connector_help_Aurora_Networks_Node_NC4000_Single_DT_REV_A
---

# Aurora Network Node NC 4000 Single DT REV A

The Aurora Network Node NC4000 Single DT REV A connector is a DVE created by the Aurora Network CX3001 connector.

It is created for every Digital Transceiver Module Revision A Type that is part of the NC 4000 chassis.
The types that are defined as Type A are:

- DT4032N
- DT4032S
- DT4232N
- DT4250N

## About

The information displayed in the main element is delivered in four pages:

- The **General** page contains a list of the nodes currently used by that transceiver, as well as some general information about this particular module.
- The **Transceiver** page contains information regarding the **status** and **primary** channel of the transceiver module.
- The **Node Monitor** page contains information regarding the power supplies and power supplies alarm monitoring of the device.
- The **Converters** page contains information related to the **Slot D Converters** and **Slot E Converters**.

## Installation and configuration

### Creation

This connector is automatically created by the Aurora CX3001 connector. For each digital transceiver found in the system, a virtual element will be created.

## Usage

### General Page

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

### Transceiver Page

This page displays information related to the **Status** and the **Primary Channel**. It also contains **SFP/SFF** information.

### Node Monitor Page

This page contains information regarding voltages, power and currents.

### Converters Page

This page displays information related to the **Slot D Converters** and **Slot E Converters**.
