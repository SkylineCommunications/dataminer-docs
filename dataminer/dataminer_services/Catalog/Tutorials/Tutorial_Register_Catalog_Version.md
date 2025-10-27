---
uid: Tutorial_Register_Catalog_Version
reviewer: Alexander Verkest
---

# Registering a new version of a connector in the Catalog

This tutorial demonstrates how to add a new version to a Catalog item using the [Catalog API](xref:Register_Catalog_Item). It builds on the example from the tutorial [Registering a new connector in the Catalog](xref:Tutorial_Register_Catalog_Item), so unless you already know how to register a new Catalog item and have done so already, we recommend that you follow that tutorial first.

While the tutorial uses the example of a connector, registering a new version for a different type of Catalog item is very similar.

Expected duration: 15 minutes

> [!NOTE]
> If you would prefer not to use Postman and HTTPS directly, try out our [platform-independent](xref:Platform_independent_CICD) tool support or check out our IaC (Infrastructure as Code) solutions using the [Skyline DataMiner Software Development Kit](xref:skyline_dataminer_sdk), which has publication to the Catalog directly integrated.
>
> If you are interested in setting up CI/CD to handle registration automatically, take a look at the [CI/CD tutorials](xref:CICD_Tutorials).

## Prerequisites

- An [organization key](xref:Managing_dataminer_services_keys#organization-keys) or account with the *Owner* role in order to access/create organization keys.

  > [!TIP]
  > See [Changing the role of a dataminer.services user](xref:Changing_the_role_of_a_dataminer_services_user)

- A registered Catalog item.

  > [!TIP]
  > For an example of how to register an item, see [Registering a new connector in the Catalog](xref:Tutorial_Register_Catalog_Item).

- [Skyline.DataMiner.CICD.Tools.Packager Nuget](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Tools.Packager#readme-body-tab).

## Overview

- [Step 1: Register the Catalog version URL](#step-1-register-the-catalog-version-url)
- [Step 2: Configure the authentication header](#step-2-configure-the-authentication-header)
- [Step 3: Register the Catalog version body](#step-3-register-the-catalog-version-body)
- [Step 4: Register the version](#step-4-register-the-version)

## Step 1: Register the Catalog version URL

To register a new version of a connector, you will need to use the register version call from the Catalog API:

1. Create a new HTTP request using the POST HTTP method and the URL `https://api.dataminer.services/api/key-catalog/v2-0/catalogs/{catalogId}/register/version`.

1. As the *catalogId* route parameter, fill in the Catalog ID of the connector.

   > [!NOTE]
   > If you followed the [previous tutorial](xref:Tutorial_Register_Catalog_Item), this is the ID that was returned in the last step. If you are registering a new version for a different Catalog item, you can find it by navigating to its details page in the [Catalog](https://catalog.dataminer.services/) and checking the last part of the URL.

For example:

![Register version HTTP URL](~/dataminer/images/tutorial_catalog_registration_version_url.png)

## Step 2: Configure the authentication header

The Catalog version register API call is authenticated using an [organization key](xref:Managing_dataminer_services_keys#organization-keys), which you can obtain in the [Admin App](https://admin.dataminer.services/). This key identifies your organization and will make sure your Catalog item is registered under the correct organization.

> [!IMPORTANT]
> You need to have the *Owner* role in order to access/create organization keys. See [Changing the role of a dataminer.services user](xref:Changing_the_role_of_a_dataminer_services_user) for information on how to change a role for a user.

1. In the [Admin app](https://admin.dataminer.services/), under *Organization* in the sidebar on the left, select the *Keys* page.

1. At the top of the page, click *New Key*.

1. Configure the key with a label of your choice and the permission *Register catalog items*.

   ![Organization Key](~/dataminer/images/tutorial_catalog_registration_create_org_key.png)

1. Copy the key and use it as the value in the **Ocp-Apim-Subscription-Key** header.

   ![Register version HTTP header](~/dataminer/images/tutorial_catalog_registration_version_headers.png)

## Step 3: Register the Catalog version body

The body of the version registration request requires a file containing the connector. For this, you will be using the [Skyline.DataMiner.CICD.Tools.Packager NuGet](https://www.nuget.org/packages/Skyline.DataMiner.CICD.Tools.Packager#readme-body-tab) to create a .dmprotocol package.

1. Navigate to [Example Rates connector](https://github.com/SkylineCommunications/SLC-C-Example_Rates-Custom) and download the connector.

1. Open a terminal window and run the command below to install the packager.

   ```powershell
   dotnet tool install --global Skyline.DataMiner.CICD.Tools.Packager --version 2.0.3
   ```

1. Run the following command to create a .dmprotocol package, adapting the directory paths as needed.

   ```powershell
   dataminer-package-create dmprotocol "C:\Tutorials\Catalog Registration\SLC-C-Example_Rates-Custom-1.0.1.X" --name catalog_registration_tutorial --output "C:\Tutorials\Catalog Registration\Packages"
   ```

   In this example command, the first version of the [Example Rates connector](https://github.com/SkylineCommunications/SLC-C-Example_Rates-Custom) is registered.

1. Add the following to the **multipart/form-data** body of the request:

   - The *dmprotocol* file you created earlier in a key of type **File** with name **file**.
   - The **version number** in a key of type **Text** with name **versionNumber**.
   - The **version description** in a key of type **Text** with name **versionDescription**.

![Register version http body](~/dataminer/images/tutorial_catalog_registration_version_body.png)

## Step 4: Register the version

Execute the call.

When the item has been registered correctly, you will receive an *HTTP Status 200 OK* response, with the Catalog ID and artifact ID in the body of the response.

In the Catalog, you will now be able to see the version you registered in the **versions** tab for the item.

![Registered version](~/dataminer/images/tutorial_catalog_registration_registered_version.png)
