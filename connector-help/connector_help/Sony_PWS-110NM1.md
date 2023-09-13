---
uid: Connector_help_Sony_PWS-110NM1
---

# Sony PWS-110NM1

This is a smart-serial, SNMP, and HTTP connector that is used to monitor and configure the Sony PWS-110NM1 equipment.

## About

The information on the device parameters is retrieved via **SNMP** communication. The matrix information is received over a **smart-serial** connection. Additional information is polled via API calls over an **HTTP** connection.

### Version Info

| **Range**            | **Key Features**  | **Based on** | **System Impact** |
|----------------------|-------------------|--------------|-------------------|
| 1.0.0.x              | Initial version   | \-           | \-                |
| 1.0.1.x              | QA version        | 1.0.0.20     | \-                |
| 1.0.2.x \[SLC Main\] | Added DCF support | 1.0.0.45     | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.1.x   | 1.25                   |
| 1.0.2.x   | 1.25                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Smart-Serial Main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device. Required.

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

#### HTTP connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

### Initialization

On the **Device Info** \> **HTTP Credentials** page, add the **Username** and **Password** for the HTTP connection.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created using this connector consists of the data pages detailed below.

### General

This page displays system information, including the **System Time**, **System Description**, **System Location**, **System Contact**, **System Up Time**, and other general parameters.
This page has page buttons that open the following subpages:

- **General Status**: Displays status information concerning the **IP Live System Manager**, i.e. **Status**, **General Status Description**, **System Stat Status**, and **Module Status table**.
- **NMI Gateway Status**: Displays the **NMI Module Gateway Status**, **NMI Module Status Description**, and **NMI Module Gateway Status Code**.
- **Gen Lock Status**: Displays the **Gen Lock Module Status**, **Gen Lock Module Description**, and **Gen Lock Status Code**.
- **NS-BUS Controller Status**: Displays the NS-BUS Controller table, listing the **Name**, **Status**, **Description**, and **Code**.
- **Redundancy**: Displays the **Redundancy**, **Redundancy Status**, **Redundant Status Description**, and **Redundant Status Code**.
- **External Router Status**: Displays the **External Router System Gateway** table, with the **System Name**, **Status**, **Description**, and **Status Code**.

### Network

This page displays the **Interfaces** and **Address Translation** tables. The operational status from the interfaces can also change based on incoming traps.

### Product Information

This page displays the **Product Information**, **Modules**, and **Remote Maintenance** tables.

### Traps

This page displays the **Traps Destination** table.

### Alarms

This page displays the **Error Status** table. This table is cleared when a "Coldstart" trap is received.

### Matrix

This page contains the **matrix** representation. The labels that are displayed here are influenced by the tables on the **All Alias Labels** page and by the **Alias to Use** parameter on the *Session Configuration* page.

### Destinations (Outputs)

On this page, the **Destinations** table displays the matrix destinations, with the output **Index**, **Label**, **Status**, **Connected Inputs**, **Protection Level**, and **Lock Status**.

### Sources (Inputs)

This page displays the **Sources** table. This table contains an **Index** (combination of port and alias information) and the input **Label Name.**

### Port Status

This page contains the **Source Port Error Info** table and the **Destination Port Error Info** table. Both tables contain the **Port Number**, **Level**, **Port Status**, **Error Status**, **Error Code**, **Error Severity**, and **Error Message** columns.

### All Alias Labels

This page contains the labels of the sources and destinations in the **Source Alias Labels** and **Destination Alias Labels** tables.

### Session Configuration

This page displays the **Device ID**, **Session ID**, **Device Description**, **Manufacture**, **Model**, **Name**, **User**, **Version**, **Protocol Version**, **Alias to Use**, and **Sequence Number**, as well as the **NS-BUS Connection Timeout**, **NS-BUS Connection Number of Retries**, and **Sequence Number**. By selecting the **Alias to Use** you can determine which label column from the All Alias Labels page will be shown in the matrix view.

### Available Device Services

This page contains the **Available Device Services** table. The **Name** and **Version** of the services can be found in this table.

### Device Info

This page displays the **Device Info**, **Device Name**, **ID**, **Device User**, **Serial Number**, **Device Manufacturer**, **Device Version**, and **Description**.

Via a page button, the page also provides access to the **HTTP Credentials** that are used for the API calls. On the subpage, the **Username** and **Password** can be set.

### Device Configuration

This page displays the **Device Configuration** table, containing the **Config ID**, **Number**, **Config Type**, **Device ID**, **Config Name**, **Description**, **Content Type**, and **HasValue** columns.
You can recall a configuration by selecting it with the **Configuration To Set** parameter and using the **Recall** button.

The **Parent ID**, **Parent Status**, **Parent Progress**, and **Parent Description** are also displayed on this page, as well as the **Configuration End Status** and **Status Description**.

Finally, the page also contains the **Status Load And Recall Child Devices** table, which displays the **Status**, **Progress**, and **Description** of the recall, via the child **ID**.
