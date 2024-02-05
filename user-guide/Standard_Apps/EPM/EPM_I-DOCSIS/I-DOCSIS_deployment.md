---
uid: I-DOCSIS_deployment
---

# EPM I-DOCSIS deployment

To deploy the I-DOCSIS branch of the EPM Solution:

1. Make sure the latest DataMiner feature release version is installed. 

2. Download the latest EPM package to the DMA server (in a different folder than C:\Skyline DataMiner) and install the package. This will install the package on all DMAs so it only needs to be executed on a single DMA. 
If DMA is connected to Dataminer Services, may deploy package directly from the Catalog.
   - If DMA is connected to Dataminer Services, may deploy package directly from the Catalog.

That is all that is needed for upgrading a configured EPM Solution. If this is an initial deployment, please perform the following steps.

> [!Prerequisite]
>1. If using multiple DMA's, a remote file location that is accessible by all servers is needed.
>2. Hosting the FrontEnd element on it's own DMA with no collectors is highly recommended.
>3. To enable the Topology app, the CPEIntegration soft launch option is needed.
  

3.  **create the necessary views**. See [Creating a view](xref:Managing_views#creating-a-view).

   - The solution expects the following view structure:

     > - Root level
     >   - Network (one or more views below the Service Provider level)
     >     - Market (as many views as are needed below the Network level)
     >       - Hub (as many views as are needed below the Market level)

     For example:

     ![I-DOCSIS view structure](~/user-guide/images/I-DOCSIS_view_structure.png)

     You can adjust the view names as you see fit, as long as the appropriate hierarchical structure is maintained. There will be a direct mapping between the views you created and the corresponding EPM topology. For example:

     ![I-DOCSIS topology](~/user-guide/images/I-DOCSIS_topology.png)

   - In addition, within the Service Provider view, add the following set of views, structured as shown below:

     > - System
     >   - DataMiner EPM
     >     - EPM BE
     >     - EPM FE

4. Create the FrontEnd Element in the System > DataMiner EPM > EPM FE view. Select Default Alarm and Trend templates if would like a starting off point for monitored KPI’s.
   
5. Create one BackEnd element per DMA in the System > DataMiner EPM > EPM BE view. Select Default Alarm and Trend templates if would like a starting off point for monitored KPI’s.
   > [!NOTE]
   > It is recommended that no Collector or BackEnd elements are on the same DMA as the FrontEnd.

6. Assign Visual Visio to EPM Elements. 
	- Go to Apps > Protocols & Templates
	- Select Skyline EPM Platform
	- Under Visio Files, right click on Custom and select ‘Set as active Visio file’
	- Do the same for the Skyline EPM Platform DOCSIS driver

7. Configure the FrontEnd element.
	- Add the FrontEnd's DMA ID/Element ID to the FrontEnd Registration table.
   - Add all of the DMA ID/Element ID's of the created BackEnds to the BackEnd Registration table. 
   - Configure the directory settings. It is recommended to have the FrontEnd import and export from a local directory. If using a remote directory, also provide username and password credentials of user who has access to the remote directory.

8. Configure the BackEnd elements.
	- Add the current BackEnd's DMA ID/Element ID to it's BackEnd Registration table. 
   - Update the directory settings. The Import directory will be the FrontEnd's export directory/DOCSIS. If using a remote directory, also provide username and password credentials of user who has access to the remote directory. Updating the Directory settings can be done using the Multiple Set option in Dataminer if configuring multiple BackEnd elements.
  
9. To configure CMTS elements, use the provided EPM_I_DOCSIS_AddNewCcapCmPair. See [Creating CCAP/CM Pair](https://docs.dataminer.services/user-guide/Standard_Apps/EPM/EPM_I-DOCSIS/I-DOCSIS_Create_CCAP_CM_pair.html).
