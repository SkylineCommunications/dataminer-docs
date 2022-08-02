---
uid: Standalone_Cassandra_Backup_Tool
---

# Standalone Cassandra Backup tool

The *StandaloneCassandraBackup.exe* tool can be used by an administrator to take a backup of a Cassandra database (either a single node or a cluster).

From DataMiner 10.1.8 onwards, this tool is available on each DMA server in the folder `C:\Skyline DataMiner\Tools`. As it only affects Cassandra files, it can be used on any DataMiner system regardless of version.

> [!NOTE]
> When running one of the below-mentioned commands against a Cassandra cluster or a remote single-node Cassandra, make sure the Cassandra nodetool is accessible remotely on all nodes. For more information, see [Making Cassandra nodetool accessible remotely](xref:Making_Cassandra_nodetool_accessible_remotely).

## Commands

### listsnapshot

This command lists all snapshots of the specified Cassandra node.

The listsnapshot command can be run with the following arguments:

- `--host` or `-h`: The IP address of one of the nodes in the cluster of which you want to take a backup.

  Default: localhost

- `--port` or `-p`: The port used to connect to the remote nodetool host.

  Default: 7199

- `--username` or `-u`: The user name used when connecting to the nodetool host.

  Typically, this argument will not be used.

- `--pw`: The password used when connecting to the nodetool host.

  Typically, this argument will not be used.

- `--path`: The full path to the location of the Cassandra nodetool.

  Default: `C:\Program Files\Cassandra\bin\nodetool.bat`

Example:

```txt
StandaloneCassandraBackup.exe listsnapshot -h 10.11.3.57
```

### clearsnapshot

This command clears the specified snapshot and deletes its data.

> [!NOTE]
> This command will automatically be run on every node of a Cassandra cluster.

The clearsnapshot command can be run with the following arguments:

- `--host` or `-h`: The IP address of one of the nodes in the cluster of which you want to take a backup.

  Default: localhost

- `--port` or `-p`: The port used to connect to the remote nodetool host.

  Default: 7199

- `--username` or `-u`: The user name used when connecting to the nodetool host.

  Typically, this argument will not be used.

- `--pw`: The password used when connecting to the nodetool host.

  Typically, this argument will not be used.

- `--name`or `-n`: The name of the snapshot that has to be cleared.

  Default: empty (which clears all snapshots)

- `--path`: The full path to the location of the Cassandra nodetool.

  Default: `C:\Program Files\Cassandra\bin\nodetool.bat`

Example:

```txt
StandaloneCassandraBackup.exe clearsnapshot -h 10.11.3.57 -n snapshot1
```

### refresh

This command refreshes the keyspaces of the specified Cassandra cluster as described in the nodetool documentation.

> [!NOTE]
> This command will automatically be run on every node of a Cassandra cluster.

The refresh command can be run with the following arguments:

- `--host` or `-h`: The IP address of one of the nodes in the cluster of which you want to take a backup.

  Default: localhost

- `--port` or `-p`: The port used to connect to the remote nodetool host.

  Default: 7199

- `--username` or `-u`: The user name used when connecting to the nodetool host.

  Typically, this argument will not be used.

- `--pw`: The password used when connecting to the nodetool host.

  Typically, this argument will not be used.

- `--keyspaces` or `-k`: The name of the keyspaces that have to be refreshed. Multiple keyspaces must be separated by spaces.

  Default: all keyspaces

- `--path`: The full path to the location of the Cassandra nodetool.

  Default: `C:\Program Files\Cassandra\bin\nodetool.bat`

Example:

```txt
StandaloneCassandraBackup.exe refresh -h 10.11.3.57 –path C:\Program Files\nodetool.bat
```

### backup

This command creates a snapshot of the specified Cassandra database.

In case of a Cassandra cluster, this command will first retrieve the IP addresses of all cluster nodes using a nodetool status command. Then, a nodetool `snapshot` command will be sent to each of the nodes. The output of both the status command and the `snapshot` command will be logged in the `C:\Program Files\CassandraBackup\Logs` folder, which will automatically be created the first time nodetool is used.

> [!NOTE]
> This command will automatically be run on every node of a Cassandra cluster.

The backup command can be run with the following arguments:

- `--host` or `-h`: The IP address of one of the nodes in the cluster of which you want to take a backup.

  Default: localhost

- `--port` or `-p`: The port used to connect to the remote nodetool host.

  Default: 7199

- `--username` or `-u`: The user name used when connecting to the nodetool host.

  Typically, this argument will not be used.

- `--pw`: The password used when connecting to the nodetool host.

  Typically, this argument will not be used.

- `--name` or `-n`: The name of the snapshot.

  If no name is provided, Cassandra will automatically generate a name based on the current timestamp.

- `--keyspaces` or `-k`: The name of the keyspaces that have to be included in the snapshot. Multiple keyspaces must be separated by spaces.

  Default: all keyspaces

- `--path`: The full path to the location of the Cassandra nodetool.

  Default: `C:\Program Files\Cassandra\bin\nodetool.bat`

Example:

```txt
StandaloneCassandraBackup.exe backup -h 10.11.3.57 -n snapshot21 –path C:\Program Files\nodetool.bat
```

## Restoring a Cassandra backup

As restoring a Cassandra backup requires files to be moved, this cannot be done using the Standalone Cassandra Backup tool.

Proceed as follows to restore a Cassandra backup:

1. Make sure the table schema exists. If it does not, then recreate it.

1. Truncate the tables you want to restore. For more information, see the [CQL documentation](https://docs.datastax.com/en/cql-oss/3.3/cql/cql_reference/cqlTruncate.html).

1. Locate the snapshot you want to restore. It will be located in the following folder:

   `data_directory/keyspace_name/table_name-UUID/snapshots/`

1. Copy the most recent snapshot folder to the following folder:

   `data_directory/keyspace/table_name-UUID`

1. Run nodetool refresh and restart your nodes.
