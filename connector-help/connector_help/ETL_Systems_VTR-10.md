---
uid: Connector_help_ETL_Systems_VTR-10
---

# ETL Systems VTR-10

The **ETL Systems VTR-10** connector is used to configure and display information of the ETL Systems VTR-10 device.

## About

This connector can be used to monitor and control the **ETL Systems VTR-10** device.

**Alarm monitoring** and **trending** can be enabled for parameters in the connector.

## Configuration

### Connections

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device, e.g. *172.27.64.111*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

**Serial connection using TCP:**

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Port number**: The port of the connected device, by default 4000.
- **Device address**: By default 65

### Web Interface

The web interface is only accessible when the client machine has network access to the product

## How to Use

The element created with this connector consists of the following page:

- **General**: Displays general information about the device such as SummaryAlarm, CPU Temperature and Fan Status.
- **Matrix**: Displays the matrix containing the connections present on the device.
- **Inputs**: Displays a table with the configuration and readings of the inputs.
- **Outputs**: Displays a table with the configuration of the outputs.
- **Trap Configurations**: Allows you to configure the traps receiver.
- **Configuration**: Allows you to configure the matrix/device.

The matrix interface allows you to do the following actions:

- Set a new connection, by clicking on the desired connection.
  Note that setting a new connection can disconnect an existing connection.
- Edit the labels, by right-clicking in the matrix and selecting **Edit**. On the pop-up page, the field description of the relevant output or input should then be changed.
