---
uid: Connector_help_Astro_U148
---

# Astro U148

This connector can be used with the following devices: **Astro U144**, **U148** and **U149**. It allows you to gather and view information from these devices as well as configure them.

This connector uses **HTTP** to monitor the device. It also uses an **SNMP** interface to receive traps from the device.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                                                                                                                                                                                                         | **Based on** | **System Impact**                                                                                                                                                                                                                                                          |
|----------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x \[Obsolete\] | Initial version                                                                                                                                                                                                                                                                                                          | \-           | \-                                                                                                                                                                                                                                                                         |
| 1.0.1.x \[SLC Main\] | \- **Removed** the **Connection Method Login** option since it was causing issues when trying to set parameter values such as the Transponder Frequency. - **Added** the **Web Interface Entrance** parameter, the **Login Message** parameter (both located on the Login page), and logic to check each login response. | 1.0.0.24     | Connection Method (read parameter with ID 85 and write parameter with ID 86) has been removed. Impact: Alarm/trend templates and Visio drawings will need to be reviewed. All templates or Visio drawings that reference these removed parameters will need to be adapted. |

### Product Info

| **Range** | **Supported Firmware**                            |
|-----------|---------------------------------------------------|
| 1.0.0.x   | 5595 5799 5974 5987 6010 6420 6800 6810 6900 6910 |
| 1.0.1.x   | 5595 5799 5974 5987 6010 6420 6800 6810 6900 6910 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.0.8   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.1.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

This connector uses two interfaces: an HTTP interface to retrieve the data and an SNMP interface to collect the traps.

Depending on the setup, the **HTTP** configuration can be different: this connector can communicate directly with the **U144/148/149** device being used, but it can also be configured to send the requests to the **Astro U100 Controller**, which will then serve as a proxy.

In either case, the **SNMP** interface collects the traps emitted by the device, so the SNMP IP address must be the IP address of the **U144/148/149** device (not the controller).

HTTP Connection for Communication with U100C as Proxy

- **IP address/host**: The IP address of the Astro U100 Controller.
- **IP port**: The port of the destination, e.g. *80*.
- **Bus address:** The IP address of the U148. In addition, "*ByPassProxy*" must be filled in to bypass any possible proxy that could block the HTTP communication. The two fields must be separated by a semicolon, e.g. *ByPassProxy;10.11.12.13.*

#### HTTP Connection for Direct Communication

- **IP address/host**: The IP address of the U148.
- **IP port**: The port of the destination e.g. *80*.
- **Bus address**: This field can be used to bypass the proxy. To do so, fill in the value *ByPassProxy*.

#### SNMP Connection

- **IP Address/host**: The polling IP of the U148, e.g. *10.11.12.13*.
- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

### Credentials

When a new element is created, if the communication settings are OK, information can be polled from the device without authentication. However, to perform sets on the device, the **Username** and **Password** credentials need to be configured on the **Login** page. The default credentials are:

- **Username**: *admin*
- **Password**: *astro*.

### Alarm forwarding

From version **1.0.0.20** onwards, you can enable/disable the **Controller Alarm Forward** parameter on the **General page**. This parameter enables or disables alarm forwarding to the Astro U100 Controller. If you want to forward alarms to the controller, the **name of the controller element** must have the format ***'Controller Name'.'Name'***.

## Usage

### General

This page displays general information about the device.

The credentials of the device must be filled in via the **Login** page button. The Login page also contains two parameters to indicate the accessibility of the web interface. Since only one user can be logged in at a time, check the **Web Interface Entrance** parameter in case a parameter set does not succeed. If the entrance is closed, the Login Message will show the IP address of the user who is currently blocking the entrance. All failed login attempts are also logged in the element log.

Some important parameters are available at the end of the first column:

- **Controller Name**: This parameter shows the name of the **Astro Virtual Controller** element that manages this device. If no such element is used, the parameter will show the exception value *N/A*.

- **Communication Type**:

  - *Direct Communication*: The element sends the requests directly to the Astro module.
  - *U100C Proxy*: The element sends the requests to the Astro U100 Controller, which will forward them to the Astro module. The controller acts as a proxy.

- **Connection Method**: This parameter is only available in Direct Communication mode, up to version 1.0.0.24. From version 1.0.1.1 onward, it is no longer available.

  - *Login*: The element logs in to the device before every request (read and write requests).
  - *Anonymous*: The element only logs in to the device for write requests. The device does not log in for read requests.

