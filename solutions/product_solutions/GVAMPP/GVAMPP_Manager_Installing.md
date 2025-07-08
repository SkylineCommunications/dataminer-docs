---
uid: GVAMPP_Manager_Installing
---

# Installing the Grass Valley AMPP Manager Application

## Prerequisites

- DataMiner version 10.4.5 or higher
- A DataMiner System [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud)
- A connection to an AMPP tenancy via its URL (i.e., https://mytenancy.gvampp.com)
  
  > [!IMPORTANT]
  > The GV AMPP Manager connector requires an API key, which can be generated using the AMPP Identity Manager. Please refer to the AMPP documentation hub for specific instructions.

## Deploying the Grass Valley AMPP Manager app

1. Look up the [*GV AMPP Metrics* package](https://catalog.dataminer.services/details/56870962-1ade-45d2-b7ac-2fbb84383307) in the Catalog.
2. Click the *Deploy* button.
3. Select the target DataMiner System and confirm the deployment. The package will be pushed to the DataMiner System.

## Initial manager configuration

The Grass Valley AMPP Manager application relies on an external component to communicate with the designated AMPP tenancy. This component must be installed and configured on each DataMiner agent where an AMPP Manager element will be created.

The installation of the external component and the creation of a DataMiner AMPP Manager element is supported conveniently by an automation script that can be executed from the Metrics LCA as follows:

1. Access the GV AMPP Manager LCA from the Cube Apps panel or the DataMiner services homepage.
2. The LCA begins with the Statistics page. Click on the configuration page in the left pane (cogwheel icon):

![AMPP Metrics](~/user-guide/images/GVAMPP_statistics_page.png)

3. The configuration page is open with initial instructions and a link to download and install the Host bundle prerequisite. See details above.
4. Click the configure button to begin the configuration script, which will display the following interactive dialog:

![AMPP Setup Script](~/user-guide/images/GVAMPP_Setup_Script.png)

- **GVAMPP Endpoint:**  The URL for the target AMPP tenancy, for example,  https://mytenancy.gvampp.com.
- **API Key:** The key that was generated in the Identity Manager.
- **DMA:** In the case of a DMS, you can choose the agent to install and configure.

> [!IMPORTANT]
> If the target agent already has an AMPP Manager element, the script will recognize this and avoid any further configuration.

