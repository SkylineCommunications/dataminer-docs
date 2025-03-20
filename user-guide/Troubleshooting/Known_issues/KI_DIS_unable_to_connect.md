---
uid: KI_DIS_unable_to_connect
---

# DIS unable to connect to DataMiner Agent

## Affected versions

DIS 3.1.6

## Cause

DIS 3.1.6 introduces features that make use of additional web API endpoints, such as importing a dashboard or low-code app solution from a DataMiner Agent. This connection depends on a trusted certificate to establish a secure link. If the certificate cannot be validated, an exception may occur, preventing the connection from being established.

## Fix

Install the latest DIS release (3.1.7 or higher).

## Description

When using DIS 3.1.6, connecting to a DataMiner Agent fails with an error message similar to one of the following examples:

```txt
System.ServiceModel.FaultException: 
System.Net.Http.HttpRequestException: An error occurred 
while sending the request. —> System.Net.WebException: 
The underlying connection was closed: Could not establish 
trust relationship for the SSL/TLS secure channel.
```

```txt
Could not connect to DMA! : System.ServiceModel.FaultException: System.ServiceModel.FaultException: System.Net.Http.HttpRequestException: Response status code does not indicate success: 404 (Not Found).
   at System.Net.Http.HttpResponseMessage.EnsureSuccessStatusCode()
   at SLDisDMAComm.SLDisDmaCommService.ConnectToWebApi() in D:\a\DIS\DIS\ProtocolEditor\SLDisDMAComm\SLDisDmaCommService.cs:line
```
