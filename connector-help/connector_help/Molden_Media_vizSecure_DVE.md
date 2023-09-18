---
uid: Connector_help_Molden_Media_vizSecure_DVE
---

# Molden Media vizSecure DVE

The **Molden Media vizSecure DVE** connector is used for Dynamic Virtual Elements (DVE) representing devices monitored by the Molden Media vizSecure connector.

## About

This connector can be used to manage a device monitored by the **Molden Media vizSecure** monitoring platform.

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

This connector is used by DVE child elements that are **automatically created** by the parent connector [Molden Media vizSecure](xref:Connector_help_Molden_Media_vizSecure).

## Usage

### Device Page

This page displays the **Hostname**, **Device Type**, **Polling State** and **Status** of the device.

### Events Page

This page contains the **Events Table**, which displays all the events returned by the monitored device.

### Connected Clients Page

This page contains the **Connected Clients** **Table**, which displays all the clients that are connected to the monitored device.

### Viz Engine

On this page, the **Channels Count** parameter displays the expected channels, and the **Process Count** parameter displays the number of processes.

The DB status is displayed by the **Connected**, **Server Type**, **Server Name**, **Server Port** and **User** parameters.

Finally, information about the running config can be found in the **Running Config Table** and the **Running Engine Properties Table**.

### Processes Info Page

This page displays the **Process Information Table**, which contains an overview of the processes.

### Profiling Info Page

On this page, you can find an overview of the profiling information in the **Profiling Information Table** and the **VSA** **Profiling Information Table.**

### Profile Status Page

On this page, you can find an overview of the profiling status in the **Profile Status Table**, the **On Air Clients Table** and the **Profile Device Status Table.**

### Profile Settings Page

On this page, you can find an overview of profile stettings in the **Profile Settings Table** and the **Device Config Table**.

### Install and Config Page

On this page, you can find an overview of installations and configurations in the **Installation and Configuration Table**, **Config Files Table**, **Plugins Table**, **Log Files Table** and **Dump Files Table**.

### Renderer Status Page

On this page, you can find an overview of the renderer status in the **Renderer Status Table**, **Video In Status Table** and the **Clip Status Table**.

### NVIDIA Page

On this page, you can find an overview of the NVIDIA status and properties in the **NVIDIA Status Table** and the **NVIDIA Properties Table**.

### Multivalue File Page

This page displays the multivalue files for the monitored device in the **Multivalue File Table**. The values of the files are displayed in the **Monitorable Value Table.**

### License Info Page

On this page, license information is displayed in the **License Info Table**, **License Status Table** and **Licensed Features Table**.

### Web Interface Page

This page allows the user to access the original web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
