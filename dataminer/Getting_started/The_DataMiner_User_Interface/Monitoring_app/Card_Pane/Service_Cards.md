---
uid: Service_Cards
description: "Explore service cards in the Monitoring app, including visual pages, child elements and services, alarms, notes, and direct navigation URLs."
---

# Service cards

On the left side of a service card, a collapsible card navigation pane provides access to the pages of the card. You can resize this pane by dragging its right edge.

The following pages are available:

- *Visual*: One or more pages with a Visio-based visual overview of the service.

- *Children*: Contains the data pages of the elements contained within the service. If the service contains a child service, this is also listed under *Children* in the navigation pane, but clicking or tapping the child service will open the card of this child service.

- *Alarms*: Displays the active alarms for the service.

- *Reports*: Deprecated. Displays reports related to the service in the [legacy Reporter module](xref:reporter).

  > [!NOTE]
  > This page is no longer available from DataMiner 10.7.0/10.7.1 onwards.<!-- RN 47135+47136 --> Prior to this, starting from DataMiner 10.4.0/10.4.1, the legacy Reports module is already disabled by default, but it can still be enabled if necessary using the [*LegacyReportsAndDashboards* soft-launch option](xref:Overview_of_Soft_Launch_Options#legacyreportsanddashboards).<!-- RN 37786 -->

- *Notes*: Allows you to add and view notes for the service.

Service cards can be opened from the navigation or recent items pane, or from the search. In addition, you can also navigate directly to a service using the following URL: <br>*http(s)://*\<DMA IP>*/monitoring/service/*\<DMA ID>*/*\<service ID>*/*\<service page>

The service page in this URL is optional; if it is not specified, the default page is displayed.

- To go to a visual page, specify *visual/*\<service page>.
<br>For example: *http://*\<DMA IP>*/monitoring/service/67/511/visual/0*

- To go to the page of one of the service children, specify *child/*\<page name>. The page name consists of the DMA ID, the element ID and the page name, separated by %2F.<br>For example: *http://*\<DMA IP>*/monitoring/service/67/511/child/67%2F509%2FPerformance*
