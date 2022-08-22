---
uid: EPM_6.0.2_D-DOCSIS
---

# EPM 6.0.2 D-DOCSIS

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

To improve performance, alarm and trend templates have been revised to ensure that no monitoring or trending is done for the Interface Overview tables. Now only the interfaces in the *DCF Interfaces* table are monitored and trended. This applies for the CISCO CBR-8 CCAP Platform Collector, Juniper Networks Manager CIN Platform, CISCO Manager CIN Platform, and COX CBR-8 Platform D-DOCSIS connectors.

#### RPD Topology: RPD box now shown when no RPA is discovered \[ID_31658\]

The RPD Topology page of the Skyline CCAP Platform EPM Visual Overview has been adjusted so that an RPD box is shown even if no RPA is discovered.

### Fixes

#### RPD name not displayed in RPD Topology \[ID_31644\]

In the RPD Topology, it could occur that the RPD name could not be displayed.

#### CCAP Platform EPM Visual Overview kept showing "Loading" message \[ID_31657\]

In the CCAP Platform EPM Visual Overview, it could occur that a "Loading" message remained displayed even after shape data were loaded.
