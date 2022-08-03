---
uid: EPM_6.0.2_I-DOCSIS
---

# EPM 6.0.2 I-DOCSIS

## New features

\-

## Changes

### Enhancements

#### US Threshold parameter renamed to D3.0 PNM Threshold + range Downstream Channel Post-FEC Maximum Uncorrectable Error Ratio adjusted \[ID_31776\]

The *US Threshold* parameter has been renamed to *D3.0 PNM Threshold*.

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
