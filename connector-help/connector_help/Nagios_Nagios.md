---
uid: Connector_help_Nagios_Nagios
---

# Nagios Nagios

The **Nagios Nagios** connector monitors a Nagios system unit through **SNMP**.

## About

The Nagios Nagios connector will receive **traps** from the device and display them in a table.

However, note that only traps with **OIDs 1.3.6.1.4.1.20006.1.6 or 1.3.6.1.4.1.20006.1.8** and having **at least 6 bindings** will be processed. When a received trap cannot be processed correctly, this will be logged. If necessary, the trap format can be configured in the Nagios application.

### Creation

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: *161*
- **Get community string**: *public*
- **Set community string**: *private*

## Usage

### Status Page

This connector contains only one data display page, the **Status page**.

This page displays a **Notify Table** with the **Device Name**, **Alarm Type**, **Status** and **Extra Info.**

You can remove a row from the table by clicking the relevant **Remove** button.
