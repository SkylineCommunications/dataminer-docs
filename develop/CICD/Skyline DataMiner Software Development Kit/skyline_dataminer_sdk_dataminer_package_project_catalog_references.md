---
uid: skyline_dataminer_sdk_dataminer_package_project_catalog_references
keywords: Skyline.DataMiner.Sdk, Package Project, CatalogReferences
---

# Skyline DataMiner Package Project - CatalogReferences.xml

Inside the Skyline DataMiner Package Project, under the *PackageContent* directory, you can find the *CatalogReferences.xml* file. This file is used to include artifacts from the Catalog in the package.

When this file is used, credentials will be needed to access the Catalog. See [Adding content from the Catalog](xref:skyline_dataminer_sdk_dataminer_package_project#adding-content-from-the-catalog).

The downloaded items will be stored in a cache similar to NuGet packages. To change the location of this cache, see [Changing the cache location of Catalog items](xref:skyline_dataminer_sdk_dataminer_package_project_advanced#changing-the-cache-location-of-catalog-items).

The CatalogReferences file looks like this:

```xml
<CatalogReferences xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns="http://www.skyline.be/catalogReferences">
<!--
   <CatalogReference id="guid">
      <Name>Example Catalog Item (Specific Version)</Name>
      <Selection>
         <Specific>1.0.0.1</Specific>
      </Selection>
   </CatalogReference>
   <CatalogReference id="guid">
      <Name>Example Catalog Item (Range)</Name>
      <Selection>
         <Range>1.0.0</Range>
      </Selection>
   </CatalogReference>
   <CatalogReference id="guid">
      <Name>Example Catalog Item (Range - Prerelease)</Name>
      <Selection>
         <Range allowPrerelease="true">1.0.0</Range>
      </Selection>
   </CatalogReference>
-->
</CatalogReferences>
```

## Identifier

The identifier, the **id** attribute, is the GUID that represents a Catalog item. This can be retrieved from the URL, e.g. [https://catalog.dataminer.services/details/4abcf220-c001-4ffd-bab8-559dee47088f](https://catalog.dataminer.services/details/4abcf220-c001-4ffd-bab8-559dee47088f) (Microsoft Platform).

## Name

The **Name** is meant for human readability. It is also used as the file name for the artifact. If this is empty or not present, the value from the *id* attribute will be used.

## Selection

### Specific

The *Selection.Specific* element represents a specific version that you can see in the Catalog UI.

### Range

The *Selection.Range* element specifies the range where the latest released version is added.

For more information about the range, see [Versioning of Catalog items](xref:About_the_Catalog_app#versioning-of-catalog-items).

#### allowPrerelease

In case you want prereleases as well, you can use the **allowPrerelease** attribute.

A prerelease is defined as having a dash ("-") in the version.

Versions from InstallPackages made on Jenkins are excluded from this definition as they contain a dash by default (A.B.C-CUx).
