---
uid: Configuration_of_DataMiner_processes
---

# Configuring DataMiner processes

## Setting the number of simultaneously running SLPort processes

The number of simultaneously running SLPort processes can be set in the *\<ProcessOptions>* tag of the *DataMiner.xml* file.

The default number is set to 5.

To set a different number:

1. Stop the DataMiner software.

1. Open the file *C:\\Skyline Dataminer\\DataMiner.xml.*

1. Specify a different number for the *portProcesses* attribute of the *ProcessOptions* tag.

   Example:

   ```xml
   <DataMiner>
     <ProcessOptions portProcesses="2" />
   </DataMiner>
   ```

1. Save the file and restart DataMiner.

> [!NOTE]
> When elements are spread over the different SLPort processes, the same IP and port are always hosted within the same process. In the log file 'SLPortSplit.txt' you can see which IPs and ports are hosted in the same process.

## Setting the number of simultaneously running SLProtocol processes

The number of simultaneously running SLProtocol processes can be set in the *\<ProcessOptions>* tag of the *DataMiner.xml* file.

By default, the number of simultaneously running processes is set to 5.

To set a different number:

1. Stop the DataMiner software.

1. Open the file *C:\\Skyline Dataminer\\DataMiner.xml.*

1. Specify a different number for the *protocolProcesses* attribute of the *ProcessOptions* tag.

   Example:

   ```xml
   <DataMiner>
     <ProcessOptions protocolProcesses="4" />
   </DataMiner>
   ```

1. Save the file and restart DataMiner.

## Configuring a separate SLProtocol process for every protocol used

For testing purposes, you can order a DataMiner Agent to spread its elements across different SLProtocol processes based on the protocol they are using.

If you do so, DataMiner will start up a separate SLProtocol process for every protocol that is used. That way, each SLProtocol process will only contain elements sharing the same protocol. This will make it much easier to pinpoint any protocol-related issues that might arise.

> [!WARNING]
> Never use this option in a production environment without having consulted Skyline Tech Support.

To have separate SLProtocol processes created for every protocol being used, do the following.

1. Stop the DataMiner software.

1. Open the file *C:\\Skyline Dataminer\\DataMiner.xml.*

1. In the *\<ProcessOptions>* tag, set the *protocolProcesses* attribute to “protocol”.

   ```xml
   <DataMiner>
     <ProcessOptions protocolProcesses="protocol" />
   </DataMiner>
    ```

1. Save *C:\\Skyline Dataminer\\DataMiner.xml.*

1. Restart the DataMiner software.

## Configuring a separate SLScripting process for every protocol used

If you suspect that a particular protocol is causing a problem in the SLScripting process, then you can have separate SLScripting processes created for every protocol being used. This will then allow you to pinpoint the protocol that is causing the problem.

To have separate SLScripting processes created for every protocol being used, do the following.

1. Stop the DataMiner software.

1. Open the file *C:\\Skyline Dataminer\\DataMiner.xml.*

