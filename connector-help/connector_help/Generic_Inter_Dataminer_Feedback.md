---
uid: Connector_help_Generic_Inter_Dataminer_Feedback
---

# Generic Inter Dataminer Feedback

This is a virtual connector that is used to receive messages and mark them as read.

This connector can catch incoming messages via a parameter set. The only communication method used is inter-element communication.

## About

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|--|--|--|--|
| 1.0.0.x | Initial version | No | Yes |

## Configuration

### Connections

This connector uses a **virtual connection** and does not require any input during element creation.

### Initialization

To make sure that incoming messages cannot lead to an endlessly growing table, you should configure:

- Whether or not you want to **Keep Read Messages**.

- The **Maximum Number of Read Messages** in the Messages Table (set to 1000 by default). When this number is reached, the oldest half of the messages will be deleted.

The **Number of Read Messages** represents the number of messages with status *Read* stored in the **Messages Table**.

## Usage

There are two **parameters** that can be **set** from **another element** or from an **Automation script**:

- Parameter ID: 60 - EXTERNAL_InconingMessages

  - This parameter should be set with the format *To*ValueofTo*From*ValueOfFrom*Message*ValueOfMessage, and separated with the char ***SOH***:

    | Dec | Hex | Acronym | Name             | Description                          |
    |-----|-----|---------|------------------|--------------------------------------|
    | 01  | 01  | SOH     | Start of Heading | First character of a message header. |

- Parameter ID: 61 - EXTERNAL_InconingIDtoMarkAsRead

  - This parameter should be set with the ID of the row of which the status should be changed to *Read*.

### General

This page contains an overview of the messages. The **Number of New Messages** represents the number of messages with status *New* stored in the **Messages** **Table**.

The table has the following columns:

- **ID**: Auto-incremented ID of this row.
- **To**: The destination of the message.
- **From**: The source of the message.
- **Status**: The status of the message. This can be *New* or *Read*. (When a message is received, the status is set as *New*).
- **Message**: Content of the message.
- **Mark as Read**: Button to change the status of the message from *New* to *Read*.
