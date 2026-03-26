---
uid: Deploying_a_catalog_item
reviewer: Alexander Verkest
---

# Deploying a Catalog item to your system

<div style="display: flex; align-items: center; justify-content: space-between; margin: 0 auto; max-width: 100%;">
  <div style="border: 1px solid #ccc; border-radius: 10px; padding: 10px; flex-grow: 1; background-color: #DEF7FF; margin-right: 20px; color: #000000;">
    <b>💡 TIPS TO TAKE FLIGHT</b><br>
    Prefer a visual guide? Watch <a href="xref:Adding_elements" style="color: #657AB7;">this short video</a> on how to deploy a connector from the Catalog.
  </div>
  <img src="~/images/Skye.svg" alt="Skye" style="width: 100px; flex-shrink: 0;">
</div>

To deploy an item from the Catalog (e.g., a connector or package) to your DataMiner System, make sure the following requirements are met:

- Your DataMiner System is connected to dataminer.services. See [Connecting your DataMiner System to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

- Your organization has been verified. This is necessary for dataminer.services to be able to check for which connectors your organization has acquired a license. See [Getting your organization verified](xref:CloudConnectionVerification).

- Your dataminer.services account is linked to a DataMiner user account. See [Linking your DataMiner account to your dataminer.services account](xref:Linking_your_DataMiner_and_dataminer_services_account).

> [!NOTE]
>
> - From DataMiner 10.4.10/10.5.0 onwards<!--RN 40291-->, when you install a connector for the first time by deploying it from the Catalog, it will automatically be promoted to the production version. However, when you later deploy a new version of the same connector and want it to be set as the production version, you will need to manually [promote this protocol version](xref:Promoting_a_protocol_version_to_production_version). Prior to DataMiner 10.4.10/10.5.0, deploying a connector from the Catalog will never change the production version for that connector in the DataMiner System.
> - When you deploy a low-code app, the version in the package becomes the active app version. For detailed information, see [Low-code app deployment behavior](#low-code-app-deployment-behavior).

> [!TIP]
> In the Admin app, you can get an overview of all the deployments that have been done to a DMS. See [Viewing information on deployments](xref:Viewing_info_on_deployments).

## Deploying a Catalog item to your system with the UI

1. Look up the item in the Catalog. See [Looking up an item in the Catalog](xref:Looking_up_an_item_in_the_catalog).

   ![Microsoft Platform](~/dataminer/images/Catalog_Microsoft.png)

1. If you cannot see the *Deploy* button yet, go to the *Versions* tab and expand the version you want to deploy.

   If you do see a *Deploy* button immediately, but you want to deploy a specific version, also go to the *Versions* tab and expand the version you want to deploy.

   > [!NOTE]
   >
   > - If your organization does not have a license for the displayed item, the *Deploy trial* button will be displayed instead, which you can use to test the item in a staging environment. By default, the trial will be registered for a 3-month period. Towards the end of this period, Skyline will contact you to check if you were able to validate the trial and if you are interested in acquiring the connector going forward.
   > - To get a license to deploy the item in a Production system, contact <licensing@skyline.be>.<!-- RN 39205 -->
   > - To be able to deploy an item to your DataMiner System, the DataMiner user profile linked to your dataminer.services user profile has to have the following permissions:
   >   - [Modules > System configuration > Agents > Install App packages](xref:DataMiner_user_permissions#modules--system-configuration--agents--install-app-packages).
   >   - [Modules > Automation > Execute](xref:DataMiner_user_permissions#modules--automation--execute).

1. Click the *Deploy* button.

   ![Deploy connector](~/dataminer/images/Catalog_Deploy_Account_Not_Linked.png)

    > [!NOTE]
    > If your account is not linked to one of the selected DataMiner systems, a message will be displayed indicating which systems the account is not linked to yet. Clicking the name of the DataMiner System will open a new tab to link your account. After the account linking process is complete, navigating back to the original tab will revalidate the account linking.

1. Select the target DataMiner System.

   The item will be pushed to the DataMiner System. Next to the *Deploy* button, the status of the deployment will be shown.<!-- RN 42131 -->

## Deploying a Catalog item to your system with the API

The *deploy* API call allows you to deploy a Catalog item to a DataMiner System.

> [!NOTE]
> The API calls are authenticated using [organization keys](xref:Managing_dataminer_services_keys#organization-keys). Make sure you use a key that has the *Deploy a version of a Catalog item* permission and add it to the HTTP request in a header called **Ocp-Apim-Subscription-Key**. The API calls use the following rate limiting policy:
>
> - Partition key: IP address or host name of connection
> - Burst limit: 100 requests
> - Long-term sustained request rate: 1 request every 36 seconds (100 request per hour)
> - No queueing for extra requests beyond the token bucket

### API Definition

For a complete definition of the API, go to [Key Catalog API Swagger](https://catalogapi-prod.cca-prod.aks.westeurope.dataminer.services/swagger/index.html?urls.primaryName=Key+Catalog+API+v2.0).

This page also provides a quick way to execute the call: Expand the "/api/key-catalog/v2-0/catalogs/{catalogId}/versions/{versionId}/deploy" item, and click the *Try it out* button.

> [!IMPORTANT]
> Clicking the *Try it out* button will execute the download call on the production Catalog.

The [Swagger.json](https://catalogapi-prod.cca-prod.aks.westeurope.dataminer.services/swagger/key-catalog_2.0/swagger.json) can be used by e.g., [Swagger CodeGen](https://swagger.io/docs/open-source-tools/swagger-codegen/) or [AutoRest](https://azure.github.io/autorest/generate/) to generate client code.

### HTTP method

GET

### Route parameters

- Route parameter "catalogId" is the ID of the Catalog item that will be deployed, which is the same as the ID used to [register the Catalog item](xref:Register_Catalog_Item#registering-a-catalog-item-with-the-api). This must be a valid GUID.

  To obtain this ID for an existing Catalog item, navigate to its details page in the [Catalog](https://catalog.dataminer.services/). The ID is the last part of the URL.

- Route parameter "versionId" is the version number of the Catalog item that will be deployed.

- Route parameter "coordinationId" is the ID of the DataMiner System to deploy to.

  To obtain this ID for an existing DataMiner System, navigate to its details page in the [Admin app](https://admin.dataminer.services/). The ID is the last GUID of the URL.

## Low-code app deployment behavior

<!-- reviewer: Stephen Lanszweert -->

When you deploy a low-code app from the Catalog, using either the UI or the API as detailed above, the **version of the app in the package will always become the active version** in the system, even if a more recent version of the same app already exists in the system.

Up to 15 versions of one low-code app can exist in a system at the same time. At any given time, at most two of these versions can be active: a draft version, which is still being worked on, and a published version, i.e., a released version of the app.

If you deploy a package containing a published app version, that version will always become the new active published version. If you deploy a package containing a draft version, this draft version will become the current active draft version of the app, but the active published version, if available, will not change.

Some example scenarios:

| Existing app | Deployed version | Deployment result |
|--|--|--|
| – | v5 published | Version 5 from the package is added as the current active published version. |
| – | v5 draft | Version 5 from the package is added as the current active draft version. |
| v5 published | v6 published | Version 6 from the package is the new active published version. |
| v5 published | v6 draft | Version 5 remains the active published version. Version 6 from the package becomes the active draft version. |
| v5 draft | v6 published | Version 5 remains the current active draft version. Version 6 becomes the new active published version. |
| v5 draft | v6 draft | Version 6 becomes the new active draft version. |
| v5 draft | v4 draft | Version 4 from the package becomes the new active draft version. |
| v16–v25 published | v5 published | Version 5 from the package becomes the new active published version. All other versions remain. |
| v16–v25 published | v5 draft | Version 5 from the package is the new active draft version. All other versions remain. |
| v5 published | v5 published | The existing version 5 is replaced by version 5 from the package, which remains the active published version. |
| v5 published | v4 draft | Version 5 remains the active published version. Version 4 from the package is the new active draft version. |
| v5 published | v5 draft | Version 5 from the package is added as the active draft version, replacing the existing published version. |
| v16-v30 published | v6 published | Version 6 from the package is added as the active published version. If a new draft is created, it will start from version 6, but the resulting draft will be version 31. As no more than 15 versions can exist in the system at the same time, the oldest non-active version will be deleted. |

> [!TIP]
> See also: [Retrieving an earlier app version](xref:LowCodeApps_earlier_version)
