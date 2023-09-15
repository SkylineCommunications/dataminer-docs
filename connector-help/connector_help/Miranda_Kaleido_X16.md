---
uid: Connector_help_Miranda_Kaleido_X16
---

# Miranda Kaleido X16

The Kaleido X16 connector is used to display information related to the **Kaleido X16** device. The connector is also used to retrieve and set specific characteristics of the device using RCP (Gateway) commands.

The connector uses two protocols to communicate with the Kaleido device: the SNMP protocol is used to retrieve information concerning the device and the TCP protocol is used to execute RCP commands.

## About

This connector has five pages: the **General** page contains general information related to this device, the **Card List** page contains information about the slots connected to the frame, the **Video** page contains information about the frame's video inputs, the **Embedded Audio** page contains information about the frame's video-embedded audio, and finally the **Discrete Audio** page contains information about discrete audio of the device.

## Configuration and Installation

### Creation

SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.145.1.12*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
  **Set community string**: The community string used when setting values on the device. The default value is *public*.

#### Serial connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **Type of port:** TCP/IP.
- **IP address/host**: The same IP as is used for the SNMP communication, e.g. *10.145.1.12*.
- **IP port**: The IP port of the device, e.g. *13000*.
- **Timeout of a single command**: At least *2500* ms.

## Usage

### General Page

This page contains general information about the device such as the frame model, layouts defined in the Kaleido X16 device, software version, number of inputs, slot count, card count and frame, fan and power supply status.

In a drop-down list, the parameter **Layout List** displays all the layouts defined in the Kaleido X16 device. Each layout displayed in the list has the following format: *RoomName/LayoutName.kg2*. When a layout is selected, an RCP command is sent by the connector to set the selected layout in the Kaleido X16 device.

The button **Set Channel** can be used to set the channel of the Kaleido X16 device according to the values set in **Channel Name** and **Monitor Name**. The parameter Channel Name will contain a drop-down list with all the available channels obtained from the Video table. Note that the RCP command will not be sent to the device unless both parameters (Channel Name and Monitor Name) are filled in.

### Card List Page

This page displays one table that contains an entry for every slot in the frame.

### Video Page

This page displays one table with the frame's video inputs. This table contains an extra column **UMD Channel Text**, which is used to retrieve and set the UMD channel text for each channel on the Kaleido X16 device using RCP commands. The **Set all UMDs** button at the top of the page can be used to set all UMD channel text according to the values defined in this column.

### Embedded Audio Page

This page displays the **Embedded Audio Table**. This table contains all the frame's video-embedded audio.

In version **1.0.0.7** of the connector, the **Config EA Table** page button was added to this page along with two **Embedded Audio Table** parameters (**EA Service Channel** and **DisplayKey (Embedded Audio) \[IDX\])**.

#### Config EA Table

This page allows you to configure the display key of the Embedded Audio Table using the parameter **EA DisplayKey**. This parameter was implemented to avoid major version changes and to facilitate a workaround procedure that allows you to change the display key without affecting the existing trend/alarm template.

The parameter **EA DisplayKey** consists of two discreet options, namely **EA Input Index \[IDX\]** and **EA Service Channel/EA Instance**. The first option is the display key used up to version **1.0.0.6** for Embedded Audio Table and the second option is the display key included from version **1.0.0.7** onwards. The naming option is implemented in a similar way as for the **Discrete Audio Table**.

#### EA Service Channel

This is a custom read/write column, similar to that in the DA Service Channel. The value in this column, combined with the column **EA Instance**, makes up the second discreet option in the **EA DisplayKey**.

#### DisplayKey (Embedded Audio) \[IDX\]

This is a hidden retrieved column. The value in this column changes based on the option selected in the parameter **EA DisplayKey**.

Note that the \[IDX\] was added to this column in spite of a pre-existing \[IDX\] from version **1.0.0.6** for parameter **EA Input Index \[IDX\]**. It was not removed to ensure that this connector version does not affect alarming/trending.

### Discrete Audio Page

This page displays the **Discrete Audio Table**. This table contains all discrete audio available on the Kaleido X16 device.

### Traps

This page displays the **Traps** table, which displays all the received traps. The auto clear information can be configured at the top of the page.

### Trap Target

This page displays the **Traps Target** table, which displays the port and ip address of all received traps.

### GPI

This page displays the **GPI** table, which contains all frame's GPIs and their information. The information includes the ID reference, number, logical name, direction (in or out), status (open or closed), and if it is enabled.

### Router

This page displays the **Router** table, which contains router information. This includes router output number and crosspoint label and status.

### Virtual Alarms

This page displays the **Virtual Alarms** table. It displays a virtual alarm's friendly name, alarm status, trap status, and causes of this virtual alarm. The trap status indicates whether or not a trap will be generated upon current virtual alarm status change.

### LTC

This page contains a table with all frame's **LTCs.** Here you will find the LTC hard slot ID, number, logical name, status, and trap status.

### HDM

This page contains the **HDM** table. The HDM information included is an HDM's slot ID, logical name, presence, and status. The presence can have the values: disabled, normal, warning, error, and unknown.
