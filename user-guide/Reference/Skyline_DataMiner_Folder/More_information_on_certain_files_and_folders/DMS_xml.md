---
uid: DMS_xml
---

# DMS.xml

This file contains a list of all DMAs in the DMS cluster.

- This file is located in the folder *C:\\Skyline DataMiner\\*.

- Before you make changes to this file, always **stop DataMiner**. Restart DataMiner when your changes have been saved.

Example:

```xml
<DMS errorTime="30000">
  <DMA ip="10.12.11.1" id="111" timestamp=""/>
</DMS>
```

> [!NOTE]
> From DataMiner 10.2.0/10.1.6 onwards, the use of hostnames instead of IP addresses is supported in DMS.xml.

> [!IMPORTANT]
> Only some of the tags of DMS.xml are explained on this page, because the configuration in this file should ideally only ever be modified through DataMiner Cube (mainly via System Center > *Agents*).

## Attributes of the DMS tag

| Attribute               | Description                                              | Default value |
|-------------------------|----------------------------------------------------------|---------------|
| errorTime               | DMA timeout                                              | 30000 ms      |
| pingCount               | Number of pings in connection check                      | 0             |
| pingTimeout             | Timeout of the connection check pings                    | 1000 ms       |
| connectionCheckTime     | Interval between two consecutive connection checks       | 20 seconds    |
| asynchronousTimeoutTime | Asynchronous call timeout                                | 60 seconds    |
| asynchronousRetries     | Number of retries before performing an asynchronous call | 4             |

## Redirects subtag

From DataMiner 10.3.0/10.3.2 onwards, this subtag can be used to make the DMAs in a DMS communicate with each other over **gRPC** instead of .NET Remoting. This uses the standard HTTPS port 443 by default. <!-- RN 34983 -->

Redirects must be added in *DMS.xml* for each DMA. Failover Agents also need a redirect to each other's IP address.

You can either configure this directly in *DMS.xml*, or configure it by [implementing connection strings via the SLNetClientTest tool](xref:SLNetClientTest_editing_connection_string). If you use SLNetClientTest tool, no DataMiner restart will be needed.

For example, in a cluster with two DMAs, with IPs 10.4.2.92 and 10.4.2.93, DMS.xml can be configured as follows.

- On the DMA with IP 10.4.2.92:

```xml
  <DMS errorTime="30000" synchronized="true" xmlns="http://www.skyline.be/config/dms">
     <Cluster name="pluto"/>
     <DMA ip="10.4.2.92" timestamp=""/>
     <DMA ip="10.4.2.93" id="35" timestamp="2023-01-05 01:24:38" contacted_once="TRUE" lostContact="2023-01-06 00:45:01"/>
     <Redirects>
        <Redirect to="10.4.2.93" via="https://10.4.2.93/APIGateway" user="MyUser" pwd="MyPassword"/>
     </Redirects>
  </DMS>
```

- On the DMA with IP 10.4.2.93:

```xml
  <DMS errorTime="30000" synchronized="true" xmlns="http://www.skyline.be/config/dms">
     <Cluster name="pluto" synchronize="" timestamp="2022-12-13 12:48:29"/>
     <DMA ip="10.4.2.93" timestamp="" contacted_once="" lostContact=""/>
     <DMA ip="10.4.2.92" timestamp="2023-01-03 23:38:42" contacted_once="TRUE" lostContact="2023-01-06 01:02:00" id="69" uri=""/>
     <Redirects>
        <Redirect to="10.4.2.92" via="https://10.4.2.92/APIGateway" user="MyUser" pwd="MyPassword"/>
     </Redirects>
  </DMS>
```

> [!NOTE]
>
> - The passwords in the *pwd* attribute are encrypted and replaced with an encryption token when they are first read out by DataMiner.
> - You can also disable .NET Remoting for inter-DMA communication in *MaintenanceSettings.xml* instead. See [Disabling .NET Remoting](xref:Configuration_of_DataMiner_processes#disabling-net-remoting).

> [!TIP]
> See also: [DataMiner hardening guide](xref:DataMiner_hardening_guide)

## Failover subtag

If a Failover setup has been implemented in the DMS, a *Failover* subtag in the *DMS.xml* file contains the Failover configuration. To modify this configuration, go to the System Center in DataMiner Cube. See [Failover configuration in Cube](xref:Failover_configuration_in_Cube).

However, prior to DataMiner 10.2.0 \[CU5]/10.2.8 and from DataMiner 9.6.1 onwards, an option is available that can only be configured directly in *DMS.xml*. This option makes the Agent that was previously online but now needs to go offline restart as quickly as possible, instead of waiting until all elements have been unloaded. To activate it:

1. Stop the DMA.

1. Add the *bruteForceToOffline="true"* attribute in the *\<Failover>* tag of the *DMS.xml* file, and save the file

1. Restart the DMA.

> [!NOTE]
> From DataMiner 10.2.0 \[CU5]/10.2.8 onwards, this should be configured in Cube instead. See [Advanced Options](xref:Advanced_Failover_options#advanced-options)
