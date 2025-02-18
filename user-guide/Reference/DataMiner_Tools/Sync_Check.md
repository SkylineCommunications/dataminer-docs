---
uid: Sync_Check
---

# Sync Check

## About this tool

To verify the synchronization of element and service files across a DataMiner System, you can use the "Sync Check" Automation script.

This is especially intended for troubleshooting in large clusters (which can include Failover Agents) in case there are errors related to duplicate service or element IDs, errors when new services are created that reuse the name of old services, or synchronization errors related to services or elements;

You can download this script from [DataMiner Dojo](https://community.dataminer.services/download/script_synccheck/).

## Running the Sync Check script

To use this script:

1. Extract the zip file you downloaded.

2. Import the script *Script_SyncCheck.xml* on a DMA in the DataMiner System you are troubleshooting. The script will become available in the *Skyline-TechSupport* folder in the Automation module.

3. Run the script in the Automation module and specify a username and password. These credentials will be used to access the different Agents in the DMS via file shares

4. When the script has run, check its output in the file *SyncInfo.txt*, which you can find in the following folder on the DMA: *C:\Skyline_Data\SyncInfo*.

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

  ## Examples of the Syncinfo output file

1 - ERRORS section

1.1 - No ERRORS 

This is the expected message when there are no errors.


1.2 - Error: RetrieveInfoFromFolders Exception

This error will appear for each dataminer failover pair where the file share is not configured :

RetrieveInfoFromFolders Exception: System.ComponentModel.Win32Exception (0x80004005): The network path was not found
   at Skyline.Automation.Testing.NetworkShareAccesser.ConnectToShare(String remoteUnc, String username, String password, Boolean promptUser)
   at Skyline.Automation.Testing.NetworkShareAccesser..ctor(String remoteComputerName, String userName, String password)
   at Skyline.Automation.Testing.NetworkShareAccesser.Access(String remoteComputerName, String domainOrComuterName, String userName, String password)
   at Skyline.Automation.Testing.DMSHelper2.DMAFolderHelper.RetrieveInfoFromFolders(ScriptData scriptdata, Dictionary`2 dictAllElements, Dictionary`2 dictAllServices)

1.3 - Error: Inconsistent FolderName

This error appears if a Service name and the Service folder name are different. In this example, the folder name is Service_name_example and the folder name is Service_name_example_1:

Inconsistent FolderName (Service_name_example): \\<DMA_IP>\c$\Skyline DataMiner\RemoteServices\<DMA_ID>\Service_Name_example_1


1.4 - Error: Duplicate Entries

Example In case there are two services (Service_name_A and Service_name_B) with the same ID:

Duplicate Entries in Main Service folder for ID <DMA_ID>/<service_ID>:Service_name_A, Service_name_B


2 - Debug Logging Section

List of all the agents in the cluster


3 - What is checked, a Section for each one of these will be available

- ELEMENT FOLDER INFO FOR DMA <DMA_ID>

- Service FOLDER INFO FOR DMA <DMA_ID>

- Remote Service Folder Check for DMA <DMA_ID>

- Elements INFO FOR DMA <DMA_ID>

- Service INFO FOR DMA <DMA_ID>

3.1 - Message when all is OK

<IP_DMA1_Online> And <IP_DMA1_Offline> Are In Sync!


3.2 - Missing

For example, if a Service <Service_name_A> is missing in the online agent of <DMA1_ID> when compared with the offline:

####Service FOLDER INFO FOR DMA <DMA_ID>

INFO: Compared based on DMAID, ID, Name and Properties

------<IP_DMA1_Offline>------

Missing: 

<Service_name_A>


> [!TIP]
> You can download an example of the output from [DataMiner Dojo](https://community.dataminer.services/download/syncinfo3/).
