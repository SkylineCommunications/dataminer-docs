---
uid: LogicTimersTimerOptions
---

# Timer options

## dynamicThreadPool

Expected format: dynamicThreadPool:\<paramId\>

With this option, it is possible to monitor the number of used threads. Not all the threads of the thread pool are created if not needed; the thread pool dynamically changes (with max of thread pool size). To see the actual size of the thread pool, dynamicThreadPool can be defined; then this value is stored into the specified parameter and will refresh at calculationInterval.

Example:

`dynamicThreadPool:306`


PID 306 is the destination parameter.

*Feature introduced in DataMiner 8.0.5.4 (RN 6520).*

## each

Expected format: each:\<period\>

The period (in ms) that each row should be executed in the table. For example, each:5000 means that a row will be executed (polled) every 5 seconds, or, in other words, the timer will go through the entire table spread over 5 seconds.

## ignoreIf

Expected format: ifgnoreIf:\<columnIndex\>:\<value\>

With this option, you can make sure a group is NOT executed when the specified condition is met. This will not execute the group when the specified 0-based column position (of the table with ID specified in the "ip" option) has the specified value (value needs to be a numeric value) or the cell value is not initialized.

In the following example, the groups will not be executed when column 6 (0-based!) of a row has value -1:

`ignoreIf:6,-1`

## instance

Expected format: instance:\<tablePid\>,\<columnIndex\>

Specifies the column (0-based) that contains the instance value. This instance is used in the SNMP group to poll the parameters.

In the following example, the instance can be found in column 46 of the table with parameter ID 1000:

`instance:1000,46`

## ip

Expected format: ip:\<tablePid\>,\<columnIndex\>

The table parameter ID (and column index (0-based)) that contains the IP address:

`options="ip:1000,30"`

or the column index of the primary key column (in case you execute a QAction for each row of the table directly from the timer):

`options="ip:1000,0"`

(separated by a comma)

## ping

When a row is called, a ping can be executed first. The column containing the IP address can be found in the ip option. This can have one or more of the following options:

- **rttColumn**: (integer) The 1-based column where the result (in ms) of the RTT (round trip time) will be placed; if the ping fails, this value will be -1.
- **timeoutPid**: (integer) Specifies the ID of the parameter that will hold the key of the row that resulted in a timeout. The use of this option is obsolete. Instead, provide an additional column in the table that will indicate whether there was a timeout for each row (detecting whether a timeout is possible through the rttColumn option).
- **ttl**: Time to live of the packet (maximum number of hops) (default 10).
- **timeout**: Max time (in ms) before the ping is flagged as timeout when no response is returned (default 500 ms).
- **timestampColumn**: The 1-based column where the timestamp should be placed when the ping has been executed.
- **type**: The type of ping that is used: ICMP or winsock (default ICMP).
- **size**: The payload size of the packet that is used to execute the ping (default 0).
- **continueSnmpOnTimeout**: True or false. Defines if the group should be executed when the ping is in timeout.
- **jitterColumn**: 1-based column index of the column that will contain the jitter (ms).
  
  The jitter is calculated as follows: Max(ping - RTT) - Min(ping - RTT) / 2
  
  *Feature introduced in DataMiner 9.0.4 (RN 13278).*
- **latencyColumn**: 1-based column index of the column that will contain the latency (ms).

  The latency is calculated as follows: Avg(ping - RTT) / 2

  *Feature introduced in DataMiner 9.0.4 (RN 13278).*
- **packetLossRateColumn**: 1-based column index of the column that will contain the packet loss rates (decimal value ranging from 0.01 to 1).

  The packet loss rate is calculated as follows: Ping Timeouts / Total Ping Packets Sent

  *Feature introduced in DataMiner 9.0.4 (RN 13278).*
- **amountPacketsMeasurements**: The number of packets that will be sent in order to calculate the three above-mentioned measurements.

  *Feature introduced in DataMiner 9.0.4 (RN 13278).*

  > [!NOTE]
  > The packet size (defined using the size and type options) will also be taken into account.

- **amountPacketsMeasurementsPid**: Specifies the ID of the parameter that holds the number of packets that will be sent in order to calculate the three above-mentioned measurements.

  *Feature introduced in DataMiner 9.5.1 (RN 14522).*
