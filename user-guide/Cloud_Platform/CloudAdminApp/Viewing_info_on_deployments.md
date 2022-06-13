---
uid: Viewing_info_on_deployments
---

# Viewing information on deployments

In the DCP Admin app, you can view information about all the deployments that have been done to the DataMiner System via the Nodes page, via the Catalog, or using a GitHub pipeline with our GitHub action.

To do so:

1. In the Admin app, check whether the correct organization is mentioned in the header bar.

1. If a different organization should be selected, click the organization selector in the top-right corner and select the organization in the list.

   ![Organization selector](~/user-guide/images/CloudAdmin_Selector.png)

1. In the pane on the left, under *DataMiner Systems*, select your DataMiner System and select the *Deployments* page.

   This page details what has been deployed, when, and by whom, and whether the deployment succeeded, is pending, or failed.

   Click an item in the list to view more detailed information, including version information and event information that can be used for debugging. For example, in case a pending deployment is queued because of other deployments, you will be able to see this in the event information.
