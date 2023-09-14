---
uid: Connector_help_Guntermann_and_Drunck_CATCenter_NEO
---

# Guntermann & Drunck CATCenter NEO

This device is an **Analogue KVM Switch Matrix System**. It is a hardware device that allows a user to control multiple computers from one or more sets of keyboards, video monitors and mice. KVM is the abbreviation for Keyboard, Video and Mouse.

## About

With this connector, it is possible to monitor the status parameters, get the device information and receive the sent traps.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.3.002 (00585)             |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Device address**: Not used.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*

## Usage

### General

This page displays four boxes of information.

- In the top-left corner, the **Status box** displays the parameters **Main Power**, **Redundant Power**, **Temperature**, **Network Interface 0** and **Network Interface 1**.
- In the lower left corner, the **Device Information** box displays the **Device ID**, **Device Class**, **Device Type**, **Serial Number**, **Ethernet Address 1**, **Ethernet Address 2** and **Firmware Version**.
- In the top-right corner, the **System Information** box shows information related to the system, rather than specifically to this device. These parameters are **System Description, System Object ID, System Up Time, System Contact, System Name, System Location** and **System Services.** Unlike most other SNMP connectors, this connector does not allow you to change the System Contact, System Name and System Location parameters directly in DataMiner. This is only possible via the web interface (see below).
- In the lower right corner, the **Error Status** box shows a **General Error Message** provided by the device and a **General Error Code**.

The Status and Error Status boxes are updated every 5 seconds. The Device and System Information is only updated once per hour.

### Traps

At the top of the page, the **Information Events** toggle button allows you to specify whether an information event should be generated when a trap is received.

Below this, you can manage the number of traps that can be stored in the Traps table:

- The **Maximum Number of Traps** can be set to a certain value or disabled. If this number is 100, for instance, the first trap will be deleted from the table when the 101st trap arrives.
- The **Maximum Age of Traps** can be set to a number of days or disabled. If this is set to a particular number of days, traps that are older than this number of days will be deleted from the table.

Note: The Maximum Number of Traps and Maximum Age of Traps cannot be disabled at the same time. At least one of these should be enabled to avoid that an unlimited number of traps are stored.

The **Traps Number** parameter shows the total number of traps currently stored in the Traps table.

The **Traps table** itself displays the following information for each trap: the **Trap Index**, the **Timestamp** specifying when the trap arrived, the **Error Level** of the trap and the **Message** that is in the trap. The last column in the table, **Delete Trap**, allows you to delete a separate trap.

### Web Interface

This page displays the web interface of the device itself, embedded within a frame in the connector.

In the web interface, you can change the **System Contact**, **System Name** and **System** **Location**. These parameters are also displayed on the General page of the connector but can only be changed via the web interface. To find these parameters, in the tree structure left, click **KVM Matrix systems** \> **KVM-DU-Samacom** \> **Matrix switches**. The device and its status parameters will be displayed on the right side of the page. Double-click the row of the device to open a menu. In this menu, select **Network** \> **SNMP Agent**. The three variables will be displayed in the Global section of this page. Do not forget to click Apply or OK after changing.

Of course, it is also possible to configure other settings via the web interface, or even to send a test trap.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
