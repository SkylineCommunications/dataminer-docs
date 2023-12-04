---
uid: Remote_PHY_Monitoring_Installation
---
# Installation of the Remote PHY Monitoring

## Prerequesites
- Dataminer version 10.3.0 or higher.
	> [!IMPORTANT]
	> When using a version older than 1.0.4.0 upgrade the Dataminer web apps version to 10.3.11.0 or higher.
	>	- Documentation: [Upgrading the Dataminer web apps](xref:Upgrading_Downgrading_Webapps#upgrading-the-dataminer-web-apps)
	>	- Download: [Dataminer 10.3.11.0 - 13456 Web Upgrade](https://community.dataminer.services/download/dataminer-10-3-11-0-13456-web-upgrade/?hilite=web+upgrade)   

- Depending on your Dataminer version, you may need to enable the following soft-launch options:
 	- [GenericInterface](xref:Overview_of_Soft_Launch_Options#genericinterface)
	- [ReportsAndDashboardsDynamicVisuals](xref:Overview_of_Soft_Launch_Options#reportsanddashboardsdynamicvisuals)
	- [ReportsAndDashboardsPTP](xref:Overview_of_Soft_Launch_Options#reportsanddashboardsptp)

	> [!NOTE]
	> Future DataMiner versions may already include these features. To check the release version of a soft-launch option, see [Overview of soft-launch options](xref:Overview_of_Soft_Launch_Options).

	 > [!TIP]
	 > See [Activating soft-launch options](xref:Activating_Soft_Launch_Options).

# Package Deployment

1. Look up the [*Remote PHY Monitoring* package](https://catalog.dataminer.services/details/package/5557) in the Dataminer Catalog.
1. Click the Deploy button.
1. Select the target Dataminer System and confirm the deployment. The package will then be pushed to the Dataminer system.
1. Open Dataminer Cube and go to the *Vecima RPM* element that was created under the *Remote PHY Monitor* View.
	This element will be in timeout due to the fact that we still need to set the IP of the API and the credentials following the steps below:  
	> [!NOTE]
	> Only follow this step if it is the first time deploying the package.

	> - Remote PHY Monitoring
	>	- Vecima RPM

	1. Righ click on the element.
	1. Select **edit**.
	1. Add the **IP Address**.
	1. Go back to the element and open the *Configuration* page.
	1. Set the **Username** and **Password**.
1. Go to `http(s)://[DMA name]/root` and start using the low-code apps:
	- R-PHY Monitoring:
	
		![R-PHY Monitoring](~/user-guide/images/R-PHY_Monitoring.png)
	- R-PHY Analog & RF:
	
		![R-PHY Analog & RF](~/user-guide/images/R-PHY_Analog_RF.png)

