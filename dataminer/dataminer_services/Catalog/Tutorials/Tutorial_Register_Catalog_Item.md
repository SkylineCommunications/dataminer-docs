---
uid: Tutorial_Register_Catalog_Item
reviewer: Alexander Verkest
---

# Registering a new connector in the Catalog

This tutorial demonstrates how to add a new Catalog item using the [Catalog API](xref:Register_Catalog_Item), using an [example connector](https://github.com/SkylineCommunications/SLC-C-Example_Rates-Custom).

For ease of use, [Postman](https://www.postman.com/) will be used to execute the register API calls. You can also integrate these into your own workflow afterwards, e.g by using them in a GitHub action.

While the tutorial uses the example of a connector, registering a different type of Catalog item is very similar.

Expected duration: 10 minutes

> [!NOTE]
> If you would prefer not to use Postman and HTTPS directly, try out our [platform-independent](xref:Platform_independent_CICD) tool support or check out our IaC (Infrastructure as Code) solutions using the [Skyline DataMiner Software Development Kit](xref:skyline_dataminer_sdk), which has publication to the Catalog directly integrated.
>
> If you are interested in setting up CI/CD to handle registration automatically, take a look at the [CI/CD tutorials](xref:CICD_Tutorials).

## Prerequisites

- An [organization key](xref:Managing_dataminer_services_keys#organization-keys) or account with the *Owner* role in order to access/create organization keys.

  > [!TIP]
  > See [Changing the role of a dataminer.services user](xref:Changing_the_role_of_a_dataminer_services_user)

## Overview

- [Step 1: Register the Catalog item URL](#step-1-register-the-catalog-item-url)
- [Step 2: Configure the authentication header](#step-2-configure-the-authentication-header)
- [Step 3: Register the Catalog item body](#step-3-register-the-catalog-item-body)
- [Step 4: Register the Catalog item](#step-4-register-the-catalog-item)

## Step 1: Register the Catalog item URL

Add a new request using an HTTP method of type **PUT** and the following URL: `https://api.dataminer.services/api/key-catalog/v2-0/catalogs/register`

![Register item HTTP URL](~/dataminer/images/tutorial_catalog_registration_item_url.png)

## Step 2: Configure the authentication header

The Catalog item register API call is authenticated using an [organization key](xref:Managing_dataminer_services_keys#organization-keys), which you can obtain in the [Admin App](https://admin.dataminer.services/). This key identifies your organization and will make sure your Catalog item is registered under the correct organization.

> [!IMPORTANT]
> You need to have the *Owner* role in order to access/create organization keys. See [Changing the role of a dataminer.services user](xref:Changing_the_role_of_a_dataminer_services_user) for information on how to change a role for a user.

1. In the [Admin app](https://admin.dataminer.services/), under *Organization* in the sidebar on the left, select the *Keys* page.

1. At the top of the page, click *New Key*.

1. Configure the key with a label of your choice and the permission *Register catalog items*.

   ![Organization Key](~/dataminer/images/tutorial_catalog_registration_create_org_key.png)

1. Copy the key and use it as the value in the **Ocp-Apim-Subscription-Key** header.

   ![Register item HTTP header](~/dataminer/images/tutorial_catalog_registration_urlandheaders.png)

## Step 3: Register the Catalog item body

1. Create a .zip file containing the following items:

   ![zip content structure](~/dataminer/images/tutorial_catalog_registration_item_zip_structure.png)

   - A *README.md* file. This *README.md* will be shown in the description tab in the Catalog.

     Copy the snippet below, changing the content as you see fit using your favorite editor, and save the file as `README.md`.

     ```md
     # Example_Rates_Custom

     This is a connector that serves as an example for how to integrate bit rates.

     ## About

     This Catalog item has been made available as part of the [Catalog registration tutorial](https://docs.dataminer.services/tutorials/Tutorials.html)
     ```

     > [!TIP]
     > See also: [Best practices when documenting Catalog items](xref:Best_Practices_When_Documenting_Catalog_Items).

   - Optionally, if you want to use images in the readme, an images folder containing those images.

   - A *manifest.yml* file describing the properties of the Catalog item.

     Copy the snippet below, changing the fields as you see fit using your favorite editor, and save the file as `manifest.yml`.

     > [!NOTE]
     > Make sure to obtain a new GUID to uniquely store and identify the Catalog item. To do so, you can for instance navigate to [GUID generator](https://guidgenerator.com/) and create a new GUID using the format *hyphens*, or you can use your own preferred method.

     ```yml
     type: 'connector'

     id: '1742495c-9231-4eeb-a56e-1fec8189246e'

     title: 'My Catalog Registration Example'

     short_description: 'Example connector showing how to calculate bitrates and other rates on any changing numeric data.'

     source_code_url: 'https://github.com/SkylineCommunications/SLC-C-Example_Rates-Custom'

     owners:
       - name: 'john doe'
         email: 'john.doe@skyline.be'
     tags:
       - 'example'
     ```

1. Add the zip file as the value of the body of the request as shown below.

   Make sure your .zip file does not exceed 250 MB.

   The body of the request needs to be in the **multipart/form-data** format with a key of type **File** with the name **file**.

   ![Register item http body](~/dataminer/images/tutorial_catalog_registration_item_body.png)

## Step 4: Register the Catalog item

Execute the call.

When the item has been registered correctly, you will receive an *HTTP Status 200 OK* response, with the Catalog ID in the body of the response.

You can now search for the Catalog item in the [Catalog](https://catalog.dataminer.services/browse) or navigate immediately to `https://catalog.dataminer.services/details/{YourCatalogId}`.

![Registered Catalog item](~/dataminer/images/tutorial_catalog_registration_registered_item.png)

> [!NOTE]
> After the first registration, you can make changes to the manifest or README.md and execute the PUT request again. This will update the registered data as long as you use the same Catalog ID.
