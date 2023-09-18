---
uid: Connector_help_Arris_CAP-1000
---

# Arris CAP-1000

The **Arris CAP-1000** connector is a **HTTP** connector that will be used to monitor and configure th **Arris CAP-1000**.

The version (**1.0.0.1**) of the connector supports software version **v4.1** with **XML protocol 4.0**.

## About

The **Arris CAP-1000** is an IP-centric MPEG-2/MPEG-4 digital stream processor capable of high-quality rate shaping, splicing, and multiplexing. It features field-replaceable processing modules, dual hot-swappable power supplies, and fan trays, all in a **single 1-RU chassis**.

There are multiple ways to monitor and configure the settings for the Arris CAP-1000. This connector is based on The **CherryPicker Element Manager**. The CherryPicker Element Manager is a browser-based Java interface that enables you to **remotely configure, control, and monitor each Arris CAP-1000** unit in your network.

### Version Info

| **Range**     | **Description**                               | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-----------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial Version                               | No                  | Yes                     |
| 1.0.1.x \[SLC Main\] | Added displaykey to the Alarms Overview Table | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**         |
|------------------|-------------------------------------|
| 1.0.0.x          | **v4.1** with **XML protocol 4.0**. |
| 1.0.1.x          | **v4.1** with **XML protocol 4.0**. |

## Installation and configuration

### Creation

#### HTTP Main Connection

This connector uses a HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device. (Default: 80)
- **Device address**: The device address. (Default: ByPassProxy)

## Usage

Before all the functions of the element are available, the user needs to **log in**. On the **Device** page, click the "**Security.**" button and fill in the correct **username** and **password**. After that, just press the "**Login**" button and the user will be logged in and the element will start working.

When the element is stopped or restarted later, the username and password will be remembered, so this step only needs to be done once. When the element is started and a username and password is already provided, the user just need to press the **Login**.

### Device

The **Device** page displays some general information of the device (**name**, **version**, **model**.). On this page, it's also possible to **reboot** the device, to **restart the core** or to **restart the controller**. As mentioned before, the "**Security.**" page button is also available on this page.

The "**Device Redundancy Slate**" parameter makes it possible to configure redundancy slate for the entire device. This will put all output muxes and programs in the selected redundancy slate configuration. This is also possible on a mux or program level, but this is available on different pages.

This page also has eight subpages, which you can access through page buttons:

- **Permissions**: Displays the **Users** table, containing a list of users available to login on the device. It's also possible to add new users to the system.
- **SimulCrypt**: Displays the **CA Systems** and **ECM Generators** tables, containing the available CA systems and ECM Generators. It's possible also to add new CA System and ECM Generators.
- **Preferences:** Displays the **PRED** and **DVBSI** tables with information related to Video Tables.
- **Ports:** Displays the **ASI Ports** and **Ethernet Ports** tables. The **ASI Ports** table can be used to configure the ASI port settings for the Arris CAP-1000. The **Ethernet Ports** table is used to view and configure the network configuration.
- **Hardware Profiles:** Displays the **Hardware** table. This table contains an entry for all the hardware components available on the system.
- **Licenses:** Dusplays the **Licenses** table, which has an entry for every license that is used by the system. It's also possible to add a new license to the system.
- **Statistics:** Displays the latest information related with number of active input multiplexers, output multiplexers etc.
- **Security:** In this subpage it's possible to configure the **user name**, **password**, **login** to the system and **logout** as well.

### Recoders

This page displays the **Recoder Cluster Allocation** and **Device Resources** tables. These tables can be used to view, configure and manage recoder used for optimal allocation.

### Interfaces

The **Interfaces** page displays two tables. The first table is the **Interfaces** table, who has an entry for every **input** and **output**. This is just a basic table that displays the interface type and name.

The other table on this page is the **Mux** table. This table contains information for every mux that is connected to an interface specified in the **Interfaces** table. This table also contains a setting for redundancy slate. But here it's the "**Mux Redundancy Slate**", which means the setting will be configured on a mux level. All the programs connected to this mux, will get the same configuration when changed.

As of version 1.0.1.11, the **Create Output Mux** was changed to **Output Mux** and an additional page, **Input Mux**, was created. The **Output Mux** page is for creating new Output Muxes and editing existing ones. The **Input Mux** page is for creating new input Muxes and editing existing ones.

### Multiplexers

The **Multiplexers** page displays the **Multiplexers** and **Tables** tables. The **Multiplexers** table has information related with every multiplexer and also is used for the creation of new multiplexers. As of version 1.0.1.11, it also allows for the editing of the Mux name and the deletion of the mux The **Tables** tables has information related to Video tables and the corresponded ID of PIDs, PMT and PCR.

### Program

The **Program** page contains the **Program** table. This table has an entry for every program and as of version 1.0.1.11, allows for the editing of the program number and name. The "**Program Redundancy Slate**" column can be used to set the slate configuration on a program level. Setting this will only change the setting for the chosen program. Note that these settings can only be done for programs connected to an output interface.

### PID

The **PID** table contains an entry for all the PID's that are connected to a program.

### Grooming

The **Grooming** page contains the **Grooming Definitions**, **Grooming Info** and **Program Intervals** tables. These tables have the information about the grooming available on the system.

There is also two subpages in order to create a new **Unreferenced Table** and also a new **Unreferenced Stream**.

- **Create Unreferenced Table**: information need to create a new Unreferenced Table.
- **Create Unreferenced Stream**: information to create a new Unreferenced Stream.

### Create Groom

The Create Groom page displays the **Inputs** and **Outputs** tables. These two tables are needed in order to create a new Groom. To create a new **Groom** the user needs to select one input and one output on each table.

There is also on this page a **Settings** subpage to change some parameters of the groom.

### Alarm

The **Alarm** page displays all the alarms that are generated by the system. This table is almost exactly the same as the **Alarm** table on The CherryPicker Element Manager.

The **Alarm** table has a customizable **IDX** column (v. 1.0.1.9) that allows for different formats of that column via dropdown. The default format is **Primarykey/Description**.

Alarms can be cleared in 2 different ways. Either the user can chose to clear the alarms one by one. For this option, the user has to use the setting in the "**Cleared**" column (note that event alarms can't be cleared). The other option is to clear all alarms at once. This can be done by using the "**Clear All Alarms**" button, which is situated underneath the **Alarms** table.

The **Alarms Overview** table has the information about the Multiplexers alarms.

### Service Overview

The **Service Overview** page contains a treeview for every interface. This is an easy way to quickly find a certain program or PID. The treeview is constructed as: Interface \> Muxes \> Programs \> PIDs.

For each Program it is also possible to find information about its **Programs,** **Tables** and **Alarms**.

### Grooming Overview

The **Grooming Overview** page contains a treeview for every Grooming. This is an easy way to quickly find a certain program. The treeview is constructed as: Groom \> Programs.

For each Groom it is also possible to find information about its **Grooming Definitions** and **Program Intervals.**

### Web Interface

This page displays the web interface of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

### Number of sessions

There is a limitation to the amount of active sessions for the **Arris CAP-1000**. Only **8 sessions** can be active at a time. Therefore, it's very important to logout of the element ("**Security.**" button) before stopping it. Otherwise the sessions won't be terminated and after a few stops, this could result in an error that can only be solved by restarting the entire device.

When restarting the device by using the buttons on the Device page, it's not necessary to logout because the element will reconnect with the device as soon as it's rebooted. But when restarting the device using another method than the one described above (for example The CherryPicker Element Manager), it's important that you re-login manually (even if the element displays that you are currently logged in).
