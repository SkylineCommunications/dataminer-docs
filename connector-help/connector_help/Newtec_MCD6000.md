---
uid: Connector_help_Newtec_MCD6000
---

# Newtec MCD6000

The **Newtec MCD6000** is multi-carrier demodulator.

## About

This connector allows the management of the Newtec MCD6000 device using the **SNMP** protocol.

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

This page contains general information about the device, such as **Product Name, Device Name, Serial Number, Temperature**, etc.

### Data Interface Page

This page contains the **IGMP Version, Ethernet Link Data Table, Data Network Gateway**, **Data Interface Table,** and **Link Redundancy** parameters.

### Demodulator Page

This page contains the **Demodulator Configuration Table, Demodulator Monitoring Table** and the **Demodulator Alarm State Table**.

### Redundancy Page

This page contains the **Redundancy**, **Redundancy Operational State** and the **Redundancy Initial State** parameters.

### Device Setup Page

This page contains parameters related to configuring **SNMP**, **Logging**, **GUI**, **CLI**, **FTP**, In addition, a number of page buttons are present, allowing to consult more information related to

- Date and Time: Contains the **Device Date** and **Device Time**, **NTP** status and **NTP Peer Table**
- Mgmt Interface: Contains the **Ethernet Link Management Table**, **Management Gateway**, **IP Management Interface Table** and link redundancy parameters (**Redundancy Management Switch Order**, **Redundancy Management Switch Count** and **Redundancy Management Active Interface**)
- Conrol Plane: Contains control plane parameters such as **Terminal ID**, **Control Plane**, and Encapsulation Configuration parameters such as **Nominal S2 ModCod**, **Frame Type**, **ISI**, **CIR**, **PIR** and **Rate Priority**.
- Monitor: Gives an overview of monitored parameters such as **Temperature, Power Supply, CPU Load, Memory Usage, Device Uptime** and the **Device Sensors Table**.
- Frontpanel: Contains the **Frontpanel** and **Device Frontpanel Access Level** parameters.
- Identification: Gives an overview of parameters related to identification of the device, such as **Label, Serial Number, Unique Id, Product Id, Device Description, Device Type, Hardware Revision, Software Id, Device Software Version** and the **Device Options Table**.

### Alarms Page

This page contains an overview of the **Alarm** parameters. The page contains general alarms (**General Device Failure**, **Boot Configuration Failure**, etc.).

In addition to the general alarms, more specific alarms are listed related to

- reference clock (**Reference Clock no Signal**, **Reference Clock no Lock**)
- power supply (**Power Supply A Failure**, **Power Supply B Failure**)
- fan controller (**Fan Failure**)
- control plane (**Control Plane Alarm no Master**)
- Ethernet (**Eth Mgmt1 Link Failure, Eth Mgmt1 Half Duplex, Eth Mgmt2 Link Failure, Eth Mgmt2 Half Duplex, Eth Data1 Link Failure, Eth Data1 Half Duplex, Eth Data2 Link Failure, Eth Data2 Half Duplex, Eth Mgmt Fp Link Failure, Eth Mgmt Fp Half Duplex, Eth Mgmt Interface Failure, Eth Data Interface Failure, Eth Sat1 Link Failure, Et Sat1 Half Duplex, Eth Sat2 Link Failure, Eth Sat2 Half Duplex, Eth Sat Interface Failure**).
- demodulator (**Demodulator General, Demodulator Internal Error, Demodulator Input Saturated, Demodulator no Lock, Demodulator LNB Power Control, Demodulator Decoder Overload, Demodulator no Physical Layer Lock, Demodulator Buffer Overflow**)

### Ethernet Statistics Page

This page contains the **Ethernet Statistics Management Table**, **Ethernet Statistics Data Interface Table.**

### Demodulator Statistics Page

This page contains the **Demodulator Statistics Table**.

### Configuration Page

This page contains an overview of the **Configuration** parameters used for saving and loading configuration to and from the device. The **Active Configuration** and the **Boot Configuration** parameters are displayed. Unsaved Changes indicates if there are unsaved changes to the configuration.
