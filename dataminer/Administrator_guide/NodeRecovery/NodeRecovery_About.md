---
uid: NodeRecovery_About
---

# Node Recovery

DataMiner Node Recovery makes use of the [DataMiner Swarming](xref:Swarming) feature to offer a way to monitor and act upon node outages in the DataMiner System.

Node Recovery will [detect outages](xref:NodeRecovery_Detection), causing the [state of nodes](xref:NodeRecovery_States) to change, which can in turn [trigger scripts](xref:NodeRecovery_Triggers) that deal with the outage.

You could for example configure a script so that when one or more nodes go down, elements that were hosted on these nodes get redistributed to other nodes, or you could have a backup element take over from an element representing an important device when the node hosting that element goes down.
