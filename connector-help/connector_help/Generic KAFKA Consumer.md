---
uid: Connector_help_Generic_KAFKA_Consumer
---

# Generic KAFKA Consumer

This connector uses a virtual connection that interfaces with KAFKA using a Confluent DLL that polls information for one or more topics via one or more brokers that can be defined in the DataMiner element.

The data retrieved from the API will be offloaded to a compressed GZ file with JSON data per topic. This file can then be ingested and used in other workflows by connectors, Automation scripts, etc.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 3.0.0                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

When you have created an element, you still need to configure several things based on your KAFKA system.

#### Mandatory configuration

Add one or more **brokers** to the element:

1.  Go to the **Broker** page of the element.
2.  Right-click the table and select **Add** in the context menu.
3.  Enter the information for the broker(s).

Add one or more **topics** to the element:

1.  Go to the **Topics** page of the element.

2.  Right-click the table and select **Add** in the context menu.

3.  Specify the **Topic name** and the following settings:

4.  - **Subscription Interval**: Determines how frequently the topic will be polled. Default: 5 minutes.
    - **Poll Duration**: Will be used in the API call to determine how long it will poll before the call ends. Default: 1 minute.

#### Optional Configuration

To configure authentication, go to the **Authentication page** of the element and fill out the parameters with the necessary information.

## How to use

After the initialization detailed above is performed, based on a timer, the connector will retrieve data from the **API** for the specified **topic(s)**. This data will be offloaded to the directory path specified in the **Export Directory parameter** in a **GZ** file per topic. These GZ files can then be used in other workflows by connectors, Automation scripts, etc.

The following settings are often of use:

- **Brokers**: Via the right-click menu of the Brokers table, you can add, edit, or delete brokers. Multiple delete is possible by highlighting multiple rows and selecting the delete option in the right-click menu.
- **Topics**: Via the right-click menu of the Topics table, you can add, edit, or delete topics. Multiple delete is possible by highlighting multiple rows and selecting the delete option in the context menu.
- **Consumer & Authentication**:These pages allow you to configure different settings for the Consumer element within the KAFKA API. Note: Double-check your KAFKA settings with the parameters on these pages, because these parameters can directly affect the polling of data from KAFKA.
- **Export Settings**: These settings allow you to toggle the export functionality of the connector and choose whether a local or remote directory should be used. Note: For the remote file handling feature to work, you must enter a local directory in the **Local Export Directory**. The connector will write to this location and then copy over to the remote location. You must also provide the credentials for the system in the **System Credentials** section and enter the path to the remote directory in the **Export Directory** parameter. The **path** **must be shared/accessible**.
