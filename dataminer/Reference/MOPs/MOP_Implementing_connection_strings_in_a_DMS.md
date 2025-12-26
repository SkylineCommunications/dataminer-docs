---
uid: MOP_Implementing_connection_strings_in_a_DMS
---

# Implementing connection strings in a DataMiner System

A use case is provided on how to implement connection strings in a DataMiner System. This can be required if there are restrictions on the authentication within a DMS cluster. These restrictions can be noted when strange behavior occurs, like desynchronization between DMAs, missing files, users losing their connection, elements not being displayed on one DMA, etc...

How to identify an issue because of connection strings and what they exactly are, can be found [here](xref:Connection_strings).


## Requirements
- Remote access to the system 
- Credentials of a Windows user with Administrator privileges  
- Access to [SLNetClientTest tool](xref:Opening_the_SLNetClientTest_tool)

## Environment
Our example uses a cluster of 1 Failover pair and 1 single DataMiner Agent:

![Use case: 1 failover and 1 single agent](~/dataminer/images/ConnectionStrings_Cluster.png)<br>

## Procedure
We will use [Editing the connection string between two DataMiner Agents](xref:SLNetClientTest_editing_connection_string) as guide to configure the connection strings in our example.
We'll mainly need to use the "_Edit Connection String_" popup window:
![Client Test Tool - Edit Connection String](~/dataminer/images/ConnectionStrings_CTT.png)<br>


### Connection to the Failover
By default, the connection towards a failover pair is always done to its Virtual IP, therefore there's no need to create 2 separate connection strings per IP/failover agent.  
Meaning in our use case, we only need to create 1 connection string.

1. Connect to an agent that can't connect to the failover via [SLNetClientTest tool](xref:Opening_the_SLNetClientTest_tool).  
In this case this will be the single agent.
2. Go to add a new connection string
3. Fill in the fields:
   - _From_: Enable the checkbox "_Update All Connections To This Agent_".  
 In our use case, we can simply use the IP of the single agent.
   - _To_: Fill in the Virtual IP of the Failover pair
   - _Username_ and _Password_: fill in the credentials of a Windows user with Administrator privileges towards the Failover pair

  > [!NOTE]
  > If only 1 of the failover agents needs a connection string, this is also possible. Simply use the primary IP of that failover agent instead of the VIP in the _To_ field.

### Connection to the Single Agent
A single agent doesn't have a Virtual IP, always use the primary IP whilst configuring the connection string.
A connection string needs to be created from each (failover) agent. In our use case, we will need a connection string per failover agent towards the single agent.

1. Connect to an agent that can't connect to the single agent via [SLNetClientTest tool](xref:Opening_the_SLNetClientTest_tool).  
In this case this will be 1 of the failover agents.
2. Go to add a new connection string
3. Fill in the fields:
   - _From_: Enable the checkbox "_Update All Connections To This Agent_" *or* in our use case, use the primary IP of 1 failover agent.
   - _To_: Fill in the IP of the single agent
   - _Username_ and _Password_: fill in the credentials of a Windows user with Administrator privileges towards the single agent.
4. Create another connection string, this time use the primary IP of the other failover agent in the _From_ field.


## Verification
After adding a connection string, give it a few minutes. Go to Cube > System Center > Agents, you should notice that the connection towards the agents should have been established.

After adding a connection string, a new _Redirects_ tag should be found in the file C:/Skyline DataMiner/DMS.xml. Open the DMS.xml file on the server used in the _From_ field, you should find a _Redirects_ tag towards the IP filled in the _To_ field.
