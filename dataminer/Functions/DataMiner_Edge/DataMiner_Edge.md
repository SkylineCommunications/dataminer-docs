---
uid: DataMiner_Edge
description: Learn how DataMiner Edge extends the xOps platform with local Edge Node execution and secure Gateway mode connectivity.
---

# About DataMiner Edge

DataMiner Edge extends the DataMiner xOps platform to remote and on-premises environments. It provides two ways to access operational data while managing elements centrally from DataMiner:

- [Edge Node mode](xref:About_Edge_Nodes) runs Python-based connector integrations locally, close to the operational data.

- [Gateway mode](xref:GatewayModeOverview) uses a secure gateway or tunnel to access remote data sources while connector logic and workflows continue to run centrally in DataMiner.

Edge Nodes are supported from DataMiner 10.5.0 [CU19]/10.6.0 [CU7]/10.6.10 onwards<!--RN 46037, 46072, and 46142-->. Gateway mode is available from DataMiner 10.5.10/10.6.0 onwards.

## The challenge

Operational data is often generated at remote or on-premises locations, while DataMiner runs centrally, for example on DaaS. Traditionally, accessing that data from a central platform can require additional connectivity solutions, such as site-to-site VPN connections. Setting up and maintaining these connections can add deployment effort and operational overhead.

DataMiner Edge addresses this challenge in two ways. Edge Node mode runs the integration where the data is generated, which supports operational continuity when connectivity is intermittent, unavailable, or bandwidth-constrained. Gateway mode provides secure connectivity between centrally running integrations and remote data sources, without requiring a site-to-site VPN.

For more information, see [About Edge Nodes](xref:About_Edge_Nodes) and [About Gateway mode](xref:GatewayModeOverview).
