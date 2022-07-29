# I-DOCSIS branch 6.0.2

## New features

\-

## Changes

### Enhancements

#### US Threshold parameter renamed to D3.0 PNM Threshold + range Downstream Channel Post-FEC Maximum Uncorrectable Error Ratio adjusted \[ID_31776\]

The *US Threshold* parameter has been renamed to *D3.0 PNM Threshold*.

In addition, the range of the Downstream Channel Post-FEC Maximum Uncorrectable Error Ratio has been adjusted.

#### Ping statistics now aggregated to higher topology levels \[ID_31778\]

The Latency, Jitter and Packet Loss Rate ping statistics KPIs are now aggregated for all topology levels of the Network and Service Topology.

### Fixes

#### Incorrect 0 values in CM QAM US Channel table \[ID_31775\]

In some cases, incorrect 0 values could be displayed for the MER and Power Fluctuation KPIs in the CM QAM US Channel table.

#### Unexpected KPI values in Cable Modem table \[ID_31777\]

In some cases, KPIs in the Cable Modem table could have unexpected values, such as an incorrect value of 0.

#### Aggregated values shown as 0 when they could not be calculated \[ID_31779\]

Up to now, when the collectors were stopped or there were no values to be aggregated, the aggregated values in the topology chain were shown as 0. Now an exception value will be displayed instead.

# D-DOCSIS branch 6.0.2

## New features

\-

## Changes

### Enhancements

#### RPD link on CCAP Core Overview page adjusted \[ID_31622\]

On the CCAP Core Overview page, the RPD KPI link has been adjusted so that it now navigates to the CCAP RPD Association page of the EPM Visual Overview. Previously, the link navigated to a different DataMiner element in the Surveyor, taking the user out of the EPM environment.

#### Dashboard trend graphs now show last 24 hours of real-time data \[ID_31623\]

All EPM dashboards showing trend graphs have now been configured to display the last 24 hours of real-time data by default.

#### Dashboards adjusted to allow dynamic element updates \[ID_31645\]

The CCAP, DPA, RPA, and NCS Overview dashboards have been adjusted to be more dynamic, so that users can immediately see new elements in the dashboards without having to edit the dashboards.

#### Alarm and trend templates adjusted to improve performance \[ID_31647\]

To improve performance, alarm and trend templates have been revised to ensure that no monitoring or trending is done for the Interface Overview tables. Now only the interfaces in the *DCF Interfaces* table are monitored and trended. This applies for the CISCO CBR-8 CCAP Platform Collector, Juniper Networks Manager CIN Platform, CISCO Manager CIN Platform, and COX CBR-8 Platform D-DOCSIS connectors.

#### RPD Topology: RPD box now shown when no RPA is discovered \[ID_31658\]

The RPD Topology page of the Skyline CCAP Platform EPM Visual Overview has been adjusted so that an RPD box is shown even if no RPA is discovered.

### Fixes

#### RPD name not displayed in RPD Topology \[ID_31644\]

In the RPD Topology, it could occur that the RPD name could not be displayed.

#### CCAP Platform EPM Visual Overview kept showing "Loading" message \[ID_31657\]

In the CCAP Platform EPM Visual Overview, it could occur that a "Loading" message remained displayed even after shape data were loaded.
