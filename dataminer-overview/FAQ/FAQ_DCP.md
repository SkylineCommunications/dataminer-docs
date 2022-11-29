---
uid: FAQ_DCP
---

# Questions related to the DataMiner cloud Platform

### How is security handled by the Cloud Platform Services?

See [Cloud connectivity and security](xref:Cloud_connectivity_and_security).

### What are the prerequisites to connect a DMS to the cloud?

These prerequisites are listed in the [first step of the procedure to connect a DMS to the cloud](xref:Connecting_your_DataMiner_System_to_the_cloud).

### How do I connect a DMS to the cloud?

See [Connecting your DataMiner System to the cloud](xref:Connecting_your_DataMiner_System_to_the_cloud).

### Do all Agents in a DMS have to be connected to the cloud?

No, this is only required for a single Agent within a private DataMiner System. However, there are a couple of advantages to connecting more than one Agent:

- **Redundancy**: The Cloud Gateway nodes run independently from each other. Each one of them will maintain a tunnel connection to the DataMiner Cloud Platform. This means that when the connection is lost for one DMA, you will still be cloud-connected through the other Cloud Gateway nodes.

- **Load balancing**: Every time you open a shared dashboard or relay to your DMS, a random Cloud Gateway node is chosen to process your session. This means that the opening of multiple shares is distributed over the various Cloud Gateways. As a Cloud Gateway always forwards the traffic to the same web API service, this also distributes the load across different web API services in the cluster.

> [!NOTE]
> At this time, we recommend running 1 to 3 Cloud Gateway nodes in a cluster. Running more Cloud Gateway nodes than that in a cluster would only add an unnecessary extra load on the DataMiner Cloud Platform.

### How does the live sharing work, and how is it secured?

Users can share a dashboard by clicking *Share* or *Start sharing* at the top of the dashboard. For more details, see [Sharing a dashboard](xref:Sharing_a_dashboard).

The sharing recipients will receive a link via email on the email address specified by the share creator. When they open the link, the recipients will be asked to authenticate as the rightful owner of the email address by logging in to an account from the DataMiner Cloud Platform, Microsoft, Google, LinkedIn, or Amazon linked to that email address, or by creating a dedicated DataMiner Cloud Platform account if they do not have any of the formerly mentioned accounts. After successfully authenticating, the recipient will be directed to the dashboard through the DataMiner Cloud Platform tunnel.

No data from the private DataMiner System hosting the dashboard is stored on the DataMiner Cloud Platform. The share can be deleted in the same way as it was created. All emailed links will then automatically become unreachable.
