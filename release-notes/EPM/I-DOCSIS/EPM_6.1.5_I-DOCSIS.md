---
uid: EPM_6.1.5_I-DOCSIS
---

# EPM 6.1.5 I-DOCSIS

## New features

#### Node Segment level [ID_34202]

A Node Segment level has been implemented in the EPM topology. This will serve as the bridge between the Cable Modem and the US and DS Port levels. It contains all the necessary KPIs to aggregate the US and DS Port KPIs.

## Changes

### Enhancements

#### Aggregation moved from back end to CCAPs [ID_34015]

The aggregation actions used to count the total number of CMs and the total number of taps in the CM table have been moved from the back end to all CCAP connectors.

#### Empty cells in DOCSIS Line Cards table now display "N/A" [ID_34092]

In the *DOCSIS Line Cards* table, if no value is available, "N/A" will now be displayed instead of "Not Initialized".

#### Decimals removed for parameters with ppm units [ID_34203]

For parameters with the unit ppm, decimals have been removed, as showing decimals for such a small KPI does not provide meaningful information.

#### Number/Percentage of Ping OK KPIs hidden at ports and linecards levels [ID_34221] [ID_34224]

The *Number of Ping OK* and *Percentage of Ping OK* KPIs will now be hidden at US/DS Port and US/DS Linecard level, since these are no longer valid because of the implementation of the Node Segment level.

#### Adaptive polling of CCAPs adjusted [ID_34365]

The behavior of adaptive fast SNMP polling of CCAPs has been adjusted. The poll interval is now based on the last execution time (i.e. the time it took to poll the last cycle) plus a period of cooling time defined by a parameter on the *Debug* page of the CCAP element. This way the polling interval is adjusted to match the speed of the device. Note that if poll times are below 15 minutes, the interval will be set to 15 minutes.

### Fixes

#### Generic DOCSIS CM Collector: Incorrect CM channel count [ID_34050]

In some cases, CMs could have more channels than allowed by the manufacturer. To prevent this, cleanup logic has now been implemented that removes old rows from the CM QAM US Channels and CM QAM DS Channels depending on the age of the rows.

#### Incorrect percentage value in DOCSIS Line Cards table in case no data was available to calculate the percentage [ID_34094]

If there was no data available to perform a percentage calculation, up to now the *DOCSIS Line Cards* table displayed "100%" instead. Now the display value in that case will be "N/A".

#### Generic DOCSIS CM Collector: Incorrect US QAM Tx Power Status [ID_34095]

In some cases, it could occur that the *US QAM Tx Power Status* parameter for a CM displayed the value "OK" even though there were no valid Tx power values associated with that CM. Now "N/A" will be displayed in such a case.

#### EPM Platform visual overview: Dashboard icon no longer working after navigation between cards [ID_34110]

If you opened the *EPM Platform* visual overview and then navigated to a different card and back, it could occur that the dashboard icon in the visual overview no longer opened a dashboard when clicked.

#### EPM Platform visual overview: Reset Interval parameter showed duplicate information [ID_34111]

On the *Configuration* page of the *EPM Platform* visual overview, the *Reset Interval* parameter could display duplicate information in case the visual overview was viewed on a high-resolution monitor. This was caused by the parameter showing both the read and write parameter values.

The write parameter will no longer be shown now, and to set the parameter the user will need to click a button.

#### Negative average latency, jitter, and packet loss values [ID_34223]

In some cases, the average latency, jitter, and packet loss rate parameters could show negative values.

To prevent this, the aggregation actions used to get these values in the Skyline EPM Platform DOCSIS connector were changed from sum to average.

#### Incorrect description Downstream Channel Minimum SNR parameter [ID_34228]

The description of the *Downstream Channel Minimum SNR* parameter was incorrect. It mentioned that the parameter that would be updated was *CM DS SNR Status*, while it should be *DS QAM SNR Status*.

##### Aggregation actions not executed correctly [ID_34229]

It could occur that aggregation actions to get the average percentage DS/US utilization per service group and the average percentage calculations per port were not executed correctly. This could cause the relevant columns in the EPM back-end element to be empty.

#### PNM and cable modem OOS parameters hidden at Service Group level [ID_34279]

The aggregation actions for PNM and cable modem OOS parameters at Service Group, US Service Group, and DS Service Group level have been removed. The parameters that depended on these actions have therefore been hidden and the visual overview has been updated accordingly. It no longer shows the PNM section and maps integration at Service Group level.

#### CISCO CMTS CCAP Platform: Incorrect US Port name exported to CM file [ID_35297]

Because the CISCO CMTS CCAP Platform connector exported incorrect US Port names to the cable modem file, the US Port IDs in the cable modem table showed "N/A" and the US Port names in that same table were incorrect.
