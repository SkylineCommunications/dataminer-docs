---
uid: Azure_Managed_Instance_for_Apache_Cassandra
---

# Azure Managed Instance for Apache Cassandra

From DataMiner 10.3.5 onwards, it is possible to use Azure Managed Instance for Apache Cassandra on Azure as an alternative to an on-prem hosted Cassandra cluster.

> [!NOTE]
> Microsoft uses Cassandra Reaper to do automatically repairs of your system. No need to set this up seperatly.

> [!TIP]
> Full informationon Azure Managed Instance for Apache Cassandra can be found on the website of [Microsoft](https://learn.microsoft.com/en-us/azure/managed-instance-apache-cassandra/).

## Compatibility

We support the same versions as we do for Cassandra Cluster on-prem, however versions are limited on Azure.

- Cassandra 3.11
- Cassandra 4.0

## Creating your Azure Managed Instance for Apache Cassandra

1. Go to [Azure Portal](https://portal.azure.com) and log in.

1. Search for Azure Managed Instance for Apache Cassandra.

1. At the top of the screen click on **Create**.

1. On the **Basics** page, give in the needed information that is required. In order to have low latency, it's best to select a region near your, or the region where your Azure VM's are running. The password that you configure is for the **Cassandra** user in the system.

1. Continue by clicking **Next: Data center** and configure the kind of servers you want to use for your Cassandra cluster. The **Sku Size** defines what VM will be used, the more resources the more expensive. You can then also select the amount of disks and nodes that you want. The minimal amount of nodes is 3.

1. If you want to configure a client certificate, you can click on **Advanced** at the top. If you don't need to do this, you can add some **Tags** to the setup so you can easily find it again, or go directly to **Review + Create**.

1. On the **Review + Create** page, Azure will do some checks to see if everything is valid. If everything is valid, you'll be able to click on the button **Create**.

1. You'll now receive a popup on the Azure website that your cluster is being created, note that this can take a while.

1. Once the creation is finished you'll see your newly created cluster on the page of **Azure Managed Instance for Apache Cassandra**.

## Connect to the cluster using DataMiner

You are now able to Configure the Cassandra cluster database in System Center. See [Configuring the database settings in Cube](xref:Configuring_the_database_settings_in_Cube).

To do this, some information from the Azure portal is needed.

### Get IP-addressess of the Cassandra Cluster

1. Go to Azure Managed Instance for Apache Cassandra.

1. Select your cluster you want to configure in DataMiner.

1. In the **Settings** menu, choose **Data Center**.

1. Click on the arrow to open the Data Center.

1. Here you can see the IP Addressess to connect to.

> [!NOTE]
> It's best to configure all of the nodes in DataMiner. If a node should go down, DataMiner can still connect to the other nodes.
