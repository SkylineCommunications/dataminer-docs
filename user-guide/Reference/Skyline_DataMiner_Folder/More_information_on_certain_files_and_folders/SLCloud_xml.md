---
uid: SLCloud_xml
---

# SLCloud.xml

This XML file determines how DataMiner connects with the NATS cluster (from DataMiner 10.1.0/10.1.1 onwards, DataMiner uses NATS for inter-process communication). It is automatically added in the folder *C:\\Skyline DataMiner*.

## Increasing the timeout for the NATS connection

From DataMiner 10.2.0/10.1.5 onwards, you can configure the timeout of the connection to the NATS server in SLCloud.xml:

1. Stop DataMiner.

2. In the folder *C:\\Skyline DataMiner*, open the file *SLCloud.xml*.

3. Add and/or configure the *ConnectTimeout* element with a value in milliseconds. Minimum value: 1000. Lower values or non-numeric values will be ignored.

    ```xml
    <SLCLoud>
     <...>
     <ConnectTimeout>3000</ConnectTimeout>
     <...>
    </SLCloud>
    ```

4. Save your changes and restart DataMiner.

> [!NOTE]
> From DataMiner 10.3.11/10.3.0 [CU8] onwards<!--RN 37401-->, when DataMiner makes changes to the *SLCloud.xml* file, the old version of that file is saved in the *C:\Skyline DataMiner\Recycle Bin* folder.
