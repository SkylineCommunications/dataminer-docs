---
uid: MOP_Implementing_connection_strings_in_a_DMS
---

# Implementing connection strings in a DataMiner System

Implementing connection strings in a DataMiner System can be required if there are restrictions on the authentication within a DMS cluster. These restrictions can be noted when strange behavior occurs, like desynchronization between DMAs, missing files, users losing their connection, elements not being displayed on one DMA, etc.

The procedure below illustrates how to configure connection strings in the following example setup, in case an Agent cannot connect to a Failover pair or to a single other Agent:

![Example setup: Failover and single Agent in one DMS](~/dataminer/images/ConnectionStrings_Cluster.png)

> [!TIP]
> For more information on connection strings and how to identify an issue because of connection strings, refer to [Connection strings](xref:Connection_strings).

## Requirements

- Remote access to the system
- Credentials of a Windows user with Administrator privileges
- Access to [SLNetClientTest tool](xref:Opening_the_SLNetClientTest_tool)

## Procedure

### Connection to a Failover pair

By default, the connection towards a Failover pair always uses its virtual IP. There is therefore no need to create two separate connection strings per Failover Agent IP, so that in the case of this example only one connection string is needed.

1. Connect to an Agent that is unable to connect to the Failover pair via [SLNetClientTest tool](xref:Opening_the_SLNetClientTest_tool).

   In this case, this will be the single Agent.

1. Add a new connection string as detailed in the procedure [Editing the connection string between two DataMiner Agents](xref:SLNetClientTest_editing_connection_string), using the following configuration:

   - *From*: Enable the checkbox *Update All Connections To This Agent*. For this example,the IP of the single Agent can be used.
   - *To*: The virtual IP of the Failover pair.
   - *Username* and *Password*: The credentials of a Windows user with Administrator privileges towards the Failover pair.

> [!NOTE]
> If only one of the Failover Agents needs a connection string, this is also possible. In that case, use the primary IP of that Failover Agent instead of the VIP in the *To* field.

### Connection to a single Agent

To configure the connection string towards a single Agent, always use the primary IP.

In this example, a connection string will need to be created from each Agent in the Failover pair towards the single Agent.

1. Connect to an Agent that is unable to connect to the single Agent via [SLNetClientTest tool](xref:Opening_the_SLNetClientTest_tool).

   In this case, this will be one of the Failover Agents.

1. Add a new connection string as detailed in the procedure [Editing the connection string between two DataMiner Agents](xref:SLNetClientTest_editing_connection_string), using the following configuration:

   - *From*: Enable the checkbox *Update All Connections To This Agent* *or* in our use case, use the primary IP of one Failover Agent.
   - *To*: The IP of the single Agent.
   - *Username* and *Password*: The credentials of a Windows user with Administrator privileges towards the single agent.

1. Create another connection string, this time use the primary IP of the other Failover Agent in the *From* field.

## Verification

After adding a connection string, wait a few minutes, and then go to Cube > System Center > Agents. You should notice that the connection towards the Agents has been established.

After adding a connection string, a new *Redirects* tag will also be present in the file `C:\Skyline DataMiner\DMS.xml`. Open *DMS.xml* on the server used in the *From* field, and check if you find a *Redirects* tag towards the IP specified in the *To* field.
