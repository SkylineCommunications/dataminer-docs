---
uid: Generic_Penalty_Box_Usage
description: "Learn how to use the Generic Penalty Box app to track alarms in real time, filter them, group them, and view detailed insights."
---

# Using the Generic Penalty Box

## Overview of the app components

![Overview of the Generic Penalty Box UI, with numbers indicating specific sections](~/solutions/images/Generic_Penalty_Box_UI_Components.png)

The app consists of the following main components:

1. [Real-time updates indicator](#real-time-updates-indicator) and [theme selector](#theme-selector).
1. Toolbar with, from left to right, an indicator of the total number of items in alarm, a [severity filter](#severity-filter), [timeout visibility](#timeout-visibility-setting) checkbox, and [grouping selection box](#grouping-selection-box).
1. Cards showing the items currently in an error, degraded, or alarm state. Clicking a card shows a [detail view](#detail-view). Depending on the configuration, cards can have an [external monitoring link](#external-monitoring-link).

### Real-time updates indicator

The *Live*/*Offline* indicator in the header indicates whether the app currently shows real-time information.

Real-time updates are available when [realtime.enabled](xref:Generic_Penalty_Box_Configuration#realtime) is set to `true` in the *config.json* configuration. In this case, the app opens one WebSocket session per monitored element using the *Generic Parameter Webhook* GQI data source. Parameter value changes arrive within seconds and update card fields immediately, without waiting for the next polling cycle. A separate alarm page subscription updates severity and alarm counts. On a WebSocket disconnect, the app reconnects automatically after the configured `reconnectMs` interval.

### Theme selector

The theme button in the upper-right corner cycles through the options *Dark*, *Light*, and *System*. When you select an option, your choice is remembered per browser.

![Generic Penalty Box app in light mode](~/solutions/images/Generic_Penalty_Box_Light_Mode.png)

### Severity filter

The *Min severity* dropdown box allows you to select the minimum severity level for which cards are shown. Any cards below the selected severity level will be hidden.

For example, selecting *Major* removes all warning-only cards, so that the wall only shows the most important problems.

This filter is runtime-only and resets to the configured default ([defaults.minSeverity](xref:Generic_Penalty_Box_Configuration#defaults) in *config.json*) when the app is loaded again.

![Generic Penalty Box app with the severity dropdown list expanded, showing the different severities you can select](~/solutions/images/Generic_Penalty_Box_Severity_Dropdown.png)

### Timeout visibility setting

The *Show elements in timeout* checkbox in the toolbar reveals elements that are in a communications timeout state.

Elements in timeout are hidden by default because their alarm data is stale. Showing them allows you to monitor how many elements are currently unreachable.

### Grouping selection box

In the upper-right corner of the app UI, you can find the *Grouping* dropdown box. You can use this to switch between the different modes defined for the app (using the [groupingOptions](xref:Generic_Penalty_Box_Configuration#groupingoptions) in the configuration file):

- **Tier-based**: elements are placed into named buckets by matching their value against the configured tiers. Groups appear in the same order the tiers are listed (the first one listed shows first). Elements that match no tier collect in an "Uncategorized" bucket.
- **Dynamic**: groups form automatically from the distinct values that exist in live data. This is useful for properties like *region* or *location*, where the set of values is not fixed in advance. New values appear as new group headers automatically.
- **No grouping**: a flat grid sorted by severity and alarm recency.

The active grouping is remembered per browser.

![Generic Penalty Box app with "No grouping" selected, showing a flat list](~/solutions/images/Generic_Penalty_Box_No_Grouping.png)

![Generic Penalty Box app with cards grouped by service tier](~/solutions/images/Generic_Penalty_Box_Grouped_By_Tier.png)

![Generic Penalty Box app with cards grouped by region](~/solutions/images/Generic_Penalty_Box_Grouped_By_Region.png)

### Detail view

Click any card to open the detail overlay. It consists of the following components:

- **Header**: Shows a severity indicator, the element name, and a criticality tier label.
- **Config-driven panels**: These panels can show different information depending on the [detailPanels](xref:Generic_Penalty_Box_Configuration#detailpanels) configuration in *config.json*.
- **Active alarms**: A full list of all relevant alarms, showing severity, parameter name, display value, and timestamp.
- **Properties**: The custom properties of the DataMiner element, as configured in [elementProperties](xref:Generic_Penalty_Box_Configuration#elementproperties) in *config.json*.
- **Monitoring link**: See [External monitoring link](#external-monitoring-link).

![Generic Penalty Box app with detail overlay opened](~/solutions/images/Generic_Penalty_Box_Detail_View.png)

### External monitoring link

When enabled in the *config.json* configuration (i.e., [monitoring.enabled](xref:Generic_Penalty_Box_Configuration#monitoring) is set to `true`), an external monitoring link icon is shown on each card, and a *View in Monitoring* button is available at the bottom of the detail overlay.

Both links open the element in the DataMiner Monitoring app in a new browser tab, using the URL pattern defined in *config.json* (using `monitoring.urlTemplate`).

Below you can see what a card looks like when this setting is disabled or enabled:

| Link disabled | Link enabled |
|--|--|
| ![Card with monitoring link disabled](~/solutions/images/Generic_Penalty_Box_Monitoring_Link_Card_Off.png) | ![Card with monitoring link enabled](~/solutions/images/Generic_Penalty_Box_Monitoring_Link_Card_On.png) |

If the setting is enabled, a blue button is shown at the bottom of the detail overlay:

![Detail overlay with monitoring link enabled](~/solutions/images/Generic_Penalty_Box_Monitoring_Link_Detail_On.png)

## Mobile and responsive layout

The wall adapts to the available viewport without a separate mobile build:

- Cards fill the viewport in as many columns as fit at the configured [layout.minCardPx](xref:Generic_Penalty_Box_Configuration#layout) width.
- If a field is listed earlier in the [cardFields](xref:Generic_Penalty_Box_Configuration#cardfields) configuration in *config.json*, it is hidden first as cards narrow below `layout.minLegibleCardPx`.
- Fields that have been pinned (with `"pinned": true` in *config.json*) are always visible at any card size.
- The detail overlay slides in as a full-height panel on tablet viewports.

![iPad landscape layout of the Generic Penalty Box app](~/solutions/images/Generic_Penalty_Box_Mobile_Layout.png)
