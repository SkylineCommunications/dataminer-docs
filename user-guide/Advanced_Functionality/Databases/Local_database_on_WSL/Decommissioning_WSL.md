---
uid: Decommissioning_WSL
---

# Decommissioning WSL

If you no longer need to run Cassandra Cluster and OpenSearch from WSL because you migrated to [Storage as a Service (STaaS)](xref:STaaS) or [configured dedicated clustered storage](xref:Configuring_dedicated_clustered_storage), it is recommended to stop WSL so it no longer consumes any resources.

Follow the below steps to decommission WSL:

1. In an elevated Powershell window, run the following command:

    ```powershell
    wsl --shutdown
     ```

1. Open Task Scheduler.
1. Right-click the "Start WSL" task and click *Disable*.
