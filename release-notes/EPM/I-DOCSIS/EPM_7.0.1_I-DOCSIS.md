---
uid: EPM_7.0.1_I-DOCSIS
---

# EPM 7.0.1 I-DOCSIS - preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## New features

#### Channel Utilization added for US/DS Service Group [ID_38849]

The ​Upstream and Downstream Service Group entities now display the Channel Utilization average of the associated channels in the data section.

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
