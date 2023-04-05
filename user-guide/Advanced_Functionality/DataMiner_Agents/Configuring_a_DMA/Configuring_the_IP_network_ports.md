---
uid: Configuring_the_IP_network_ports
---

# Configuring the IP network ports

A DataMiner System makes extensive use of TCP/IP communication. Below, you find an overview of the TCP and UDP ports being used, as well as instruction on how to change port configurations. This information will especially prove useful when you have to configure firewalls in your network.

> [!NOTE]
> In new DataMiner installations from DataMiner 10.1.11/10.2.0 onwards, only the essential ports are opened by default (80, 8004, as well as 162 from DataMiner 10.1.12 onwards). To make use of DataMiner functionality that requires additional ports, you will need to manually create a firewall rule for those ports.

> [!TIP]
> See also: [DataMiner hardening guide](xref:DataMiner_hardening_guide)

## Overview of IP ports used in a DMS

| Protocol | Ports used | Application      |
|----------|------------|------------------|
| SNMP     | 161/udp<br> 162/udp | SNMP    |
| .Net Remoting  | Configurable port<br> Default port: 8004/tcp | Inter-DMA communication ([unless gRPC is configured instead](xref:DMS_xml#redirects-subtag))<br> DataMiner Cube ([unless gRPC is configured instead](xref:ConnectionSettings_txt#connectionsettingstxt-options))<br> Alerter |
| HTTP(S) | 80/tcp<br> 443/tcp | Inter-DMA communication ([if gRPC is configured](xref:DMS_xml#redirects-subtag))<br>DataMiner Cube<br> Alerter<br> Web apps (e.g. Monitoring, Jobs)<br> Dashboards, Reporter |
| HTTP(S) | 9200/tcp | Indexing Engine (server listening for client requests) |
| N/A     | 7000/tcp | Cassandra: non-TLS setup (inter-node communication in Failover setups) |
| N/A     | 7001/tcp | Cassandra: TLS setup (available from DataMiner 10.1.3 onwards) |
| N/A     | 7199/tcp | Cassandra cluster backups |
| N/A     | 9042/tcp | Cassandra (server listening for client requests) |
| N/A     | 9200/tcp | Elasticsearch |
| N/A     | 9300/tcp | Elasticsearch (inter-node communication) |
| Multiple protocols | 4222/tcp<br> 6222/tcp | NATS (required from DataMiner 10.1.1 onwards) |
| NAS    | 9090/tcp  | NATS Account Server (required from DataMiner 10.1.1 onwards) |
| HTTP(S) | 5100/tcp (internal) | [dataminer.services endpoint](xref:Custom_cloud_endpoint_configuration) hosted in [DataMiner CloudGateway](xref:DataMinerExtensionModules#cloudgateway) (by default required from DataMiner CloudGateway 2.10.0 onwards)
| Telnet | 23/tcp   | Stream (by default disabled from DataMiner 9.6.5 onwards) |

> [!NOTE]
>
> - When viewing Stream via DataMiner Cube, access to port 23/tcp is not required. Access is only required when using a Telnet client. However, note that Telnet is by default disabled from DataMiner 9.6.5 onwards. For more information on how to enable this, see [DataMiner.xml](xref:DataMiner_xml)
> - Prior to DataMiner 10.0.8, ports 7001, 7199, 9142 and 9160 are also opened during Cassandra installation. However, from DataMiner 10.0.8 onwards, only the essential ports 7000 and 9042 are opened.
> - Prior to DataMiner 10.1.0 CU10 and 10.2.1, port 8222 is also opened for NATS monitoring. However, this port is no longer used from those versions onwards and is no longer opened during new installations.

## Graphical representation of IP communication within a DMS

The diagram below shows how communication within a DMS could be set up. The blue lines indicate the communication towards the databases (in this case an Elasticsearch and Cassandra cluster of three nodes each).

![DMS communication overview](~/user-guide/images/dms_ip_communication_with_DB.png)

> [!NOTE]
> We do not recommend letting a DMA connect to another DMA via Web Services. From DataMiner 10.0.11, connecting via Web Services is no longer supported.

> [!TIP]
> See also:
>
> - [Configuring DMA communication settings in SLNet.exe.config](xref:Configuration_of_DataMiner_processes#configuring-dma-communication-settings-in-slnetexeconfig)
> - [Configuring client communication settings](xref:DMA_configuration_related_to_client_applications#configuring-client-communication-settings)
