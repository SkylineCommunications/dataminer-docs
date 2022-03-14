---
uid: DMAAlarmFilterItem
---

# DMAAlarmFilterItem

| Item  | Format  | Description                                                                                                              |
|-------|---------|--------------------------------------------------------------------------------------------------------------------------|
| Match | Boolean | Set to True by default, but can be set to False for a negative filter.                                                   |
|       |         | Possible additional fields can be specified, depending on the type of filter. See [FilterItem types](#filteritem-types). |

### FilterItem types

The DMAAlarmFilterItem class is an abstract type for all possible filter types. It can be set to any of the following subtypes with the *xsi:type* attribute:

| Type                      | Additional fields                                                           |
|---------------------------|-----------------------------------------------------------------------------|
| DMAAlarmFilterConstant    | \-                                                                          |
| DMAAlarmFilterAll         | \-                                                                          |
| DMAAlarmFilterAny         | \-                                                                          |
| DMAAlarmFilterStatus      | string\[\] States                                                           |
| DMAAlarmFilterSeverity    | string\[\] Severities                                                       |
| DMAAlarmFilterAlarmType   | string\[\] Types                                                            |
| DMAAlarmFilterView        | int ViewID                                                                  |
| DMAAlarmFilterDataMiner   | int DataMinerID                                                             |
| DMAAlarmFilterService     | int DataMinerID<br> int ServiceID                                           |
| DMAAlarmFilterElement     | int DataMinerID<br> int ElementID                                           |
| DMAAlarmFilterParameter   | int DataMinerID<br> int ElementID<br> int ParameterID<br> string TableIndex |
| DMAAlarmFilterSavedFilter | string Filter                                                               |

For example:

```xml
<FilterItem xsi:type="DMAAlarmFilterView">
<Match>true</Match>
<ViewID>25</ViewID>
</FilterItem>
```
