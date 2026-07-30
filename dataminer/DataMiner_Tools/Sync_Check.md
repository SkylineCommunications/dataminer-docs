---
uid: Sync_Check
---

# Sync Check

## About this tool

To verify the synchronization of element and service files across a DataMiner System, you can use the "Sync Check" automation script.

This is especially intended for troubleshooting in large clusters (which can include Failover Agents) in case there are errors related to duplicate service or element IDs, errors when new services are created that reuse the name of old services, or synchronization errors related to services or elements;

You can get this script from the [DataMiner Catalog](https://catalog.dataminer.services/details/151f362f-673a-4674-b678-f1f494b1713a).

## Running the Sync Check script

To use this script:

1. Install the script package on a DMA in the DataMiner System you are troubleshooting, via the DataMiner Catalog. Once installed, the script will become available in the *Skyline-TechSupport* folder in the Automation module.

1. Run the script in the Automation module and specify a username and password. These credentials will be used to access the different Agents in the DMS via file shares.

1. When the script has run, check its output in the generated per-run report grouped by DMA, which you can find in the following folder on the DMA: `C:\Skyline_Data\SyncCheckResults\`. The file name uses the format `SyncCheckResult_<yyyyMMdd>_<HHmm>.txt`, based on server-local time.

Note that to be able to run the script, file share access to all IP addresses in the cluster is required.

### Username formats

The **Username** parameter supports the following formats:

- `alice` (local account)
- `.\alice` (explicit local account)
- `MYDOMAIN\alice` (Active Directory, NETBIOS down-level)
- `alice@corp.example.com` (Active Directory, UPN)

### Prerequisites

- A Windows account with local Administrator rights on the remote DMAs. The script accesses the `C:\Skyline DataMiner` folder through the administrative UNC share `\\<DMA-IP>\c$`.

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

  - Orphaned remote-service references (source service no longer exists)

## Output report

The generated report file consists of an ERRORS section, a DEBUG LOGGING section (listing all the DMAs found in the cluster, including which agent acts as Main/Backup and the resolved connection identity used for each), and the following sections for each DMA:

- Elements INFO

- Service INFO

- ELEMENT FOLDER INFO

- Service FOLDER INFO

- Remote Service Folder Check

### Error examples

- `No ERRORS`

  This is the expected message when there are no errors.

- `RetrieveInfoFromFolders Exception -> <ExceptionType>: <Message>`

  This error will be shown for each DataMiner Failover pair where folder retrieval fails, for example when the file share is not configured. The error is logged as a single compact line; the full exception stack trace is no longer included in the report.

- `Inconsistent FolderName`

  This error is shown if a service name and the service folder name are different.
  
  For example, here the folder name is *Service_name_example* and the folder name is *Service_name_example_1*:

  ```txt
  Inconsistent FolderName (Service_name_example): \<DMA_IP>\c$\Skyline DataMiner\RemoteServices\<DMA_ID>\Service_Name_example_1
  ```

- `Duplicate Entries`

  This error is shown when there are two services with the same ID, for example the services *Service_name_A* and *Service_name_B* here:

  ```txt
  Duplicate Entries in Backup Service folder for ID <DMA_ID>/<service_ID>:Service_name_A, Service_name_B
  ```

- `Orphaned remote-service references (source service no longer exists):`

  This is shown when a local remote-service reference folder exists, but the source service it points to no longer exists on the origin DMA. This differs from `Missing services`, which indicates a remote-service reference is expected but not found locally.

### Other examples

In the *Elements INFO*, *Service INFO*, *ELEMENT FOLDER INFO*, *Service FOLDER INFO*, and *Remote Service Folder Check* sections, if everything is OK, a message such as `<IP_DMA1> And <IP_DMA2> Are In Sync!` or `The remote services for DMA <DMA_ID> are in Sync!` will be displayed.

For example:

```txt
#################################
####Elements INFO FOR DMA 123 'DMA_A'
#################################

INFO: Compared based on DMAID, ID, protocol, version and Name
SLNet And Folder Structure Are In Sync!
---------------------------------

#################################
####Service INFO FOR DMA 123 'DMA_A'
#################################

INFO: Compared based on DMAID, ID, protocol, version and Name
SLNet And Folder Structure Are In Sync!
---------------------------------

#################################
####ELEMENT FOLDER INFO FOR DMA 123 (FO Pair: 'DMA_A' <-> 'DMA_B')
#################################

INFO: Compared based on DMAID, ELID, Name, Protocol, Version and Properties
<IP_DMA1> And <IP_DMA2> Are In Sync!
---------------------------------

#################################
####Service FOLDER INFO FOR DMA 123 (FO Pair: 'DMA_A' <-> 'DMA_B')
#################################

INFO: Compared based on DMAID, ID, Name and Properties
<IP_DMA1> And <IP_DMA2> Are In Sync!
---------------------------------

#################################
####Remote Service Folder Check for DMA 123 (FO Pair: 'DMA_A' <-> 'DMA_B')
#################################

INFO: MAKE SURE MAIN AND BACKUP ARE IN SYNC FIRST!
The remote services for DMA 123 are in Sync!
---------------------------------
```

If something is missing on one of the DMAs, a message starting with `Missing` will be displayed, scoped to the relevant agent's role. For example, if a service *Service_name_A* is missing on the Backup DMA compared to the Main DMA:

```txt
#################################
####Service FOLDER INFO FOR DMA 123 (FO Pair: 'DMA_A' <-> 'DMA_B')
#################################

INFO: Compared based on DMAID, ID, Name and Properties

------ Missing on 'DMA_B' => <IP_DMA1_Backup> (Backup) ------

Service_name_A
```
