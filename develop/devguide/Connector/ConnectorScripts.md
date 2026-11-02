---
uid: ConnectorScripts
description: "Learn how connector scripts run Python-based integrations on DataMiner Edge Nodes and return collected data to DataMiner elements."
---

# Connector scripts

A connector script is optional Python-based logic that a DataMiner connector can use. When used, it executes on a DataMiner Edge Node, where it collects and processes data close to the data source and returns the resulting data to the DataMiner element.

Connector scripts complement the logic that runs in DataMiner by executing in the managed environment of an Edge Node. This is useful when the integration must run locally at a remote site or close to a data source.

> [!IMPORTANT]
> Edge Node mode is currently available in preview. For more information, see [About Edge Nodes](xref:About_Edge_Nodes).

## How connector scripts work

A connector can contain one or more connector scripts. Each script has its own source code, metadata, dependencies, and tests. The connector declares the script under `Edge.Scripts` in *protocol.xml*, together with its schedule and any input arguments.

Connector scripts use the following flow:

1. The connector package includes the script and its required dependencies.
1. When you create an element, you select a compatible Edge Node and configure any settings defined by the connector.
1. DataMiner deploys the script to the selected Edge Node and creates the configured schedule.
1. At each scheduled execution, the script parses its input, retrieves and processes the data, and pushes a JSON-serializable result to the Edge Node.
1. The Edge Node returns the result to the DataMiner element.

The script and its schedules follow the lifecycle of the element. DataMiner enables them when the element starts, disables them when the element is paused or stopped, and removes them when the element is deleted. If the connection to DataMiner is interrupted, the Edge Node buffers the collected data and synchronizes it when the connection is restored.

## Main components

A connector script consists of the following main components:

- **Connector declaration**: Identifies the script and defines its schedule and optional input arguments under `Edge.Scripts` in *protocol.xml*.
- **Manifest**: Defines the script identity, version, entry point, supported platforms, and Python version.
- **Implementation**: Parses the input, communicates with the data source, and returns the collected data.
- **Dependencies**: Lists the direct third-party Python packages that must be included when the connector is packaged.
- **Tests**: Validate the script logic, input handling, and manifest.

The script identity in the connector declaration must match the identity in the manifest and the script directory in the connector package.

## Input and output

Connector settings can provide deployment-specific values and credentials. The connector maps these settings to script arguments, which the script receives when it runs. This keeps environment-specific configuration separate from the script source code.

The script returns data through the Edge Node. The returned object must be JSON-serializable. For more information about supported table structures, see [Support for tables](xref:Data_API#support-for-tables). For applicable restrictions, see [Data source limitations](xref:Data_Sources_Limitations).

## Security

Each script execution receives a unique secret that authorizes it to return data to DataMiner. Do not store credentials or other environment-specific secrets in the script. Use connector settings or another approved secret mechanism instead.

For information on creating, configuring, debugging, testing, and packaging a connector script, see [Developing connector scripts in Visual Studio](xref:DevelopingConnectorScriptsInVisualStudio).
