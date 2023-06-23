---
uid: DOM_data_storage
---

# DOM data storage

All DOM data are stored in the Elasticsearch database. Data for each object are stored in a separate Elasticsearch index. Currently, the following indices are in use:

| Object name | Index name |
|--|--|
| [SectionDefinition](xref:DOM_SectionDefinition) | cdomsectiondefinition_{moduleId} |
| [DomTemplate](xref:DomTemplate) | cdomtemplate_{moduleId} |
| [DomDefinition](xref:DomDefinition) | cdomdefinition_{moduleId} |
| [DomInstance](xref:DomInstance) | cdominstance_{moduleId} |
| [DomBehaviorDefinition](xref:DomBehaviorDefinition) | cdombehaviordefinition_{moduleId} |
| [HistoryChange](xref:DOM_history#historychange) | chistory_dominstance_{moduleId} |

## Caching

By default, a full cache of the DOM configuration objects (`SectionDefinition`, `DomDefinition` and `DomBehaviorDefinition`) is present. This means that all of these objects are stored in memory to improve the performance of the DOM manager. These caches are kept in sync across the cluster using the [DOM events](xref:DOM_events).

> [!NOTE]
>
> - Correct delivery of the DOM events is important to keep these caches in sync. If the DMS is unstable and agents frequently lose connection to each other, it is recommended to disable the caches. This can be done using the [caching settings](xref:DOM_StorageSettings#cachingsettings) on the `ModuleSettings`.
> - If a DOM configuration object event would get lost, the cache may not reflect the correct state. This will be automatically fixed at midnight where a 'midnight sync' will ensure the caches are correct by comparing them with the database. You can trigger this sync manually in the [SLNetClientTest tool](xref:Opening_the_SLNetClientTest_tool) on the maintenance tab of a DOM manager viewer window. (Advanced > Apps > DataMiner Object Model)
