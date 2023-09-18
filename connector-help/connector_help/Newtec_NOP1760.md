---
uid: Connector_help_Newtec_NOP1760
---

# Newtec NOP1760

The **Newtec NOP1760** is a traffic shaper.

## About

This connector allows the management of the Newtec NOP1760 device using the **SNMP** protocol.

## Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *public*.

## Usage

### General Page

This page contains general information about the device in the Identification panel showing parameters such a Label, Serial Number, Unique Id, Product Id, etc. In addition, a number of monitored parameters are shown on the Monitored Parameters panel (Temperature, CPU Load, Memory Usage, Device Uptime).

### Data Interface Page

This page contains the **IGMP Version, Ethernet Link Data Table, Data Network Gateway**, **Data Interface Table,** and **Link Redundancy** parameters.

### Encapsulation Page

This page contains information related to the encapsulation using 5 page buttons. The General encapsulation page contains parameters related to the default encapsulation protocol (**Default Forwarding Mode**, **Default BBF Encapsulation Protocol**, **Default TS Encapsulation Protocol**), output settings (**BBF Type**, **BBF Destination IP Address**, **BBF Destination UDP Port**), carrier settings (**Modulation Standard**, **Symbol Rate**, **Pilots**) and link optimization settings (**Transponder Mode** and **Equalink**).

The BBF Encapsulation page contains the **BBF Encapsulation ISIs Table** and the **BBF Encapsulation Channels Table**.

The TS Encapsulation page contains the **TS Encapsulation ISIs Table**, the **TS Encapsulation PIDs Table** and the **TS Encapsulation Channels Table**.

The Traffic Shaping page displays the **Traffic Shaping Table** and the **Traffic Classification Table**.

The Encapsulation Monitor page contains monitoring parameters such a **Forwarded Bit Rate**, **Forwarded Bytes**. It also displays the **Monitor Traffic Shaping Table** and the **Encapsulation Channels Monitoring Table**.

### Decapsulation Page

This page displays the **Default BBF Decapsulation Protocol** and the **Default TS Decapsulation Protocol**. In addition, four page buttons are present each grouping information related to the decapsulation.

The general page button groups displays the **Decapsulation BBF Input Enpoint Table** and the **GSE Decapsulation**, **Default Forwarding Mode** and **Enable ISI Filtering** parameters.

The BBF Decapsulation page contains the **BBF Decapsulation ISIs Table** and the **BBF Decapsulation Channels Table**.

The TS Encapsulation page contains the **TS Decapsulation ISIs Table**, the **TS Decapsulation PIDs Table** and the **TS Decapsulation Channels Table**.

The Decapsulation Monitor page contains monitoring parameters such a **Output Bit Rate**, **GSE Forwarded Bytes**, **GSE Forwarded Packets**, etc. It also displays the **BBF Monitoring Table**.

### Remote Terminals

This page contains the **Terminals Cfg State Table** and the **Terminals Monitoring State Table**.

### ACM Controller

This page displays parameters related to the ACM controller such as **ACM Controller Enable**, **ACM Controller Mode**, **ModCod Selection Algorithm**, **ModCod Tuning**, **Minimum Margin** and **Target Margin**.

### AUPC Controller

This page displays parameters related to the AUPC controller such as **AUPC Controller Enable**, **ACM Controller Mode**, **ModCod Selection Algorithm**, **ModCod Tuning**, **Minimum Margin** and **Target Margin**. The Monitoring page button allows to display some monitoring parameters related to the AUPC Controller, such as **Forward Configuration Counter**, **Client Feedback Count**, **Power Request Count**, **Requested Output Power** and **Current Output Power**.

### Redundancy

This page contains the **Redundancy**, **Redundancy Initial State** and the **Redundancy Operational State** parameters.

### Device Setup

This page contains information related to the device, such as the **SNMP Notifications Destination Table**, **Device Reset**, **GUI**, **Remote CLI** and **FTP**. In addition, five page buttons are present allowing to display more information related to

- Alarm Handling: Contains the **Alarm Configuration Table**.
- Date and Time: Allows setting the **Device Date** and **Device Time**. This also contains the **NTP Peer Table**.
- Conrol Plane: Contains control plane parameters such as **Terminal ID**, **Control Plane**, and Encapsulation Configuration parameters such as **Nominal S2 ModCod**, **Frame Type**, **ISI**, **CIR**, **PIR** and **Rate Priority**.
- Mgmt Interface: Displays the **Ethernet Link Management Table** and the **IP Management Interface Table**. In addition, parameters related to Link Redundancy are displayed (**Mgmt Switch Order**, **Mgmt Switch Count** and **Mgmt Active Interface**).
- Logging: Displays parameters related to logging, such as **Local Logging**, **Remote Logging**, **Remote IP Address** and **Remote UDP Port**. It also contains the **Log Filter Table**.

### Alarms Page

This page contains an overview of the **Alarm** parameters. The page contains general alarms (**General Device Failure**, **Boot Configuration Failure**, etc.).

In addition to the general alarms, more specific alarms are listed related to

- control plane (**Control Plane Alarm no Master**)
- IP: **Gateway Unreachable Alarm**
- Ethernet (**Eth Mgmt1 Link Failure, Eth Mgmt1 Half Duplex, Eth Mgmt2 Link Failure, Eth Mgmt2 Half Duplex, Eth Data1 Link Failure, Eth Data1 Half Duplex, Eth Data2 Link Failure, Eth Data2 Half Duplex, Eth Mgmt Fp Link Failure, Eth Mgmt Fp Half Duplex, Eth Mgmt Interface Failure, Eth Data Interface Failure, Eth Sat1 Link Failure, Et Sat1 Half Duplex, Eth Sat2 Link Failure, Eth Sat2 Half Duplex, Eth Sat Interface Failure**).

### Statistics Page

This page contains the **Ethernet Statistics Management Interface Table** and the **Ethernet Statistics Data Interface Table**.

### Configuration Page

This page contains an overview of the **Configuration** parameters used for saving and loading configuration to and from the device. The **Active Configuration** and the **Boot Configuration** parameters are displayed. Unsaved Changes indicates if there are unsaved changes to the configuration.
