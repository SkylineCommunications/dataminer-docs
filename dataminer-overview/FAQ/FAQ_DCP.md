---
uid: FAQ_DCP
---

# Questions related to dataminer.services

## Getting started

### What is dataminer.services?

dataminer.services is a cloud based extension of your DataMiner system. Connecting your DataMiner system to dataminer.services allows you to augment it with several featueres which are not available otherwise:

- [Storage as a Service](xref:STaaS)
- [Remote access](xref:Cloud_Remote_Access) to the web pages.
- [Live Sharing](xref:Sharing) of dashboards.
- Connector deployments from the [Catalog](xref:About_the_Catalog_module)
- [ChatOps](xref:ChatOps)
- [Streamlined support services](xref:RemoteLogCollection)
- ...

### How do I connect my DataMiner system to dataminer.services?

Connecting your DataMiner system to dataminer.services can be done very simply by installing the [DataMiner Cloud Pack](https://community.dataminer.services/dataminer-cloud-pack/) on one or more of your DataMiner agents. After doing so, you still have to set up the connection by going to *System center > Cloud* within cube and clicking on the *Connect* button on that page. More details on how to connect your DataMiner system to dataminer.services can be found [here](xref:Connecting_your_DataMiner_System_to_the_cloud)

### Do all agents in a DMS have to be connected to dataminer.services?

No, You will have full access to all dataminer.services features even with only a single connected agent. However, there are a couple of advantages to connecting more than one Agent:

- **Redundancy**: The Cloud Gateway nodes work independently from eachother, which means that, as long as one Cloud Gateway node can maintain it's connection towards dataminer.services, your DataMiner system will remain cloud connected.
- **Load balancing**: Having multiple agents connected to dataminer.services allows dataminer.services to spread incomming requests accross multiple agents. For example, when multiple shared dasboards are accessed simultaniously, the load will be spread accross the connected agents.
- **Streamlined support services**: Even though not all agents need to be cloud-connected for this, the [Support Assistant module](xref:DataMinerExtensionModules#supportassistant) needs to be installed on all DataMiner Agents to allow our Tech Support team to carry out automated support actions.

  > [!NOTE]
  > At this time, we recommend running 1 to 3 Cloud Gateway nodes in a cluster. Running more Cloud Gateway nodes than that in a cluster would only add an unnecessary extra load on dataminer.services.

## dataminer.services features

### How does the live sharing work?

Users can share a dashboard by clicking *Share* or *Start sharing* at the top of the dashboard. For more details, see [Sharing a dashboard](xref:Sharing_a_dashboard).

The sharing recipients will receive a link via email on the email address specified by the share creator. When they open the link, the recipients will be asked to authenticate as the rightful owner of the email address by logging in to an account from dataminer.services, Microsoft, Google, LinkedIn, or Amazon linked to that email address, or by creating a dedicated dataminer.services account if they do not have any of the formerly mentioned accounts. After successfully authenticating, the recipient will be directed to the dashboard through the dataminer.services tunnel.

The share can be deleted in the same way as it was created. All emailed links will then automatically become unreachable.

## Security

### Is the connection towards dataminer.services secure?

Yes, all communication from and towards dataminer.services happens over HTTPS and WSS, both using TLS 1.2.

### Do I need to allow inbound traffic towards my DMS?

No, only outbound https traffic needs to be allowed. When connecting a DataMiner agent to dataminer.services, the Cloud Gateway will set send an https request to dataminer.services with the request to upgrade to a websocket. This websocket allows for bidirectional communication without the need to open up the firewall for inbound traffic. For more details, see [Cloud connectivity and security](xref:Cloud_connectivity_and_security).

### Will my data be stored in the cloud?

Unless you use Storage as a Service, all data that is collected and processed by your DataMiner system remains stored in your on-prem databases. Some configuration and analytics data is ofloaded or stored in the cloud. An exact overview of which data that is stored in the cloud can be found [here](xref:Cloud_data_storage_policies).
