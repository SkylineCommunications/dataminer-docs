---
uid: PTP_1.1.3_CU1
---

# PTP 1.1.3 CU1

## Enhancements

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

## Fixes

#### Table icon on Summary page of PTP app not available [ID_34855]

If PTP 1.3.0 CU0 was used with DataMiner 10.2.7 or higher, the table icon on the Summary page of the PTP app was no longer available.
