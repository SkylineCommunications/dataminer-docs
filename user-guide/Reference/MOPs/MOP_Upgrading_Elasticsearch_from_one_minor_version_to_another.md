---
uid: MOP_Upgrading_Elasticsearch_from_one_minor_version_to_another
---

# Upgrading Elasticsearch from one minor version to another

## Introduction

For reasons of security or stability, it can be useful to upgrade Elasticsearch from one **minor version** to another (e.g. from version 6.8.X to version 6.8.Y). This article contains detailed instructions for this upgrade.

These instructions are only intended for Elasticsearch setups on **Microsoft Windows**. For setups on Linux systems, see [Rolling upgrades | Elasticsearch Guide [6.8] | Elastic](https://www.elastic.co/guide/en/elasticsearch/reference/6.8/rolling-upgrades.html). If you are comfortable with Linux systems, you can follow the instructions below and translate each operation to the correct Linux counterpart.

> [!NOTE]
> Make sure that when you reinstall Elasticsearch, you keep the old `/config` folder and do not remove the `path.data` location.

## Requirements

Access to the server with administrator rights. This requires a connection dedicated completely or partially to this procedure, via VPN or local network.

## Procedure

### Performing a rolling upgrade (optional)

If you prefer to perform a rolling upgrade, i.e. upgrade one node at a time, make sure to perform step 1 and 2 of [Rolling upgrades | Elasticsearch Guide [6.8] | Elastic](https://www.elastic.co/guide/en/elasticsearch/reference/6.8/rolling-upgrades.html#rolling-upgrades). This will ensure that there is no unnecessary internet traffic while upgrading.

### Downloading the binaries

Download the Windows binaries from the official Elasticsearch website:

- [Past Releases of Elastic Stack Software | Elastic](https://www.elastic.co/downloads/past-releases#elasticsearch)

At the time when this article is published, this is the latest version to be used in conjunction with DataMiner:

- [Elasticsearch 6.8.23 | Elastic](https://www.elastic.co/downloads/past-releases/elasticsearch-6-8-23)
- [Direct windows download link 6.8.23.zip](https://artifacts.elastic.co/downloads/elasticsearch/elasticsearch-6.8.23.zip)

### Making a copy of the necessary files

Take a copy of the `config` folder, which can usually be found in `C:\Program files\elasticsearch`. If you want to keep the old configuration, then it is necessary to take a copy of the entire folder. When TLS is enabled, only copying the *elasticsearch.yml* file will not suffice. Copying the entire folder will ensure that the TLS settings are copied as well.

If TLS is configured, locate the certification files and the root CA file (if generated, they may be found in the `elasticsearch\bin` or `elasticsearch\config` folder), take a backup of these files or make sure they are not deleted during the upgrade process. For more information on these generated files, see [Securing the Elasticsearch database](xref:Security_Elasticsearch).

### Performing the actual upgrade

In the instructions below, we assume that Elasticsearch is installed in `C:\Program Files\Elasticsearch`. If your Elasticsearch installation uses a custom path, make sure to use that path instead.

After the necessary backup copies have been taken, as mentioned above, proceed as follows:

1. Stop the Elasticsearch service.

   If the node is running on the same server as DataMiner, you may need to disable the service instead, as DataMiner will otherwise attempt to restart it.

1. Delete the contents of `C:\Program Files\Elasticsearch`, but make sure to **keep the config, kibana and java folders** if these are present.

   > [!CAUTION]
   > Make sure that the `path.data` folder does not get removed. This folder is defined in the *elasticsearch.yml* file.

1. Place the new, unzipped binaries in the `C:\Program files\Elasticsearch` folder. You should now again have a `C:\Program files\Elasticsearch\bin` subfolder.
1. Restore the copy of the config folder and its contents to `C:\Program Files\Elasticsearch\config`. You can overwrite all the new files with your old config folder and files.
1. Start the Elasticsearch node.
1. If you followed the rolling upgrade guide, go to step 8 of that guide: [Rolling upgrades | Elasticsearch Guide [6.8] | Elastic](https://www.elastic.co/guide/en/elasticsearch/reference/6.8/rolling-upgrades.html#rolling-upgrades).

### Verifying the upgrade

Once the Elasticsearch node has restarted, it should be up and running again with the new version. You can verify this by going to `http://IP:9200/` and checking *version > number*.

Note that as the upgrade procedure above does not reinstall the Elasticsearch service, Windows services will still mention the previous Elasticsearch version in the service description.

If you want to check whether the node has correctly entered the cluster, go to `http://IP:9200/_cat/nodes` and check if all nodes are present.

If you want to check if all data is still present, go to `http://IP:9200/_cat/indices`. If TLS is enabled, replace *http* by *https*.

## Time estimate

| Item | Activity | Duration |
|------|----------|----------|
| 1    | Downloading the binaries             | 5 min.           |
| 2    | Making a copy of the necessary files | 5 min. per node  |
| 3    | Performing the upgrade               | 5 min. per node  |
| 4    | Verifying the upgrade                | 5 min. per node  |
