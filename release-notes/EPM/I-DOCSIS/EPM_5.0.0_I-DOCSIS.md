---
uid: EPM_5.0.0_I-DOCSIS
---

# EPM 5.0.0 I-DOCSIS

## New features

#### Map visualization for service groups \[ID_30804\]

When navigating to service groups in the DOCSIS Service topology, users will now be able to access a *Maps* tab. The DataMiner Map displayed in this tab is by default set to show the Service Group layer, so that the cable modems in the relevant service group are displayed on the map.

If there are several cable modems in the same location, these are clustered under one marker. Clicking this marker will show each individual cable modem. For each cable modem, a tooltip can display information such as the MAC address, the group delay status, and more. There are also links available that will display the topology focused on the cable modem.

You can also select to view other layers, such as the Group Delay and Reflection layer. Multiple layers can be viewed at the same time. The markers for different layers have different colors, so that you can clearly see the difference between e.g. a cable modem with and without group delay.

#### Improved channel data \[ID_30775\]\[ID_30776\]\[ID_30778\]\[ID_30791\]

Changes have been implemented to multiple connectors so that the DS/US Ports, DS/US Service Groups, and Service Group \[Fiber Node\] levels now show individual channel data instead of instanced data from the cable modems.

The Arris E6000 CCAP Platform connector now exports an improved channels file that can be ingested by the Generic DOCSIS CM Collector to show cable modem channel instances and general channel instances. The Skyline EPM Platform DOCSIS connector will then view this data so that the Skyline EPM Platform can aggregate it into one single table.

#### CM latitude and longitude information added \[ID_30777\]

Latitude and longitude information has been added for cable modems, for use in DataMiner Maps.

## Changes

### Fixes

#### Flickering effect caused by fluctuations in Percentage CM Offline KPI value \[ID_30774\]

On the Market level in the network topology, it could occur that the alarm severity indication continually changed very quickly causing a flickering effect. This was caused by fluctuations in the value of the *Percentage CM Offline* KPI.
