---
uid: Connector_help_Oracle_DIVArchive
---

# Oracle DIVArchive

This connector monitors the tape library of Oracle called DIVArchive. It is part of a Content Management System. With this device, an operator can archive, organize and restore a large number of files on disks and tapes.

## About

The connector polls via HTTP (more specifically SOAP) requests to the API of the device. In addition, it can also catch SNMP traps in order to instantly update statuses of actors, drivers, disks and libraries.

The connector only monitors the device. Though the API also allows for requests to manage the device, this is not included in the current connector version.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                                                       |
|------------------|-----------------------------------------------------------------------------------|
| 1.0.0.x          | Tested with DIVArchive 7.1 Compatible with the most recent version DIVArchive 7.3 |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection to catch traps and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

#### HTTP connection with API

This connector uses an HTTP connection to do SOAP calls to the API and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device. The suffix to access the SOAP Endpoint is filled in in the Connection Manager of the connector. This field is required.
- **IP port**: The port through which the API can be accessed. This field is required.
- **Bus address**: This field is optional. If the proxy server has to be bypassed, specify *bypassproxy.* This is also the default value.

### Configuration of the API Connection

On the **Connection Manager page** of the connector (the last page), the suffix to access the **SOAP Address Endpoint** is filled in by default. However, if this address is different, or if, for example, you want to access the 2.0 version instead of the 2.1, you can change it there.

Requesting a token is done via the 'registerClient' request, which is the only available request to the API that does not require a token. A token is only valid for 30 minutes after it has been requested. If you enable **Automatically Refresh Token**, a new token will be requested every 29 minutes to solve this issue. On requesting a token, you must specify an **Application Name** and **Physical Location.** This is then stored in the database of the device to keep track of which systems accessed the API.

Note that no credentials are required to request the token and thus communicate with the API.

## Usage

### General

This page displays the **DIVArchive Manager Status**, the **Number of Objects** stored, the **Number of Blank Tapes**, the **Total Remaining Storage Size** and the **Total Storage Size**.

### Actors

This page lists all actors available in the library, together with their properties. This table is filled in via SOAP requests, but the **Availability** of every actor can also be instantly updated if an SNMP trap is caught announcing a change of status.

### Disks

This page lists all disks available in the library, together with their properties. This table is filled in via SOAP requests, but the **Availability** of every disk can also be instantly updated if an SNMP trap is caught announcing a change of status.

### Drives

This page lists all drives available in the library, together with their properties. This table is filled in via SOAP requests, but the **Status** of every drive can also be instantly updated if an SNMP trap is caught announcing a change of status.

### Libraries

This page lists all libraries available in the library, together with their properties. This table is filled in via SOAP requests, but the **Status** of every library can also be instantly updated if an SNMP trap is caught announcing a change of status.

Note that in most cases there will be only one library, but as the device is theoretically able to manage more than one, this information is listed in a table that can have multiple rows.

### Finished Requests

This page lists all **Finished Requests**. The information in this table is retrieved via SOAP requests. The connector fetches up to the **Max Number of Requests**. The requests are retrieved for the period of time of the number of seconds specified in **Request List Initial Time** until the current time.

### Connection Manager

This page displays the current **SOAP Connection Status** and the current **Session Token** that is used for the SOAP Calls. For more information on the other parameters on this page, refer to the section "Configuration of the API Connection" above.
