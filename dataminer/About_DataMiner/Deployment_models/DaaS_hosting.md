---
uid: DaaS_hosting
description: DataMiner as a Service will allow you to spin up your DataMiner System in the cloud in just a few minutes with cloud-hosted DataMiner nodes.
---

# DataMiner as a Service

Today's applications need to be highly responsive and always online. To achieve low latency and high availability, instances of these applications need to be deployed in data centers that are close to their users. Applications need to respond in real time to large changes in usage at peak hours, store ever increasing volumes of data, and make this data available to users in milliseconds.

We therefore also offer **DataMiner as a Service (DaaS)**, a DataMiner platform fully hosted by Skyline Communications. Both the solution and the storage are hosted by Skyline in its DataMiner Azure Stack. This allows you to spin up your DataMiner System in the cloud in just a few minutes with Skyline-hosted DataMiner nodes (SaaS).

**You operate the platform, we build and maintain the platform for you.**

Our DaaS model guarantees that you immediately get access to a wide range of capabilities for streamlined and worry-free solution development.

> [!TIP]
> For more hands-on information, see [Creating a DataMiner System on dataminer.services](xref:Creating_a_DMS_on_dataminer_services).

## Benefits of DataMiner as a Service (DaaS)

DataMiner as a Service will allow you to spin up your DataMiner System in the cloud in just a few minutes with cloud-hosted DataMiner nodes. This is what this means:

- *Supercharge your productivity*

  It has never been easier to set up a DataMiner System. Whether you are in need of a quick test, aiming to establish a lab environment, or building a production environment, all it takes is a simple click to effortlessly spin one up. And when you are done, just as easily, you can spin it back down.

  In other words, you gain access to the full power of a DataMiner System, free from any concerns about hardware, infrastructure, or maintenance. It is a hassle-free experience that allows you to focus solely on the task at hand.

- *Experience the convenience of cloud connectivity*

  Since your DataMiner System is spun up in the cloud, you are immediately cloud-connected, which comes with many amazing capabilities, from Live Dashboard Sharing to direct access to DataMiner connectors from the Catalog. Discover all the benefits of being cloud-connected.

- *Benefit from DataMiner Storage as a Service (STaaS)*

  DataMiner as a Service comes with our very own Storage as a Service (STaaS) solution. This means your DataMiner System will immediately benefit from being connected to a scalable and user-friendly cloud-native storage platform. Gone are the days of estimating your storage requirements in advance, placing specific VM orders, or configuring complex Cassandra and OpenSearch clusters with the necessary replication and backup.

- *Security first*

  DaaS is powered by Microsoft Azure and as a result benefits from the same strong security measures: all data is encrypted with 256-bit AES encryption. In addition, we also have a dedicated SecOps team that constantly focuses on optimizing our cloud security.

- *Grow as you go*

  DaaS is built with scalability in mind. This means that you will be able to easily scale both vertically (add or remove resources) and horizontally (add or remove nodes) whenever you need. Another function coming up is intelligent resource distribution or "swarming", which will enable you to automatically redistribute elements between nodes for even more efficiency.

- *Hybrid infrastructure monitoring*

  DaaS will enable you to seamlessly monitor your entire infrastructure regardless of whether it is located on premises or off premises.

  ![DaaS](~/dataminer/images/DaaS.svg)

## Effortless storage with STaaS

For its data storage, DataMiner as a Service makes use of DataMiner Storage as a Service (STaaS), which is powered by Azure's cloud-native storage solutions, such as [Azure Cosmos DB](https://learn.microsoft.com/en-us/azure/cosmos-db/introduction). With automatic management, updates, and patching, database administration is completely taken off your hands. Capacity management is handled with cost-effective serverless and automatic scaling options that respond to application needs to match capacity with demand.

> [!TIP]
> See also:
>
> - [Data location and redundancy](xref:STaaS_features#data-location-and-redundancy)
> - [Data resilience and backups](xref:STaaS_features#data-resilience-and-backups)
> - [Data security and availability](xref:STaaS_features#data-security-and-availability)

## DataMiner as a Service: a complete cloud-native experience

With DataMiner as a Service, Skyline offers a complete cloud-native experience:

![Pillars_NMS](~/dataminer/images/Hosting_DaaS_create.png)

You can go to [dataminer.services](xref:Overview_dataminer_services), where

1. you create an organization,
1. you give a name to your DataMiner System (DMS), and
1. you can start adding elements to it, all with a couple of clicks.

## Regional support for DaaS

By default, your DaaS system is hosted in the Azure West Europe region. However, you can request deployment in [other Azure regions](https://datacenters.microsoft.com/globe/explore/).

Geographically distributed systems with multiple nodes across different regions are also supported. If you require a *custom setup*, contact us at [daas@dataminer.services](mailto:daas@dataminer.services).

For information about the regional support for the linked storage (STaaS) for your DaaS cluster, refer to [Data location and redundancy](xref:STaaS_features#data-location-and-redundancy).
