---
uid: Connector_help_Miranda_Kaleido_IP
---

# Miranda Kaleido IP

This is an SNMP and serial-based protocol for Miranda Kaleido IP.

## About

The Kaleido IP is an IP Video Multiviewer used to monitor and view local/remote IP multicast streams. Using SNMP and serial communication, the gathered information is loaded into the connector. Once a configuration file (.xls/.xlsx) has been supplied, a DataMiner element will keep track of the provisioned services.

## Configuration

### SNMP connections

This connector uses two Simple Network Management Protocol (SNMP) connections and requires the following input during element creation:

#### SNMP Connection - Basic

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

#### SNMP Connection - GSMalarm

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

SNMP Settings:

- **Port number**: The port of the connected device, by default ***2161**.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

### Serial connection

There is also a serial connection named **connectionSerialKaleido**, which requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **IP port**: The port of the connected device, by default *13000*.

## Usage

### General

On this page, the **channel** and **layout** can be set.

The page also contains two page buttons:

- **Load File**: opens the configuration file import window.
- **On-Air Services**: opens a window where you can edit the on-air services times.

### Transport

This page displays an overview of the transport streams, including status, TSID and an indication of whether the underlying services are on air.

### Services

This page contains all the services as specified in the configuration file. For each service, the alarm values are filled in in the columns, with the on-air status at the end. Not all possible alarm values are present to prevent an overload of (irrelevant) data.

### Teletext

This page displays the **Teletext Information Table**. This table contains the teletext alarm values, which have been separated from the services table.

### Health and Card Health

This page displays the health information, which is read out directly from the device, concerning CPU, fan, and voltage.

It also displays the card health information, which is read from the alarm table.

### Alarm Table

This page contains the alarm values used to fill the **Transport stream**, **Services**, **Teletext**, and **Card Health** tables. This is a filtered set from the actual table to reduce polling time.

If you click the **Restart OIDs** button, the full table is polled again (available on the **Configure Polling** pop-up page), and the filter is recalculated.

Toggle the **Enable Table Polling** parameter to poll the **Alarm Table** and update the previously mentioned tables.

### RCP

On this page, messages can be sent over the serial interface (RCProtocol).

### Web Interface

When the client is in the same network as the device, the web interface can be loaded in this page.

### Virtual Alarms

This page displays the alarms of the device.
