---
uid: DaaS_connecting_to_data_sources
---

# Connecting to data sources using a DaaS system

To connect to data sources so that you can see their information in DataMiner, you need to [create DataMiner elements](xref:Adding_elements). For a quick tutorial illustrating how to do so, refer to [Creating your first element on a DaaS system](xref:Creating_your_first_element_on_a_DaaS_system).

Your DaaS system is able to connect to three types of data sources:

![Connecting to different data sources with DaaS](~/user-guide/images/DataSources.png)

## Cloud services

DaaS can communicate with any cloud service as long as it has a public endpoint and a secure way of connecting. This could for example be an Azure App Service, AWS S3, Azure Blob Storage, etc.

Each DaaS instance also has a public IP so it can receive SNMP traps.

## Publicly available data sources

DaaS can communicate with any public APIs such as Slack API, Open Weather Map API, Trello API, YouTube API, GitHub API, etc.

It can also connect to any of your on-premises resources that are publicly available. Make sure that these are published in a secure fashion to ensure that DataMiner can connect to them securely.

## Private data sources

To connect to resources in your private network, DaaS will connect using a VPN gateway. However, this requires additional configuration for which you will need to contact Skyline. For more details, see [Connecting to private data sources with DaaS](xref:Connecting_to_private_data_sources).
