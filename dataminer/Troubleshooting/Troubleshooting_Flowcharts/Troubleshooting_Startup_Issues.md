---
uid: Troubleshooting_Startup_Issues
---

# Troubleshooting - DataMiner startup issues

## Overview

```mermaid
flowchart TD
%% Define styles %%
linkStyle default stroke:#cccccc
classDef LightBlue fill:#9DDAF5,stroke:#000070,stroke-width:0px, color:#1E5179;
classDef Blue fill:#4BAEEA,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef DarkGray fill:#58595B,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef Gray fill:#999999,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef DarkBlue fill:#1E5179,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef classExternalRef fill:#9ddaf5,stroke:#9ddaf5,color:#1E5179,stroke-width:0px;

%% Define blocks %%
DMAStartupIssues([DMA startup issues])
ServicesRunning{{"Are all DataMiner Core Module services running? <br/>"}}
DCMIssue["DcM issue"]
AgentNotLicensed{{"Agent not licensed message in Cube? <br/>"}}
SwarmingEnabled{{"Swarming recently enabled? <br/>"}}
SLNetComFailure{{"SLNetCom failure logged in SLDataMiner.txt? <br/>"}}
IncorrectIPAddresses{{"Incorrect IP addresses in DMS.xml? <br/>"}}
NATSErrors{{"Errors related to NATS in SLDataMiner.txt + SLWatchdog2.txt? <br/>"}}
CloudSettingsErrors{{"Errors related to CloudSettings in SLCloudStorage.txt?"}}
CloudSession["Cloud session issue"]
CassandraErrors{{"Errors related to Cassandra in SLErrors.txt? <br/> "}}
LicensingIssue["Licensing issue"]
SwarmingIssue["Swarming issue"]
IPChangeIssue["IP change issue"]
NATSIssue["NATS issue"]
CassandraIssue["Cassandra issue"]
ContactTechSupport["Contact DataMiner Support"]

%% Connect blocks %%
DMAStartupIssues --- ServicesRunning
Home([Start page])
ServicesRunning --- |YES| AgentNotLicensed
ServicesRunning --- |NO| DCMIssue
AgentNotLicensed --- |YES| LicensingIssue
AgentNotLicensed --- |NO| SwarmingEnabled
SwarmingEnabled --- |YES| SwarmingIssue
SwarmingEnabled --- |NO| SLNetComFailure
SLNetComFailure --- |YES| IPChangeIssue
SLNetComFailure --- |NO| IncorrectIPAddresses
IncorrectIPAddresses --- |YES| IPChangeIssue
IncorrectIPAddresses --- |NO| NATSErrors
NATSErrors --- |YES| NATSIssue
NATSErrors --- |NO| CloudSettingsErrors
CloudSettingsErrors --- |YES| CloudSession
CloudSettingsErrors --- |NO| CassandraErrors
CassandraErrors --- |YES| CassandraIssue
CassandraErrors --- |NO| ContactTechSupport

%% Define hyperlinks %%
click Home "/dataminer/Troubleshooting/Troubleshooting_Flowcharts/Finding_a_Root_Cause.html"
click DCMIssue "/dataminer/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Startup_Issues.html#dcm-issue"
click LicensingIssue "/dataminer/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Startup_Issues.html#licensing-issue"
click SwarmingIssue "/dataminer/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Startup_Issues.html#swarming-issue"
click IPChangeIssue "/dataminer/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Startup_Issues.html#ip-change-issue"
click NATSIssue "/dataminer/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Startup_Issues.html#nats-issue"
click CloudSession "/dataminer/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Startup_Issues.html#cloud-session-token-issue"
click CassandraIssue "/dataminer/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Startup_Issues.html#cassandra-issue"
click ContactTechSupport "/dataminer/Troubleshooting/Contacting_tech_support.html"

%% Apply styles to blocks %%
class DMAStartupIssues,ContactTechSupport DarkBlue;
class LicensingIssue,SwarmingIssue,IPChangeIssue,NATSIssue,CassandraIssue,DCMIssue,CloudSession classExternalRef;
class ServicesRunning,AgentNotLicensed,SwarmingEnabled,SLNetComFailure,IncorrectIPAddresses,NATSErrors,CassandraErrors,CloudSettingsErrors Blue;
class Home LightBlue;
```

