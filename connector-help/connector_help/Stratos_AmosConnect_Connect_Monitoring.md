---
uid: Connector_help_Stratos_AmosConnect_Connect_Monitoring
---

# Stratos AmosConnect Connect Monitoring

This connector connects to an external MySQL database for monitoring purposes.

## About

This connector uses an **Oracle Connection** to connect with the database.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                                          |
|------------------|----------------------------------------------------------------------|
| 1.0.0.x          | 11.2.0.2.0 Oracle Database 11g Release 11.2.0.2.0 - 64bit Production |

## Installation and configuration

### Creation

#### Serial Main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device (e.g. *10.24.13.151*).
  - **IP port**: The IP port of the device is required (e.g. *1521*).
  - **Bus address**: Not required.

## Usage

### Main

At the top of this page, you can configure the parameters needed to connect to the database: the **Username**, **Password** and **Oracle System ID (SID)**.

The page contains several tables:

- The **Last Poll Results** table provides the following information for each **Gateway Type**: **Successful Sessions**, **Failed Sessions**, **Total Sessions**, **Success Rate** and **Failure Rate**.
- The **Last Hour Results** table displays the following for each **Gateway Type**: the **Successful Sessions**, **Failed Sessions**, **Total Sessions**, **Success Rate** and **Failure Rate**.
- The **Last 24 Hours Results** table contains the following information for each hour of the day: the **TCP Failed Sessions**, **TCP Success Rate**, **Dial-In Total Sessions**, **Dial-In Success Rate**, etc.

The **Last Hour History** page button, which can be found below the Last Hour Results table, displays the **Last Hour Poll Results** table, which contains the following information for each **Poll Gateway Type** during the last hour, with an interval of 5 minutes: the **Poll Successful Sessions**, **Poll Failed Sessions**, **Poll Total Sessions**, **Poll Success Rate** and **Poll Failure Rate**.
