---
uid: Preparing_the_two_DataMiner_Agents
---

# Preparing the two DataMiner Agents

Before you start the actual configuration, make sure you have the following:

- A [primary DMA](#primary-dataminer-agent)

- A [backup DMA](#backup-dataminer-agent) (newly installed; see [Installation with the DataMiner Installer](xref:Installing_DM_using_the_DM_installer) or [Installation with pre-installed DataMiner Virtual Hard Disk](xref:Using_a_pre_installed_DataMiner_Virtual_Hard_Disk))

- A [pair of additional IP addresses or a hostname](#additional-ip-addresses-or-hostname)

  > [!NOTE]
  > If you use IP addresses instead of a hostname:
  >
  > - Make sure [Npcap](https://nmap.org/npcap/) or WinPcap (deprecated) is installed on both DMAs. From DataMiner 10.4.10/10.5.0 onwards<!--RN 40257 + RN 40267-->, you can check whether this is installed via *System Center* > *Agents* > *Failover*. This will open the *Failover Config* window, where an information icon will be displayed next to *Failover (Virtual IP)* in case neither of these is installed or no valid installation could be detected on the DMA you are currently connected to. Hover the mouse pointer over this icon for more detailed information.
  > - To avoid possible conflicts, make sure the IP addresses are not used anywhere else and that these are reserved for the Failover pair.

In addition, make sure the [required ports are opened](#opening-the-required-ports), and the [database is prepared](#preparing-the-database).

> [!IMPORTANT]
> The [Swarming](xref:Swarming) feature must not be enabled on either of the DMAs, as Failover is not supported in combination with Swarming.

## Primary DataMiner Agent

The primary DMA is a normal DataMiner Agent. In most cases, this will be an existing DMA that is a member of a DMS cluster. It does not require any additional configuration.

For a brand-new Failover pair where the primary DMA is not yet part of a cluster, first add the primary DMA to the cluster using its physical IP before you set up Failover.

## Backup DataMiner Agent

The backup DMA must be a newly installed DataMiner Agent.

If you are adding a brand-new Failover pair to a cluster, you do not need to add the backup DMA to the cluster yourself. Once the Failover setup is complete, it will be added automatically.

- The DataMiner ID of this DMA must be identical to the DataMiner ID of the primary DMA.

  For more information on how to change the DataMiner ID, see [Changing the DataMiner ID of a DMA](xref:Changing_the_DMA_ID).

- The version of the DataMiner software on the backup DMA must be exactly the same as on the primary DMA.

- The backup DMA may not be a member of a DMS cluster.

## Additional IP addresses or hostname

When Failover is configured, one or two additional IP addresses are needed, depending on the number of network interfaces of the DMAs. These will be used as the virtual IP addresses of the primary or the backup DMA, depending on which of the two is online. If the DMAs only have one network interface, only one additional IP address is needed.

Alternatively, from DataMiner 10.2.0/10.1.8 onwards, a shared hostname can be used instead of the virtual IP addresses. This hostname must be configured in the network, i.e. a corresponding DNS record must exist that can be resolved from the hostname to both primary IP addresses of the Failover Agents and vice versa with a reverse lookup. For example, this could be the output of an nslookup of such a hostname and IP:

```txt
Name: ResetPlease.FailoverZone
Addresses: 10.11.5.52
 10.11.4.52
```

> [!IMPORTANT]
>
> - If your system has been configured to use HTTPS, make sure that the virtual IP addresses or shared hostname are configured in the **HTTPS tag** of *MaintenanceSettings.xml* and also have **signed certificates**. For more information, see [Setting up HTTPS on a DMA](xref:Setting_up_HTTPS_on_a_DMA).
>
>   As the setup of the certificates can be highly situational, for example in case proxies are involved, check with your IT services if you are not sure how to generate and deploy TLS/SSL certificates.
>
> - If a DMS already contains a DMA that was added based on its hostname or a Failover pair based on hostname, any Failover pairs you add to that DMS have to be configured based on hostname. Similarly, if a DMS already contains a Failover pair with virtual IP addresses, other Failover pairs in that same DMS also have to be configured with virtual IP addresses. This way you avoid mixing two different environments in one DMS. From DataMiner 10.2.0 [CU21]/10.3.0 [CU9]/10.3.12 onwards, such a mix of environments is not allowed.<!--RN 37075-->

## Opening the required ports

To ensure that the primary and backup DMA can communicate, make sure that both DMAs have the required ports mentioned under [Configuring the IP network ports](xref:Configuring_the_IP_network_ports).

Make sure that packets to and from these ports coming from the virtual IP address or the shared hostname are not dropped by the network.

## Preparing the database

Each [supported system data storage architecture](xref:Supported_system_data_storage_architectures) has a different way of handling the setup of a Failover system. Below you can find the measures that need to be taken for each of the supported architectures.

### Storage as a Service

If you want to add the Failover pair to a DataMiner System that uses STaaS, first make sure the primary DMA has been added as detailed under [Adding a DMA to a DMS running STaaS](xref:Adding_a_DMA_to_a_DMS_running_STaaS). Then follow the same steps for the backup DMA, but skip the step where you actually join the DMA to the cluster.

### Dedicated clustered storage

1. Make sure that the Agents to be added can reach the Cassandra cluster through ports 9042 or 9142 when using TLS.

1. Make sure that the Agents to be added can reach the OpenSearch or Elasticsearch cluster through port 9200.

1. Double-check that there are no elements or alarms on the backup DMA to ensure that no conflicts happen when joining the DMAs. The backup DMA must be a newly installed, blank Agent.

1. Stop the backup DMA, and then copy the database configuration from the primary DMA to the backup DMA:

   1. On the primary DMA, open `C:\Skyline DataMiner\DB.xml`.

   1. Copy the contents of the `DataBases` tag.

   1. Paste this content in the file `C:\Skyline DataMiner\db.xml` on the backup DMA.

      > [!IMPORTANT]
      > If multiple [OpenSearch clusters](xref:Configuring_multiple_OpenSearch_clusters) or [Elasticsearch clusters](xref:Configuring_multiple_Elasticsearch_clusters) are used prior to DataMiner 10.4.0/10.4.2, there is an additional file that needs to be copied from the primary to the backup DMA. You can find this *DBConfiguration.xml* file in the folder `C:\Skyline DataMiner\Databases\`. Make sure you also do this while the backup Agent is stopped.

      > [!NOTE]
      > If multiple [OpenSearch clusters](xref:Configuring_multiple_OpenSearch_clusters) or [Elasticsearch clusters](xref:Configuring_multiple_Elasticsearch_clusters) are used, you may wish to configure the *priorityOrder* attribute differently on the main or backup DMA. You can do this if you want to change which indexing cluster is read from when there is a Failover switch. For more info on the *priorityOrder* attribute, see [OpenSearch clusters](xref:Configuring_multiple_OpenSearch_clusters) or [Elasticsearch clusters](xref:Configuring_multiple_Elasticsearch_clusters).

   1. In the `PWD` tags, replace the GUID reference with the password in plain text.

      During the next startup, DataMiner will encrypt this password again and replace it with a placeholder GUID.

   1. Restart the backup DMA.

1. If TLS is used, make sure that the required certificates are imported, and this is correctly configured on the backup DMA as well.

   - For Cassandra see [Encryption in Cassandra](xref:Security_Cassandra_TLS).

   - For OpenSearch, see [Securing the OpenSearch database](xref:Security_OpenSearch).

   - For Elasticsearch (deprecated) see [Securing the Elasticsearch database](xref:Security_Elasticsearch).

### Separate Cassandra setup with indexing

We **recommend against this setup** for Failover. With this setup, it is possible that if one node goes down, all data in the indexing database is unavailable.

If you do go ahead with this, take into account that the the indexing database will automatically create a cluster of two nodes: one for the primary DMA and one for the backup DMA. To ensure this can happen, make sure that **ports 9200 and 9300** are open between primary and backup DMA so the databases can communicate. See [Configuring the IP network ports](xref:Configuring_the_IP_network_ports).

For Cassandra, you will need to take the same steps as detailed below for a [separate Cassandra setup without indexing](xref:Preparing_the_two_DataMiner_Agents#separate-cassandra-setup-without-indexing).

### Separate Cassandra setup without indexing

When you set up Failover, DataMiner will automatically attempt to add Cassandra to a cluster of two Cassandra nodes, one for the primary DMA and one for the backup DMA. To make sure this can happen correctly, follow the steps below before you attempt to set up Failover:

1. Make sure that Cassandra is installed and running on both DataMiner Agents, by opening *Windows Services* and checking whether the *cassandra* service exists and is running.

   > [!NOTE]
   > If Cassandra is not installed yet, for instance because you used an older DataMiner installer that still installs MySQL, you will first need to [migrate the database to Cassandra](xref:Migrating_the_general_database_to_Cassandra).

1. If Cassandra is running, open an *elevated command window* and navigate to `C:\Program Files\Cassandra\bin`.

1. In this folder, execute the command *nodetool version*.

1. Make sure the output of this command is the same for both DMAs.

   For example, if the command returns "**ReleaseVersion: 3.7**", the other node must also return "**ReleaseVersion: 3.7**". If one of the DMAs has a lower release version, update the Cassandra node so it uses the same version (see *On Windows* under [Updating Cassandra](xref:Cassandra_updating)).

1. Make sure that between the primary and backup DMA, **port 7000 and port 9042** are open to allow the databases to communicate as mentioned under [Configuring the IP network ports](xref:Configuring_the_IP_network_ports).

### Legacy setup with MySQL or MSSQL database

DataMiner will automatically synchronize the configuration and subsequently its data. No steps are necessary to prepare for this.

To check the data synchronization state after you have set up Failover, see [Synchronizing the DMA databases](xref:Synchronizing_the_DMA_databases).

> [!NOTE]
> From DataMiner 10.3 onwards, this setup is no longer supported. See [Third-party software support life cycle](xref:Software_support_life_cycles#third-party-software-support-life-cycle)

## Preparing authentication and user provisioning

DataMiner supports SAML using different identity providers, such as [Okta](xref:SAML_using_Okta), [Microsoft Entra ID](xref:SAML_using_Entra_ID), and [Azure B2C](xref:SAML_using_Azure_B2C).

If SAML authentication is used on the primary DMA, you will need to ensure that the configuration also exists on the backup DMA. For this, the configuration of the backup Agent must be made to mirror the configuration on the primary DMA:

1. Make sure the backup DMA is stopped.

1. On the primary DMA, open `C:\Skyline DataMiner\DataMiner.xml`.

1. Copy the relevant tags such as the *\<ExternalAuth\>* and *\<AzureAD\>* tags, depending on the identity provider used, from the primary DMA's *DataMiner.xml*.

   This includes a reference to the place where the identity provider's *ipMetaData.xml* file is stored. This file is usually stored on the identity provider and is filled in as a URL in DataMiner.xml.

   > [!NOTE]
   > To identify which tags are required for your specific setup, refer to [Configuring SAML settings](xref:Configuring_external_authentication_via_an_identity_provider_using_SAML). Make sure that both authentication and user provisioning are taken into consideration.

1. On the backup DMA, open `C:\Skyline DataMiner\DataMiner.xml` and paste the copied tags where appropriate.

1. In case the *ipMetaData.xml* file is located on the primary DMA instead of referenced by URL in *DataMiner.xml*, copy this file to the same location on the backup DMA as is referenced in *DataMiner.xml*.

1. On the primary DMA, locate the file `C:\Skyline DataMiner\spMetaData` and copy it to the same location on the backup DMA.

   For information on the *spMetaData* file, refer to [Microsoft Entra ID or Azure B2C](xref:SAML_using_Entra_ID#creating-a-dataminer-metadata-file) or [Okta](xref:SAML_using_Okta), depending on your setup.

1. Start the backup DMA.

> [!IMPORTANT]
> While you do this, also make sure that that the identity provider has a reference to the address representing the online DMA. If it refers to the DMS via an IP address, make sure that the identity provider refers to the **virtual IP address** (i.e. the IP address that represents the online DMA) instead of a DMA's private IP address.
