---
uid: DataMiner_Edge
description: "Learn how DataMiner Edge extends the xOps platform with local Edge Node execution and secure Edge Gateway connectivity."
---

# About DataMiner Edge

Operational data is often generated at remote or on-premises locations, while DataMiner runs centrally, for example on DaaS. Traditionally, accessing that data from a central platform can require additional connectivity solutions, such as site-to-site VPN connections. Setting up and maintaining these connections can add deployment effort and operational overhead.

DataMiner Edge addresses this challenge. It can extend the DataMiner xOps platform to remote and on-premises environments in two ways:

- [Edge Node mode](xref:About_Edge_Nodes) (currently available in preview) runs the integration where the data is generated, which supports operational continuity when connectivity is intermittent, unavailable, or bandwidth-constrained. It runs Python-based connector integrations locally, close to the operational data.

- [Edge Gateway mode](xref:About_Edge_Gateways) provides connectivity between centrally running integrations and remote data sources. It uses a secure gateway or tunnel to access remote data sources while connector logic and workflows continue to run centrally in DataMiner.

Edge Nodes are available in preview from DataMiner 10.6.10/10.7.0 onwards<!--RN 46037, 46072, and 46142-->. Edge Gateways are available from DataMiner 10.5.10/10.6.0 onwards.
