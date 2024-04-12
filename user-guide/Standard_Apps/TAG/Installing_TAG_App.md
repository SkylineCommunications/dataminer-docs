---
uid: Installing_TAG_App
---

# Installing the DataMiner TAG app

To install and set up the TAG app, do the following:

- Go to the [DataMiner Catalog](https://catalog.dataminer.services/), and deploy the latest version of the [TAG Management Package](https://catalog.dataminer.services/details/package/6076).

If your system is not connected to the DataMiner cloud, then you will have to download the package.
   
- In DataMiner Cube, go to *Apps > System Center > Agents > Manage*, and install the package in the same manner as a [DataMiner upgrade](xref:Upgrading_a_DataMiner_Agent_in_System_Center).

## TAG elements

To ensure full functionality of the *TAG Management* low-code application included in your package, creating elements is essential. Without these elements, the application will not operate correctly.

To create an element in DataMiner Cube, do the following:

1. In DataMiner Cube, open the *Surveyor*, and select the view in which you want to add the new element.

1. Right-click the selected view, hover over *New*, and select *Element*. This action will open a window in which you will be able to configure the element.

1. In the *Edit* tab, go to the *Device details* section.

   1. Open the *Protocol* selection box, search for "TAG", and select the appropriate TAG protocol (e.g. *TAG Video Systems MCM-9000* or *TAG Video Systems Media Control System*).
   1. Open the *Version* selection box, and select the latest version.

1. Go to the *HTTP connection* section.

   1. In the *IP address/host* box, enter the IP address of the TAG device.
   1. In the *IP port* box, enter the recommended port for the selected protocol.

      For information about the recommended port, see the documentation for [TAG MCM](https://catalog.dataminer.services/details/connector/1923) or [TAG MCS](https://catalog.dataminer.services/details/connector/8160).

1. At the bottom of the window, click *Create* button to have the element created.

> [!TIP]
> For more information on how to create elements, see [Adding elements](xref:Adding_elements).
