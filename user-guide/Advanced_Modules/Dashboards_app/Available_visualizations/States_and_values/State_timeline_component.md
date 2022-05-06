---
uid: DashboardStateTimeline
---

# State timeline

This component visualizes the alarm state changes over time of a parameter, element or service. By default, it shows a timeline for the last 24 hours, but a time range feed can be added to set the component to a different time range. Available from DataMiner 10.1.0/10.0.10 onwards.

To configure the component:

1. Apply an element, service, or protocol/element parameter data feed.

1. Add a filter if necessary:

   - If the component uses a protocol parameter data feed, add an element filter feed.

   - If the component uses a table or column parameter data feed, add an index filter feed.

1. Optionally, add a *Time range* component and configure the state timeline component to use it as a filter feed.
