---
uid: Connector_help_Kathrein_ORA9022
---

# Kathrein ORA9022

The **Kathrein ORA9022** is an optical receiver.

## About

With this connector you can manage the Kathrein ORA9022 device using the **SNMP** protocol.

## Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *public*.

## Usage

### Main Page

This page contains general information about the device, such as the **Vendor**, **Model Number**, **Serial Number**, etc.

In addition, a number of monitored parameters are shown, such as the **Internal Temperature** and **Tamper Status**.

Here, you can also find one central place for all configuration: the **Operations** page button.

### Advanced Page

This page consists of a number of different sections:

- This common section contains parameters such as the **Type**, **Firmware Id** and **Number Paths**.
- The States section displays an overview of the states of the device, such as **Handheld Connected**, and **Return Path Standby**. The **States** table provides an overview of states such as **Lower Pilot Loss**, **Main Rx Signal Low**, etc.
- The Measuring section displays measured values such as the **DC Supply Voltage**. The table shows measured values such as **Optical Rx Power**, **Total Attenuation**, etc.
- The Display section contains return path parameters such as **Return Path Standby Mode** and **Return Path**.
- The Transmitters section provides an overview of the number of transmitters and displays information about each transmitter in the Transmitter table.
- The Supply Monitor section displays the number of voltages and their values. This section also contains two additional page buttons, **GGA80 Inventory** and **OSR 900x** , which display parameters related to GGA80 Inventory and OSR 900x respectively.

### Configuration Page

This page contains this connector's configurable parameters. In the **Configuration** table, for example, you can configure the **Forward Bandwidth**, **ALSC Mode**, **Lower Pilot Modulation**, **Lower Pilot Level**, etc.

The **OSR 900x** page button opens an additional page where you can set OSR 900x-specific parameters in the **OSR 900x Configuration Table**.
