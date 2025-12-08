---
uid: FAQ_dataminer_services
---

# Questions related to dataminer.services

## Getting started

### What is dataminer.services?

dataminer.services is a cloud-based extension of the DataMiner System. Connecting your DataMiner System to dataminer.services allows you to augment it with several features that are otherwise not available:

- [Storage as a Service](xref:STaaS)
- [Remote access](xref:About_Remote_Access) to the web pages.
- [Sharing](xref:About_the_Sharing_app) of dashboards.
- Connector deployments from the [Catalog](xref:About_the_Catalog_app)
- [ChatOps](xref:About_ChatOps)
- [Streamlined support services](xref:RemoteLogCollection)
- ...

### How do I connect my DataMiner System to dataminer.services?

To connect your DataMiner System to dataminer.services, you need to install the [DataMiner Cloud Pack](https://community.dataminer.services/dataminer-cloud-pack/) on one or more of your DataMiner Agents. When this is done, you can set up the connection by going to *System Center > Cloud* in DataMiner Cube and clicking the *Connect* button on that page.

> [!TIP]
> For more detailed information, see [Connecting your DataMiner System to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

### Do all Agents in a DMS have to be connected to dataminer.services?

No, You will have full access to all dataminer.services features even with only a single connected DataMiner Agent. However, there are a couple of advantages to connecting more than one Agent:

- **Redundancy**: The Cloud Gateway nodes work independently from each other, which means that as long as one Cloud Gateway node can maintain its connection towards DataMiner.services, your DataMiner System will remain connected to dataminer.services.
- **Load balancing**: Having multiple Agents connected to dataminer.services allows dataminer.services to spread incoming requests across multiple Agents. For example, when multiple shared dashboards are accessed simultaneously, the load will be spread across the connected Agents.
- **Streamlined support services**: Even though not all Agents need to be connected to dataminer.services for this, the [Support Assistant module](xref:DataMinerExtensionModules#supportassistant) needs to be installed on all DataMiner Agents to allow our tech support team to carry out [automated support actions](xref:Proactive_Support).

### How can I find the ID of my organization in dataminer.services?

1. [Log in using your dataminer.services account](xref:Logging_on_to_dataminer_services).
1. Select the organization you want to find the ID of.
1. Go to the webpage URL and copy the last part of the URL after the final slash.

![How to retrieve organization ID](~/dataminer/images/Retrieve_Organization_ID.gif)

## Storage as a Service (STaaS)

### For STaaS, Cassandra and ElasticSearch/OpenSearch are no longer mentioned, so what do you mean with 'storage'?

STaaS is a service, which means you do not need to worry about how data are stored, and you do not need to configure anything for this yourself. The underlying technology is Azure Cosmos DB, a high-performance cloud-native data storage solution from Microsoft.

### What about resiliency?

Our solution separately replicates your storage account synchronously across three Azure availability zones (i.e. a group of data centers in a region, close enough to have a low-latency of < 2ms) in the primary region. Each availability zone is a separate physical location in one region with independent power, cooling, and networking, which means you are protected against server, rack, or driver failures and against physical disasters (such as fire or flooding) within the data center.

See also [Data location and redundancy](xref:STaaS_features#data-location-and-redundancy).

### How fast does data get stored in the cloud database (with our default config)?

The speed is similar as for an on-premises DataMiner System with Cassandra. A throttling mechanism has been configured as a safety mechanism.

### For how long is the data stored in the cloud database?

The same configuration settings are used as when you have an on-premises DataMiner System, based on the 'storage period' and the concurrent number of alarms.

### Can I download the data for archiving purposes?

You cannot access the data from the database directly, similar as with an on-premises DataMiner System; however, the standard data offload feature in DataMiner remains fully functional in case you need to offload data e.g. for archiving/legal purposes.

### What type of databases are used in the cloud?

Azure Cosmos DB (NOSQL, fully managed DBaaS) and Azure Table storage.

### What is the latency towards any Azure data center from within my location?

Please visit [Azure Speed Test](https://azurespeedtest.azurewebsites.net/) to measure the latency.

### What if I am in government business or located in a country with e.g. strict regulations?

There are separated Azure ecosystems, completely isolated from the commercial Azure, which are in cooperation with a local/in-country data center service provider that has pretty much the full Azure stack available, allowing Skyline Communications to deploy everything over there in a separate URL if necessary.

### Where does MS Azure have active data centers deployed?

Please visit [Azure Geographies](https://azure.microsoft.com/en-us/explore/global-infrastructure/geographies/#overview) for detailed information.

### What is the cost for the traffic billed by Azure?

No additional cost is applicable. Our STaaS offering includes both the storage and upload/download Azure traffic costs.

### How is the data migrated from an on-premises database to the Azure Cloud Stack?

We support auto live-migration of the data from a Cassandra cluster, a Cassandra single node, as well as from Elasticsearch. MySQL is not automatically supported and needs manual interaction.

For detailed information on migration limitations, see [Limitations](xref:STaaS_features#limitations)

### What is the TCO of on-premises versus cloud storage?

While it is very difficult to assess, and this can also be different depending on the region, as a rule of thumb you could say a server with an initial cost of €10k purchase price has an overall TCO of €5k over its lifespan of 5 years.

### CapEx vs. OpEx?

CapEx investments depreciate over the useful life of the asset whereas cloud server expenses are considered as operational expenses that are deducted from costs supporting day-to-day operations. From an accounting point of view, these are funds that are used at the end of the accounting period, or within the year they are purchased, meaning they can be deducted in full from taxes the year they are incurred. CapEx are depreciated, meaning they are deducted over their expected useful life (e.g. an asset purchased for $10,000, for example, might depreciate by $2000 a year, over an expected five years of use).

With OpEx purchases, such as cloud storage, you only need to pay for items you use. You can scale up or scale down as defined by your actual needs, rather than trying to predict how much capacity you will need in the distant future. This enables more cash at hand and creates a predictable recurring cost structure that aligns with your net income. Also, it is important to understand that capital expenditures typically have to go through several management approvals before they can be purchased. Operational expenditures, on the other hand, can typically be procured as long as they are considered within the operating expense budget.

### Is my on-premises data center more secure?

No. Looking at the volatile infrastructure and hardware costs nowadays, the quickly evolving technology, and the frequent cybersecurity threats, there is a real likelihood that your on-premises data center is not able to keep up with the security level of Microsoft, with its team of +3,500 globally distributed cybersecurity experts.

### What is the ROI of cloud storage vs. on-premises storage?

See [DataMiner STaaS: a game changer](https://community.dataminer.services/storage-as-a-service/).

### Can I subscribe to DataMiner, including STaaS, using my own Microsoft Azure Marketplace credit balance?

Yes, you can subscribe directly through the Azure Marketplace. If interested, please get in touch with your [sales representative](https://community.dataminer.services/get-in-touch/sales-team/).

## Features

### How does sharing work?

Users can share a dashboard by clicking *Share* or *Start sharing* at the top of the dashboard. For more details, see [Sharing a dashboard](xref:Sharing_a_dashboard).

The sharing recipients will receive a link via email on the email address specified by the share creator. When they open the link, the recipients will be asked to authenticate as the rightful owner of the email address by logging in to an account from dataminer.services, Microsoft, Google, LinkedIn, or Amazon linked to that email address, or by creating a dedicated dataminer.services account if they do not have any of the formerly mentioned accounts. After successfully authenticating, the recipient will be directed to the dashboard through the dataminer.services tunnel.

The share can be deleted in the same way as it was created. All emailed links will then automatically become unreachable.

## Security

### Is the connection towards dataminer.services secure?

Yes, all communication from and towards dataminer.services happens over HTTPS and WSS, both using TLS 1.2.

### Do I need to allow inbound traffic towards my DMS?

No, only outbound HTTPS traffic needs to be allowed. When a DataMiner Agent is connected to dataminer.services, the Cloud Gateway will send an HTTPS request to dataminer.services with the request to upgrade to a WebSocket. This WebSocket allows bidirectional communication without the need to open up the firewall for inbound traffic.

> [!TIP]
> For more details, see [Cloud connectivity and security](xref:Cloud_connectivity_and_security).

### Will my data be stored in the cloud?

Unless you use Storage as a Service, all data that is collected and processed by your DataMiner System remains stored in your self-managed databases. Some configuration and analytics data is offloaded or stored in the cloud.

For an exact overview of which data is stored in the cloud, see [Cloud data storage policies](xref:Cloud_data_storage_policies).
