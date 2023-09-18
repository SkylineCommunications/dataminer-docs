---
uid: Connector_help_T-Vips_TVG415
---

# T-VIPS TVG415

The **T-VIPS TVG415** connector is an SNMP-based connector used to monitor and configure the **T-VIPS TVG415**.

## About

The **TVG415** provides a monitoring interface to the **T-VIPS TVG415** IP Video Gateway device.

## Installation and configuration

### Creation

The **T-VIPS TVG415** is an SNMP connector. The IP needs to be configured during creation of the element.

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### Main View

The **Main View** is primarily used to monitor all alarms on the **TVG415** device. To view the alarms, the option **Request Alarm Data** must first be enabled. If you do not want information about the alarms, it can be disabled.

### General

The **General** page displays general information on the device, for example **Product Name**, **System** **Uptime,** . Some of these parameters can also be changed, like for example **System Contact** or **System Location**.

Using the **Reset Delay** parameter, the device can be reset after a period of time. This value needs to be between *1* and *6*. After this time has elapsed, the device will perform a cold restart.

### SDI to IP

If the **Operation Mode** parameter is set to **SDI to IP**, the parameters for this page will be initialized. Otherwise, the parameters on the **IP to SDI** page will be initialized. The **Operation Mode** setting can be found on the **SDI to IP** page and the **IP to SDI** page.

This page contains the transceiver parameters. Most of these parameters are bitrate values, but there are also some page buttons that lead to extra information. The **Audio Tx** page button displays the **Audio Channel** table that can be used to enable or disable the audio channels. The other page buttons display more transceiver settings.

### IP to SDI

This page is similar to the **SDI to IP** page, but contains the parameters for the receiver parameters. These parameters will only be initialized if the **Operation Mode** is set to **IP to SDI**.

Most of the parameters on this page are bitrate parameters, but the page displays some page buttons as well. The **Audio Tx** page button will display the same page as the page button on the **HD-SDI to IP** page. The other page button displayed on this page leads to general information and settings for the receiver.

### Web interface

This page can be used to access the web interface of the device.

## DCF Implementation

### SDI to IP

If the **Operation Mode** parameter is set to **SDI to IP**, a connection will be made from the **SDI** inout interface to the **IP** inout interface, which will have the following connection properties:

- 1st Property -\> Name: Service ; Type: in/out ; Value: Tx Input Name
- 2nd Property -\> Name: IP ; Type: output ; Value: Tx Destination IP:Tx Destination UDP Port

### IP to SDI

If the **Operation Mode** parameter is set to **IP to SDI**, a connection will be made from the **IP** inout interface to the **SDI** inout interface, which will have the following connection properties:

- 1st Property -\> Name: Service ; Type: in/out ; Value: Rx Output Name
- 2nd Property -\> Name: IP ; Type: input ; Value: Rx Source IP
