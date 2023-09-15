---
uid: Connector_help_Molden_Media_vizSecure
---

# Molden Media vizSecure

The **Molden Media vizSecure** is a monitoring platform.

## About

This connector can be used to monitor **Molden Media vizSecure**-enabled devices using the **HTTP** protocol.

### Version Info

| **Range** | **Description** |
|------------------|-----------------|
| 1.0.0.x          | Initial version |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### HTTP main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy*.

## Usage

### Devices Page

On this page, the **Devices Table** provides an overview of the devices that can be monitored. In order to add a device to the table, press the **Add Row** button. This will generate a new row in the table, where you can then set the hostname of the device that has to be monitored. In order to start monitoring the newly added device, set its **Polling State** to *Enabled*. In order to stop monitoring a device, set its **Polling State** to *Disabled*. To remove a device from the table, set its **Polling State** to *Delete.*

The **Device Status Table** provides an overview of the status of all devices.

Currently, two types of devices are supported: **VizEngine** and **M2Control**.

### Events Page

This page contains the **Events Table**, which displays all the events returned by the monitored devices.

### Connected Clients Page

This page contains the **Connected Clients Table**, which displays all the clients that are connected to any monitored device.

### Viz Engine Page

On this page, the **Expected Viz Channels Count Table** displays the expected channels, and the **Engine Processes Count Table** displays the number of processes.

In the **DB Status Table** and the **Scene Status Table**, you can find the DB status and scene status, respectively.

Finally, information about the running config can be found in the **Running Config Table** and the **Running Engine Properties Table**.

### Processes Info Page

This page displays the **Process Information Table**, which contains an overview of the processes.

### Profiling Info Page

On this page, you can find an overview of the profiling information in the **Profiling Information Table** and the **VSA** **Profiling Information Table.**

### Profile Status Page

On this page, you can find an overview of the profiling status in the **Profile Status Table**, the **On Air Clients Table** and the **Profile Device Status Table.**

### Profile Settings Page

This page contains an overview of profile settings in the **Profile Settings Table** and the **Device Config Table**.

### Install and Config Page

On this page, you can find an overview of installations and configurations in the **Installation and Configuration Table**, **Config Files Table**, **Plugins Table**, **Log Files Table** and **Dump Files Table**.

### Renderer Status Page

On this page, you can find an overview of the renderer status in the **Renderer Status Table**, **Video In Status Table** and the **Clip Status Table**.

### NVIDIA Page

On this page, you can find an overview of the NVIDIA status and properties in the **NVIDIA Status Table** and the **NVIDIA Properties Table**.

### Multivalue File Page

On this page, you can find an overview of the multivalue files for monitored devices in the **Multivalue File Table**. The values of the files are displayed in the **Monitorable Value Table**.

### License Info Page

On this page, license information is displayed in the **License Info Table**, **License Status Table** and **Licensed Features Table**.

### Web Interface Page

This page allows the user to access the original web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
