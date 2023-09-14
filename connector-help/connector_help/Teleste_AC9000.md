---
uid: Connector_help_Teleste_AC9000
---

# Teleste AC9000

This connector can be used to monitor Teleste AC9000 devices using **SNMP**.

## About

The Teleste AC9000 connector monitors the Teleste AC9000 node.

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. 10.11.12.13.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General Page

This page displays general information about the device, divided into the sections **Element Settings** and **Status Information**. In the Element Settings section, you can find information such as the **Element Name**, the **Element Structure**, etc.

The **Automatic Alignment** page button allows you to monitor and configure settings related to automatic alignment.

### Module Page

This page displays tables with information regarding the modules: the **Module Table**, **Module Detail Table** and **Module Status Table**.

### Event Log Page

This page displays the **Event Log Table** along with a number of other parameters related to the event logs.

### Forward Path Page

This page displays parameters related to the forward path. In the **Forward Path Settings** section, you can configure parameters such as **Band**, **Status**, **Type**, etc. In the **Forward Path Routing** section, you can configure routing-related settings.

This page also contains the **Optical Receiver** and **Forward Path OMI** page buttons.

### Return Path Page

This page displays parameters related to the return path. Like the Forward Path page, it is divided in two sections. In the **Return Path Settings** section, you can configure parameters such as **Band**, **Status**, **Amplifier Type**, etc. In the **Return Path Routing** section, you can configure routing-related settings.

This page also contains the **Optical Transmitter**, **Return Path OMI** and **Automatic Ingress Blocking** page buttons.

### Level Detector Page

This page displays the **Level Detector Table**.

### Level Control Page

This page displays the **Level Control Table**.

### Web Interface Page

This page displays the web interface of the device. However, note that the web interface is only accessible when the client machine has network access to the device.
