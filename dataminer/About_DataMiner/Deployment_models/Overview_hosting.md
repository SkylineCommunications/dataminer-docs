---
uid: Overview_hosting
description: DataMiner's architecture makes it extremely resilient to all types of failures, also because this architecture has no single point of failure.
---

# DataMiner deployment models

DataMiner's architecture makes it extremely resilient to all types of failures, also because this architecture has no single point of failure.

DataMiner is deployed starting from [dataminer.services](xref:Overview_dataminer_services). The core software can be deployed either as a managed service ([DaaS](xref:DaaS_hosting)) or via [private cloud or on-premises deployment](xref:DM_selfhosted_and_StaaS). Both options by default use Storage as a Service ([STaaS](xref:DaaS_hosting#effortless-storage-with-staas)).

![DataMiner deployment models](~/dataminer/images/DataMiner_Stack_deployment_models.png)

Each of the different hosting possibilities has its own strengths in term of redundancy and high-availability options:

- [DataMiner as a Service](xref:DaaS_hosting): both the DataMiner nodes and the storage nodes as a service.

  ![DaaS](~/dataminer/images/DaaS.svg)

- [Self-managed DataMiner nodes with Storage as a Service](xref:DM_selfhosted_and_StaaS).

  ![Hybrid](~/dataminer/images/Hybrid.svg)

> [!NOTE]
> Exceptionally, instead of going for a standard DataMiner deployment model, you can also host both the DataMiner nodes and the storage nodes yourself. However, note that this is a deviation from our advised deployment path, and it is a complex setup that we do not recommend and that will involve additional costs (e.g. procurement of additional hardware for hosting the databases and associated running and maintenance costs, mandatory Skyline Communications engineering services for the deployment and configuration of the database cluster, as well as for database-related tickets, etc.). See [Self-managed DataMiner nodes and storage nodes](xref:DM_and_storage_selfhosted).
>
> ![Self-managed](~/dataminer/images/Self-managed.svg)
