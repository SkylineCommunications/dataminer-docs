---
uid: Connector_help_Enensys_Gateway_NN6-T2
---

# Enensys Gateway NN6-T2

The **Enensys Gateway NN6-T2** is a DVB-T2 Gateway that is used to deliver TV services over second-generation terrestrial networks.

## About

This driver is mainly used to monitor the device, but also allows the configuration of certain parameters, such as the general device information and the date and time settings.

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact**                                                                                                                                                   |
|----------------------|------------------|--------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version  | \-           | \-                                                                                                                                                                  |
| 1.0.1.x \[SLC Main\] | Driver review    | 1.0.0.1      | The entire driver was updated considering the newest DMA features. Furthermore, the vendor discontinued the main MIB and the driver suffered a considerable change. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Unknown                |
| 1.0.1.x   | 1.8.2                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP main connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## How to Use

### System page (renamed since version 1.0.1.1)

This page displays standard parameters and the device temperature. In the **Control** section, you can configure and control the device.

The **Clock Reference** displays the **source** of the device's clock and also displays the **GPS Status.** Note that in driver versions **prior to 1.0.1.1**, these parameters were **on the Monitoring page**.

There are buttons that can be used to make the **LED blink**, to **Reboot** the device and to reset the device to factory settings (**Factory Reset**).

The following page buttons are available:

- **Options**: Displays a list of the activated options.
- **Network interface**:Allows you to configure the network interface.
- **Control:** Allows you to change the date and time.
- **Trap receiver:** Allows you to configure the trap settings.

### Monitoring page (removed since version 1.0.1.1 - no longer supported by the vendor)

This page allows you to monitor parameters specific for this device, such as basic **Input** and **Output** parameters.

The **Clock Reference** displays the **source** of the device's clock and also displays the **GPS Status**. Note that these parameters have been moved to the **System page** from version **1.0.1.1** onwards**.**

The following page buttons are available:

- **Network:** Displays the overall network parameters (T2 System and SFN).
- **T2 Frame:** Displays the overall frame structure and modulation parameters.
- **PLP Settings:** Displays the different PLPs.

### IP Module page (added in version 1.0.1.1)

This page contains information regarding the IP module included in the T2 Gateway. It allows you to monitor and configure each entry.

### Alarms page

This page displays the **Current Active Alarms** and **Status** of the device, including a list of the active alarms in the **Current Alarms** table**.** Two additional buttons are available: **Clear Log** and **Refresh Log.**

The following page buttons are available:

- **Alarm Configurations:** Allows you to configure the different alarms, their severity, traps, counter, etc.
- **Log Table:** Displays the logging of the alarm activity and other useful information regarding the device.

### Web Interface page

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
