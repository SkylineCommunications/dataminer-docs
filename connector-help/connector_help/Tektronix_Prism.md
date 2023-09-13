---
uid: Connector_help_Tektronix_Prism
---

# Tektronix Prism

The Tektronix Prism is a media monitoring and analysis platform that can handle SDI and IP streams. This connector monitors the configuration and statistics associated with its inputs, as well as the relevant information that can be found in its management interface. The connector also allows the user to set the configuration parameters of its inputs.

## About

The device exposes a REST interface based on JSON. There is no authentication, as this is not supported by the API. The connector makes periodic requests to the device and breaks the response into different parameters. Most calls return composed, structured parameter values. Set operations use HTTP POST requests.

### Version Info

| **Range**            | **Description**                                                                                                                                                                                                                                 | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x \[Obsolete\] | Initial branch. Supports configuration of device inputs and monitors all basic parameters.                                                                                                                                                      | Yes                 | Yes                     |
| 1.0.1.x \[Obsolete\] | Revised version.                                                                                                                                                                                                                                | Yes                 | Yes                     |
| 1.0.2.x \[Obsolete\] | Changed column display order for Audio Flow Configuration and Video Flow Configuration tables.                                                                                                                                                  | Yes                 | Yes                     |
| 1.0.3.x \[SLC Main\] | Primary keys Audio Flow Configuration updated to new format to guarantee unique keys. Default primary key format setting for Flows table and Selected Flows table also updated to include the port in the primary key to guarantee unique keys. | Yes                 | Yes                     |

### Product Info

| **Range** | **Supported Firmware**                                                            |
|-----------|-----------------------------------------------------------------------------------|
| 1.0.3.x   | 1.6 1.5 in read-only mode (input configuration might not be available completely) |

## Configuration

### Connections

#### HTTP main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The IP address of the device.
- **IP port**: The port of the management interface. By default, this port is 9000.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## Usage

### General

This page mostly displays general information related to the hardware, such as the **firmware version**, **serial number**, **uptime**, **BIOS time**, and **host name**.

### Inputs

This page contains two tables that display the **audio** and **video flows** that are currently being processed by the device. Since a **redundancy** flow may be available for a single flow, the ID in each table is a combination of the input ID (0-5), a dot (".") and zero (0) if it is the main flow or one (1) if it is the redundancy flow. At the bottom of the page, a table lists the **inputs** and their respective names. In these tables, it is possible to configure the **source and destination ports** and **destination and source addresses**, as well as the **prefix** per flow.

This page also contains the **Input Status** page button, which displays information such as colorimetry, OETF encoding, transport format and **type** and **video scope** information.

### Audio

This page contains information about the audio configuration, including the parameters **Mixer Volume**, **Test Play**, **Test Volume**, **Test Frequency**, and the **Mute** status.

### PTP Information

This page displays information about the **PTP** (Precision Time Protocol) configuration. This includes the **announce**, **sync**, **delay resp** and **delay req rates**, the **grand master configuration**, and the **lock status**. For most of these parameters, trending and alarm monitoring can be activated.

### Flows

This page displays a table listing the flows that are currently being processed by the device. Unlike the tables on the Inputs page, here you will also find detailed information on each flow, such as **Bitrate**, **Total Buffer Size**, and **Packets**.

This page also allows you to create and configure new flows to be added to the device. You can do so on the **Flow Creation** page. Fill in the required information on this page to create new flows. The **Flow Configuration** table can be configured via its right-click menu. This not only influences this table, but also the **Flow IP Configuration** table.

### Network

This page shows information about the network configuration, such as **IP addresses** assigned to the device, **gateways**, **DHCP**, and **bitrate**. You can also access a subpage with low-level Ethernet statistics such as **BER**, **fault packets**, **pauses**, and **errors**.

### Hardware Info

This page contains information about the status of the **fans**, **GPIO**, **jitter**, and **FPGAs**. There is also a subpage with information about the relevant voltages (**Eye**, **PEHA**, **Core**, and **IO**).

### Settings

This page contains the **colorimetry** and **EOTF** settings.

### Session Control

This page currently only contains the **Session Control** parameter but may be expanded with additional parameters for future firmware releases.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface. The web interface is a VNC web client that by default runs on port 6080 of the device.

## DataMiner Connectivity Framework

Version **1.0.0.1** of this connector supports DCF and should only be used with a DMA using DataMiner 9.0.0.5 or higher.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed interfaces

This connector does not expose dynamic interfaces

#### Dynamic Interfaces

Physical Dynamic Interfaces:

- The inputs listed in the **Inputs Table** (on the **Inputs** page) are exposed as "**in**" interfaces. For the current device model, there are always six such interfaces.

### Connections

This connector only exposes physical interfaces.

## Notes

This connector is designed to work in the context of an automated solution. One important consideration is that the input configuration set requests are queued, and they are only processed once the last one has received a response from the device. As such, brief delays can be observed in the user interface if multiple parameters are set at once.
