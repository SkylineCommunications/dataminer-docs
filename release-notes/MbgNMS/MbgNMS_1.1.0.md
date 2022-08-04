---
uid: MbgNMS_1.1.0
---

# MbgNMS 1.1.0

## New features

\-

## Changes

### Enhancements

#### Compatibility with DataMiner 10.2.0.0-11897-CU4 Main Release \[ID_33083\]

The mbgNMS solution is now compatible with the DataMiner 10.2.0.0-11897-CU4 Main Release.

#### Compatibility with IDP 1.2.0 \[ID_33144\]

The mbgNMS solution is now compatible with DataMiner IDP 1.2.0.

#### Backup options limited to supported backup types \[ID_33146\]

When you take a backup of a device, now only the supported backup types will be available.

#### Only relevant device types shown for golden configuration rule configuration \[ID_33149\]

When you create a golden configuration rule, now only the device types for which backup and restore are possible are shown.

#### Meinberg LANTIME Modular SyncMon: Parameters with nanoseconds unit now use dynamic units \[ID_33150\]

Meinberg LANTIME Modular SyncMon parameters that use the nanoseconds unit have now been adjusted to use the dynamic units feature, so that they are converted to a bigger unit in the UI when appropriate.

#### Meinberg LANTIME Non-Modular SyncMon: Parameters with nanoseconds unit now use dynamic units \[ID_33151\]

Meinberg LANTIME Non-Modular SyncMon parameters that use the nanoseconds unit have now been adjusted to use the dynamic units feature, so that they are converted to a bigger unit in the UI when appropriate.

#### Meinberg LANTIME IMS-HPS: Parameters with nanoseconds unit now use dynamic units \[ID_33154\]

Meinberg LANTIME IMS-HPS parameters that use the nanoseconds unit have now been adjusted to use the dynamic units feature, so that they are converted to a bigger unit in the UI when appropriate.

#### Compatibility with DataMiner Cube’s black theme \[ID_33157\]

The Meinberg Network Management System is now compatible with DataMiner Cube's black theme.

#### Meinberg LANTIME Modular: CPU Load parameter improvements \[ID_33158\]

In the Meinberg LANTIME Modular connector, the *CPU Load* parameter now has a range and unit.

#### Meinberg LANTIME Non-Modular: CPU Load parameter improvements \[ID_33159\]

In the Meinberg LANTIME Non-Modular connector, the *CPU Load* parameter now has a range and unit.

### Fixes

#### Incorrect card type shapes in Meinberg LANTIME Modular visual overview \[ID_33145\]

In the Meinberg LANTIME Modular visual overview, incorrect card type shapes were displayed.

#### Meinberg Element Manager app: Details not shown via link on Equipment \> Software \> Overview page \[ID_33147\]

When you selected an entry on the *Equipment* > *Software* > *Overview* page of the Meinberg Element Manager app and clicked *Show details*, the main page of the app was displayed instead of the detailed information.

#### Meinberg LANTIME IMS-HPS: Port state displayed incorrectly \[ID_33152\]

Instead of the correct display value, the Meinberg LANTIME IMS-HPS element showed the value "9" for the port state.

#### Meinberg Element Manager app: Invalid OS version displayed in inventory summary \[ID_33155\]

In the inventory summary, if the *Device State* was not *Synchronized*, the Model OS would be displayed as *N/A*.
