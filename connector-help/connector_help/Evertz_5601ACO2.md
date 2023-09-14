---
uid: Connector_help_Evertz_5601ACO2
---

# EVERTZ 5601ACO2

The 5601ACO2 Automatic Changeovers are intended for use with two 5601MSC Master Clock/Sync Generators. The 5601ACO2 system uses latching relays to ensure maximum reliability and minimal disruption in the event of any failure.

## About

This connector uses SNMP to monitor the **Evertz 5601ACO2** device.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device, e.g. *10.145.1.12*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *public*.

## Usage

### General Page

This page displays general information about the device, such as the **System Description**, **Up Time**, and **Contact**. It also displays the **Operating Mode**, **Changeover Rate**, **Voting Mode**, **Control Source**, etc.

### GPO I/O Page

This page contains the **GPO Input Table** with the **Input Status** and **GPO Output Table** with the **Output Status.**

### Analog Faults Page

This page displays the **Fault Analog TG** **Table** and the **Fault Analog Sync** **Table**. There is a **Voting** page button for each table, which will display the corresponding voting configuration.

### Source Signal Faults Page

This page displays faults related to the source signal, displayed in the **3G/HD/SDI, AES/DARS, 10 MHz, Word Clock** and **LTC Table**. Each table either has a **Voting** page button, which will display the corresponding voting configuration, or a toggle parameter to configure voting.

### Output Faults Page

This page contains output-related faults. The **Fault** **GPO Output** **Table** has a **Voting** page button, which will display the corresponding voting configuration.

### Power/Fan/Door Faults Page

This page displays faults related to the **Power Supply**, the **Fan** or the **Door**.
