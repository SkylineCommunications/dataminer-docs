---
uid: Connector_help_Network_Electronics_Router_MRP
---

# Network Electronics Router MRP

The Network Electronics MRP matrix routers can be controlled and monitored using this connector.

## About

Range 2.1.0.x uses serial communication and introduces virtual matrixes. It works with MRP rev3.0, syntax v3. The connector allows you to manage connections of logical routers (i.e. levels) that are partitions of the physical device. Virtual routers allow you to manage connections on multiple levels at the same time.

The Network Electronics MRP matrix routers are polled with SNMP from version 3.0.0.x onwards, and can connect each output with a single input. In addition, they allow the user to monitor fans, voltages, temperatures, etc.

Version 3.0.0.7 and higher:

- The crosspoints are now retrieved and set using MRP communication. This happens on port *4381* and has been implemented to provide higher performance when the matrix is edited. All other values use SNMP.

Version 3.0.0.8 and higher:

- The maximum matrix size has been increased to 264x264.
- For backwards compatibility, the *port.xml* file will be imported after the first startup of the element, and stored as *port_v3.xml* from then onwards.
- Note that there might be compatibility issues for the 1.x.x.x range due to some shifts in parameter IDs. The matrix write parameter currently has parameter ID 1060; labels were moved to 4000 and 5000.
- Please also read the additional configuration section regarding SNMP- and MRP-compatible controllers.

### Version Info

| **Range** | **Description**                                   | **DCF Integration** | **Cassandra Compliant** |
|------------------|---------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                   | No                  | Yes                     |
| 1.0.1.x          | Virtual Matrix                                    | No                  | No                      |
| 2.1.0.x          | Main Matrix, Virtual Matrix, Serial, Smart Serial | No                  | Yes                     |
| 3.0.0.x          | MRP (+SNMP) version                               | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | MRP                         |
| 1.0.1.x          | MRP                         |
| 2.1.0.x          | MRP Rev3.0                  |
| 3.0.0.x          | MRP (+SNMP)                 |

## Installation and configuration

### Creation

<table>
<colgroup>
<col style="width: 50%" />
<col style="width: 50%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Range</strong></td>
<td><strong>Connections</strong></td>
</tr>
<tr class="even">
<td>Range 1.0.0.x</td>
<td>Serial Main Connection
<p>This connector uses a serial connection and requires the following input during element creation:</p>
<p>SERIAL CONNECTION:</p>
<ul>
<li>Interface connection:</li>
<li><ul>
<li><strong>IP address/host</strong>: The polling IP of the device.</li>
<li><strong>IP port</strong>: The IP port of the device, by default <em>4381</em>.</li>
<li><strong>Bus address</strong>: The bus address of the device, by default <em>1</em>.</li>
</ul></li>
</ul></td>
</tr>
<tr class="odd">
<td>Range 1.0.1.x</td>
<td>Serial Main Connection
<p>This connector uses a serial connection and requires the following input during element creation:</p>
<p>SERIAL CONNECTION:</p>
<ul>
<li>Interface connection:</li>
<li><ul>
<li><strong>IP address/host</strong>: The polling IP of the device.</li>
<li><strong>IP port</strong>: The IP port of the device, by default <em>4381</em>.</li>
<li><strong>Bus address</strong>: The bus address of the device, by default <em>1</em>.</li>
</ul></li>
</ul></td>
</tr>
<tr class="even">
<td>Range 2.1.0.x</td>
<td>Serial Main Connection
<p>This connector uses a serial connection and requires the following input during element creation:</p>
<p>SERIAL CONNECTION:</p>
<ul>
<li>Interface connection:
<ul>
<li><strong>IP address/host</strong>: The polling IP of the device.</li>
<li><strong>IP port</strong>: The IP port of the device, by default <em>4381</em>.</li>
<li><strong>Bus address</strong>: The bus address of the device, by default <em>1</em>.</li>
</ul></li>
</ul>
<h4 id="serial-statusmessages-connection">Serial StatusMessages Connection</h4>
<p>This connector uses a smart serial connection to retrieve spontaneous status messages and requires the following input during element creation:</p>
<p>SERIAL CONNECTION:</p>
<ul>
<li>Interface connection:
<ul>
<li><strong>IP address/host</strong>: The polling IP of the device.</li>
<li><strong>IP port</strong>: The IP port of the device, by default <em></em> <em>4381</em>.</li>
<li><strong>Bus address</strong>: The bus address of the device, by default <em>1</em>.</li>
</ul></li>
</ul></td>
</tr>
<tr class="odd">
<td>Range 3.0.0.x</td>
<td>SNMP main connection
<p>This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:</p>
<p>SNMP CONNECTION:</p>
<ul>
<li><strong>IP address/host</strong>: The polling IP of the device, e.g. <em>10.11.12.13.</em></li>
<li><strong>Device address</strong>: Determines the level of the router that will be retrieved.</li>
</ul>
<p>SNMP Settings:</p>
<ul>
<li><strong>Port number</strong>: The port of the connected device, by default <em>161.</em></li>
<li><strong>Get community string</strong>: The community string in order to read from the device. The default value is <em>public</em>.</li>
<li><strong>Set community string</strong>: The community string in order to set to the device. The default value is <em>private.</em></li>
</ul></td>
</tr>
</tbody>
</table>

