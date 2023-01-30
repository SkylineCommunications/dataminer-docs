---
uid: PA_1.3.0_CU1
---

# PA 1.3.0 CU1

> [!NOTE]
> This version requires that **SRM 1.2.28 [CU1]** is installed.

## Fixes

#### SRM_Setup script created queue element while one existed already [ID_34777]

When the *SRM_Setup* script was executed in order to configure Process Automation, it could occur that a new queue element was created for a resource pool while there already was a queue element for that resource pool.
