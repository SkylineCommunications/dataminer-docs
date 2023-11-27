---
uid: Backup_Restore_Cassandra_Cluster
---
# About Cassandra cluster backup and restore

A complete guide on how to take a backup of the Cassandra database (single or cluster) is available on [Github](https://github.com/thelastpickle/cassandra-medusa/tree/master/docs). In this documentation, we will summarize the steps that are required for a local storage. Besides local storage, there are two other storage providers that can be used, google or s3 and may be configured using the afore referenced Github documentation.

## Taking a backup of Cassandra Cluster using Medusa

> [!IMPORTANT]
> All nodes in the cluster must be granted SSH access to connect to every nodes in the cluster, including the node where the backup is configured. Therefore, generate SSH keys in PEM format and add the SSH credentials to the configuration file.

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

   - Taking a full backup of a single node: `$ medusa backup --backup-name=<name of the backup> --mode=full`</break>

   - Taking a full backup of a cluster: `$ medusa backup-cluster --backup-name=<name of the backup> --mode=full`</break>

1. Verify that the backup is taken for every node in the cluster

## Generating SSH keys

1. Generate private key PEM format: `$ ssh-keygen -t rsa -b 4096 -m PEM -f <file_name>`

1. Copy the public key to the all nodes

1. Write the public key to the authorized_keys on all nodes in the cluster `cat [Path to file]/<file_name>.pub >>~/.ssh/authorized_keys`

## Restoring the backup

Choose if you want to:

- [Restore a full cluster](https://github.com/thelastpickle/cassandra-medusa/blob/master/docs/Restoring-a-full-cluster.md)

- [Restore a single node](https://github.com/thelastpickle/cassandra-medusa/blob/master/docs/Restoring-a-single-node.md)
