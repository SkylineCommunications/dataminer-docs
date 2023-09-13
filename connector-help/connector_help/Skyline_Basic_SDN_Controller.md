---
uid: Connector_help_Skyline_Basic_SDN_Controller
---

# Skyline Basic SDN Controller

The Skyline Basic SDN Controller is a generic solution to control and configure IP streams based on the premise that the configuration is done at the destiny. It assumes that the network is in a "non-blocking" state and that the elements can handle the configuration proposed by the user.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                                                       |
|-----------|------------------------------------------------------------------------------|
| 1.0.0.1   | Not applicable. This is a virtual driver that doesn't connect to any device. |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**            | **Exported Components** |
|-----------|---------------------|-------------------------|----------------------------------|-------------------------|
| 1.0.0.1   | No                  | Yes                     | See "Solution Components" below. | \-                      |

## Solution Components

- **SDN controller:** Based on a generic matrix that allows the interconnecting of inputs and outputs.
- **Connection script:** Automation script that the SDN controller will execute to create the connections.
- **Metadata definition:** Script that defines the metadata format that will be used by the SDN controller.
- **Parameter profiles:** A parameter profile must be defined in the Profiles module for each parameter that the SDN controller will use when the Connection or Disconnection script is called.

## Configuration

### Connections

#### Virtual connection

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

1. Create the SDN element with the desired name and set its state to "Active"

1. Upload or create the Connection and Disconnection scripts. The SDN controller can handle one script for each activity. Specify their names on the **SDN Controller General page**.

   > [!IMPORTANT]
   > These scripts need to be tailored to the environment where your controller will reside. They need to be modified according to the used elements. This applies to the Metadata Editor as well as the SDN Connection Action Script.

1. Define which parameters will be used to connect the different elements.

1. For each parameter, create a profile in the Profiles module. Only the parameter must be included in this profile; the definitions and instances can be empty.

### Redundancy

There is no redundancy defined.

## How to use

Once you have executed all initialization steps, do the following to use the SDN controller:

1. Open the SDN element.

1. In Visual Overview, use the fields to create an association between elements. This will execute the script **Metadata Editor** (which should be adjusted to your environment, as described above).

1. Once the script has finished, you can verify your changes on the **SDN Controller Table View page** in the columns Metadata and Linked Element.

1. If all changes are as expected, you can start using the **Matrix view page** to create connections between elements.

## Notes

The solution does not have any way of knowing if the connection fails from external sources, such as:

- Inputs changed directly in the element after the connection is made in the SDN matrix.

- Element misconfiguration.
