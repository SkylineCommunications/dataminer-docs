---
uid: General_Main_Release_10.3.0_CU10
---

# General Main Release 10.3.0 CU10 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

*No enhancements have been added yet.*

### Fixes

#### SLAnalytics: Problem when the alarm repository was not available at startup [ID_37782]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

In some cases, an error could occur in SLAnalytics when it was not able to connect to the alarm repository at startup.

#### Profile migrations to Elasticsearch/OpenSearch will now fail when the profiles.xml file is corrupt [ID_37818]

<!-- MR 10.3.0 [CU10] - FR 10.3.12 [CU0] -->

When you started a profile migration to an Elasticsearch/OpenSearch database while the *profiles.xml* file was corrupt, up to now, a new empty *profiles.xml* file would be created and the migration would continue. From now on, no new *profiles.xml* file will be created anymore and the migration will go into an error status.

> [!NOTE]
> When, in the SLNetClientTest tool, you go to *Advanced > Migration*, all migrations in an error status will now have a red background.
