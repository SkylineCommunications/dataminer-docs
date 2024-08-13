---
uid: General_Main_Release_10.4.0_CU7
---

# General Main Release 10.4.0 CU7 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### MessageBroker: Each individual chunk will now be sent with a dynamic timeout [ID_38633]

<!-- MR 10.4.0 [CU7] - FR 10.4.6 -->

When chunked messages are being sent using MessageBroker, from now on, each individual chunk will be sent with a dynamic timeout instead of a static 5-second timeout.

The dynamic timeout will be calculated as the time it would take to send the chunk at a speed of 1 Mbps, rounded up to the nearest second.

> [!NOTE]
> The minimum timeout will always be 5 seconds.

#### MessageBroker: New NATS reconnection algorithm [ID_38809]

<!-- MR 10.4.0 [CU7] - FR 10.4.6 -->

From now on, when NATS reconnects, it will no longer perform the default reconnection algorithm of the NATS library. Instead, it will perform a custom reconnection algorithm that will do the following:

1. Re-read the MessageBroker configuration file.
1. Update the endpoints to which MessageBroker will connect.

#### Security enhancements [ID_38869]

<!-- MR 10.4.0 [CU7] - FR 10.4.6 -->

A number of security enhancements have been made.

#### MessageBroker: 'Subscribe' method of the 'NatsSession' class has now been made completely thread-safe [ID_38939]

<!-- MR 10.4.0 [CU7] - FR 10.4.6 -->

The *Subscribe* method of the `NatsSession` class has now been made completely thread-safe.

#### Caching of protocol signature information will enhance overall performance during a DataMiner startup [ID_39468]

<!-- MR MR 10.3.0 [CU19]/10.4.0 [CU7] - FR 10.4.7 -->

Information regarding protocol signature validation will now be cached. This will considerably enhance overall performance during a DataMiner startup.

#### MessageBroker: Clients will now first attempt to connect via the local NATS node [ID_39727]

<!-- MR 10.4.0 [CU7] - FR 10.4.9 -->

From now on, when a client connects to the DataMiner System, an attempt will first be made to connect to the NATs bus via the local NATS node. Only when this attempt fails, will the client connect to the NATS bus via another node.

#### Improved performance when alarm filters containing operators are used [ID_39732]

<!-- 10.4.0 [CU7] - FR 10.4.10 -->

Alarm filters that contain the operators AND, OR, or NOT (without brackets) will now be translated to OpenSearch queries, which will improve the performance of these filters. This will for example lead to improved performance when filtering alarms on a specific element and on severity.

#### When stopping, native processes will only wait for 30 seconds to close the MessageBroker connection when necessary [ID_39863]

<!-- MR 10.4.0 [CU7] - FR 10.4.9 -->

When a native process (e.g. SLDataMiner) is stopping, it will by default wait for 30 seconds before it closes the MessageBroker connection.

However, in some rare cases, there is no need to wait for 30 seconds. In those cases, the MessageBroker connection will be closed immediately.

#### SLASPConnection is now a 64-bit process [ID_39978]

<!-- MR 10.4.0 [CU7] - FR 10.4.8 -->

*SLASPConnection.exe* is now a 64-bit process.

This will prevent out of memory exceptions from being thrown, especially on larger DataMiner Systems.

#### SLNet.txt log file will no longer contain any logging from MessageBroker [ID_40061]

<!-- MR 10.4.0 [CU7] - FR 10.4.9 -->

From now on, by default, the *SLNet.txt* log file will no longer contain any logging from MessageBroker.

### Fixes

#### MessageBroker: Problem when trying to read a file that was being updated by another process [ID_39408]

<!-- MR 10.4.0 [CU7] - FR 10.4.7 -->

In some rare cases, an exception could be thrown when MessageBroker tried to read a file that was being updated by another process.

#### Problem when disposing an ISession with multiple subscriptions [ID_39483]

<!-- MR 10.4.0 [CU7] - FR 10.4.7 -->

In some cases, an `InvalidOperationException` could be thrown when a .NET Framework host application (e.g. DataMiner Automation) disposed an ISession with multiple subscriptions without having disposed the subscriptions first.

#### MessageBroker: Problem when receiving a Subscribe call while reconnecting [ID_39633]

<!-- MR 10.4.0 [CU7] - FR 10.4.7 -->

When MessageBroker received a Subscribe call while it was reconnecting, in some cases, the subscription could fail.

#### SLElement memory leak while NATS is down [ID_39889]

<!-- MR 10.4.0 [CU7] - FR 10.4.7 [CU0] -->

When the NATS server was down, SLElement would leak memory while trying to push data to the NATS connection.

#### GQI: Problems with persisting GQI sessions and incorrectly serialized GenIfAggregateException messages [ID_40333]

<!-- MR 10.4.0 [CU7] - FR 10.4.9 -->

When the user's SLNet connection was lost, the GQI session of a query with real-time updates enabled would incorrectly persist, potentially causing both an unhandled exception to be thrown when GQI tried to send an update to the user and SLHelper to crash.

Also, *GenIfAggregateException* messages would not be serialized correctly, causing the following exception to be added to the SLHelperWrapper log file:

```txt
2024/07/25 15:25:35.636|SLNet.exe|SendMessage|ERR|0|264|System.Reflection.TargetInvocationException: Exception has been thrown by the target of an invocation. ---> System.Runtime.Serialization.SerializationException: Member 'InnerExceptions' was not found.
   at System.Runtime.Serialization.SerializationInfo.GetElement(String name, Type& foundType)
   at System.Runtime.Serialization.SerializationInfo.GetValue(String name, Type type)
   at Skyline.DataMiner.Analytics.GenericInterface.GenIfAggregateException..ctor(SerializationInfo info, StreamingContext context)
```

#### MessageBroker: Reconnection mechanism could cause the overall CPU load to increase [ID_40071]

<!-- MR 10.4.0 [CU7] - FR 10.4.9 -->

Whenever the MessageBroker client loses its connection to the NATS server, it will try to reconnect. Because of an internal issue, up to now, this reconnection mechanism could cause the overall CPU load to increase. This issue has now been fixed.
