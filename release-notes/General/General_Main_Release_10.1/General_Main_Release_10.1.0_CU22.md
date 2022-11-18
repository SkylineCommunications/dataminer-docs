---
uid: General_Main_Release_10.1.0_CU22
---

# General Main Release 10.1.0 CU22 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Elasticsearch: Sending a GetInfoMessage of type 'IndexingConfiguration' with an invalid DataMiner ID will now only return the Elasticsearch configuration of the local DMA [ID_34774]

<!-- MR 10.1.0 [CU22]/10.2.0 [CU10] - FR 10.3.1 -->

When a *GetInfoMessage* of type "IndexingConfiguration" was sent containing an invalid DataMiner ID, up to now, the Elasticsearch configuration of all DMAs would be returned.

From now on, when the DataMiner ID in a *GetInfoMessage* request of type "IndexingConfiguration" is invalid, only the Elasticsearch configuration of the local DMA will be returned instead.

#### DataMiner upgrade: Enhanced method to delete locked files [ID_34779]

<!-- MR 10.1.0 [CU22] / 10.2.0 [CU10] - FR 10.3.1 -->

When, during a DataMiner upgrade, an attempt was made to delete files that were locked by certain processes, up to now, that attempt would fail, causing those files to remain on the system until the next upgrade.

From now on, when an attempt to delete a file during a DataMiner upgrade fails, the extension of that file will be replaced by `.SLReplace` and, later on in the upgrade process, the file will then be deleted by SLHelper.

#### DataMiner Cube: Stream Viewer enhancements [ID_34837] [ID_34838]

<!-- MR 10.1.0 [CU22] / 10.2.0 [CU10] - FR 10.3.1 -->

The Stream Viewer tree view now supports more levels. This will allow you to display more detailed information.

For example, in case of HTTP communication, there will now be extra levels for sessions, connections, requests/responses, parameters*, and even status codes and error codes.

**only in case of a response*

### Fixes

#### 'One or more of the following modules are not licensed' error would incorrectly not list the unlicensed modules [ID_34407]

<!-- MR 10.1.0 [CU22] / 10.2.0 [CU10] - FR 10.2.11 -->

When a required software license cannot be found, a `One or more of the following modules are not licensed: ...` message will appear.

In some cases, instead of listing the unlicensed modules, this message would incorrectly only mention "None".

#### Dashboards app - Time range feed: Quick pick buttons would not be displayed in the correct order [ID_34759]

<!-- MR 10.1.0 [CU22] / 10.2.0 [CU10] - FR 10.3.1 -->

When a time range feed was configured to show quick pick buttons, those buttons would not be displayed in the correct order. From now on, quick pick buttons will be displayed in chronological order.

#### Standalone parameters belonging to another child of the same DVE parent element could be set to 'Not Initialized' when a row linked to a DVE child element was deleted [ID_34785]

<!-- MR 10.1.0 [CU22] / 10.2.0 [CU10] - FR 10.3.1 -->

When a row linked to a DVE child element was deleted, in some cases, standalone parameters belonging to another child of the same DVE parent element could be set to "Not Initialized".

#### Memory leak in SLDataGateway during a Cassandra Cluster migration [ID_34829]

<!-- MR 10.1.0 [CU22] / 10.2.0 [CU10] - FR 10.3.1 -->

During a Cassandra Cluster migration, SLDataGateway would leak memory due to paging handlers not being cleaned up correctly.

#### DataMiner Cube - Visual Overview: Preset specified in a Spectrum Analysis component would incorrectly not be loaded [ID_34833]

<!-- Main Release Version 10.1.0 [CU22]/10.2.0 [CU10] - Feature Release Version 10.3.1 -->

When you had specified a preset in a shape that contained a Spectrum Analysis component, the preset would incorrectly not be loaded when you opened the visual overview in Cube.

#### HTTP requests would incorrectly not be retried when WinHTTP threw a SEC_E_BUFFER_TOO_SMALL error [ID_34888]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU22]/10.2.0 [CU10] - Feature Release Version 10.3.1 -->

When an HTTP request is sent, in some cases, WinHTTP can incorrectly throw a `SEC_E_BUFFER_TOO_SMALL` error when the server is using TLS 1.2.

From now on, when this error is thrown, DataMiner will retry the HTTP request the number of times specified for the HTTP connection in question.
