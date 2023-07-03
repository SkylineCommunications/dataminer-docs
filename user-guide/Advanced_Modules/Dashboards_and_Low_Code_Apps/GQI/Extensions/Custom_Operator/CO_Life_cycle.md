---
uid: CO_Life_cycle
---

# Life cycle of a custom operator

All methods listed in [Building blocks](xref:CO_Building_blocks) are called at some point during the GQI life cycle, depending on whether a query is created or fetched, and depending on whether they have been implemented.

The following flowchart illustrates the GQI life cycle when a query is created:

![GQI query creation life cycle](~/user-guide/images/operator_lifecycle_create.png)

The following flowchart illustrates the GQI life cycle when a query is fetched:

![GQI query fetching life cycle](~/user-guide/images/operator_lifecycle_fetch.png)
