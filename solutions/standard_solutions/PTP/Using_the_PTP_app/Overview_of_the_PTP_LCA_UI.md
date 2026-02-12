---
uid: Overview_of_the_PTP_LCA_UI
---

# The PTP low-code app

From PTP version 1.2.0 onwards, a DataMiner low-code app is available with the following pages:

- [The Summary page](#the-summary-page)
- [The Nodes page](#the-nodes-page)
- [The Topology Page](#the-topology-page)
- [The Admin page](#the-admin-page)

## The Summary page

This page shows a list of configured PTP Domains and a summary of the selected domain. The first domain is selected by default.

- The list in the top-right corner shows all the configured PTP domains in the PTP Solution with the amount of configured clocks per domain. The selected domain is highlighted. All the other data in the app will be related to this selected domain.

- From left to right, the total number of grandmaster, boundary clock, transparent clock, and slave clocks in the selected PTP domain are shown. The filter icon in each box is indicating if there are any active alarms for the respective clock type. When clicking the filter icon, the alarm list below will be filtered to the specific clock type.

- The total amount of alarms in the PTP domain per severity. When clicking the circles, the alarm list below will be filtered to the specific severity.

- The alarm list will show all alarms of the selected PTP domain. By default only PTP-related alarms are shown, this can be switched to show all alarms of the equipment included in the PTP domain.
 From the context menu next to the element name, the monitoring app and a details panel for the specific element can be opened.

- At the bottom of the page, general parameters of the detected active grandmaster are shown.

  ![Summary page](~/solutions/images/PTP_Summary.png)

## The Nodes page

This page lists all PTP nodes in the domain, grouped by PTP role, with icons showing the element alarm state for each node. From the context menu next to the element name, the monitoring app and a details panel for the specific element can be opened.

At the top-right, there is an option to only show the nodes with active alarms. These states are updated in real-time, there is no need to refresh the page.

The tabs on this page allow for easy comparison between multiple nodes of the same clock type.

  ![Nodes page](~/solutions/images/PTP_Nodes.png)

## The Topology page

This page shows a graphical overview of how the different PTP nodes are connected, using DataMiner DCF. For each node, an icon is displayed indicating the type of node. For more information on these icons, see [Types of PTP devices](xref:Types_of_PTP_devices). Note that for the grandmaster clocks, the current active grandmaster (as detected by the PTP probe) is indicated by a small star icon on the top-right.

By default, the color of the nodes is indicating the PTP state, this can be changed to the overall element state by hovering over a node, clicking the 'configure color' circle in the top-right and selecting the Element State instead of the PTP state. Note that this change needs to be done for every clock type seperatly.

In the bottom right corner, there is the option to hide all the slave clocks.

To change the position of the nodes, click and drag a node to the desired position. Multiple nodes can be selected by holding the Ctrl key.

> [!NOTE]
> When upgrading the PTP solution to version 1.2.0 or later, the positions used in the Visio Topology will be copied over to the positions for the Low-Code APP. After this upgrade, the positions are not synced in any way.

  ![Topology page](~/solutions/images/PTP_Topology.png)

## The Admin page

 This page shows all the configured PTP domains. You can add more domains using the *Add Domain* button.

Two action buttons are available in the table for each domain:

- **Setup**: Launches the setup wizard again, allowing you to reconfigure the PTP domain.

  > [!TIP]
  > See also: [Installing the DataMiner PTP app](xref:Installing_the_DataMiner_PTP_app)

- **Asign Roles**: Launches the role assignment wizard, allowing you to change the roles that were assigned to the different PTP devices, or to assign roles to newly added devices.
