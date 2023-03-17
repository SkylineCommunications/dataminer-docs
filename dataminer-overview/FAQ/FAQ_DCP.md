---
uid: FAQ_DCP
---

# Questions related to dataminer.services

### How is security handled by dataminer.services?

See [Cloud connectivity and security](xref:Cloud_connectivity_and_security).

### How do I connect a DMS to dataminer.services? What are the prerequisites?

See [Connecting your DataMiner System to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

### Do all Agents in a DMS have to be connected to dataminer.services?

No, this is only required for a single Agent within a private DataMiner System. However, there are a couple of advantages to connecting more than one Agent:

- **Redundancy**: The Cloud Gateway nodes run independently from each other. Each one of them will maintain a tunnel connection to dataminer.services. This means that when the connection is lost for one DMA, you will still be connected through the other Cloud Gateway nodes.

- **Load balancing**: Every time you open a shared dashboard or relay to your DMS, a random Cloud Gateway node is chosen to process your session. This means that the opening of multiple shares is distributed over the various Cloud Gateways. As a Cloud Gateway always forwards the traffic to the same web API service, this also distributes the load across different web API services in the cluster.

  > [!NOTE]
  > At this time, we recommend running 1 to 3 Cloud Gateway nodes in a cluster. Running more Cloud Gateway nodes than that in a cluster would only add an unnecessary extra load on dataminer.services.

- **Streamlined support services**: The [Support Assistant module](xref:DataMinerExtensionModules#supportassistant) needs to be installed on all DataMiner Agents to allow our Tech Support team to [remotely collect logs](https://docs.dataminer.services/user-guide/Troubleshooting/RemoteLogCollection.html) and to carry out other automated support actions, which definitely speeds up the support process. Even though not all DMAs have to be cloud-connected for this, they do all need to have this DxM installed.

### How does the live sharing work, and how is it secured?

Users can share a dashboard by clicking *Share* or *Start sharing* at the top of the dashboard. For more details, see [Sharing a dashboard](xref:Sharing_a_dashboard).

The sharing recipients will receive a link via email on the email address specified by the share creator. When they open the link, the recipients will be asked to authenticate as the rightful owner of the email address by logging in to an account from dataminer.services, Microsoft, Google, LinkedIn, or Amazon linked to that email address, or by creating a dedicated dataminer.services account if they do not have any of the formerly mentioned accounts. After successfully authenticating, the recipient will be directed to the dashboard through the dataminer.services tunnel.

No data from the private DataMiner System hosting the dashboard is stored on dataminer.services. The share can be deleted in the same way as it was created. All emailed links will then automatically become unreachable.
