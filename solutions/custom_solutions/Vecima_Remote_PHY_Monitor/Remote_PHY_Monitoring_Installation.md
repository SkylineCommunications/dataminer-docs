---
uid: Remote_PHY_Monitoring_Installation
---
# Installing Remote PHY Monitoring

1. Make sure the following **prerequisites** are met:

   - Your DataMiner System uses DataMiner 10.3.0 or higher and is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

   - Make sure the DataMiner web apps are upgraded to DataMiner 10.3.11 or higher.

     > [!TIP]
     > See also: [Upgrading the DataMiner web apps](xref:Upgrading_Downgrading_Webapps)

   - Depending on your DataMiner version, you may need to enable the following soft-launch options:

     - [GenericInterface](xref:Overview_of_Soft_Launch_Options#genericinterface)
     - [ReportsAndDashboardsDynamicVisuals](xref:Overview_of_Soft_Launch_Options#reportsanddashboardsdynamicvisuals)
     - [ReportsAndDashboardsPTP](xref:Overview_of_Soft_Launch_Options#reportsanddashboardsptp)

     > [!NOTE]
     > To check whether your DataMiner version requires these soft-launch options, see [Overview of soft-launch options](xref:Overview_of_Soft_Launch_Options).

     > [!TIP]
     > See [Activating soft-launch options](xref:Activating_Soft_Launch_Options).

1. Deploy the *Remote PHY Monitoring* package:

   1. Look up the [Remote PHY Monitoring](https://catalog.dataminer.services/details/4abaa31f-faa6-44d1-a737-7eebb8fdb649) package in the Catalog.

   1. Click the *Deploy* button.

   1. Select the target DataMiner System and confirm the deployment.

      The package will be pushed to the DataMiner System.

1. Configure the *Vecima RPM* element:

   1. Open DataMiner Cube and go to the *Vecima RPM* element that has been created under the *Remote PHY Monitor* View.

      At this point, this element will be in timeout because the IP of the API and credentials still need to be configured.

   1. Right-click the *Vecima RPM* element in the Surveyor and select *Edit*.

   1. Specify the IP address in the *IP address/host* box and click *Apply*.

   1. Go to the *Configuration* page of the *Vecima RPM* element.

   1. Set the *Username* and *Password*.

You can now go to `http(s)://[DMA name]/root` and start using the Remote PHY Monitoring low-code apps. Two apps are available:

- R-PHY Monitoring

  ![R-PHY Monitoring](~/dataminer/images/R-PHY_Monitoring.png)

- R-PHY Analog & RF

  ![R-PHY Analog & RF](~/dataminer/images/R-PHY_Analog_RF.png)

> [!NOTE]
> If you want to **update** an existing installation of the Remote PHY Monitoring Solution, you can do so by going to the [*Remote PHY Monitoring* package](https://catalog.dataminer.services/details/4abaa31f-faa6-44d1-a737-7eebb8fdb64) in the Catalog and deploying it. The steps that follow after this deployment in the procedure above are not needed for an update.
