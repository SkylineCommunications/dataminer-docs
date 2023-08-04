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
