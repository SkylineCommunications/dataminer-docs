---
uid: KI_Unavailable_system_database_after_DataMiner_server_reboot
---

# Unavailable system database after DataMiner server reboot

## Description of the issue

> [!NOTE]
> This only applies to DataMiner Agents that are hosting both the DataMiner software and the Cassandra node on one and the same server instance.

When a DataMiner Agent is rebooted, you may end up in a scenario where the DataMiner Agent is no longer connected to its system database (also known as local database) after the reboot.

## Cause

If a Cassandra node is restarted while there is still data being actively written to it, this may result in a faulty node, which needs to run a recovery process at node startup time.

During this recovery process, which can take some time, the node will not accept any incoming connections. At this time, the node is also not in a UN (Up Normal) state. Because of this, the DataMiner software will not be able to connect to the Cassandra node at startup time.

## Resolution

When you execute a planned maintenance action that involves rebooting the DataMiner server, first stop the DataMiner software running on that server and then wait a minute to allow all remaining data offloads to the local Cassandra node to finish. After this, you can execute the server reboot action. As there was no data being written to the node during the shutdown process, this way, you avoid the scenario where the node needs to run a recovery process at startup time.

Upon server startup, the Cassandra node will automatically start. The DataMiner software will then also start up and be able to connect to an active Cassandra node, resulting in a fully functional DataMiner Agent.
