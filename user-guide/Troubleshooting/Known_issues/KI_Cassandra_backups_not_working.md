---
uid: KI_Cassandra_backups_not_working
---

# Cassandra backups no longer working

## Affected versions

DataMiner 10.3.9 CU0.

## Cause

DataMiner 10.3.9 [CU0] introduced additional binding redirects in the CassandraBackup.exe.config file. SLDataGateway would try to load these references, but as these were not available in `C:\Skyline DataMiner\Tools`, this caused exceptions.

## Workaround

1. Open the file `C:\Skyline DataMiner\Tools\CassandraBackup.exe.config`.

1. Remove or quote out the last three `<dependentAssembly>` entries in the file:

   ```xml
   <dependentAssembly>
      <assemblyIdentity name="Microsoft.Extensions.Logging.Abstractions" publicKeyToken="adb9793829ddae60" culture="neutral" />
      <bindingRedirect oldVersion="0.0.0.0-7.0.0.0" newVersion="7.0.0.0" />
   </dependentAssembly>
   <dependentAssembly>
      <assemblyIdentity name="Microsoft.Extensions.Logging" publicKeyToken="adb9793829ddae60" culture="neutral" />
   </dependentAssembly>
   <dependentAssembly>
      <assemblyIdentity name="K4os.Compression.LZ4" publicKeyToken="2186fa9121ef231d" culture="neutral" />
      <bindingRedirect oldVersion="0.0.0.0-1.2.16.0" newVersion="1.2.16.0" />
   </dependentAssembly>
   ```

1. Save and close the file.

## Fix

Install DataMiner 10.3.9 [CU1]<!-- RN 37217 -->.

## Issue description

Cassandra backups no longer work. The logging contains an exception like the one illustrated below.

```txt
[08/29/2023 09:51:21][INFO][CassandraConnection.cs:73] Could not connect to Cassandra: The type initializer for 'Cassandra.AtomicMonotonicTimestampGenerator' threw an exception.
[08/29/2023 09:51:21][ERROR][Program.cs:43] System.TypeInitializationException: The type initializer for 'Cassandra.AtomicMonotonicTimestampGenerator' threw an exception. ---> System.TypeInitializationException: The type initializer for 'Cassandra.Diagnostics' threw an exception. ---> System.IO.FileLoadException: Could not load file or assembly 'Microsoft.Extensions.Logging, Version=7.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60' or one of its dependencies. The located assembly's manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040) ---> System.IO.FileLoadException: Could not load file or assembly 'Microsoft.Extensions.Logging, Version=1.0.0.0, Culture=neutral, PublicKeyToken=adb9793829ddae60' or one of its dependencies. The located assembly's manifest definition does not match the assembly reference. (Exception from HRESULT: 0x80131040)
   --- End of inner exception stack trace ---
   at Cassandra.Diagnostics..cctor()
   --- End of inner exception stack trace ---
   at Cassandra.Logger..ctor(Type type)
   at Cassandra.AtomicMonotonicTimestampGenerator..cctor()
   --- End of inner exception stack trace ---
   at Cassandra.Policies..ctor(ILoadBalancingPolicy loadBalancingPolicy, IReconnectionPolicy reconnectionPolicy, IRetryPolicy retryPolicy, ISpeculativeExecutionPolicy speculativeExecutionPolicy, ITimestampGenerator timestampGenerator)
   at Cassandra.Builder.GetPolicies()
   at Cassandra.Builder.GetConfiguration()
   at Cassandra.Builder.Build()
   at SLDataGateway.Backup.Cassandra.Utils.CassandraConnection.CreateCassandraConnection()
   at SLDataGateway.Backup.Cassandra.Utils.CassandraConnection..ctor(ConfigurationManager configurationManager, ILogger logger)
   at SLDataGateway.Backup.Cassandra.Operations.Backup..ctor(ILogger logger, ProgramOptions options, Nodetool nodetool, IPackageFactory packageFactory, CassandraConfig cassandraConfig, ConfigurationManager configurationManager)
   at SLDataGateway.Backup.Cassandra.Operations.OperationFactory.CreateInstance(ProgramOptions options, ILogger logger)
   at SLDataGateway.Backup.Cassandra.Program.Main(String[] args)
```
