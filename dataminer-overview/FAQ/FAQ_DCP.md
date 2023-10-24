---
uid: FAQ_DCP
---

# Questions related to dataminer.services

## Getting started

### What is dataminer.services?

dataminer.services is a cloud-based extension of the DataMiner System. Connecting your DataMiner System to dataminer.services allows you to augment it with several features that are otherwise not available:

- [Storage as a Service](xref:STaaS)
- [Remote access](xref:Cloud_Remote_Access) to the web pages.
- [Live sharing](xref:Sharing) of dashboards.
- Connector deployments from the [Catalog](xref:About_the_Catalog_module)
- [ChatOps](xref:ChatOps)
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
- **Streamlined support services**: Even though not all Agents need to be connected to dataminer.services for this, the [Support Assistant module](xref:DataMinerExtensionModules#supportassistant) needs to be installed on all DataMiner Agents to allow our tech support team to carry out [automated support actions](xref:CCA_Support_Services).

  > [!NOTE]
  > At this time, we recommend running 1 to 3 Cloud Gateway nodes in a cluster. Running more Cloud Gateway nodes than that in a cluster would only add an unnecessary extra load on dataminer.services.

## Features

### How does live sharing work?

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

Unless you use Storage as a Service, all data that is collected and processed by your DataMiner System remains stored in your self-hosted databases. Some configuration and analytics data is offloaded or stored in the cloud.

For an exact overview of which data is stored in the cloud, see [Cloud data storage policies](xref:Cloud_data_storage_policies).
