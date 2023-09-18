---
uid: Connector_help_Imagine_Communications_Platinum_Router
---

# Imagine Communications Platinum Router

This is a serial connector that is used to monitor and control the device **Imagine Communications Platinum Router.**

## About

A platinum router is a matrix that can switch different types of sources (Audio/Video). The matrix can also be divided into several "virtual" matrixes, which each create a new level.

This connector requires **DataMiner version 8.5.3** or higher.

### Version Info

| **Range** | **Description**                                         | **DCF Integration** | **Cassandra Compliant** |
|------------------|---------------------------------------------------------|---------------------|-------------------------|
| 1.1.0.x          | Initial version.                                        | Yes                 | No                      |
| 1.1.2.x          | Added SNMP tables for input and output signal presence. | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.1.0.x 1.1.2.x  | Unknown                     |

## Installation and configuration

### Creation

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The default value is *52116*.
- **Bus address**: A one-based number between 1 and 16, 16 included. Defines the level that is monitored by the connector.
- **Ignore** the **Timeout of a single command** and **Number of retries** settings (the latter should be *0*).
  (Note: it is possible to configure an element timeout in the **Advanced element settings**.)

#### SNMP secondary connection

In range 1.1.2.x, the connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *62.245.205.52.*
- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, e.g. *public*.
- **Set community string**: The community string used when setting values on the device, e.g. *private*.

### Configuration in case the matrix remains empty

In case the matrix remains empty after you have created the element, check if the IP address, bus address and port are correct. Also verify if the DataMiner software is version 8.0.5.4 or later.
If this is the case and all settings seem correct, check the element log file and verify if there is no firewall blocking traffic on port 52116.

## Usage

### Main View Page

On this page, you can view the status of the device matrix, and make changes to the matrix.

### Table View Page (version 1.1.0.3 onwards)

On this page, you can view a table representation of the matrix, and you can also set a crosspoint or disconnect it.
This is only available if the appropriate setting is configured on the **Configuration Page**.

### Configuration Page

On this page, the following settings can be configured:

- **Number of Inputs Visible**
- **Number of Outputs Visible**
- **Matrix Resize Method**
- **Table View of Matrix (v. 1.1.0.3 onwards)**

## Usage (1.1.2.x)

### Main View Page

On this page, you can view the status of the device matrix, and make changes to the matrix.

### Table View Page

On this page, you can view a table representation of the matrix, and you can also set a crosspoint or disconnect it.
This is only available if the appropriate setting is configured on the **Configuration Page**.

### Configuration Page

On this page, the following settings can be configured:

- **Number of Inputs Visible**
- **Number of Outputs Visible**
- **Matrix Resize Method**
- **Table View of Matrix**

### Input Presence Page

On this page, the presence of certain selected inputs is shown.

For inputs to be shown, you must enable the **Poll State** of the input on the **Input Configuration** page, which is accessible via a page button.

### Output Presence Page

On this page, the presence of certain selected outputs is shown.

For inputs to be shown, you must enable the **Poll State** of the outputs on the **Output Configuration** page, which is accessible via a page button.

## Notes

- Once the element has been created, the connector shows the connected crosspoints on the configured level. You can change the connected input for an output by clicking the new input. The Platinum Router will then automatically disconnect the originally connected input in order to connect the new input. This means that the connector will not send a disconnect command. It is currently not possible to disconnect a connected input, so the connector will never send a disconnect command. All communication happens through the LRC (Logical Router Control) protocol, which also sends notifications when a change occurs, so that changes are updated in real time.
- All sets are (currently) done ONLY on the level that is being monitored.
- It is possible to hide some inputs and outputs from the matrix. To do so, go to the **Configuration** page and set the **Matrix Resize Method** to *Manual.* Then set the **Number of Inputs Visible** to the number you want to see. The same applies for the outputs. When you do this, only the first chosen number of inputs and outputs will be visible in the matrix.
- The maximum number of inputs and outputs is 640.
- When you set the **Matrix Resize Method** to *Automatic*, the connector will query the dimensions of the matrix and show only the first N and M inputs and outputs.
  From version 1.1.0.3 onwards, there is also a **Table View Page**, which shows a Table View of the matrix, and allows you to connect or disconnect crosspoints.