- **amountPackets**: With this option, you can first specify the number of packets to be sent to the device, and then the number of packets to be sent that will actually be used to calculate the KPIs. The difference between the two will be the number of packets that are ignored for the calculation of the KPIs. This way, you can for example ignore the first ping, as it may have the worst results if the address is not in the routing tables.
If you only specify "amountPacketsMeasurements=x" and leave out "amountPackets=x", the number of packets to be taken into account to calculate the KPIs will be considered the same as the total number of packets.

  *Feature introduced in DataMiner 9.5.1 (RN 14522).*

  > [!NOTE]
  > - This, and the amountPacketsPID option, are only supported in conjunction with the threadPool option. When no threadPool is used, only one ping request will be sent.
  > - If the number specified for amountPacketsMeasurements is larger than for amountPackets, amountPacketsMeasurements will be adjusted to the same number as amountPackets.
  > - Note that the amountPacketsMeasurements option in itself is already available in DataMiner 9.0.0 CU6 and 9.0.4. (See also RN 13278 and RN 13278.)

- **amountPacketsPID**: Instead of specifying fixed values ("amountPackets=x:amountPacketsMeasurements=x"), it is also possible to specify dynamic values stored in parameters (""). Note that if you specify both fixed and dynamic values, the latter will take precedence.

  The value in the referred parameters must not be 0 or uninitialized. If it is, by default 1 or the hard-coded value on the timer will be used. The referred parameters must be of numeric type.

  ```xml
  <Interprete>
      <RawType>numeric text</RawType>
      <LengthType>next param</LengthType>
      <Type>double</Type>
  </Interprete>
  ```

  *Feature introduced in DataMiner 9.5.1 (RN 14522).*

- **interval**: With this option, you can specify the interval in ms between two consecutive ping packets. This should be used when the device does not respond to all ping requests when they are sent without any intermediate delay.

  *Feature introduced in DataMiner 10.2.11 (RN 34463).*

  > [!NOTE]
  > This option is only relevant when *amountPackets* or *amountPacketsPID* is used. These are currently only supported in conjunction with the *threadPool* option. When *threadPool* is not used, only one ping request will be sent.

- **intervalPID**: Instead of specifying a fixed interval value ("interval=x"), it is also possible to specify a dynamic value stored in a standalone parameter. Note that if you specify both a fixed and a dynamic value, the latter will take precedence.

  The value in the referred parameters must not be 0 or uninitialized. Otherwise, 0, the hard-coded value on the timer, or the last valid value will be used by default. The referred parameters must be of numeric type.

  ```xml
  <Interprete>
      <RawType>numeric text</RawType>
      <LengthType>next param</LengthType>
      <Type>double</Type>
  </Interprete>
  ```

  *Feature introduced in DataMiner 10.2.11 (RN 34463).*
  
- **excludeWorstResults**: With this option, you can filter out the worst results of the different ping packets to calculate the KPIs. The specified value is a percentage, and the number of packets that will be filtered out is an integer number that is rounded down, with a minimum of 1.

  *Feature introduced in DataMiner 9.5.1 (RN 14522).*

- **excludeWorstResultsPID**: Instead of specifying a fixed value ("excludeWorstResults=x"), it is also possible to specify a dynamic value stored in a parameter. Note that if you specify both fixed and dynamic values, the latter will take precedence.

  If the value in the parameter for excludeWorstResultsPID is 0 or undefined, no results will be excluded.
  The referred parameter must be of numeric type.

  ```xml
  <Interprete>
      <RawType>numeric text</RawType>
      <LengthType>next param</LengthType>
      <Type>double</Type>
      <Decimals>2</Decimals>
  </Interprete>
  ```

  *Feature introduced in DataMiner 9.5.1 (RN 14522).*

Example:

```xml
ping:rttColumn=7,timestampColumn=5,ttl=250,timeout=500,type=icmp,continueSNMPOnTimeout=true
```

It is also possible to retrieve the RTT (round-trip time) and the ping timestamp in a QAction using the following methods: Feature introduced in DataMiner 8.5.0 (RN 7690).

- RowRTT()
- RowPingTimestamp()

Note, however, that it is not necessary to have the rrtcolumn option defined in the ping attribute.

## pollingRate

Configures the use of a counting semaphore to spread the row processing more equally over time.

Expected format: pollingRate:\<interval\>,\<maxCount\>,\<releaseCount\>

