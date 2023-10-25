---
uid: DataMinerProbes
---

# DataMiner Probes

A DataMiner Probe (DMP) is a DataMiner Agent with limited capabilities. DMPs typically, but not necessarily, run on small-form-factor compute instances in remote and unmanned locations where communication channels often have capacity constraints and/or intermittent availability.

DMPs can support a multitude of applications and are typically installed in e.g. remote VSAT terminals, satellite hubs, terrestrial transmitter sites, small network nodes, cellular network base centers, etc.

> [!TIP]
> See also: [Adding a DataMiner Probe](xref:Adding_a_DataMiner_Probe)

## DMP limitations

Compared to regular DataMiner Agents, DataMiner Probes have the following limitations:

- **Capacity**: DMPs only support up to 50 devices.

- **Users**: While you can add as many users as you want to a DMP, only one user at a time can access the DMP.

- **Ecosystem**: A DMP does not function as one of the DataMiner nodes in a DataMiner System. Instead it functions as a standalone gateway or proxy between its devices and the DMS. This means that you should [upgrade a DataMiner Probe](xref:upgrading_a_dataminer_probe) separately from the rest of the DMS.

- **View structure**: A DMP only has 1 single view with optional visual overview. All connected devices will be displayed within this view.

- **Historical data**: A DMP can only store up to 7 days of historical data. However, this data is typically forwarded towards the cluster, where it is stored for a longer time.
