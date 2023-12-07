---
uid: Installing_Huawei_Manager_Dashboard
---

# Installing the Huawei Manager dashboard

1. Make sure the following **prerequisites** are met:

   - Your DataMiner System uses 10.3.9 [CU2] or higher and is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

     > [!IMPORTANT]
     > The DataMiner Huawei Manager dashboard was tested to be compatible with DataMiner versions 10.3.9 [CU2] and higher. We do not recommend using an older version as this may lead to unexpected issues.

   - Depending on your DataMiner version, you may need to enable the following soft-launch options:

     - [GenericInterface](xref:Overview_of_Soft_Launch_Options#genericinterface)

     - [ReportsAndDashboardsDynamicVisuals](xref:Overview_of_Soft_Launch_Options#reportsanddashboardsdynamicvisuals)

     - [ReportsAndDashboardsButton](xref:Overview_of_Soft_Launch_Options#reportsanddashboardsbutton)

     > [!NOTE]
     > To check whether your DataMiner version requires these soft-launch options, see [Overview of soft-launch options](xref:Overview_of_Soft_Launch_Options).

     > [!TIP]
     > See [Activating soft-launch options](xref:Activating_Soft_Launch_Options).

1. Deploy the *Huawei Manager* package:

   1. Go to <https://catalog.dataminer.services/catalog/5322>.

   1. Click the *Deploy* button.

   1. Select the target DataMiner System and confirm the deployment.

      The package will be pushed to the DataMiner System.

1. Go to `http(s)://[DMA name]/dashboard` and select *Huawei Switch Infrastructure Generic dashboard* to start using the dashboard.

> [!IMPORTANT]
> The Huawei Manager dashboard will only recognize Huawei Manager elements using the production version of the connector. See [Promoting a protocol to production version](xref:Promoting_a_protocol_version_to_production_version). Note also that we recommend using Huawei Manager version 1.0.4.7 or higher. If you are using a lower version, deploy the package again, as detailed above.
