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
