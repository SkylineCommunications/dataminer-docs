---
uid: Connector_help_Orbitracs_OPM_ACU
---

# Orbitracs OPM ACU

The Orbitracs OPM ACU connector facilitates the operation and monitoring of tracking systems.

## About

This connector uses **SNMP** to extract the relevant information used to monitor and manage Orbitracs OPM ACU events.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | RU-4.1                      |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: 80.13.26.167 (Simulation provided by the vendor)
- **Device address**: not required

SNMP Settings:

- **Port number**: 161
- **Get community string**: public
- **Set community string**: private

## Usage

### General

This is the default page. Here some **general** information is displayed. This includes the **Station Name and Location (Latitude, Longitude and Altitude), UTC Clock,** present pointing satellite **(Orbit Position,** **Satellite Name and Offset** (fine-pointing offset)), station **Clock Status** (GPS synchronized), button to force the clock synchronization.

**Repointing**:

- **Select Satellite** drop-down list (created from the satcat.ocf file) from where an existing satellite can be selected. Saves the last selected satellite.
- Increment arrow selection. To select a position with **0.01ø**, **0.05ø** or **1ø** increments (**West** or **East**). Repetitive and can be mixed with the other increments commands below. To be terminated by **GO** for validation. Time-out of 5 sec.
- **Position Input,** free orbit position input. Format "p+xxx.xx" or "p-xxx.xx". Format should be respected, insert leading zeros if needed.

Following **settings** are provided with page buttons:

- **Console**: **Console Line,** allow display the on-going process after **Force Sync**, **Repointing** or **Fine-pointing**.
- **Maintenance:** **Start** and **operate** the OPM in **DOS mode**.

### Fine-pointing

This page contains information/options for a fine-pointing offset.
**OPM ACU Status:** indicate if the pointing correction has been established (**On Target**) or if is still **Moving**.
**Offset:** Indicate fine-pointing offset. Directions arrow selection (**Left**, **Right** and **Up**, **Down**) of **0.1ø** increments with **maximum** value of **1.9ø**.

The page button **Console** (described above) is presented too on this page.
