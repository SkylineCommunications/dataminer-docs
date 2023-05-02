---
uid: Cassandra_updating
---

# Updating Cassandra

It's common practice with Cassandra to do rolling upgrades. If your settings allows it, an upgrade can be done without downtime.

Doing a rolling upgrade basically means:

1. Upgrade one node.
1. Bring it up again.
1. Move to the next one.

> [!IMPORTANT]
> When going from one major range to another (e.g. from 3.x to 4.x), it is best practice to first upgrade to the latest version in the current range before going to the new range.

## Checking the Cassandra version

> [!TIP]
> To limit the impact of a breach through Cassandra, we recommended running the Cassandra service as a non-SYSTEM user. For more details, see [Running Cassandra as non-SYSTEM user](xref:Running_Cassandra_as_non-SYSTEM_user).

We recommend that you periodically update your Cassandra database. This will ensure that all known vulnerabilities are fixed.

To check the Cassandra version, go to *C:\Program Files\Cassandra\bin* and execute the following *nodetool* command:

   `.\nodetool version`

With recent DataMiner versions, in case a Cassandra database per Agent is used, **Cassandra 3.11** is installed by default, but Cassandra 4.0 is also supported (and even recommended in case the database consists of multiple nodes). If a Cassandra database per cluster is used, Cassandra 3.11 remains supported for existing installations, but 4.0 is highly recommended and is the minimum supported version for new installations.

> [!NOTE]
> Cassandra 4.0 **no longer supports Windows**. This means that extra Linux servers will be required to host the Cassandra database.

## Updating the Cassandra version

As with all software, it is good practice to ensure you are running the latest version to minimize the number of known vulnerabilities.

