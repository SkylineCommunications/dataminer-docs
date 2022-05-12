---
uid: Deploying_A_DataMiner_Connector_to_your_system
---

# Deploying a DataMiner connector to your Cloud Connected system

## Requirements to be able to use this feature

First of all make sure that the DataMiner System you want to deploy to is connected to the cloud. You can find documentation about getting your system connected to the cloud [here](xref:Connecting_your_DataMiner_System_to_the_cloud).

Be sure to check if you organization has been verified already. This is necessary so we can check for which connectors your organization has acquired licenses. If your organization is not verified you will not be able to deploy any connector to your system. Take a look at the [guide](xref:CloudConnectionVerification) for more info on how you can get your organization verified.

The last thing you need to do is link your DCP account to a DataMiner user. To do this you can follow [this](xref:Linking_your_DataMiner_and_DCP_account) guide.

## How to deploy to your system

To deploy a connector you must first find it in the Catalog. Once you have located your connecter you will be able to see a button that says "deploy".

> [!NOTE]
> You will only see the deploy button if your organization has a license for that specific connector. If your organization does not have a license the button will be greyed out and have the text "No License" in it. In that case we suggest you contact licensing@skyline.be.

After clicking the deploy button you will be presented with a list of Cloud Connected systems for your organization that you can deploy the connector to. Select your target system(s) and confirm the deploy action. This will push the connector to your DataMiner System.

> [!NOTE]
> Pushing a connector will never change the production version for that connector on the DataMiner System.

If you want to deploy a specific version of a connector you can click on the version history of the connector. Every version will have a deploy button next to it that can be used to deploy that specific version to your DataMiner System(s).
