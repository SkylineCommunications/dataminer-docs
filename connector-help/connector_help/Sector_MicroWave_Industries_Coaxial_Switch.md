---
uid: Connector_help_Sector_MicroWave_Industries_Coaxial_Switch
---

# Sector MicroWave Industries Coaxial Switch

The **Sector MicroWave Industries Coaxial Switch** connector is a virtual connector. This means that no information is actually polled directly from a device.

## About

The **Sector MicroWave Industries Coaxial Switch** is a switch between RF switch position 1 and switch position 2. This connector itself in fact only indicates the actual switch position.

## Installation and configuration

### Creation

This connector is a virtual connector, which means it doesn't directly poll information from the actual device. As a consequence, no extra configuration is required during element creation.

### Virtual Element Configuration

Because this is an I/O device, an I/O gateway is used to retrieve and set the information from the **Sector MicroWave Industries Coaxial Switch**. As a consequence, an extra protocol is used to connect with the I/O gateway. The I/O gateway is the link between the DataMiner server and the I/O device. To configure the connection between the **Sector MicroWave Industries Coaxial Switch** element and the I/O gateway element, the virtual element configuration wizard is used.

1. To access the wizard, go to the Element List in System Display.
2. Right-click the **Sector MicroWave** **Industries Coaxial Switch** element, and select "**Configure Virtual Element...**".
3. In the **Configuration Virtual Element** window, an overview of the parameters and their links can be found. To make sure that the parameters are updated with the values from the I/O gateway element, the correct parameters need to be linked to each other. To do this, set the **Linked Element** and the **Linked Parameter** to the element and parameter from the I/O gateway element, by selecting these in the drop-down list.
4. Set the **Element state forwarding** to *Yes*.

Once you have finished this configuration, the parameters in the **Sector MicroWave Industries Coaxial Switch** element will contain the values from the linked parameters in the I/O gateway element.

## Usage

### Main View

The **Main View** only displays the **Switch** **Position**. This can either be *Position 1*, *Position 2* or *Illegal*.

### General

The **General** page also displays the **Switch** **Position,** but in addition it also contains some buttons to change the position. The **Pulse Line** **position 1** and **2** are also displayed on this page.
