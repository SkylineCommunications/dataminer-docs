---
uid: EPM_7.0.1_I-DOCSIS
---

# EPM 7.0.1 I-DOCSIS

## New features

#### Channel Utilization added for US/DS Service Group [ID 38849]

When you open the Upstream or Downstream Service Group levels under the DOCSIS Service Group chain in the Topology app, the Channel Utilization average of the associated channels is now displayed in the data section.

#### Skyline EPM Platform: New default values for US/DS SNR threshold [ID 39054]

New default values have been added for the upstream and downstream SNR threshold:

- For the upstream SNR threshold:

  - "Other" Modulation: 20.0 dB
  - QPSK: 15.0 dB
  - QAM8: 15.0 dB
  - QAM16: 15.0 dB
  - QAM32: 19.0 dB
  - QAM64: 21.0 dB
  - QAM128: 24.0 dB

- For the downstream SNR threshold:

  - "Other" Modulation: 20.0 dB
  - QAM64: 15.0 dB
  - QAM256: 27.0 dB

When the Skyline EPM Platform element is first initialized, it will now set default values for the Upstream QAM Channel Threshold and Downstream QAM Channel Threshold. In case the element already has values in the tables, you can add the default values with a button. This button is located on the Thresholds Settings page next to the *Execute* button.

#### New time picker for QAM DS and US Channels dashboards [ID 39074]

In the *Node Segment* and *Service Groups* folders in the Dashboards app, a new feature is available on the *QAM DS Channels* and *QAM US Channels* pages, which allows you to select specific start and end times for the information shown.

To use this feature, click the timestamp at the top of the dashboard. This will open a window where you can select the desired start and end times. When you do so, the trend graph will automatically update to display the information for the selected time period. To close the pop-up window, click outside of the window.

#### Harmonic CableOS CCAP support added [ID 39188]

​The I-DOCSIS Solution can now poll and show information from Harmonic CableOS CCAP devices. Using the *AddNewCcapCmPair* script, you can create a collector pair for these devices. After a polling cycle, these will then be shown in the EPM topology.

## Changes

### Enhancements

#### Generic DOCSIS CM Collector performance improvement [ID 39069]

Several improvements have been implemented in the Generic DOCSIS CM Collector connector to increase performance.

#### Default values added for upstream SNR threshold CCAPs [ID 39207]

New default values have been added for the upstream SNR threshold. When a CCAP element is first initialized, it will now set these default values for the Upstream QAM Channel Threshold:

- "Other" Modulation: 20.0 dB
- QPSK: 15.0 dB
- QAM8: 15.0 dB
- QAM16: 15.0 dB
- QAM32: 19.0 dB
- QAM64: 21.0 dB
- QAM128: 24.0 dB

### Fixes

#### Maps cluster color not matching household color [ID 38847]

If no alarm is present, the CPE household icons are no longer displayed in green by default, as this caused a disparity with the cluster color, shown as gray. The markers now show the correct alarm severity of the object.

#### DS Linecard Percentage CM Ping Uncorrectable KPI showed incorrect value [ID 38888]

It could occur that the *DS Linecard Percentage CM Ping Uncorrectable* KPI incorrectly showed 0% for all entities, because it used an incorrect parameter (*Number Ping OK*, with PID 1243013) to make the calculation. The correct parameter (*Total Number of CM*) will now be used instead.

#### System.IO.IOException when copying or writing a file [ID 38889]

In some cases, when the I-DOCSIS Solution tried to copy or write a file, a System.IO.IOException could be thrown. The relevant QActions have now been updated to handle this error.

#### EPM_I_DOCSIS_SetThresholdsTableToCollectors script ID conflict [ID 39040]

Up to now, a conflict could occur between the script ID of the *EPM_I_DOCSIS_SetThresholdsTableToCollectors* script and that of other scripts. In the Automation log file, this would be logged as "Execute ID 1 is used by another script". The script has now been updated to prevent this.

#### Parameter status values in Cable Modem table shown as not initialized [ID 39206]

When there were no valid values for the status of the parameters Rx Power Status, Tx Power Status, SNR Status, Post-FEC Status, Group Delay Status, Reflection Status, Reflection Distance Status, or Group Delay Reflection Status, it could occur that these columns in the Cable Modem table showed "Not Initialized" instead of the correct value "N/A". This has been corrected by adding an exception when the rows are initialized.
