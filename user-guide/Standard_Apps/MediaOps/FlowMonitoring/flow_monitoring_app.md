---
uid: flow_monitoring_app
---

# Flow Monitoring

![Screenshot of the flow monitoring app](~/user-guide/images/mediaops_fm_overview.png)

The flow monitoring app can be used by engineers and operators to visualize flow paths throughout the network, for troubleshooting or other purposes. The application tracks two paths for every flow:

* As-engineered path: this the result of the path calculation done by [flow engineering](xref:flow_engineering_app) during setup of a connection. Therefore, it represents the expected path of a flow throughout the network.
* As-is path: this shows the actual current path of a flow, based on the monitoring data reported by the elements on the DataMiner system. In order for this to work, the connectors of the elements in the flow path should be integrated with the dataminer.MediaOps solution. More information on that integration can be found [here](xref:mediaops_connectors).

These paths can be visualized in different views:

* By source: for a virtual signal group source, this view shows the flows starting from the source to all destinations connected to it.
* By destination: for a virtual signal groups source, this view shows the path of the flows received by this destination.
* By multicast IP (as-is path only): this view allows to quickly search for a multicast IP address and see its path across devices reporting this multicast address.
