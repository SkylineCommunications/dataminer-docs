---
uid: Connector_help_T-Vips_CP541
---

# T-Vips CP541

The **T-Vips CP541** connector uses an SNMP connection to communicate with the **CP541** **Monitoring** **Switch**. This connector can not only be used to monitor the **CP541**, but also to update part of its configuration.

Note that the T-Vips CP541 device is also known as **Nevion TNS541**. This is the alternative name for the device after the acquisition of T-Vips by Nevion. As such, this connector can also be used for the Nevion TNS541.

## About

The **CP541** is part of the T-VIPS cProcessor product family, a line of products designed for processing and handling MPEG transport streams. This connector is consequently very similar to other connectors for the T-VIPS cProcessor product family, such as the **CP540** or **CP546** connectors.

The connector uses SNMP to poll information from the device, but it also handles alarm traps. The **CP541 connector** can also be used to configure the relay controller(s).

### Version Info

| **Range** | **Description**                                                           | **DCF Integration** | **Cassandra Compliant** |
|------------------|---------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                                           | No                  | No                      |
| 2.0.0.x          | Branch version based on 1.0.0.x using serial communication                | No                  | No                      |
| 3.0.0.x          | Branch version based on 1.0.0.x                                           | Yes                 | No                      |
| 3.1.0.x          | Version based on 3.0.0.x and adapted to alarm changes in FW version 2.2.2 | Yes                 | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 2.0.0.x          | Unknown                     |
| 3.0.0.x          | 1.12.60, 2.0.2              |
| 3.1.0.x          | 2.2.2 and higher            |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

#### Serial connection (in version 2.0.0.x only)

Version 2.0.0.x of this connector uses a serial connection, which requires the following input during element creation:

SERIAL CONNECTION:

- **Interface connection**:

- **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device, by default *80*.

## Usage

### General

This page contains all the general information about the device, such as the **System Name**, **System Up Time**, etc. Some of these parameters can be changed. The general page also displays the **General Alarm Status**, which has the same severity level as the most severe alarm that is currently in the system.

The **Number of Switch Controllers** parameter displays the number of managed switch controllers. This can either be *1* or *2*. If there is only 1 switch controller, the **Current Relay Position** parameter can be used to change the relay position. If there are 2 switch controllers, this parameter can only be used to change the first one. If you want to change the position for both or for the second one, you will need to do so in the **Switch Table** (on the **Switch Control page**).

### Switch Control

This page contains the **Switch Table**. This is the main configuration table for the relay controllers.

### Inputs

This page contains 3 tables: **Service Status**, **Ts Service Components Table** and **Ts Status Table**. The **Service Status** table has an entry for all services detected for a particular transport stream. The **Ts Service Components Table** is more detailed and contains information about components for a particular service. The **Ts Status Table** is the main transport stream status table and contains top-level information for an MPEG-2 transport stream.

### Outputs

This page displays the output parameters for the currently assigned outputs of the switch controller. If there is only 1 switch controller, only the Output 1 parameters will be filled in.

There are 4 page buttons for each output:

- **Output x PIDs**: Displays a table with the PIDs for this output.
- **Output x Services**: Displays a table with the services for this output.
- **Output x Alarms**: Displays the most important alarms for this output.
- **More Output x Alarms**: Displays all other alarms for this output.

### PIDs

This page displays 2 tables: the **PID Status** and the **PCR Status** table. The **PID Status** table displays the status for PIDs detected for a particular transport stream. If there are rows in this table of which the PID value (PID column) is empty, these can be removed with the option **Rem PID Empty Entries**.

The **PCR** **Status** table contains PCR status information about a particular transport stream.

### Alarms

This page displays information about all the alarms in the system. There are 2 tables on this page:

- The **Alarms** table is a custom table, which means its information is not directly polled from the system. It contains an entry for every possible alarm (for every input) in the system. This table can be updated in 2 ways, either via traps or via the **Current Alarms** table.
- The **Current Alarms** table is an SNMP table that displays all current alarms in the system. This table is polled every minute and will update the Alarms table when there is a change.

### Overview