### Configuration (range 3.0.0.x)

By default, the **Request Matrix Data** parameter is set to *Sublime* (see "Settings" section below). This will prevent any SNMP polling, technically supporting controllers with only MRP. Enabling *Compact* or *Modular* could irreversibly cause the element to go into timeout if SNMP is not supported by the controller.

## Usage (ranges other than 3.0.0.x)

### Main View

This page contains the matrix to configure the **Logical Router**. Each output needs at most one input connection. Each input can be connected to up to the maximum number of outputs. Larger matrices have their inputs and outputs grouped by 16. Clicking a group will open or close it. The **labels** correspond to the retrieved aliases for each of the items (inputs or outputs). **Locks** are effective only on outputs.

### Logical Router Status

This page contains information related to the Logical Router displayed on the Main View page. **Size**, **Format** and **Description** give an overview of the level and are displayed as parameters. **Inputs** and **Outputs** with corresponding **Names**, **Aliases**, **Descriptions**, **Labels**, **Crosspoints** and **Locks** are listed in tables.

### Virtual Router View

This page displays the matrix to configure the **Virtual Router.** A drop-down menu allows you to select a **Virtual Router** from a list. **Size** and **Description** are displayed as parameters. Disconnecting crosspoints of the virtual matrix is not allowed, only switching.

Within a text box, a **Log** is displayed with the last changes to the connections of the virtual router. This box will contain warnings in case connections are out of bounds of the matrix size, in an unknown state or in a cross-level gateway configuration.

A tree control allows you to monitor all the available virtual routers.

### Virtual Routers Status

This page contains information related to all the **Virtual Routers**, **Levels**, **Sources** and **Destinations** with the corresponding **ID**, **Format,** **Description**, **Label**, **Crosspoints** and **Lock** listed in tables.

### Alarms

This page contains a table displaying all the **Alarms** stored on the device with their **State**, **Severity**, **Origin** and **Description**. Alarms are retrieved both through a serial command and via alarm status messages.

### Communication Details

This page contains the boxes to log on with a new **Username** and **Password**. The **logged users** are displayed in a table. **Protocol** **Configuration** information is displayed with parameters containing the **Version** and the **Syntax**.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Usage (range 3.0.0.x)

### Main View

This page contains the matrix to configure the router. Each output needs exactly one input connection. Larger matrices have their inputs and outputs grouped by 16. Clicking the group will open or close it.

### General

On this page, basic device information is displayed:

- **System Name**
- **System Description**
- **System Uptime**
- **System Contact**
- **System Location**

### Modules

This page contains a table displaying the modules of the modular router of Flashlink. The table has the following columns:

- **Number**: The ID of the module within the bus.
- **Type**: E.g. *vd128xp*, *aavmux*, *adcsdi*, *rs422,* etc.
- **Status**: *Ok*, *Fail* or *Removed.*
- **Label**: The appointed name at configuration time.
- **Alarm Status**: The alarm handler for the **ModuleStatus** variable. Read the description for more information.
- **Alarm Trap**: Disables or enables the use of traps when the card fails or when it is removed.
- **Alarm Count**: The number of active alarms, not including the card removal alarm.

### Input Connections

On this page, the **Input Table** combines all the outputs that are connected to each input in a semicolon-separated list.

### Fans

