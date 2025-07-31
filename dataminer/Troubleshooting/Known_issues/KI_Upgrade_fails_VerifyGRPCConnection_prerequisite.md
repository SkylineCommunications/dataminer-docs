---
uid: KI_Upgrade_fails_VerifyGRPCConnection_prerequisite
---

# Upgrade fails because of VerifyGRPCConnection.dll prerequisite

## Affected versions

From DataMiner 10.5.10 onwards.

## Cause

The VerifyGRPCConnection upgrade prerequisite checks if the DMS is ready to use gRPC as the default communication type.
The check can fail for 2 reasons:
- **Configuration:** one or more DataMiner network-related settings have been changed from their default value.
  This is not necessarily a problem, especially if there are no connectivity checks failing, but it requires manual intervention to reconsider why the setting was changed and if that would affect moving to gRPC.
- **Connectivity:** one or more gRPC connection checks between agents in the cluster have failed.
  This is a functional problem and indicates the cluster is not ready to use gRPC.

The following articles can help to analyze the configuration:
* [Overview of IP ports used in a DMS](xref:Configuring_the_IP_network_ports#overview-of-ip-ports-used-in-a-dms)
* [DataMiner Agent hardening](xref:DataMiner_hardening_guide#dataminer-agent-hardening)
* [Disabling .NET Remoting](xref:Configuration_of_DataMiner_processes#disabling-net-remoting) (MaintenanceSettings.xml)
* [Configuring the port for .NET Remoting](xref:Configuration_of_DataMiner_processes#configuring-the-port-for-net-remoting) (SLNet.exe.config)
* [ConnectionSettings.txt Options](xref:ConnectionSettings_txt#connectionsettingstxt-options) (ConnectionSettings.txt)
* [Connection strings](xref:Connection_strings) (DMS.xml)
  - [Redirects subtag](xref:DMS_xml#redirects-subtag)
  - [Editing the connection string between two DataMiner Agents](xref:SLNetClientTest_editing_connection_string)

## Fix for configuration failures

### Prerequisite fails on ConnectionSettings.txt
Error message:
```txt
ConnectionSettings.txt was changed, only default config is allowed without MaintenanceSetting flag
```
This will occur if one of the following changes have been made in ConnectionSettings.txt:
- Polling was configured (e.g. `polling=1000`)
- A server port other than 8004 was configured (e.g. `serverport=1234`)
- Different settings for different IP ranges have been configured.

Fix: modify ConnectionSettings.txt to use GRPCConnection for all clients and evaluate if Cube connections work as expected:
```txt
* type=GRPCConnection
```

### Prerequisite fails on SLNet.exe.config
Error message:
```txt
SLNet.exe.config .NET Remoting port should be 8004 but was {port}
```
This will occur if a server port other than 8004 was configured in C:\Skyline DataMiner\Files\SLNet.exe.config (e.g. `<channel ref="http" name="SLNetRemoting" port="1234" timeout="300000" clientConnectionLimit="200">`)

Fix:
1. Modify ConnectionSettings.txt to use gRPC for all clients and evaluate if Cube connections work as expected:
  ```txt
  * type=GRPCConnection
  ```
2. Manually disable .NET Remoting on all agents and verify that agents can still communicate correctly (Cube > System Center > Agents).


### Prerequisite fails on DMS.xml redirects
Error message:
```txt
{redirect} is not of format 'https://*/APIGateway'
```

This will occur if any non-APIGateway redirects URIs have been configured in DMS.xml.

APIGateway redirect URIs or username/password redirects will not trigger a failure:
```xml
<Redirects>
  <Redirect to="10.0.0.21" via="" user="dataminer" pwd="abc123" />     <!-- OK -->
  <Redirect to="10.0.0.22" via="https://10.0.0.22:443/APIGateway" />   <!-- OK -->
  <Redirect to="10.0.0.23" via="http://10.0.0.23:8004/SLNetService" /> <!-- fail -->
  <Redirect to="10.0.0.24" via="auto://nodetect/" />                   <!-- fail -->
</Redirects>
```

Fix: change the connection strings to the format `https://{ip}/APIGateway` and verify that agents can still communicate correctly (Cube > System Center > Agents).

## Fix for connectivity failures

Error messages:
```txt
{ip}: APIGateway version check failed: APIGateway is unavailable.
{ip}: gRPC call failed: Status(StatusCode="...", Detail="...")
{ip}: No response was received
{ip}: Connection test returned an error, possible causes are APIGateway not running or port 443 is closed
```

Where the previous failures on configuration may be false positives, the connection check failures indicate a functional problem.
Verify the following items:
- is the `SLNet` service running on all agents?
- is the `DataMiner APIGateway` service running on all agents?
- is the `https://{ip}/APIGateway/api/version` endpoint reachable on all agents and returing the version information?
  - a **connection refused** error indicates IIS, APIGateway or HTTP services not running
  - a **connection timeout** indicates a firewall issue
  - a **404 Not Found** error indicates APIGateway not running
- is there a proxy configured for the SYSTEM user? Verify the output of the following commands:
  ```txt
  netsh winhttp show proxy
  reg query "HKU\S-1-5-18\SOFTWARE\Microsoft\Windows\CurrentVersion\Internet Settings" /f Proxy
  reg query "HKU\S-1-5-18\SOFTWARE\Microsoft\Windows\CurrentVersion\Internet Settings" /f AutoConfigURL
  ```
  The expected output contains:
  ```txt
  Direct access (no proxy server).
  ProxyEnable    REG_DWORD    0x0
  End of search: 0 match(es) found.
  ```

## Workaround

It is possible to keep using .NET Remoting as the default communication type by applying the [EnableDotNetRemoting.dmupgrade](https://community.dataminer.services/download/enabledotnetremoting-dmupgrade/) package.
This upgrade package will set `<SLNet><EnableDotNetRemoting>` to true in MaintenanceSettings.xml on all agents in the cluster.
This does not trigger a restart and can immediately be followed by a full upgrade to 10.5.10+.

> [!WARNING]
> When deciding to keep using .NET Remoting as communication type between agents, be aware when adding a new agent to the cluster, that agent must also first be configured with EnableDotNetRemoting set to true.

> [!WARNING]
> Note that .NET Remoting will eventually be removed in a future version, and at that point the upgrade will be blocked again.

## Issue description

Upgrading a cluster is blocked because the VerifyGRPCConnection prerequisite fails.