---
uid: Configuring_the_necessary_tags_in_DataMiner_xml
---

# Configuring the necessary tags in DataMiner.xml

1. If you want the DMA to forward alarm events via a particular TCP/IP socket, add an [AlarmSocket](xref:DataMiner.AlarmSocket) tag and specify the socket in the *port* attribute.

   Example:

   ```xml
   <AlarmSocket port="5000"/>
   ```

1. If you want to allow the DMA to forward information about elements and parameters when it receives a request on a particular TCP/IP socket, add a [PollSocket](xref:DataMiner.PollSocket) tag and specify the socket in the *port* attribute.

   Example:

   ```xml
   <PollSocket port="5025"/>
   ```

1. Save the *DataMiner.xml* file and restart the DataMiner software.

> [!NOTE]
> The *DataMiner.xml* file is not synchronized throughout the DataMiner System. It is unique for each DMA. As a result, you can have different socket configurations on each of your DMAs.
