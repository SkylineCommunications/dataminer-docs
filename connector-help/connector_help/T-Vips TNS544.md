---
uid: Connector_help_T-Vips_TNS544
---

# T-Vips TNS544

This is an SNMP connector that can be used to obtain information from the T-Vips TNS544 switch. It polls the device periodically and also implements traps to display updated states. The connector can also be used to configure the device.

## About

### Version Info

| **Range**            | **Key Features**                                                                                | **Based on** | **System Impact** |
|----------------------|-------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version                                                                                 | \-           | \-                |
| 1.0.2.x \[SLC Main\] | Added IDX column in the naming for the following tables: 7000, 9000, 15000, 16000, 21000, 42400 | 1.0.1.6      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.8.0                  |
| 1.0.2.x   | 2.8.0                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## Usage

### General

This page contains general information about the device, including the Product Name, Device Name, System Description, System Object ID, System Up Time, System Contact, System Name, System Location, System Service, General Alarm Status, Unit Device Name, Serial Number, Software Version, Software Build Time, Internal Temperature, Reset Delay, Unit Alarm Old Status, Unit Fabrication Code, Unit Active Configuration and Number of Switch Controllers.

It also contains a page button to the **Polling** subpage, where you can find the Switch Control Timer, Services Timer, Pids Timer, Inputs and Outputs Timer, Alarm Status Timer, and Unit Curr Alarm Timer.

### Switch Control

This page contains the tables **TS Input Switches Table**,**Seamless Switch Config Table**,and **TS Input Switch Details**. It also contains the **Switch Relay Current Position** and **Switch Relay Control Mode** configuration parameters.

This page includes page buttons to the following subpages:

- **Unit RIP2**: Contains the parameters related to the configuration of the **RIP2** routing protocol.
- **Unit VLAN**: Contains the **Unit VLAN Table**.
- **Unit Address**: Contains the **Unit Address Table**.
- **Unit Time**: Contains the parameters related to the date, time, time zone, and daylight-saving time configuration.
- **Traps Destination**: Contains the **Trap Destination Table** and the **Unit Trap Destination Next Available Table Index**.

### Services

This page contains the **TS Service Status Table**.

### Pids

This page contains the **TS Pid Status Table**.

### Inputs and Outputs

This page contains the **Input Table**, the **Output Table** and a page button to the **Global Ports** page.

### TS Out

This page contains the **TS Out Config Table** and **TS Output Transparent Configurations Table**.

### Alarms

This page contains several tables related to alarms: Table TS Alarm, Table IP Alarm, Unit Notifications Alarms Table, Unit Curr Alarm Table, Unit Short Curr Alarm Table, Unit Alarms Traps, and Unit Alarm Trap History Table.

### Events

This page contains the parameters **Unit Event Config Change Index** and **Unit Event Config Change Text**.

It also contains the tables **Unit Notifications Event Table**, **Unit Notifications Detailed Event Table**, and **Unit Event History Table**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
