---
uid: netinsight-nimbra-vision-overview
---

# NetInsight Nimbra Vision

The DataMinert NetInsight Nimbra Vision solution package focuses on end-to-end **monitoring and orchestration** of NetInsight Nimbra networks from a single pane of glass.

Traditionally, device products have focused on managing their specific configurations, creating opportunities for third-party solutions like DataMiner to offer a holistic view. This enables users to easily define and configure end-to-end services across their infrastructure. However, integrating all features of each specific device product can be challenging for third-party platforms.

> [!IMPORTANT]
> DataMiner leverages the management of converged networks, including both NetInsight platforms and third-party products such as SDI routers, edge devices, IP routers and switches, PTP infrastructure, and others. This comprehensive approach ultimately enables end-to-end orchestration.

The NetInsight Nimbra Vision product is designed to provide management and orchestration functionalities for Nimbra MSR networks. This allows DataMiner to act as an orchestrator of orchestrators, leveraging Vision's computational and routing algorithms while maintaining a comprehensive view of the infrastructure.

In this context, the DataMiner Nimbra Vision solution is a valuable asset for any customer using Nimbra products. It is not intended to replace any Nimbra product but rather to offer features that simplify the orchestration of end-to-end services on a Nimbra MSR network. The DataMiner Nimbra Vision solution provides comprehensive monitoring and orchestration of Nimbra Nodes from a single pane of glass. This seamless end-to-end monitoring and orchestration is made possible through its integration with the Nimbra Vision platform.

![NetInsight Nimbra Vision](~/user-guide/images/netinsight-nimbra-vision-demo.gif)

## Key Features
The DataMiner Nimbra Vision solution provides not only a comprehensive view of all active Nimbra MSR circuits (with easy filtering based on type, node and metadata), but also a simplifies the process of setting up a new ad hoc Nimbra MSR circuit. Users can simply choose a service type, a source and destination node from the DataMiner XY routing panel, and click connect. The system automatically computes and schedules the network paths in the background.

- **Adhoc services**: ability to quickly create ad hoc circuits (services) of any type, with the necessary properties.
- **Schedule services**: prepare and schedule with auto-route path detection a circuit for the future.
- **Monitoring**: quick access to specific nodes to promptly assess their health, usage, and alarms. 

> [!IMPORTANT]
> At this stage the solution is a MVP and does not necessarily cover the full feature set of the NetInsight Products.

## Solution Components

This solution is composed by the following artifacts.

| Artifact name | Artifact type     | Location |
|-------------|---------------------|------    |
| NetInsight Nimbra Vision | Connector    | [Catalog](https://catalog.dataminer.services/details/e48af0b9-b52c-4106-b0e0-22c44ead85f5) |
| NetInsight Nimbra Vision | Visio    | [Catalog](https://catalog.dataminer.services/details/9bf706bd-93a3-421f-ba1c-c2620f5e072d)    |
| Nimbra Vision app | Low-code app | [Catalog](https://catalog.dataminer.services) |
| Source code | Automation | [GitHub](https://github.com/SkylineCommunications/NIS-AS-NimbraVisionScripts) |

Please head over to [NetInsight Nimbra Vision Architecture](xref:netinsight-nimbra-vision-architecture) to get more details on the architecture of this solution.