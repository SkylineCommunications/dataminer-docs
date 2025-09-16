---
uid: I-DOCSIS_deployment
keywords: I-DOCSIS deployment
---

# EPM Integrated DOCSIS deployment

To deploy the Integrated DOCSIS branch of the EPM Solution:

1. Make sure the latest DataMiner feature release version is installed.

1. Deploy the EPM package:

   - If the DMA is connected to dataminer.services, you can [deploy the package](xref:Deploying_a_catalog_item) directly from the Catalog.

   - Otherwise, place the application package on any DMA available in the cluster. No specific location is required; however, avoid using the Skyline DataMiner folder (C:\Skyline DataMiner). More information about how to install application packages using the Taskbar Utility can be found under [Upgrading a DataMiner Agent using DataMiner Taskbar Utility](xref:Upgrading_a_DataMiner_Agent_using_DataMiner_Taskbar_Utility).

   This will install the application package on all the DMAs in the cluster.

   > [!NOTE]
   > If you are **upgrading** an existing EPM setup, refer to [EPM Integrated DOCSIS upgrade](xref:I-DOCSIS_upgrade) for further steps. If you are deploying this solution for the **first time**, follow the steps below.

1. Make sure the following prerequisites are met:

   - If the cluster (DMS) contains more that one DMA, it is mandatory to have a shared folder that is accessible by all DMAs available in the cluster.

   - There should be a separate DMA to host the front-end element, which does not host any collectors. This is not mandatory, but it is highly recommended.

   - If you are using a DataMiner Cube version prior to DataMiner Cube 10.4.0 [CU14]/10.5.0 [CU2]/10.5.5<!-- RN 42221 --> and you want to be able to use the Topology app, the [*CPEIntegration* soft-launch option](xref:Overview_of_Soft_Launch_Options#cpeintegration) must be enabled.

1. Create the necessary views. See [Creating a view](xref:Managing_views#creating-a-view).

   - The solution expects the following view structure:

     > - Root level
     >   - Network (one or more views below the Service Provider level)
     >     - Market (as many views as are needed below the Network level)
     >       - Hub (as many views as are needed below the Market level)

     For example:

     ![Integrated DOCSIS view structure](~/dataminer/images/I-DOCSIS_view_structure.png)

     You can adjust the view names as you see fit, as long as the appropriate hierarchical structure is maintained. There will be a direct mapping between the views you created and the corresponding EPM topology. For example:

     ![Integrated DOCSIS topology](~/dataminer/images/I-DOCSIS_topology.png)

   - In addition, within the Service Provider view, add the following set of views, structured as shown below:

     > - Z-SYSTEM
     >   - DataMiner EPM
     >     - EPM BE
     >     - EPM FE

1. Create the front-end element in the view *System* > *DataMiner EPM* > *EPM FE*.

   Optionally, select the default alarm and trend templates during element creation to have a starting point for monitored KPIs.

1. Create one back-end element per DMA where a CCAP collector will reside.

   The back-end element will be in charge of all CCAP collectors on the same DMA. The CM collectors can be placed on DMAs without a back-end element.

   Place these elements in the view *System* > *DataMiner EPM* > *EPM BE*.

   Optionally, select the default alarm and trend templates during element creation to have a starting point for monitored KPIs.

   > [!NOTE]
   > We recommend that you avoid placing collector or back-end elements on the same DMA as the front-end element.

1. Assign the necessary Visio drawings to the EPM elements:

   1. Go to *Apps* > *Protocols & Templates*.

   1. Select *Skyline EPM Platform*.

   1. Under *Visio Files*, right-click *Custom* and select *Set as active Visio file*.

   1. Select *Skyline EPM Platform DOCSIS* and repeat the previous step.

1. Configure the front-end element:

   1. Add the DMA ID/Element ID of the front-end element to the *Frontend Registration* table. This can be found on the Frontend page in the Configuration Topology, accessible through the Topology app or in the element.

   1. Add all of the DMA ID/Element ID combinations of the created back-end elements to the *Backend Registration* table. This can be found in the Element in the Configuration Topology Chain under the Backends page.

   1. Configure the directory settings:

      - We recommend having the front end import and export from a local directory.

      - If you use a remote directory instead, also provide username and password credentials of a user with access to the remote directory.

1. Configure the back-end elements:

   1. Add the DMA ID/Element ID of each back-end element to the *Backend Registration* table of that element. This can be found in the Element in the Configuration Topology Chain under the Backends page.

   1. Configure the directory settings:

      - The import directory will be the front end's export directory/DOCSIS.

      - If you use a remote directory, also provide username and password credentials of user with access to the remote directory.

      - To configure the directory settings for multiple back-end elements at the same time, you can use the [multiple set](xref:Updating_elements#setting-a-parameter-value-in-multiple-elements) feature.

1. Configure the CMTS elements using the script *EPM_I_DOCSIS_AddNewCcapCmPair*. See [Creating CCAP/CM Pair](https://docs.dataminer.services/dataminer/Standard_Apps/EPM/EPM_I-DOCSIS/I-DOCSIS_Create_CCAP_CM_pair.html).
