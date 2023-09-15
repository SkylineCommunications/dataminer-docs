---
uid: Connector_help_T-Vips_TVG430
---

# T-VIPS TVG430

The **T-VIPS TVG430** connector is an SNMP-based connector used to monitor and configure the **T-VIPS TVG430**.

## About

The **TVG430** provides JPEG2000 compression of HD-SDI signals, allowing transmission of HDTV signals over Gigabit Ethernet links as well as over DVB ASI links. The **TVG430** is part of the T-VIPS Video Gateway Suite and is consequently very similar to other T-VIPS TVGxxx connectors.

There are 2 operational modes available for the **T-VIPS TVG430**: *HD-SDI to IP* and *IP to HD-SDI*. This connector allows you to change the operational mode and to modify settings for both operational modes.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.1.x          | Initial version | Yes                 | False                   |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.1.x          | Unknown                     |

## Installation and configuration

### Creation

SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host:** The IP address of the device.
- **Device address:** Can be left empty.

SNMP Settings:

- **Port number:** The port of the connected device, by default *161*.
- **Get community string:** The community string in order to read from the device. The default value is *public*.
- **Set community string:** The community string in order to set to the device. The default value is *private*.

### Alarm Data

After an element is created, alarm data will not be polled immediately. First, the setting **Request Alarm Data** must be enabled. This setting can be found in the right column of the **Main View** page. After the setting is enabled, the alarm information will be polled.

## Usage

### Main View

This page is primarily used to monitor all alarms on the TVG430 device. To view the alarms, the option **Request Alarm Data** must first be enabled. If you do not want information about the alarms, it can be disabled.

### General

This page displays general information about the device, such as the **Product Name**, **System** **Uptime**, etc. Some of these parameters can also be changed, like for example **System Contact** or **System Location**.

With the **Reset Delay** parameter, the device can be reset after a period of time. This value needs to be between *1* and *6*. After this time has elapsed, the device will perform a cold restart.

### HD-SDI to IP

If the **Operation Mode** parameter is set to **HD-SDI to IP**, the parameters for this page will be initialized. Otherwise, the parameters on the **IP to HD-SDI** page will be initialized. The **Operation Mode** setting can be found both on the **HD-SDI to IP** page and the **IP to HD-SDI** page.

This page contains the transceiver parameters. Most of these parameters are bitrate values, but there are also some page buttons that lead to some extra information. The **Audio Tx** page button displays the **Audio Channel table**, which can be used to enable or disable the audio channels. The other page buttons display more transceiver settings.

### IP to HD-SDI

This page is similar to the **HD-SDI to IP** page, but contains the parameters for the receiver parameters. These parameters will only be initialized if the **Operation Mode** is set to **IP to HD-SDI**.

Most of the parameters on this page are bitrate parameters, but the page displays some page buttons as well. The **Audio Tx** page button will display the same page as the page button on the **HD-SDI to IP** page. The other page button displayed on this page leads to general information and settings for the receiver.

### Web Interface

This page can be used to access the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DCF Implementation

### HD-SDI to IP

If the **Operation Mode** parameter is set to **HD-SDI to IP**, a connection will be made from the **SDI-IN** in interface to the **IP** inout interface, which will have the following connection properties:

- 1st property -\> Name: *Service*, Type: *input*, Value: *Tx Input Name*
- 2nd property -\> Name: *IP*, Type: *output*, Value: *Tx Destination IP:Tx Destination UDP Port*

### IP to HD-SDI

If the **Operation Mode** parameter is set to **IP to** **HD-SDI** , a connection will be made from the **IP** inout interface to both **SDI-OUT1** and **SDI-OUT2** out interfaces, which will have the following connection properties:

- 1st property -\> Name: *Service*, Type: *output*, Value: *Rx Output Name*
- 2nd property -\> Name: *IP,* Type: *input*, Value: *Rx Source IP*
