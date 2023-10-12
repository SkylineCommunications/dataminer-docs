---
uid: Azure_Managed_Instance_for_Apache_Cassandra
---

# Setting up an Azure Managed Instance for Apache Cassandra

From DataMiner 10.3.5/10.4.0 onwards<!-- RN 35830 -->, it is possible to use an Azure Managed Instance for Apache Cassandra as an alternative to a Cassandra cluster hosted on premises.

You will first need to [create your Azure Managed Instance for Apache Cassandra](#creating-your-azure-managed-instance-for-apache-cassandra), and then [connect your DataMiner System to the created instance](#connecting-your-dataminer-system-to-the-azure-managed-instance).

> [!NOTE]
> Microsoft uses Cassandra Reaper to do automatic repairs of your system. You do not need to set this up separately.

> [!TIP]
> For detailed information on Azure Managed Instance for Apache Cassandra, refer to the [Microsoft documentation](https://learn.microsoft.com/en-us/azure/managed-instance-apache-cassandra/).

## Supported Cassandra versions

DataMiner supports the same Cassandra versions as for an on-premises cluster. However, only the following versions are available on Azure:

- Cassandra 3.11
- Cassandra 4.0

## Creating your Azure Managed Instance for Apache Cassandra

1. Go to [Azure Portal](https://portal.azure.com) and log in.

1. Search for *Azure Managed Instance for Apache Cassandra*.

1. At the top of the window, click *Create*.

1. On the *Basics* page, specify the required information.

   To have low latency, you should select a region near your own or the region where your Azure VMs are running. The password that you configure is for the *Cassandra* user in the system.

1. Click *Next: Data center* and configure the kind of servers you want to use for your Cassandra cluster.

   The *Sku Size* defines which VM will be used (the more resources, the more expensive). You can then also select the number of disks and nodes that you want. The minimum number of nodes is 3.

1. If you want to configure a client certificate, click *Advanced* at the top.

   If you do not need to do this, you can add some tags to the setup so you can easily find it again, or go to the next step.

1. Go to the *Review + Create* page.

   Here, Azure will do some checks to see if everything has been configured correctly.

1. If everything is valid, click *Create*. Otherwise, adjust your configuration until Azure indicates that it is valid, and then click *Create*.

A pop-up window on the Azure website will now indicate that your cluster is being created. This can take a while.

Once the creation is finished, you will see your newly created cluster on the *Azure Managed Instance for Apache Cassandra* page.

## Connecting your DataMiner System to the Azure Managed Instance

1. Retrieve the necessary information from the Azure portal:

   1. Go to [Azure Portal](https://portal.azure.com) and log in.

   1. Go to *Azure Managed Instance for Apache Cassandra*.

   1. Select the cluster you want to connect your DataMiner System to.

   1. In the *Settings* menu, select *Data Center*.

   1. Click the arrow to open the data center, and copy the IP addresses DataMiner will need to connect to.

   > [!NOTE]
   > We recommend configuring all of the nodes in DataMiner. If a node should go down, DataMiner can then still connect to the other nodes.

1. Using the copied IP addresses, configure the [Cassandra cluster database in System Center](xref:Configuring_the_database_settings_in_Cube).

1. Stop DataMiner.

1. Open the [DB.xml](xref:DB_xml) configuration file.

1. Set the *TLSEnabled* tag to true in the file and save your changes:

   ```xml
   <TLSEnabled>True</TLSEnabled>
   ```

1. Restart DataMiner.
