---
uid: Connector_help_SES_S.A._DCMS
---

# SES S.A. DCMS

The Dedicated Carrier Monitoring System (**DCMS**) permanently measures the downlink Equivalent Isotropically Radiated Power (**EIRP**) of the European SES satellite. Aside from EIRP values, it also measures **System Gain** and **Radiometer** **Data**, and keeps track of some **Housekeeping Data Values**, such as **Outside Temperature** and **Voltages**.

## About

The **SES S.A. DCMS** connector is used by DataMiner to access, process, and display relevant information about some of the DCMS data files, such as **EIRP Data**, **System Gain** and **Housekeeping** (**Outer Temperature**, **Hub Temperature**, **Noise Source 1 Temperature**, **Noise Source 2 Temperature**, **Voltage -15V Supply**, **Voltage 5V Supply**, **Voltage 15V Supply** and **Voltage 28V Supply**). The data, accessed from a Windows share, is treated as one independent file for each of the above parameters. In the case of the satellite database file, multiple pieces of data are retrieved, such as **Original** and **Backup Satellite Name**, **Frequency**, and **Nominal**, **Low**, and **High EIRP.** All files, excluding the satellite database file, also return **Date Time** information about the retrieval of data.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | N/A                         |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation. All files are retrieved from Windows Local Shares as from version 1.0.0.1.

## Usage

### General

For each type of file, this page indicates the number of files that exist for the current month. This information is displayed for **EIRP**, **System Gain**, **Database** and **Housekeeping Files**. In addition, this page displays the **Directory Path** (Windows path) used by the connector to retrieve all data files, and it also shows the **Status** of this directory.

Note: The **Directory Path** must contain the **DCMS ID** (e.g. *C:\Skyline DataMiner\Documents\SES S.A. DCMS\DCMS Files\dcms3-data*).

### Channels

This page displays the **Channels Table**, the **Poll Table** button and several additional parameters.

- **Channels Table**: Contains information from the **Satellite Database**, **EIRP Data** and **System Gain Files**. It includes the following parameters:

- **Date Time**: The time information about the last retrieval of data.
  - Original Satellite Name (hidden)
  - Backup Satellite Name (hidden)
  - **Frequency (MHz)**
  - EIRP Nominal (dBW) (hidden)
  - EIRP Low (dBW) (hidden)
  - EIRP High (dBW) (hidden)
  - **EIRP Measured (dBW)**
  - **Time since last EIRP update**
  - **System Gain (dB)**
  - **Time since last Gain update**
  - **Alarm Preset**
  - **Preset Priority**

- **Poll Table** button: The table information is regularly polled by the protocol logic. However, you can also manually trigger table polling at any time with this button.

- **Max Time Since Last EIRP Update**: This parameter displays the largest time value of all rows since an EIRP update was last received.

- **Max Time Before Timeout**: This parameter specifies from which value of the "Max Time Since Last EIRP Update" parameter onwards the element will go into timeout.

### Housekeeping

This page displays the **Housekeeping Data**, the **Housekeeping Control Table** and the **Poll** button.

- **Housekeeping Data**: Shows information from the system's **housekeeping files**. The displayed parameters are:

- **Outer Temperature (øC)**
  - **Hub Temperature (øC)**
  - **Noise Source 1 Temperature (øC)**
  - **Noise Source 2 Temperature (øC)**
  - **Voltage -15V Supply**
  - **Voltage 5V Supply**
  - **Voltage 15V Supply**
  - **Voltage 28V Supply**

- **Housekeeping Control Table**: Contains information regarding the status of parameters and the last update time of files.

- **Poll Table** button: The information is regularly polled by the protocol logic. However, you can also manually trigger table polling at any time with this button.

### Alarm Presets

On this page, you can create and edit **Alarm Presets**. You can also import and export presets using .csv files.
