---
uid: Cassandra_updating
---

# Updating Cassandra

## Viewing the Cassandra version

We recommend that you periodically update your Cassandra database to ensure that all known vulnerabilities are fixed.

You can verify your version of Cassandra by executing the following query:

`SELECT cql_version FROM system.local;`

Alternatively, you can verify the Cassandra version with the following *nodetool* command:

`nodetool version`

By default, DataMiner installs **Cassandra 3.11**. However, Cassandra 4.0 is also supported.

> [!NOTE]
> Cassandra 4.0 is no longer supported on Windows, which means that extra Linux servers will be required to host the Cassandra database.
> Older DataMiner versions deployed Cassandra 3.7.

## Updating the Cassandra version

As with all software it's a best practice to ensure you're running the latest version to minimize the number of known vulnerabilities.

To update the Cassandra version:

1. Ensure you have a **full backup** of the Cassandra database.

1. Download the latest Cassandra *3.11.X* binaries from the [official website](https://cassandra.apache.org/_/download.html) and *extract* the archive

1. Stop the DataMiner agent

1. Stop the Cassandra service

1. Rename the *C:\Program Files\Cassandra* folder to *Cassandra_bak*

1. Create a new folder named *Cassandra* in *C:\Program Files\*

1. Copy the downloaded Cassandra binaries to this new *Cassandra* folder

1. Copy the **old** *Java* folder from *C:\Program Files\Cassandra_bak\Java* to *C:\Program Files\Cassandra*

1. Copy the **old** *cassandra.yaml* from *C:\Program Files\Cassandra_bak\conf\cassandra.yaml* to *C:\Program Files\Cassandra\conf*

1. Create a new folder named *logs* in *C:\Program Files\Cassandra*

1. Copy the **old** *daemon* folder from *C:\Program Files\Cassandra_bak\bin\daemon* to *C:\Program Files\Cassandra\bin*

1. Open a PowerShell prompt (as Administrator) and execute the following commands:

`$env:CASSANDRA_HOME='C:\progra~1\Cassandra\'`

`$env:JAVA_HOME='C:\progra~1\Cassandra\Java\'`

`cd 'C:\Program Files\Cassandra\bin\'; .\cassandra.ps1 -install`

1. Verify the *Cassandra* service is created and can be started

1. Finally, start the DataMiner agent and assert no Error alarms are visible in the Alarm Console.

> [!TIP]
> If the service cannot start, verify that under **HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Apache Software Foundation\Procrun 2.0\cassandra\Parameters\Java** the *Jvm* registry key is set to *C:\Program Files\Cassandra\Java\bin\server\jvm.dll*.
> After starting the Cassandra service, verify the expected Cassandra version is logged in *C:\Program Files\Cassandra\Logs\system.log*. For example: *Cassandra version: 3.11.12*
> Verify the system is running stable by executing:
> `nodetool status`