## DcM issue

### Symptoms

- DataMiner fails to start, takes too long to start, or gets stuck at 99% during the startup process.

- [DataMiner Core Module](xref:DataMinerExtensionModules#available-dcms) services are stopped.

- The server where the DMA is running has recently been rebooted.

### Root cause

Some DataMiner Core Module (DcM) services do not respond quickly enough to the Windows Service Controller after a reboot (e.g. because of Windows updates). As a consequence, these services are still stopped while the DataMiner Agent is already starting up, but DataMiner needs these services to be able to start up fully.

### Solution

1. Open Task Manager on the DMA.

1. Navigate to the **Services** tab.

1. Sort by name and locate the *DataMiner* services.

1. Start all services identified as DataMiner Core Modules (see [Available DcMs](xref:DataMinerExtensionModules#available-dcms)).

1. Restart the DataMiner Agent.

## Licensing issue

### Symptoms

- DataMiner fails to start, takes too long to start, or gets stuck at 99% during the startup process.

- DataMiner Cube displays the error message "This DataMiner Agent is not licensed", prompting you to contact the system administrator.

- Errors in the *SLDataMiner.txt* file, including:

  - No valid license file
  - Start DataMiner failed, 0x80040291

### Root cause

DataMiner cannot find a valid license to run the Agent. This issue may be caused by a **MAC address change**, which can have the following causes:

- Hardware changes (e.g. replacing network interface cards).

- NIC priority rearrangement (e.g. because of new VMs or network configurations).

- Randomized MAC addresses.

### Solution

1. Navigate to the folder `C:\Skyline DataMiner` on the DMA.

1. Copy the *Request.lic* file and send it to <dataminer.licensing@skyline.be>.

   After some time, you will receive an email with license files.

1. When you have received the license files, place them in the `C:\Skyline DataMiner` folder.

1. Restart the DataMiner Agent.

## IP change issue

Two different DataMiner startup issues are related to IP changes: DataMiner may be trying to [connect to an old IP address](#dataminer-is-trying-to-connect-to-an-old-ip-address), or there may be [incorrect IP addresses in *DMS.xml*](#incorrect-ip-addresses-in-dmsxml-cause-ip-conflicts).

### Swarming issue

If you have just enabled the [Swarming](xref:Swarming) feature and DataMiner does not start up:

- Double-check whether the DataMiner System uses a database compatible with Swarming. See [Prerequisites](xref:EnableSwarming#prerequisites).

- Check the *SLErrors.txt* and *SLSwarming.txt* log files for swarming-related errors.

- Double-check the *Swarming.xml* configuration file for errors.

- Check *SLDataMiner.txt* and *SLNet.txt* for any critical exceptions (e.g. an invalid setup is detected).

### DataMiner is trying to connect to an old IP address

#### Symptoms

- DataMiner fails to start or gets stuck at 99%.

- Error messages in *SLDataMiner.txt* indicate a failure to initialize SLNetCom.

  For example:

  ```txt
  Initializing SLNetCom
  Initializing SLNetCom failed. - There's no connection available with this dataminer. (hr = 0x800402CD)
  ```

- Authentication timeouts are indicated in *SLNet.txt*.

  For example:

  - `Destroying connection (SLAnalytics): Authentication took too long.`
  - `Destroying connection (SLDataMiner.exe): Authentication took too long.`

- *SLAnalytics.txt* mentions an exception while opening SLNetConnection.

  For example:

  `2023/12/12 17:42:20.733|SLAnalytics.txt|SLAnalytics|SLNetConnection.cpp(196): Skyline::DataMiner::Analytics::SLNetConnection::openConnection)|ERR|0|Exception while opening SLNetConnection`

- NATS logging:

  - The *nats-account-server.log* file in `C:\Skyline DataMiner\NATS\nats-account-server` mentions `connected to NATS for account and activation notifications`.
  - The *nats-server.log* file in `C:\Skyline DataMiner\NATS\nats-streaming-server` mentions `STREAM: Streaming Server is ready`.

#### Root cause

In a two-node setup, a DMA is trying to connect to a NATS instance on an old IP address.

#### Solution

1. Stop the DataMiner Agent.

1. Open the *SLCloud.xml* file.

1. In *SLCloud.xml*, change the old IP address to the new IP address.

1. Restart the DataMiner Agent.

### Incorrect IP addresses in DMS.xml cause IP conflicts

#### Symptoms

- DataMiner Agents fail to start up.

- There are IP conflicts within the cluster.

- There are discrepancies between the Failover configuration and the *DMS.xml* file: the IP addresses shown in Cube do not match those in *DMS.xml*.

#### Root cause

Incorrect IP addresses in *DMS.xml* cause IP conflicts within the DataMiner System.

> [!NOTE]
> If you check the previous *DMS.xml* versions from the `C:\Skyline DataMiner\Recycle Bin` folder, you may be able to pinpoint which change caused this issue.

#### Solution

1. Check the *DMS.xml* configuration:

   - If there are Agents in the cluster that do start up, connect to one of those Agents and compare the IP addresses in *DMS.xml* with the Failover configuration in DataMiner Cube to identify discrepancies and find the incorrect IP addresses.

   - If all Agents in the cluster fail to start up, manually inspect each *DMS.xml* file to check if the IP addresses in the file match the actual IPs assigned to each Agent.

1. Update the *DMS.xml* file with the correct IP addresses.

1. Reinstall NATS to ensure all Agents can come online without issues. See [NATS troubleshooting](xref:Investigating_NATS_Issues) for details.

1. Check *DMS.xml* to ensure that each DMA retains its respective IP address.

1. Verify that no two PCs have similar hostnames that could be truncated to identical names in *DMS.xml*.

> [!TIP]
> See also: [Changing the IP of a DMA](xref:Changing_the_IP_of_a_DMA)

## NATS issue

### Symptoms

- DataMiner fails to start, takes too long to start, or gets stuck at 99% during the startup process.

- Errors in the *SLDataMiner.txt* file, including:

  - "ERR" logs that include references to NATS or MessageBroker.
  - `Initializing Cloud Bridge`

- *SLWatchdog2.txt* contains logs referencing NATS.

### Root cause

NATS is not running as expected. As every DataMiner Agent must be able to reach every other DataMiner Agent in the cluster over NATS, this might impact an Agent's startup process. Most commonly, the issue will stem from one of the following causes:

- NATS/NAS services not running.

- Misconfiguration issue.

- Corrupt installation.

### Solution

follow the steps under [NATS Troubleshooting](xref:Investigating_NATS_Issues).

## Cloud session token issue

### Symptoms

- DataMiner fails to start up.

- *SLCloudStorage.txt* contains entries similar to the examples below:

  ```txt
  CloudSettings could not be retrieved from the cloud. Retrying in 00:00:05. Exception: SLCloudStorage.Repositories.Exceptions.CloudSettingsRepositoryException: Failed to do GetCloudAccessTokenRequest. Received the following error messages: { "message": "The Service Principal of this DMS is expired (3/14/2023 8:09:51 AM +00:00) but should soon be refreshed automatically." }
  ```

  ```txt
  CloudSettings could not be retrieved from the cloud. Retrying in 00:00:05. Exception: SLCloudStorage.Repositories.Exceptions.CloudSettingsRepositoryException: Exception while doing GetCcaGatewayConfigRequest. ---> System.AggregateException: One or more errors occurred. ---> DataMinerMessageBroker.API.Exceptions.SubscriptionException: No responders are available for the request. ---> NATS.Client.NATSNoRespondersException: No responders are available for the request.
  ```

### Root cause

Under normal circumstances, CloudGateway refreshes the cloud session automatically. However, if CloudGateway is down for longer than six days (for example, because of a server outage), the cloud session will become invalid. As a result, DataMiner will fail to start on systems using STaaS.

### Solution

To resolve this issue, follow the troubleshooting steps described in [The session token has expired](xref:STaaS_Error_messages#the-session-token-has-expired).

## Cassandra issue

### Symptoms

- DataMiner fails to start up, takes too long to start up, or gets stuck at 99%.

- DataMiner starts up but all elements have errors and all nodes are down.

- *SLErrors.txt* contains errors related to the connection to the database, for example:

  `ConnectionComposing|ERR|0|1|System.Exception: Could not establish a connection to the Cassandra database (nodes=10.2.5.100, retries=60).`

  The 60 retries in the error above are the maximum number of attempts DataMiner will make to connect to the database before a DataMiner restart is required.

- *SLDBConnection.txt* contains errors similar to the following examples:

  - `2024/11/14 12:02:55.247|SLDBConnection|.ctor|INF|0|1|Failed connection attempt to 10.2.5.100:9042 because NoHostAvailableException: System.Net.Sockets.SocketException (0x80004005): A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond.`

  - `2025/03/25 14:46:01.013|SLDBConnection|.ctor|INF|0|1|Failed connection attempt to 172.16.150.19:9042 because NoHostAvailableException: Cassandra.AuthenticationException: Unable to perform authentication: Cannot achieve consistency level LOCAL_ONE`

### Root cause

DataMiner is unable to establish a connection to the database. This can be caused by any of the following reasons:

- The database is down.
- The database credentials are incorrect.
- Incorrect replication factor or consistency level configured.
- The connection between DataMiner and the external database is blocked, for example by a firewall.

### Solution

1. Connect to the database server and verify whether all nodes are running fine by checking their status in nodetool.

   - UN (or up/normal): The node is running fine.
   - DN: The node is down. In some cases, this can mean data loss is occurring.

1. If the node is up or you do not have access to the database server, check if you can connect with Cassandra using a query tool of your choice.

   You can find the IP of the database in *DB.xml*, in the *DBServer* tag.

   If you can connect to Cassandra:

   - Check whether DataMiner is configured with the correct credentials to connect to the database.
   - Check the configured replication factor against the consistency level. If the *system_auth* schema keyspace is not set to the correct replication factor, credentials will not be synchronized across all Cassandra nodes in the cluster. Consequently, if a node is down, DataMiner may fail to connect to nodes where the credentials have not been replicated. See [Replication and consistency configuration](xref:replication_and_consistency_configuration).
   - Check the DMA server for possible port exhaustion issues and restart if necessary.
   - Check whether a firewall is blocking the communication.

1. If the node is down, verify whether the Cassandra service is running:

   - On **Linux**: `sudo systemctl status Cassandra`
   - On **Windows**: Look for the Cassandra service in the Task Manager.

   If the service is not running, restart it:

   - On **Linux**: `sudo systemctl restart Cassandra`
   - On **Windows**: Right-click the Cassandra service in the Task Manager and select *Restart*, or reboot the server if this restart fails.

1. Inspect the debug log to confirm whether the node has fully started or terminated unexpectedly:

   - On **Linux**: `/var/log/cassandra/debug.log`
   - On **Windows**: `C:\Program Files\Cassandra\logs\debug.log`

   Look for the log line indicating the service is listening for CQL clients: `DEBUG [main] 2024-XX-XX XX:XX:XX Server.java:XX - Starting listening for CQL clients on /<IP>:9042.`

   If the node is down because of the disk policy, other nodes in the cluster will report it as down. The affected node itself might still report its state as "UN" even when it is actually down, which is why it is important to check *debug.log*. Alternatively, you could also check the node status via nodetool on other nodes in the cluster, as these should report the correct state.

> [!TIP]
> See also: [Troubleshooting – Cassandra](xref:Troubleshooting_Cassandra)
