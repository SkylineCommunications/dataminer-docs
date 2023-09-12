---
uid: Connector_help_EVS_Cerebrum
---

# EVS Cerebrum

This is a WebSocket-based connector with Cerebrum acting as the server, using either secure or non-secure communication, depending on how this is configured within the Cerebrum application.

The data sent over the WebSocket connection, once initial handshakes are complete, is XML-based.

## About

### Version Info

| **Range**            | **Key Features**                                      | **Based on** | **System Impact**                                                                         |
|----------------------|-------------------------------------------------------|--------------|-------------------------------------------------------------------------------------------|
| 1.0.0.x \[obsolete\] | Initial version                                       | \-           | \-                                                                                        |
| 1.0.1.x              | New version because of invalid connector integration. | \-           | Loss of trending, alarming, saved parameters, etc. Creating a new element is recommended. |

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

To be able to log in to the WebSocket API, specify the **User Name** and **Password** on the **Credentials** page.

When the login is successful, the **Credential State** will show the *OK* state.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

### General Page

This page contains parameters related to the **system** and the **WebSocket** API.

When the **System Controller State** changes to *Enabled*, the Cerebrum server acts as the active server and the WebSocket subscriptions are made.

### Cortex Link Page

This page provides an overview of the Cortex link **Tx**, **Rx**, and **connectivity** parameters.

### Cortex Link Redundancy Page

This page provides an overview of the Cortex link **redundancy** parameters.

### SQL Server Info Page

This page provides an overview of the **primary** and **secondary** server, and **SQL** information.

### Statistics Page

This page provides an overview of statistics related to the WebSocket API.

### Sources Page

The following options are available in the right-click menu on this page:

- **Add To Category**: Adds the selection of sources to the specified category.
- **Add Alternate Mnemonic**: Adds an alternate mnemonic to the source.
- **Exclude:** Adds the selected sources to the source exclusion list. Any routes matching the source exclusions will not be shown in the routes table. You can for example use this if you do not want to show your "not connected" routes.

### Source Associations

To **create** a source association, specify the configuration settings on the **Source Configuration** subpage and click the **Create** button.

With the **Delete** option in the right-click menu, you can delete the selected source association.

### Destinations Page

The following options are available in the right-click menu on this page:

- **Add To Category**: Adds the selection of destinations to the specified category.
- **Add Alternate Mnemonic**: Adds an alternate mnemonic to the destination.

### Destination Associations

To **create** a destination association, specify the configuration settings on the **Destination** **Configuration** page and click the **Create** button.

With the **Delete** option in the right-click menu, you can delete the selected destination association.

### Categories

The following options are available in the right-click menu on this page:

- **Create**: Creates a new category with the specified settings.
- **Delete**: Deletes the selected category.
- **Add To Parent**: Adds the selected category to the specified parent category.

On the **Category Sub Categories**, **Category Sources**, **Category Destinations**, and **Category Salvos** subpages, you can also use the **Delete** option in the right-click menu to delete the selected sub category item, source category item, destination category item, or salvo category item, respectively.

## Notes

Most Cerebrum systems consist of both a primary and a secondary server. At any point in time, only one of these servers will be "active", and the other will be in an "inactive" state. While a connection can always be made to both servers, the inactive server will only respond to the LOGIN and POLL command.

If a virtual IP address has been enabled within Cerebrum, this can be used to ensure that the client is always connected to the active server. However, as this method does not confirm network connectivity from the client to the currently inactive server, some provisions should be made to ensure that a connection will be available following a switch between the servers.

The configuration of the WebSocket-related subscription items is only applicable when the Cerebrum server acts as the active server.
