---
uid: Connector_help_Miranda_nVision_9000_Router_Control
---

# Miranda nVision 9000 Router Control

The **Miranda nVision 9000 Router Control** connector is used to view the status of an NV9000 Router Control System over TCP/IP and control its crosspoints.

This connector uses **serial** communication to configure and monitor routers supporting the nVision NV9000 Ethernet protocol.

## About

### Version Info

| **Range**            | **Key Features**                                                                             | **Based on** | **System Impact**                                                                                                         |
|----------------------|----------------------------------------------------------------------------------------------|--------------|---------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version                                                                              | \-           | \-                                                                                                                        |
| 1.0.1.x \[SLC Main\] | Layout adapted and pages renamed.                                                            | \-           | Users may not be used to the new layout and existing Visio files may need to be adapted because of the page name changes. |
| 1.0.2.1              | DCF implemented.                                                                             | \-           | \-                                                                                                                        |
| 1.0.3.x              | Smart-serial connection added to use a subscription mechanism for device crosspoint changes. | \-           | \-                                                                                                                        |
| 1.0.4.x              | Matrix dimension change                                                                      | \-           | \-                                                                                                                        |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.0.1.x   | \-                     |
| 1.0.2.1   | \-                     |
| 1.0.3.x   | \-                     |
| 1.0.4.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.1   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.3.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.4.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
  - **IP port**: The IP port of the device, e.g. *9193*.

## Usage (Range 1.0.0.x)

### Crosspoints

This page contains the parameters that need to be configured in order to obtain the status of the router's ports. To be able to start the polling, you first need to configure which subset of the router control card's outputs will be polled. You can do this by specifying the **Level Number** and configuring the total number of outputs that are retrieved, using the **Number of Outputs** parameter.

The **Crosspoints Table** contains information about the connected **Destination Ports** and **Source Ports**.

It is possible to set a specific crosspoint by providing a **Source Port Label**, **Destination Port Label**, **Source Level** and **Destination Level** on the **Set Crosspoint** page.

Note: With the **Set Command Mode** parameter on this page, you can select the command for setting crosspoints: *Take Input to Output* (default) or *Device All Levels Take*.

### Input

This page contains the **Crosspoints Input Table**, which stores the present input source ports.

### Output

This page contains the **Crosspoints Output Table**, which stores the present output source ports.

### Matrix

This page displays a **Matrix** that contains the connected **inputs** and **outputs**.

## Usage (Range 1.0.1.x/1.0.3.x/1.0.4.x)

### General

This page contains the parameters that need to be configured in order to obtain the necessary information. Physical parameters are displayed on the left, and device parameters are displayed on the right.

In order to start the polling for physical crosspoints, you first need to configure which subset of the router control card's outputs will be polled. You can do this by specifying the **Level Number** and configuring the total number of outputs that are retrieved, using the **Number of Outputs** parameter. It is possible to enable or disable displaying the physical matrix UI.

For device crosspoint parameters, the start and stop of the destination and source IDs must be indicated. You need to specify the **Device Level Number** in order to then enable or disable the polling of information.

Note:

- **Range 1.0.4.x** implements the **default parking input** feature. When this is active, whenever you disconnect a crosspoint, the output is connected to the default parking input.
- **Range 1.0.4.x** implements communication with the **Virtual Matrix** connector.

### Physical Crosspoints

The **Crosspoints Table** contains information about the connected **Destination Ports** and **Source Ports**.

It is possible to set a specific crosspoint by providing a **Source Port Label**, **Destination Port Label**, **Source Level** and **Destination Level** on the **Set Crosspoint** page.

Note: With the **Set Command Mode** parameter on the General page, you can select the command for setting crosspoints: *Take Input to Output* (default) or *Device All Levels Take*.

### Input

This page contains the **Crosspoints Input Table**, which stores the present input source ports.

### Output

This page contains the **Crosspoints Output Table**, which stores the present output source ports.

### Physical Matrix

This page displays a **Matrix** that contains the connected **inputs** and **outputs**.

### Device Crosspoints

The **Device Crosspoints Table** contains information about the connected **Destination** and **Source IDs**. It is also possible to set a specific crosspoint by means of the **Connected Source** column.

### Device Source

This page contains the **Device Source Table**, which stores the information about the source ports.

### Device Destination

This page contains the **Device Destination Table**, which stores the information about the destination ports.
