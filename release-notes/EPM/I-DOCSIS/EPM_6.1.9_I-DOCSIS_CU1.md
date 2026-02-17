---
uid: EPM_6.1.9_I-DOCSIS_CU1
---

# EPM 6.1.9 I-DOCSIS CU1

## Enhancements

#### Network layer KPIs adjusted and CH Utilization updated to show filtered dashboard [ID 36751]

​On the network layer, the *#CM Ping OK* KPI is now no longer displayed, as it does not provide meaningful information. Instead, the KPI *#CM Ping Unreachable* is now displayed. On the service group layer, the CH Utilization has been updated so it shows the dashboard with preselected filters for the respective service group.

#### Generic DOCSIS CM Collector: Interval adjusted for KPI calculation [ID 37356]

To make sure the same data are shown at the same time, the logic that updates KPIs in the CM QAM Channels, Cable Modem Overview, and QAM Channels tables now uses the same interval parameter, i.e., the Threshold Execution Interval.

#### DOCSIS version information streamlined [ID 38078]

To streamline the way DOCSIS version information is displayed, a number of changes have been implemented:

- On the visual overview pages for all levels, the *Number DOCSIS 1.X* parameter has been added.
- The *DOCSIS Other* parameter has been renamed to *DOCSIS Unknown* and added to all data and visual overview pages for all levels.
- In the CM dashboard, the names of the *Latency*, *Jitter*, and *Average Packet Loss* parameters were changed to *Average Latency*, *Max Jitter*, and *Packet Loss*. The order of the PNM KPIs has also been adjusted, so that now *Reflection Distance* comes first, then *Reflection Status*, and finally *Group Delay*.
- The font size in the visual overview for the CM has been adjusted so that it is the same for every KPI.
- In DataMiner Cube, KPIs can now be displayed over several lines, so that all the data of each KPI is fully visible.

#### Start and Stop Frequency parameters added to CM OFDM Channels dashboard [ID 38287]

In the dashboard *05. CM OFDM Channels*, the Start and Stop Frequency parameters are now displayed in the table *OFDM Channels*. These are retrieved from the CCAP. Previously, these parameters were not available in this dashboard.

#### EPM_I_DOCSIS_AddNewCcapCmPair script updated [ID 38326]

The script *EPM_I_DOCSIS_AddNewCcapCmPair*, which is used to create a new CCAP/CM pair, has been updated as follows:

- Users can now create elements by selecting the host instead of the back-end elements.
- The path of the CCAP is now the same as the selected host, instead of the name of the element pointing to the EPM SOLUTION folder.
- Custom properties are now updated through the script and take the values of the views in which the element was created.
- The script now supports the set and get community string for the collector and the CCAP, instead of only the set community string.

## Fixes

#### Generic CM Collector: Empty rows in QAM Channels and Cable Modem Overview tables [ID 36626]

Up to now, it could occur that the QAM Channels and Cable Modem Overview tables contained rows that were almost completely empty. To prevent this, the methods to calculate and obtain the status for the QAM channel KPIs have been modified to only consider active QAM channels.

#### CM count on CCAP Core level not matching cumulative count across associated linecards [ID 37399]

It could occur that the total count of CMs at the CCAP Core level did not match the cumulative count of CMs across the linecards associated with that CCAP. This was caused by the CMs being associated with linecards using a logical value (Service Group ID) instead of a physical one (MAC Domain). This has now been changed so that CMs are linked to a linecard using the MAC Domain of each CM.

#### CISCO CBR-8 CCAP Platform: DS port not found for some QAM Channels [ID 38044]

Because of a problem in the port mapping, it could occur that the DS port was not found for some QAM channels. This problem has been resolved so that the information in the US and DS QAM channels will now be more accurate.