-<interval>: Specifies the interval (in ms) at which the semaphore object's current count will be increased. The minimum supported value is 15.
-<maxCount>: Specifies the max count of the semaphore.
-<releaseCount>: Specifies the release count. This is the value by which the semaphore object's current count will be increased.

In case the maxCount or releaseCount are not specified, both will be set to 10 by default.

> [!NOTE]
> It is advisable to set the maxCount and releaseCount to the same value.

Suppose a table contains 10 000 rows and the "each" option is set to 100 000 ms; this means that the timer should execute 10 000 rows/100 s = 100 rows per second. When pollingrate is not defined, this means that at the start of each second, 100 rows are launched at the same time (in bulk).

The polling rate ensures that these 100 rows are more equally spread over the second pollingrateinter-val(ms),pollingratemaxcount,pollingratereleasecount pollingrate:15,3,3 (every 15 ms, release 3 threads).

## qaction

Expected format: qaction:\<qactionId\>

- \<qactionId\>: Specifies the ID of the QAction.

The ID of the QAction that is activated by the timer. The triggers attribute of the QAction tag needs to be empty, and the option row="true" needs to be added.

RowKey() can then be called in the QAction to see which row was being called. Note that this is not executed multi-threaded but sequentially.

> [!NOTE]
> This is not executed multi-threaded but sequentially. Therefore, this option is considered obsolete. Instead, use the qactionBefore option to obtain multi-threaded behavior.
 
Example:

`options="qaction:2"`

## qactionBefore

Expected format: qactionBefore:\<qactionId\>

- \<qactionId\>: Specifies the ID of the QAction.

Run this QAction before executing the ping (in combination with the ping option). The triggers attribute of the QAction tag needs to be empty, and the option row="true" needs to be added.

RowKey() can then be called in the QAction to see which row was being called.

Example:

`options="qactionBefore:14"`

## qactionAfter

Expected format: qactionAfter:\<qactionId\>

- \<qactionId\>: Specifies the ID of the QAction.

Run this QAction after the response enters. The QAction triggers attribute needs to be empty and the option row="true" can be added.

RowKey() can then be called in the QAction to see which row was being called.

## threadPool

Normally this is a multi-threaded timer (except when only a QAction is defined). This means that several rows are executed at the same time. To be able to do this at the same time, the timer requires multiple threads.

Expected format: threadPool:\<size\>,\<calculationInterval\>,\<usagePid\>,\<waitingPid\>,\<maxDurationPid\>,\<avgDurationPid\>,\<counterPid\>,\<stackSize\>

The values must be interpreted as follows:

- **size**: Specifies the maximum number of threads available in the thread pool.
- **calculationInterval**: Specifies the interval (in s) for refreshing the thread statistics. Default: -1, which means the thread statistics will not be calculated.
- **usagePid**: The parameter that will display the number of threads that are in use, refreshed at calculation interval (every 5 seconds in this case). Default: -1.
- **waitingPid**: Specifies the ID of the parameter that will display how many threads are waiting because all the threads in the thread pool are in use, refreshed at calculation interval. Default: -1.
- **maxDurationPid**: Specifies the ID of the parameter that will display how long it took to execute the slowest thread (in ms) during the last calculation interval. Default: -1.
- **avgDurationPid**: Specifies the parameter that will display how long it took by average to execute a thread (in ms) during the last calculation interval. Default: -1.
- **counterPid**: Specifies the ID of the parameter that will display how many threads were finished executing during the last calculation interval. Default: -1.
- **queueSize**: Specifies the number of items that can be placed in waiting state. When the waiting thread pool has reached the queue size, a notice alarm is generated. Default: \<size\> * 10.

Only the \<size\> is required., the other settings are optional.

The following example only specifies the size of the thread pool:

`options="threadPool:10"`

The following example specifies all options:

`options="threadPool:10,5,205,206,207,208,209,500"`

> [!NOTE]
> In case these statistics are of no interest, set the refresh rate to -1 to avoid these calculations, and provide -1 for the parameter IDs as illustrated in the following example:
>
> `threadPool:10,-1,-1,-1,-1,-1,-1,500`

From DataMiner 8.0.5.4 onwards, the number of threads specified is the maximum expected number of needed threads. SLProtocol will only create the threads that are needed to meet the polling interval. Threads are ended automatically when they are no longer needed. This improves the performance of using threadpools that can differ a lot.

*Feature introduced in DataMiner 8.0.5.4 (RN 6520).*
