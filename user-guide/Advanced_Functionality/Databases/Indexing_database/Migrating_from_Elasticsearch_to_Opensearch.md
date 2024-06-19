---
uid: Migrating_from_Elasticsearch_to_OpenSearch
keywords: re-indexer
---

# Migrating from Elasticsearch to OpenSearch

From DataMiner 10.4.0 [CU2]/10.4.4 onwards<!-- RN 37994 -->, a tool is available that allows you to migrate from Elasticsearch 6.8.22 to OpenSearch 2.11.1.

To use this tool, follow the instructions below:

1. Stop all Agents in the DMS.

1. [Take a snapshot of the Elasticsearch 6.8.22 cluster](#take-a-snapshot-of-the-elasticsearch-6822-cluster).

1. [Copy the snapshot to an Elasticsearch 7.10.0 cluster and restore it](#restore-the-snapshot-on-an-elasticsearch-7100-cluster).

1. [Run the re-indexing tool and take a snapshot](#run-the-re-indexing-tool-and-take-a-snapshot).

1. [Copy the snapshot with the re-indexed data to an OpenSearch 2.11.1 cluster and restore it](#restore-the-snapshot-with-the-re-indexed-data-to-an-opensearch-2111-cluster).

1. [Reconfigure DB.xml on every Agent](#reconfigure-dbxml-on-every-agent).

1. Restart all DataMiner Agents in the DMS.

> [!CAUTION]
> To prevent data loss, all Agents of the DMS must be stopped during this procedure. They must not be started up again until the migration is completed.

> [!NOTE]
> As of DataMiner 10.3.0 [CU16], 10.4.0 [CU4], and 10.4.7 [CU0], an improved version of the tool is available, which among others features better logging, as well as the possibility to retry failed indexes (once the cause of the failure has been resolved) using the following command-line option: `ReIndexElasticSearchIndexes.exe [-R <path to failed indexes file>]`.<!-- RN 39614 -->

> [!TIP]
> See also: [Taking a snapshot of one Elasticsearch cluster and restoring it to another](xref:Taking_snapshot_Elasticsearch_cluster_and_restoring_to_different_cluster)

## Take a snapshot of the Elasticsearch 6.8.22 cluster

Using Kibana, you can take a snapshot in the following way:

1. Check the *path.repo* configuration in *elasticsearch.yml*.

   This configuration should point to a shared file system location to which each node has access.

1. Check the existing repositories by sending the following request:

   ```txt
   GET /_snapshot/_all
   ```

   - This will return a response containing information about all the repositories configured in Elasticsearch. In case the desired repository already exists, you can skip the next step.
   - Example response when a repository already exists:

     ```json
     {
       "test_tepo_1" : {
         "type" : "fs",
         "settings" : {
           "location" : "/usr/share/elasticsearch/repo",
           "maxRestoreBytesPerSec" : "40mb",
           "readonly" : "false",
           "compress" : "true",
           "maxSnapshotBytesPerSec" : "40mb"
         }
       }
     }
     ```

1. Create the repository by sending the following request:

   ```txt
   PUT /_snapshot/<repo_name>
    {
        "type": "fs",
        "settings": {
        "location" : "<shared_repo_path>",
            "maxRestoreBytesPerSec" : "40mb",
            "readonly" : "false",
            "compress" : "true",
            "maxSnapshotBytesPerSec" : "40mb"
        }
    }
   ```

   Variables:

   - **repo_name**: A repository name of your choice.
   - **shared_repo_path**: The path to the shared folder where the snapshots will be stored.

1. Take the snapshot by sending the following request:

   ```txt
   PUT /_snapshot/<repo_name>/<snapshot_name>
    {
      "indices": "dms*"
    }
   ```

   Variable:

   - **snapshot_name**: A snapshot name of your choice.

1. Check the snapshot by sending the following request:

   ```txt
   GET /_snapshot/<repo_name>/<snapshot_name>/_status
   ```

   This request returns status information for a specific snapshot within a given repository. The state should be SUCCESS and all shards should be successful.

## Restore the snapshot on an Elasticsearch 7.10.0 cluster

Using Kibana, you can restore the snapshot in the following way:

1. Check the *path.repo* configuration in *elasticsearch.yml*.

   This configuration should point to a shared file system location to which each node has access.

1. Check the existing repositories by sending the following request:

   ```txt
   GET /_snapshot/_all
   ```

   - This will return a response containing information about all the repositories configured in Elasticsearch. In case the desired repository already exists, you can skip the next step.
   - Example response when a repository already exists:

     ```json
     {
       "test_tepo_1" : {
         "type" : "fs",
         "settings" : {
           "location" : "/usr/share/elasticsearch/repo",
           "maxRestoreBytesPerSec" : "40mb",
           "readonly" : "false",
           "compress" : "true",
           "maxSnapshotBytesPerSec" : "40mb"
         }
       }
     }
     ```

1. Create the repository by sending the following request:

   ```txt
   PUT /_snapshot/<repo_name>
    {
        "type": "fs",
        "settings": {
        "location" : "<shared_repo_path>",
            "maxRestoreBytesPerSec" : "40mb",
            "readonly" : "false",
            "compress" : "true",
            "maxSnapshotBytesPerSec" : "40mb"
        }
    }
   ```

1. Restore the snapshot by sending the following request:

   ```txt
   POST /_snapshot/<repo_name>/<snapshot_name>/_restore 
   ```

1. Check the snapshot by sending the following request:

   ```txt
   GET /_snapshot/<repo_name>/<snapshot_name>/_status
   ```

   This request will return information about the status of the specified snapshot. The status should be "SUCCESS".

1. Check the cluster health by sending the following request:

   ```txt
   GET /_cluster/health
   ```

   The status of the cluster should turn green after the restore.

## Run the re-indexing tool and take a snapshot

1. Open a terminal, and go to the folder containing the tool. By default, this is the folder `C:\Skyline DataMiner\Tools\ReIndexElasticSearchIndexes`:

   ```txt
   cd C:\Skyline DataMiner\Tools\ReIndexElasticSearchIndexes
   ```

1. Run the tool with the following arguments:

   | Argument | Description |
   |----------|-------------|
   | -Node or -N | The name of the node to be used for re-indexing (mandatory).<br>Format: `http(s)://127.0.0.1:9200` or `http(s)://fqdn:9200` |
   | -User or -U | The user name, to be provided in case Elasticsearch was hardened.<br>See [Securing the Elasticsearch database](xref:Security_Elasticsearch) |
   | -Password or -P | The user password |
   | -DBPrefix or -D | The database prefix, to be provided in case a custom database prefix is used instead of the default `dms-` prefix.<br>If you do not provide a prefix, the default `dms-` will be used. |
   | -TLSEnabled or -T | Whether or not TLS is enabled for this ElasticSearch database.<br>Values: true or false. Default: false |
   | -RetryFile or -R &lt;path to failed indexes file&gt; | File path for a file containing failed indexes, to be provided in case the reindexer should retry reindexing previously failed indexes (supported from 10.3.0 [CU16]/10.4.0 [CU4]/10.4.7 [CU0] onwards). |

   > [!NOTE]
   > In case the re-indexing fails, a file `<runId>_failed.json` will be created in the folder where the tool is located, listing all failed indexes. This file can be used with the `-R <path to failed indexes file>` option to retry the failed indexes. To find out why these indexes failed, check the log file created in the *logging* folder located in the folder where the tool is available. Before retrying the re-indexing, make sure the failures are resolved.

1. Take a snapshot of the re-indexed data by sending the following request:

   ```txt
   PUT /_snapshot/<repo_name>/<snapshot_name_reindexed>
    {
      "indices": "dms*"
    }
   ```

1. Check the snapshot by sending the following request:

   ```txt
   GET /_snapshot/<repo_name>/<snapshot_name>/_status
   ```

   This request will return information about the status of the specified snapshot. The status should be "SUCCESS".

## Restore the snapshot with the re-indexed data to an OpenSearch 2.11.1 cluster

1. Check the *path.repo* configuration in *opensearch.yml*.

   This configuration should point to a shared file system location to which each node has access.

1. Check the existing repositories by sending the following request:

   ```txt
   GET /_snapshot/_all
   ```

   - This will return a response containing information about all the repositories configured in Elasticsearch. In case the desired repository already exists, you can skip the next step.
   - Example response when a repository already exists:

     ```json
     {
       "test_tepo_1" : {
         "type" : "fs",
         "settings" : {
           "location" : "/usr/share/elasticsearch/repo",
           "maxRestoreBytesPerSec" : "40mb",
           "readonly" : "false",
           "compress" : "true",
           "maxSnapshotBytesPerSec" : "40mb"
         }
       }
     }
     ```

1. Create the repository by sending the following request:

   ```txt
   PUT /_snapshot/<repo_name>
    {
        "type": "fs",
        "settings": {
        "location" : "<shared_repo_path>",
            "maxRestoreBytesPerSec" : "40mb",
            "readonly" : "false",
            "compress" : "true",
            "maxSnapshotBytesPerSec" : "40mb"
        }
    }
   ```

1. Restore the snapshot by sending the following request:

   ```txt
   POST /_snapshot/<repo_name>/<snapshot_name_reindexed>/_restore 
   ```

1. Check the snapshot by sending the following request:

   ```txt
   GET /_snapshot/<repo_name>/<snapshot_name>/_status
   ```

   This request will return information about the status of the specified snapshot. The status should be "SUCCESS".

1. Check the cluster health by sending the following request:

   ```txt
   GET /_cluster/health
   ```

   The status of the cluster should turn green after the restore.

## Reconfigure DB.xml on every Agent

In case the OpenSearch nodes have been installed on a different machine than the Elasticsearch nodes you are migrating from, do the following **on every Agent** in your DMS:

1. Navigate to the folder `C:\Skyline DataMiner` and open *DB.xml*.

1. Locate the IP addresses or hostnames previously used by Elasticsearch.

   > [!TIP]
   > For information on where these are located in *DB.xml*, see [Indexing database settings](xref:DB_xml#indexing-database-settings).

1. Replace these with the IP addresses of the OpenSearch nodes.

1. Save the *DB.xml* file and exit.

When all *DB.xml* files have been reconfigured, you can restart all DataMiner Agents to finish the procedure.
