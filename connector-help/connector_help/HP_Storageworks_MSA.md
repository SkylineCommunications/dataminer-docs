---
uid: Connector_help_HP_Storageworks_MSA
---

# HP Storageworks MSA

The **HP Storageworks MSA** is a storage area network (SAN) and direct-attached storage (DAS) solution designed for small to medium sized deployments or remote locations.

## About

The **HP Storageworks MSA** connector is used to monitor and control the HP Storageworks MSA device. The information is divided over different pages, and the settings can be modified.

### Version Info

| **Range**     | **Description**                                                                                                                                                                                                                                                                                      | **DCF Integration** | **Cassandra Compliant** |
|----------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 2.0.0.x              | Changed connector to new MIBs                                                                                                                                                                                                                                                                           | No                  | True                    |
| 3.0.0.x \[SLC Main\] | HTTP only version, Note that this version is not compatible with the previous versions.Features Implemented: + Features General Info, Controllers, Enclosures, Fans, Power Supplies, Volumes, Disks, Hosts and Event Log. + Implemented Physical and Logical Tree Control to resemble the device UI. | No                  | True                    |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 2.0.0.x          | GL200                       |
| 3.0.0.x          | GL220 or above.             |

## Installation and configuration

Creation for v2.0.0.x

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not used.

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

Creation for v3.0.0.x

#### HTTP Main Connection

This connector uses a HTTP connection and requires the following input during element creation:

HTTP Settings:

- **IP address/host**: The polling IP of the device, eg 10.11.12.13

## Usage for connector Range v2.0.0.x

### General page

The **General** page displays two blocks of data:

- **System**: General information regarding the system.
- **Operating System**: General information regarding the operating system.

The page also contains the **Firmware** page button, which can be used to access a pop-up page with the **Firmware** **Version** **Table**.

### Interface page

The **Interface** **page** displays the interface table.

Underneath the **Interface** **Table**, a page button is available that opens a pop-up page regarding the **NIC**.

### Connection page

The **Connection** page displays information regarding connectivity. The **Connectivity** **Units Table** displays general information on the system's units. Underneath it, there are three page buttons that will each open a pop-up page displaying a table related to the subject displayed on the page button.

### Sensor page

On this page, the **Connectivity** **Unit** **Sensor** **Table** is displayed.

### Webpage

This page displays the web interface of the device.

## Usage for connector Range v3.0.0.x

### General

The **General** page displays two blocks of data:

- **System**: General information regarding the system.

### Physical

The **Physical** page resembles the device's Physical tree control to display all information regarding each **enclosure** present in the device as well as all the **fans**, **power supplies** and **disks installed** in each **enclosure**.

### Controllers

The **Controllers** page displays all present controllers in the device while also showing additional details regarding **health**, **status** and other configurations.

### Logical

The Logical page displays information regarding the **Virtual Disks** and **Volumes**.

### Hosts

The **Hosts** page displays detailed information about the **Hosts**.

### Events

The **Events** page presents the Log Table. The user may **enable or disable the polling** of this page and also manage the **ammount of event entries** to poll from the device.

### Web Interface

This page displays the web interface of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
