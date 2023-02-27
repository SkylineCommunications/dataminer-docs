---
uid: I-DOCSIS_upgrade
---

# EPM I-DOCSIS upgrade

When you have upgraded the EPM solution, execute the following procedure:

1. Go to the folder `C:\Skyline DataMiner\Dashboards\EPM SOLUTION`.

1. In each JSON file in the folder:

   - Replace all occurrences of `"Value": 738` with `"Value": newDataMinerID`.
   - Replace all occurrences of `"Value": 1` with `"Value": newElementID`.
   - Replace all occurrences of `"DataMinerID": 738` with `"DataMinerID": newDataMinerID`.
   - Replace all occurrences of `"ElementID": 1` with `"ElementID": newElementID`.
   - Replace all occurrences of `Parameter/738/1` with `Parameter/newDataMinerID/newElementID`.
   - Replace all occurrences of `Element/738/1` with `Element/newDataMinerID/newElementID`.

> [!NOTE]
>
> - `newElementID` is the element ID of the front-end element.
> - `newDataMinerID` is the DMA ID of the DataMiner Agent where the front-end (FE) element is located.
> - Currently, this procedure needs to be executed every time the EPM solution is upgraded.
