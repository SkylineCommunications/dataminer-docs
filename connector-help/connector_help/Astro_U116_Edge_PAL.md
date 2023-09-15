---
uid: Connector_help_Astro_U116_Edge_PAL
---

# Astro U116 Edge PAL

Through this connector is possible to gather and view information from the device **Astro U116 Edge PAL**. It also gives the possibility to configure the device.

## About

HTTP connector to monitor the **Astro U116 Edge PAL** device.

This connector also contains a SNMP interface to receive traps from the device and polls some network information.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 5595                        |

## Installation and configuration

### Creation

### HTTP

This connector can communicate directly to the **U116** but it can also be configured to send the requests to the **Astro U100 Controller** which will then serve as a proxy. Depending on the case, the **HTTP** configuration differs :

A\) Communication with U100C as proxy :

**SERIAL Connection:**

- **IP address/host**: the IP address of the Astro U100 Controller
- **IP port**: the port of the destination e.g. 80
- **Bus address**: The IP address of the U116. Also, we must fill in 'ByPassProxy' to bypass any possible proxy which could block the HTTP communication. Both fields must be separated by a semi-column. e.g : ByPassProxy;10.11.12.13

B\) Direct Communication :

**SERIAL Connection:**

- **IP address/host**: The IP address of the U116
- **IP port**: the port of the destination e.g. 80
- **Bus address**: this field can be used to bypass the proxy. To do so fill in the value ByPassProxy.

### SNMP

In either case, the **SNMP** interface collects the traps emitted by the device, so the SNMP IP Address must be the IP Address of the **U116** (not the controller).

**SNMP Connection:**

- **IP Address/host**: The polling IP of the U116, e.g. 10.11.12.13

**SNMP Settings:**

- **Port number**: the port of the connected device, default 161
- **Get community string**: the community string in order to read from the device. The default value is public.
- **Set community string**: the community string in order to set to the device. The default value is private.

## Usage

### General

This page displays some general information about the device.

The credentials of the device must be filled-in behind the **Login** page button.

Some important parameters are available at the end of the first column :

- **Controller Name** : this parameter shows the name of the **Astro Virtual Controller** element which manages this device. If no such element is used, the parameter will show the exception value *No Virtual Controller Found*.

- **Communication Type** :

  - *Direct Communication* : The element sends the requests directly to the Astro module device.
  - *U100C Proxy* : The element sends the requests to the Astro U100 Controller which will forward them to the Astro module. The controller acts as a proxy.

- **Communication Method** : this parameter is only available in *Direct Communication* mode.

  - *Login* : The element logs in to the device before every requests (read and write requests).
  - *Anonymous* : The element logs in to the device only for write requests. The device does not login before read requests.

### Status

This page displays the status of the device. E.g.: **Temperature**, **Power Supply**, **CPU Load**,...

### Main

This page allows to configure the main configurations of the device. E.g.: **DNS**, **Time Source**, **Interfaces**,...

### Test Gen

This page allows to configure the test gen parameters. E.g.: **Data Rate**, **Packet ID**,...

### IP Channel

This page allows to configure the IP channels, through the IP RX Channel Settings table.

In this page is also present two page buttons: **More Settings .** and IP **Rx Status .**.

### RF

This page allows to configure the RF channels, through the RF Channel table.

This page contains as well several page buttons with more RF configurations and statistics.

### RF1.1

Page with the channel RF1.1 settings.

### RF1.2

Page with the channel RF1.2 settings.

### RF2.1

Page with the channel RF2.1 settings.

### RF2.2

Page with the channel RF2.2 settings.

### Time Sharing

This page allows to configure the Time Zone Settings.

### OSD

Page with OSD settings.

### In Out Status

Summary about the links between inputs and outputs.

### Update/Config

This page allows the user to upload/download config files to/from the device. The user can also perform a software update.

1\. Configuration Files (Download/Upload)

The following table allows the user to upload/download configuration files to the device:

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
<td><p>To download a file, click on `Download'. This pop-up will be shown:</p>
<p><img src="/SiteAssets/Driver%20Help/Astro%20U116%20Edge%20PAL/Download.PNG" alt="Download.PNG" /></p>
<p>Enter the name of the file then click on `OK'. The file will be saved at this location:</p>
<p>C:\Skyline DataMiner\Documents\&lt;protocol name&gt;\&lt;element name&gt;\&lt;file name&gt;</p></td>
<td><p>To upload a file, click on `Upload. This pop-up will be shown:</p>
<p><img src="/SiteAssets/Driver%20Help/Astro%20U116%20Edge%20PAL/Upload.PNG" alt="Upload.PNG" /><img src="" /></p>
<p><strong>Module Name</strong> lists all the Astro elements of the same type in the system.</p>
<p><strong>Upload File Name</strong> lists all the files available in Documents folder of the selected module.</p>
The file to be uploaded is located at: C:\Skyline DataMiner\Documents\&lt;protocol name&gt;\&lt;element name&gt;\&lt;file name&gt;</td>
</tr>
</tbody>
</table>

2\. Software Update

The connector allows the user to upload a firmware archive from the local disk of the DMA:

![SoftwareUpdate.PNG](~/connector-help/images/Astro_U116_Edge_PAL_SoftwareUpdate.PNG)

The **Firmware File** parameter is used to select which file to upload. The dropdown lists all the files present in the DMA hard drive at the location: C:\Skyline DataMiner\Documents\\Protocol Name\>.

Once the file is selected, the user can click the button **Update and Reboot** to start the upgrade. The update progress can be observed in the page behind the **Update Progress** page button. Traps must be configured for that.

### Licensing

Shows the available licenses for this Astro device.

### System Log

This page contains a table listing all the log entries. The user can download the log files by clicking on the **Download** buttons. Log Settings are available via the **System Log Config** page button.

### Alarm Severities

In this page, the user can set the severity for each alarm type.

### Active Alarms

This page displays a table with the device's current alarms.

### Network

This page displays Network parameters. Note that this parameter are retrieved via SNMP. The polling can be enabled/disabled using the **Network Data Polling** toggle button.

### Web Interface

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
