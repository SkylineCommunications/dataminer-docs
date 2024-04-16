---
uid: Installing_TAG_App
---

# Installing the DataMiner TAG Management app

## Prerequisites

- DataMiner version 10.4.5 or higher

- A connection to a TAG MCS system

- The DataMiner TAG Management app contains multiple functions that allows interaction with the TAG MCS or TAG MCM elements available in the system. To ensure the app works properly, it is necessary to have the following versions set to production at minimum:

  - TAG Video Systems MCM-9000 connector version 1.1.6.10

  - TAG Video Systems Media Control System (MCS) connector version 1.0.2.1

  > [!NOTE]
  > When you download the *TAG Management* package from the Catalog, these connectors are included and do not need to be installed separately.

## Deploying the DataMiner TAG Management app

If your system is **cloud-connected**:

1. Look up the [*TAG Management* package](https://catalog.dataminer.services/details/package/6076) in the DataMiner Catalog.

1. Click the *Deploy* button.

1. Select the target DataMiner System and confirm the deployment. The package will be pushed to the DataMiner System.

If your system is **not connected to the cloud**:

1. Look up the [*TAG Management* package](https://catalog.dataminer.services/details/package/6076) in the DataMiner Catalog.

1. Click the *Download* button.

1. Double click the package file and click on the Install button. This step requires [DataMiner Taskbar Utility](xref:DataMiner_Taskbar_Utility) to be installed and connected to the agent that will host the app.
   
1. The wizard will show the progress of the installation. If you encounter any issues please contact [techsupport@skyline.be](mailto:techsupport@skyline.be)

## Creating TAG elements

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

      > [!TIP]
      > For information about the recommended port, see the documentation for [TAG MCM](https://catalog.dataminer.services/details/connector/1923) or [TAG MCS](https://catalog.dataminer.services/details/connector/8160).

1. Click *Create* in the lower right corner to have the element created.

> [!TIP]
> For more information on how to create elements, see [Adding elements](xref:Adding_elements).

## Accessing the TAG Management app

To access the TAG Management application:

1. Go to `http(s)://[DMA name]/root`.

1. Select *TAG Management* to start using the application.

   ![TAG Management](~/user-guide/images/TAG_application.png)

> [!TIP]
> See also: [Use case: TAG VS – Tech Partner Integration](https://community.dataminer.services/use-case/tag-vs-tech-partner-integration/).
