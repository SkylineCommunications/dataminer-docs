---
uid: Connector_help_Thomson_Nextream_Vibe_VS7000
---

# Thomson Nextream ViBE VS7000

The **Thomson ViBE VS7000** is a **video system** supporting all-IP environments with live broadcast-quality encoding, video preprocessing, and file transcoding.

## About

This is an SNMP and HTTP connector that is used to configure and monitor the **Thomson Video Networks ViBE VS7000** device.

### Version Info

| **Range** | **Description**                               | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version.                              | No                  | \-                      |
| 1.1.0.x          | Supports device firmware version 4.0.0.0.     | No                  | \-                      |
| 1.1.1.x          | Supports a variable number of job parameters. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | \-                          |
| 1.1.0.x          | 4.0.0.0                     |
| 1.1.1.x          | 4.0.0.0                     |

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and an HTTP connection. It requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

**HTTP CONNECTION**:

- **IP address/host**: The polling IP or URL of the destination, e.g. *10.11.12.13.*
- **IP port**: The port of the destination, e.g. *80.*

### Configuration

Once the element has been created, the user credentials must still be filled in. To do so, go to the **General** page and click the **Credentials** page button.

## Usage

### General

This page displays the **Date and Time** of the device and the **Network Storage Table**.

Via the **Credentials** page button, you can fill in the username and password to access the device.

### Workflow

This page displays the **Workflow Table**.

Via the **Parameters** page button, you can check the list of public WorkFlow parameters.

### Hardware

This page displays a **tree view** with relevant information structured according to **Node**, **Job** and **Job Parameter**.

### Nodes

This page contains the **Node Table**.

### Jobs

This page displays the **Jobs List Table**.
From device firmware version 4.0.0.0 and connector version 1.1.0.1 onwards, this table has new parameters.

Via the **Job Information** page button, you can find more detailed information about each job on the device.

In version **1.1.0.x**, there is a **Custom Display Key** parameter that allows you to customize the Job Table's display key.

From version **1.1.1.5** onwards, a **Create Job** button is available, which starts a wizard that allows you to create and configure the WorkFlow that will be used for the job. The wizard uses the Automation script *Thomson_Nextream_Vibe_VS7000_New_Job.*

From version **1.1.1.6** onwards, a **Manage** button is available in the **Job Table**, which starts a wizard that allows you to configure the WorkFlow parameters that will be used for the job. The wizard uses the Automation script *Thomson_Nextream_Vibe_VS7000_Manage_Job.*

### Alarms

This page contains the **Active Log Table** and the **Active Alarm Table**.

In the **Active Alarm** table, you can find the alarm states of the jobs.

### Web interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
