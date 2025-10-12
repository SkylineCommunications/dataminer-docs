---
uid: MaintenanceSettings.DeltCache.DELTCacheMode-mode
---

# mode attribute

Specifies the DELT cache cleanup mode.

## Content Type

| Item | Facet Value | Description |
| --- | --- | --- |
| ***string restriction*** |  |  |
| &#160;&#160;Enumeration | CleanupKeepRecentPackages | Use this mode if you want all .dmimport packages deleted except the X most recent ones. If, for instance, you add a `<DELTCacheMode>` tag in which you set the mode attribute to “CleanupKeepLastPackages” and the value attribute to 5, then after each import or export operation, DataMiner will delete all packages except the 5 most recent ones. |
| &#160;&#160;Enumeration | CleanupLargerThan | Use this mode if you want all .dmimport packages deleted that are larger than a specific number of bytes. If, for instance, you add a `<DELTCacheMode>` tag in which you set the mode attribute to “CleanupLargerThan” and the value attribute to 2099200, then after each import or export operation, DataMiner will delete all packages larger than 2 MB. |
| &#160;&#160;Enumeration | CleanupOlderThan | Use this mode if you want all .dmimport packages deleted that were created prior to a specific date and time. If, for instance, you add a `<DELTCacheMode>` tag in which you set the mode attribute to “CleanupOlderThan” and the value attribute to “11-07-2016 12:00”, then after each import or export operation, DataMiner will delete all packages that were created before that time. |

## Parents

[DELTCacheMode](xref:MaintenanceSettings.DeltCache.DELTCacheMode)
