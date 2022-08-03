---
uid: DOM_data_storage
---

# DOM data storage

All DOM data are stored in the Elasticsearch database. Data for each object is stored in a separate Elasticsearch index. Currently, the following indices are in use:

| Object name | Index name |
|--|--|
| SectionDefinition | cdomsectiondefinition_{moduleId} |
| DomTemplate | cdomtemplate_{moduleId} |
| DomDefinition | cdomdefinition_{moduleId} |
| DomInstance | cdominstance_{moduleId} |
| DomBehaviorDefinition | cdombehaviordefinition_{moduleId} |
