---
uid: I-DOCSIS_upgrade
---

# EPM I-DOCSIS upgrade

To upgrade the Dashboards to work property: 

Replace all "Value": 738 occurrences with "Value": 'newDataMinerID'
Replace all "Value": 1 occurrences with "Value": 'newElementID'
Replace all "DataMinerID": 738 occurrences with "DataMinerID": 'newDataMinerID'
Replace all "ElementID": 1 occurrences with "ElementID": 'newElementID'
Replace all Parameter/738/1 occurrences with Parameter/newDataMinerID/newElementID
Replace all Element/738/1 occurrences with Element/newDataMinerID/newElementID