---
uid: Deploying_a_catalog_item
---

# Deploying a Catalog item to your system

To deploy an item from the DataMiner Catalog (e.g. a connector or package) to your DataMiner System, make sure the following requirements are met:

   - Your DataMiner System is connected to dataminer.services. See [Connecting your DataMiner System to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

   - Your organization has been verified. This is necessary for dataminer.services to be able to check for which connectors your organization has acquired a license. See [Getting your organization verified](xref:CloudConnectionVerification).

   - Your dataminer.services account is linked to a DataMiner user account. See [Linking your DataMiner account to your dataminer.services account](xref:Linking_your_DataMiner_and_DCP_account).

> [!NOTE]
> From DataMiner 10.4.10/10.5.0 onwards<!--RN 40291-->, when you install a connector for the first time by deploying it from the DataMiner Catalog, it will automatically be promoted to the production version. However, when you later deploy a new version of the same connector and want it to be set as the production version, you will need to manually [promote this protocol version](xref:Promoting_a_protocol_version_to_production_version). Prior to DataMiner 10.4.10/10.5.0, deploying a connector from the Catalog will never change the production version for that connector in the DataMiner System.

## Deploying a Catalog item to your system with the UI

1. Look up the item in the Catalog. See [Looking up an item in the Catalog](xref:Looking_up_an_item_in_the_catalog).

   ![Microsoft Platform](~/user-guide/images/Catalog_Microsoft.png)

1. If you cannot see the *Deploy* button yet, go to the *Versions* tab and expand the version you want to deploy.

   If you do see a *Deploy* button immediately, but you want to deploy a specific version, also go to the *Versions* tab and expand the version you want to deploy.

   > [!NOTE]
   >
   > - If your organization does not have a license for the displayed item, the *Deploy trial* button will be displayed instead, which you can use to test the item in a staging environment. To get a license to deploy the item in a Production system, contact <licensing@skyline.be>.<!-- RN 39205 -->
   > - To be able to deploy an item to your DataMiner System, the DataMiner user profile linked to your dataminer.services user profile has to have the following permissions:
   >   - [Modules > System configuration > Agents > Install App packages](xref:DataMiner_user_permissions#modules--system-configuration--agents--install-app-packages).
   >   - [Modules > Automation > Execute](xref:DataMiner_user_permissions#modules--automation--execute).

1. Click the *Deploy* button.

   ![Deploy connector](~/user-guide/images/Catalog_Deploy_Account_Not_Linked.png)

    > [!NOTE]
    > If your account is not linked to one of the selected DataMiner systems, a message will be displayed indicating which systems the account is not linked to yet. Clicking the name of the DataMiner System will open a new tab to link your account. After the account linking process is complete, navigating back to the original tab will revalidate the account linking.

1. Select the target DataMiner System.

   The item will be pushed to the DataMiner System. In the Admin app, you can check the status of the deployment. See [Viewing information on deployments](xref:Viewing_info_on_deployments).


## Deploying a Catalog item to your system with the API

The deploy API call allows you to deploy a Catalog item to a DataMiner System.


> [!NOTE]
> The API calls are authenticated using [organization keys](xref:Managing_DCP_keys#organization-keys). Make sure you use a key that has the *Deploy a version of a catalog item* permission and add it to the HTTP request in a header called **Ocp-Apim-Subscription-Key**.

### API Definition

For a complete definition of the API, go to [Key Catalog API Swagger](https://catalogapi-prod.cca-prod.aks.westeurope.dataminer.services/swagger/index.html?urls.primaryName=Key+Catalog+API+v2.0).

This page also provides a quick way to execute the call: Expand the "/api/key-catalog/v2-0/catalogs/{catalogId}/versions/{versionId}/deploy" item, and click the *Try it out* button.

> [!IMPORTANT]
> Clicking the *Try it out* button will execute the download call on the production Catalog.

The [Swagger.json](https://catalogapi-prod.cca-prod.aks.westeurope.dataminer.services/swagger/key-catalog_2.0/swagger.json) can be used by e.g. [Swagger CodeGen](https://swagger.io/docs/open-source-tools/swagger-codegen/) or [AutoRest](https://azure.github.io/autorest/generate/) to generate client code.

### HTTP method

GET

### Route parameters

- Route parameter "catalogId" is the ID of the Catalog item of which you want to download a version from, which is the same as the ID used to [register the Catalog item](#registering-a-catalog-item-with-the-api). This must be a valid GUID.
  
  To obtain this ID for an existing Catalog item, navigate to its details page in the [Catalog](https://catalog.dataminer.services/). The ID is the last part of the URL.

- Route parameter "versionId" is the version number of the Catalog item you want to download.

- Route parameter "coordinationId" is the id of the DataMiner System to deploy to.

  To obtain this ID for an existing DataMiner system, navigate to its details page in the [Admin](https://admin.dataminer.services/). The ID is the last GUID of the URL.
