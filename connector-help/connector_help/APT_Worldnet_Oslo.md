---
uid: Connector_help_APT_Worldnet_Oslo
---

# APT Worldnet Oslo

The **APT Worldnet Oslo** connector is used to monitor and control the APT Worldnet Oslo codec.

## About

The connector uses **SNMP** to retrieve data from the device. When traps are forwarded to the DMA, parameters can be updated faster than through the regular polling.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

### Configuration

No additional configuration is needed in the element.

## Usage

### Main View page

This page is the default page of the element. Most important status parameters are displayed here.

### General page

This page contains general information about the device, like the serial number, IP address, temperature, ...

### Audio page

Everything related to audio is grouped on this page. The first table displays all status parameters of each audio codec card. The second table allows the user to configure when audio alarms should be raised.

### Rack Configuration page

This page contains a table with all installed module cards in the chassis, with their status.

### Alarm Configuration page

This page allows the operator to control the alarm options provided by the device.

### Remote DCF Interface Table page

This page contains the Remote DCF Interface Table.
