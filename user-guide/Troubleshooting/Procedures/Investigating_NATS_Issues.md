---
uid: Investigating_NATS_Issues
---

# Investigating NATS issues

To investigate NATS issues, follow the actions detailed below, in the specified order:

1. [Look for the SLMessageBroker.Crash.txt and SLMessageBroker.txt file](#look-for-the-slmessagebrokercrashtxt-and-slmessagebrokertxt-file)
1. [Check if the installation and clustering were successful](#check-if-the-installation-and-clustering-were-successful)
1. [Check the configuration in SLCloud.xml](#check-the-configuration-in-slcloudxml)
1. [Check if NAS and NATS are running](#check-if-nas-and-nats-are-running)
1. [Check the configs](#check-the-configs)
1. [Try a NATS reset](#try-a-nats-reset)
1. [Check if new NATS connections can be established](#check-if-new-nats-connections-can-be-established)
1. [Check the NAS and NATS logging](#check-the-nas-and-nats-logging)
1. [Check if port is already in use](#check-if-port-is-already-in-use)
1. [Remaining steps](#remaining-steps)


It may also be useful to understand the [algorithms used by DataMiner to configure NATS](#algorithms-used-by-dataminer-to-configure-nats).

> [!NOTE]
> - These are advanced procedures that are only meant for administrators. If you do not feel confident applying any of these procedures, contact Skyline Communications.
> - Some steps may refer to interfaces/classes of SLMessageBroker.dll, the wrapper for the NATS interface. These will likely only be useful for developers.

## Look for the SLMessageBroker.Crash.txt and SLMessageBroker.txt file

In the `C:\Skyline DataMiner\Logging` folder, look for the file **SLMessageBroker.Crash.txt**. This file is generated whenever a process fails to create an ISLMessageBroker (i.e. an instance of the wrapper for the NATS interface). Unless the problem lies with NATS itself, this file can immediately point you in the right direction to solve the problem.

These are some of the most frequently occurring errors logged in this file:

- **Could not connect to server**: This means that it was not possible to connect to any of the servers specified in `C:\Skyline DataMiner\SLCloud.xml`. This error occurs when either NATS is not correctly configured, or SLCloud.xml mentions the wrong servers.

- **No response from streaming server with id XYZ**: This means NATS streaming was unable to connect, but NATS itself was able to connect. (The NATS streaming connection, also known as STAN, is only established if the underlying NATS connection is OK.) This error occurs when either there is a problem with the streaming section of the NATS config file (`C:\Skyline DataMiner\NATS\nats-streaming-server\nats-server.config`), or the cluster ID in the *SLCloud.xml* file does not match the one in *nats-server.config*.

- **Invalid SLCloud.xml (missing attribute)**: When NATS is installed, attributes should be filled in automatically. If attributes are missing, most likely something went wrong during NATS installation so that it is not correctly installed.

In the same DMA folder, also look for the file **SLMessageBroker.txt**. This file logs information whenever a NATS or STAN connection is established (when an ISLMessageBroker is created or recovers from a disconnect). If **successful reconnects** are logged after the last error in the .Crash file, it is possible that there was only a temporary disconnect that is already resolved. If this happens, a **restart of the service or DMA** will likely solve the problem. If the problem is indeed gone after a restart, you may want to investigate if the app causing the problem can be made more resilient (e.g. by installing the latest updates).

## Check if the installation and clustering were successful

An unsuccessful installation will typically result in one or more of the following scenarios:

- The folder `C:\Skyline DataMiner\NATS\` does not exist.

- SLCloud.xml is missing or incomplete (see [Check the configuration in SLCloud.xml](#check-the-configuration-in-slcloudxml)).

- The NAS and/or NATS services are missing (see [Check if NAS and NATS are running](#check-if-nas-and-nats-are-running)).

- NAS and/or NATS fail to start because of an invalid configuration (see [Check the configs](#check-the-configs)).

For error information, check the logging in `C:\Skyline DataMiner\Logging`.

- If any errors occurred during installation, an error will be logged in *SLCcaEndpointManager.txt*.

- If something went wrong during clustering, an error will be logged in *SLNatsCustodian.txt*.

> [!NOTE]
> - The above-mentioned log files will contain much more useful information on level 5 than they do on log level 0.
> - The clustering step is skipped if the DMA is a standalone Agent.

## Check the configuration in SLCloud.xml

Even if NATS is configured correctly, you will still encounter issues if *SLCloud.xml* does not contain the right NATS servers. This file should contain all servers that ISLMessageBroker can connect to. Note that this does not necessarily include the local NATS service (e.g. in a cluster of 2 Agents).

Example of *SLCloud.xml* on a standalone DMA:

```xml
<?xml version="1.0" encoding="utf-8"?>
<SLCloud xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <!-- Path to the .creds file used by MessageBroker to connect with the NATS cluster. These are credentials and should be treated as secrets-->
  <NatsCredsFile>C:\Skyline DataMiner\NATS\nsc\.nkeys\creds\DataMinerOperator\DataMinerAccount\DataMinerUser.creds</NatsCredsFile>
  <!-- ClientID used by MessageBroker when connecting. Any short string is fine here. -->
  <ClientID>LAURENSVG</ClientID>
  <!-- Cluster ID of the STAN cluster you want to connect to. Should match with nats-server.config -->
  <ClusterID>SLUMS</ClusterID>
  <NATSServers>
    <!-- NATS node that can be connected to -->
    <NATSServer>
      <!-- URI of the entrypoint into the NATS node -->
      <URI>nats://LAURENSVG:4222</URI>
    </NATSServer>
  </NATSServers>
  <WebServers />
</SLCloud>
```

## Check if NAS and NATS are running

Double-check the status of NAS ([NATS Account Server](https://github.com/nats-io/nats-account-server)) and NATS in the Task Manager.

There is no case where NAS or NATS are stopped on purpose. However, it can occur that NATS is stuck in the "stopping" state and *nats-streaming-server.exe* has to be manually killed in order for the process to be able to restore itself.

If you see that NAS is running but NATS is not, the most likely cause is a **firewall issue**. When NATS is installed, entries are automatically added to the Windows Firewall, but if there is an additional firewall in between the DMAs in a DMS, the rules need to be added/modified manually. The ports that need to be opened are **4222** (NATS communication), **6222** (NATS clustering), and **9090** (NAS). These ports need to be opened between all DMAs. Port 8222 is also used, but for monitoring only, so this port does not have to be opened in the firewall.

> [!NOTE]
> The mentioned ports should be opened in the firewall as an inbound rule with the "All" profile. This means that if you go to *Properties* > *Advanced* > *Profiles* for the firewall rule, all checkboxes (*Domain*, *Private*, and *Public*) should be selected.

Typically, in case of a firewall issue, if you check the *nats-account-server.log* file in the folder `C:\Skyline DataMiner\NATS\nats-account-server\` of the DMA where NATS does not start, you will see a message like this near the top of the file: "*Unable to initialize from primary, will use what is on disk*".

## Check the configs

Compare the actual contents of each config to the example configs below. Depending on the number of DMAs in the cluster (a Failover pair counts as 2 DMAs), the expected config will be different.

A few details to pay attention to:

- If NATS is configured as standalone, the resolver in *nats-server.config* will be set to 0.0.0.0. This is the only difference with the config in case of 2 DMAs, where the resolver is set to one of the DMAs' IP addresses. It must be the same IP address for both DMAs.

- The cluster ID must be identical on all DMAs in the cluster.

- In a cluster of 3 or more DMAs, there is always exactly 1 primary NAS. All non-primary NAS must have the same primary configured.

- In a cluster of 3 or more DMAs, every DMA must have a unique node ID. By default, this is generated based on the IP of the DMA. NATS internally makes subscriptions based on these IDs, so some non-alphanumeric characters (quotes, periods, underscores, lesser/greater than, etc.) should be avoided.

### nats-server.config

#### Cluster of 3 or more DMAs

This is an example of **nats-server.config** in a NATS cluster of 3 or more Agents:

```txt
port: 4222 # Port for client connections
max_payload: 30000000 # maximum number of bytes in a message payload
http_port: 8222 # http port for server monitoring
operator: "C:\\Skyline DataMiner\\NATS\\nsc\\.nsc\\nats\\DataMinerOperator\\DataMinerOperator.jwt" # Path to operator JWT
resolver: URL(http://0.0.0.0:9090/jwt/v1/accounts/) # URL to nats-account-server. Example: URL(http://10.11.3.201:9090/jwt/v1/accounts/)
debug: true
trace: true
logtime: true
log_file: "C:\\Skyline DataMiner\\NATS\\nats-streaming-server\\nats-server.log" # Path to the log file (nats-server.log)
streaming: {
    cluster_id: "UUEtVGVzdC1DbHVzdGVyNA==" # Cluster name
    store_limits: {
        max_age: "600s" # How long messages can stay in the log
        max_inactivity: "600s" # How long without any subscription and any new message before a channel can be automatically deleted
        max_channels: 0 # Maximum number of channels, 0 means unlimited
        max_msgs: 0 # Maximum number of messages per channel, 0 means unlimited
        max_subs: 0 # Maximum number of subscriptions per channel, 0 means unlimited
        max_bytes: 0 # Total size of messages per channel, 0 means unlimited
    }
    credentials: "C:\\Skyline DataMiner\\NATS\\nsc\\.nkeys\\creds\\DataMinerOperator\\DataMinerAccount\\DataMinerUser.creds" # Credentials file to connect to external NATS 2.0+ Server
    cluster: {
        peers: ["0A-0A-49-0A","0A-0A-49-14"]
        node_id: "0A-0A-49-28"
        log_path: "C:\\Skyline DataMiner\\NATS\\nats-streaming-server\\raftLogging"
    }
    store: "file"
    dir: "C:\\Skyline DataMiner\\NATS\\nats-streaming-server\\fileStore"
}
cluster: {
    name: DMS # Same on each node. Does not need to be the same as streaming.cluster_id
    routes: ["nats://10.10.73.10:6222/","nats://10.10.73.20:6222/"]
    listen: 0.0.0.0:6222
}
server_name: MyServerName # Unique on each node
```

The following values can vary in each DMS:

- **streaming.cluster_id**: Based on the cluster name in DataMiner.
- **streaming.cluster.peers** and **streaming.cluster.node_id**: Based on the IP of the local Agent.
- **cluster.routes:** IP addresses of up to 4 other Agents in the cluster.

#### Cluster of 2 DMAs

This is an example of **nats-server.config** in a NATS cluster of exactly 2 Agents:

```txt
port: 4222 # Port for client connections
max_payload: 30000000 # maximum number of bytes in a message payload
http_port: 8222 # http port for server monitoring
operator: "C:\\Skyline DataMiner\\NATS\\nsc\\.nsc\\nats\\DataMinerOperator\\DataMinerOperator.jwt" # Path to operator JWT
resolver: URL(http://10.103.0.22:9090/jwt/v1/accounts/) # URL to nats-account-server. Example: URL(http://10.11.3.201:9090/jwt/v1/accounts/)
debug: false
trace: false
logtime: true
logfile_size_limit: 10MB
log_file: "C:\\Skyline DataMiner\\NATS\\nats-streaming-server\\nats-server.log" # Path to the log file (nats-server.log)
streaming: {
    cluster_id: SLUMS # Cluster name
    store_limits: {
        max_age: "600s" # How long messages can stay in the log
        max_inactivity: "600s" # How long without any subscription and any new message before a channel can be automatically deleted
        max_channels: 0 # Maximum number of channels, 0 means unlimited
        max_msgs: 0 # Maximum number of messages per channel, 0 means unlimited
        max_subs: 0 # Maximum number of subscriptions per channel, 0 means unlimited
        max_bytes: 0 # Total size of messages per channel, 0 means unlimited
    }
    credentials: "C:\\Skyline DataMiner\\NATS\\nsc\\.nkeys\\creds\\DataMinerOperator\\DataMinerAccount\\DataMinerUser.creds" # Credentials file to connect to external NATS 2.0+ Server
}
server_name: MyServerName
```
  
The only difference between this config and a config of an Agent that has a standalone NATS is that the resolver is different from 0.0.0.0.

#### Standalone NATS

This is an example of **nats-server.config** for a standalone Agent.

```txt
port: 4222 # Port for client connections
max_payload: 30000000 # maximum number of bytes in a message payload
http_port: 8222 # http port for server monitoring
operator: "C:\\Skyline DataMiner\\NATS\\nsc\\.nsc\\nats\\DataMinerOperator\\DataMinerOperator.jwt" # Path to operator JWT
resolver: URL(http://0.0.0.0:9090/jwt/v1/accounts/) # URL to nats-account-server. Example: URL(http://10.11.3.201:9090/jwt/v1/accounts/)
debug: false
trace: false
logtime: true
logfile_size_limit: 10MB
log_file: "C:\\Skyline DataMiner\\NATS\\nats-streaming-server\\nats-server.log" # Path to the log file (nats-server.log)
streaming: {
    cluster_id: SLUMS # Cluster name
    store_limits: {
        max_age: "600s" # How long messages can stay in the log
        max_inactivity: "600s" # How long without any subscription and any new message before a channel can be automatically deleted
        max_channels: 0 # Maximum number of channels, 0 means unlimited
        max_msgs: 0 # Maximum number of messages per channel, 0 means unlimited
        max_subs: 0 # Maximum number of subscriptions per channel, 0 means unlimited
        max_bytes: 0 # Total size of messages per channel, 0 means unlimited
    }
    credentials: "C:\\Skyline DataMiner\\NATS\\nsc\\.nkeys\\creds\\DataMinerOperator\\DataMinerAccount\\DataMinerUser.creds" # Credentials file to connect to external NATS 2.0+ Server
}
server_name: MyServerName
```  

> [!NOTE]
> - From DataMiner 10.1.0 \[CU12]/10.2.3 onwards, STAN is no longer used by the core processes because of performance issues. The streaming configuration can therefore be simplified as follows:
>
> ```txt
> streaming: {
>    cluster_id: SomeName # Unique on each node
>    credentials: "C:\\Skyline DataMiner\\NATS\\nsc\\.nkeys\\creds\\DataMinerOperator\\DataMinerAccount\\DataMinerUser.creds" # Credentials file to connect to external NATS 2.0+ Server
> }
> ```

### nas.config

There should only be one primary NAS in each DMS, with the configuration detailed below. Every other NAS should be configured as a secondary, except in a cluster of exactly 2 Agents.

In a cluster of exactly 2 Agents, both NATS configs will point to the same NAS in their resolver setting. The other NAS will be running, but neither NATS will connect to it.

#### Primary NAS

```txt
http: {
    host: 0.0.0.0 # Interface to listen for requests on
    port: 9090 # Port to listen for requests on.
}
nats: {
    servers: ["localhost:4222"] # List of NATS servers for the account server to use when connecting to a NATS server to publish updates
    usercredentials: "C:\\Skyline DataMiner\\NATS\\nsc\\.nkeys\\creds\\DataMinerOperator\\NASAccount\\NASUser.creds" # A credentials .creds file for connecting to the NATS server. User must be a member of a system account.
}
store: {
    dir: "C:\\Skyline DataMiner\\NATS\\nsc\\JWTs" # Configures a dir mode store.
    readonly: True # Host the store as read-only. No changes through POST requests allowed.
}
```

#### Secondary NAS

```txt
http: {
    host: 0.0.0.0 # Interface to listen for requests on
    port: 9090 # Port to listen for requests on.
}
nats: {
    servers: ["localhost:4222"] # List of NATS servers for the account server to use when connecting to a NATS server to publish updates
    usercredentials: "C:\\Skyline DataMiner\\NATS\\nsc\\.nkeys\\creds\\DataMinerOperator\\NASAccount\\NASUser.creds" # A credentials .creds file for connecting to the NATS server. User must be a member of a system account.
}
primary: http://10.103.0.22:9090 # the URL for the primary server, sets the server to run in replica mode, the format of the url is protocol://host:port
```

## Try a NATS reset

Almost all configuration issues can be resolved by manually triggering a NATS reset.

To trigger a NATS reset:

1. Use SLNetClientTest tool to connect to any DMA in the cluster. For more information, see [SLNetClientTest tool](xref:SLNetClientTest_tool).

1. In the *Build Message* tab, select the message *Skyline.DataMiner.Net.Apps.NATSCustodian.NATSCustodianResetNatsRequest*.

1. Leave all fields set to the default values (*IsDistributed* = false) and click *Send Message*.

This will recalculate the NAS and NATS configs in the entire cluster, so any faulty configurations are cleaned up automatically.

## Check if new NATS connections can be established

Try restarting things one by one to see whether their functionality is restored, or whether the error changes:

1. Restart the service that is having issues.

1. Restart the DataMiner Agent.

1. Restart the NATS service.

1. Restart both the NATS and NAS service.

## Check the NAS and NATS logging

To check the NAS logging, usually the logging of the server that is configured as resolver on the NATS server that is having issues will suffice.

When you check the NATS logging, it is important that you check the logging of all NATS servers in the cluster. If NATS is running as a cluster, it needs to maintain a certain degree of consistency (this is done through the [RAFT](https://docs.nats.io/running-a-nats-service/configuration/clustering/jetstream_clustering#raft) consensus algorithm). If NATS receives conflicting info from its peers, it will shut itself down.

For example, in a cluster of 4 agents, the following situation could occur:

- Agent 1 can only reach Agent 2.
- Agent 2 can reach every Agent.
- Agent 3 can only reach Agents 2 and 4.
- Agent 4 can only reach Agents 3 and 4.

This will result in Agent 2 receiving different information about the same cluster from its peers. Because Agent 2 cannot resolve this, it will shut itself down, without stating a particular reason for doing so. This makes it look like Agent 2 is the one experiencing issues because it is the only one where NATS will not start. However, it is in fact the only server where all the connections are working correctly.

## Check if port is already in use

NATS uses port 9090 by default. If another program is already using this port, you will notice the following behavior:

- DataMiner fails to start.

- NAS is running.

- NATS is stopped.

- Several 2kB large log files can be found in the *C:\Skyline DataMiner\NATS\nats-account-server* folder.

  > [!NOTE]
  > The number of log files in this folder can increase rapidly (over 30,000 files in 12 hours).

  The log files contain the following entry:

  `listen tcp 0.0.0.0:9090: bind: Only one usage of each socket address (protocol/network address/port) is normally permitted.`

The 9090 port may already be in use if your DMA has elements using [GPIB communication](xref:GPIB_Connection) and you have the [Keysight Connection Expert software](xref:Installing_the_Keysight_Agilent_IO_Libraries) from IO Libraries installed. This is commonly the case for [spectrum analyzer elements](xref:Connecting_spectrum_analyzers_to_your_DataMiner_System).

Check whether Keysight Agilent IO Libraries or a different third-party software is using the 9090 port:

1. Ensure that NAS and NATS are stopped.

1. Run the following command in a command prompt window: `netstat -aon | findstr 9090`.

1. If you identify a process using port 9090, open Windows Task Manager to find the process PID, e.g. *kdi-controller.exe*.

### Manually configuring a custom port for NATS

To resolve this issue, manually configure a custom port for NATS that is not yet in use, e.g. port 9091.

1. Stop DataMiner and the NAS and NATS services.

1. Make sure SLWatchdog is stopped.

1. Open *C:\Skyline DataMiner\NATS\nats-account-server\nas.config* and change the port from 9090 to your chosen custom port, e.g. 9091.

1. Run the following command in a command prompt window: `nssm edit NAS`.

1. Change any mentions of 9090 to 9091.

1. Open *C:\Skyline DataMiner\NATS\nats-streaming-server\nats-server.config* and change the port from 9090 to 9091.

1. In Windows Firewall, locate the inbound rule for NAS. Change the port from 9090 to 9091.

1. Open *C:\Skyline DataMiner\MaintenanceSettings.xml* and add the following lines:

   ```xml
   <SLNet>
   <NATSForceManualConfig>true</NATSForceManualConfig>
   </SLNet>
   ```

1. Start the NAS and NATS services.

1. Start DataMiner.

1. Repeat this process for every Agent in the cluster.

## Remaining steps

If you continue to have NATS issues, try the following steps:

1. Stop DataMiner.

1. Open a command window as Administrator.

1. Navigate to `C:\Skyline DataMiner\Files` and run .\SLEndpointTool_Console.exe.

1. Uninstall NAS

   ```cmd
   CMD
   C:\Skyline DataMiner\Files>.\SLEndpointTool_Console.exe
   Install or Uninstall? (I/U): U
   You have chosen to Uninstall
   Root installation directory? (Empty for default):
   Resource directory? (Empty for default):
   Which endpoint? (NAS, NATS, API, Swarming): NAS
   Use default values? (Y/N): Y
   You have chosen to use the DEFAULTS
   ...
   ```

1. Verify that the `C:\Skyline DataMiner\NATS` folder is empty and that the NATS/NAS services are gone from the Task Manager.

1. Run the SLEndpointTool_Console.exe tool again.

1. Install NATS.

   ```cmd
   CMD
   C:\Skyline DataMiner\Files>.\SLEndpointTool_Console.exe
   Install or Uninstall? (I/U): I
   You have chosen to Install
   Root installation directory? (Empty for default):
   Resource directory? (Empty for default):
   Which endpoint? (NAS, NATS, API, Swarming): NATS
   Use default values? (Y/N): Y
   You have chosen to use the DEFAULTS
   ...
   ```

1. Verify that the NATS/NAS services are running again, that the folders were created under `C:\Skyline DataMiner\NATS` and that the firewall rules are OK (port 9090, 4222 and 6222 should be open).

1. Start DataMiner.

This will leave the system with a standalone NATS setup with all default settings. If the DMA is in a cluster and/or Failover pair, restart the DMA and send a *NATSCustodianResetNatsRequest* message to any DMA in the cluster that is not an offline Failover Agent (see [Try a NATS reset](#try-a-nats-reset)). This will trigger the NATS reset routine on all DMAs in the cluster, which recalculates the entire NAS and NATS configuration on the entire cluster and restarts both services.

## Algorithms used by DataMiner to configure NATS

### Clustering algorithms

The NATS clustering configuration is managed by the *NATSCustodian* class in SLNet. When you send a *NatsCustodianResetNatsRequest* to the server, this is the class the message ends up in.

> [!NOTE]
> When configuration is mentioned in this section, the actual NATS/NAS configuration is meant:
> - NAS configuration file: `C:\Skyline DataMiner\NATS\nats-account-server\nas.config`
> - NATS configuration file: `C:\Skyline DataMiner\NATS\nats-streaming-server\nats-server.config`

First, the algorithm will collect all the reachable primary IPs in the cluster (including the local IP).

- If no reachable IPs are found, an error is thrown and the algorithm exits.

- If only 1 reachable IP is found and the local system is NOT in a Failover setup, the config will be reverted to the “standalone” config. This is the same as the default config when first installing NATS. The algorithm exits after this. Otherwise, it will sort all the nodes by IP (sortedNodes).

- If only 2 nodes are found, a special algorithm will be run designed for 2 nodes only. It will first reset both nodes to the standalone configuration. Then it will select the node with the alphabetically first IP address or hostname and configure that one as “master” and the other as “guest”. The master node will be left as the default config, while the guest node will be configured to use NATS and NAS from the master node. This means that the guest node will still be running the NAS and NATS service, but the DataMiner Agent will never connect to it; it will always connect with the NATS of the master node. This is needed because a cluster of exactly 2 NATS nodes is impossible. This can be a vulnerability on systems that run a standalone Failover setup. If the master node goes down for any reason, the guest node will no longer be able to use NATS either.

- If 3 or more nodes are detected, the algorithm will cluster them all together.

  1. Using the sorted IPs, it will try to find the next 4 IPs in the list after itself and use these as routes and peers. The list is iterated in a wrap-around fashion so that the last few IPs in the sorted list still get up to 4 peers/routes. A node will never select itself as a peer/route.

  1. Node IDs are set using the IPs of the machines, noted down in a hexadecimal fashion. For example, IP 10.10.73.40 corresponds with node ID "0A-0A-49-28".

  1. The filestore and raft logging are cleaned up (`..\NATS\nats-streaming-server\fileStore` and `..\NATS\nats-streaming-server\raftLog`). This is done to remove any references and cached data from the previous cluster configuration.

  1. The alphabetically first IP or hostname is selected to become the primary NAS; all the other nodes are configured as a secondary NAS and will reference the primary NAS.

  1. The cluster ID is set using the DMS cluster name, transformed to Base64 string. This transformation is done to prevent special symbols in the cluster ID.

  1. *SLCloud.xml* is updated with the new configuration.

This algorithm is run on all DMAs at the same time and will only change the configuration of the local NAS/NATS/DMA. It is therefore important that all DMAs in your cluster are online and reachable when you run the NATS reset.
