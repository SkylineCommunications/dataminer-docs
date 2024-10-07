---
uid: Availability_deployment
keywords: Availability deployment
---

# Dataminer EPM Availability deployment

To deploy the Availability branch of the EPM Solution:

1. Deploy the EPM package:

   - If the DMA is connected to dataminer.services, you can [deploy the package](xref:Deploying_a_catalog_item) directly from the Catalog.

   - Otherwise, place the application package on any DMA available in the cluster. No specific location is required; however, avoid using the Skyline DataMiner folder (C:\Skyline DataMiner). More information about how to install application packages using the Taskbar Utility can be found under [Upgrading a DataMiner Agent using DataMiner Taskbar Utility](xref:Upgrading_a_DataMiner_Agent_using_DataMiner_Taskbar_Utility).

   This will install the application package on all the DMAs in the cluster.

   > [!NOTE]
   > If you are **upgrading** an existing EPM setup, no further steps are needed. However, if you are deploying this solution for the first time, follow the steps below as well.

1. Make sure the following prerequisites are met:

   - If the cluster (DMS) contains more that one DMA, it is mandatory to have a shared folder that is accessible by all DMAs available in the cluster.

   - There should be a separate DMA to host the front-end element, which does not host any collectors. This is not mandatory, but it is highly recommended.

   - If you want to be able to use the Topology app, the [*CPEIntegration* soft-launch option](xref:Overview_of_Soft_Launch_Options#cpeintegration) must be enabled.

1. Execute the *EPMSetupWizard* Automation script found in *Apps* > *Automation* > *EPM TOOLS*.

1. Fill in the fields presented by the script:
   - **Frontend Host** will show all of the available DMA servers in the system. This will be where the Frontend element will reside and all of the other DMA's will have Backend elements created.

   - **Number of expected Endpoints** is used to determine how many Collector elements will be created. The script will create a Collector for every 20k endpoints I.E. 500k expected endpoints will have 25 Collector elements created, evenly distributed to all available DMA's.
      > [!NOTE]
      > The Collectors can support more endpoints, this is just used as a baseline. So as more endpoints are added, there is nothing else that needs to be done and the system will work without intervention. Addition of additional Collectors is only needed if a large increase of endpoints are added.

   - The **File Configuration** section has all the required fields for distributing the endpoints to all of the elements. If a cluster is used, please provide the remote directory with the hostname I.E. //HostName/Availability and the Username and Password of a user that has read/write access to the directory.

1. Hit the create button for the script to create and configure all the elements needed for the solution.
> [!NOTE]
> The script can take a while depending on how many elements are needed to be created. Progress can be tracked in the Information Events tab in the Alarm Console.

1. Place a file called MASTER_PING.csv in the directory to be used. There is an example of what the file structure should look like in C:Skyline DataMiner\Documents\Availability.
> [!NOTE]
> Semicolon or comma delimiters may be used in this file.

1. Open the Configuration topology chain in the Topology app. Once the Frontend's visual overview loads, simply hit the Import button to begin the provisioning.

![alt text](image-1.png)

> [!NOTE]
> If the Topology app does not appear inbetween the Surveyor and Activity modules in Cube, please ensure the [*CPEIntegration* soft-launch option](xref:Overview_of_Soft_Launch_Options#cpeintegration) has been configured. A Cube or DMA restart may be required for it to take effect.