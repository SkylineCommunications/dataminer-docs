---
uid: PTP_1.1.3
---

# PTP 1.1.3

## New features

\-

## Changes

### Enhancements

#### Support for custom alarm severity colors in alarm summary pane \[ID_31314\]

When the PTP application is run on a DataMiner System using DataMiner version 10.1.11 or higher, and custom alarm colors are defined for the different alarm severities, these custom colors will now be displayed in the alarm summary pane. On older DataMiner versions, the default severity colors will still be displayed.

#### Minimum DMA version for Standard DataMiner PTP Device connector \[ID_31342\]

A minimum DMA version is now filled in for the Standard DataMiner PTP Device connector.

#### Support added for several connectors \[ID_31971\]

The PTP app now supports the following connectors:

- Riedel Communications MediorNet MuoN (FusioN and VirtU)
- Pebble Beach Dolphin

In addition, the mediation for the Meinberg Lantime M3000 connector has been extended with the *Offset*, *P2P Mode* and *Grandmaster Clock Timescale* parameters.

#### PTP app layout improvements \[ID_32116\]

The following layout improvements have been implemented in the PTP app:

- The top sections of the *Summary* tab are now better aligned.
- The spacing between the interface name and cogwheel on the *Summary* tab has been increased to improve readability.

### Fixes

#### Grandmaster not correctly marked in Topology tab \[ID_31135\]

In some cases, it could occur that the grandmaster was not correctly marked in the *Topology* tab of the PTP app.

#### Incorrect grandmaster clock timescale value \[ID_31342\]

On the *Nodes* > *Grandmasters* tab, in the *Time Properties* pane, it could occur that the *Timescale* value was incorrect.

#### Incorrect name information on Boundary Clocks tab \[ID_32085\]

In the 1.1.2 version of PTP, the *Nodes* > *Boundary Clocks* tab could display incorrect names for parent and grandmaster clocks.

#### Cogwheel drop-down list not working on Nodes \> Grandmasters/Boundary Clocks/Analyzers tabs \[ID_32116\]

On the *Grandmasters*, *Boundary Clocks* and *Analyzers* subtabs of the *Nodes* tab, when you clicked the cogwheel icon, it could occur that it was not possible to select an element.

## Addendum CU1

### Enhancements

#### Tektronix Prism 'Lock FOM' parameter used as offset value & Bridge Technologies VB Probe Series PTP data mapped [ID_32892]

For the mediation of PTP parameters of the Tektronix Prism, the *Lock FOM* parameter will now be used as the offset value for this device type in the PTP app. This parameter represents the phase lag, which is used to correct the internal PTP clock of the PRISM to match the selected PTP grandmaster.

In addition, the PTP data for the *Bridge Technologies VB Probe Series* has now been mapped.

#### Cisco Nexus Clock IDs swapped [ID_32893]

The values for the Cisco Nexus Clock ID (Grandmaster) and ID have been swapped. The PTP app has been adjusted to take this into account.

#### Support for Seiko Time Server Pro. TS-2950 [ID_33143]

The PTP app now supports the *Seiko Time Server Pro. TS-2950* connector.

#### Support for Meinberg LANTIME IMS-HPS [ID_33552]

The PTP app now supports the *Meinberg LANTIME IMS-HPS* connector.

#### Support for Hirschmann - a Belden Brand MAR 1040 connector [ID_33562]

The PTP app now supports the *Hirschmann - a Belden Brand MAR 1040* connector.

#### Support for Mellanox Technologies MLNX-OS Manager connector [ID_34750]

The PTP app now supports the *Mellanox Technologies MLNX-OS Manager* connector.

### PTP app changes to improve performance [ID_34757]

Several changes have been implemented to the PTP app to improve performance:

- The *Node* > *Summary* tab will no longer show the alarm summaries.
- On the *Summary* tab, the automatic switching between *Settings GM* and *Nodes Summary* has been removed. Instead the nodes summary information is aggregated and displayed in the *Settings GM* section, on the right side of the corresponding tiles.

#### Transparent clock shapes no longer show alarm color [ID_34854]

On the *Nodes* > *Transparent clocks* tab of the PTP app, the transparent clocks no longer show the alarm color of the element. Instead, they will now always have a gray color, regardless of the element alarm state.

### Fixes

#### Table icon on Summary page of PTP app not available [ID_34855]

If PTP 1.3.0 CU0 was used with DataMiner 10.2.7 or higher, the table icon on the Summary page of the PTP app was no longer available.
