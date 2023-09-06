---
uid: Connector_help_Astro_U154_Edge_QAM
---

# Astro U154 Edge QAM

With this driver, you can gather and view information from the device **Astro U154 Edge QAM**, as well as configure the device.

## About

This driver uses HTTP to monitor the **Astro U154 Edge QAM** device. The driver also has an SNMP interface to receive traps from the device.

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

This driver uses both an HTTP and an SNMP connection.

Depending on the setup, the **HTTP** configuration differs: this driver can communicate directly with the **U154**, but it can also be configured to send the requests to the **Astro U100 Controller**, which will then serve as a proxy.

In either case, the **SNMP** interface collects the traps emitted by the device, so the SNMP IP address must be the IP address of the **U154** (not the controller).

#### Serial Connection for Communication with U100C as Proxy

SERIAL Connection:

- **IP address/host**: The IP address of the Astro U100 Controller.
- **IP port**: The port of the destination, e.g. *80*.
- **Bus address**: The IP address of the U154. In addition, "*ByPassProxy*" must be filled in, in order to bypass any possible proxy that could block the HTTP communication. The two fields must be separated by a semicolon, e.g. *ByPassProxy;10.11.12.13.*

#### Serial Connection for Direct Communication

SERIAL Connection:

- **IP address/host**: The IP address of the U154.
- **IP port**: The port of the destination, e.g. *80*.
- **Bus address**: This field can be used to bypass the proxy. To do so, fill in the value *ByPassProxy*.

#### SNMP Connection

SNMP Connection:

- **IP Address/host**: The polling IP of the U154, e.g. *10.11.12.13*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General

This page displays general information about the device.

The credentials of the device must be filled in via the **Login** page button.

Some important parameters are available at the end of the first column:

- **Controller Name**: This parameter shows the name of the **Astro Virtual Controller** element that manages this device. If no such element is used, the parameter will show the exception value *No Virtual Controller Found*.

- **Communication Type**:

- *Direct Communication*: The element sends the requests directly to the Astro module.
  - *U100C Proxy*: The element sends the requests to the Astro U100 Controller, which will forward them to the Astro module. The controller acts as a proxy.

- **Communication Method**: This parameter is only available in *Direct Communication* mode.

- *Login*: The element logs in to the device before every request (read and write requests).
  - *Anonymous*: The element only logs in to the device for write requests. The device does not log in for read requests.

### Status

This page displays the status of the device. E.g.: **Temperature**, **Power Supply**, **CPU Load**, ...

### Main

On this page, you can access the main configuration of the device. E.g.: **DNS**, **Time Source**, **Interfaces**, ...

### Test Gen

On this page, you can configure the test gen parameters. E.g.: **Data Rate**, **Packet ID**, ...

### IP Channel

On this page, you can configure the IP channels using the **IP RX Channel Settings** table.

At the top of the page, two page buttons are available: **More Settings** and **IP Rx Status**.

### RF

On this page, you can configure the RF channels using the **RF Channel** table.

Several page buttons are available with more RF configuration options and statistics.

### Time Zone

On this page, you can configure the Time Zone settings.

### In Out Status

This page contains a summary of the links between inputs and outputs.

### TS Processing

On this page, you can configure the PAT and NIT Processing.

### NIT

This page shows the NIT configuration.

It is possible to add an external transport stream here. To do so, right-click the table, select the option **Add External Transport Stream** and fill in the necessary information.

### Update/Config

On this page, you can upload/download config files to/from the device, and perform a software update.

#### Configuration Files (Download/Upload)

The following table provides more information on how to upload/download configuration files to/from the device:

<table>
<colgroup>
<col style="width: 50%" />
<col style="width: 50%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Download</strong></td>
<td><strong>Upload</strong></td>
</tr>
<tr class="even">
<td>To download a file, click <strong>Download</strong>. This following pop-up will be displayed:
<p><img src="/SiteAssets/Driver%20Help/Astro%20U116%20Edge%20PAL/Download.PNG" alt="Download.PNG" /> Enter the name of the file, then click <strong>OK</strong>.</p>
<p>The file will be saved at the following location:</p>
<p><em>C:\Skyline DataMiner\Documents\&lt;protocol name&gt;\&lt;element name&gt;\&lt;file name&gt;</em></p></td>
<td>To upload a file, click <strong>Upload</strong>. The following pop-up will be displayed:
<p><img src="/SiteAssets/Driver%20Help/Astro%20U116%20Edge%20PAL/Upload.PNG" alt="Upload.PNG" /> <strong>Module Name</strong> lists all the Astro elements of the same type in the system.</p>
<p><strong>Upload File Name</strong> lists all the files available in the Documents folder of the selected module.</p>
<p>The file to be uploaded is located at:</p>
<p><em>C:\Skyline DataMiner\Documents\&lt;protocol name&gt;\&lt;element name&gt;\&lt;file name&gt;</em></p></td>
</tr>
</tbody>
</table>

#### Software Update

The driver allows you to upload a firmware archive from the local disk of the DMA:

![SoftwareUpdate.PNG](~/connector-help/images/Astro_U154_Edge_QAM_SoftwareUpdate.PNG)

The **Firmware File** parameter is used to select which file to upload. The drop-down list contains all the files present in the following directory of the DMA: *C:\Skyline DataMiner\Documents\\Protocol Name\>*.

Once the file is selected, click the button **Update and Reboot** to start the upgrade. To follow the update progress, click the **Update Progress** page button. However, traps must be configured for this to be possible.

### Licensing

This page shows the available licenses for this Astro device.

### System Log

This page contains a table listing all the log entries. You can download the log files by clicking the **Download** buttons. To access the log settings, click the **System Log Config** page button.

### Alarm Severities

On this page, you can set the severity for each alarm type.

### Active Alarms

This page displays a table with the current alarms on the device.

### Network

This page displays network parameters.

Note that these parameters are retrieved via SNMP. The polling can be enabled/disabled using the **Network Data Polling** toggle button.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
