---
uid: Preparing_the_two_DataMiner_Agents
---

# Preparing the two DataMiner Agents

Before you start the actual configuration, make sure you have the following:

- A primary DMA

- A backup DMA (newly installed)

- A pair of additional IP addresses or a hostname

  > [!NOTE]
  > To avoid possible conflicts, make sure these IP addresses are not used anywhere else and that these are reserved for the Failover pair.

## Primary DataMiner Agent

The primary DMA is a normal DataMiner Agent. In most cases, this will be an existing DMA that is a member of a DMS Cluster. It does not require any additional configuration.

## Backup DataMiner Agent

The backup DMA must be a newly installed DataMiner Agent.

- The DataMiner ID of this DMA must be identical to the DataMiner ID of the primary DMA.

  For more information on how to change the DataMiner ID, see [Changing the DataMiner ID of a DMA](xref:Changing_the_DMA_ID).

- The version of the DataMiner software on the backup DMA must be exactly the same as on the primary DMA.

- The backup DMA may not be a member of a DMS cluster.

## Additional IP addresses or hostname

When Failover is configured, one or two additional IP addresses are needed, depending on the number of network interfaces of the DMAs. These will be used as the virtual IP addresses of the primary or the backup DMA, depending on which of the two is online. If the DMAs only have one network interface, only one additional IP address is needed.

Alternatively, from DataMiner 10.2.0/10.1.8 onwards, a shared hostname can be used instead of the virtual IP addresses. This hostname must be configured in the network, i.e. a corresponding DNS record must exist. The hostname must resolve to both primary IP addresses of the Failover Agents. For example, this could be the output of an nslookup of such a hostname:

```txt
Name: ResetPlease.FailoverZone
Addresses: 10.11.5.52
 10.11.4.52
```

> [!IMPORTANT]
>
> - If your system has been configured to use HTTPS, make sure that the virtual IP addresses or shared hostname also have **signed certificates**. For more information, see [Setting up HTTPS on a DMA](xref:Setting_up_HTTPS_on_a_DMA).
>
>   As the setup of the certificates can be highly situational, for example in case proxies are involved, check with your IT services if you are not sure how to generate and deploy TLS/SSL certificates.
>
> - If a DMS already contains a DMA that was added based on its hostname or a Failover pair based on hostname, any Failover pairs you add to that DMS have to be configured based on hostname. Similarly, if a DMS already contains a Failover pair with virtual IP addresses, other Failover pairs in that same DMS also have to be configured with virtual IP addresses. This way you avoid mixing two different environments in one DMS. From DataMiner 10.2.0 [CU21]/10.3.0 [CU9]/10.3.12 onwards, such a mix of environments is not allowed.<!--RN 37075-->
