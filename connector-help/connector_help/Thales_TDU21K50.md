---
uid: Connector_help_Thales_TDU21K50
---

# Thales TDU21K50

With this connector, you can gather and view information from the device **Thales TDU21K50**, as well as configure the device.

## About

The connector monitors the **Thales TDU21K50** device. For each exciter present on the device, by default, the connector will export a DVE.

### Version Info

| **Range** | **Description**                                                 | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version.                                                | No                  | Yes                     |
| 1.1.0.x          | MIB update and support for different exciter modes implemented. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.1.0.x          | Unknown                     |

### Exported connectors

| **Exported protocol**                                                            | **Description**                                          |
|----------------------------------------------------------------------------------|----------------------------------------------------------|
| [Thales TDU21K50 Exciter A](xref:Connector_help_Thales_TDU21K50_Exciter_A) | DVE protocol for Thales TDU21K50 \[exported by 1.1.0.x\] |
| [Thales TDU21K50 Exciter B](xref:Connector_help_Thales_TDU21K50_Exciter_B) | DVE protocol for Thales TDU21K50 \[exported by 1.1.0.x\] |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP Connection:

- **IP Address/host**: The polling IP of the device, e.g. *10.220.224.16*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General Page

This page displays general information about the device, such as the **Equipment OID**, **SNMP Version** and **Software Version**.

With the **DVE Config** page button on this page, you can enable or disable the DVEs.

### Functional Page

This page displays the functional parameters of the device, such as the **Tx Frequency**, **Requested Power** and **Ripple Level**.

### Structure Page

This page displays the structure parameters of the device, such as the **Tx Type**, **Tx Length**, **Amplifier Number** and **Linear Correction Fitted**.

It also contains five page buttons, **Amplifier**, **Transistor**, **Supply**, **Cabinet** and **Cell**, with more information on the structure of these components of the device.

### Alarms Page

This page displays the main alarms of the device, e.g. **Major Fault**, **Temperature Fault**, etc.

### Amplifiers Page (not available in range 1.1.0.x)

This page contains a table with the status of the amplifiers present on the device.

It also contains two page buttons, **Transistor Amp.** and **Pre-Amplifier**.

### Supplies Page (not available in range 1.1.0.x)

This page contains a table with the status of the supplies present on the device.

### Cooling Page (not available in range 1.1.0.x)

This page contains a table with the status of the coolers present on the device.

### Cabinet Page (not available in range 1.1.0.x)

This page contains a table with the status of the cabinets present on the device.

### Commands Page (not available in range 1.1.0.x)

This page displays the commands of the device, e.g. **Transmitter Control**, **Reserve Exciter Control**, etc.

### Configuration Page (not available in range 1.1.0.x)

On this page, the device can be configured. The page also contains a page button, **OFDM Config**, that opens a page where you can configure the OFDM.

### Profile Page (not available in range 1.1.0.x)

This page displays a table with the profiles configured on the device.

### Supervision Page (not available in range 1.1.0.x)

This page displays the supervision parameters of the device.

It also displays two tables with the **Managers** and **Contacts** information.

- To add a manager or a contact, right-click the relevant table, click **Add Manager** or **Add Contact**, and then fill in the requested items.
- To delete a manager or a contact, click the **Delete** button in the relevant row of the table in question.

### Events Page (not available in range 1.1.0.x)

This page displays a table with the log events of the device.

### Traps Page (range 1.1.0.x only)

This page contains the **Event Table**, which records all the traps on the device.

### DVE Page

This page contains the **Exciter Digital** and **Exciter Analog** table, which are exported to DVE elements.

### Web Interface Page

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
