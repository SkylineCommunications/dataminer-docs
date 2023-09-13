---
uid: Connector_help_Comcast_LRM
---

# Comcast LRM

The purpose of this driver is to receive messages from the Comcast LRM system. It will act as a server using the smart-serial protocol. It can log received messages and determine when two messages refer to the same situation with a different status.

This driver should use TLS encryption in combination with basic HTTP authentication.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.4                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The driver will act as a server. Set this field to "*Any*".
  - **IP port**: By default *3000*. A different port can be specified.

### Initialization

To perform the basic HTTP authentication, you need to specify credentials on the General page and make sure the authentication process is enabled. If the received message does not contain the specified credentials, the reply will be a 401 HTTP code.

## How to Use

### General

On this page, you can specify the credentials to authenticate the received messages and enable/disable the authentication process.

### Messages

This page contains the **Messages** table. When a message is received, and it passes the configured authentication requirements and has the expected format, a row will be added to this table. If two messages have the same Notification ID, they will be considered to refer to the same situation, so that the same row in the table will be updated.

Each row contains additional information regarding the **Age** of the message and its **Alarm Status**. The alarm status is calculated based on the user-defined **Alarm Timeout**. If a message is older than the Alarm Timeout value, its Alarm Status will change to *disabled*. This feature allows you to customize the alarm template.

The page also displays the **Message Status**, which shows information related to the last received message. You can also configure the **Message Timeout**. This value will be used to determine the Message Status, in order to provide information about how long the element has not received any messages. You can enable monitoring on this parameter, so that a DataMiner alarm is generated when a message is not received in an expected time period, allowing you to troubleshoot possible connection issues.

### Debug

This page contains the last received message and the response. This information can be useful for debugging purposes.
