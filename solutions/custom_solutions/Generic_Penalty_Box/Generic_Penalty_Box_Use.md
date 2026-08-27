---
uid: Generic_Penalty_Box_Usage
---

# Using the Generic Penalty Box

## Grouping

In the upper-right corner of the app UI, you can find the *Grouping* dropdown bx. You can use this to switch between the different modes defined for the app (using the [`groupingOptions`](xref:Generic_Penalty_Box_Configuration#groupingoptions) in the configuration file):

- **Tier-based**: elements are placed into named buckets by matching their value against the configured tiers. Groups appear in the same order the tiers are listed (the first one listed shows first). Elements that match no tier collect in an "Uncategorized" bucket.
- **Dynamic**: groups form automatically from the distinct values that exist in live data. This is useful for properties like *region* or *location*, where the set of values is not fixed in advance. New values appear as new group headers automatically.
- **No grouping**: a flat grid sorted by severity and alarm recency.

The active grouping is remembered per browser.

![No grouping, flat list](~/solutions/images/Generic_Penalty_Box_No_Grouping.png)

![Grouped by service tier](~/solutions/images/Generic_Penalty_Box_Grouped_By_Tier.png)

![Grouped by region](~/solutions/images/Generic_Penalty_Box_Grouped_By_Region.png)

## Detail view

Click any card to open the detail overlay:

- **Header**: severity indicator, element name, and criticality tier label.
- **Config-driven panels**: each entry from [`detailPanels`](xref:Generic_Penalty_Box_Configuration#detailpanels) rendered as a labeled key/value grid.
- **Active alarms**: a full list showing severity, parameter name, display value, and timestamp.
- **Properties**: the element's DataMiner custom properties, as configured in [`elementProperties`](xref:Generic_Penalty_Box_Configuration#elementproperties).
- **Monitoring link**: when [`monitoring.enabled`](xref:Generic_Penalty_Box_Configuration#monitoring) is `true`, a button links to DataMiner Monitoring.

![Detail overlay](~/solutions/images/Generic_Penalty_Box_Detail_View.png)

## Real-time push

When [`realtime.enabled`](xref:Generic_Penalty_Box_Configuration#realtime) is `true`, the app opens one WebSocket session per monitored element using the *Generic Parameter Webhook* GQI data source. Parameter value changes arrive within seconds and update card fields immediately, without waiting for the next poll. A separate alarm-page subscription updates severity and alarm counts.

On a WebSocket disconnect, the app reconnects automatically after the configured `reconnectMs` interval. The *Live*/*Offline* indicator in the header reflects the push state at all times.

## Severity filter

The *Min severity* dropdown hides units below the chosen level. For example, selecting *Major* removes all warning-only units, so the wall shows only the most important problems. This filter is runtime-only and resets to the configured [`defaults.minSeverity`](xref:Generic_Penalty_Box_Configuration#defaults) on the next load.

![Severity dropdown](~/solutions/images/Generic_Penalty_Box_Severity_Dropdown.png)

## Timeout indicator

The *Show elements in timeout* checkbox in the toolbar reveals elements that are in a communications-timeout (comms-lost) state. These are hidden by default because their alarm data is stale; showing them lets you monitor how many elements are currently unreachable.

## External monitoring link

When [`monitoring.enabled`](xref:Generic_Penalty_Box_Configuration#monitoring) is `true`, a link icon appears on each card, and a *View in Monitoring* button appears at the bottom of the detail overlay. Both open the element in DataMiner Monitoring in a new tab, using the URL pattern from `monitoring.urlTemplate`.

*monitoring.enabled: false* (default), no link on the card:

![Card with monitoring link disabled](~/solutions/images/Generic_Penalty_Box_Monitoring_Link_Card_Off.png)

*monitoring.enabled: true*, link icon shown on the card:

![Card with monitoring link enabled](~/solutions/images/Generic_Penalty_Box_Monitoring_Link_Card_On.png)

*monitoring.enabled: false*, no button in the detail overlay:

![Detail overlay with monitoring link disabled](~/solutions/images/Generic_Penalty_Box_Monitoring_Link_Detail_Off.png)

*monitoring.enabled: true*, *Open in Monitoring* button shown in the detail overlay:

![Detail overlay with monitoring link enabled](~/solutions/images/Generic_Penalty_Box_Monitoring_Link_Detail_On.png)

## Mobile and responsive layout

The wall adapts to the available viewport without a separate mobile build:

- Cards fill the viewport in as many columns as fit at the configured [`layout.minCardPx`](xref:Generic_Penalty_Box_Configuration#layout) width.
- Fields listed earlier in [`cardFields`](xref:Generic_Penalty_Box_Configuration#cardfields) are hidden first as cards narrow below `layout.minLegibleCardPx`.
- Fields marked `"pinned": true` are always visible at any card size.
- The detail overlay slides in as a full-height panel on tablet viewports.

![iPad landscape layout](~/solutions/images/Generic_Penalty_Box_Mobile_Layout.png)

## Dark, light, and system theme

The theme toggle in the top-right cycles through *Dark*, *Light*, and *System*. The choice is remembered per browser.

![Light mode](~/solutions/images/Generic_Penalty_Box_Light_Mode.png)
