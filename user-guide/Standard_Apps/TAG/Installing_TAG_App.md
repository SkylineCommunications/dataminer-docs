---
uid: Installing_TAG_App
---

# Installing the DataMiner TAG app

To install and set up the TAG app:

1. In [DataMiner Catalog](xref:https://catalog.dataminer.services/), download the latest version of the [TAG Platform Package](xref:)

1. In DataMiner Cube, go to *Apps* > *System Center* > *Agents* > *Manage*, and install the package in the same manner as a [DataMiner upgrade](xref:Upgrading_a_DataMiner_Agent_in_System_Center).

1. In DataMiner Cube, go to *Apps* > *Automation*.

1. Select the script *TAG_SetupWizard* and click *Execute*.

1. On the first page, click the button *Execute Now*.

   The Setup Wizard will execute in the background and apply all changes needed.

1. Close execution window.

1. Open the Automation app and search for the "Merge LCA themes" script. Within the script, go to Advanced > DLL references and replace **C:\Skyline DataMiner\ProtocolScripts\WebApiLib.dll** with **C:\Skyline DataMiner\Webpages\API\bin\WebApiLib.dll**

## TAG Elements

To ensure full functionality of the TAG Management Low-code Application included in your package, creating elements is essential. Without these elements, the application will not operate correctly.

To create an element in DataMiner Cube, follow these steps:

1. In DataMiner Cube, navigate to the Surveyor section and select the View where you wish to add the new element.

1. Right-click on the selected view, hover over New, and then choose Element. This action will open a new tab for element configuration.

1. In the Element Configuration tab, locate the Device Details section:
   * Under Protocol, search for "TAG" and select the appropriate TAG protocol, such as TAG Video Systems MCM-9000 or TAG Video Systems Media Control System.
   * Choose the latest version from the Version dropdown menu.

1. In the *Version* dropdown select the latest version.

1. For the Http Connection:
   * Enter the IP address of the TAG device in the *IP address/host* field.
   * In the IP port section, input the recommended port for the selected protocol. Refer to the documentation for [TAG MCM](xref:https://catalog.dataminer.services/details/connector/1923) or [TAG MCS](xref:https://catalog.dataminer.services/details/connector/8160) for the recommended port information.

1. After filling all required fields, click the Create button to finalize the creation of the element.

For more information on how to create elements see [Adding elements](xref:Adding_elements).


   



   
