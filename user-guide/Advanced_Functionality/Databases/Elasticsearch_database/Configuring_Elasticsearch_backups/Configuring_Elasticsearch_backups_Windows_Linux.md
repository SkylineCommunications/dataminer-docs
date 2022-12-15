---
uid: Configuring_Elasticsearch_backups_Windows_Linux
---

# Configuring Elasticsearch backups for Windows and Linux

> [!NOTE]
> This configuration requires advanced knowledge of Elasticsearch. If you are in doubt, ask Skyline for assistance. However, note that this is not covered by the standard DataMiner Support Services.

This method to configure an Elasticsearch backup focuses on setting up and using an Elastic snapshot to back up and restore Elasticsearch data.

For more information on version compatibility, see the [Elasticsearch Guide](https://www.elastic.co/guide/en/elasticsearch/reference/6.8/modules-snapshots.html#_version_compatibility).

This method makes use of a source Elasticsearch cluster and a target Elasticsearch cluster and can be used for two purposes:

- Making a simple backup

  > [!NOTE]
  >
  > - The source and target Elasticsearch cluster may be the same.
  > - If you only want to make a backup, follow the guide below until step x.

- Migrating data from an existing Elasticsearch cluster to a new target Elasticsearch cluster

  Examples:

  - Migrating data from an older Windows-setup to a better performing Linux-setup

  - Migrating data to different hardware

  > [!NOTE]
  >
  > - The source and target Elasticsearch cluster will be different.
  > - This guide provides an entire explanation on how to make a backup for the sake of migrating data.

## Requirements

You will need a client application that is able to communicate with the Elasticsearch rest API. This application must be able to send POST and PUT messages with a request body.

Examples:

- Kibana: [Kibana](https://www.elastic.co/guide/en/kibana/6.8/deb.html#deb-repo) is often used together with Elasticsearch. If you are using Ubuntu or Debian as operating system, this is the preferred client application.

- CURL: [Curl](https://curl.se/) is a simple command line utility that allows messages with payload (e.g POST and PUT messages) and is useful for scripting.

- [Elasticvue](https://elasticvue.com/)

- [Postman](https://www.postman.com/product/rest-client/)

- ...

## Preparing and configuring the repositories

### Preparing the source Elasticsearch cluster

1. Ensure that the target Elasticsearch cluster is of a more recent version than the source Elasticsearch cluster by looking up the version number at `http://[IP-address]:9200`.

   Example:

   ```txt
   {
     "name" : "537-0",
     "cluster_name" : "DMS",
     "cluster_uuid" : "mhEwvZl2QTyZSxsdS1714w",
     "version" : {
       "number" : "6.8.23",
       "build_flavor" : "default",
       "build_type" : "zip",
       "build_hash" : "4f67856",
       "build_date" : "2022-01-06T21:30:50.087716Z",
       "build_snapshot" : false,
       "lucene_version" : "7.7.3",
       "minimum_wire_compatibility_version" : "5.6.0",
       "minimum_index_compatibility_version" : "5.0.0"
      },
      "tagline" : "You Know, for Search"
   }
   ```

   Snapshots can be restored from an older version of Elastic to a more recent version, but not the other way around.

1. Set up a shared folder on the source and target Elasticsearch clusters to hold the snapshots. This folder must be shared across all machines in the Elasticsearch clusters in all directions.

   > [!TIP]
   > If required, contact your IT department to follow the NFS server setup procedure as this may otherwise be challenging. Further input on networking infrastructure also may be required.

   To set up the shared folder:

   - For Windows:

     Use built-in sharing.

   - For Linux:

     Use an NFS server and client as explained in [How to Set Up NFS Server and Client on CentOS 8](https://www.tecmint.com/install-nfs-server-on-centos-8/) and in [Elasticsearch: Snapshot Backups on a Shared NFS](https://octoperf.com/blog/2019/05/02/elasticsearch-snapshot-backup-shared-nfs/#snapshot-repository). Follow this procedure on all machines in the Elasticsearch Cluster.

     > [!NOTE]
     >
     > - As this setup might be more challenging, we advise you to set it up in advance.
     > - Be wary of read, write, and execute rights, firewall configurations, and the state of the NFS server service during the setup.
     > - Make sure the Elasticsearch user has enough rights to the folder to read, write, and execute its contents.

1. On the source and target Elasticsearch cluster, navigate to the *Elasticsearch.yml* file. Open the file and set *path.repo* as your previously created shared folder. 

1. Create a repository with the following PUT request:

   ```txt
   PUT localhost:9200/_snapshot/my_fs_backup?pretty
   {
       "type": "fs",
       "settings": {
           "location": "/mount/backups/my_fs_backup_location",
           "compress": true
       }
   }
   '
   ```

   In this PUT request, `my_fs_backup_location` is the path of the shared folder you created and `my_fs_backup` should be replaced with a repository name of your choice.

   > [!TIP]
   > For more information, see [Shared File System Repository](https://www.elastic.co/guide/en/elasticsearch/reference/6.8/modules-snapshots.html#_shared_file_system_repository).

1. Search the Elasticsearch logging for exceptions.

   For Windows: `C:\Program Files\Elasticsearch\logs\[cluster.name].log`

   You can find the cluster name in `/etc/Elasticsearch/Elasticsearch.yml`.

   For Linux: `/var/log/elasticsearch/[cluster.name].log`

   You can find the cluster name in `C:\Program Files\Elasticsearch\config\Elasticsearch.yml`.

   - If you do not have enough rights to the shared folder, use the `chmod` and `chown` command.

     > [!NOTE]
     > It is possible you will need to contact your IT department to get more rights.

   - If the shares have not been set up correctly, return to step 2.

   - If there are no exceptions, move on to the next step.

   > [!TIP]
   > For more information, see [Logging configuration](https://www.elastic.co/guide/en/elasticsearch/reference/6.8/logging.html).

1. Verify whether the repository has been created correctly by entering `http://[IP-address]:9200/_cat/repositories?v`. In this is the case, the name of your repository should be visible on the page.

   ![Verify Repository](~/user-guide/images/Verify_Repository.png)

### Preparing the target Elasticsearch cluster

Repeat steps 1 to 6 of [Preparing the source Elasticsearch cluster](#preparing-the-source-elasticsearch-cluster).

> [!IMPORTANT]
> To restore a snapshot it is required to go through steps 1 to 6 first. Without a functional repository, you will run into issues that will delay the snapshot restore.

## Taking the snapshot

## Preparing the target machine

## Restoring the snapshot
