---
uid: Connector_help_Motorola_APEX1000
---

# Motorola APEX1000

This connector uses **SNMP** to monitor and control the **Motorola APEX1000** **edge QAM**.

## About

The **1.0.1.x** version of the **Motorola APEX1000** connector implements the latest MIB available in early 2014 for the **APEX1000 edge QAM** and can therefore be used with the latest firmware of the device. Only the most important information is currently implemented in this connector.

### Version Info

| **Range** | **Description**            | **DCF Integration** | **Cassandra Compliant** |
|------------------|----------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version            | No                  | Yes                     |
| 1.0.1.x          | New range based on 1.0.0.x | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | N/A                         |
| 1.0.1.x          | N/A                         |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling ip of the device, e.g. *10.11.12.13.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The communicty string for reading values from the device, by default *public*.
- **Set community string**: The community string to set values from the device, by default *private*.

## Usage

### General Page

This page displays basic information about the **APEX1000** unit, such as the **System Name**, **System Up Time**, etc.

### Configuration Section

This section consists of 3 pages: **Fast Ethernet Configuration**, **GbE Configuration** and **QAM Configuration**.

- The **Fast Ethernet Configuration** page contains all information related to the **Fast Ethernet** configuration of the device, such as the **OAMP** and **IP settings**.
- The **GbE Configuration** page displays the **Gigabit Ethernet Status Table**, which has an entry for each Gigabit Ethernet interface.
- The **QAM Configuration** page displays the **Transition Mode** of the **APEX1000** and the **QAM RF Config** **Table**. The QAM RF Config Table contains the configuration items configurable on a **QAM RF Port Basis**.

### Monitoring Section

This section contains all **measurements and monitoring data** for the **APEX1000**. It consists of 5 pages: **Alarms**, **Temperature & Fan**, **Power Supply**, **QAM Status** and **Output Program**.

- **Alarms**: Displays the alarm status of possible faults in the device.
- **Temperature** **& Fan**: Displays temperature measurements.
- **Power Supply**: Displays status information about both power supplies.
- **QAM Status**: Contains the QAM Channel Status Table.
- **Output Program**: Contains the Output Program Table.

Starting from version **1.0.1.2** of the **APEX1000** connector, it is possible to **import** an excel file on the **Output Program** page of the connector. This will populate the **description** column in the Output Program Table with the descriptions from the Excel file. These descriptions are linked to the **Output Program Source ID**. The **Data Connectivity Components** need to be installed in the system before the Excel import will work. These can be downloaded from the following Microsoft website: <http://www.microsoft.com/en-us/download/details.aspx?id=23734>.

### Input & Output Stream Section

This section has 2 pages, one for the **Input Stream Status** and one for the **Output Stream Status**. The pages display the **Transport Status Table** for the inputs or outputs respectively.
