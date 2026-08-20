---
uid: Generic_Penalty_Box_Overview
---

# Generic Penalty Box

A **penalty box** is an exception-only monitoring view used in broadcast Master Control Rooms (MCR) and IT/Network Operations Centers (NOC). Unlike a dashboard that shows the full inventory of monitored items, a penalty box shows **only the items currently in an error, degraded, or alarm state**, and keeps them visible until the issue is acknowledged or resolved.

Generic Penalty Box is a DataMiner application that puts a live wall display of active alarms in front of your team. It watches every element of the protocol you choose and shows only the ones currently in alarm, presented as easy-to-scan cards ordered by severity so the most urgent issues stand out first. The wall updates itself automatically as alarms change, and the entire look and feel, including what's shown, how it's organized, and how it's branded, can be adjusted after deployment without rebuilding the app.

> [!WARNING]
> After deploying the Generic Penalty Box solution, you must edit [*config.json*](xref:Generic_Penalty_Box_Configuration) to match your environment before the app can be used. See [Installing the Generic Penalty Box](xref:Generic_Penalty_Box_Installation).

![Generic Penalty Box wall](~/solutions/images/Generic_Penalty_Box_No_Grouping.png)