### Status

This page displays the status of the device, e.g. **Temperature**, **Power Supply**, **CPU Load**, etc.

### Main

On this page, you can access the main configuration of the device, e.g. **DNS**, **Time Source**, **Interfaces**, etc.

### Input Settings

On this page, you can configure the settings for the four F sockets. Each socket listens to a specific satellite.

The **Satellites** page button displays a list of all the detected satellites.

### Transponder

This page contains two tables, the first containing the configuration settings of each of the transponders, and the second containing information on the current transponder status.

### IP TX Settings

On this page, you can configure the output IP settings. The device contains 8 output IP channels. Each output IP is redundant (Data A and Data B).

### CAM MUX

The CAM MUX is **only functional** for the **U144 device**. It enables the routing of the input satellite channel to a TX MUX input, using a matrix parameter. The same input can be connected to multiple outputs.

### MUX

To adjust the setup of the multiplexers, the **MUX Setup** table can be used. Also, this page displays an overview of the services that are currently assigned to the transport stream.

To assign a service to a MUX, use the **Add Service** page button at the bottom of the page. A new window will open where you can configure your service. To do so, select a multiplexer, select a service, and select the required SID Out State. Once all fields are filled in, click the Add Service button. Fields like SID and SID Out will be filled in automatically in some situations. When the service is successfully assigned to a MUX, a new entry (with the newly assigned service) will be added to the **Service Selection** table. Note that it is important that you select a **valid service for the multiplexer**.

The **Service Selection** table will show the services that are currently assigned to a MUX. To remove a service from the transport stream, click the corresponding **Delete** button in the Action column of the Service Selection table. It is not possible to modify a service directly in the Service Selection table. Instead, you will need to remove the entry (with the Delete button in the Action column) and add a new one (Add Service page button \> fill in parameters \> Add Service button).

### TX MUX

On this page, you can route the input satellite channel to an output IP channel, using a matrix parameter on the U148/149 device. The same input can be connected to multiple outputs. On the U144, the first 4 TX MUX inputs connect to the 4 CAM modules, while the other 4 directly connect to the 4 RF inputs.

### Update/Config

On this page, you can upload/download config files to/from the device and perform a software update.

### Configuration Files (Download/Upload)

The following table provides more information on how to upload/download configuration files to the device:

- To **download** a file, click *Download*. The following pop-up window will be displayed:

  ![Download.PNG](~/connector-help/images/Download.PNG)

  Enter the name of the file then click on `OK'. The file will be saved at this location:

  `C:\Skyline DataMiner\Documents\<protocol name>\<element name>\<file name>`

- To **upload** a file, click *Upload*. The following pop-up window will be displayed:

  ![Upload.PNG](~/connector-help/images/Upload.PNG)

  **Module Name** lists all the Astro elements of the same type in the system.

  **Upload File Name** lists all the files available in Documents folder of the selected module.

  The file to be uploaded is located at: `C:\Skyline DataMiner\Documents\<protocol name>\<element name>\<file name>`

#### Software Update

The connector allows you to upload a firmware archive from the local disk of the DMA:

![SoftwareUpdate.PNG](~/connector-help/images/Astro_U148_SoftwareUpdate.PNG)

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

## DataMiner Connectivity Framework

DCF is supported in range 1.0.0.x, from version **1.0.0.8 onwards**. It can only be used on a DMA with **9.0.0 \[CU6\]** as the minimum version.

### Interfaces

#### Dynamic Interfaces

- **Sat/RF Inputs** (type: in) interfaces, created from the Input Settings table on the Input Settings page of the connector.
- **Data Ethernet Outputs** (type: out) interfaces, created from the Interface Configuration table on the Main page of the connector.

### Connections

#### Internal Connections

**Internal Connections** between the **Sat/RF Input Ports** and the **Ethernet Data Outputs** are mapped and characterized by the following connection properties: **Transponder Name**, **TS-ID**, **ONID**, **Input Frequency** and **MC (Syntax** **"TX Destination IP:TX Destination Port"** **)**.

## Notes

We recommend creating Astro U148 elements on a DMA running the **Windows Server 2012 R2 Standard operating system or higher**. Elements that were created on a DMA running the Windows Server 2008 R2 Standard operating system can behave incorrectly. When multiple modifications are made to the settings.xml file in a short time period, only the first modification will succeed and the others will fail.
