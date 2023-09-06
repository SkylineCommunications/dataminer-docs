---
uid: Connector_help_Evertz_Magnum_SDVN_Reflex
---

# Evertz Magnum SDVN Reflex

With Reflex you can automate tasks with sensors, triggers and actions. Scripts can be triggered, and the content of the scripts can be viewed.

## About

### Version Info

| **Range**            | **Key Features**                | **Based on** | **System Impact** |
|----------------------|---------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version.                | \-           | \-                |
| 1.1.0.x \[SLC Main\] | Support for new firmware 2.1.0. | 1.0.0.2      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.5.10                 |
| 1.1.0.x   | 2.1.0                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection - Main

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *8700*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

#### Serial Connection - IP Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination.
  - **Accepted IP addresses**: The IP (usually multiple IP addresses) of the associated Reflex servers that might send unsolicited TCP messages to DataMiner.

The connection above is used to received messages after actions such as HTTP POST, as well as unsolicited TCP messages that can be configured in Reflex to send parameter values to update contexts.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element created with this connector consists of the following data pages:

- **General**: Displays information related to the **Server Info** command. Via the **Show Debugging** page button, you can access a page with debugging parameters.
- **Scripts**: Contains the **Scripts** table, listing all the scripts in the system. The **Run Action** column can be used to trigger a specific action. This page also contains the **Action Execution Logs** table, which logs the status of the run action commands and can be used for alarm monitoring for failed messages from run action commands.
- **Contexts**: Contains the **Contexts** table, with all key value pairs for all the contexts in all the scripts. In the **Value** column, you can update the value. A **Context** value can be updated through receipt of an unsolicited TCP message from Reflex.
- **Messages**: Contains configurable parameters such as **Script to Trigger**, **Run Script After New Message** and **Table Cleanup**. This allows you to configure a DataMiner Automation script to be triggered when a new message is received and added to the **Received Messages** table. This table also logs all incoming TCP messages, including unsolicited TCP messages containing parameter value change data associated with a context. When a message is received, DataMiner will attempt to match the context. When it finds a match, it will update the parameter value associated with that context and set the Message Table "Context Match" parameter to "Present" to indicate that the message was used to update a Context value already present in the Context table. This function is very powerful as it allows DataMiner to receive virtually any data point available in the Reflex system. For example, the TCP message can contain the current state of a Standards and Practices processor. By setting an alarm on that particular context value, you can create an audit trail in DataMiner that shows when a particular operator triggered the S&P Bypass in the event of a requirement to censor a live broadcast in real time.
