---
uid: Forcing_a_DMA_to_work_without_virtual_IPs
---

# Forcing a DataMiner Agent to work without virtual IP addresses

In the file *DataMiner.xml*, you can order a DataMiner Agent not to use virtual IP addresses.

To do so:

1. Stop DataMiner.

1. Open the file *C:\\Skyline Dataminer\\DataMiner.xml.*

1. Add a *disableElementIP* attribute to the *\<DataMiner>* tag, and set it to “true”.

   By default, the *disableElementIP* attribute is set to “false”.

1. Save the file and restart DataMiner.

> [!NOTE]
> If the *disableElementIP* attribute is set to “true”, after a restart of the DataMiner Agent, it will no longer be possible to assign a virtual IP address to an element. Moreover, the virtual IP addresses of all existing elements will be disabled.

Example:

```xml
<DataMiner disableElementIP="true" >...</DataMiner>
```
