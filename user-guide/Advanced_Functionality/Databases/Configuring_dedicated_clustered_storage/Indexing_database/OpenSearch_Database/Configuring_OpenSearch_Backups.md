---
uid:  Configuring_OpenSearch_Backups
---

# Configuring OpenSearch backups

This procedure to configure an OpenSearch database backup focuses on setting up and using an OpenSearch snapshot to back up and restore OpenSearch data.

## Requirements

You will need a client application that is able to communicate with the OpenSearch rest API. This application must be able to send POST and PUT messages with a request body.

Examples:

- Kibana: [Kibana](https://www.elastic.co/guide/en/kibana/6.8/deb.html#deb-repo) is often used together with OpenSearch. If you are using Ubuntu or Debian as your operating system, this is the preferred client application.

- CURL: [Curl](https://curl.se/) is a simple command-line utility that allows messages with payload (e.g POST and PUT messages) and is useful for scripting.

- [Elasticvue](https://elasticvue.com/)

- [Postman](https://www.postman.com/product/rest-client/)

- ...

## Preparing and configuring the repositories

> [!IMPORTANT]
> To be able to restore a snapshot later, you must go through these steps first. Without a functional repository, you will run into issues that will delay the snapshot restore.

1. Set up a shared folder on the source OpenSearch cluster to contain the snapshots. This folder must be shared across all machines in the OpenSearch clusters in all directions.

   > [!TIP]
   > If required, contact your IT department to follow the NFS server setup procedure, as this step may otherwise be challenging. Further input on networking infrastructure may also be required.

   To set up the shared folder:

   - For Windows:

     Use built-in sharing.

   - For Linux:

     Use an NFS server and client as explained in [How to Set Up NFS Server and Client on CentOS 8](https://www.tecmint.com/install-nfs-server-on-centos-8/). Follow this procedure on all machines in the OpenSearch Cluster.

     > [!NOTE]
     >
     > - As this setup might be more challenging, we recommend that you set it up in advance.
     > - Be wary of read, write, and execute rights, firewall configurations, and the state of the NFS server service during the setup. For the machines that will act as NFS servers, make sure the firewall allows NFS traffic. You can use the following command for this: *sudo ufw allow nfs*. After this, you can for example mount the folder on the NFS Ubuntu clients referencing it using the command *sudo mount ip-address:pathofyoursharedserverfolder pathofyourclientfolder*.
     > - Make sure the OpenSearch user has enough rights to the folder to read, write, and execute its contents.

     > [!TIP]
     > It is also possible to set up an NFS share on Windows and share it with the destination Linux system. See [Windows Server 2016 as an NFS server for Linux clients](https://blog.bobbyallen.me/2018/01/18/windows-server-2016-as-an-nfs-server-for-linux-clients/).

1. On the source OpenSearch cluster, navigate to the *opensearch.yml* file. Open the file and set *path.repo* as your previously created shared folder.

1. Create a repository by executing the following PUT request in your client application:

   ```txt
   PUT /_snapshot/my-fs-repository
   {
     "type": "fs",
     "settings": {
       "location": "/mnt/snapshots"
     }
   }
   ```

   - "/mnt/snapshots": The path of the shared folder you created

   - "my_fs_backup": A repository name of your choice

   > [!TIP]
   > For more information see [Shared file system](https://opensearch.org/docs/2.8/tuning-your-cluster/availability-and-recovery/snapshots/snapshot-restore/#shared-file-system).

   > [!NOTE]
   > You can also use ElasticVue to create your repository: Go to *Snapshots* > *Snapshot Repositories*, and click the *New repository* button. Then fill in the name and the repository location, and leave the default settings untouched (i.e. *Compress* should be enabled, and *Readonly* should be disabled).

1. Search the OpenSearch logging for exceptions.

   - For Windows: `C:\Program Files\OpenSearch\logs\[cluster.name].log`

     You can find the cluster name in `C:\Program Files\opensearch-2.8.0\config\opensearch.yml`.

   - For Linux: `/var/log/opensearch/[cluster.name].log`

     You can find the cluster name in `/etc/opensearch/opensearch.yml`.

   If you do not have enough rights to the shared folder, use the `chmod` and `chown` command.

   > [!NOTE]
   > It is possible you will need to contact your IT department to get more rights.

   If the shares have not been set up correctly, return to step 1.

   If there are no exceptions, move on to the next step.

   > [!TIP]
   > For more information, see [Logs](https://opensearch.org/docs/latest/monitoring-your-cluster/logs/).

1. Verify whether the repository has been created correctly by entering the following GET request in your chosen client application.

   ```txt
   GET _snapshot/my-opensearch-repo
   ```

   If the repository was created correctly, the response returns repository information.

   Example:

   ```txt
   {
     "my-opensearch-repo" : {
       "type" : "fs",
       "settings": {
         "location": "/mnt/snapshots"
       }
     }
   }
   ```

   - "my-opensearch-repo": name of your snapshot repository

   - "fs": a file system repository

   - "/mnt/snapshots": the path where all snapshots are stored

   > [!TIP]
   > For more information, see [Get snapshot repository](https://opensearch.org/docs/latest/api-reference/snapshots/get-snapshot-repository/).

## Taking the snapshot

1. Execute the following PUT request in your chosen client application:

   ```txt
   PUT /_snapshot/my-repository/1
   ```

   - "_snapshot": name for the snapshot

   - "my-repository": name of your snapshot repository

   You can also add a request body to include or exclude certain indices or specify other settings. See [Take snapshots](https://opensearch.org/docs/2.8/tuning-your-cluster/availability-and-recovery/snapshots/snapshot-restore/#take-snapshots).

1. Verify that the snapshot was created successfully by entering the following GET request:

   ```txt
   GET /_snapshot/my-repository/1
   ```

   The field next to *"state":* should display "SUCCESS".

You have now finished configuring an OpenSearch backup.

## Restoring the snapshot

1. Ensure that the target OpenSearch cluster is empty.

1. To see all snapshots in your repository, execute:

   ```txt
   GET /_snapshot/my-repository/_all
   ```

1. In the target OpenSearch cluster, execute the following POST request:

   ```txt
   POST /_snapshot/my-repository/1/_restore
   ```

   You can also add a request body to include or exclude certain indices or specify other settings. See [Restore snapshots](https://opensearch.org/docs/2.8/tuning-your-cluster/availability-and-recovery/snapshots/snapshot-restore/#restore-snapshotss).

1. Verify whether the snapshot restore worked by comparing the indices for the local OpenSearch cluster with those of the target OpenSearch cluster.

   To do so, ...

   These indices should be identical and take up the same amount of space.
