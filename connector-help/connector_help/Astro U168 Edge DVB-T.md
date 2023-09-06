---
uid: Connector_help_Astro_U168_Edge_DVB-T
---

# Astro U168 Edge DVB-T

With this driver, it is possible to gather and view information from the device **Astro U168 Edge DVB-T**, as well as to configure the device.

## About

This driver uses an **HTTP** connection to monitor the Astro U168 Edge DVB-T device.

This driver also contains an **SNMP** interface to receive traps from the device.

### Ranges of the driver

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | 5595                        |

## Installation and configuration

### Creation

This driver uses two interfaces: an HTTP interface to retrieve the data and an SNMP interface to collect the traps.

#### HTTP connection

This driver can communicate directly with the **U168** but it can also be configured to send the requests to the **Astro U100 Controller**, which will then serve as a proxy. Depending on the communication mode, the HTTP connection must be configured differently:

#### A) Communication with U100C as proxy:

**SERIAL connection:**

- **IP address/host**: The IP address of the Astro U100 Controller.
- **IP port**: The port of the destination, e.g. *80*.
- **Bus address**: The IP address of the U168. Also, fill in "ByPassProxy" to bypass any possible proxy that could block the HTTP communication. Both fields must be separated by a semicolon. For example: *ByPassProxy;10.11.12.13*.

#### B) Direct Communication:

**SERIAL connection:**

- **IP address/host**: The IP address of the U168.
- **IP port**: The port of the destination, e.g. *80*.
- **Bus address**: This field can be used to bypass the proxy. To do so, fill in the value *ByPassProxy*.

#### SNMP connection

Regardless of the HTTP connection configuration, the SNMP interface collects the traps emitted by the device, so the SNMP IP address must be the IP address of the **U168** (not the controller).

**SNMP connection:**

- **IP address/host**: The polling IP of the U168, e.g. *10.11.12.13*.

**SNMP settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General

This page displays general information about the device.

The credentials of the device must be filled in via the **Login** page button.

Some important parameters are available at the end of the first column:

- **Controller Name**: This parameter shows the name of the **Astro Virtual Controller**element that manages this device. If no such element is used, the parameter will show the exception value *No Virtual Controller Found*.

- **Communication Type**:

- *Direct Communication*: The element sends the requests directly to the Astro module device.
  - *U100C Proxy*: The element sends the requests to the Astro U100 Controller, which will forward them to the Astro module. The controller acts as a proxy.

- **Communication Method**: This parameter is only available in **Direct Communication** mode.

- *Login*: The element logs in to the device for every request (read and write requests).
  - *Anonymous*: The element only logs in to the device for write requests. The device does not log in for read requests.

### Status

This page displays status information for the device, e.g. **Temperature**, **Power Supply**, **CPU Load**, etc.

### Main

This page allows you to configure the main device configuration, e.g. **DNS**, **Time Source**, **Interfaces**, etc.

### Test Gen

This page allows you to configure the test gen parameters, e.g. **Data Rate**, **Packet ID**, etc.

### Channels

This page allows you to configure the device channels, via the tables **Channel Parameters**, **DVB-T Parameters** and **RF Input Settings**.

**Note**: To be able to configure settings in the table **DVB-T Parameters**, the corresponding entry in the column **Tuning Parameter** needs to be set to ***manua**l***.

The page also contains the **Channel Status** page button.

### IP TX

This page allows you to configure the **IP TX** parameters, via the **IP TX Channel Settings** table.

The page also contains several page buttons that provide access to additional RF settings and statistics.

### Time Zone

This page allows you to configure the **Time Zone Settings**.

### Update/Config

This page allows you to upload and download config files to the device. You can also perform a software update via this page.

#### Configuration files (download/upload)

To download a file:

1.  Click **Download**. The following pop-up message will be displayed:
2.  Enter the name of the file and click OK. The file will be saved in the following location:C:\Skyline DataMiner\Documents\\protocol name\>\\element name\>\\file name\>

To upload a file:

1.  Click **Upload**. The following pop-up window will be displayed:
2.  In this window, **Module Name** lists all the Astro elements of the same type in the system. **Upload File Name** lists all the files available in the Documents folder of the selected module.The file to be uploaded must be located in the following folder: C:\Skyline DataMiner\Documents\\protocol name\>\\element name\>\\file name\>

#### Software update

The driver allows you to upload a firmware archive from the local disk of the DMA:

The **Firmware File** parameter is used to select which file to upload. The drop-down list contains all the files present in the following folder on the DMA: C:\Skyline DataMiner\Documents\\Protocol Name\>.

When you have selected the file, click **Update and Reboot** to start the upgrade. To view the progress of the update, click the **Update Progress** page button. However, traps must be configured for this.

### Licensing

This page shows the available licenses for this Astro device.

### System Log

This page contains a table listing all the log entries. You can download the log files by clicking the **Download** button. Log settings are available via the **System Log Config** page button.

### Alarm Severities

This page allows you to set the severity for each alarm type.

### Active Alarms

This page displays a table with the current alarms on the device.

### Network

This page displays network parameters. Note that these parameters are retrieved via SNMP. The polling can be enabled or disabled with the **Network Data Polling** toggle button.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