This page is the **default page** of the CP541 connector. This means that when the element is opened, by default, this will be the first page it displays. The page contains a tree view with the inputs in the system.

### Configurations

This page can be used to apply a backup configuration file to the device.

### Web interface

This page can be used to access the web interface of the **T-Vips CP541**. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Usage (3.0.0.14)

### General

This page contains all the general information about the device, such as the **System Name**, **System Up Time**, etc. Some of these parameters can be changed. The general page also displays the **General Alarm Status**, which has the same severity level as the most severe alarm that is currently in the system.

The **Number of Switch Controllers** parameter displays the number of managed switch controllers. This can either be *1* or *2*. If there is only 1 switch controller, the **Current Relay Position** parameter can be used to change the relay position. If there are 2 switch controllers, this parameter can only be used to change the first one. If you want to change the position for both or for the second one, you will need to do so in the **Switch Table** (on the **Switch Control page**).

### Switch Control

This page contains the **Switch Table**. This is the main configuration table for the relay controllers.

### Overview

This page is the **default page** of the CP541 connector. This means that when the element is opened, by default, this will be the first page it displays. The page contains a tree view with the inputs in the system.

### Inputs

This page contains 3 tables: **Ts Status Table**, **Service Status**, and **Ts Service Components Table**. The **Ts Status Table** is the main transport stream status table and contains top-level information for an MPEG-2 transport stream. The **Service Status** table has an entry for all services detected for a particular transport stream. The **Ts Service Components Table** is more detailed and contains information about components for a particular service.

There is also a page button to access the transport PIDs. The **PID Status** table displays the status table for PIDs detected for a particular transport stream. If there are rows in this table of which the PID value (PID column) is empty, these can be removed with the option **Rem PID Empty Entries**.

### Outputs

This page displays the output parameters for the currently assigned outputs of the switch controller. If there is only 1 switch controller, only the Output 1 parameters will be filled in.

There are 4 page buttons for each output:

- **Output x PIDs**: Displays a table with the PIDs for this output.
- **Output x Services**: Displays a table with the services for this output.
- **Output x Alarms**: Displays the most important alarms for this output.
- **More Output x Alarms**: Displays all other alarms for this output.

### Alarms

This page provides a general overview of all the alarms in the system. There are 2 tables on this page:

- The **Current Alarms** table is an SNMP table that displays all current alarms in the system. This table is polled every minute and will update the Alarms table when there is a change.
- The **Alarms** table is a custom table, which means its information is not directly polled from the system. It contains an entry for every possible alarm (for every input) in the system. This table can be updated in 2 ways, either via traps or via the **Current Alarms** table.

### Detailed Alarms

This page displays the **Detailed Alarms** table, which contains a detailed overview of all the alarms in the system. (For example, this table will show a unique alarm for every PID under a port, while the Current Alarms table will only show a single alarm for the port as a whole.)

This table is updated via traps and is also polled every minute to correct the table in case a trap has been missed (for example, because of loss of connection).

### Configurations

This page can be used to apply a backup configuration file to the device.

### Web interface

This page can be used to access the web interface of the **T-Vips CP541**. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DCF Implementation

### Input A

If the **Current Input** parameter, in the **Switch Table** on the **Switch Control** page, is set to **Input A**, the following connections will be made, according to the **Relay Controller** (1 or 2) chosen:

- From the **ASI 1 Input A** in interface to the following out interface: **ASI 1 Out 2**, **ASI 1 Out 3** and **ASI 1 Out Main**.
- From the **ASI 2 Input A** in interface to the following out interface: **ASI 2 Out 2**, **ASI 2 Out 3** and **ASI 2 Out Main**.

### Input B

If the **Current Input** parameter, in the **Switch Table** on the **Switch Control** page, is set to **Input B**, the following connections will be made, according to the **Relay Controller** (1 or 2) chosen:

- From the **ASI 1 Input B** in interface to the following out interface: **ASI 1 Out 2**, **ASI 1 Out 3** and **ASI 1 Out Main**.
- From the **ASI 2 Input B** in interface to the following out interface: **ASI 2 Out 2**, **ASI 2 Out 3** and **ASI 2 Out Main**.
