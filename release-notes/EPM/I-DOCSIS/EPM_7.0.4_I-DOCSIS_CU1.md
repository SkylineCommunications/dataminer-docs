---
uid: EPM_7.0.4_I-DOCSIS_CU1
---

# EPM 7.0.4 I-DOCSIS CU1

## Changes

### Fixes

#### Host of BE or collector not found when running script to add CCAP pair [ID 40000]

When the script to add a CCAP pair was used, it could occur that this did not work and an error in the following format was displayed in the information events:

```txt
[ERROR]|Host of BE or Collector is not found for element [...]
```

To prevent this issue, the logic has been adjusted so that it is no longer possible to select a different host for the collector without a corresponding back end.

#### Invalid cast exception when deploying Generic DOCSIS CM Collector [ID 40002]

When the Generic DOCSIS CM Collector package was deployed, it could occur that an InvalidCastException was thrown.
