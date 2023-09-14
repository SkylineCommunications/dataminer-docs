---
uid: Connector_help_Astro_U125_Edge_FM
---

# Astro U125 Edge FM

With this connector, you can monitor and control an **Astro U125 Edge FM** module, which is part of the Astro U100 Series.

The connector uses the HTTP API of the Astro U125 Edge FM device in order to communicate. It also uses an SNMP interface to receive SNMP traps from the device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 5595, 6000, 6200, 6400 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial connection

This connector can communicate directly with the **U125 module**, but it can also be configured to send the requests to the **Astro U100 Controller**, which will then serve as a proxy. Depending on whether direct communication is used or not, the **HTTP** configuration differs, as shown below.

- #### A) Communication with U100C as proxy

> SERIAL Connection:
>
> - **IP address/host**: The IP address of the Astro U100 Controller.
> - **IP port**: The port of the destination, e.g. *80*.
> - **Bus address**: The IP address of the U125. To bypass any possible proxy that could block the HTTP communcation, also add *ByPassProxy*, using a semicolon as separator, e.g. *ByPassProxy;10.11.12.13*.

- **B) Direct communication**

> SERIAL Connection:
>
> - **IP address/host**: The IP address of the U125.
> - **IP port**: The port of the destination, e.g. *80*.
> - **Bus address**: This field can be used to bypass a possible proxy. To do so, fill in the value *ByPassProxy*.

#### SNMP connection

Regardless of which serial connection is used, the SNMP interface collects the traps emitted by the device, so the SNMP IP address must be the IP address of the **U125** (not the controller).

SNMP Connection:

- **IP address/host**: The polling IP of the U125, e.g. *10.11.12.13*.

SNMP Settings:

- **Port number**: The port of the connected device, by default 161.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General

This page displays general information about the device.

Via the **Login** page button, you can fill in the credentials to access the device.

The page also contains the following important parameters:

- **Controller Name**: Displays the name of the **Astro Virtual Controller** element that manages this device. If no such element is used, *No Virtual Controller Found* will be displayed instead.

- **Communication Type**: Can have the following values:

- *Direct Communication*: The element sends requests directly to the Astro module device.
  - *U100C Proxy*: The element sends requests to the Astro U100 Controller, which will forward them to the Astro module. The controller acts as a proxy.

- **Communication Method**: This parameter is only available in direct communication mode. It can have the following values:

- *Login*: The element logs in to the device before every request (this applies both to read and write requests).
  - *Anonymous*: The element only logs in to the device for write requests, but not for read requests.

### Status

This page displays status information for the device, e.g. **Temperature**, **Power Supply**, **CPU Load**, etc.

### Main

On this page, you can configure the main settings of the device, e.g. **DNS**, **Time Source**, **Interfaces**, etc.

### Test Gen

On this page, you can configure the test gen parameters, e.g. **Data Rate**, **Packet ID**, etc.

### IP Channel

On this page, you can configure the IP channels in the **IP RX Channel Settings** table.

### RF

This page allows you to configure the RF channels. It also contains several page buttons that provide access to additional RF settings and statistics.

### Time Zone

This page allows you to configure the time zone settings.

### In Out Status

This page contains information about the links between inputs and outputs.

### Update/Config

This page allows you to upload or download config files to or from the device. You can also perform a software update here.

#### Downloading configuration files

To download a file, click **Download**. The following pop-up window will be displayed:

![Download.PNG](~/connector-help/images/Astro_U125_Edge_FM_Download.PNG)

Enter the name of the file and click OK.

The file will be saved in the following location: *C:\Skyline DataMiner\Documents\\protocol name\>\\element name\>\\file name\>*

#### Uploading configuration files

To download a file, click **Upload**. The following pop-up window will be displayed:

![Upload.PNG](~/connector-help/images/Astro_U125_Edge_FM_Upload.PNG)

**Module Name** lists all the Astro elements of the same type in the system.

**Upload File Name** lists all the files available in the Documents folder of the selected module.

The file to be uploaded is in the following location: *C:\Skyline DataMiner\Documents\\protocol name\>\\element name\>\\file name\>*

#### Performing a software update

The connector allows you to upload a firmware archive from the local disk of the DMA:

![SoftwareUpdate.PNG](~/connector-help/images/Astro_U125_Edge_FM_SoftwareUpdate.PNG)

The **Firmware File** parameter is used to select which file to upload. The drop-down box lists all the files present on the DMA hard drive in the following location: *C:\Skyline DataMiner\Documents\\Protocol Name\>*.

Once you have selected the file, click **Update and Reboot** to start the upgrade. You can check the update progress via the **Update Progress** page button. However, note that traps must be configured for this.

### Licensing

This page shows the available licenses for this Astro device.

### System Log

This page contains a table listing all the log entries. You can download the log files by clicking the **Download** buttons. Log settings are available via the **System Log Config** page button.

### Alarm Severities

On this page, you can set the severity for each alarm type.

### Active Alarms

This page displays a table with the current alarms of the device.

### Network

This page displays network parameters. Note that these parameters are retrieved via SNMP. The polling can be enabled or disabled using the **Network Data Polling** toggle button.

### Web Interface Page

This page provides access to the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
