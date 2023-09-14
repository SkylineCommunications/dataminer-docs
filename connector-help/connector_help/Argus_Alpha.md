---
uid: Connector_help_Argus_Alpha
---

# Argus Alpha

The **Argus Alpha** connector uses SNMP to communicate with the **Argus Alpha controller**.

## About

The **Argus Alpha** connector can be used to monitor the **Argus Alpha controller**. This device only supports monitoring via SNMP, which means that configuration settings still need to be done on the interface of the device itself.

On top of the normal SNMP polling, the device also sends traps (notifications) when an alarm occurs on the system. The connector will then update the **Alarms Table** with the new alarms.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General

The **General** page displays the **Contact** **Information** and the **System** **Information**. The **Contact** **Information** parameters are used to indicate where the device is located and who needs to be contacted for support. The **System** **Information** parameters display general information about the device itself.

### Status

The **Status** page displays the status parameters for the **Argus** **Alpha** device. The status parameters are the same as on the **System** \> **View Live Status** page on the web interface of the actual device. Only the parameters that can be polled via SNMP are displayed on the **Status** page.

### Signals

The **Signals** page only displays the **Controller** **Signals** parameters on the page itself. These are the general signal parameters for the device. To view the other signal parameters, you must use the page buttons on this page to access the pages in question. Some of the pages display tables (e.g. **Digital** **Inputs**), others display single parameters only (e.g. **Rectifier** **Signals**, **Converter** **Signals**).

### Alarms

The **Alarms** page displays 2 status parameters and the **Alarms** **table**. The status parameters (**Nbr of Major Alarms & Nbr of Minor Alarms**) display how many alarms are currently in the system.

The **Alarms** table is a custom table that contains an entry for every possible alarm in the system. This table is updated in 2 ways: by polling all alarm tables via SNMP, and via SNMP traps. When a trap is received that is linked to an alarm in the **Alarms** **table**, the correct entry will be updated.

### Web Interface

This page can be used to access the web interface for the device. Note that the web interface of the device must be accessible from the client PC if you want to access it via the connector.

## Notes

There are also some information and general alarm traps (e.g. **Communication** **Error**) that are implemented. These traps will not update the **Alarms** table, but will immediately generate an alarm in DataMiner itself.