1. In the *\<ProcessOptions>* tag, set both the *protocolProcesses* attribute and the *scriptingProcesses* attribute to “protocol”.

   ```xml
   <DataMiner>
     <ProcessOptions protocolProcesses="protocol" scriptingProcesses="protocol" />
   </DataMiner>
   ```

   > [!NOTE]
   > If scriptingProcesses is set to "protocol", an SLScripting process is initialized for every SLProtocol process (see [Configuring a separate SLScripting process for each SLProtocol process](#configuring-a-separate-slscripting-process-for-each-slprotocol-process)). As an SLProtocol process is used for every protocol when protocolProcesses is set to "protocol", combining these two attributes effectively initializes a separate SLScripting process for every protocol.

1. Save *C:\\Skyline Dataminer\\DataMiner.xml.*

1. Restart the DataMiner software.

> [!WARNING]
> Never use this option in a production environment without having consulted Skyline Tech Support.

## Configuring a separate SLScripting process for each SLProtocol process

In a system where the load for one particular protocol has to be spread over several processes, because otherwise too much memory would be needed for one process, it can be useful to have a dedicated SLScripting process created for each SLProtocol process:

1. Stop the DataMiner software.

1. Open the file *C:\\Skyline Dataminer\\DataMiner.xml.*

1. In the *\<ProcessOptions>* tag, set the *protocolProcesses* attribute to a fixed number and the *scriptingProcesses* attribute to “protocol”.

   ```xml
   <DataMiner>
     <ProcessOptions protocolProcesses="18" scriptingProcesses="protocol" />
   </DataMiner>
   ```

   The number you specified determines the number of SLProtocol processes. Elements using the same SLProtocol process will also use the same SLScripting process.

1. Save *C:\\Skyline Dataminer\\DataMiner.xml.*

1. Restart the DataMiner software.

> [!WARNING]
> Never use this option in a production environment without having consulted Skyline Tech Support.

## Configuring separate SLProtocol and SLScripting instances for a specific protocol

As some protocols have QActions that require a large amount of memory, elements using these protocols can cause SLScripting to run out of memory when they run together in the same process instance. From DataMiner 10.2.5/10.3.0 onwards, you can prevent this by making such elements run in their own SLProtocol and SLScripting instances.

When a protocol is flagged to run in separate instances, every element using that protocol will be started in a new instance of SLProtocol and SLScripting. When the element is stopped, these instances are taken down again, and when the element restarts, new instances are created.

> [!NOTE]
> From DataMiner 10.2.7/10.3.0 onwards, this behavior can also be configured in the protocol itself using the [RunInSeparateInstance](xref:Protocol.SystemOptions.RunInSeparateInstance) tag. In that case, no DataMiner restart is required.

To configure this:

1. Stop the DataMiner software.

1. Open the file *C:\\Skyline Dataminer\\DataMiner.xml.*

1. In the *\<ProcessOptions>* element, specify a *\<SeparateProcesses>* element listing the protocols that should run in separate SLProtocol and SLScripting instances. For example:

   ```xml
   <DataMiner>
      ...
      <ProcessOptions protocolProcesses="3" scriptingProcesses="protocol">
         <SeparateProcesses>
            <Protocols>
               <Protocol>
                  <Name>MyElementProtocol</Name>
               </Protocol>
            </Protocols>
         </SeparateProcesses>
      </ProcessOptions>
      ...
   </DataMiner>
   ```

1. Save *C:\\Skyline Dataminer\\DataMiner.xml.*

1. Restart the DataMiner software.

> [!NOTE]
>
> - A separate SLScripting process must be launched for every SLProtocol process. This means that when at least one protocol name is specified in the *SeparateProcesses* tag, the configuration of the *scriptingProcesses* attribute will be overridden to "protocol", except if it is set to "\[Service]" (see [Running SLScripting as a service](#running-slscripting-as-a-service)). Configuring separate SLProtocol and SLScripting instances for a protocol is not compatible with a configuration where SLScripting is configured as a service. If you do configure both of these options, the configuration to run separate SLProtocol and SLScripting instances will be ignored, and a notice alarm will be generated with more information.
> - DataMiner.xml files are not synchronized in a DMS. If your DMS consists of multiple DMAs, you will need to edit the DataMiner.xml file on each of the DMAs.

## Having replicated elements handled by one SLProtocol process

In order to reduce the number of connections in case of element replication, in the *DataMiner.xml* file, you can specify that all replicated elements from the same remote DataMiner Agent have to be handled by the same SLProtocol process.

To do so:

1. Stop the DataMiner software.

1. Open the file *C:\\Skyline Dataminer\\DataMiner.xml.*

1. Set the *protocolProcesses* attribute of the *\<ProcessOptions>* tag to “replicationIP”:

```xml
<DataMiner>
  ...
  <ProcessOptions protocolProcesses="replicationIP"/>
  ...
</DataMiner>
```

## Setting the number of simultaneously running SLScripting processes

From DataMiner 10.2.7/10.3.0 onwards, the number of simultaneously running SLScripting processes can be set in the *\<ProcessOptions>* tag of the *DataMiner.xml* file.

1. Stop the DataMiner software.

1. Open the file *C:\\Skyline Dataminer\\DataMiner.xml.*

1. In the *\<ProcessOptions>* tag, set the *scriptingProcesses* attribute to the desired number. For example:

   ```xml
   <DataMiner>
     <ProcessOptions protocolProcesses="5" scriptingProcesses="3" />
   </DataMiner>
   ```

1. Save *C:\\Skyline Dataminer\\DataMiner.xml.*

1. Restart the DataMiner software.

> [!NOTE]
> The SLProtocol processes will be assigned one of the available SLScripting processes in a round-robin way. For example, if protocolProcesses is set to 5 (i.e. the default value), and scriptingProcesses is set to 3:
>
> - SLScripting 1 will host SLProtocol #1 and #4
> - SLScripting 2 will host SLProtocol #2 and #5
> - SLScripting 3 will host SLProtocol #3
>
> Assigning more SLScripting processes than SLProtocol processes will give every SLProtocol process its own instance without launching additional SLScripting processes.

## Running SLScripting as a service

By default, the SLScripting process runs as a server. However, in some cases, it needs to run as a service. It is possible to configure this in the file *DataMiner.xml*:

### To register SLScripting as a service

1. Stop the DataMiner software.

1. Open the file *C:\\Skyline Dataminer\\DataMiner.xml.*

1. Make sure *DataMiner.xml* contains a *\<ProcessOptions>* tag and that it contains the *scriptingProcesses="\[Service\]"* attribute:

   ```xml
   <ProcessOptions ... scriptingProcesses="[Service]" .../>
   ```

1. Open a command window as Administrator, and do the following:

   1. Go to *C:\\Skyline DataMiner\\Files*.

   1. Execute the following command: *SLScripting.exe /service*

1. Start the DataMiner software.

### To register SLScripting as a server

1. Stop the DataMiner software.

1. Open the file *C:\\Skyline Dataminer\\DataMiner.xml.*

1. If *DataMiner.xml* contains a *\<ProcessOptions>* tag with a *scriptingProcesses=”\[Service\]”* attribute, remove that attribute:

   ```xml
   <ProcessOptions ... scriptingProcesses="[Service]" .../>
   ```

1. Open a command window as Administrator, and do the following:

   1. Go to *C:\\Skyline DataMiner\\Files*.

   1. Execute the following command: *SLScripting.exe /regserver*

1. Start the DataMiner software.

## SLWatchdog

On a DataMiner Agent, the SLWatchdog process continuously monitors all other DataMiner processes. When it detects some kind of problem with one of those processes, it takes action.

> [!CAUTION]
> SLWatchdog must never be started or restarted manually when DataMiner is running. Doing so may have unintended consequences as it guards the DataMiner processes.

### When will SLWatchdog take action?

In Windows Task Manager, the DataMiner processes all have names starting with “SL”. SLWatchdog will take action in either of the following cases:

- When a DataMiner process has disappeared from the list of running processes.

- When an anomaly has been detected in a DataMiner process.

#### When a DataMiner process has disappeared

In this case, SLWatchdog will do the following:

1. Send an email message stating the name of the DataMiner process toward all recipients specified in the SLWatchdog configuration settings. By default, this message will include a dump file containing copies of all DataMiner log files found on the DataMiner Agent the moment the problem was detected.

1. Restart the process (in case the process that disappeared was SLScripting), or restart the DataMiner Agent as a whole (in case the process that disappeared was not SLScripting, but one of the other processes, which in many cases have a number of dependencies).

1. Create two information messages:

   - One at the moment the DataMiner Agent is stopped.

   - One at the moment the DataMiner Agent is restarted.

   Both messages will be displayed in the DataMiner Alarm Console.

#### When an anomaly has been detected in a DataMiner process

In this case, SLWatchdog will do the following:

1. Send an email message stating the name of the DataMiner process toward all recipients specified in the SLWatchdog configuration settings. By default, this message will include a dump file containing copies of all DataMiner log files found on the DataMiner Agent the moment the problem was detected.

1. Create an alarm with severity “Error”, which will be displayed in the DataMiner Alarm Console. This alarm will contain detailed information about the anomaly.

1. Optionally restart the DataMiner Agent. By default, this will not be done.

### Configuring the SLWatchdog process

In the file *MaintenanceSettings.xml*, you can specify a number of SLWatchdog settings.

1. Open the file *C:\\Skyline DataMiner\\MaintenanceSettings.xml*.

1. In the *Watchdog* tag, modify the SLWatchdog settings (see below).

1. Save *C:\\Skyline DataMiner\\MaintenanceSettings.xml*.

1. Stop the DataMiner Agent.

1. Manually stop the SLWatchdog service.

1. Restart the DataMiner Agent.

> [!TIP]
> See also: [MaintenanceSettings.xml](xref:MaintenanceSettings_xml)

### Example of an SLWatchdog tag in MaintenanceSettings.xml

```xml
<MaintenanceSettings>
  ...
  <WatchDog>
    <TimeoutTime>5</TimeoutTime>
    <Errors>2</Errors>
    <Actions>Alarm</Actions>
    <EMail active="true">
      <Destination></Destination>
      <CCDestination></CCDestination>
      <BCCDestination></BCCDestination>
    </EMail>
    <ProcessMonitor maxinHour="3"
        maxProcess="2"
        maxTimeout="2"
        maxAttachmentSize="5"
        passwordOnAttachment="true" />
  </WatchDog>
  ...
</MaintenanceSettings>
```

### Overview of the different SLWatchdog settings

The following table contains all information about the different SLWatchdog settings you can configure in the *Watchdog* tag of *MaintenanceSettings.xml*.

| Tag | Attribute | Description |
|--|--|--|
| TimeoutTime | - | The interval (in minutes) between two consecutive process thread checks. Default value: 5 |
| Errors | - | The number of process thread checks that are allowed to return an error before SLWatchdog will consider the situation to be an anomaly. Default value: 2 |
| Actions | - | List of actions (separated by semicolons) to be performed upon detection of an anomaly. Possible values are “Alarm” and “Restart”. Default value: “Alarm” |
| Email | active | If true, SLWatchdog will send email messages upon detection of an anomaly. Default value: true |
| Email.Destination | - | The “To” recipients, separated by semicolons. Default value: [dataminer.minidump@skyline.be](mailto:dataminer.minidump%40skyline.be) |
| Email.CCDestination | - | The “CC” recipients, separated by semicolons. By default, this tag is empty. |
| Email.BCCDestination | - | The “BCC” recipients, separated by semicolons. By default, this tag is empty. |
| ProcessMonitor | maxInHour | SLWatchdog will perform the specified actions if the situation does not occur more than X times in one hour. Default value: 3 |
| ProcessMonitor | maxProcess | SLWatchdog will perform the specified actions if a maximum of X processes have disappeared within the time span defined in *maxTimeout*. Default value: 2 |
| ProcessMonitor | maxTimeout | SLWatchdog will perform the specified actions if more processes than defined in *maxProcess* have disappeared within a time span of X minutes. Default value: 2 |
| ProcessMonitor | maxAttachmentSize | The maximum size (in MByte) of the dump file that will be attached to the email messages. If exceeded, a so-called mini dump file will be attached. Default value: 5 |
| ProcessMonitor | passwordOnAttachment | If true, users will have to enter the password “Skyline” in order to access the dump files attached to the email messages. Default value: false |

## Configuring SLNet settings in MaintenanceSettings.xml

> [!TIP]
> See also: [MaintenanceSettings.xml](xref:MaintenanceSettings_xml)

> [!NOTE]
> Before you configure any of these settings, you will need to stop DataMiner. After you have saved your changes, restart DataMiner again.

### Limiting the number of connection attempts

Using the following tags, you can limit the number of connection attempts per client computer that a DataMiner Agent will allow.

- MaxConnectionAttemptsCheckEnabled (default: true)

- MaxConnectionAttempts (default: 40)

- MaxConnectionAttemptsTime (default: 2 minutes)

> [!NOTE]
> These settings do not apply to replication connections.

Example:

```xml
<SLNet>
  <MaxConnectionAttemptsCheckEnabled>true</MaxConnectionAttemptsCheckEnabled>
  <MaxConnectionAttempts>40</MaxConnectionAttempts>
  <MaxConnectionAttemptsTime>2</MaxConnectionAttemptsTime>
</SLNet>
```

If you specify the above-mentioned connection attempt settings, a DataMiner Agent will disregard all subsequent attempts and return the following error message when it receives more than 40 connection attempts within 2 minutes:

```txt
Too many connection attempts from client XXXXX.
```

### Enabling encrypted connections

If you set the *RequireEncryptedConnections* tag to TRUE, then all incoming connections have to use encryption.

When a legacy DMA tries to connect to a DMA that requires encrypted connections, the following message will be returned:

```txt
Client software does not support encrypted connections.
```

Example:

```xml
<SLNet>
  <RequireEncryptedConnections>TRUE</RequireEncryptedConnections>
</SLNet>
```

Default from DataMiner 10.1.7 onwards: TRUE

Default prior to DataMiner 10.0.13: FALSE

### Configuring the number of messages to be returned (polling/eventing)

Using the following tags, you can specify the number of messages to be returned in case of polling or eventing:

- **MaxMessagesPerPollingRequest**: The maximum number of events to be returned after a polling request. Default: 500 events

- **MaxMessagesPerCallback**: The maximum number of events to be sent via an eventing callback. Default: 500 events

Polling requests are usually sent less often than eventing callbacks. Normally, callbacks are sent every 100 ms, while polling requests are sent every second (depending on the configuration).

Example:

```xml
<SLNet>
  <MaxMessagesPerPollingRequest>2000</MaxMessagesPerPollingRequest>
  <MaxMessagesPerCallback>500</MaxMessagesPerCallback>
</SLNet>
```

> [!NOTE]
>
> - When a single polling response is not able to empty the stack of queued messages on the server, the next polling request will be scheduled after 100ms (fixed value).
> - Unzipping/unpacking polling response data on the client can be done while another polling request is already in progress.

### Configuring the polling request timeout

In the *\<DefaultPollingRequestTimeout>* tag, you can set the polling request timeout (in seconds).

This setting will apply to all new inter-DMA connections set up from that DMA.

Default value: 60 seconds

> [!TIP]
> See also: [Configuring the polling request timeout](xref:Configuring_the_polling_request_timeout)

### Configuring indexing options for the server-side search of DataMiner Cube

In the *\<SearchOptions>* tag, you can configure the indexing options for the server-side search of DataMiner Cube.

Example:

```xml
<SLNet>
  <SearchOptions>trendedParamsOnly</SearchOptions>
</SLNet>
```

> [!TIP]
> See also: [Setting the indexing options for the server-side search](xref:Setting_the_indexing_options_for_the_server-side_search)

### Making DataMiner Cube ignore view updates

If you set the *\<ClientSkipViewUpdates>* tag to TRUE, DataMiner Cube clients will no longer handle any view changes.

The first time a view change has been ignored, a *Reconnect* button will appear at the top of the Surveyor. Click this button to reconnect and manually reload any view changes.

Example:

```xml
<SLNet>
  <ClientSkipViewUpdates>TRUE</ClientSkipViewUpdates>
</SLNet>
```

Default: FALSE

> [!NOTE]
> This setting can also be configured with the SLNetClientTest tool. However, note that this is an advanced administration tool that should be used with extreme care. See [Making DataMiner Cube ignore view updates](xref:SLNetClientTest_making_Cube_ignore_view_updates).

### Specifying DCF settings

Within the *\<SLNet>* tag, several settings for the DCF engine can be configured.

#### ConnectivityEngineInterval

Use this setting to specify (in milliseconds) how frequently the DCF engine has to check for changes in connectivity chains. By default, the interval is set to 1000 milliseconds.

Example:

```xml
<MaintenanceSettings>
  <SLNet>
    <ConnectivityEngineInterval>5000</ConnectivityEngineInterval>
    ...
  </SLNet>
  ...
</MaintenanceSettings>
```

#### ConnectivityLogVerbose

Set this setting to “true” to add extra information in the logs with regard to connectivity chain resolution.

Example:

```xml
<MaintenanceSettings>
  <SLNet>
    <ConnectivityLogVerbose>true</ConnectivityLogVerbose>
    ...
  </SLNet>
  ...
</MaintenanceSettings>
```

#### ConnectivityMaxConnections

Use this setting to specify the maximum number of connections that is allowed in Connectivity event and response messages. By default, the maximum number of connections is set to 500.

Example:

```xml
<MaintenanceSettings>
  <SLNet>
    <ConnectivityMaxConnections>700</ConnectivityMaxConnections>
    ...
  </SLNet>
  ...
</MaintenanceSettings>
```

### Activating the NonElementProtocol option system-wide

In a Visual Overview, a “NonElementProtocol” option can be specified in case it contains shapes linked to a large number of elements, but no element-specific formatting is needed from files like *description.xml*, *informations.xml*, or *port.xml*. This can enhance the overall performance of the Visual Overview.

It is also possible to apply this option system-wide, instead of limiting it to one Visual Overview shape or page.

To do so, add a *\<NonElementProtocol>* tag in the *\<SLNet>* section of the *MaintenanceSettings.xml* file, and set this tag to “true”.

Example:

```xml
<MaintenanceSettings>
  ...
  <SLNet>
    ...
    <NonElementProtocol>true</NonElementProtocol>
    ...
  </SLNet>
  ...
</MaintenanceSettings>
```

> [!TIP]
> See also: [NonElementProtocol](xref:Overview_of_page_and_shape_options)

### Generating information events when a connection fails to authenticate

It is possible to have an information event generated whenever a connection fails to be authenticated. From DataMiner 10.1.8/10.2.0 onwards, this is enabled by default.

To enable this option in older systems, add an *\<EnableFailedAuthenticationInfoEvents>* tag in the *\<SLNet>* section of the *MaintenanceSettings.xml* file, and set this tag to “true”.

Example:

```xml
<MaintenanceSettings>
  ...
  <SLNet>
    <EnableFailedAuthenticationInfoEvents>true</EnableFailedAuthenticationInfoEvents>
    ...h
  </SLNet>
  ...
</MaintenanceSettings>
```

### Configuring a cluster transition state timeout

From DataMiner 10.0.3 onwards, in the *\<ClusterTransitionStateTimeout>* tag, you can specify a cluster transition state timeout (in seconds).

DataMiner Agents leaving the DataMiner System (i.e. cluster) will leave the transition state after the specified timeout delay, starting from the last received notification from any of the DataMiner processes.

Example:

```xml
<MaintenanceSettings>
  ...
  <SLNet>
    <ClusterTransitionStateTimeout>5</ClusterTransitionStateTimeout>
    ...
  </SLNet>
  ...
</MaintenanceSettings>
```

### Fine-tuning NATS settings

From DataMiner 10.1.0/10.1.1 onwards, DataMiner processes use the NATS open-source messaging system to communicate with each other. Some settings for NATS can be fine-tuned in *MaintenanceSettings.xml*, using the following tags:

- *NATSDisasterCheck*: Set this to true or false in order to respectively activate or deactivate automatic detection and triggering of NATS cluster self-healing (default: false).

- *NATSResetWindow*: Specify a value in seconds to set a window during which only one NATS reset can occur. This prevents situations where NATS disaster recovery is triggered too often. The minimum value is 60. If a lower value is specified, 60 will be used instead.

- *NATSLogFileCleanupMs*: Supported from DataMiner 10.1.0 \[CU9\]/10.1.8 onwards. Determines the time (in milliseconds) between NATS log file cleanup attempts. This timing will only be applied after the next cleanup attempt after the configuration change. For example, if the next cleanup attempt is in 15 minutes, and you change this value, the next cleanup will still be in 15 minutes, but all subsequent cleanups will happen after 1-minute intervals. The default value of this setting is 900000 (15 minutes).

- *NATSLogFileAmountToKeep*: Supported from DataMiner 10.1.0 \[CU9\]/10.1.8 onwards. The number of log files to keep (default =10). This value only applies to the log files that do not have the .log extension.

Example:

```xml
<MaintenanceSettings>
  ...
  <SLNet>
    ...
    <NATSDisasterCheck>true</NATSDisasterCheck>
    <NATSResetWindow>90</NATSResetWindow>
    <NATSLogFileCleanupMs>60000</NATSLogFileCleanupMs>
    <NATSLogFileAmountToKeep>20</NATSLogFileAmountToKeep>
    ...
  </SLNet>
  ...
</MaintenanceSettings>
```

> [!NOTE]
> From DataMiner 10.1.0/10.1.3 onwards, you can instead configure this using the SLNetClientTest tool. See [Fine-tuning NATS settings](xref:SLNetClientTest_finetuning_nats_settings).

> [!TIP]
> See also: [Increasing the timeout for the NATS connection](xref:SLCloud_xml#increasing-the-timeout-for-the-nats-connection)

### Fine-tuning message throttling

From DataMiner 10.2.0/10.1.2 onwards, message throttling is enabled on connections from web applications (e.g. Monitoring app, Dashboards app, Web APIs, etc.) to SLNet. This is a mechanism that avoids an excessive number of parameter update messages being sent at the same time.

From DataMiner 10.1.3 onwards, the following settings can be fine-tuned for this in *MaintenanceSettings.xml:*

- *MessageThrottlingThreshold*: Time interval in ms. The default and minimum value is 250. If two updates for the same parameter are received within this interval, message throttling is activated. The first of the parameter updates is sent immediately, but messages for the same parameter that come after this are throttled until no more parameter updates have been received for this same time interval. Once the throttling has stopped, the last update is also sent after at most this time interval.

- *MessageThrottlingPeriodicUpdate*: Time interval in ms. The default value is 1000, and the value must always be at least twice the *MessageThrottlingThreshold* value. If there is a steady flow of updates for the same parameter, and message throttling is activated, a periodic update is sent after this interval.

Example:

```xml
<MaintenanceSettings>
  ...
  <SLNet>
    ...
    <MessageThrottlingThreshold>250</MessageThrottlingThreshold>
    <MessageThrottlingPeriodicUpdate>1000</MessageThrottlingPeriodicUpdate>
    ...
  </SLNet>
  ...
</MaintenanceSettings>
```

### Customizing how long a connection ticket remains valid

When establishing a new connection (e.g. using the DataMiner Web Services), SLNet makes use of a ticket for authentication. The *AuthenticationTicketExpirationTime* setting in *MaintenanceSettings.xml* determines how long this ticket remains valid. If a request for a new connection is made after the specified time has elapsed, the system will consider the request invalid.

By default, this is set to 30 seconds.

Example:

```xml
<MaintenanceSettings>
  ...
  <SLNet>
    ...
    <AuthenticationTicketExpirationTime>30</AuthenticationTicketExpirationTime>
    ...
  </SLNet>
  ...
</MaintenanceSettings>
```

> [!NOTE]
> Within the SLNet element in *MaintenanceSettings.xml*, there is also a *TicketExpirationTime* setting. This determines the duration (in seconds) that a ticket used to perform privileged instructions remains valid (default value: 300 seconds). This is for instance used to grant a user permission to start DataMiner. If a request for the privileged instruction is made after the specified time period has passed, the system considers the ticket invalid and denies the request.

### Disabling .NET Remoting

By default, .NET Remoting is used for communication between DMAs. From DataMiner 10.3.2/10.3.0 onwards, a gRPC connection can be used instead. To make gRPC the default for communication between DMAs, you can either [add Redirect tags in DMS.xml](xref:DMS_xml#redirects-subtag), or disable .NET Remoting in *MaintenanceSettings.xml*. However, note that the latter is **only recommended from DataMiner 10.3.6/10.3.0 [CU3] onwards**, as prior to this there is no support for DataMiner upgrades over gRPC.

To do the latter, add an *\<EnableDotNetRemoting>* tag in the *\<SLNet>* section of the *MaintenanceSettings.xml* file, and set this tag to “false”.<!-- RN 31498+36023 -->

Example:

```xml
<MaintenanceSettings>
  ...
  <SLNet>
    ...
    <EnableDotNetRemoting>false</EnableDotNetRemoting>
    ...
  </SLNet>
  ...
</MaintenanceSettings>
```

> [!IMPORTANT]
> Make sure this is configured the same way for all Agents in a DMS.

## Configuring the ports for .NET Remoting and/or XML Web Services

On a DMA, you can specify the ports to be used for both .NET Remoting and (for legacy DMAs) XML Web Services.

1. On the DataMiner Agent on which you want to configure these settings, go to the *C:\\Skyline DataMiner\\Files* directory.

1. In a text editor (e.g. Microsoft Notepad), open *SLNet.exe.config*.

1. Optionally, and prior to DataMiner 10.0.11 only, in the *appSettings* section, go to the *TcpWebServicePort* key, and set its “value” attribute to the port number to be used for XML Web Services. By default, this will be port 9004:

   ```xml
   <add key="TcpWebServicePort" value="9004" />
   ```

   > [!NOTE]
   > The default port 9004 for XML Web Services is deprecated from DataMiner 9.6 onwards. Using Web Services for DMA communication is no longer supported from DataMiner 10.0.11 onwards.

1. In the Channels section, go to the channel tag named SLNetRemoting, and set its “port” attribute to the port number to be used for .NET Remoting. By default, this will be port 8004:

    ```xml
    <channel
      ref="http"
      name="SLNetRemoting"
      port="8004"
      timeout="300000"
      clientConnectionLimit="200">
    ```

1. Save and close the file.

1. Restart DataMiner.
