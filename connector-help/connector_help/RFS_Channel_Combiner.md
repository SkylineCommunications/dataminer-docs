---
uid: Connector_help_RFS_Channel_Combiner
---

# RFS Channel Combiner

The **RFS Channel Combiner** connector is an **SNMP** connector that is used to retrieve the monitoring data from the **RFS Monitor System**.

## About

The **RFS Monitor** is a component used to monitor **forward/reflected transmitter power** and provide multi-channel combiner configurations. The **RFS Channel Combiner** connector retrieves this monitoring information from the RFS Monitor component, so that this information can be accessed via DataMiner.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host:** The polling IP of the device, e.g. *10.11.12.13*.

**SNMP Settings:**

- **Port number:** The port of the connected device, by default *161*.
- **Get community string:** The community string in order to read from the device. The default value is *public*.
- **Set community string:** The community string in order to set to the device. The default value *private*.

## Usage

### General

This page displays general information about the device, for example the **Operating System**, **Uptime,** .

### Calculations

This page has 2 sections: **VSWR** and **Return Loss**.

- The **VSWR** section displays the VSWR value for the 4 input channels and the output channel. VSWR stands for Voltage Standing Wave Ratio and is used as an efficiency measure for transmission lines.
- The **Return Loss** sections displays the calculated return loss for the 4 input channels and the output channel, expressed in decibels.

### Power

This page also has 2 sections: **Forward Power** and **Reflected Power**. These 2 sections display the power measurements for the 4 input channels and the output channel.
