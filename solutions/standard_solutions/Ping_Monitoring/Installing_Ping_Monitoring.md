---
uid: Installing_Ping_Monitoring
---

# Installing the Ping Monitoring tool

## Prerequisites

- DataMiner version 10.3.9 [CU2] or higher

  > [!IMPORTANT]
  > The DataMiner Ping Monitoring tool was tested to be compatible with DataMiner versions 10.3.9 [CU2] and higher. We do not recommend using an older version as this may lead to unexpected issues.

- A DataMiner System [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud)

- The [*Generic Ping* connector](https://catalog.dataminer.services/details/253977dd-efa6-4095-b22e-de9adb9cc23d)

  > [!TIP]
  > We recommend using Generic Ping version 3.1.2.11 or higher. See [Deploying a Catalog item](xref:Deploying_a_catalog_item).

- At least one Generic Ping element within your DMS that is configured with one or multiple destinations

  > [!IMPORTANT]
  > The DataMiner Ping Monitoring tool will only recognize Generic Ping elements using the production version of the connector. See [Promoting a protocol to production version](xref:Promoting_a_protocol_version_to_production_version).

  > [!TIP]
  >
  > - For more information about configuring destinations, consult the [Generic Ping connector documentation](https://catalog.dataminer.services/details/516670b3-a9c5-402d-88f3-16b3f0c142bb).
  > - See also:
  >
  >   - [Working with elements in DataMiner](xref:Element_cards)
  >   - [Creating a ping element](xref:Adding_elements) ![Video](~/dataminer/images/video_Duo.png)

- Depending on your DataMiner version, you may need to enable the following soft-launch options:

  - [GenericInterface](xref:Overview_of_Soft_Launch_Options#genericinterface)

  - [ReportsAndDashboardsDynamicVisuals](xref:Overview_of_Soft_Launch_Options#reportsanddashboardsdynamicvisuals)

  - [ReportsAndDashboardsButton](xref:Overview_of_Soft_Launch_Options#reportsanddashboardsbutton)

  > [!NOTE]
  > To check whether your DataMiner version requires these soft-launch options, see [Overview of soft-launch options](xref:Overview_of_Soft_Launch_Options).

  > [!TIP]
  > See [Activating soft-launch options](xref:Activating_Soft_Launch_Options).

## Deploying the Ping Monitoring tool

1. Look up the [*Generic Ping* package](https://catalog.dataminer.services/details/cb1bd962-97a5-461b-80fd-a62b3799de96) in the Catalog.

1. Click the *Deploy* button.

1. Select the target DataMiner System and confirm the deployment. The package will then be pushed to the DataMiner System.

1. Go to `http(s)://[DMA name]/root` and select *PING Monitor* to start using the application.
