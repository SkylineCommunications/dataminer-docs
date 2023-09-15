---
uid: Connector_help_T-Vips_CP540
---

# T-Vips CP540

This connector is used to retrieve status parameters, mainly alarms, via SNMP.

## About

This connector fetches status information via SNMP and displays it in simple parameters and tables.

### Version Info

| **Range** | **Description**          | **DCF Integration** | **Cassandra Compliant** |
|------------------|--------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version          | Yes                 | Yes                     |
| 1.1.0.x          | New firmware (see below) | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Before v3.1                 |
| 1.1.0.x          | v3.1                        |

## Installation and configuration

### Creation

#### Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device, e.g. *127.0.0.1*.
- **Device address**: Not required.

**SNMP Settings:**

- **Port number**: The port of the connected device, e.g. *161*.
- **Get community string**: The community string used when reading values from the device, e.g. *public*.
- **Set community string**: The community string used when setting values on the device, e.g. *private*.

## Usage

### Main View

This page provides general information concerning the device: **Product Name**, **Device Name**, **General Alarm Status**, ...

### General

This page also displays general information, along with other extra parameters such as **Serial Number**, **Software Version**, **Current Relay Position**, ...

### Input Alarm

This page displays detailed alarm statuses through several parameters: **Input A Sync Unstable**, **Input A CC Error**, **Input A TS ID Incorrect**, **Input B Transport Error**, **Input B State Scrambling Bits**, ...

### Output Alarm

On this page, several parameters provide alarm status information regarding the Output: **Output PTS Error**, **Output Input Overflow**, **Output Service Missing**, ...

### Inputs

On this page, the **Input Overview** table shows the following information for each input: the **Input Alarm Status**, **Input Total Bitrate**, **Input Effective Bitrate** and **Input Synchronisation**.

The following page buttons provide service- and PID-specific information for both Inputs (A and B): **Services**, **Pids** and **Normalized Values**.

### Outputs

On this page, you can find general output parameters (**Output Synchronisation**, **Output Alarm Text**, **Output Name**), output service parameters (page button **Output Services**) and PID-related output parameters (page button **Output PIDs**). With the **Output Normalized Values** page button, you can also view **Normalized bitrates** for services and PIDs.

### Web Interface

This page can be used to access the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DCF Implementation

### Input A

If the **Current Relay Position** parameter (on the **General** page) is set to **Input A**, the following connections will be made:

- From the **ASI Input A** in interface to the **ASI Out Main** out interface.
- From the **ASI Input B** in interface to the **ASI Out Alternate** out interface.

### Input B

If the **Current Relay Position** parameter (on the **General** page) is set to **Input B**, the following connections will be made:

- From the **ASI Input A** in interface to the **ASI Out Alternate** out interface.
- From the **ASI Input B** in interface to the **ASI Out Main** out interface.
