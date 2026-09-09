---
uid: Overview_of_the_PTP_custom_app
description: Explore the PTP custom web app to monitor PTP domains, compare node BMCA settings, inspect network topology, and manage domains and roles.
---

# The PTP custom app

> [!NOTE]
> The PTP custom app is available from PTP version 2.0.0 onwards. You can access it in any modern web browser at `/public/ptp/`.

The PTP custom web application (*PTP Monitor*) provides real-time visibility and configuration management for your Precision Time Protocol (PTP) infrastructure. It is designed to monitor synchronization health across multiple domains, compare node configurations, inspect live network topology, and manage domain setups directly from the browser.

The app consists of the following main sections:

- [Header](#header)
- [Summary page](#summary-page)
- [Nodes page](#nodes-page)
- [Compare panel](#compare-panel)
- [Topology page](#topology-page)
- [Admin page](#admin-page)

## Header

The header bar is permanently displayed at the top of the interface and contains global controls:

- **DataMiner logo**: Navigates back to the default overview page.
- **Domain selector**: A dropdown list that allows you to switch between configured PTP domains (such as *Media* or *Default*). All data, metrics, and topology views across the app immediately update to reflect the selected domain.
- **Theme toggle**: Switches the user interface between light and dark visual themes.
- **User sign-out**: Allows you to sign out of the current DataMiner user session.

## Summary page

The *Summary* page delivers an operational overview of the selected PTP domain, highlighting overall health, clock distribution, active alarms, and grandmaster performance.

![Summary page in the PTP custom app](~/solutions/images/PTP_2.0_Summary.png)

This page contains the following key components:

- **Domain summary KPIs**: Displays the total count of PTP devices in the domain, categorized by clock role:
  - *Grandmasters*
  - *Boundary Clocks*
  - *Transparent Clocks*
  - *Follower Clocks*

  Clicking a KPI card opens the *Nodes* page with the corresponding role filter applied.

- **Active alarms table**: Lists all current active alarms in the selected PTP domain in real time. It features:
  - Free-text search to quickly find alarms by element name or description.
  - A toggle to filter between showing only PTP-specific alarms or all alarms from the equipment in the domain.
  - Severity badges (*Critical*, *Major*, *Minor*, and *Warning*).
  - Actions to inspect devices: clicking an element name opens the device in the DataMiner Monitoring app, while clicking anywhere else on the row opens the slide-out device details panel.

- **Active Grandmaster card**: Displays vital statistics of the detected active grandmaster clock in the domain:
  - Clock identity and lock status.
  - Number of synchronized nodes.
  - Best Master Clock Algorithm (BMCA) parameters, including Priority 1, Priority 2, Clock Class, Clock Accuracy, and Clock Variance.
  - Configured message rates for Announce, Sync, and Delay Request messages.

- **PTP Probe card**: Shows the probe device responsible for identifying the active grandmaster in the domain. The card features real-time 1-hour trend charts for *Offset* and *Mean Path Delay*, allowing you to verify timing stability and detect jitter or offset drift.

## Nodes page

The *Nodes* page provides a searchable list of all PTP nodes in the domain, with their alarm status and configuration attributes.

![Nodes page in the PTP custom app](~/solutions/images/PTP_2.0_Nodes.png)

Key capabilities on this page include:

- **Role filter tabs**: Filter the list by device role: *All*, *Grandmaster Clocks*, *Boundary Clocks*, *Transparent Clocks*, and *Follower Clocks*.
- **Only Alarmed toggle**: Instantly filters the view to display only nodes that have active alarms.
- **Search bar**: Filter nodes by element name, alias, IP address, or clock ID.
- **Alarm state indicators**: Each node displays dual alarm indicators showing both:
  - *Element State*: The general health and alarm state of the host device.
  - *PTP State*: Alarms specific to PTP synchronization and protocol performance.
- **Node detail panel**: Clicking a node opens a slide-out panel with detailed BMCA parameters, port statuses, and sparkline trend graphs for offset and path delay.
- **Multi-selection for comparison**: Click the *Compare* button in the toolbar to display checkboxes, select two or more nodes, and click the *Compare* button at the bottom to open the *Compare* panel.

## Compare panel

The *Compare* panel enables side-by-side analysis of two or more PTP nodes, making it easy to identify configuration discrepancies or performance differences.

To open the *Compare* panel:

1. On the *Nodes* page, click the *Compare* button in the toolbar to enable selection mode.

1. Select the checkboxes of the nodes you want to compare (two or more).

1. Click the *Compare [X] nodes* button at the bottom of the page.

   The *Compare* panel will open over the page.

![Compare panel in the PTP custom app](~/solutions/images/PTP_2.0_Compare.png)

The panel includes the following features:

- **Side-by-side parameter grid**: Compares selected nodes across structured dataset groups:
  - *Clock*
  - *Default DS*
  - *Current DS*
  - *Parent DS*
  - *Grandmaster*
  - *Time Properties*
  - *Ports*
- **Automated difference highlighting**: Parameters whose values differ between compared nodes are automatically highlighted in amber, accompanied by a badge showing the total count of differences.
- **Only show differences toggle**: Filters the comparison view to display only parameters with conflicting or differing values.
- **Performance sparklines**: Embedded sparkline graphs display real-time trends for *Offset* and *Mean Path Delay*, allowing you to compare timing stability across devices.

## Topology page

The *Topology* page provides an interactive graphical map of the PTP network, visualizing the clock hierarchy and device interconnections based on either DataMiner Connectivity Framework (DCF) connections or reported parent connections.

![Topology page in the PTP custom app](~/solutions/images/PTP_2.0_Topology.png)

Key features of the topology view include:

- **Interactive node graph**: Displays interconnected devices with distinct role icons:
  - *Active Grandmaster* (indicated with an active badge)
  - *Grandmaster* (GM)
  - *Boundary Clock* (BC)
  - *Transparent Clock* (TC)
  - *Follower Clock* (Follower)
- **Connection source toggle**: Switch between two connection visualization modes:
  - *DCF*: Displays connections defined through the DataMiner Connectivity Framework (DCF).
  - *Parent Clock*: Displays the reported parent connections, showing the active synchronization tree reported by each node's parent dataset.
- **State color coding**: Toggle between *Element State* and *PTP State* color coding to inspect either general device availability or clock synchronization health across the network.
- **Show Followers toggle**: Allows you to collapse or show follower devices to simplify view navigation on large networks and focus on the clock distribution spine.
- **Edit Layout mode**: Allows you to reposition nodes on the canvas using drag-and-drop. Custom node positions are automatically saved per domain.

## Admin page

The *Admin* page centralizes domain administration and role assignments within the PTP solution:

- **Domain management table**: Lists all configured PTP domains with their name, element ID, and available actions (such as assigning roles, renaming, or deleting the domain).
- **Add Domain modal**: A setup wizard to define a new PTP domain and assign initial devices and views (only elements supported by the solution are listed). The assigned view is used to place the domain element and service; users accessing the app must have read permissions for this view and its elements. If no domains exist yet (such as during first-time onboarding), this wizard is automatically presented as an onboarding overlay.
- **Assign Roles modal**: A configuration wizard to change device roles (*Grandmaster*, *Boundary Clock*, *Transparent Clock*, or *Follower Clock*), designate preferred grandmasters, and assign the PTP probe. Default roles are automatically preselected based on the connector of each element.
- **Rename Domain modal**: Allows you to rename an existing PTP domain.
- **Delete Domain modal**: Enables safe removal of a domain with automatic deletion of associated domain elements and services, and a prompt to clean up corresponding DataMiner views. This does not touch the device elements in any way.
