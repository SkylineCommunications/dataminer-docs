---
uid: Connector_help_EVS_Cerebrum
---

# EVS Cerebrum

This is a WebSocket-based connector with Cerebrum acting as the server, using either secure or nonsecure communication, depending on how this is configured within the Cerebrum application.The data sent over the WebSocket connection, once initial handshakes are complete, is XML-based.

## About

### Version Info

| **Range**            | **Key Features**                                  | **Based on** | **System Impact**                                                                       |
|----------------------|---------------------------------------------------|--------------|-----------------------------------------------------------------------------------------|
| 1.0.0.x \[obsolete\] | Initial version                                   | \-           | \-                                                                                      |
| 1.0.1.x              | New version due to invalid connector integration. | \-           | Loss of trending, alarming, saved parameters, etc.It's advised to create a new element. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | API 0.1                |
| 1.0.1.x   | API 0.1                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

WEBSOCKET INTERFACE:

- **IP address/host**: ws://*\[the polling IP or URL of the destination\]*
- **IP port**: The IP port of the destination, default: *40007*.

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

To be able to log-in with the WebSocket API, specify the **UserName** and **Password** on the **credentials** page.

When the log-in is successful, the **credential state** will show the '**OK**' state.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

### General

Provides the **system** and **WebSocket** API related parameters.When the **system controller state** changes to '**Enabled**', the Cerebrum server acts as the active server and the WebSocket subscriptions are made.

### Cortex Link

Provides an overview of the Cortex link **Tx**, **Rx** and **connectivity** parameters.

### Cortex Link Redundancy

Provides an overview of the Cortex link **redundancy** parameters.

### SQL Server Info

Provides an overview of the **primary** and **secondary** server, and **SQL** information.

### Statistics

Provides an overview of the WebSocket API related statistics.

### Sources

*Context Menu*- **Add To Category**: Adds the selection of sources to the specified category.- **Add Alternate Mnemonic**: Add an alternate mnemonic to the source.- **Exclude:** Adds the selected sources to the source exclusion list. Any routes matching the source exclusions will not be shown in the routes table. E.g. you do not want to show your 'not connected' routes.

### Source Associations

*Configuration*In order to create a source association, specify the configuration settings on the **Source Configuration** page and click the **Create** button.

*Context Menu*- **Delete**: Deletes the selected source assocation.

### Destinations

*Context Menu*- **Add To Category**: Adds the selection of destinations to the specified category.- **Add Alternate Mnemonic**: Add an alternate mnemonic to the destination.

### Destinations Associations

*Configuration*In order to create a destination association, specify the configuration settings on the **Destination** **Configuration** page and click the **Create** button.

*Context Menu*- **Delete**: Deletes the selected destination association.

### Categories

*Context Menu*- **Create**: Creates a new category with the specified settings.- **Delete**: Deletes the selected category.- **Add To Parent**: Adds the selected category to the specified parent category.

### Category Sub Categories

*Context Menu*- **Delete**: Deletes the selected sub category item.

### Category Sources

*Context Menu*- **Delete**: Deletes the selected source category item.

### Category Destinations

*Context Menu*- **Delete**: Deletes the selected destination category item.

### Category Salvos

*Context Menu*- **Delete**: Deletes the selected salvo category item.

## Notes

Most Cerebrum systems consist of both a Primary and Secondary server.At any point in time only on of these servers will be 'active', the other will be in an 'inactive' state.Whilst a connection can always be made to both servers, the inactive server will only respond to the LOGIN and POLL command.

If a virtual IP address has been enabled within Cerebrum, this can be used to ensure that the client is always connected to the active server.However, as this method does not confirm network connectivity from the client to the currently inactive server, some provision should be made to ensure a connection will be available following a failover of servers.

The configuration of the WebSocket related subscription items is only applicable when the Cerebrum server acts as the active server.
