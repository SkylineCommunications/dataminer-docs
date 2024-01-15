---
uid: Migration_from_Elasticsearch_to_OpenSearch
---

# Migration from Elasticsearch to OpenSearch

This guide describes the steps to migrate from Elasticsearch 6.8.22 to OpenSearch 2.11.1

1. Take a snapshot in the Elasticsearch 6.8.22 cluster.

2. Copy the snapshot to a Elasticsearch 7.10.0 cluster and restore it there.

3. Run the Reindexing tool on the restored data and take a snapshot.

4. Copy the reindexed snapshot to a OpenSearch 2.11.1 cluster and restore it there.

Reference [Taking a snapshot of one Elasticsearch cluster and restoring it to another](xref:Taking_snapshot_Elasticsearch_cluster_and_restoring_to_different_cluster)

## Take Snapshot on Elasticsearch 6.8.22

### Sample Steps to take snapshot on Kibana

1. Check the "path.repo" configuration on elasticsearch.yml.

2. Check existing repositories.

   ```txt
   GET /_snapshot/_all
   ```

3. Create repository

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

    - **shared_repo_path**: The path of the shared folder for storing the snapshots.
    - **repo_name**: A repository name of your choice.

4. Take snapshot

   ```txt
   PUT /_snapshot/<repo_name>/<snapshot_name>
    {
      "indices": "dms*"
    }
   ```

    - **snapshot_name**: A snapshot name of your choice.

5. Check Snapshot

   ```txt
    GET /_snapshot/<repo_name>/<snapshot_name>/_status
   ```

## Restore Snapshot on Elasticsearch 7.10.0

### Sample Steps to restore snapshot on Kibana

1. Check the "path.repo" configuration on elasticsearch.yml.

2. Check existing repositories.

   ```txt
   GET /_snapshot/_all
   ```

3. Create repository

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

4. Restore snapshot.

   ```txt
    POST /_snapshot/<repo_name>/<snapshot_name>/_restore 
   ```

5. Check Snapshot

   ```txt
    GET /_snapshot/<repo_name>/<snapshot_name>/_status
   ```

6. Check cluster health

   ```txt
    GET /_cluster/health
   ```

    - Wait for green status of cluster health.

## Run Reindexing Tool

1. On the terminal go to the tool location:

   ```txt
    cd <ReIndexElasticSearchIndexes.exe location>
   ```

2. Execute the tool whith the following arguments:

   - **Node or N** Name of the node to be used for re-indexing, in format: http(s)://127.0.0.1:9200 or http(s)://fqdn:9200 (required)
   - **User or U** UserName to be provided in case you hardened your ElasticSearch,  [Securing the Elasticsearch database](https://docs.dataminer.services/user-guide/Advanced_Functionality/Security/Advanced_security_configuration/Database_security/Security_Elasticsearch.html)
   - **Password or P** Password of the User
   - **DBPrefix or D** DB Prefix in case you use a custom db-prefix instead of the default dms- prefix. In case no prefix is provided, will default to dms-
   - **TLSEnabled or T** Indicate if TLS is enabled for your ElasticSearch, can be true or false, will default to false

3. Take snapshot of the reindexed data

   ```txt
   PUT /_snapshot/<repo_name>/<snapshot_name_reindexed>
    {
      "indices": "dms*"
    }
   ```

4. Check Snapshot

   ```txt
    GET /_snapshot/<repo_name>/<snapshot_name>/_status
   ```

## Restore reindexed snapshot in OpenSearch

1. Check the "path.repo" configuration on opensearch.yml.

2. Check existing repositories.

   ```txt
   GET /_snapshot/_all
   ```

3. Create repository

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

4. Restore snapshot.

   ```txt
    POST /_snapshot/<repo_name>/<snapshot_name_reindexed>/_restore 
   ```

5. Check Snapshot

   ```txt
    GET /_snapshot/<repo_name>/<snapshot_name>/_status
   ```

6. Check cluster health

   ```txt
    GET /_cluster/health
   ```