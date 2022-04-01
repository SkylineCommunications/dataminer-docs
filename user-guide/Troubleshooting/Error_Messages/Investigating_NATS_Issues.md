---
uid: Investigating_NATS_Issues
---

# Investigating NATS Issues

- [Investigating NATS Issues](#investigating-nats-issues)
      - [Is there an SLMessageBroker.Crash.txt file?](#is-there-an-slmessagebrokercrashtxt-file)
      - [Were the installation and clustering successful?](#were-the-installation-and-clustering-successful)
      - [What's in SLCloud.xml?](#whats-in-slcloudxml)
      - [Are NAS and NATS running?](#are-nas-and-nats-running)
      - [What do the configs look like?](#what-do-the-configs-look-like)
      - [Does a NATS reset fix it?](#does-a-nats-reset-fix-it)
      - [Can new NATS connections be established?](#can-new-nats-connections-be-established)
      - [What's in the NAS and NATS logging?](#whats-in-the-nas-and-nats-logging)
      - [If all else fails](#if-all-else-fails)
- [Algorithms used by DataMiner for configuring NATS](#algorithms-used-by-dataminer-for-configuring-nats)
      - [Clustering algorithms](#clustering-algorithms)

The following is a list of actions that can be taken in order to investigate NATS issues. Parts of this may reference to interfaces/classes of SLMessageBroker.dll (this is our wrapper for the NATS interface) which will likely only be useful for developers.

#### Is there an SLMessageBroker.Crash.txt file?

*C:\Skyline DataMiner\Logging\SLMessageBroker.Crash.txt* is a file that is generated whenever a process failed to create an ISLMessageBroker (aka an instance of our wrapper). If the problem lies with NATS itself, then this file generally isn't very useful, but it's always worth checking it first because it might just immediately solve the problem or point you in the right direction
Some of the most frequent errors:

- **Could not connect to server:** This means none of the servers in *C:\Skyline DataMiner\SLCloud.xml* could be connected to. Either NATS isn't configured correctly, or SLCloud.xml contains the wrong servers.
- **No response from streaming server with id XYZ:** This means NATS streaming was unable to connect, but NATS itself was able to connect (the NATS streaming connection, also known as STAN, is only established if the underlying NATS connection is OK). Either there's a problem specifically with the streaming section of the NATS config file (*C:\Skyline DataMiner\NATS\nats-streaming-server\nats-server.config*) , or the Cluster ID in the SLCloud.xml doesn't match the one in nats-server.config
- **Invalid SLCloud.xml (missing attribute):** Attributes are normally filled in automatically when NATS is installed. IF attributes are missing, there's a good chance something went wrong during installation and NATS isn't (correctly) installed.

Additionally check *C:\Skyline DataMiner\Logging\SLMessageBroker.txt*. This file logs information whenever a NATS or STAN connection is established (when an ISLMessageBroker is created or recovers from a disconnect). If successful reconnects are logged after the last error in the .Crash file, it's possible that there was just a temporary disconnect that's already resolved. If this happens, a restart of the service or DMA will likely make the problem go away. If the problem is indeed gone after a restart, you may want to investigate if the app causing the problem can be made more resilient (e.g. by installing the latest updates)

#### Were the installation and clustering successful?

An unsuccessful installation will typically result in one or more of the following scenarios:

- The folder *C:\\Skyline DataMiner\\NATS\\* doesn't exist.
- The NAS and/or NATS services are missing
- NAS and/or NATS fail to start because of an invalid configuration (see What do the configs look like?)
- SLCloud.xml is missing or incomplete

For error information, check the logging in *C:\Skyline DataMiner\Logging*

- If any errors occurred during installation, an error will be logged in *SLCcaEndpointManager.txt*
- If something went wrong during clustering, an error will be present in *SLNatsCustodian.txt*

Note that these log files will contain much more useful logging on level 5 than they do on log level 0.
The clustering step is skipped if the DMA is a standalone agent.

#### What's in SLCloud.xml?

NATS can be configured correctly, but none of that matters if SLCloud.xml doesn't contain the right NATS servers. It should contain all servers that ISLMessageBroker can connect to. Note that this doesn't necessarily include the local NATS service (e.g. in a cluster of 2 agents).

Example of SLCloud.xml on a standalone agent

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

#### Are NAS and NATS running?

Double-check the status of NAS ([NATS Account Server](https://github.com/nats-io/nats-account-server)) and NATS in the Task Manager.
There is no case where NAS and/or NATS are stopped on purpose. However, a problem was encountered in the past where NATS was stuck in the "stopping" state and nats-streaming-server.exe had to be manually killed in order for the process to be able to restore itself.

If you see that NAS is running but NATS is not, the most likely cause is a firewall issue. When NATS is installed, entries are automatically added to the Windows Firewall, but if there's an additional firewall in between the DMAs in a DMS, the rules need to be added/modified manually. The ports that need to be opened are 4222 (NATS communication), 6222 (NATS clustering), 9090 (NAS). They need to be opened between all DMAs. 8222 is for monitoring only and doesn't have to be opened in the firewall.

Typically, in case of a firewall issue, the *C:\Skyline DataMiner\NATS\nats-account-server\nats-account-server.log* file of a DMA where NATS doesn't start will contain something similar to this near the top of the file: "Unable to initialize from primary, will use what is on disk".

#### What do the configs look like?

Compare the actual contents of each config to the example configs below. Depending on the number of DMAs in the cluster (a failover pair counts as 2 DMAs), the expected config will be different.

A few details to pay attention to:

- If NATS is configured as standalone, the resolver in nats-server.config will be set to 0.0.0.0. This is the only difference with the config in case of 2 DMAs, where the resolver is set to one of the DMAs' IP addresses. It must be the same one for both DMAs!
- The Cluster ID must be identical on all DMAs in the cluster. 
- In a cluster of 3 or more agents, there is always exactly 1 primary NAS. All non-primary NAS must have the same primary configured.
- In a cluster of 3 or more DMAs, every DMA must have a unique Node ID. By default, this is generated based on the IP of the DMA. NATS internally makes subscriptions based on these IDs, so some non-alphanumeric characters (quotes, dots, underscores, lesser/greater than, etc.) should be avoided.

**nats-server.config:**
NATS cluster of 3 ore more agents

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
    routes: ["nats://10.10.73.10:6222/","nats://10.10.73.20:6222/"]
    listen: 0.0.0.0:6222
}
```

The following values can vary on each DMS:

- **streaming.cluster_id:** Based on the cluster name in DataMiner.
- **streaming.cluster.peers:** streaming.cluster.node_id: Based on the IP of the local Agent.
- **cluster.routes:** IP addresses of up to 3 other agents in the cluster

NATS cluster of exactly 2 agents

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
```
  
The only difference between this config and a config of an agent that has a standalone NATS is that the resolver is different from 0.0.0.0

Standalone NATS

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
```  

nas.config:
Primary NAS

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

There should only be one primary NAS in each DMS. Every other NAS should be configured as a secondary. The exception to this is a cluster of exactly 2 agents, where both NATS configs will point to the same NAS in their resolver setting. The other NAS will be running, but neither NATS will connect to it.

Secondary NAS

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

#### Does a NATS reset fix it?

Almost all configuration issues can be resolved by manually triggering a NATS reset.
To trigger a NATS reset:

1. Use Client Test Tool, connect to any DMA in the cluster.
2. Send a NATSCustodianResetNatsRequest message, leaving all fields to the default values (IsDistributed = false)

This will recalculate the NAS and NATS configs in the entire cluster, so any faulty configurations are cleaned up automatically.

#### Can new NATS connections be established?

Try restarting things one by one to see whether its functionality is restored, or whether the error changes. Restart things in the following order:

1. The service that's having issues
2. The entire DMA
3. The NATS service.
4. Both the NATS and NAS Servicee

#### What's in the NAS and NATS logging?

To check the NAS logging, usually the logging of the server that's configured as resolver on the NATS server that's having issues will suffice.
When checking the NATS logging, it's important that you check the logging of all ANTS servers in the cluster. If NATS is running as a cluster, it needs to maintain a certain degree of consistency (this is done through the [RAFT](https://docs.nats.io/running-a-nats-service/configuration/clustering/jetstream_clustering#raft) consensus algorithm). If NATS receives conflicting info from its peers, it will simply shut itself down.

For example, take a case where in a cluster of 4 agents:

- Agent 1 can only reach Agent 2,
- Agent 2 can reach every Agent,
- Agent 3 can only reach Agents 2 and 4,
- Agent 4 can only reach Agents 3 and 4,

This will result in Agent 2 receiving different information about the same cluster from its peers. Because Agent 2 can't resolve this, it will simply shut itself down, without stating a particular reason for doing so. This makes it look like Agent 2 is the one that's experiencing issues because it's the only one where NATS won't start, while it's the only server where all the connects are working correctly.

#### If all else fails

- Stop DataMiner
- Open CMD as Administrator
  - This is necessary because the tool we will run creates/modifies firewall rules on windows
- Navigate to C:\Skyline DataMiner\Files and run SLEndpointTool_Console.exe
- Uninstall NAS

```cmd
CMD
C:\Skyline DataMiner\Files>SLEndpointTool_Console.exe
Install or Uninstall? (I/U): U
You have chosen to Uninstall
Root installation directory? (Empty for default):
Resource directory? (Empty for default):
Which endpoint? (NAS, NATS, API, Swarming): NAS
Use default values? (Y/N): Y
You have chosen to use the DEFAULTS
...
```

- Verify that the C:\Skyline DataMiner\NATS folder is empty and the NATS/NAS services are gone from the task manager
- Run the SLEndpointTool_Console.exe tool again
- Install NATS

```cmd
CMD
C:\Skyline DataMiner\Files>SLEndpointTool_Console.exe
Install or Uninstall? (I/U): I
You have chosen to Install
Root installation directory? (Empty for default):
Resource directory? (Empty for default):
Which endpoint? (NAS, NATS, API, Swarming): NATS
Use default values? (Y/N): Y
You have chosen to use the DEFAULTS
...
```

- Verify that the NATS/NAS services are running again, that the folders were created under C:\Skyline DataMiner\NATS and that the firewall rules are OK (port 9090, 4222 and 6222 should be open)
- Start DataMiner

This will leave the system with a standalone NATS setup with all default settings. If that DMA is in a cluster and/or Failover pair, restart the Agent and send a NATSCustodianResetNatsRequest (IsDistributed = false) to any Agent in the cluster that's not an offline Failover agent. This will trigger the NATS reset routine on all Agents in the cluster, which recalculates the entire NAS and NATS configuration on the entire cluster and restarts both services.

# Algorithms used by DataMiner for configuring NATS

#### Clustering algorithms

NATS clustering configuration is managed by the NATSCustodian class in SLNet. When you send a NatsCustodianResetNatsRequest to the server, this is the class the message ends up in.

When configuration is mentioned in this section, the actual NATS/NAS configuration is mentioned:

- NAS configuration file: *C:\Skyline DataMiner\NATS\nats-account-server\nas.config*
- NATS configuration file: *C:\Skyline DataMiner\NATS\nats-streaming-server\nats-server.config*

First, the algorithm will collect all the reachable primary IPs in the cluster (including the local IP). If no reachable IPs are found, an error is thrown and the algorithm exits.

If only 1 reachable IP is found and the local system is NOT in a Failover setup, the config will be reverted to “standalone”. This is the same as the default config when first installing NATS. The algorithm exits after this.

Otherwise, it will sort all the nodes by IP (sortedNodes).

If only 2 nodes are found, a special algorithm will be run designed for 2 nodes only. It will first reset both nodes to the standalone configuration. Then it will select the node with the lowest IP address and configure that one as “master” and the other as “guest”. The master node will be left as the default config, while the guest node will be configured to use NATS and NAS from the master node. This means that the guest node will still be running the NAS and NATS service, but the DataMiner Agent will never connect to it; it will always connect with the NATS of the master node. This is needed because a cluster of exactly 2 NATS nodes is impossible. This can be a vulnerability on systems that run a standalone Failover setup. If the master node goes down for any reason, the guest node will no longer be able to use NATS as well.

If 3 or more nodes are detected, the algorithm will cluster them all together.

1. Using the sorted IPs, it will try to find the next 4 IPs in the list after itself and use these as routes and peers. The list is iterated in a wrap-around fashion so that the last few IPs in the sorted list still get up to 4 peers/routes. A node will never select itself as a peer/route.
2. NodeIDs are set using the IPs of the machines, noted down in a hexadecimal fashion: ip: 10.10.73.40 => node_id: "0A-0A-49-28"
3. The filestore and raft logging are cleaned up (..\NATS\nats-streaming-server\fileStore and ..\NATS\nats-streaming-server\raftLog). This is done to remove any references and cached data from the previous cluster configuration.
4. The lowest IP is selected to become the primary NAS; all the other nodes are configured as a secondary NAS and will reference the primary NAS.
5. The cluster ID is set using the DMS clustername, transformed to Base64 string. This transformation is done to prevent special symbols in the cluster ID.
6. SLCloud.xml is updated with the new configuration.

This algorithm is run on all DMAs at the same time and will only change the configuration of the local NAS/NATS/DataMiner.
It is therefore important that all DMAs in your cluster are online and reachable at the time you run the NATS Reset.
