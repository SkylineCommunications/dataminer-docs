---
uid: Standalone_Elastic_Backup_Tool
---

# Standalone Elastic Backup tool

From DataMiner 10.0.13 onwards, this tool allows you to back up and restore Elasticsearch database clusters. By default, it is available on a DMA in the folder `C:\Skyline DataMiner\Tools`.

> [!IMPORTANT]
> The standalone Elastic Backup tool is being **deprecated** in favor of Elasticsearch's own snapshot functionality. We therefore recommend that you take database backups using the [Elasticsearch snapshot functionality](xref:Configuring_Elasticsearch_backups_Windows_Linux) instead.

## Syntax

Use the following general syntax when you run this tool:

```txt
StandaloneElasticBackup.exe <action> <arguments>
```

Example:

```txt
StandaloneElasticBackup.exe backup --host 127.0.0.1 -u elastic --pw mypw123 -r reponame
```

## Actions

The following actions can be specified in the syntax mentioned above:

- **init**: Initialize a repository.
- **backup**: Take a backup/snapshot.
- **restore**: Restore a backup/snapshot.

## Arguments

Depending on the specified action, different arguments are required.

### General arguments

The following arguments should be used regardless of the specified action:

- `--host` or `-h`: The host on which the command has to be run.

  Default: 127.0.0.1

- `--port` or `-p`: The port on which Elasticsearch will be contacted.

  Default: 9200

- `--username` or `-u`: The username that has to be used to connect to Elasticsearch.

  Only use this argument when credentials are required.

- `-- pw`: The password that has to be used to connect to Elasticsearch.

  Only use this argument when credentials are required.

### Arguments when initializing the repository

To initialize a repository for a snapshot, use the following arguments:

- `--repo` or `-r`: The name of the repository to be created.

- `--path`: The path of the repository as defined in the *yaml.xml* file of the Elasticsearch cluster (i.e. `path.repo`), enclosed by "". Add an extra backslash ("\") in front of backslash characters to make sure these are interpreted correctly. This is the location where the snapshot will be placed.

> [!NOTE]
> Snapshots are incremental. Do not delete any of them. For more information, see [Register a snapshot repository](https://www.elastic.co/guide/en/elasticsearch/reference/current/snapshots-register-repository.html).

### Arguments when taking a backup/snapshot

To take a backup/snapshot, use the following arguments:

- `--repo` or `-r`: The repository in which to take the backup.

  - If none is defined and only one repository is found in the Elasticsearch cluster, then that one will be used.
  - If none is defined and none can be found, no backup will be taken.

- `--SnapshotName` or `-n`: The (lowercase) name of the snapshot to be taken.

  Default: `DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");`

### Arguments when restoring a backup/snapshot

To restore a backup/snapshot, use the following arguments:

- `--repo` or `-r`: The repository containing the backup to be restored. If none is defined and only one repository is found in the Elasticsearch cluster, then that one will be used. If none is defined and none can be found, an error will be thrown.

- `--SnapshotName` or `-n`: The name of the snapshot to be restored.

> [!NOTE]
>
> - If all data was deleted from the database, first initialize the repository again before you restore a backup.
> - We recommend that you disable security when restoring a backup with security enabled. To do so, comment the security setting in the *.yaml* file.
> - It is only possible to restore indices that do not exist yet. Therefore, in most cases, you will have to delete all data from all nodes before restoring a backup.
> - Do not restore a backup while DataMiner is online.
> - You can get a list of existing snapshots to help find the right snapshot name by running a query on Kibana DevTools, e.g. `GET /snapshot/my_repository`. For more information, see [Get a list of available snapshots](https://www.elastic.co/guide/en/elasticsearch/reference/current/snapshots-restore-snapshot.html#get-snapshot-list).
