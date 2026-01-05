---
uid: DOM_data_storage
---

# DOM data storage

All DOM data are stored in an [indexing database](xref:Indexing_Database). For the fastest and easiest deployment, we recommend using [Storage as a Service (STaaS)](xref:STaaS).

In a self-managed OpenSearch or Elasticsearch database, the data for each object is stored in a separate index. Currently, the following indices are in use:

| Object name | Index name |
|--|--|
| [SectionDefinition](xref:DOM_SectionDefinition) | cdomsectiondefinition_{moduleId} |
| [DomTemplate](xref:DomTemplate) | cdomtemplate_{moduleId} |
| [DomDefinition](xref:DomDefinition) | cdomdefinition_{moduleId} |
| [DomInstance](xref:DomInstance) | cdominstance_{moduleId} |
| [DomBehaviorDefinition](xref:DomBehaviorDefinition) | cdombehaviordefinition_{moduleId} |
| [HistoryChange](xref:DOM_history#historychange) | chistory_dominstance_{moduleId} |

## Backups

When using [Storage as a Service (STaaS)](xref:STaaS), all DOM data is automatically backed up. For more information on self-managed database backups, see [Configuring OpenSearch backups](xref:Configuring_OpenSearch_Backups) or [Configuring Elasticsearch backups](xref:Configuring_Elasticsearch_backups).

## Caching

From DataMiner 10.3.9/10.4.0 onwards<!-- RN 36412 -->, a full cache of the DOM configuration objects (`SectionDefinition`, `DomDefinition`, and `DomBehaviorDefinition`) is present by default. This means that all of these objects are stored in memory to improve the performance of the DOM manager. These caches are kept in sync across the cluster using the [DOM events](xref:DOM_events).

> [!NOTE]
>
> - Correct delivery of the DOM events is important to keep these caches in sync. If the DMS is unstable and Agents frequently lose connection to each other, we recommend disabling the caches. You can do so using the [caching settings](xref:DOM_StorageSettings#cachingsettings) in the `ModuleSettings`.
> - If a DOM configuration object event is lost, the cache may not reflect the correct state. This will be automatically fixed at midnight, as the "midnight sync" will ensure that the caches are correct by comparing them with the database. You can also trigger this sync manually in the SLNetClientTest tool. For more information, see [Triggering a midnight sync for a DOM manager](xref:SLNetClientTest_triggering_DOM_midnight_sync).

## Cleaning up DOM data from the database

To clean up a DOM manager and remove all DOM data, each DOM object needs to be deleted. This can be done in a custom script using the DOM helper, or via the ["Delete DOM Manager" feature](xref:SLNetClientTest_removing_DOM_Manager) in the DOM window of SLNetClientTest tool. This tool can be used to delete managers with up to 100&thinsp;000 instances (or up to 10&thinsp;000 instances prior to DataMiner 10.5.6/10.6.0<!-- RN 42788 -->). To clean up larger DOM managers, use the script approach first to remove the DOM instances.

When using a self-managed database (Elasticsearch or OpenSearch), you will need to remove the indices in the database as well. This is not needed for a DMS using STaaS.

### Removing DOM indices in Elasticsearch or OpenSearch

For each DOM manager, multiple indices are created in the database to store various DOM objects. Specifically, the DOM instance index mapping contains linking information between FieldDescriptor IDs and types. This can prevent redeployment of a modified model with the same module ID if the mappings no longer match.

To avoid potential mapping conflicts, we recommend deleting these indices entirely before redeployment. This can be done using the Elasticsearch or OpenSearch REST API by sending a delete request for all associated indices. However, the simplest approach is to use the database management tool **Elasticvue**.

> [!NOTE]
> After removing the indices from the database, restart your DMS to apply the changes.

> [!WARNING]
> Incorrectly modifying database content can result in data loss or corrupted configurations. Double-check all operations before proceeding.

Follow these steps to remove the relevant indices using Elasticvue:

1. Install the [Elasticvue tool](https://elasticvue.com/installation) as a desktop application or as a browser extension.

1. Open Elasticvue and click *Add Elasticsearch Cluster*. (This also works with OpenSearch clusters.)

1. Ensure the **URI** and **port** are correctly entered.

   You can find the IP address in the `C:\Skyline DataMiner\DB.xml` file. If authentication is required, configure *Basic Auth* accordingly.

1. Click *Connect* to establish a connection with the cluster.

   If the connection is successful, cluster statistics should be displayed.

1. Navigate to the *Indices* tab in the top-right menu.

1. Enter the **module ID** of the DOM manager in the filter box in the top-right corner.

   The following six indices should be listed:

   - `dms-cdombehaviordefinition_...`
   - `dms_cdomdefinition_...`
   - `dms_cdominstance_...`
   - `dms_cdomsectiondefinition_...`
   - `dms_cdomtemplate_...`
   - `dms_chistory_dominstance_...`

1. Select all six indices by selecting the box next to each name.

1. Click the green *Bulk Actions* button in the lower-left corner and select *Delete 6 Indices*.

1. Verify the indices listed in the confirmation box and click *OK* if they are correct.

1. Restart your DMS to ensure that the changes take effect and the system correctly detects the removed indices.

Once these steps have been completed, the indices will be removed from the cluster, allowing you to redeploy a DOM module with the same ID and an updated configuration.
