---
uid: MOP_Implementing_connection_strings_in_a_DMS
---

# Implementing connection strings in a DataMiner System

The procedure below details how to implement connection strings in a DataMiner System. With the help of these instructions, you will be able to create connection strings between all the DMAs within a cluster in a mesh-type connection, which means that every DMA will be connected with its respective peer. For example, DMA 1 will be connected to DMA2, DMA3, DMA4, etc.; DMA2 will be connected to DMA1, DMA3, DMA4, etc.; and so on.

This procedure is required when there are restrictions on the authentication within a DMA cluster. These restrictions can be noted when strange behavior occurs, like desynchronization between DMAs, missing files, users losing their connection, elements not being displayed on one DMA, etc.

## Requirements

- Access to the DMAs with the built-in Windows Administrator account. This requires a connection dedicated completely or partially to this procedure, via VPN or local network.
- Access to the *SLNetClientTest* tool on every DMA in the DataMiner System.

## Procedure

### Check the requirements

#### Prerequisites

- Remote access to the system
- Credentials for the built-in Windows Administrator account

#### Steps

1. Connect to the system using the designated VPN or host PC.
1. Check if *SLTaskBarUtility* is available in the notification area. For more information, see [DataMiner Taskbar Utility](xref:DataMiner_Taskbar_Utility).

    - If *SLTaskBarUtility* is available, right-click the taskbar utility icon and select *Launch > Tools > Client Test*.
    - If *SLTaskBarUtility* is not available, run the *SLNetClientTest* tool as Administrator from the following location: `C:\Skyline DataMiner\Files\SLNetClientTest.exe`.

### Create the connection strings

#### Prerequisites

Access to SLNetClientTest tool on the DMA

#### Steps

1. Connect to the DMS using the *SLNetClientTest* tool:

    1. In the *SLNetClientTest* tool, go to *Connection* > *Connect*.
    1. In the *Connect* window, under *Authentication*, select *Explicit credentials* and specify the Administrator credentials.
    1. Click the *Connect* button.

1. In the *Advanced* menu, select *Edit Connection Uris*.
1. Create the connections for each of the DMAs in the cluster, as detailed in [Editing the connection string between two DataMiner Agents](xref:SLNetClientTest_editing_connection_string).

   You will need to follow the linked procedure for all the DMA connections that need to be made. For example, if there are 9 DMAs in the system, there must be 8 connections from every DMA. From DMA1, for instance, there will need to be a connect to DMA2, DMA3, etc. up to DMA9; from DMA2, there will need to be a connection to DMA1, DMA3, etc. to DMA9; and so on.

1. When all connections have been configured, click the *Done* button in the *Connection String Configuration* window.

## Time estimate

| Item | Activity | Duration |
|------|----------|----------|
| 1    | Connect and open SLNetClientTest tool.      | 10 min. |
| 2    | Connect to the DMS in SLNetClientTest tool. | 3 min.  |
| 3    | Create the connection strings.              | approx. 30 min. per DMA,<br> depending on the number of DMAs in the cluster |
| 4    | Check the results.                          | approx. 10 min. per DMA |
