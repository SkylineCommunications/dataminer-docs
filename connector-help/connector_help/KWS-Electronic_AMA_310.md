---
uid: Connector_help_KWS-Electronic_AMA_310
---

# KWS-Electronic AMA 310

The **KWS-Electronic AMA 310** does measurements of analog or digital signals.

## About

This connector uses **SNMP** to set up the measurement parameters and get the measurement values.

The different measurements can be executed according to the round-robin principle.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | V45761.14e                  |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.66.98.240*.

SNMP Settings:

- **Port number**: *161*
- **Get community string**: *public*.
- **Set community string**: *private*.

## Usage

### Measurement Config

This is the default page for controlling the different measurement types and measurements. Whenever a new measurement is added, the default values are loaded. Each measurement has three different tables that can be configured:

- The waiting time between the operations.
- Which parts of the measurement are enabled.
- The number of retries that are allowed to happen on a certain part.

When a new measurement is added, its running **state** will be equal to "*Not configured*". This means that some values have to be filled in first, before the measurement can be used. After these values are filled in, the state will automatically change to "*Waiting*".

It is possible to change the order in which measurement types are executed by changing their sequence in the measurement type table. The lower the sequence, the faster this type of measurement will be handled. With the **Move Up** and **Move Down** buttons, the sequence can be customized.

In the **Measurement Overview**, you can also find an **Execute Next** button. This button changes the current running state of the measurement to "*Pending"*. When the currently running measurement is finished, the pending measurement will be performed. Note that only one "*Pending*" measurement can be available in the table, and that a currently running measurement cannot be set to "*Pending*".

Note that a measurement will **only be executed** when both the **operating state** of the measurement type and the **measurement itself** are *enabled*.

### General Config

On this page, the round-robin mechanism can be configured together with some SNMP polling settings.

- The **Input Source** can be set to either *COAX* or *FIBRE*.
- The **Round Robin Polling Interval** is displayed in seconds. This value is the amount of time the connector waits between two measurements. For example, when this value is set to *5 s*, the idle time between two consecutive measurements will equal *5 s*.
- The **Round Robin Operating State** indicates whether or not polling should occur. When this parameter is *Disabled*, there will be **no polling**.
- The **Ama Level Unit** can be set to *dBmV*, *dBm* or *dBuV*.
- The **Ama Sound Carrier Measurement** can be set to *Relative* or *Absolute*.
- The **Ama FM Start and Stop Frequencies** can be set. Setting one of these values can have an impact on the other value.

### Import/Export Data

It is possible to export the current configuration for all the measurements to an .xml file. From version 1.0.0.19 of the connector onwards, it is also possible to export the name, type, frequency and sound type of each measurement to a .csv file.
To export, select the appropriate **File Type (Export)**, fill in the export **File Name** and click the **Export** button.
When the export has succeeded, the value of the **Last Export** field changes to the current time. This parameter will also display any errors that occurred.

A measurement configuration in .xml format can also be imported. In addition, from version 1.0.0.19 of the connector onwards, you can modify existing measurements and add new measurements by importing a .csv file.
To import, select the appropriate **File Type (Import)**, select the file name via **Select File** and click the **Import** button.
When the import has succeeded, the value of the **Last Import** field changes to the current time. This parameter will also display any errors that occurred.

Below, you can find an example of the structure of the .csv file that can be used from version 1.0.0.19 onwards. Note that the header line is fixed and each line has 4 columns. A semicolon (";") delimiter is used. Values for frequency use a decimal point ( . ).

> Measurement Name;Type;Frequency;Sound Type
>
> VRT Radio 1;FM;88.5;Comedy Central;TV ANA;133.25;NICDisney Channel Vl;TV ANA;280.25;STEREO

### Measurement Type pages

These pages contain a table with the additional settings that can be done for each measurement, and a table with the measurement results. Each page has three subpages containing the aforementioned tables.

To initialize a measurement, fill in the mandatory values in the **Measurement** **Status** table. The results of the measurement are also displayed in this table.

### Firmware Upgrade

As of version **1.0.0.25**, the connector also allows you to upgrade the **firmware** of the device. All related parameters can be found on the **Firmware Upgrade** page.

Before the firmware can be upgraded, you first need to **load the software via FTP**. To do so:

1. Start Windows Explorer, and connect to the AMA310 using the following URL: *ftp://\<ipaddress\>*

1. Copy the upgrade file (.bin2) to the FTP directory of the AMA310.

Once this is done, the **upgrade itself** can be performed. To do so:

1. Configure the **FTP User Name**, **FTP Password** and **Uploaded File Name** correctly. (In case the *anonymous* user is used, the *password* can be blank.)

1. Start the upgrade itself by clicking the **Start Upgrade** button.

   The **Uploaded File Execution State** parameter will indicate the status of the upgrade. When the upgrade is successfully completed, this parameter will transition to *Idle*.
