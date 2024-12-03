---
uid: EPM_7.0.3_I-DOCSIS_CU1
---

# EPM 7.0.3 I-DOCSIS CU1

## Changes

### Fixes

#### DS Rx Power OOS calculation incorrect [ID 39750]

Up to now, the MER status was used to calculate the threshold values for the DS Rx Power OOS KPI instead of the Rx power, which caused false positives and alarms in the system. This calculation has now been corrected.
