---
uid: SRM_1.2.15_CU1
---

# SRM 1.2.15 CU1

## Enhancements

#### Local orchestration of contributing transport bookings [ID_30381]

It is now possible to orchestrate contributing transport bookings locally. For this purpose, define an LSO script per state in the *ContributingConfig.ActionScripts* field of the Path parameter configuration of the transport node.

The *ContributingConfig.OrchestrationTrigger* field of the Path configuration will determine whether local orchestration is used or not.

For example:

```json
{
 "Link": "PATH",
 "Paths": [
  {
   "Name": "Route",
   "ResourcePoolForLinks": "SDMN.SAT.Transport",
   "Algorithm": "Dijkstra",
   "LinkPoolOptions": 0,
   "NrOfSuggestions": 10,
   "PathSelectionMode": "Manual",
   "Source": {
    "Link": "RESOURCE",
    "Function": "Demodulating",
    "Property": "Connected Resource"
   },
   "Destination": {
    "Link": "RESOURCE",
    "Function": "Decoding",
    "Property": "Connected Resource"
   },
   "ContributingConfig": {
    "PreRoll": 0,
    "PostRoll": 0,
    "LifeCycle": "Locked",
    "ReservationType": "FollowMain",
    "Concurrency": 1,
    "VisioFileName": "SRM_DefaultTransportService.vsdx",
    "Script": "Script:SRM_DummyScript||DummyParameterName=DummyValue",
    "OrchestrationTrigger": "Local", /* default */
    "ActionScripts": [
     { "Name": "PAUSE", "Script": "SRM_LifecycleServiceOrchestration" },
     { "Name": "STANDBY", "Script": "SRM_LifecycleServiceOrchestration" },
     { "Name": "START", "Script": "SRM_LifecycleServiceOrchestration" },
     { "Name": "STOP", "Script": "SRM_LifecycleServiceOrchestration" }
    ]
   }
  }
 ]
}
```

## Fixes

#### Created resources exported twice \[ID_30395\]

An issue in the *SRM_DiscoverResources* script could cause created resources to be exported twice.
