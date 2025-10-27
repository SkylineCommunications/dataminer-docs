---
uid: DashboardStateTimeline
---

# State timeline

This component visualizes the alarm state changes over time of a parameter, element or service. By default, it shows a timeline for the last 24 hours, but a time range can be added as data to set the component to a different time range.

![State timeline](~/dataminer/images/State_Timeline.png)<br>*State timeline component in DataMiner 10.4.6*

To configure the component:

1. Apply element, service, or protocol/element parameter data.

1. Add a filter if necessary:

   - If the component uses protocol parameter data, add an element filter.

   - If the component uses table or column parameter data, add an index filter.

1. Optionally, add a time range component and configure the state timeline component to use it as a filter.
