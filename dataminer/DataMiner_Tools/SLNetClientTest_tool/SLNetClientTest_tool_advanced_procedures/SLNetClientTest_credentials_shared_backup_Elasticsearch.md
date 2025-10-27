---
uid: SLNetClientTest_credentials_shared_backup_Elasticsearch
---

# Specifying credentials for a shared backup path for Elasticsearch

From DataMiner 10.2.0/10.1.8 onwards, it is possible to configure specific credentials for the network location that is used for Elasticsearch backups.

To do so:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to the *Build Message* tab of the main window.

1. In the *Filter* box, specify *SetElasticBackupPath*. A message ending in *SetElasticBackupPath* should then be selected in the *Message Type* box.

1. Specify the backup path, password and username in the corresponding fields.

1. Click *Send Message*.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
