---
uid: I-DOCSIS_upgrade
---

# EPM I-DOCSIS upgrade

Next proceure needs to be done for the right functioning of the dashboards: 

1. Go to the path: `C:\Skyline DataMiner\Dashboards\EPM SOLUTION`.

1. For all .json files there, you should:
    1. Search for: `"Value": 738` and replace all occurences with `"Value": newDataMinerID`.
    1. Search for: `"Value": 1` and replace all occurences with `"Value": newElementID`.
    1. Search for: `"DataMinerID": 738` and replace all occurences with `"DataMinerID": newDataMinerID`.
    1. Search for: `"ElementID": 1` and replace all occurences with `"ElementID": newElementID`.
    1. Search for: `Parameter/738/1` and replace all occurences with `Parameter/newDataMinerID/newElementID`.
    1. Search for: `Element/738/1` and replace all occurences with `Element/newDataMinerID/newElementID`.

> [!NOTE]
> `newDataMinerID` and `newElementID` are the Dataminer ID and Element ID (FrontEnd element) that belongs to the DMS where the package was installed.
> This procedure needs to be done every time a new package is installed.
> If those values are not replaced you will notice a lot of errors when a dashboard is open.