---
uid: KI_DataMinerMessageBroker_TLS
---

# TLS Authentication issues when Messagebroker is connecting to the NATS bus

## Affected versions

DataMiner systems migrated to BrokerGateway managed NATS.

## Cause

An issue can occur with DataMinerMessageBroker not being able to connect to the NATS bus due to Windows its SChannel library not recognising the certificates that NATS is using.

## Fix

Install DataMiner 10.5.0 CU11 /10.6.0<!--RN 44195-->.

A workaround is *copying* "C:\ProgramData\Skyline Communications\DataMiner Security\ca.pem" and renaming the copied file to "ca.crt". 
Open it and install the certificate with the install location on local machine and the rest as default settings.
Keep in mind that this workaround will break again when a DMA is removed from the DMS.

## Description

When using DataMinerMessageBroker on a DataMiner system that is migrated to Brokergateway, it is possible that it cannot connect due to the certificates not being recognised by Windows.
The following error will be visible in the logs or in the alarmconsole:
DataMinerMessageBroker.API.Exceptions.SessionException: Unable to create connection with endpoints nats://<IP>:4222 ---> NATS.Client.NATSConnectionException: TLS Authentication error ---> System.AggregateException: One or more errors occurred. ---> System.IO.IOException: Unable to read data from the transport connection: An existing connection was forcibly closed by the remote host. ---> System.Net.Sockets.SocketException: An existing connection was forcibly closed by the remote host
