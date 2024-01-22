---
uid: Deploying_a_catalog_item
---

# Deploying a Catalog item to your system

To deploy an item from the DataMiner Catalog (e.g. a connector or package) to your DataMiner System:

1. Make sure the following requirements are met:

   - Your DataMiner System is connected to dataminer.services. See [Connecting your DataMiner System to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).
   - Your organization has been verified. This is necessary for dataminer.services to be able to check for which connectors your organization has acquired a license. See [Getting your organization verified](xref:CloudConnectionVerification).
   - Your dataminer.services account is linked to a DataMiner user account. See [Linking your DataMiner account to your dataminer.services account](xref:Linking_your_DataMiner_and_DCP_account).

1. Look up the item in the Catalog. See [Looking up an item in the Catalog](xref:Looking_up_an_item_in_the_catalog).

1. If you cannot see the *Deploy* button yet, go to the *Versions* tab and expand the version you want to deploy.

   If you do see a *Deploy* button immediately, but you want to deploy a specific version, also go to the *Versions* tab and expand the version you want to deploy.

   > [!NOTE]
   >
   > - The *Deploy* button is only available if your organization has a license for the displayed item. If it is unavailable, to be able to deploy the item, contact <licensing@skyline.be>.
   > - All dataminer.services users in your organization have the rights to deploy items to your DataMiner Systems, regardless of the [permissions](xref:DataMiner_user_permissions) that have been configured for them in DataMiner. Note that this will be adjusted in the near future.

1. Click the *Deploy* button.

1. Select the target DataMiner System and click *Deploy*.

   The item will be pushed to the DataMiner System. In the Admin app, you can check the status of the deployment. See [Viewing information on deployments](xref:Viewing_info_on_deployments).

> [!NOTE]
> Deploying a connector from the Catalog will never change the production version for that connector in the DataMiner System.
