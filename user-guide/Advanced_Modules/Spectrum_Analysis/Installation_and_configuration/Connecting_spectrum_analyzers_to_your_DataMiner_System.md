---
uid: Connecting_spectrum_analyzers_to_your_DataMiner_System
---

# Connecting spectrum analyzers to your DataMiner System

Spectrum analyzers are usually connected to a DataMiner System via a GPIB gateway.

However, in case a Spectrum Analyzer is equipped with a TCP/IP interface, it can also be directly connected to the acquisition LAN.

![](~/user-guide/images/Spectrum_architecture.jpg)

If a GPIB gateway is used, the Agilent I/O libraries need to be installed. See [Installing the Keysight/Agilent IO Libraries](xref:Installing_the_Keysight_Agilent_IO_Libraries#installing-the-keysightagilent-io-libraries).

If the Spectrum Analyzer is connected using the [TCP/IP interface](xref:TCPIP_UDPIP_Connection), the setup during element creation is the same as for any other device using serial or SNMP communication. For more information on the element setup for a Spectrum Analyzer connected via a GPIB gateway, refer to [GPIB connections](xref:GPIB_Connection).
