---
uid: Connector_help_Solarwinds_Orion
---

# Solarwinds Orion

The **Solarwinds Orion** is a monitoring tool used by system administrators and network engineers. This connector is intended to collect information about the components available on the network. That information is provided by the Orion modules (APM, NCM, IPAM, NPM, etc.).

This connector will export a different connector based on retrieved data (see section "Exported Connectors"). The corresponding **Solarwinds Orion Node** element is generated when **DVE Creation** is enabled in the **Orion Nodes** table.

## About

### Version Info

| **Range**            | **Key Features**                      | **Based on** | **System Impact** |
|----------------------|---------------------------------------|--------------|-------------------|
| 1.0.0.x \[Obsolete\] | Initial version                       | \-           | \-                |
| 1.0.1.x \[Main\]     | Partial tables, new request mechanism | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | NPM 10.4               |
| 1.0.1.x   | NPM 10.4               |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                                |
|-----------|---------------------|-------------------------|-----------------------|------------------------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | [Solarwinds Orion Node](xref:Connector_help_Solarwinds_Orion_Node) |
| 1.0.1.x   | No                  | Yes                     | \-                    | [Solarwinds Orion Node](xref:Connector_help_Solarwinds_Orion_Node) |

## Configuration

### Connections

HTTP main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: *17778*
- **Bus address**: *bypassproxy*

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## Usage

A REST/JSON API will be used to define queries sent to the tool through HTTP POST commands.

For more information about the API, refer to the website <https://github.com/solarwinds/OrionSDK/wiki>. For more information about the Orion suite, refer to <http://www.solarwinds.com/>.

The element created with this connector has the following data pages:

- **General**: Displays the address of the tool and the credentials that must be filled in in order to start communicating with it.
- **Engines**: Contains an overview of the engines with related information.
- **Nodes**: Contains an overview of the nodes available in the network and related information.
- **Interfaces**: Contains an overview of the interfaces and statistics about the interfaces available in the server.
- **Volumes**: Displays the available volumes along with statistical data about them.
- **Pollers**: Displays the pollers created in the system.
- **Module**: Displays the modules that are part of the Orion suite and that have been installed in the system.
- **Discovery**: Contains information related to the discovery of the different elements on the network.
- **Topology**: Displays topology information about the connections between the elements in the network.
- **Settings**: Contains extensive information about specific settings related to the Orion system.
- **Security**: Contains data related to security.
- **Events**: Allows you to check events generated on the network.
- **Forecast**: Contains forecast-related statistical data.
- **Alerts**: Displays alerts and alert settings.
- **Auditing**: Contains auditing information.
- **Actions**: Displays actions that can be performed.
- **Maintenance Plan**: Displays the maintenance planned for the system.
- **Syslog**: Contains Syslog messages received by the server.
- **Report**: Contains all report-related information.
