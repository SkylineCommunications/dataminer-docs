---
uid: Connector_help_tm_stagetec_systems_DIO
---

# tm stagetec systems DIO

The tm stagetec systems DIO (Dante Input Output) has a wide variety of interface and conversion options. The DIO is powered by PoE (Power over Ethernet) or runs via an external PSU. Redundancy is provided between both power sources.

## About

### Version Info

| **Range** | **Key Features** | **Based on**            | **System Impact** |
|-----------|------------------|-------------------------|-------------------|
| 1.0.0.x   | Initial version  | Delec Unito DIO 1.0.0.x | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 4.02.000.028           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Smart-Serial Main Connection

This driver uses a smart-serial connection and requires the following input during element creation:

SMART-SERIAL CONNECTION:

- Interface connection:

  - **type:** UDP/IP
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.

#### HTTP connection

This driver also uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

On the **General** page, you can configure the **Polling Time**, save the device configuration (under **Unsaved Configuration**) and view general information, such as the **Uptime**, **Temperature**, **Model name** and **XML Configuration version**.

The **Unsaved Configuration** parameter indicates if sets have been sent to the device without saving the configuration. Below this, the **Save Config** button allows you to write all changes to the disk, and the **Clear Flag** button allows you to set the flag to *No* without saving the parameters. Note that the parameter changes apply the moment the parameter is set, but they will only be "set" in active memory. This means that after a device reboot, the changes will be lost. The value of this flag is not retrieved from the device, but updated after any set and cleared when the configuration is saved (or the flag is cleared explicitly). The flag will also be cleared when the element is restarted.

After you have configured the desired polling time (by default 1 minute), you will be able to see all the data being retrieved. The **General** and **System Information** pages display generic information about the device itself. The other pages show the device information by category, such as **SMA (DAC**, **ADC**, **DSP)**, **AES**, **Channel Names**, **GPIO**, etc.
