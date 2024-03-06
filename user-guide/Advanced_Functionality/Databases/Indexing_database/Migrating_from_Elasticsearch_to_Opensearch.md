---
uid: Migrating_from_Elasticsearch_to_OpenSearch
---

# Migrating from Elasticsearch to OpenSearch

From DataMiner 10.4.4/10.5.0 onwards<!-- RN 37994 -->, a tool is available that allows you to migrate from Elasticsearch 6.8.22 to OpenSearch 2.11.1.

To use this tool, follow the instructions below:

1. [Take a snapshot of the Elasticsearch 6.8.22 cluster](#take-a-snapshot-of-the-elasticsearch-6822-cluster).

1. [Copy the snapshot to an Elasticsearch 7.10.0 cluster and restore it](#restore-the-snapshot-on-an-elasticsearch-7100-cluster).

1. [Run the re-indexing tool and take a snapshot](#run-the-re-indexing-tool-and-take-a-snapshot).

1. [Copy the snapshot with the re-indexed data to an OpenSearch 2.11.1 cluster and restore it](#restore-the-snapshot-with-the-re-indexed-data-to-a-opensearch-2111-cluster).

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

   - This request will return all registered snapshots in the cluster. In case the desired repository already exists the next step can be skipped.

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

   - This request returns status information for a specific snapshot within a given repository. The state should be SUCCESS and all shards should be successful.

## Restore the snapshot on an Elasticsearch 7.10.0 cluster

Using Kibana, you can restore the snapshot in the following way:

1. Check the *path.repo* configuration in *elasticsearch.yml*, it should be pointing to a shared filesystem location to which each node has access.

1. Check the existing repositories by sending the following request:

   ```txt
   GET /_snapshot/_all
   ```

   - This request will return all registered snapshots in the cluster. In case the desired repository already exists the next step can be skipped.

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

## Restore the snapshot with the re-indexed data to a OpenSearch 2.11.1 cluster

1. Check the *path.repo* configuration in *opensearch.yml*.

   This configuration should point to a shared file system location to which each node has access.

1. Check the existing repositories by sending the following request:

   ```txt
   GET /_snapshot/_all
   ```

   - This request will return all registered snapshots in the cluster. In case the desired repository already exists the next step can be skipped.

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

1. Check the cluster health by sending the following request:

   ```txt
    GET /_cluster/health
   ```

   The status of the cluster should turn green after the restore.
