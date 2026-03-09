---
uid: KI_DataMinerMessageBroker_TLS
---

# TLS authentication issues when MessageBroker is connecting to the NATS bus

## Affected versions

DataMiner Systems migrated to BrokerGateway-managed NATS.

## Cause

An issue can occur with DataMiner MessageBroker not being able to connect to the NATS bus because the Windows SChannel library does not recognize the certificates used by NATS.

## Workaround

1. [Download BrokerGateway 1.9.5.23100](https://community.dataminer.services/download/dataminer-brokergateway-1-9-5-23100-msi/) and install this MSI on each server to update BrokerGateway.
   
1. Once the update is complete, run `C:\Skyline DataMiner\Tools\NATSRepair.exe`.

Alternatively, this repair action can be done manually:
   
1. Copy `C:\ProgramData\Skyline Communications\DataMiner Security\ca.pem` and rename the copied file to `ca.crt`.

1. Open the file and install the certificate, setting the install location to the local machine and keeping the default settings.

Keep in mind that without the BrokerGateway update, this workaround may break again when a DMA is removed from the DMS.

## Fix

Install DataMiner 10.5.0 [CU11]/10.5.12 [CU2]/10.6.0.<!--RN 44195-->

## Description

When DataMiner MessageBroker is used on a DataMiner System that has been migrated to BrokerGateway-managed NATS, it can occur that MessageBroker cannot connect because the certificates are not recognized by Windows.

The following error will be shown in the logs or in the Alarm Console:

```txt
DataMinerMessageBroker.API.Exceptions.SessionException: Unable to create connection with endpoints nats://<IP>:4222 
---> NATS.Client.NATSConnectionException: TLS Authentication error ---> System.AggregateException: One or more errors occurred. 
---> System.IO.IOException: Unable to read data from the transport connection: An existing connection was forcibly closed by the remote host. 
---> System.Net.Sockets.SocketException: An existing connection was forcibly closed by the remote host
```
