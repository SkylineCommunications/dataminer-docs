---
uid: Overview_MediaOps_Flow_Monitoring
---

# Flow Monitoring app

The Flow Monitoring app can be used by engineers and operators to visualize flow paths throughout the network, for troubleshooting or other purposes. The application tracks two paths for every flow:

- **As-engineered path**: This the result of the path calculation done by [Flow Engineering](xref:Overview_MediaOps_Flow_Engineering) during the setup of a connection. It therefore represents the expected path of a flow throughout the network.
- **As-is path**: This shows the actual current path of a flow, based on the monitoring data reported by the elements in the DataMiner System. In order for this to work, the connectors of the elements in the flow path must be integrated with dataminer.MediaOps. For a list of the currently integrated connectors, see [Supported connectors for MediaOps](xref:Overview_MediaOps_supported_connectors).

These paths can be visualized in different views:

- By **source**: For a virtual signal group source, this view shows the flows starting from the source to all destinations connected to it.
- By **destination**: For a virtual signal groups source, this view shows the path of the flows received by this destination.
- By **multicast IP** (for as-is paths only): This view allows users to quickly search for a multicast IP address and see its path across devices reporting this multicast address.

![Flow Monitoring app UI](~/dataminer-overview/images/flowmonitoring_1.png)
