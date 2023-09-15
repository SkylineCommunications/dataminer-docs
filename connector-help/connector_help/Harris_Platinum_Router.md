---
uid: Connector_help_Harris_Platinum_Router
---

# Harris Platinum Router

This connector monitors a **Harris Platinum Router** (sometimes also referred to as a Leitch Router).

## About

This connector is based on the **Leitch Matrix SNMP** connector (version 1.1.0.19) and should have the same features as that connector, though it is possible that deviations will occur in future versions. The difference between the **Harris Platinum Router** and the **Leitch Matrix SNMP** connector is mainly in the protocol used to communicate between DataMiner and the device. Where the Leitch connector only uses SNMP, the Platinum connector uses both SNMP and the LRC protocol. The LRC protocol allows for faster polling and event messages when changes of crosspoint settings occur.

Note: The Harris Platinum Router can be configured to have several levels. In that case, only one level is monitored by the connector.

## Installation and configuration

### Creation

Two connections are required for this connector. The main connection, used for most of the communication, is an **SNMP** connection. In addition, there is also an **LRC** connection, which is used to get and set crosspoints in the matrix, and to receive notification messages of changes regarding the crosspoints.

#### Main Connection

SNMP CONNECTION:

- **IP Address/host**: The IP of the device.
- **Device Address**: The level which you want to monitor. If no levels are configured, use 0.

SNMP Settings:

- **Port Number**: The port of the connected device, by default *161.*
- **Get Community String**: The community string used when reading values from the device. The default value is *public.*
- **Set Community String**: The community string used when setting values on the device. The default value is *private.*

#### LRC Connection

- **IP Address/host**: The IP of the device. (This is the same IP as used in the main connection.)
- **IP Port**: The IP port of the device: *52116.*
- **Number of retries**: Should be set to *0*.

## Usage

Before you use this connector, please read the sections "[Main View](/connector%20Help/Harris%20Platinum%20Router.aspx#MainView)" & "[Status](/connector%20Help/Harris%20Platinum%20Router.aspx#Status)".

### Main View

On this page, a matrix is displayed containing the crosspoints of the monitored level. The latter is defined by the **Bus Address** field in the element wizard (See "Creation" section). If active, the matrix layout can be used to edit the crosspoints.

Note:

- It is possible that the matrix is empty. In that case, check if the **Layout** parameter on the **Table View** page is set to *Table* or *Matrix & Table*.
- There are two different ways to display the status of the crosspoints. The most intuitive is probably the Matrix layout; however, it is also possible to display the crosspoints in a table layout where the first column contains the output and the second column contains connected input (if any).

### Table View

On this page, the alternative display mode of the crosspoint can be found. In order to see data in this table, make sure the **Layout** parameter is set to *Table* or Matrix & *Table.* If active, the table layout can also be used to set crosspoints.

With the page button **Advanced ...** you can access a pop-up page with a third way to get and set crosspoints. On this page there are two parameters. The first, **Crosspoints**, contains a textual representation of all connected inputs, the second, **Set Crosspoint**, allows the user to set multiple crosspoints at once. This purpose of these parameters is mainly to provide an easy interface for automation scripts. The format to set crosspoints on this page is: \[Output\];\[Input\]. Multiple sets can be combined by using a hyphen ('-') as separator. For example, "1;1-2;5" means: Connect input 1 to output 1 and input 5 to output 2.

### Status

The status page contains important and general data about the device, such as **Device Name**, **IP**, **Product Type**, ...

A very important button is the **Polling .** button: it allows you to define which SNMP parameters should be polled. By default, all polling is disabled, in order to reduce bandwidth and CPU load on the DM server. However, without polling almost no other data is available than the crosspoints.

You can find most of the SNMP parameters on the **Status** page, or by clicking the page buttons on the **Status** page.

Below is a list of all sections which can be activated:

- **General Parameters**
  Includes: **Device Name**, **ID**, **Product Type**, .
- **IP Settings**
- **PSU Settings**
- **Sync Settings**
- **FAN Settings**
- **Hardware Slots**
- **Physical Matrix**
  Can be found on page **Matrix Configuration**
- **Physical Input**
  Can be found on page **Matrix Configuration**
- **Physical Output**
  Can be found on page **Matrix Configuration**

### Monitoring Outputs

It is possible to monitor outputs that are on another level than the one defined in the **Bus Address** parameter of the element wizard. To do so, define the level and output that need to be monitored using the **Monitoring Output Level** and **Monitoring Output ID** parameters, and then click the **Add** button. To remove an output from the list, follow the same procedure, but click the **Remove** button instead.

When you add a specific output, a new record will be added to the **Monitoring Output Table**, which is similar to the **Output Table** on the **Table View** page. The only difference is the addition of a **Monitoring Level** column.
