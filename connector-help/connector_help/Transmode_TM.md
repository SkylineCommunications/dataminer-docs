---
uid: Connector_help_Transmode_TM
---

# Transmode TM

The Transmode TM is a **transponder/muxponder** that is used as a buffer between the "client layer" and the "WDM domain". As a result of this buffer, client equipment of different types and from different vendors can be connected to the Transmode network. A transponder/muxponder also enables encapsulation of the client signal into a digital wrapper, i.e. extra bytes are added to the client signal at the client ingress point and removed at the client egress point. These overhead bytes can be used for a number of features such as Performance & Fault Management, FEC, Automatic Laser Shutdown, etc.

## About

This connector retrieves and sets data via **SNMP**.

### Version Info

| **Range** | **Description**                                                                                                                                                        | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                                                                                                                                        | No                  | No                      |
| 1.0.1.x          | \- Implementation of DCF - Obsolete DisplayColumn technology replaced (for improved efficiency & Cassandra support): No access to previous trend data for some tables. | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | r23b-31                     |
| 1.0.1.x          | r23b-31                     |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host:** The polling IP of the device.

SNMP Settings:

- **Port number:** The port of the connected device, by default *161*.
- **Get community string:** The community string used when reading values from the device. The default value is *public*.
- **Set community string:** The community string used when setting values on the device. The default value is *private*.

## Usage

### General

This page displays the **system node info**. Via page buttons, you can access the **IP**, **Options** and **Configuration** settings.

The page also contains buttons that can be used to show the **Board Table**, **Equipment Table**, **Module Overview**, **Ping**, **Power Table** and **Fan Table**.

### Client overview 1-4

These pages display the **various parameters** that correspond with the different **clients**. Some of these parameters can also be set from the displayed **client tables**.

### IP

This page displays the **IP Interface Table** and the **IP Route Table**.

### Alarms

This page displays a table containing all **Alarms.**

### BackUp

This page displays the **BackUp File Table**, which stores the backup configurations.

### Line Overview (PM 15m - PM 24h)

These pages display the different **Line Overview Tables** (Line Overview - Line PM 15m - Line PM 24h).

### Passive IF

This page displays the **Passive IF Table**.

### Port

This page displays the **Port Table**.

### VLAN

This page displays the **VLAN Port Table** and the **Management VLAN Table**.

### Traffic Data (PM 15m - PM 24h)

These pages display the **Traffic Data Tables** for PM 15m and PM 24h.

### Physical Transceiver

This page contains the **Physical Transceiver** and the **Basic Admin Interface** tables.

### Optical Transmission

This page contains the **Optical Transmission Section** and **Optical Channel** tables.

### Optical Signal Processing

This page contains the **Optical Digital Signal Rate**, **Optical FEC** and **OTN OTU** tables.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

The **1.0.1.1** connector range of the Transmode TM protocol supports the usage of DCF and can be used on a DMA with a minimum version of **8.5.7.2**.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Dynamic Interfaces

Physical dynamic interfaces:

- **IP**: inout type

- **Client**: inout type

  - Board Table (depending on Type, see below)

- **Line**: inout type

  - Board Table (depending on Type, see below)

### Connections

#### Internal Connections

- From **Client** to **Line**

  - Connections differ depending on the **Type** of the row in the **Board Table**. (Not all types are implemented. See below for a list of the implemented types.)

  - **Types:**

    - **TPQMRI:**

      - Client x:y:1-2 \<-\> Line x:y:3-4
      - Client x:y:5-6 \<-\> Line x:y:7-8
      - Client x:y:9-10 \<-\> Line x:y:11-12
      - Client x:y:13-14 \<-\> Line x:y:15-16

    - **TPDDGBE:**

      - Client x:y:1-2 \<-\> Line x:y:13-14
      - Client x:y:3-4 \<-\> Line x:y:13-14
      - Client x:y:5-6 \<-\> Line x:y:15-16
      - Client x:y:7-8 \<-\> Line x:y:15-16

    - **TPD10GL:**

      - Client x:y:1-2 \<-\> Line x:y:3-4
      - Client x:y:5-6 \<-\> Line x:y:7-8

    - **MSMXP10G:**

      - Client x:y:1-2 \<-\> Line x:y:21-22
      - Client x:y:3-4 \<-\> Line x:y:21-22
      - Client x:y:5-6 \<-\> Line x:y:21-22
      - Client x:y:7-8 \<-\> Line x:y:21-22
      - Client x:y:9-10 \<-\> Line x:y:21-22
      - Client x:y:11-12 \<-\> Line x:y:21-22
      - Client x:y:13-14 \<-\> Line x:y:21-22
      - Client x:y:15-16 \<-\> Line x:y:21-22
      - Client x:y:17-18 \<-\> Line x:y:21-22
      - Client x:y:19-20 \<-\> Line x:y:21-22

    - **GBE10EMXP10II:**

      - Client x:y:1-2 \<-\> Line x:y:21-22
      - Client x:y:3-4 \<-\> Line x:y:21-22
      - Client x:y:5-6 \<-\> Line x:y:21-22
      - Client x:y:7-8 \<-\> Line x:y:21-22
      - Client x:y:9-10 \<-\> Line x:y:21-22
      - Client x:y:11-12 \<-\> Line x:y:21-22
      - Client x:y:13-14 \<-\> Line x:y:21-22
      - Client x:y:15-16 \<-\> Line x:y:21-22
      - Client x:y:17-18 \<-\> Line x:y:21-22
      - Client x:y:19-20 \<-\> Line x:y:21-22

    - **MDU4EXT2F:**

      - Client x:y:1-5 \<-\> Line x:y:9-10
      - Client x:y:2-6 \<-\> Line x:y:9-10
      - Client x:y:3-7 \<-\> Line x:y:9-10
      - Client x:y:4-8 \<-\> Line x:y:9-10
      - Client x:y:11-12 \<-\> Line x:y:9-10

    - **MDU4TERM2F:**

      - Client x:y:1-5 \<-\> Line x:y:9-10
      - Client x:y:2-6 \<-\> Line x:y:9-10
      - Client x:y:3-7 \<-\> Line x:y:9-10
      - Client x:y:4-8 \<-\> Line x:y:9-10
