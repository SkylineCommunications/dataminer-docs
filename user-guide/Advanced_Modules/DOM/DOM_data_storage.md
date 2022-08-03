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

> [!NOTE]
>
> - Logging for each DOM manager is done in a separate log file with the name "SLDomManager_{moduleId}", e.g. "SLDomManager_my_module.txt".
> - A backup of all DOM manager data can be taken using the backup option *Create a backup of the database* > *Include all DomManager data in backup*. This is by default enabled in the backup preset *Full Backup*. See [Configuring the DataMiner backups](xref:Backing_up_a_DataMiner_Agent_in_DataMiner_Cube#configuring-the-dataminer-backups).
