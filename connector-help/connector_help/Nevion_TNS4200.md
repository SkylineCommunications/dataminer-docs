---
uid: Connector_help_Nevion_TNS4200
---

# Nevion TNS4200

The **Nevion TNS4200** is a monitoring probe for continuous monitoring of broadcast streams and signals.

## About

This connector is used to manage the Nevion TNS4200 device using the **HTTP** protocol.

### Version Info

| **Range** | **Description**                                                                                                                                                                  | **DCF Integration** | **Cassandra Compliant** |
|------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version. (Only supports ASCII labels.)                                                                                                                                   | No                  | No                      |
| 1.0.1.x          | Added SNMP connection for trap receipt. (Only supports ASCII labels.)                                                                                                            | No                  | No                      |
| 1.1.0.x          | Updated alarm implementation to firmware 1.6.16/1.7.0. Removed relative alarming in protocol. Added filter column in Transport Streams table. (Only supports ASCII labels.)      | No                  | No                      |
| 1.1.1.x          | Range with adjustable DisplayKeys. Obsolete option "DisplayColumn" replaced with "Naming" in Alarms table. (Note: not all "DisplayColumn" options were removed from the connector.) | No                  | No                      |
| 2.0.0.x          | Continues support for 1.1.0.x range                                                                                                                                              | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.0.1.x          | Unknown                     |
| 1.1.0.x          | 1.6.16/1.7.0                |
| 2.0.0.x          | 2.0.30                      |

## Installation and configuration

### Creation

#### HTTP connection

This connector uses an HTTP connection and requires the following input during element creation:

**HTTP Connection:**

- **IP address**: The polling IP or URL of the destination.
- **IP Port**: The IP port of the destination, by default *80*.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy*.

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection to receive traps and requires the following input during element creation:

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *public*.

## Usage

### General (from version 2.0.0.2 onwards)

This page contains general info about the device.

### Inputs Page

This page contains an overview of the inputs (ASI, SS2, Ethernet, TSoIP, TT2 and CC2).

### Transport Streams Page

This page contains an overview of all transport streams in the **Transport Streams** table. This table contains parameters related to the transport stream, such as **Status**, **Mode**, **Total Rate**, **Effective Rate**, **TS ID**, and **ON ID**.

In addition, the table contains a number of columns indicating whether a specific alarm is present for a particular transport stream (e.g. **Sync Byte Error**, **PAT Repetition Interval**, etc.).

### Services Page

This page provides an overview of all services in the **Services** table. This table contains service-specific information for each service, such as **Provider**, **Type**, **EIT Schedule Signaled**, **Scrambling Signaled**, **PMT PID**, **PCR PID**, and **Total Rate**.

In addition, the table contains a number of columns indicating whether a specific alarm is present for a particular service (e.g. **PMT Missing**, **Too Many PIDs**, etc.).

### SCTE35 Page (from version 1.0.1.10)

This page provides an overview of all components available for each service in the **Components List Table**. This table displays the **Stream Type** and indicates whether it is encrypted or not**.**

The page also contains the **Cue Message Log Table**, which shows the list of log messages for each service. For each entry in this table, information is available regarding **Status**, **Command Time**, the **Slice Command** that was requested, the **Event type** and **Time** and also the **Command Status**.

Finally, there is also the **Events Counts Table**, which shows the current events that have been logged in the **Cue Message Log Table** for the previous X hours (as defined with the parameter **Time Interval Number of Events for Service**).

### Switches (from version 2.0.0.2)

This page contains the **Switches** table and **Switch Inputs** table, with information from the inputs configured on the switches and their **Status** (**Active**/**Inactive**). It also displays specific input information.

### Seamless Switches (from version 2.0.0.2)

This page contains the **Seamless Switches** table and **Seamless Switch Inputs** table, with information from the inputs configured on the seamless switches and their **Status** (**Active**/**Inactive**). It also displays specific input information.

### ASI Outputs

This page contains an **ASI Outputs** table with information about the **Source**, **Transmission format** and **Packet length**.

### TS-IP Outputs

This page contains a **TS-IP** **Outputs** table with information about the **Source**, **Destination** and other **TS**-specific parameters. It also displays the **TS-IP** **Output Destinations** with the **Destination IP** and respective interfaces configured on each TS-IP Output.

### PIDS Page

This page contains information related to the PIDs. Two tables are displayed: the **PIDs** table and the **PCR PIDs** table.

The PIDs table displays an overview of all PIDs, showing among others which service each PID is part of (**Ref. by service**), and the **Type**, **Rate**, **Continuity Error Counter**, etc.

In addition, the table contains a number of columns indicating whether a specific alarm is present for a particular PID (e.g. **Unreferenced PID**, **PID Rate** **Too High**, etc.).

The PCR PIDs table contains information about the PCR PIDs, such as **Clock**, **Local Clock**, **Max Jitter**, etc.

### Alarms Page

This page displays an overview of the alarms that are currently active (and implemented by the connector).

Via the **Filtered Alarms** page button, you can get an overview of the alarms that are currently present but filtered in the **Filtered Alarms Table**. To process traps for filtered alarms, set the toggle button **Process Traps for Filtered Alarms** to *Yes*.

via the **Auto Clear** page button, you can set configuration parameters for the automatic clearing of alarms in the **Alarms Table** and the **Filtered Alarms Table**. When **Max Duration Status** is set to *Enabled*, alarms that are older than the number of days specified in the **Notification Max Duration** parameter are automatically removed from the table.

Note that many alarms are related to a specific transport stream, service or PID. For many alarms, an additional column has therefore been defined in the corresponding **Transport Streams**, **Services** or **PIDs** table. For example, for the alarm with ID 1101 ("TS unstable"), a column **TS Unstable** is defined in the **Transport Streams** table that indicates if this alarm is present for a particular transport stream.

### Overview Page

This page displays a tree view that shows the relation between the inputs, transport streams, services and PIDs.

### Connect Page

On this page, you can enter the username and password used for basic authentication.

The **Login Status** displays if the HTTP call succeeded or if there was an authentication error during the request.

It is advisable to verify whether the TXP settings on the web interface of the device have been enabled. Note that when no credentials are filled in in the connector, auto login has to be enabled on the device.

### Web Interface Page

This page allows the user to access the original web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
