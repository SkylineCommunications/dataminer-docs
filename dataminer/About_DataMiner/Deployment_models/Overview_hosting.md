---
uid: Overview_hosting
description: Explore the DataMiner deployment models. The core software can be deployed as a managed service (DaaS) or via private cloud or on-premises deployment.
---

# DataMiner deployment models

DataMiner's architecture has no central node, which allows you to build systems that are resilient to many types of failures. How resilient a system is depends on the redundancy of its nodes, its storage, and its network connections. See [Redundancy](xref:Overview_Architecture_and_components#redundancy).

DataMiner is deployed starting from [dataminer.services](xref:Overview_dataminer_services). The core software can be deployed either as a managed service ([DaaS](xref:DaaS_hosting)) or via [private cloud or on-premises deployment](xref:DM_selfhosted_and_StaaS). Both options by default use Storage as a Service ([STaaS](xref:DaaS_hosting#effortless-storage-with-staas)).

![DataMiner deployment models](~/dataminer/images/DataMiner_Stack_deployment_models.png)

Each of the different hosting possibilities has its own strengths in term of redundancy and high-availability options:

- [DataMiner as a Service](xref:DaaS_hosting): both the DataMiner nodes and the storage nodes as a service.

  ![Schematic overview of a DaaS setup](~/dataminer/images/DaaS.svg)

- [Self-managed DataMiner nodes with Storage as a Service](xref:DM_selfhosted_and_StaaS).

  ![Schematic overview of a STaaS setup](~/dataminer/images/Hybrid.svg)

You can also [combine these two options](xref:Hybrid_clusters) within the same DataMiner cluster.

The deployment model does not determine where your equipment can be. A DaaS system can monitor private equipment through a site-to-site VPN or DataMiner Edge. See [Connecting to private data sources](xref:Connecting_to_private_data_sources).

> [!TIP]
> For example architectures that show how these deployment models are used in practice, see [DataMiner System architecture and components](xref:Overview_Architecture_and_components#choosing-an-architecture).

> [!NOTE]
> Exceptionally, instead of going for a standard DataMiner deployment model, you can also host both the DataMiner nodes and the storage nodes yourself. However, note that this is a deviation from our advised deployment path, and it is a complex setup that we do not recommend and that will involve additional costs (e.g., procurement of additional hardware for hosting the databases and associated running and maintenance costs, mandatory Skyline Communications engineering services for the deployment and configuration of the database cluster, as well as for database-related tickets, etc.). See [Self-managed DataMiner nodes and storage nodes](xref:DM_and_storage_selfhosted).
>
> ![Self-managed](~/dataminer/images/Self-managed.svg)
