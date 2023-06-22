---
uid:  Configuring_OpenSearch_Backups
---

# Configuring OpenSearch backups

This procedure to configure an OpenSearch database backup focuses on setting up and using an OpenSearch snapshot to back up and restore OpenSearch data.

## Requirements

You will need a client application that is able to communicate with the OpenSearch rest API. This application must be able to send POST and PUT messages with a request body.

Examples:

- OpenSearch Dashboards: [OpenSearch Dashboards](https://opensearch.org/docs/latest/dashboards/index/) is often used together with OpenSearch. If you are using Ubuntu or Debian as your operating system, this is the preferred client application.

- CURL: [Curl](https://curl.se/) is a simple command-line utility that allows messages with payload (e.g POST and PUT messages) and is useful for scripting.

- [Elasticvue](https://elasticvue.com/)

- [Postman](https://www.postman.com/product/rest-client/)

- ...

## Preparing and configuring the repositories

> [!IMPORTANT]
> To be able to restore a snapshot later, you must go through these steps first. Without a functional repository, you will run into issues that will delay the snapshot restore.

Below we are talking about NFS server and NFS clients. The NFS server is responsible of providing a shared folder accessible from all OpenSearch nodes. Why? Because that’s the way Elasticsearch snapshots work. All nodes must have access to a shared storage to be able to store the snapshot data.

1. Set up a shared folder on the source OpenSearch cluster for all nodes to contain the snapshots. This folder must be shared across all machines in the OpenSearch clusters in all directions.

    ```bash
    sudo mkdir /var/nfs/opensearch -p
    ```

1. Give the folder the necessary permissions on all nodes.

   ```bash
   sudo chmod 777 /var/nfs/opensearch
   ```

   If you do not have enough rights to the shared folder, use the `chmod` and `chown` command.

   > [!NOTE]
   > It is possible you will need to contact your IT department to get more rights.

  -**NFS Server**

   1. Install the NFS server packages on one node. We recommend the cluster_manager node.
  
      ```bash
      sudo apt update
      sudo apt install nfs-kernel-server
      ```

   1. Configure the NFS Server to share the folder with NFS clients by editing the /etc/exports and adding the following line:

      ```bash
      sudo nano /etc/exports
      ```
  
      ```text
      /var/nfs/opensearch 166.206.186.0/24(rw,sync,no_root_squash,no_subtree_check)
      ```

      166.206.186.0/24: This will allow all nodes/server that are in the network-address range: 166.206.186.x and subnet mask 255.255.255.0.
  
      Save the by entering, CTRL+O, Enter, followed by CTRL+X.

   1. Restart the nfs-kernel-server:

      ```bash
      sudo systemctl restart nfs-kernel-server
      ```

  -**NFS client**

  1. For every node install the NFS-client.

      ```bash
      sudo apt update
      sudo apt install nfs-common
      ```

  1. Mount the OpenSearch folder:

      ```bash
      sudo mount [NFSServerIP]:/var/nfs/opensearch /var/nfs/opensearch
      ```

      Example:

      ```bash
      sudo mount 166.206.186.146:/var/nfs/opensearch /var/nfs/opensearch
      ```

      > [!IMPORTANT]
      > Mounting the OpenSearch folder is not needed on the node with the nfs-server role.
  
  1. To make the mount permanently even after a server reboot, modify /etc/fstab.

      ```bash
      sudo nano /etc/fstab
      ```

  1. Add the following line:

      ```text
      [NFSServerIP]:/var/nfs/opensearch /var/nfs/opensearch nfs rw,_netdev,tcp 0 0
      ```
  
      Example:

      ```text
      166.206.186.146:/var/nfs/opensearch /var/nfs/opensearch nfs rw,_netdev,tcp 0 0
      ```
  
  1. Save by hitting CTRL+O, Enter, followed by CTRL+X.

  1. Test if the mounting succeeded by executing the following command:

      ```bash
      df -h
      ```

      In the output of this command, you should see the mount.

  1. Another test is creating a file:

      ```bash
      sudo touch /var/nfs/opensearch/test.txt
      ```

      This should create a file named test.txt which can be seen from any other NFS client.

      > [!TIP]
      > If required, contact your IT department to follow the NFS server setup procedure, as this step may otherwise be challenging. Further input on networking infrastructure may also be required.

      > [!TIP]
      > It is also possible to set up an NFS share on Windows and share it with the destination Linux system. See [Windows Server 2016 as an NFS server for Linux clients](https://blog.bobbyallen.me/2018/01/18/windows-server-2016-as-an-nfs-server-for-linux-clients/).

      > [!NOTE]
      >
      > - As this setup might be more challenging, we recommend that you set it up in advance.
      > - Be wary of read, write, and execute rights, firewall configurations, and the state of the NFS server service during the setup. For the machines that will act as NFS servers, make sure the firewall allows NFS traffic. You can use the following command for this: *sudo ufw allow nfs*.
      > - Make sure the OpenSearch user has enough rights to the folder to read, write, and execute its contents.

### Create a repository via OpenSearch Dashboards GUI

1. On the OpenSearch cluster, on all nodes, navigate to the *opensearch.yml* file. Open the file and set *path.repo* as your previously created shared folder.

1. In OpenSearch Dashboards go to Snapshot Management - Repositories:

   ![OpenSearch Dashboards - Repositories ](~/user-guide/images/OpenSearchDashboards_Repositories.png)

1. This will open a **Repositories Overview**:

   ![OpenSearch Dashboards - Repository Overview ](~/user-guide/images/OpenSearchDashboards_RepositoryOverview.png)

1.Click on the **Create repository** button. Give the repository a name and location. The repository type should be **Shared file system**. Finally click on the **Add** button.

1. In the **Repositories Overview** there should be a repository added if everything went fine.

### Create a repository via REST-API

1. Create a repository by executing the following PUT request in your client application(Elastic Vue, OpenSearch Dashboards,...):

   ```txt
   PUT /_snapshot/opensearchbackup
   {
     "type": "fs",
     "settings": {
       "location": "/var/nfs/opensearch"
     }
   }
   ```

   - "/var/nfs/opensearch": The path of the shared folder you created

   - "opensearchbackup": A repository name of your choice

   > [!TIP]
   > For more information see [Shared file system](https://opensearch.org/docs/2.8/tuning-your-cluster/availability-and-recovery/snapshots/snapshot-restore/#shared-file-system).

   > [!NOTE]
   > You can also use ElasticVue to create your repository: Go to *Snapshots* > *Snapshot Repositories*, and click the *New repository* button. Then fill in the name and the repository location, and leave the default settings untouched (i.e. *Compress* should be enabled, and *Readonly* should be disabled).

1. Verify whether the repository has been created correctly by entering the following GET request in your chosen client application.

   ```txt
   GET _snapshot/opensearchbackup
   ```

   If the repository was created correctly, the response returns repository information.

   Example:

   ```txt
   {
     "opensearchbackup" : {
       "type" : "fs",
       "settings": {
         "location": "/var/nfs/opensearch"
       }
     }
   }
   ```

   - "opensearchbackup": name of your snapshot repository

   - "fs": a file system repository

   - "/var/nfs/opensearch": the path where all snapshots are stored

   > [!TIP]
   > For more information, see [Get snapshot repository](https://opensearch.org/docs/latest/api-reference/snapshots/get-snapshot-repository/).

## Taking the snapshot

### Take snapshot via OpenSearch Dashboards GUI

1. In OpenSearch Dashboards go to **Snapshot Management**

   ![OpenSearch Dashboards - Snapshot Management](~/user-guide/images/OpenSearchDasbhoards_SnapshotManagement.png)

1. Next click on **Snapshots**, the **Snapshots** overview should be opened

   ![OpenSearch Dashboards - Snapshot Overview](~/user-guide/images/OpenSearchDashboards_SnapshotOverview.png)

1. Click on the **Take snapshot** button, below panel opens, fill in the snapshot-name, and select your repository you created earlier.

   ![OpenSearch Dashboards - Snapshot Overview](~/user-guide/images/OpenSearchDashboards_CreateSnapshot.png)

   > [!IMPORTANT]
   > As input source indexes or index patterns we recommend to use the asterisk sign: \*

1. Finally click on the **Add** button. You will go back to the **Snapshots** overview and a snapshot is being taken.

### Take snapshot via REST-API

1. Execute the following PUT request in your chosen client application:

   ```txt
   PUT /_snapshot/opensearchbackup/20230620
   {
   "indices": "*",
   "ignore_unavailable": true,
   "include_global_state": false,
   "partial": false
   }
   ```

   - "20230620": name for the snapshot

   - "opensearchbackup": name of your snapshot repository

   You can also add a request body to include or exclude certain indices or specify other settings. See [Take snapshots](https://opensearch.org/docs/2.8/tuning-your-cluster/availability-and-recovery/snapshots/snapshot-restore/#take-snapshots).

1. Verify that the snapshot was created successfully by entering the following GET request:

   ```txt
   GET /_snapshot/opensearchbackup/20230620
   ```

   The field next to *"state":* should display "SUCCESS".

You have now finished configuring an OpenSearch backup.

## Restoring the snapshot via REST-API

1. Ensure that the target OpenSearch cluster is empty.

1. To see all snapshots in your repository, execute:

   ```txt
   GET /_snapshot/opensearchbackup/_all
   ```

1. In the target OpenSearch cluster, execute the following POST request:

   ```txt
   POST /_snapshot/opensearchbackup/20230620/_restore
   ```

   You can also add a request body to include or exclude certain indices or specify other settings. See [Restore snapshots](https://opensearch.org/docs/2.8/tuning-your-cluster/availability-and-recovery/snapshots/snapshot-restore/#restore-snapshotss).

1. Verify whether the snapshot restore worked by comparing the indices for the local OpenSearch cluster with those of the target OpenSearch cluster.

   To do so, ...

   These indices should be identical and take up the same amount of space.

## Troubleshooting

1. Search the OpenSearch logging for exceptions.

   - For Linux: `/var/log/opensearch/[cluster.name].log`

     You can find the cluster name in `/etc/opensearch/opensearch.yml`.

   > [!TIP]
   > For more information, see [Logs](https://opensearch.org/docs/latest/monitoring-your-cluster/logs/).
