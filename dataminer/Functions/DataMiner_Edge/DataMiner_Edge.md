---
uid: DataMiner_Edge
description: Learn how DataMiner Edge executes Python-based connector integrations close to on-premises and remote data sources.
---

# About DataMiner Edge

DataMiner Edge extends the DataMiner xOps platform to remote and on-premises environments. It lets you run Python-based connector integrations close to operational data, while managing the integration and its element centrally from DataMiner.

Available from DataMiner 10.5.0 [CU19]/10.6.0 [CU7]/10.6.10 onwards<!--RN 46037, 46072, and 46142-->, DataMiner Edge provides the foundation for deploying and running Python-based integrations on DataMiner Edge Nodes.

## The challenge

Operational data is often generated at remote or on-premises locations, while DataMiner runs centrally, for example on DaaS. Traditionally, accessing that data from a central platform can require additional connectivity solutions, such as site-to-site VPN connections. Setting up and maintaining these connections can add deployment effort and operational overhead.

DataMiner Edge addresses this challenge by running the integration where the data is generated, rather than running it centrally. This supports operational continuity when connectivity is intermittent, unavailable, or bandwidth-constrained.

## How DataMiner Edge works

DataMiner Edge uses **DataMiner Edge Nodes**. An Edge Node is a lightweight runtime environment that runs on Windows or Linux. It securely connects to DataMiner either directly or through dataminer.services and provides a managed environment in which connector integrations can collect and process data locally.

![An Edge Node running a scripted connector on Windows or Linux, connecting to a DataMiner element over a secure WebSocket connection, either directly or via the cloud.](~/dataminer/images/Edge_Node.png)

Python-based integrations are included in a DataMiner connector package. When you create an element using such a connector, you select a compatible Edge Node and configure the scripts and any connector-defined settings. DataMiner then deploys the required scripted connector to the selected node and creates its schedule.

The Edge Node runs the integration according to the configured schedule and returns the resulting data to the DataMiner element.

The script and its schedule are kept in sync with the element lifecycle. They are enabled when the element is started, disabled when it is paused or stopped, and removed when the element is deleted. When a script no longer has any schedules, it is also removed<!--RN 46072-->.

When the connection to DataMiner is interrupted, an Edge Node buffers collected data on disk. After connectivity has been restored, the buffered data is automatically synchronized with DataMiner.

This makes edge execution part of the existing connector and element lifecycle. Elements can be created and managed centrally in DataMiner, while their integrations execute close to the data source.

For information on configuring an Edge-enabled element, see [Adding a DataMiner element](xref:Adding_a_DataMiner_element).

## Main components

DataMiner Edge consists of the following main components:

- DataMiner System: Centrally manages the element, its connector, and the lifecycle of the integration.

- Edge Node: Provides the local runtime environment where the integration is executed.

- Scripted connector: Contains one or more Python-based integrations, together with their dependencies and metadata.

- Element: Represents the integration and the returned operational data in DataMiner.

## Security

Each execution runs in a secure context and receives a unique secret. The integration must use this secret when returning data to DataMiner, ensuring that only authorized executions can submit data.
