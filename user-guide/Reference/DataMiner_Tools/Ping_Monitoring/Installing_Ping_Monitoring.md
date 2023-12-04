---
uid: Installing_Ping_Monitoring
---

# Installing the Ping Monitoring tool

## Prerequisites

- DataMiner version 10.3.9 [CU2] or higher

  > [!IMPORTANT]
  > The DataMiner Ping Monitoring tool was tested to be compatible with DataMiner versions 10.3.9 [CU2] and higher. We do not recommend using an older version as this may lead to unexpected issues.

- A DataMiner System [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud)

- The [*Generic Ping* connector](https://catalog.dataminer.services/result/driver/530)

  > [!TIP]
  > We recommend using Generic Ping version 3.1.2.11 or higher. See [Deploying a DataMiner connector to your system](xref:Deploying_A_DataMiner_Connector_to_your_system).

- At least one Generic Ping element within your DMS that is configured with one or multiple destinations

  > [!IMPORTANT]
  > The DataMiner Ping Monitoring tool will only recognize Generic Ping elements using the production version of the connector. See [Promoting a protocol to production version](xref:Promoting_a_protocol_version_to_production_version).
  
- Promoting_a_protocol_version_to_production_version).

  > [!TIP]
  >
  > - For more information about configuring destinations, consult the [Generic Ping connector documentation](https://catalog.dataminer.services/result/driver/530).
  > - See also: [Working with elements in DataMiner](xref:Element_cards)

- Depending on your DataMiner version, you may need to enable the following soft-launch options:

  - [GenericInterface](xref:Overview_of_Soft_Launch_Options#genericinterface)

  - [ReportsAndDashboardsDynamicVisuals](xref:Overview_of_Soft_Launch_Options#reportsanddashboardsdynamicvisuals)

  - [ReportsAndDashboardsButton](xref:Overview_of_Soft_Launch_Options#reportsanddashboardsbutton)

  > [!NOTE]
  > Future DataMiner versions may already include these features. To check the release version of a soft-launch option, see [Overview of soft-launch options](xref:Overview_of_Soft_Launch_Options).

  > [!TIP]
  > See [Activating soft-launch options](xref:Activating_Soft_Launch_Options).

## Deploying the Ping Monitoring tool

1. Look up the [*Ping Monitoring* package](https://catalog.dataminer.services/catalog/4992) in the DataMiner Catalog.

1. Click the *Deploy* button.

1. Select the target DataMiner System and confirm the deployment. The package will then be pushed to the DataMiner System.

1. Go to `http(s)://[DMA name]/root` and select *PING Monitor* to start using the application.
