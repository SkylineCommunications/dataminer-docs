---
uid: About_Edge_Nodes
keywords: DataMiner Edge, scripted connectors
description: "Learn how DataMiner Edge Nodes run Python-based connector integrations locally and synchronize collected data with DataMiner."
---

# About Edge Nodes

> [!IMPORTANT]
> At present, this feature is only available in preview, if the [DataAPI](xref:Overview_of_Soft_Launch_Options#dataapi) soft-launch option is enabled. For more information, see [Soft-launch options](xref:SoftLaunchOptions).

An Edge Node is a lightweight runtime environment that runs on Windows or Linux. It securely connects to DataMiner either directly or through dataminer.services and provides a managed environment in which connector integrations can collect and process data locally.

## How Edge Nodes work

Python-based integrations are included in a DataMiner connector package. When you create an element using such a connector, you select a compatible Edge Node and configure the integrations and any connector-defined settings. DataMiner then deploys the required integrations to the selected node and creates their schedules.

The Edge Node runs each integration according to its configured schedule and returns the resulting data to the DataMiner element.

The integrations and their schedules are kept in sync with the element lifecycle. They are enabled when the element is started, disabled when it is paused or stopped, and removed when the element is deleted. When an integration no longer has any schedules, it is also removed<!--RN 46072-->.

When the connection to DataMiner is interrupted, an Edge Node buffers collected data on disk. After connectivity has been restored, the buffered data is automatically synchronized with DataMiner.

This makes local execution part of the existing connector and element lifecycle. Elements can be created and managed centrally in DataMiner, while their integrations execute close to the data source.

For information on configuring an Edge-enabled element, see [Adding a DataMiner element](xref:Adding_elements).

## Main components

Edge Node mode consists of the following main components:

- DataMiner System: Centrally manages the element, its connector, and the lifecycle of the integration.

- Edge Node: Provides the local runtime environment where the integration is executed.

- Connector: Contains one or more Python-based integrations, together with their dependencies and metadata.

- Element: Represents the integration and the returned operational data in DataMiner.

## Security

Each execution of a Python-based integration runs in a secure context and receives a unique secret. The integration must use this secret when returning data to DataMiner, ensuring that only authorized executions can submit data.
