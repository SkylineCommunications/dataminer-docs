---
uid: NodeRecovery_About
---

# NodeRecovery

DataMiner NodeRecovery offers a way to monitor and act upon node outages in the DataMiner System.

- When one or more nodes go down, you might want to redistribute elements previously hosted on these agents.
- When a certain node hosting an important device goes down, a backup node can take over this element.

> [!IMPORTANT]
> The NodeRecovery functionality requires Swarming to be enabled on the cluster.

More information is available on a number of topics:

- [Installing](xref:NodeRecovery_Installing)
- [Outage detection](xref:NodeRecovery_Detection)
- [Node states](xref:NodeRecovery_States)
- [Settings](xref:NodeRecovery_Settings)
- [Triggering on node state changes](xref:NodeRecovery_Triggers)
- [API](xref:NodeRecovery_API)
- [Troubleshooting](xref:NodeRecovery_Troubleshooting)
- [Frequently asked questions](xref:NodeRecovery_FAQ)

## Upcoming features

We are working to add the following functionality soon:

- A default rebalance action when nodes go down
- Detection of other forms of outages (e.g., DataMiner software not running while server is still up)