> [!NOTE]
> A PowerShell script is available to update Cassandra easily. For more details see [Cassandra Hardening](https://github.com/SkylineCommunications/cassandra-hardening).

To update the Cassandra version:

> [!TIP]
> To limit the impact of a breach through Cassandra, we recommended running the Cassandra service as a non-SYSTEM user. For more details, see [Running Cassandra as non-SYSTEM user](xref:Running_Cassandra_as_non-SYSTEM_user).

### [On Windows](#tab/tabid-1)

1. Ensure you have a **full backup** of the Cassandra database.
1. Download the latest Cassandra *3.11.X* binaries from the [official website](https://cassandra.apache.org/_/download.html).

   These will contain a `.tar` file called `apache-cassandra-3.11.8-bin.tar.gz`.

1. Stop the DataMiner Agent.
1. Go to the *C:\Program Files\Cassandra\bin* folder and run the following command to push all data from memory to disk and stop processing new requests:

   `.\nodetool drain`

1. Stop the Cassandra service.
1. Rename the *C:\Program Files\Cassandra* folder to *Cassandra_bak*.
1. Create a new folder named *Cassandra* in *C:\Program Files*.
1. Extract the contents of the `apache-cassandra-3.11.8-bin.tar.gz` file into a temporary folder.

   > [!NOTE]
   > You will need to extract the file twice, first to get a `.tar` file and then to obtain an *apache-cassandra-3.11.14* folder with additional subfolders.

1. Copy the contents of the *apache-cassandra-3.11.14* folder to *C:\Program Files\Cassandra*.

   You should now see folders such as *C:\Program Files\Cassandra\bin* and *C:\Program Files\Cassandra\lib*.

1. Delete the temporary folder.
1. Copy the **old** *Java* folder from *C:\Program Files\Cassandra_bak\Java* to *C:\Program Files\Cassandra*.
1. Copy the **old** *cassandra.yaml* file from *C:\Program Files\Cassandra_bak\conf\cassandra.yaml* to *C:\Program Files\Cassandra\conf*.
1. Copy the **old** *daemon* folder from *C:\Program Files\Cassandra_bak\bin\daemon* to *C:\Program Files\Cassandra\bin*.
1. Copy the **old** *DevCenter* folder from *C:\Program Files\Cassandra_bak\DevCenter* to *C:\Program Files\Cassandra*.
1. Create a new folder named *logs* in *C:\Program Files\Cassandra*.
1. To enable the use of *nodetool*, set the system-wide environment variables *JAVA_HOME* and *CASSANDRA_HOME* to the correct locations by executing the following PowerShell commands:

   `[System.Environment]::SetEnvironmentVariable('CASSANDRA_HOME','C:\progra~1\Cassandra\',[System.EnvironmentVariableTarget]::Machine)`

   `[System.Environment]::SetEnvironmentVariable('JAVA_HOME','C:\progra~1\Cassandra\Java\',[System.EnvironmentVariableTarget]::Machine)`

1. Open a **new PowerShell prompt** (as Administrator) and execute the following command to register the Cassandra service:

   `cd 'C:\Program Files\Cassandra\bin\'; .\cassandra.ps1 -install`

1. To make sure the location of the *Jvm* is correctly set in the registry, execute the following PowerShell command:

   `Set-ItemProperty -Path "HKLM:\SOFTWARE\WOW6432Node\Apache Software Foundation\Procrun 2.0\cassandra\Parameters\Java" -Name "Jvm" -Value "C:\Program Files\Cassandra\Java\bin\server\jvm.dll"`

1. To prevent startup issues, DataMiner enables the commitlog.ignorereplayerrors option in Cassandra. Make sure this is set by executing the following PowerShell commands:

   `$options = Get-ItemProperty -Path "HKLM:\SOFTWARE\WOW6432Node\Apache Software Foundation\Procrun 2.0\cassandra\Parameters\Java" -Name "Options"`

   `$options.Options += "-Dcassandra.commitlog.ignorereplayerrors=true"`

   `Set-ItemProperty -Path "HKLM:\SOFTWARE\WOW6432Node\Apache Software Foundation\Procrun 2.0\cassandra\Parameters\Java" -Name "Options" -Value $options.Options`

1. Verify that the *Cassandra* service has been created and that it can be started from the Task Manager (or the Services Manager).

1. After a Cassandra upgrade, it is (sometimes) necessary to execute *nodetool upgradesstables* on your nodes to convert sstables to the new Cassandra version. Go to the *C:\Program Files\Cassandra\bin* folder and run the following command:

   `.\nodetool upgradesstables`

   > [!WARNING]
   > Depending on the size of your database, converting the sstables can take a while.

1. Start the DataMiner Agent and make sure that no error alarms are visible in the Alarm Console.

> [!TIP]
> After starting the Cassandra service, verify that the expected Cassandra version is logged in *C:\Program Files\Cassandra\Logs\system.log*. For example: *Cassandra version: 3.11.12*
> If the service does not start and no logs are created, make sure that the *Jvm* registry key refers to the correct location.
> Execute `nodetool status` to check whether the system is running stable.

### [On Linux](#tab/tabid-2)

The following steps were executed on Ubuntu Server. When you have a Cassandra Cluster, each node needs to be updated separately.

#### Backup Cassandra using snapshot

Perform a snapshot using the following command:

```txt
nodetool snapshot
```

#### Update the repositories

1. Add the GPG key of the Apache Cassandra repository to your system:

   ```txt
   wget -q -O - https://www.apache.org/dist/cassandra/KEYS | sudo apt-key add -
   ```

1. Add the Cassandra repository to the sources list:

   In the following example we are going to add Cassandra 4.1 to the sources list.

   ```txt
   echo "deb https://downloads.apache.org/cassandra/debian 41x main" | sudo tee -a /etc/apt/sources.list.d/cassandra.sources.list
   ```

1. Open the Cassandra.sources.list

   ```txt
   sudo nano /etc/apt/sources.list.d/cassandra.sources.list
   ```

1. Remove old installation entries and only leave the following line:

   ![Cassandra Source List File](~/user-guide/images/CassandraUpdate_CassandraSourcesListFile.png)

   Hit CTRL + X after modifying this file, when the question "Save Modified buffer" comes up, hit **Y** keyboard button.

   At the bottom, File Name to Write pane will come up, hit the **Enter** keyboard button.

   ![Nano Editor File Name to Write](~/user-guide/images/CassandraUpdate_NanoFileToWrite.png)

1. Update the package list with the following command:

   ```txt
   sudo apt-get update
   ```

#### Update Cassandra

##### Stop the service daemon

1. Stop the service:

   ```txt
   sudo service cassandra stop
   ```

1. Check if the service has stopped using:

   ```txt
   nodetool status
   ```

##### Backup the Cassandra and Cassandra YAML

```txt
sudo cp -R /var/lib/cassandra /var/lib/cassandra_backup
```

The following command will back up the home directory of the administrator user. In your case, this could be another (home) directory.

```txt
sudo cp /etc/cassandra/cassandra.yaml /home/administrator/cassandra.yaml
```

##### Update Cassandra and SSTables

Update Cassandra with the following command:

```txt
sudo apt install cassandra
```

It could be that bash shell shows the following:

![Cassandra Configuration File Update](~/user-guide/images/CassandraUpdate_ConfigurationFileUpdate.png)

> [!IMPORTANT]
>
> Using **Y** will overwrite your current cassandra.yaml file and take the one from the package. This could lead to a broken setup. It is best to revise the changes using the **D** or **Z** option. When using the **D** option, the screen will be replaced with the contents of the cassandra.yaml file. Exiting that screen can be done by using the **q** keyboard button.
>
> As the screenshot explains, **N** is the default option, so your existing cassandra.yaml file would be unchanged if this option was used. We recommend using the **N** option.
>
> The backup we took earlier can also be placed back.

##### Start Cassandra

1. Start the Cassandra daemon using the following bash command:

   ```txt
   sudo service cassandra start
   ```

1. Check if the upgrade was successful by running the following command:

   ```txt
   nodetool version
   ```

1. Check the status of the Cassandra node:

   ```txt
   nodetool status
   ```

   The status column in the output window should report **UN** which stands for "Up/Normal".

1. Upgrading the SSTables can be done like this:

   ```txt
   sudo nodetool upgradesstables
   ```

> [!NOTE]
> When upgrading Cassandra to a new version, it is generally recommended to upgrade the SSTables as well. This is because the new version of Cassandra may have another way to store data on disk, and using old SSTables with the new version of Cassandra could result in compatibility issues or suboptimal performance. The decision to upgrade the SSTables should be based on the specifics of your use case and the trade-offs.

##### Check log files

Cassandra log files can be checked as follows:

- Check the last 100 longlines of system.log:

   ```txt
   tail -n 100 /var/log/cassandra/system.log
   ```

- View the complete system.log file:

   ```txt
   less /var/log/cassandra/system.log
   ```

> [!TIP]
> You can also use the Apache Cassandra Cluster Monitor driver described [here](xref:Maintain_Cassandra_Cluster) to verify the status of your Cassandra nodes.

---
