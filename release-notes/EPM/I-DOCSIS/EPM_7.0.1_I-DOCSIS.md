---
uid: EPM_7.0.1_I-DOCSIS
---

# EPM 7.0.1 I-DOCSIS - preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## New features

#### Channel Utilization added for US/DS Service Group [ID_38849]

When you open the ​Upstream or Downstream Service Group entities in the Topology app, the Channel Utilization average of the associated channels is now displayed in the data section.

#### Skyline EPM Platform: New default values for US/DS SNR threshold [ID_39054]

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

When a Skyline EPM Platform element is first initialized, it will now set default values for the Upstream QAM Channel Threshold and Downstream QAM Channel Threshold. In case the element already has values in the tables, you can add the default values with a button. This button is located on the Thresholds Settings page next to the *Execute* button.

## Changes

#### EPM_I_DOCSIS_SetThresholdsTableToCollectors script ID updated [ID_39040]

The ID of the *EPM_I_DOCSIS_SetThresholdsTableToCollectors* script has been updated to prevent possible conflicts with other script IDs.

### Enhancements

### Fixes

#### Maps cluster color not matching household color [ID_38847]

If no alarm is present, the CPE household icons are no longer displayed in green by default, as this caused a disparity with the cluster color, shown as gray. The icons now show the correct alarm severity of the object.

#### DS Linecard Percentage CM Ping Uncorrectable KPI showed incorrect value [ID_38888]

It could occur that the *DS Linecard Percentage CM Ping Uncorrectable* KPI incorrectly showed 0% for all entities, because it used an incorrect parameter to make the calculation. The correct parameter (*Total Number of CM*) will now be used instead.

#### System.IO.IOException when copying or writing a file [ID_38889]

In some cases, when the I-DOCSIS Solution tried to copy or write a file, a System.IO.IOException could be thrown. The relevant QActions have now been updated to handle this error.
