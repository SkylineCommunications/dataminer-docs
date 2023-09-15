---
uid: Connector_help_EVS_IP_Director
---

# EVS IP Director

With this connector it is possible to monitor **EVS IP Director** devices with SNMP.

## About

The **EVS IP Director** will monitor the **EVS IP Director** device.

## Installation and configuration

### Creation

The **EVS IP Director** is an SNMP and serial connector. The SNMP connection is used to monitor the product status, while the serial connection will be used to monitor the Jobs using the SOAP interface.

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

**SERIAL CONNECTION:**

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.
- **IP port**: The port of the connected device, default value: *9002*.

## Usage

### EVS Product Page

This page displays some general info regarding the device:

- System Name
- System Location
- Status

### EVS Product Agent Page

On this page, you can find tables with information regarding the modules.

### EVS Product Management Page

On this page, you can find the **Event Log** table.

### EVS Job Monitoring Page

On this page, you can find the **Job** tables with all the cached jobs. If you click the button **View History** in one of the rows, the history for that job will be filled in in the **History Table** below.

For the serial communication to work, you must first click the **Authentication** page button and fill in the logon credentials.

### Web Interface Page

On this page, you can find the web interface of the device.
