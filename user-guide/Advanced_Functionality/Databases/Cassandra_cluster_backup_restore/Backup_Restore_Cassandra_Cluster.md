---
uid: Backup_Restore_Cassandra_Cluster_Medusa
---

# Backing up and restoring a Cassandra cluster using Medusa

If you are running a Cassandra cluster on **Linux** for the DataMiner system storage, you can use Medusa to back up and restore your data.

Medusa serves as an Apache Cassandra backup system, offering a command-line interface for backing up or restoring either a single Cassandra node or an entire cluster. Its functionality extends to supporting various storage options, including **local storage** as detailed below.

> [!NOTE]
>
> - We promote the use of Ubuntu LTS as the preferred Linux distribution. As such, the commands mentioned below will work on any Debian-based system, including Ubuntu.
> - Medusa also supports cloud services such as Google Cloud Storage (GCS), Azure Blob Storage, and AWS S3. For detailed instructions and guidance on utilizing these storage providers, please consult the [Cassandra Medusa documentation](https://github.com/thelastpickle/cassandra-medusa/tree/master/docs).

## Configuring the firewall and generating SSH keys

The backup is configured on one of the nodes in the cluster. That node will then connect to the other nodes when a backup is performed. Therefore, it is crucial that all nodes within the cluster can communicate through the SSH port (default port 22).

See below for detailed instructions on how to enable SSH access.

> [!IMPORTANT]
> This documentation assumes that you have activated the firewall, and that port 22 has been opened following the recommendation found in [Installing Cassandra on a Linux machine](xref:Installing_Cassandra). If the firewall is disabled, please refer to step 2 of [Installing Cassandra on a Linux machine](xref:Installing_Cassandra) first, and ensure that the firewall permits traffic on ports 7000, 7001 and 9042 before proceeding with the backup configuration.

1. Configure each node to allow access to port 22 from each node in the cluster.

   - Example of commands on node 1:

     `$ sudo ufw allow from [IP node 2] to [IP node 1] proto tcp port 22`

     `$ sudo ufw allow from [IP node 3] to [IP node 1] proto tcp port 22`

   - Example of commands on node 2:

     `$ sudo ufw allow from [IP node 1] to [IP node 2] proto tcp port 22`

     `$ sudo ufw allow from [IP node 3] to [IP node 2] proto tcp port 22`

   - Example of commands on node 3:

     `$ sudo ufw allow from [IP node 1] to [IP node 3] proto tcp port 22`

     `$ sudo ufw allow from [IP node 2] to [IP node 3] proto tcp port 22`

1. Generate SSH keys.

   You will need to generate SSH keys in PEM format, and add the path of the private key to the SSH section in the *medusa.ini* configuration file.

   1. On the node where the backup will run (Node 1 in this example), generate a 4096-bit RSA key pair using the following command:

      `$ ssh-keygen -t rsa -b 4096 -m PEM -f <file_name>`

      Example:

      `$ ssh-keygen -t rsa -b 4096 -m PEM -f id_rsa`

      The command above creates a private key (**id_rsa**) and its corresponding public key (**id_rsa.pub**) in PEM format within the home folder.

   1. Copy the public key to all nodes by running the following command:

      `$ scp id_rsa.pub username@<Node1_IP>:/home/<username>/`

      - Example in which the keys are copied to Node 2:

        `$ scp id_rsa.pub myUser@10.10.10.12:/home/myUser/`

      - Example in which the keys are copied to Node 3:

        `$ scp id_rsa.pub myUser@10.10.10.13:/home/myUser/`

   1. Write the public key to the *authorized_keys* on all nodes in the cluster by running the following command:

      `$ cat [Path to file]/<file_name>.pub >>~/.ssh/authorized_keys`

      Example:

      `$ cat /home/myUser/id_rsa.pub >>~/.ssh/authorized_keys`

> [!IMPORTANT]
> If the backup is initiated from one of the nodes in the cluster, the public key should also be appended to the *authorized_keys* file on this node.

## Configuring the NFS share

To facilitate storage for backups, a shared folder is necessary, and all nodes in the cluster must be mounted to the same network path.

Set up an NFS share by following the instructions in [How to set up an NFS mount on Ubuntu 20.04](https://www.digitalocean.com/community/tutorials/how-to-set-up-an-nfs-mount-on-ubuntu-20-04) or [Installing and configuring Network File System (NFS) on Ubuntu](https://ubuntu.com/server/docs/service-nfs).

Make a note of the path, as you will need to store it in the *base_path* property in the *Medusa.ini* configuration file.

> [!NOTE]
> If you opt for a local path rather than a network share, only the backups of the local node will be accessible. We strongly recommend utilizing a shared folder for improved visibility and centralized access to backups across all nodes in the cluster.

## Installing and configuring Medusa

Execute the following steps on each node in the cluster:

1. Install python3-pip by running the following commands:

   1. `$ sudo apt update`
   1. `$ sudo apt install python3-pip`

1. Install Medusa. For detailed instructions, see the [installation guide on GitHub](https://github.com/thelastpickle/cassandra-medusa/blob/master/docs/Installation.md).

1. Create the */etc/medusa* directory if it does not exist yet, and create the */etc/medusa/medusa.ini* file. For more detailed information, go to [Configure Medusa on GitHub](https://github.com/thelastpickle/cassandra-medusa/blob/master/docs/Configuration.md).

   1. Create the directory by running the following command: `$ sudo mkdir -p /etc/medusa/`
   1. Create the file by running the following command: `$ sudo touch /etc/medusa/medusa.ini`
   1. Ensure the following properties are configured:

      - Cassandra:

        - *config_file*
        - CQL credentials

          - *cql_username*
          - *cql_password*

        - nodetool credentials:

          - *nodetool_username*
          - *nodetool_password*

      - Storage:

        - *storage_provider*
        - *bucket_name*
        - *base_path*

      - SSH:

        - *key_file*(path to the rsa private key)
        - *port*

## Taking a backup using Medusa

1. [Take a backup](https://github.com/thelastpickle/cassandra-medusa/blob/master/docs/Performing-backups.md).

   Choose whether to take a single node backup or a cluster backup.

   - To take a full backup of a single node, run the following command:

     `$ medusa backup --backup-name=<name of the backup> --mode=full`

   - To take a full backup of a cluster, run the following command:

     `$ medusa backup-cluster --backup-name=<name of the backup> --mode=full`

1. Verify that the backup is taken for every node in the cluster. The location of the backup is *base_path*/*bucket_name*.

## Restoring a backup using Medusa

You can restore a full cluster or a single node.

- To restore a full cluster, see [Restoring a full cluster](https://github.com/thelastpickle/cassandra-medusa/blob/master/docs/Restoring-a-full-cluster.md)

- To restore a single node, see [Restoring a single node](https://github.com/thelastpickle/cassandra-medusa/blob/master/docs/Restoring-a-single-node.md)
