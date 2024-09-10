---
uid: Tutorial_Register_Catalog_Item
---

# Registering a new connector in the Catalog

This tutorial demonstrates how to add a new Catalog item using the [Catalog API](xref:Register_Catalog_Item).  
We will be registering our own version of the following example [connector](https://github.com/SkylineCommunications/SLC-C-Example_Rates-Custom).  

For ease of use we will be using [Postman](https://www.postman.com/) to execute the register API calls. Feel free to integrate them afterwards in your workflow, e.g by using them in a github action.

## Prerequisites

- Organization key with permission "Register catalog items".

## Overview

- [Step 1: Register Catalog item URL](#step-1-register-catalog-item-url)
- [Step 2: Authentication header](#step-2-authentication-header)
- [Step 3: Register Catalog item body](#step-3-register-catalog-item-body)
- [Step 4: Register](#step-4-register)

## Step 1: Register Catalog item URL

Add a new request with HTTP method of type **PUT** and the following URL: <https://api.dataminer.services/api/key-catalog/v1-0/catalog/register>

![Register item http url](~/user-guide/images/tutorial_catalog_registration_item_url.png)

## Step 2: Authentication header

The Catalog item register api call uses Organization key authentication, we can obtain one in the [Admin App](https://admin.dataminer.services/) on the Keys page. 
This key identifies your organization and will make sure the registration will register your Catalog item under the organization of the key you use.

> [!IMPORTANT]
> You need to have the "Owner" role in order to access/create organization keys.

Go ahead and create a new key with permission "Register catalog items".

![Organization Key](~/user-guide/images/tutorial_catalog_registration_create_org_key.png)

After creation of the key, you can copy the key and use it as value in the **Ocp-Apim-Subscription-Key** header  

![Register item http header](~/user-guide/images/tutorial_catalog_registration_urlandheaders.png)

## Step 3: Register Catalog item body

The body of the request needs to be in the **multipart/form-data** format with key of type **File** and name **file**, the value should be a `.zip` file containing the following items:

- A `README.md` file with any required image in an images folder. This `README.md` will be shown in the description tab in the Catalog.

  Copy the snippet below, changing the content as you see fit using your favorite editor and save the file as `README.md`.

  ```md
  # Example_Rates_Custom

  This is a connector that serves as example on how to integrate bit rates.

  ## About

  This Catalog item has been made available as part of the [Catalog registration tutorial](https://docs.dataminer.services/tutorials/Tutorials.html)
  ```

- A manifest.yml file describing the properties of the Catalog item.

  Copy the snippet below and change the fields as you see fit using your favorite editor.

  > [!NOTE]
  > Make sure to obtain a new GUID to uniquely store and identify the Catalog item. Navigate to [GUID generator](https://guidgenerator.com/) and create a new one using the format *hyphens* or use your own preferred method.

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

Create a zip file containing the manifest and the README and add it to the body of the request as shown below

![zip content structure](~/user-guide/images/tutorial_catalog_registration_item_zip_structure.png)

![Register item http body](~/user-guide/images/tutorial_catalog_registration_item_body.png)

## Step 4: Register

Execute the call and upon correct registration you will receive HTTP Status 200 OK and the catalog id in the body of the response.

You can now search for you Catalog item in the [Catalog](https://catalog.dataminer.services/browse) or navigate immediately to https://catalog.dataminer.services/details/{YourCatalogId}

![Registered Catalog item](~/user-guide/images/tutorial_catalog_registration_registered_item.png)

> [!NOTE]
> After the first registration, you are able to make changes to the manifest or readme.md and execute the PUT request again, it will update the registered data as long as you use the same Catalog ID.
