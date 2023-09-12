---
uid: Connector_help_Telenor_EPM_MAM_Consumer
---

# Telenor EPM MAM Consumer

This connector is used to collect messages stored in a RabbitMQ queue and forward them to multiple **Telenor EPM Collector** elements.

The messages are transferred from the MAM consumer to the collectors using multi-threaded serial communication.

To be aware of the collector elements available in the system, the connector will read provision files created by the **Telenor EPM Manager** element.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | RabbitMQ 3.8.5         |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                                                                                     | **Exported Components** |
|-----------|---------------------|-------------------------|-------------------------------------------------------------------------------------------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | [Telenor EPM Collector](/Driver%20Help/Telenor%20EPM%20Collector.aspx) [Telenor EPM Manager](xref:Connector_help_Telenor_EPM_Manager) | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

<!-- -->

- **IP address/host**: The IP address is irrelevant because the connector uses multi-threaded serial communication. The field can be set to *127.0.0.1*.
  - **IP port**: The port is irrelevant because the connector uses multi-threaded serial communication. The field can be set to the default value *8935*.

## How to Use

On the **General** page, the connection settings towards the RabbitMQ server must be specified. This includes the **IP Address**, the **Port** and the credentials. The **General** page also displays some statistics about the number of messages received.

The **Collectors** page displays a table containing all the collectors detected in the system and their current state. The path and access details to the folder containing the provisioning files can be configured on this same page

The **Log** page can be used to configure the custom logging. The connector uses custom logging to display the messages received for specific devices. The log files are stored in the folder *C:\Skyline DataMiner\Telenor\Elements\\ElementName\>\Logging*. The devices table is used to configure the list of devices for which the received messages should be logged. Via the right-click menu of the table, you can add devices to the table or remove them.

The **Elastic Search Offload** page contains the toggle button **Elastic Offloading Status** to configure the offload of Errors to Elastic. The index under which the records are stored is *MAMConsumerDB.ErrorMessagesTable*. Next to this option, there is a possibility to debug the offloading of errors by temporary copy the offloaded errors to the Erros Offloaded Debug Table.
