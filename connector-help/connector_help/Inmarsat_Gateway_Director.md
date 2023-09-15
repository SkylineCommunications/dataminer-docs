---
uid: Connector_help_Inmarsat_Gateway_Director
---

# Inmarsat Gateway Director

This connector acts as a **manager** for the **Inmarsat Gateway** connector. The connector will share the terminals over the available gateways.

## About

This connector uses the HTTP protocol to create sessions and request data from the server. The data is received in JSON format, parsed and displayed in a table.

The connector acts as a **manager** for the Inmarsat Gateway. It manages the terminals for each Inmarsat Gateway element.

### Version Info

| **Range**     | **Description**                  | **DCF Integration** | **Cassandra Compliant** |
|----------------------|----------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version                  | No                  | Yes                     |
| 1.1.0.x \[SLC MAIN\] | Made compatible with the new API | No                  | Yes                     |

## Configuration

### Connections

#### HTTP main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: [https://api.inmarsat.com](https://api.inmarsat.com/)
- **IP port**: *443*
- **Bus address**: *byPassProxy*

## How to use

The element created with this connector consists of the data pages described below.

### General

This page displays the device name and device type. It also allows you to enable debug mode, which can be used to generate more log information.

### Authentication

This page allows you to specify the credentials for the **Inmarsat Gateway API**, as well as to view general information. The **Connection Status** parameter indicates the status of the main (HTTP) connection.

In the 1.0.0.x range of the connector, the following information must be filled in to request information from the Inmarsat Gateway API:

- **API Key**
- **API Username**
- **API Password**

In the 1.1.0.x range of the connector, the following information is required instead:

- **API Client ID**
- **API Client Secret**

### Terminals

On this page, the **Terminal Table** displays an overview of all available terminals:

- The terminal **State** in the table indicates the state of the terminal related to the **API**:

- ***New***: The terminal has been detected by the director for the first time.
  - ***Equal***: The terminal continues to exist.
  - ***Removed***: The terminal no longer exists in the API.

- The **Deleted** column indicates if the terminal has been deleted **by the user**. If a terminal is marked as deleted, **no data** will be polled for it anymore. If the terminal was assigned to a terminal manager, it will be **unassigned** from it and its **DVE will be deleted automatically**.

- The **Polling** column indicates if data will be polled for the terminal.

- The **Gateway** column indicates the **Inmarsat** **Gateway** the terminal is **assigned** to.

The following settings and actions are also available on this page:

- **Auto Enable Terminals**: Enable this setting to **automatically enable** **polling** for new terminals.
- **Auto delete all removed terminals**: Enable this setting to **delete** terminals with a **removed** **state** from the system.
- **Delete all removed terminals**: This button allows you to **manually** **delete** all terminals with a **removed** **state** from the system.

### Gateway Elements

On this page, the **Gateway Elements** table provides an overview of the available Inmarsat Gateway elements:

- You can add gateway elements to the table by selecting **Add** in the table **context menu** and then selecting the right element in the drop-down list.
- The **Number of Terminals** column indicates how many terminals are assigned to the gateway element.
- The **Maximum Allowed Terminals** indicates the maximum terminals that can be assigned to the gateway element.

The following settings and actions are also available on this page:

- **Gateway Elements Refresh**: Refreshes the available gateway elements that are not yet used by the director.
- **Default Max Allowed Terminals**: Determines the **default maximum allowed terminals** that can be assigned to **new gateway elements**.

### Satellites (range 1.1.0.x only)

This page contains all the satellites detected by the Inmarsat Gateways. Their longitude can be added, after which the information will be sent to all the gateways.

### Metric Overview

This page contains a table with all the **statistics** that can be polled for all the object types.
