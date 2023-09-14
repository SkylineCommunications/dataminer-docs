---
uid: Connector_help_Harmonic_Electra_XT
---

# Harmonic Electra XT

The **Harmonic Electra XT** is a **video system** supporting all-IP environments with live broadcast-quality encoding, video preprocessing, and file transcoding.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Unknown                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

**HTTP CONNECTION**:

- **IP address/host**: The polling IP or URL of the destination, e.g. *10.11.12.13.*
- **IP port**: The port of the destination, e.g. *80.*

### Initialization

Once the element has been created, the user credentials must be filled in. To do so, go to the **General** page and click the **Credentials** page button.

### Redundancy

Redundancy is not defined in the connector.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## Usage

The element made using this connector has the following data pages:

- **General**: Displays the date and time of the device, as well as the **Network Storage Table**. Via the **Credentials** page button, you can fill in the username and password to access the device.
- **Workflow**: Displays the **Workflow Table**.
- **Hardware**: Displays a tree view with relevant information, structured in a hierarchy of **Node**, **Job** and **Job Parameter**.
- **Nodes**: Contains the **Node Table**.
- **Jobs**: Displays the **Jobs List Table**. Via the **Job Information** page button, you can find more detailed information about each job on the device. The **Custom Display Key** parameter allows you to customize the Job Table's display key.
- **Alarms**: Contains the **Active Log Table** and the **Active Alarm Table**. In the Active Alarm table, you can find the alarm states of the jobs.
