---
uid: Installing_Huawei_Manager_Dashboard
---

# Installing the Huawei Manager dashboard

## Prerequisites

- DataMiner version 10.3.9 [CU2] or higher

  > [!IMPORTANT]
  > The DataMiner Huawei Manager dashboard was tested to be compatible with DataMiner versions 10.3.9 [CU2] and higher. We do not recommend using an older version as this may lead to unexpected issues.

- The [*Huawei Manager* connector](https://catalog.dataminer.services/result/driver/1094)

  > [!TIP]
  > We recommend using Huawei Manager version 1.0.4.7 or higher. See [Deploying a DataMiner connector to your system](xref:Deploying_A_DataMiner_Connector_to_your_system).

  > [!IMPORTANT]
  > The Huawei Manager dashboard will only recognize Huawei Manager elements using the production version of the connector. See [Promoting a protocol to production version](xref:Promoting_a_protocol_version_to_production_version).

- Depending on your DataMiner version, you may need to enable the following soft-launch options:

  - [GenericInterface](xref:Overview_of_Soft_Launch_Options#genericinterface)

  - [ReportsAndDashboardsDynamicVisuals](xref:Overview_of_Soft_Launch_Options#reportsanddashboardsdynamicvisuals)

  - [ReportsAndDashboardsButton](xref:Overview_of_Soft_Launch_Options#reportsanddashboardsbutton)

  > [!NOTE]
  > Future DataMiner versions may already include these features. To check the release version of a soft-launch option, see [Overview of soft-launch options](xref:Overview_of_Soft_Launch_Options).

  > [!TIP]
  > See [Activating soft-launch options](xref:Activating_Soft_Launch_Options).

## Deploying the Huawei Manager Dashboard

1. Look up the [*Huawei Manager* package](https://catalog.dataminer.services/catalog/5322) in the DataMiner Catalog.

1. Click the *Deploy* button.

1. Select the target DataMiner System and confirm the deployment. The package will then be pushed to the DataMiner System.

1. Go to `http(s)://[DMA name]/dashboard` and select *Huawei Switch Infrastructure Generic dashboard* to start using the dashboard.
