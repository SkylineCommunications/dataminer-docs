---
uid: CO_Life_cycle
---

# Life cycle of a custom operator

All methods listed in [Building blocks](xref:CO_Building_blocks) are called at some point during the GQI life cycle, depending on whether a query is created or fetched, and depending on whether they have been implemented.

The following diagram illustrates in what order each GQI life cycle method is called. Different methods are called depending on whether the query is being build or executed.

![Custom operator life cycle](~/user-guide/images/GQI_CustomOperatorLifeCycle.png)
