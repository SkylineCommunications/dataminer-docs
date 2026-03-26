---
uid: EPM_6.1.10_I-DOCSIS
---

# EPM 6.1.10 I-DOCSIS

## New features

#### Topology chains and chain fields can now be hidden [ID 37944]

It is now possible to hide specific chains, chain fields, search chains, search chain tabs, and search chain fields in the I-DOCSIS EPM UI in DataMiner Cube. You can do so on the *Configuration* > *Chain and Field Settings* page of the EPM front-end element.

## Changes

### Enhancements

#### Dashboard folders adjusted and unused dashboards removed [ID 37767]

The unused dashboards *I-DOCSIS CCAP -Trend_Test.dmadb* and *I-DOCSIS GLOBAL SYSTEM COUNTS.dmadb* have been removed, along with the *EPM Solution* folder containing them. In addition, two new folders, *CCAP* and *Network*, have been added, each containing the respective overview pages. Finally, the Service Group Overview dashboard has been moved to the *SERVICE GROUP* folder.

### Fixes

#### Problem in GQI_Display_Trend caused incorrect trending in dashboards [ID 37712]

A problem in the *GQI_Display_Trend* automation script could cause discrepancies between trend graphs in dashboards and the corresponding tables in DataMiner Cube.
