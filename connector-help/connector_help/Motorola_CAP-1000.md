---
uid: Connector_help_Motorola_CAP-1000
---

# Motorola CAP-1000

The **Motorola CAP-1000** connector is a **HTTP** connector that will be used to monitor and configure the **Motorola CAP-1000**. This version (**5.0.0.3**) of the connector supports software version **v4.0** with **XML protocol 3.0**.

## About

The **Motorola CAP-1000** is an IP-centric MPEG-2/MPEG-4 digital stream processor capable of high-quality rate shaping, splicing, and multiplexing. It features field-replaceable processing modules, dual hot-swappable power supplies, and fan trays, all in a **single 1-RU chassis**.

There are multiple ways to monitor and configure the settings for the Motorola CAP-1000. This connector is based on The **CherryPicker Element Manager**. The CherryPicker Element Manager is a browser-based interface that enables you to **remotely configure, control, and monitor each CAP-1000** unit in your network.

## Configuration

## Connections

This connector uses a HTTP connection and requires the following input during element creation:

**SERIAL CONNECTION (Until version 3.0.0.1)**:

- **IP address/host**: the polling IP or URL of the destination eg *10.11.12.13*
- **IP port**: the port of the destination eg *80*
- **Bus address**: this field can be used to bypass the proxy. To do so fill in the value *ByPassProxy (default)*..

**HTTP CONNECTION (Starting on version 4.0.0.1)**:

- **IP address/host**: the polling IP or URL of the destination eg *10.11.12.13*
- **IP port**: the port of the destination eg *80*
- **Bus address**: this field can be used to bypass the proxy. To do so fill in the value *ByPassProxy (default)*..

## Usage

Before all the functions of the element are available, the user needs to **log in**. On the **Device** page, click the "**Security.**" button and fill in the correct **username** and **pass word**. After that, just hit the "**Login**" button and the user will be logged in and the element will start working.

When the element is stopped or restarted later, the username and password will be remembered, so this step only needs to be done once. When the element is started and a username and password is already provided, the element will log in automatically.

### Device

The **Device** page displays some general information of the device (**name**, **version**, **model**.). Via this page, it is also possible to **reboot** the device, to **restart the core** or to **restart the controller**. As mentioned before, the "**Security**" page button is also situated on this page.

The "**Device Redundancy Slate**" parameter makes it possible to configure redundancy slate for the entire device. This will put all output muxes and programs in the selected redundancy slate configuration. This is also possible on a mux or program level, but this is situated on different pages.

### Ports

The **Ports** page displays 2 tables. The first one is **ASI Port table**, which can be used to configure the ASI port settings for the Motorola CAP-1000. The other table that is also displayed on this page is the **Ethernet Port table**, which is used to view and configure the network configuration.

### Hardware

The **Hardware** page displays a similar table as the one on the Setup \> Hardware page of The CherryPicker Element Manager. This table contains an entry for all the hardware components available on the system.

### License

The **License** page contains the License table which has an entry for every license that is used by the system.

### Enable Polling

The **Enable Polling** page added on **version 5.0.0.1** contains a **Parsing Response Status** that indicates if the parsing of the response went ok, as well as two toggle buttons that allow to enable and disable the polling of the **Program** and **PID** tables.

### Security

The **Security** page contains the **Username** and **Password** fields that need to be filled in order to authenticate the connection to the device.

### Recoders

This page displays the same tables as the Setup \> **Recoders** page in The CherryPicker Element Manager. These tables can be used to view, configure and manage recoder use for optimal allocation.

### Interfaces

The **Interfaces** page also displays 2 tables. The first table is the **Interface Table**, who has an entry for every **input** and **output**. This is just a basic table that displays the interface type and name.

The other table on this page is **the Mux table**. This table contains information for every mux that is connected to an interface specified in the Interface table. This table also contains a setting for redundancy slate. But here it is the "**Mux Redundancy Slate**", which means the setting will be configured on a mux level. All the programs connected to this mux, will get the same configuration when changed.

### Program

The **Program** page contains the **Program table**. This table has an entry for every program. The "**Program Redundancy Slate**" column can be used to set the slate configuration on a program level. Setting this will only change the setting for the chosen program. Note that these settings can only be done for programs connected to an output interface.

### PID

The **PID** table contains an entry for all the PIDs that are connected to a program.

### Grooming

The **Grooming** page added on **version 4.0.0.4** displays the relation between the **Input** and **Output** in terms of **Line ID, Mux ID and Program ID** through the **Grooming Definitions** table.

### Create Groom

The **Create Groom** page added on **version 4.0.0.4** displays the information regarding the identifiers of the **Input** and the **Output** programs.

### Alarm

The **Alarm** page displays all the alarms that are generated by the system. This table is almost exactly the same as the Alarm table on The CherryPicker Element Manager.

Alarms can be cleared in 2 different ways. Either the user can chose to clear the alarms one by one. For this option, the user has to use the setting in the "**Cleared**" column (note that event alarms can't be cleared). The other option is to clear all alarms at once. This can be done by using the "**Clear All Alarms**" button, which is situated underneath the Alarms table.

### TreeView

The **TreeView** page contains a treeview for every interface. This is an easy way to quickly find a certain program or PID. The treeview is constructed as: Interface \> Muxes \> Programs \> PIDs.

### Web Interface

This is the last page of the element and is just a link that will take the user to the **webinterface** for the Motorola CAP-1000.

## Notes

### Number of sessions

There is a limitation to the amount of active sessions for the **Motorola CAP-1000**. Only **8 sessions** can be active at a time. Therefore, it is very important to logout of the element ("**Security.**" button) before stopping it. Otherwise the sessions won't be terminated and after a few stops, this could result in an error that can only be solved by restarting the entire device.

When restarting the device by using the buttons on the Device page, it is not necessary to logout because the element will reconnect with the device as soon as it is rebooted. But when restarting the device using another method than the one described above (for example The CherryPicker Element Manager), it is important that you re-login manually (even if the element displays that you are currently logged in).
