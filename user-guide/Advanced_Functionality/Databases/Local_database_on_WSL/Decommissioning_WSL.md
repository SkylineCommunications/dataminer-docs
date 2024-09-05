---
uid: Decommissioning_WSL
---

# Decommissioning WSL

If you no longer need to run Cassandra Cluster and OpenSearch from WSL because you migrated to [Storage as a Service (STaaS)](xref:STaaS) or [configured dedicated clustered storage](xref:Configuring_dedicated_clustered_storage), it is recommended to stop WSL so it no longer consumes any resources.

Follow the below steps to decommission WSL:

1. In an elevated Powershell window, run the following commands:

    ```powershell
    wsl --shutdown
    wsl --unregister Ubuntu-22.04
     ```

1. Open Task Scheduler.
1. Right-click the "Start WSL" task and click *Disable*.

> [!NOTE]
> If, for some reason, you want to keep a backup of the WSL distribution, you can export it by running the following command:
>
> ```powershell
> wsl --export
> ```
>
> This backup can later be re-imported with the command:
>
> ```powershell
> wsl --import
> ```
