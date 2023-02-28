---
uid: EPM_6.1.6_I-DOCSIS_CU1
---

# EPM 6.1.6 I-DOCSIS CU1

## Fixes

#### Incorrect linecard name in US Port/DS Port tables [ID_35637]

In the US Port/DS Port tables, an incorrect linecard name could be displayed, as this name was retrieved from the Physical Interface table instead of the Module table. Now the name will be retrieved from the Module table, so that the Linecard table and US Port/DS Port tables get the name from the same source.
