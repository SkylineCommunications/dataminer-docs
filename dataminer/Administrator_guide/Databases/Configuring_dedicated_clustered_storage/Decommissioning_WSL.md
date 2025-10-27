---
uid: Decommissioning_WSL
---

# Decommissioning WSL

In case you deployed DataMiner by using the [pre-installed DataMiner Virtual Hard Disk](xref:Using_a_pre_installed_DataMiner_Virtual_Hard_Disk) and you chose the *Self-Hosted - Local Storage* database type option, both Cassandra Cluster and OpenSearch run locally on the Virtual Machine on Windows Subsystem for Linux (WSL). This allows you to easily get started with a database setup that supports all DataMiner functionalities. However, such a setup should only be used for **test and staging environments**.

To switch such a setup to production, you will need to migrate to [Storage as a Service (STaaS)](xref:STaaS) or switch to using Cassandra and OpenSearch clusters on separate servers.

Once you no longer need the local Cassandra and OpenSearch nodes on WSL, we recommend decommissioning WSL so it no longer consumes any resources.

Follow the below steps to decommission WSL:

1. In an elevated Powershell window, run the following commands:

    ```powershell
    wsl --shutdown
    wsl --unregister Ubuntu-22.04
     ```

1. Open Task Scheduler.

1. Right-click the *Start WSL* task and click *Disable*.

> [!NOTE]
> If, for some reason, you want to keep a backup of the WSL distribution, you can export it by running the following command before performing the decommissioning:
>
> ```powershell
> wsl --export <name of WSL distro> "<filepath>.tar"
> ```
>
> This backup can later be re-imported with the following command:
>
> ```powershell
> wsl --import <name of WSL distro> $WslDistroInstallPath $WslDistroBackupFilePath
> ```
