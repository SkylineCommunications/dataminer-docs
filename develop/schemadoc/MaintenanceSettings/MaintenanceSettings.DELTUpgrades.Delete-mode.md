---
uid: MaintenanceSettings.DELTUpgrades.Delete-mode
---

# mode attribute

Specifies the deletion mode.

## Content Type

| Item | Facet Value | Description |
| --- | --- | --- |
| ***string restriction*** |  |  |
| &#160;&#160;Enumeration | CleanupKeepRecentPackages | For this mode, the value attribute specifies the X most recent packages that have to be kept. |
| &#160;&#160;Enumeration | CleanupLargerThan | For this mode, the value attribute specifies the maximum size (in bytes) of the files that are allowed in the Upgrades folder. |
| &#160;&#160;Enumeration | CleanupOlderThan | For this mode, the value attribute specifies the oldest timestamp of the files that are allowed in the Upgrades folder. |
| &#160;&#160;Enumeration | CleanupAll | No value is applicable for this mode. |

## Parents

[Delete](xref:MaintenanceSettings.DELTUpgrades.Delete)
