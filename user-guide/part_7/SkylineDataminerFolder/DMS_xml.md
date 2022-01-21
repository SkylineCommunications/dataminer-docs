---
uid: DMS_xml
---

## DMS.xml

This file contains a list of all DMAs in the DMS cluster.

- This file is located in the following folder:

    *C:\\Skyline DataMiner\\*

- Before you make changes to this file, always stop DataMiner. Restart DataMiner when your changes have been saved.

##### Example:

```xml
<DMS errorTime="30000">
  <DMA ip="10.12.11.1" id="111" timestamp=""/>
</DMS>
```

> [!NOTE]
> From DataMiner 10.2.0/10.1.6 onwards, the use of hostnames instead of IP addresses is supported in DMS.xml.

### Attributes of the DMS tag

| Attribute               | Description                                              | Default value |
|-------------------------|----------------------------------------------------------|---------------|
| errorTime               | DMA timeout                                              | 30000 ms      |
| pingCount               | Number of pings in connection check                      | 0             |
| pingTimeout             | Timeout of the connection check pings                    | 1000 ms       |
| connectionCheckTime     | Interval between two consecutive connection checks       | 20 seconds    |
| asynchronousTimeoutTime | Asynchronous call timeout                                | 60 seconds    |
| asynchronousRetries     | Number of retries before performing an asynchronous call | 4             |

### Failover subtag

If a Failover setup has been implemented in the DMS, a *Failover* subtag in the *DMS.xml* file contains the Failover configuration. To modify this configuration, go to the System Center in DataMiner Cube. See [Failover configuration in Cube](../../part_3/failover/Failover_configuration_in_Cube.md).

However, from DataMiner 9.6.1 onwards, an option is available that can only be configured directly in *DMS.xml*. This option makes the Agent that was previously online but now needs to go offline restart as quickly as possible, instead of waiting until all elements have been unloaded. To activate it, in the *\<Failover>* tag of the *DMS.xml* file, add the *bruteForceToOffline="true"* attribute, and then restart the DMA.
