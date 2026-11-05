---
uid: publish_to_catalog
---

# Publishing items in the Catalog

The [Catalog](https://catalog.dataminer.services/) allows users to quickly look up, download, and deploy various DataMiner-related items.

This platform is constantly getting improved. At present, several workarounds are still needed to get certain items to show up in the Catalog. Below, you can find more information about how to publish specific kinds of items.

> [!TIP]
> See also: [About the Catalog app](xref:About_the_Catalog_app)

> [!NOTE]
> The procedures below are meant for Skyline employees and contain links that are only accessible to Skyline employees.

## Publishing connectors

Connectors (also known as protocols) are XML files and assemblies that are packaged into .dmprotocol files. The source code of these is currently hosted on GitHub under the [Skyline Communications organization](https://github.com/SkylineCommunications). GitHub workflows are used to (pre-)release new versions in the Catalog.

Perform the following steps to release a connector version:

1. Make sure the following prerequisites are available:

   - [Visual Studio](https://visualstudio.microsoft.com/downloads/)

   - [Git](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git)

   - [DIS](xref:Installing_and_configuring_DataMiner_Integration_Studio)

1. Register the connector in the Catalog (note that for all non-connector items, registration happens automatically from the GitHub workflows, but for connectors, a pre-registration is required):

   1. Register the connector using the [Connector Admin Tool](https://aka.dataminer.services/Connector_Admin_Tool).

      If the new connector belongs to a new vendor, you can also add the vendor on the *Add New Connector* page.

   1. Copy the [Integration ID](xref:Protocol.IntegrationID), the [Vendor OID](xref:Protocol.VendorOID), and the [Device OID](xref:Protocol.DeviceOID) received in the previous step and paste these within the appropriate connector XML tags.

   1. Look up the newly registered connector in the Catalog and copy the GUID from the URL.

      A new connector will always initially be registered as private, so you need to log in to access it. When applicable, the connector can be [made public](xref:Change_Catalog_Publishing_State) once a first release or pre-release is made.

   1. Make sure the root folder of the repository contains a *catalog.yml* file, add an `id` property to it, and paste the catalog GUID as its value, for example:

      ```yaml
      id: PASTE_CATALOG_GUID_HERE
      ```

      This configuration is required to make sure the release flow succeeds.

1. Add the *DataMiner Connector* workflow to the repository.

   The workflow will automatically run, and a *auto-generated-catalog.yml* file will be created in the *.githubtocatalog* folder within the connector repository. This file should never be edited manually.

   Optionally, you can use this file as an example to extend the *catalog.yml* you created during the registration step with extra properties. Here are a few examples where this could be useful:

      - The Catalog item needs to have a different name than defined within the *protocol.xml* file. This can, for example, happen when a special character that is not allowed within the `Protocol.Name` tag of the *Protocol.xml* is needed as the Catalog item name.

      - Owners need to be specified for the connector.

      - Extra tags need to be associated with the connector.

      - ...

1. Release or pre-release using the GitHub release feature.

## Publishing DataMiner app packages

DataMiner app packages, i.e., .dmapp files, can contain any other artifacts, including automation scripts, other app packages, and companion files. The source code of these is currently hosted on GitHub under the [Skyline Communications organization](https://github.com/SkylineCommunications).

The packages will automatically be registered as private Catalog items via GitHub workflows once a release or pre-release is made. When applicable, you can make them public directly within the Catalog. For more information, see [CI/CD using GitHub for non-connector items](xref:CICD_on_GitHub_getting_started#cicd-using-github-for-non-connector-items).
