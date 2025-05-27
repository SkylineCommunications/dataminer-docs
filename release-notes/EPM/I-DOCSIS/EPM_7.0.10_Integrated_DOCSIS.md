---
uid: EPM_7.0.10_Integrated_DOCSIS
---

# EPM 7.0.10 Integrated DOCSIS - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

## New features

#### New dashboard to monitor whether KPI exceeds threshold for specific period [ID 42406]

A new dashboard is now available with the name *US FN Breach Report (OFDMA)* and *US FN Breach Report (SC-QAM)*. It allows you to monitor whether a KPI is higher than a specific threshold for a specific period of time. It makes use a of new ad hoc data source (*EPM_I_DOCSIS_GQI_GET_BREACH_DATA*) that reports the fiber nodes that breached a threshold for a specific number of months in a row. This is checked in weekly increments. This means that if for example a month is selected, the dashboard will check whether for that period of time (i.e. a month), the threshold was breached at least once every week.
