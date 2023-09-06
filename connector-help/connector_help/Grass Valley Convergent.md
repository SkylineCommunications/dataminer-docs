---
uid: Connector_help_Grass_Valley_Convergent
---

# Grass Valley Convergent

The Convergent is a video router device that controls video input and output matrices. These matrices connect inputs and outputs, and they can be organized in physical or logical layers. Several layers can be active at the same time.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                                                                             | **Based on**                 | **System Impact**                                                                                                                                                                                                                                                                                                                                                                                                                 |
|----------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version.                                                                                                                                                                             | Miranda Nvision 9000 1.0.3.3 | \-                                                                                                                                                                                                                                                                                                                                                                                                                                |
| 1.0.1.x              | \- Device tables no longer showing wrong data.- Device matrix added.- Crosspoint update subscriptions.                                                                                       | 1.0.0.1                      | Existing elements will need to be recreated.                                                                                                                                                                                                                                                                                                                                                                                      |
| 1.0.2.x              | \- DCF implemented.                                                                                                                                                                          | 1.0.1.7                      | DCF impact.                                                                                                                                                                                                                                                                                                                                                                                                                       |
| 1.0.3.x              | \- Matrix UI removed from element.- Matrix maximum size increased to 10000x10000.- Option to select special "ALL" level that shows aggregated view of all crosspoints across all levels.     | None.                        |                                                                                                                                                                                                                                                                                                                                                                                                                                   |
| 1.0.4.x              | The primary key of the tables Device Sources (PID 3400) and Device Destinations (PID 3500) is now the ID of the Convergent device (External ID).                                             | 1.0.3.4                      | Loss of data: Changing the primary key of a table has a large impact, as all saved data references to the primary key will be lost. This includes element data (i.e. all columns that were saved) and alarm/trend data, since all these records refer to the primary key. Any components that rely on a specific primary key will also need to be adjusted. These could be dashboards, Automation scripts, visual overviews, etc. |
| 1.0.5.x \[SLC Main\] | The connector no longer relies on DataMiner to establish the HTTP connection towards the device. Instead, the device sets up its own connection in order to speed up the communication flow. | 1.0.4.5                      | Existing elements will need to be recreated.                                                                                                                                                                                                                                                                                                                                                                                      |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.0.1.x   | \-                     |
| 1.0.2.x   | \-                     |
| 1.0.3.x   | \-                     |
| 1.0.4.x   | \-                     |
| 1.0.5.x   | \-                     |

### System Info

| **Range** | **MinimumDataMiner Version** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|------------------------------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | 10.0.0.5                     | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | 10.0.0.5                     | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | 10.0.0.5                     | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.3.x   | 10.0.0.5                     | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.4.x   | 10.0.0.5                     | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.5.x   | 10.2.10.0                    | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

Depending on the connector range, the connections detailed below are used. The **redundant serial connection** is used in range **1.0.0.x only**.

#### Serial Connection - Main (range 1.0.0.x - 1.0.4.x)

This connector uses a serial connection and requires the following input during element creation:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination. You can determine the port by adding **9193** to the external ID of the area. You can find the external area ID in the Area Configurator of the Convergent Client application.

#### Serial IP Connection - Subscription Updates Connection (range 1.0.0.x)

This connector uses a serial connection and requires the following input during element creation:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination. You can determine the port by adding **9193** to the external ID of the area. You can find the external area ID in the Area Configurator of the Convergent Client application.

### Initialization (Range 1.0.5.x)

In range 1.0.5.x, you do not need to configure a connection during element creation.

Instead, once the element has been created, go to the **General** \> **Configuration** page, and fill in the connection details to connect to the device.

- **Device IP Address**: The polling IP or URL of the destination.
- **Device Port**: The IP port of the destination.

## How to Use

The focus of the connector is on the routing matrices used to connect outputs and inputs. There are two main areas of the connector: physical and device (logical).

In the element, you can find the data pages described below, depending on the connector range used.

### General (1.0.0.x)

This page contains the parameters that need to be configured in order to obtain the necessary information. Physical parameters are displayed on the left and device parameters are displayed on the right.

In order to start the polling for physical crosspoints, you first need to configure which subset of the router control card's outputs will be polled. You can do this by specifying the **Level Number** and configuring the total number of outputs that are retrieved, using the **Number of Outputs** parameter. It is possible to enable or disable displaying the physical matrix UI.

For device crosspoint parameters, the start and stop of the destination and source IDs must be indicated. You need to specify the **Device Level Number** in order to then enable or disable the polling of information.

### General (1.0.1.x - 1.0.5.x)

This page contains the parameters that need to be configured in order to obtain the necessary information.

In order to start the polling for device crosspoints, first you need to configure which subset of the router control card's outputs will be polled, resorting to the **Device Virtual Level**.

Since this is a router connector, a matrix component is also embedded in the connector, but it is disabled by default. To enable it, toggle the **Display Device Matrix UI** parameter.

A **Default Park Input** configuration is also available, which can be overwritten per output in the **Device Destinations** table on the **Device Crosspoints** page.

### Virtual Levels

This page contains a table with an overview of all levels available on the device.

### Physical Crosspoints (1.0.0.x)

The **Crosspoints Table** displays information about the connected **Destination Ports** and **Source Ports**.

On two subpages, you can find specific information on **Inputs** and **Outputs**, respectively.

Note:

- With the **Set Command Mode** parameter on the General page, you can select the command for setting crosspoints: *Take Input to Output* (default) or *Device All Levels Take*.
- It is possible that the crosspoints are not shown correctly when the port IDs have gaps or start with an offset. This is caused by a bug in the current firmware of the device.

### Physical Matrix (1.0.0.x)

This page displays all the connections between physical **inputs** and **outputs**,using a **matrix** representation.

### Device Crosspoints

This page contains the following tables:

- The **Device Sources** table, with information about the sources**.**
- The **Device Destinations** table, with information about the destinations. It also allows you to set a specific crosspoint by means of the **Connected Input** column.

Changing the labels is not possible, because this is not supported by the device. Locking is also not possible, because this is not supported by the current firmware of the device.

It is possible to set a specific crosspoint by providing a **Source Port Label**, **Destination Port Label**, **Source Level**, and **Destination Level** on the **Custom Take** page.

### Device Matrix

This page displays all the connections between device sources and destinations, using a matrix representation.

### IO Configuration

You can configure how the element will retrieve device data by setting the **Operational Mode** to one of the following modes:

- **Auto** \[Default\]: The element will automatically fetch the device data (Sources/Destinations External IDs and Labels) on a regular time basis and store it in the tables Device Sources and Device Destinations. The elementwill also create a subscription to be immediately notified when a crosspoint change occurs on the device.
- **Manual**: Users need to manually fetch the device data (Sources/Destinations External IDs and Labels) or load it via a CSV file, which must contain the row headers "External ID", "Label", and "Notes".The data is first stored in the tables Device Sources Configuration and Device Destinations Configuration, before it can be applied to the tables Device Sources and Device Destinations.

Note:The Manual mode can be used when unexpected ID and/or label changes have a devastating impact on elements or services linked to the Grass Valley Convergent element. The manual retrieval of data, together with the Configuration tables, prevents the escalation of unwanted ID and/or label changes throughout DataMiner without the awareness of the user.
