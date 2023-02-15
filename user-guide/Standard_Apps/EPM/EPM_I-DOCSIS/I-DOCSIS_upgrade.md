---
uid: I-DOCSIS_upgrade
---

# EPM I-DOCSIS upgrade

The below procedure is required to be executed once the EPM solution is upgraded: 

1. Go to the path: `C:\Skyline DataMiner\Dashboards\EPM SOLUTION`.

1. For all JSON files in the folder, proceed with the following replacements:
    1. Replace all occurences of `"Value": 738` with `"Value": newDataMinerID`.
    1. Replace all occurences of `"Value": 1` with `"Value": newElementID`.
    1. Replace all occurences of `"DataMinerID": 738` with `"DataMinerID": newDataMinerID`.
    1. Replace all occurences of `"ElementID": 1` with `"ElementID": newElementID`.
    1. Replace all occurences of `Parameter/738/1` with `Parameter/newDataMinerID/newElementID`.
    1. Replace all occurences of `Element/738/1` with `Element/newDataMinerID/newElementID`.

> [!NOTE]
> `newElementID` is the EID of the FE element.
> `newDataMinerID` is the DMA ID where the FE (Front end) element is located.
> Currently this procedure needs to be executed every time that the EPM solution is upgraded.