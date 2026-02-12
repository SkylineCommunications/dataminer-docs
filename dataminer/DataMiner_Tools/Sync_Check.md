---
uid: Sync_Check
---

# Sync Check

## About this tool

To verify the synchronization of element and service files across a DataMiner System, you can use the "Sync Check" automation script.

This is especially intended for troubleshooting in large clusters (which can include Failover Agents) in case there are errors related to duplicate service or element IDs, errors when new services are created that reuse the name of old services, or synchronization errors related to services or elements;

You can download this script from [DataMiner Dojo](https://community.dataminer.services/download/script_synccheck/).

## Running the Sync Check script

To use this script:

1. Extract the zip file you downloaded.

1. Import the script *Script_SyncCheck.xml* on a DMA in the DataMiner System you are troubleshooting. The script will become available in the *Skyline-TechSupport* folder in the Automation module.

1. Run the script in the Automation module and specify a username and password. These credentials will be used to access the different Agents in the DMS via file shares

1. When the script has run, check its output in the file *SyncInfo.txt*, which you can find in the following folder on the DMA: `C:\Skyline_Data\SyncInfo`.

Note that to be able to run the script, file share access to all IP addresses in the cluster is required.

## What is included in the sync check?

The script checks the following things:

- Elements:

  - Missing between main and backup DMA (Failover)

  - Failed to parse

  - Inconsistent folder name (different name or capitalization)

  - Not in sync: compared based on DMA ID, element ID, name, protocol, version and properties

  - Duplicate element IDs

- Services

  - Missing between main and backup DMA (Failover)

  - Failed to parse

  - Inconsistent folder name (different name or capitalization)

  - Not in sync: compared based on DMA ID, service ID, name and properties

  - Duplicate service IDs

- Remote services:

  - Missing DMA folder

  - Missing services

  - Failed to parse

  - Inconsistent folder name (different name or capitalization)

## SyncInfo output file

The SyncInfo file consists of an ERRORS section, a DEBUG LOGGING section (listing all the DMAs in the cluster), and the following sections for each DMA:

- Elements INFO

- Service INFO

- ELEMENT FOLDER INFO

- Service FOLDER INFO

- Remote Service Folder Check

> [!TIP]
> You can download an example of the output from [DataMiner Dojo](https://community.dataminer.services/download/syncinfo3/).

### Error examples

- `No ERRORS`

  This is the expected message when there are no errors.

- `RetrieveInfoFromFolders Exception`

  This error will be shown for each DataMiner Failover pair where the file share is not configured:

  ```txt
  RetrieveInfoFromFolders Exception: System.ComponentModel.Win32Exception (0x80004005): The network path was not found
     at Skyline.Automation.Testing.NetworkShareAccesser.ConnectToShare(String remoteUnc, String username, String password, Boolean promptUser)
     at Skyline.Automation.Testing.NetworkShareAccesser..ctor(String remoteComputerName, String userName, String password)
     at Skyline.Automation.Testing.NetworkShareAccesser.Access(String remoteComputerName, String domainOrComuterName, String userName, String password)
     at Skyline.Automation.Testing.DMSHelper2.DMAFolderHelper.RetrieveInfoFromFolders(ScriptData scriptdata, Dictionary`2 dictAllElements, Dictionary`2 dictAllServices)
  ```

- `Inconsistent FolderName`

  This error is shown if a service name and the service folder name are different.
  
  For example, here the folder name is *Service_name_example* and the folder name is *Service_name_example_1*:

  ```txt
  Inconsistent FolderName (Service_name_example): \<DMA_IP>\c$\Skyline DataMiner\RemoteServices\<DMA_ID>\Service_Name_example_1
  ```

- `Duplicate Entries`

  This error is shown when there are two services with the same ID, for example the services *Service_name_A* and *Service_name_B* here:

  ```txt
  Duplicate Entries in Main Service folder for ID <DMA_ID>/<service_ID>:Service_name_A, Service_name_B
  ```

### Other examples

In the *Elements INFO*, *Service INFO*, *ELEMENT FOLDER INFO*, *Service FOLDER INFO*, and *Remote Service Folder Check* sections, if everything is OK, the message `<IP_DMA1_Online> And <IP_DMA1_Offline> Are In Sync!` will be displayed.

For example:

```txt
#################################
####Elements INFO FOR DMA 123
#################################

INFO: Compared based on DMAID, ID, protocol, version and Name
SLNet And Folder Structure Are In Sync!
---------------------------------

#################################
####Service INFO FOR DMA 123
#################################

INFO: Compared based on DMAID, ID, protocol, version and Name
SLNet And Folder Structure Are In Sync!
---------------------------------

#################################
####ELEMENT FOLDER INFO FOR DMA 123
#################################

INFO: Compared based on DMAID, ELID, Name, Protocol, Version and Properties
<IP_DMA1> And <IP_DMA2> Are In Sync!
---------------------------------

#################################
####Service FOLDER INFO FOR DMA 123
#################################

INFO: Compared based on DMAID, ID, Name and Properties
<IP_DMA1> And <IP_DMA2> Are In Sync!
---------------------------------

#################################
####Remote Service Folder Check for DMA 123
#################################

INFO: MAKE SURE THE MAIN BACKUP IS IN SYNC FIRST!
The remote services for DMA 123 are in Sync!
---------------------------------
```

If something is missing on one of the DMAs, a message starting with `Missing` will be displayed. For example, if a service *Service_name_A* is missing on the online DMA with ID 123 compared to the offline DMA:

```txt
#################################
####Service FOLDER INFO FOR DMA 123
#################################

INFO: Compared based on DMAID, ID, Name and Properties

------<IP_DMA1_Offline>------

Missing: 
Service_name_A
```
