---
uid: Generic_Penalty_Box_Overview
---

# Generic Penalty Box

Generic Penalty Box is a live-updating single-page display for DataMiner. It surfaces every element of a chosen protocol that currently carries an active alarm and renders each one as a card, sorted by severity. Cards refresh in real time over a WebSocket push (with automatic polling as a fallback), and the entire layout, including titles, fields, groupings, thresholds, and branding, is controlled by a single [*config.json*](xref:Generic_Penalty_Box_Configuration) file that can be edited after deployment without rebuilding the app.

The app is **read-only**: it has no acknowledge, clear, set, or control affordances anywhere. It only reads alarms, parameters, and element properties from DataMiner. You do have the option to open the element in the DataMiner Monitoring App to make any necessary sets on there. 

> [!WARNING]
> After deploying the Generic Penalty Box solution, you must edit [*config.json*](xref:Generic_Penalty_Box_Configuration) to match your environment before the app can be used. See [Installing the Generic Penalty Box](xref:Generic_Penalty_Box_Installation).

![Generic Penalty Box wall](~/solutions/images/Generic_Penalty_Box_No_Grouping.png)