This page contains a table displaying information related to the fans.

- **Index**: The index within the table.
- **Number**: The ID within the module.
- **Nominal**: The nominal value.
- **Value** / **Speed**: The measured value.
- **Upper Limit**: Generates an event if the value exceeds this limit, which could result in a trap, depending on the Alarm Trap setting.
- **Lower Limit**: Generates an event if the value goes below this limit, which could result in a trap, depending on the Alarm Trap setting.
- **Alarm Status**: Indicates if the value is outside the limits.
- **Alarm Trap**: Determines whether traps are sent when an alarm is raised.

### Voltages

The table on this page is similar to the **Fans** table, but displays information on the voltages.

### Temperatures

The table on this page is similar to the **Fans** table, but with an additional **Description** column. This column provides a textual description of the placement or function of a sensor.

### Cable Equalizer

The table on this page is similar to the **Fans** table, but does not contain any measurements or measurement-related alarms. However, the following columns are added:

- **Config**: The current configuration.
- **Status**: The status of the signal detector.

Use the **Refresh Cable EQ Table** button to poll the table once immediately.

### Reclockers

The table on this page is similar to the **Fans** and **EQ** table, with the addition of loop-bandwidth and bitrate values.

Use the **Refresh Reclocker Table** button to poll the table once immediately.

### Cable Driver

This page contains a table showing the **Number**, **Configuration**, and **Slew Rate** of the cable drivers.

Use the **Refresh Cable Driver Table** button to poll the table once immediately.

### Monitor

This page contains three tables, the first of which displays the information and alarm/error status of the signal monitors. The other two summarize the masks for the signal monitors.

### Level

This page displays the different levels present in this router, with their corresponding information.

### Crosspoints

This page contains the **crosspoints** table. This is the table that is stored in the device and converted into the matrix on the **Main View** page. It contains the output and connected input number, as well as the **Locking**, **Locking Level** and **Lock UID** columns. However, currently the matrix locking and the device's locking are not connected.

### Settings

On this page, you can manually set the number of **inputs** and **outputs**.

The following settings are possible for the **Request Matrix Data** parameter:

- *Sublime - Poll Crosspoints*
- *Compact - Poll Crosspoints* and *Labels Only*
- *Modular - Enable Additional Tables and Poll all Others*.

When **Request Matrix** **Data** is set to *Modular*, the following toggle buttons will decide if those tables will be polled as well:

1. **Modular - Poll Cable Equalizers Table**
1. **Modular - Poll Reclockers Table**
1. **Modular - Poll Cable Drivers Table**

The following table provides an overview of which data will be polled under which setting.

| **Settings**        |               |               |                  |           |
|---------------------|---------------|---------------|------------------|-----------|
| Request Matrix Data | ***Sublime*** | ***Compact*** | *Modular*        | *Modular* |
| Modular (1)(2)(3)   | *Any*         | *Any*         | ***Not polled*** | *Polled*  |

| **SNMP Table/Param**                          | **Polling status** |                  |                  |          |
|-----------------------------------------------|--------------------|------------------|------------------|----------|
| Crosspoints                                   | *Polled*           | *Polled*         | *Polled*         | *Polled* |
| Labels                                        | ***Not polled***   | *Polled*         | *Polled*         | *Polled* |
| Modules                                       | ***Not polled***   | ***Not polled*** | *Polled*         | *Polled* |
| Fans, Voltage, Temperature, Monitor, Level    | ***Not polled***   | ***Not polled*** | *Polled*         | *Polled* |
| Cable EQ (1), Reclocker (2), Cable Driver (3) | ***Not polled***   | ***Not polled*** | ***Not polled*** | *Polled* |
| System Info                                   | ***Not polled***   | ***Not polled*** | *Polled*         | *Polled* |

### Matrix Configuration

On this page, you can change the options for the **Matrix**.

### Labels

On this page, you can edit the **input** and **output labels** or synchronize them with the device.

## DataMiner Connectivity Framework

### Interfaces

#### Dynamic interfaces

The matrix (parameter ID 50) will create the following interfaces:

- Matrix inputs will create interfaces of type *in* named *Interface In*.
- Matrix outputs will create interfaces of type *out* named *Interface Out*.

### Connections

#### Internal Connections

- Between **Interface In** and **Interface Out**, connections are made automatically when crosspoints are set.
