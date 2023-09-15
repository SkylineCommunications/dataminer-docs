---
uid: Connector_help_CA_Spectrum
---

# CA Spectrum

The **CA Spectrum** connector can be used to retrieve the **devices** and **device alarms** available in the **CA Spectrum Infrastructure Manager**.

## About

This is a **distributed manager** connector, which means that it can be used to (automatically) create multiple elements. Each element will manage a subset of the devices available in the **CA Spectrum Infrastructure Manager** and will retrieve the alarms for those devices. Each CA Spectrum can (if enabled) create **DVEs** for each device (**CA Spectrum Device** protocol). These elements will then display the alarms for that particular device. Note that alarms are not displayed in the main CA Spectrum element itself.

Because the CA Spectrum is a distributed manager connector, 1 element needs to act as the master element, while the other elements act as slaves. The master element decides which element will retrieve and manage the alarms for the different devices in the CA Spectrum Infrastructure Manager. Even if no extra CA Spectrum elements are necessary, the CA Spectrum element still needs to be configured as the master, as otherwise no devices and alarms will be retrieved.

The **CA Spectrum master** element will **sync its data to an XML file** (C:\Skyline DataMiner\Documents\CA Spectrum\MasterSyncFile.xml). This file is used when a new master element needs to be selected.

The devices and alarms are retrieved using the **RESTful HTTP Web Service API** in CA Spectrum.

### Version Info

| **Range** | **Description**                                                                               | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                                                               | No                  | Yes                     |
| 2.0.0.x          | Alarms are received on port instead of via polling. Possibility to get devices from CSV file. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 10.0                        |

### Exported connectors

| **Exported Connector** | **Description**       |
|-----------------------|-----------------------|
| CA Spectrum Device    | Device in CA Spectrum |

## Installation and configuration

### Creation

#### HTTP Main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the CA Spectrum.
- **IP port**: The IP port of the destination, by default *8080*.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

### Configuration of master

To configure a **CA Spectrum** element as master, in the **Master-Slave** section of the **Configuration** page of the element, set the **Master** toggle button to *True*.

If there already is a master CA Spectrum element, it will not be possible to promote another CA Spectrum element to master.

### Configuration of connection

Before the devices and alarms can be requested from the CA Spectrum, you must specify the **credentials**. To do so, go to the **Connection** section of the **Configuration** page of the element.

Note that you only need to specify this on manually created CA Spectrum elements. Elements that are automatically created by the master CA Spectrum element will already have the credentials defined.

## Usage

### Devices

This page displays the **devices** managed by this CA Spectrum element. The **master** element is in charge of deciding which CA Spectrum element will managed which devices.

It is possible to enable automatic DVE creation for each device, by *Enabling* the **Auto Create DVEs** option. Alternatively, you can also manually determine for which device a DVE should be created, by setting **DVE (Device)** to *Enabled*/*Disabled* in the **Devices** table.

If this CA Spectrum element no longer needs to manage one of its devices, this device can be **detached**. It is also possible to detach all devices. However, detaching a device is only possible if **no** **DVE** is created. When a device is detached, the master CA Spectrum element will add it to the list of **unmanaged devices**. These devices can then be assigned to a CA Spectrum element again.

### Configuration

This page contains all configuration settings. Please refer to the "Installation and configuration" section above for information on the configuration of the master and the connection.

The **Polling** section of this page can be used to configure the polling speed of the devices and alarms. Note that devices are only polled by the master element.

Via the **Master Config** page button, you can access the **Master Configuration** subpage. This page contains all the settings that are only applicable to the master CA Spectrum element.

- The right side of this subpage displays the unmanaged devices. By default, all devices retrieved by the master element will be added to the **Unmanaged Devices** table. If these devices need to be assigned to a CA Spectrum element automatically, you should enable **Auto Assign Devices**. Alternatively, you can also assign specific devices to a CA Spectrum element by clicking the **Assign** button. Clicking the **Assign All** button will assign all unmanaged devices to a CA Spectrum element, if the max. load has not yet been reached for all CA Spectrum elements.
- The left side of this subpage displays more information about the available CA Spectrum elements. The **Max Load** indicates how many devices can be assigned to that particular CA Spectrum element. The **DMA Overview** table contains an overview of all DMAs in the cluster and how many CA Spectrum elements can be (automatically) created on each DMA. If the **Max Load** is reached on each CA Spectrum element and there is still spare capacity on a DMA in the cluster, when **Auto Create CA Spectrum Elements** is *Enabled*, the master element will automatically create a new CA Spectrum element to assign new devices.

Via the **Alarm Attributes** page button, you can view all alarm attributes that can be retrieved. By default, all attributes are *Enabled*. If an alarm attribute is *Disabled*, it will not be retrieved from the CA Spectrum and the column will be set to *Not Applicable* in the **Alarms** table (on the DVEs).

### Webpage

This page can be used to access the webpage of the CA Spectrum and launch the **CA Spectrum OneClick Console**. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
