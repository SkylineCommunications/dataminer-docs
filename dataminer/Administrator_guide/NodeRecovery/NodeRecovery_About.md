---
uid: NodeRecovery_About
---

# Node Recovery

DataMiner Node Recovery offers a way to monitor and act upon node outages in the DataMiner System. It will [detect outages](xref:NodeRecovery_Detection), which it will signal by means of updated [node states](xref:NodeRecovery_States). This can in turn [trigger scripts](xref:NodeRecovery_Triggers) that deal with the outages.

Using the [Swarming](xref:Swarming) feature, you could for example configure a script so that when one or more nodes go down, elements that were hosted on these nodes get redistributed to other nodes. Or, for another example, you could have a backup element take over from an element representing an important device when the node hosting that element goes down.

Via the [Node Recovery API](xref:NodeRecovery_API), you can monitor the outage information and for example show it in a [low-code app](xref:Application_framework), as illustrated below.

![Node Recovery monitored in a low-code app](~/dataminer/images/NodeRecoveryApp.png)<br>*Node Recovery information shown in a DataMiner low-code-app*
