---
uid: Backup_Restore_Cassandra_Cluster
---

# Backing up and restoring a Cassandra cluster using Medusa

Medusa is an Apache Cassandra backup system. It is a command line tool that can be used to back up or restore a single Cassandra node or an entire cluster. It supports local storage, but also Google Cloud Storage (GCS), Azure Blob Storage, and AWS S3. The procedures below assume local storage is used. For more information, including on how to work with the mentioned storage providers, refer to the [Cassandra Medusa documentation](https://github.com/thelastpickle/cassandra-medusa/tree/master/docs).

> [!IMPORTANT]
> All nodes in the cluster must be granted SSH access to connect to every node in the cluster, including the node where the backup is configured. You will therefore need to generate SSH keys in PEM format and add the SSH credentials to the configuration file.

## Generate SSH keys

1. Generate private key PEM format: `$ ssh-keygen -t rsa -b 4096 -m PEM -f <file_name>`

1. Copy the public key to all nodes.

1. Write the public key to the authorized_keys on all nodes in the cluster `cat [Path to file]/<file_name>.pub >>~/.ssh/authorized_keys`

## Taking a backup of a Cassandra cluster using Medusa

1. You need a shared folder to store the backups, please follow the [How to Set Up NFS Server and Client on CentOS 8](https://www.tecmint.com/install-nfs-server-on-centos-8/) guide.

   > [!NOTE]
   > All nodes in the cluster must be mounted to the same network path. When using a local path, only the backups of the local node will be visible.

1. [Install Medusa](https://github.com/thelastpickle/cassandra-medusa/blob/master/docs/Installation.md)

1. [Configure Medusa](https://github.com/thelastpickle/cassandra-medusa/blob/master/docs/Configuration.md).

   Important properties that must be configured:

   - Cassandra: config_file and CQL/nodetool credentials

   - Storage: bucket_name, base_path

   - SSH: username, password, key_file,port,cert_file. 

1. [Take a backup](https://github.com/thelastpickle/cassandra-medusa/blob/master/docs/Performing-backups.md), choose whether to take a single node backup or a cluster backup.

   - Taking a full backup of a single node: `$ medusa backup --backup-name=<name of the backup> --mode=full`

   - Taking a full backup of a cluster: `$ medusa backup-cluster --backup-name=<name of the backup> --mode=full`

1. Verify that the backup is taken for every node in the cluster

## Restoring a backup using Medusa

Choose if you want to:

- [Restore a full cluster](https://github.com/thelastpickle/cassandra-medusa/blob/master/docs/Restoring-a-full-cluster.md)

- [Restore a single node](https://github.com/thelastpickle/cassandra-medusa/blob/master/docs/Restoring-a-single-node.md)
