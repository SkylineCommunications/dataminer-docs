---
uid: Connector_help_Huawei_iManager_U2000_D-CCAP
---

# Huawei iManager U2000 D-CCAP

The Huawei iManager U2000 D-CCAP is a device that contains all topology info of a network.

## About

SNMP is used to retrieve general parameters and alarms entering through traps.

Through SFTP, the topology files will be retrieved. These files will be split per OLT by the connector.

### Version Info

| **Range** | **Description**                        | **DCF Integration** | **Cassandra Compliant** |
|------------------|----------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                        | No                  | Yes                     |
| 2.0.0.x          | Virtual Protocol. SNMP pages are gone. | No                  | Yes                     |
| 2.0.1.x          | Based on 2.0.0.x; Alarms Page.         | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | V200R015C50                 |
| 2.0.0.x          | V200R015C50                 |
| 2.0.1.x          | V200R015C50                 |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Configuration of SFTP

Protocol versions 1.0.0.x: To configure SFTP, go to the **General** page and click the **SFTP** page button.

Protocol versions 2.0.0.x: Go to **SFTP** page.

On the left-hand side, fill in the SFTP credentials to be used to connect to the SFTP.

On the right-hand side, configure where the files should be stored. Use the **Storage Method** parameter to specify how the files should be stored: *Only Local* or *Local and Remote*. The local directory where the files should be placed can be configured with **Storage Local File Path**. If **Storage Method** is set to *Local and Remote*, the credentials of the remote locaction can be configured with the **Storage Remote** parameters.

Configuration of Stored Procedure

To configure the Stored Procedure file Formats, go to the **Stored Procedure Configurations** page and configure the four name format parameters.

## Usage

### General Page

**Optional page**: This page is only available in protocol versions: **1.0.0.x**.

This page contains the main parameters, such as the **System Description**.

The page also contains the **SFTP** page button, which opens the SFTP subpage. In addition to the parameters mentioned in the "Configuration of SFTP" section above, this page also contains the following buttons: **Get Files** and **Process Files**.

When you click **Get Files**, the files will be downloaded to the local directory and if needed uploaded to the remote location. Afterwards, the files will be processed and split per OLT. A *Topology* directory will be created in the local directory. A CMTSs.csv file will be created, containing all the OLTs. Per OLT, a new subdirectory will be created. This OLT directory will contain 4 files: Amplifier.csv, Channel.csv, CM.csv and CMC.csv.

When you click **Process Files**, there will be no download or upload, but the files that are in the local directory will be split.

### Alarms Page

**Optional page**: This page is only available in protocol versions: **1.0.0.x**.

This page contains the incoming trap alarms. These are displayed in the **Alarm Overview** table.

Via the **Clean Up Config** page button, you can configure how the **Alarm Overview** table should be cleaned up. **Trap Clean Up Method** can be set to the one of the following values:

- *Row Count*: As soon as there are as many alarms as configured in **Max Traps**, the number of rows specified in **Trap Clean Up Amount** will be removed.
- *Trap Age*: As soon as an alarm is older than configured in **Max Age Traps**, that trap will be removed.
- *Combo*: Combines the above possibilities: as soon as the row limit is reached or the alarm is too old, it will be removed.

Via the **Filter Config** page button, you can configure the **Trap Receiving IP Address** and **Trap Receiving Port**.

## Usage - range 2.0.0.x

### SFTP

On the left-hand side, fill in the SFTP credentials to be used to connect to the SFTP.

On the right-hand side, configure where the files should be stored. Use the **Storage Method** parameter to specify how the files should be stored: *Only Local* or *Local and Remote*. The local directory where the files should be placed can be configured with **Storage Local File Path**. If **Storage Method** is set to *Local and Remote*, the credentials of the remote locaction can be configured with the **Storage Remote** parameters.

### Stored Procedure Configurations

To configure the Stored Procedure file Formats, go to the **Stored Procedure Configurations** page and configure the four name format parameters.

### Settings

In this page is possible to configure the **Scheduler**.

### Statistics

The Statistics Page displays information about the Cable Modems and the Amplifiers.

## Usage - range 2.0.1.x

### SFTP

On the left-hand side, fill in the SFTP credentials to be used to connect to the SFTP.

On the right-hand side, configure where the files should be stored. Use the **Storage Method** parameter to specify how the files should be stored: *Only Local* or *Local and Remote*. The local directory where the files should be placed can be configured with **Storage Local File Path**. If **Storage Method** is set to *Local and Remote*, the credentials of the remote locaction can be configured with the **Storage Remote** parameters.

### Stored Procedure Configurations

To configure the Stored Procedure file Formats, go to the **Stored Procedure Configurations** page and configure the four name format parameters.

### Settings

In this page is possible to configure the **Scheduler**.

### Statistics

The Statistics Page displays information about the Cable Modems and the Amplifiers.

### Alarms

The Alarms page displays an **Alarms** table with the alarms sent by the device. It is possible to set the number of entries in the table with the **Max Number of Alarms** parameter and to remove all the entries with the button **Remove All**. The **Configurations** sub page displays information about the state of the connection and when the last trap was received. We can set the number of **Keep Alive Retries** and execute the command for the device to resend the active alarms in the system with the button **Resync Alarms**.
