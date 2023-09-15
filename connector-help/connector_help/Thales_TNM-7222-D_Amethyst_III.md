---
uid: Connector_help_Thales_TNM-7222-D_Amethyst_III
---

# Thales TNM-7222-D Amethyst III

The **Thales TNM-7222-D Amethyst III** is a redundancy switcher.

## About

The Thales TNM-7222-D Amethyst III connector makes it possible to monitor and control the Amethyst III with SNMP.

### Version Info

| **Range** | **Description**                             | **DCF Integration** | **Cassandra Compliant** |
|------------------|---------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                             | No                  | Yes                     |
| 3.0.0.x          | Reviewed version with updated naming format | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 3.0.0.x          | 02.22.03                    |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses an SNMP connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

### Configuration

On the **General page -\> Polling Config: Polling All:**

- YES: Polls all data
- NO: Slow polling for alarms and some specific parameters (SerialNr, EqSoftwareVersion, EqConfigVersion, CommercialOptList) and tables (Input Stream Table, Input Services Table and Input PID subTable).

## Usage

### General page

This page displays general information about the device. You can also find the **Polling Config** page button here.

### Input/Output Overview

This page displays a tree view of the **Inputs** and **Outputs**.

### Active Alarms

This page contains the **Alarm Table**. This table has 9 specific alarm types. If a trap on these alarms occurs, the Alarm Table changes its status. The start date and end date are also included. It is possible to reset the table with a button. If the Active Alarms table contains one or more of those specific alarm types, the Alarm Table will be updated with this information. Resetting is necessary if an alarm is active in the Alarm Table but not in the Active Alarms table (a trap was missed).
