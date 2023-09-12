---
uid: Connector_help_Snell_Wilcox_IQSRT10
---

# Snell Wilcox IQSRT10

The **Snell Wilcox IQSRT10** is an eight-input router/switcher for HD-SDI 1.5 Gbit/s, SD-SDI 270 Mbit/s, DVB-ASI and wide-band signals.

This driver allows you to manage this device using a smart-serial connection.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial main connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP of the device, e.g. *10.253.112.83*.
  - **IP port**: The IP port of the device, e.g. *2050*.
  - **Bus address**: The unit address and the unit port, e.g. *10.10* (for unit address *0x10* and unit port *0x10*)*.*

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## Usage

The element created with this driver consists of the following data pages:

- **General**: Contains the **Display** parameter and gives an overview of device properties such as **Version**, **Build**, **Serial** and **Firmware**. Also contains buttons that allow you to do a **Restart** and a **Factory Reset.**
- **Crosspoint**: Allows you to set up the input/output routing by changing the source and destination channels. You can also enable the changes to the routing matrix on the template without actually configuring the crosspoint until the **Take** button is pressed. There are four buttons that allow different **Take** configurations.
- **Output 1/2 Switching**: These pages allow you to set up the switching parameters for output 1 and 2 by setting the **Synchronous State**, **Force RP168**, **Output Line** and **Pixel**.
- **Name Association**: Allows you to name the inputs and shows the state for each input.
- **Memory 1-16**: Allows you to define a number of setups of the IQSRT10 to be saved and recalled. Via page button, you can access the configuration for memories 9 to 16.
- **Logging**: Check the appropriate box to see information about various parameters on this page.
- **RollTrack**: Allows you to send information to other compatible units connected on the same networks, using the **Source**, **Address** and **Command** parameters.
- **GPIO**: Allows you to configure the GPI functions.
- **GPIO Debug**: When selected, the debug settings will take priority over the setup options and the setup options will be grayed out.
