---
uid: Configuring_the_TCP-IP_socket_settings
---

# Configuring the TCP-IP socket settings

If you want a DataMiner Agent to forward information to third-party applications via TCP/IP sockets, you have to [configure the socket settings in the *DataMiner.xml* file](xref:Configuring_the_necessary_tags_in_DataMiner_xml), which is located in the DMA's `C:\Skyline DataMiner\` directory.

> [!NOTE]
> If an AlarmSocket or PollSocket is used, the forwarded data will be encoded as UTF-8. The data sent to the PollSocket must also be encoded using UTF-8.
