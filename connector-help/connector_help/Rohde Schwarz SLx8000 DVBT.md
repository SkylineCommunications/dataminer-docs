---
uid: Connector_help_Rohde_Schwarz_SLx8000_DVBT
---

# Rohde Schwarz SLx8000 DVBT

The UHF/VHF low-power transmitters of the R&SrSLx8000 family are available for ATV, DTV and DAB/T-DMB. They are reliable, compact and flexible and fill coverage gaps in transmitter networks. The transmitters can handle both analog and digital TV standards (DVB-T, DVB-T2, DVB-H, ISDB-T/ISDB-TB and ATSC including ATSC Mobile DTV). Output power ranges up to 100 W for DVB-T, DVB-T2, DVB-H and ISDB-T/ ISDB-TB up to 150 W for ATSC and up to 250 W for analog TV. If necessary, an analog transmitter can easily be switched over to digital TV without modifying the hardware. For digital audio broadcasting, the transmitter family supports transmission in line with the DAB, DAB+ and T-DMB specifications with output power of up to 300 W.

## About

This SNMP connector is used to monitor the transmitter parameters with trap functionality.

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact**          |
|-----------|------------------|--------------|----------------------------|
| 1.0.0.x   | Initial version  | \-           | There is no system impact. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 4.4.25                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device Default value if not overridden in the connector is *public.*
- **Set community string**: The community string used when setting values on the device. Default value if not overridden in the connector: *private.*

### Web Interface

Web interface can be accessed using the same IP as the SNMP address. It is only accessible when the client machine has network access to the device.

## Usage

### General

On the **General** page of this connector, you can find the system information, product information and transmitter configuration. This page has two subpages. namely SNMP and SNMP Trap Config.

\- The *SNMP* sub pagecontains basic information about the SNMP In and Out parameters.

> \- The *SNMP Trap Config* subpage contains the trap configuration info as well as a Trap Sink table which makes the remote configuration of the trap sinks easier.
>
> ### DVBT
>
> On the **DVBT** page of the connector, all the relevant state information of the DVB SIngle Transmitter is available. This page has a subpage called Commands.
>
> \- In the *Commands* subpage, you can find all the mode configurations info that can be used for the transmitter control. It also has a Commands Tx Table which contains important commands to the transmitter.
>
> ### Receiver
>
> The **Receiver** page contains status and power parameters.
>
> ### Exciter
>
> On the **Exciter** page of the connector, you can find more information about the Exciter's Input, Status, Precorrection, Configuration and Product Informaion in the respective tables. All of these information is read-only.
>
> ### Alarms/Events
>
> This page has multiple subpages, namely Alarms, Events and Controls.
>
> \- The *Alarms* subpage contains all the necessary information to handle the alarms.
>
> \- The *Events* subpage contains all the configurable parameters for the DVB Receiver/Monitor modules and the product information about the module that are necessary when contacting Rohde and Schwarz services.
>
> \- The *Controls*subpage contains all the control parameters of the DVB Single Transmitter.
