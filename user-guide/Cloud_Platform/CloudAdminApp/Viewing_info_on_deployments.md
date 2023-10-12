---
uid: Viewing_info_on_deployments
---

# Viewing information on deployments

In the Admin app, you can view information about all the deployments that have been done to the DataMiner System via the Nodes page, via the Catalog, or using a GitHub pipeline with our GitHub action.

To do so:

1. In the Admin app, check whether the correct organization is mentioned in the header bar.

   > [!TIP]
   > See also: [Accessing the Admin app](xref:Accessing_the_Admin_app)

1. If a different organization should be selected, click the organization selector ![Organization selector](~/user-guide/images/Cloud_Admin_Selector_icon.png) in the top-right corner and select the organization in the list.

1. In the pane on the left, under *DataMiner Systems*, select your DataMiner System and select the *Deployments* page.

   This page details what has been deployed, when, and by whom, and whether the deployment succeeded, is pending, or failed.

   Click an item in the list to view more detailed information, including version information and event information that can be used for debugging.

> [!NOTE]
> When you select a deployment record, the URL of the Admin app is updated with a query parameter referencing the ID of the deployment. This way, you can easily share the deployment record with someone by sharing the URL.

> [!TIP]
> You can also find log files regarding deployments in the folder *C:\ProgramData\Skyline Communications\DataMiner ArtifactDeployer* on the server where the Artifact Deployer is installed. Together with the information in the Admin app, this can help you solve any problems with deployments.
