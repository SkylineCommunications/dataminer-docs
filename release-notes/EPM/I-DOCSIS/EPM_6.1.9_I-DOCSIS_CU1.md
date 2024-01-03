---
uid: EPM_6.1.9_I-DOCSIS_CU1
---

# EPM 6.1.9 I-DOCSIS CU1

## Enhancements

#### DOCSIS version information streamlined [ID_38078]

To streamline the way DOCSIS version information is displayed, a number of changes have been implemented:

- On the visual overview pages for all levels, the *Number DOCSIS 1.X* parameter has been added.
- The *DOCSIS Other* parameter has been renamed to *DOCSIS Unknown* and added to all data and visual overview pages for all levels.
- In the CM dashboard, the names of the *Latency*, *Jitter*, and *Average Packet Loss* parameters were changed to *Average Latency*, *Max Jitter*, and *Packet Loss*. The order of the PNM KPIs has also been adjusted, so that now *Reflection Distance* comes first, then *Reflection Status*, and finally *Group Delay*.
- The font size in the visual overview for the CM has been adjusted so that it is the same for every KPI.
- In DataMiner Cube, KPIs can now be displayed over several lines, so that all the data of each KPI is fully visible.

#### Start and Stop Frequency parameters added to CM OFDM Channels dashboard [ID_38287]

In the dashboard *05. CM OFDM Channels*, the Start and Stop Frequency parameters are now displayed in the table *OFDM Channels*. These are retrieved from the CCAP. Previously, these parameters were not available in this dashboard.

## Fixes

#### CISCO CBR-8 CCAP Platform: DS port not found for some QAM Channels [ID_38044]

Because of a problem in the port mapping, it could occur that the DS port was not found for some QAM channels. This problem has been resolved so that the information in the US and DS QAM channels will now be more accurate.
