---
uid: Connector_help_Radeus_Labs_ACU_8200
---

# Radeus Labs ACU 8200

The 8200 ACU is compatible with industry-standard drive cabinet interfaces and legacy position feedback devices such as absolute rotary optical encoders, standard single-speed brushless size-11 resolvers, and two-speed brushless size-20 resolvers.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                                                                                                                                                                                                                                                                                                                   | **Based on**                                                                                    | **System Impact**                                                                                                                                                                             |
|----------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x \[Obsolete\] | Initial version                                                                                                                                                                                                                                                                                                                                                                                                                    | \-                                                                                              | \-                                                                                                                                                                                            |
| 1.0.1.x \[SLC Main\] | **Major** **Changes:** - In the Targets table: Moved column Longitude from 12th position to 3rd position and Beacon Frequency from 14th to 4th. - Moved parameters "Offset Azimuth/Elevation/Polarization" from Positioner to Encoder page. - Moved parameters "Fault test Period ..." from Timing to Motion page. **Fix:** Ack/Unacknowledged Faults are now string parameters (this was incorrect from version 1.0.0.2 onwards). | 1.0.0.2 (the change made in version 1.0.0.3 is also present in 1.0.1.x, but in a different way) | \- Displayed column order of table changed (existing custom reports may no longer work). - Layout changes may take some getting used to. However, the result is similar to the web interface. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.0.1.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element created with this driver consists of the data pages described below. Each page displays information about the **Actual Positions** of the antenna and **Receiver** parameters like the **Receiver Signal Level**.

### General

This page displays general system parameters such as **System Name**, **System Location** and the **Database Version**.

### Main View

This page contains **Status** information about the device

### Settings

On this page, you can configure the device settings. More information is displayed on each subpage: **Site**, **Receiver**, **Encoders**, **Limits**, **Motion**, **Timing**, **Options**, **Positioner** and **Targets**.
