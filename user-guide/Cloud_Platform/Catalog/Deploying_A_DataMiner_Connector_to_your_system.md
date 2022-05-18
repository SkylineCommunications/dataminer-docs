---
uid: Deploying_A_DataMiner_Connector_to_your_system
---

# Deploying a DataMiner connector to your system

To deploy a connector to your DataMiner System from the Catalog module:

1. Make sure the following requirements are met:

   - Your DataMiner System is connected to the cloud. See [Connecting your DataMiner System to the cloud](xref:Connecting_your_DataMiner_System_to_the_cloud).
   - Your organization has been verified. This is necessary for DCP to be able to check for which connectors your organization has acquired a license. See [Getting your organization verified](xref:CloudConnectionVerification).
   - Your DCP account is linked to a DataMiner user account. See [Linking your DataMiner account to your DCP account](xref:Linking_your_DataMiner_and_DCP_account).

1. Look up the connector in the catalog. See [Looking up a DataMiner connector](xref:Looking_up_a_DataMiner_connector).

1. Click the *Deploy* button.

   > [!NOTE]
   >
   > - The *Deploy* button is only available if your organization has a license for the displayed connector. Otherwise, it is grayed out and displays the text "No License". In that case, to be able to deploy the connector, contact <licensing@skyline.be>.
   > - To deploy a specific version of a connector, click the version history of the connector, and then click the *Deploy* button next to the relevant version.

1. Select the target cloud-connected system and confirm the deployment. The connector will then be pushed to the DataMiner System.

> [!NOTE]
> Deploying a connector from the catalog will never change the production version for that connector in the DataMiner System.
