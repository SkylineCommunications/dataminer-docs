---
uid: PTP_1.1.3_CU2
---

# PTP 1.1.3 CU2

## Enhancements

#### Improved support for Arista Manager [ID_34993]

The following parameters from the Arista Manager connector have been added to the mediation layer:

- Mode, which represent the switch clock mode, is now mapped to PID 33001 of the Arista Manager.

#### New PTP parameters in Tektronix SPG8000 - PTP Interface connector [ID_34994]

The following parameters have been added to the Tektronix SPG8000 - PTP Interface connector:

- Clock class (in the PTP Status table)
- Local Offset time (in the PTP Status table)
- Step (in the PTP Status table)
- Local Time (to be added to the DVE and mediated)

#### Improved support for Tektronix SPG8000 - PTP Interface [ID_35055]

The following parameters from the Tektronix SPG8000 - PTP Interface connector have been added to the mediation layer:

- Local time (PID 10109)
- Step mode (PID 11219)
- Clock class (PID 11212)

In addition, for the following Tektronix SPG8000 - PTP Interface parameters, an N/A value will now be displayed in the mediation layer:

- PID 10110 - PID10120
- PID 14219 - PID14221

#### Mellanox Technologies MLNX-OS Manager clocks added [ID_35201]

The parameter IDs for the following Mellanox Technologies MLNX-OS Manager clocks have been added to the Standard DataMiner PTP Device connector: the local clock, parent clock, and grandmaster clock.

#### Support for Meinberg LANTIME IMS-HPS API V10 - PTPv2 Instance connector added [ID_35289]

DataMiner PTP now supports the Meinberg LANTIME IMS-HPS API V10 - PTPv2 Instance connector.

#### DataMiner PTP updated to support Seiko Time Server Pro. TS-2950 and Mellanox Technologies MLNX-OS Manager parameters [ID_36059]

DataMiner PTP now fully supports the following parameters from the Seiko Time Server Pro. TS-2950:

- PTP Profile Column (PID 1818)
- Log Announce Interval Column  (PID 1804)
- Log Sync Interval Column (PID 1806)
- Clock Source (PID 529)
- Log Min Delay Request Interval Column (PID 1807)
- Announce Receipt Timeout (PID 1805)

In addition, the following parameters from the Mellanox Technologies MLNX-OS Manager are now supported:

- Parent Clock - Clock ID (PID 8120)
- Grandmaster Clock - Clock ID (PID 8104)
- Local Clock - Clock ID (PID 8016)

#### 'Slave clocks' terminology adjusted [ID_36361]

In the PTP visual overview, the term "slave" has now been adjusted to "slave clock" in several places:

- On the *Nodes* > *Summary* tab, the title *Slaves* has been changed to *Slave clocks*.
- On the *Nodes* tab, the *Slaves* subtab has been renamed to *Slave clocks*, and the title on that subtab has also been changed accordingly.

## Fixes

#### Connections not displayed on PTP Topology page [ID_36358]

Because of a change introduced in DataMiner 10.3.1, connections on the PTP Topology page were no longer shown from that DataMiner version onwards. This happened because DCF connections were no longer shown for dynamically positioned shapes if connectivity was disabled for a child shape. To resolve this, the *DisableConnectivity* option has been removed from the PTP visual overview.

#### Help link not working [ID_36359]

On the *Help* tab of the PTP app, the link to the PTP help no longer worked. The URL has now been updated to the redirect URL `https://aka.dataminer.services/PTPHelp`, so that it will always link to the correct page.
