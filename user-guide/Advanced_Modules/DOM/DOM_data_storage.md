---
uid: DOM_data_storage
---

# DOM data storage

All DOM data are stored in an [indexing database](xref:Indexing_Database). Data for each object are stored in a separate index. Currently, the following indices are in use:

| Object name | Index name |
|--|--|
| [SectionDefinition](xref:DOM_SectionDefinition) | cdomsectiondefinition_{moduleId} |
| [DomTemplate](xref:DomTemplate) | cdomtemplate_{moduleId} |
| [DomDefinition](xref:DomDefinition) | cdomdefinition_{moduleId} |
| [DomInstance](xref:DomInstance) | cdominstance_{moduleId} |
| [DomBehaviorDefinition](xref:DomBehaviorDefinition) | cdombehaviordefinition_{moduleId} |
| [HistoryChange](xref:DOM_history#historychange) | chistory_dominstance_{moduleId} |

## Caching

From DataMiner 10.3.9/10.4.0 onwards<!-- RN 36412 -->, a full cache of the DOM configuration objects (`SectionDefinition`, `DomDefinition`, and `DomBehaviorDefinition`) is present by default. This means that all of these objects are stored in memory to improve the performance of the DOM manager. These caches are kept in sync across the cluster using the [DOM events](xref:DOM_events).

> [!NOTE]
>
> - Correct delivery of the DOM events is important to keep these caches in sync. If the DMS is unstable and Agents frequently lose connection to each other, we recommend disabling the caches. You can do so using the [caching settings](xref:DOM_StorageSettings#cachingsettings) in the `ModuleSettings`.
> - If a DOM configuration object event is lost, the cache may not reflect the correct state. This will be automatically fixed at midnight, as the "midnight sync" will ensure that the caches are correct by comparing them with the database. You can also trigger this sync manually in the SLNetClientTest tool. For more information, see [Triggering a midnight sync for a DOM manager](xref:SLNetClientTest_triggering_DOM_midnight_sync).
