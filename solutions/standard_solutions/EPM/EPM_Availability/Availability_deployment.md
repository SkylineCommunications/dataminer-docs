---
uid: Availability_deployment
keywords: Availability deployment
---

# Deploying the DataMiner EPM Availability solution

To deploy the Availability branch of the EPM Solution:

1. Deploy the EPM package:

   - If the DMA is connected to dataminer.services, you can [deploy the package](xref:Deploying_a_catalog_item) directly [from the Catalog](https://catalog.dataminer.services/details/85c53fba-9f58-42cb-bd94-5adce97f662e).

   - Otherwise, place the application package on any DMA available in the cluster. No specific location is required; however, avoid using the Skyline DataMiner folder (C:\Skyline DataMiner). More information about how to install application packages using the Taskbar Utility can be found under [Upgrading a DataMiner Agent using DataMiner Taskbar Utility](xref:Upgrading_a_DataMiner_Agent_using_DataMiner_Taskbar_Utility).

   This will install the application package on all the DMAs in the cluster.

   > [!NOTE]
   > If you are **upgrading** an existing EPM setup, no further steps are needed. However, if you are deploying this solution for the first time, follow the steps below as well.

1. Make sure the following prerequisites are met:

   - If the cluster (DMS) contains more that one DMA, it is mandatory to have a shared folder that is accessible by all DMAs available in the cluster.

   - There should be a separate DMA to host the front-end element, which does not host any collectors. This is not mandatory, but it is highly recommended.

   - If you are using a DataMiner Cube version prior to DataMiner Cube 10.4.0 [CU14]/10.5.0 [CU2]/10.5.5<!-- RN 42221 -->, make sure the [*CPEIntegration* soft-launch option](xref:Overview_of_Soft_Launch_Options#cpeintegration) is enabled so you can use the Topology app.

1. In DataMiner Cube, go to *Apps* > *Automation* and run the *EPMSetupWizard* automation script (in the *EPM TOOLS* folder).

   > [!TIP]
   > See [Manually executing a script](xref:Manually_executing_a_script)

1. Fill in the fields presented by the script:

   - *Frontend Host*: Select the DMA within your DataMiner System that should host the front-end element. On the other DMAs, back-end elements will be created.

   - *Number of Expected Endpoints*: Determines how many collector elements will be created. The script will create a collector for every 20K endpoints. For example, for 500K expected endpoints, 25 collector elements will be created, evenly distributed over all available DMAs.

      > [!NOTE]
      > The collectors can support more endpoints. This setting is used as a baseline. This means that as more endpoints are added, there is nothing else that needs to be done, and the system will work without intervention. You will only need to add more collectors in case there is a large increase of the number of endpoints.

   - *File Configuration*: This section contains all the required fields for distributing the endpoints to all elements. If a cluster is used, provide the remote directory with the hostname, e.g. `\\HostName\DataMiner EPM\Availability`, and the username and password of a user that has read/write access to this directory.

1. Click the *Create* button.

   The script will create and configure all the elements needed for the solution. This can take a while depending on how many elements need to be created. You can follow the progress via the information events in the Alarm Console.

1. When the script is finished, place a file named *MASTER_PING.csv* in the directory that was specified during the setup wizard (default: `C:\Availability`).

   This file must have the following header:

   `ENDPOINT_ALIAS;IP;CUSTOMER_NAME;VENDOR_NAME;STATION_NAME;HUB_NAME;SUB_REGION_NAME;REGION_NAME;NETWORK_NAME;LATITUDE;LONGITUDE`

   > [!NOTE]
   >
   > - You can use either a semicolon or a comma as the delimiter for the CSV file. Not all fields are needed. Any fields not used can be left blank.
   > - For an example of what the file structure should look like, refer to `C:\Skyline DataMiner\Documents\Availability`.

1. Open the *Configuration* topology chain in the Topology app.

1. In the front-end visual overview, click the *Set* button next to *Import* to begin the provisioning.

   ![Configuration page front-end element](~/dataminer/images/Availability_FrontEnd_Configuration.png)

   > [!NOTE]
   > If you cannot see the Topology app in between the Surveyor and Activity modules in Cube, close and reopen DataMiner Cube. If this has no effect, and you are using a DataMiner Cube version prior to DataMiner Cube 10.4.0 [CU14]/10.5.0 [CU2]/10.5.5<!-- RN 42221 -->, make sure the [*CPEIntegration* soft-launch option](xref:Overview_of_Soft_Launch_Options#cpeintegration) is enabled. If you are using a recent DataMiner version or the option is enabled, and the app is still not shown, restart DataMiner.

1. Optionally, duplicate and customize the alarm and trend templates.

   The *EPM_SetupWizard* script automatically assigns default alarm and trend templates that have a baseline of thresholds as a starting point. If you would like to make further adjustments to the thresholds or apply conditional rules, it is important that you duplicate the default templates as they will be overwritten with any subsequent Availability package update.
