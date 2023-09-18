---
uid: Connector_help_Satcom_Technologies_NetMAC
---

# Satcom Technologies NetMAC

The NetMAC connector is designed to collect data from the NetMAC device, which is a management tool for telecommunication systems.
The relevant information is contained in data points, associated to different SCUs, owned by nodes of different systems.

## About

The aim of this connector is to collect data from the NetMAC device and to allow the user some control, both through SNMP. The data is structured by means of a tree control.

### Version Info

| **Range** | **Description**                                   | **DCF Integration** | **Cassandra Compliant** |
|------------------|---------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version, with optional DVE creation.      | No                  | Yes                     |
| 2.0.0.x          | Implementation based on traps instead of polling. | No                  | Yes                     |
| 2.0.0.x          | Only processes traps of Primary FEP.              | No                  | Yes                     |
| 2.0.1.x          | Added connection for Primary FEP state polling    | No                  | Yes                     |

## Installation and configuration

### Creation: Range 1.0.0.1 to 2.0.0.2

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host:** The polling IP of the device.
- **Device address:** Not required.

**SNMP Settings:**

- **Port number:** The port of the connected device, e.g. *161*.
- **Get community string:** The community string used when reading values from the device, e.g. *public*.
- **Set community string:** The community string used when setting values on the device, e.g. *private*.

### Creation: Range 2.0.1.x

This connector uses 2 Simple Network Management Protocol (SNMP) connections (one for each FEP) and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host:** The polling IP of FEP A.
- **Device address:** Not required.

**SNMP Settings:**

- **Port number:** The port of the connected device, e.g. *161*.
- **Get community string:** The community string used when reading values from the device, e.g. *public*.
- **Set community string:** The community string used when setting values on the device, e.g. *private*.

**SNMP CONNECTION FEP B:**

- **IP address/host:** The polling IP of FEP B.
- **Device address:** Not required.

**SNMP Settings:**

- **Port number:** The port of the connected device, e.g. *161*.
- **Get community string:** The community string used when reading values from the device, e.g. *public*.
- **Set community string:** The community string used when setting values on the device, e.g. *private*.

## Usage: Range 1.0.0.1

### System Overview Page (also present in the DVEs)

On this page, you can find a tree control implementing the following hierarchy: **System Table**, **Node Table**, **SCU Table**, **DP Table**.

### General Page

On this page, the tables are displayed that are used in the tree control of the **System Overview** page.

The **System Table** displays the **System Names** and the **System First Node** for each of them.

The **Node Table** displays the **Node Name**, the **Node System** (the system owning the node), and the **Node First SCU** (the first SCU owned by the current node) for each node.

All the SCUs are displayed in the **SCU Table**. Each line of the table describes a different SCU, with its associated **SCU Sys Type,** **SCU Sub Sys Type,** **SCU Equip Type** and **SCU SCU Type**.
In addition, it is possible to enable one or more DVEs with toggle buttons in the **DVE Status** column. You can also enable all the DVEs or remove those previously created by clicking the **Enable All DVEs** and **Disable All DVEs** buttons. All the created DVEs are shown in the **Filtered SCU Table**. For the sake of convenience, the names of the SCUs are editable.

The **DP Table** contains the final information for each data point: the **DP Type**, **DP Direction**, **DP String/Numeric Value**, **DP Quality**, **DP State**, **DP Enable** (status), **DP Sample Rate**, **DP Sample Period**, **DP Last Update**, etc.

### Web Interface Page

On this page, you can access the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Usage: Range 2.0.0.x

This range monitors the device by processing the traps instead of performing regular SNMP polling.

### General Page

This page contains the **DataPoint Table**. This table is initialized by parsing a MIB provided by Satcom Technologies. This MIB file contains a list of all entries in the table of a specific customer, with two OIDs per entry (dpValue and dpTrapState).

To parse the MIB file, set the location in the **MIB Location** parameter and click **Parse MIB**. After the MIB file has been parsed, the table will contain all parameters. When a trap is received, the corresponding entry in the table will be updated.

*Note:* In order to include the **System Name** column, the **Naming File Location** parameter has to be set to the naming file (see "Friendly Names Page" below).

The **Traps...** page button provides access to parameters related to receiving traps:

- The Trap **IP Sources** will typically contain a value that includes both the IP addresses of the primary and backup FEP (e.g. 192.168.10.\*).
- The parameters **FEP A IP** and **FEP B IP** contain the IP address of FEP A and FEP B respectively.
- The parameter **Primary FEP** indicates which FEP is the primary one. This value will change automatically when a trap is received denoting a switch of the primary FEP. Note that only traps that are sent from the primary FEP will be processed (with the exception of traps denoting a primary FEP switch).
- The **Traps** table provides an overview of the last 100 traps that were received.

### Friendly Names Page

This page provides an overview of the mapping between the system codes and their user-friendly names in the **Friendly Names Table**. You can load this table by setting the location of the naming file in the **Naming File Location** parameter and clicking the **Get Names** button.

The naming file contains the conversion of the database device code to the user-friendly names. In this CSV file, every line must mention a system code and a user-friendly name, separated by a semicolon. E.g.:

*ANT1 SYS1 CTRL BRK12\*\*\*;LNA Controller*

## Usage: Range 2.0.1.x

This range has a separate SNMP connection for each FEP. Usage is similar to range 2.0.0.x, except for the **Traps** page.

The **Traps...** page button provides access to parameters related to receiving traps:

- The parameter **Primary FEP** indicates which FEP is the primary one. This value will change automatically when a trap is received denoting a switch of the primary FEP. Note that only traps sent from the primary FEP will be processed (with the exception of traps denoting a primary FEP switch).
- **Primary FEP status**: This parameter indicates if both FEPs agree on which FEP is set as the primary FEP. Each FEP is polled every 5 minuts to obtain the primary FEP value. If the FEPs contradict each other 3 consecutive times, the parameter is set to an alarm state.
- The **Traps** table provides an overview of the last 100 traps that were received.
