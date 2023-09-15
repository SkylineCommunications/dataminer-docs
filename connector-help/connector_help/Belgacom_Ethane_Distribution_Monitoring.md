---
uid: Connector_help_Belgacom_Ethane_Distribution_Monitoring
---

# Belgacom Ethane Distribution Monitoring

The **Belgacom Ethane Distribution Monitoring** connector handles information sent by the current monitoring tool that monitors the Belgacom distribution network for Broadcast TV.

## About

This connector uses an **SNMP** interface in order to receive traps sent from the monitoring tool.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device, e.g. *10.145.1.12*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *private*.

## Usage

### General

This page displays the **Traps Number** received and the **Injection Nodes Table**.

### Distribution Nodes

This page displays the **Distribution Nodes Table**.

### Stream Based Overview

This page displays the **Stream Based Overview** table.

### Configuration

This page displays the **Channel Names Table**. New channels can be added to this table in two ways: either by using a .csv file to add several channels at a time, or by adding channels one by one using the **Add Channel ID** page button. To load from a .csv file, first set the **CSV File Path** and then click the **Load Channels Names CSV File** button. To delete a channel, use the **Delete Channel ID** page button.

The page also displays the **Range Config Table**. Click the **Delete Range** or **Add Range** page buttons to delete or add a **Range Index**.

Finally, you can also find the **Trap IP IP** here, which is filled in with the IP that was set when creating the element, and the **Traps Max duration**.

### Debug

This page is used for debug purposes.
