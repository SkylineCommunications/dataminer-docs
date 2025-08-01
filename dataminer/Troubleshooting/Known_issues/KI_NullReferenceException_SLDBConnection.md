---
uid: KI_NullReferenceException_SLDBConnection
---

# Null reference exceptions in SLDBConnection.txt and unhandled exception when retrieving Correlation details

## Affected versions

- DataMiner Main Release versions from 10.1.0 onwards up to 10.2.0 [CU10]
- DataMiner Feature Release versions from 10.1.2 onwards up to 10.3.1

## Cause

In a DMS using a Cassandra cluster setup, composite storage types are used for alarms and information events. However, some SLDataGateway requests were not properly rerouted to these types.

## Fix

Install DataMiner 10.2.0 [CU11], 10.3.0, or 10.3.2.

## Issue description

In systems with a [Cassandra cluster](xref:Supported_system_data_storage_architectures) setup, there could be null reference exceptions in the *SLDBConnection.txt* log file. For example:

```txt
SLDBConnection|Skyline.DataMiner.Net.Messages.SLDataGateway.DataRequest`1[Skyline.DataMiner.Net.Messages.SLDataGateway.Alarm]|INF|0|285|System.NullReferenceException: Object reference not set to an instance of an object.
   at SLCassandraClassLibrary.DBGateway.DBGateway.ExecuteRequest[T](DataRequest`1 request)
   at SLCassandraClassLibrary.DBGateway.IncomingConnection.$_executor_ExecuteRequest(BaseRequest request)
```

Depending on the type of request and the storage type (*Alarm* or *Info*), different stack traces were possible. For example:

```txt
|SLDBConnection|Skyline.DataMiner.Net.Messages.SLDataGateway.DataRequest`1[Skyline.DataMiner.Net.Messages.SLDataGateway.Info]|INF|0|94|System.NullReferenceException: Object reference not set to an instance of an object.
   at SLCassandraClassLibrary.DBGateway.DBGateway.ExecuteRequest[T](DataRequest`1 request)
   at System.Dynamic.UpdateDelegates.UpdateAndExecute2[T0,T1,TRet](CallSite site, T0 arg0, T1 arg1)
   at SLCassandraClassLibrary.DBGateway.IncomingConnection.$_executor_ExecuteRequestStatic(BaseRequest request)
```

These exceptions could cause further problems with the process taking care of the request. This was especially noticeable when SLNet retrieved Correlation details. This resulted in errors in the Alarm Console. For example:

```txt
Unexpected Exception [Object reference not set to an instance of an object.]: Get Correlation Details for 39110/8231242 (   at Skyline.DataMiner.Net.SLDataGateway.DataGateway.SendMessage[TReq,TResp](TReq request, String method, Nullable`1 timeout)
   at Skyline.DataMiner.Net.SLDataGateway.DataGateway.ExecuteRequest(BaseRequest request)
   at Skyline.DataMiner.Net.Facade.HandleClientRequestMessage(IConnectionInfo connInfo, ClientRequestMessage oneMsg, Boolean canQueue)
   ...
```
