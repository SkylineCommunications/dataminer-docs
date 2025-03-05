---
uid: skyline_dataminer_sdk_dataminer_package_project_catalog_references
keywords: Skyline.DataMiner.Sdk, Package Project, CatalogReferences
---

# Skyline DataMiner Package Project - CatalogReferences.xml

Inside the Skyline DataMiner Package Project, you can find the CatalogReferences.xml file. This file is being used to include artifacts from the Catalog in the package.

> [!NOTE]
> When using the CatalogReferences, credentials are needed to access the Catalog. More information can be found on [Adding content from the Catalog](xref:skyline_dataminer_sdk_dataminer_package_project#adding-content-from-the-catalog).

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

The identifier, the **id** attribute, is the GUID that represents a Catalog item. This can be retrieved from the URL, e.g.: [https://catalog.dataminer.services/details/4abcf220-c001-4ffd-bab8-559dee47088f](https://catalog.dataminer.services/details/4abcf220-c001-4ffd-bab8-559dee47088f) (Microsoft Platform)

## Name

The **Name** is for human readability. It is also used for the filename for the artifact. If this is empty or not present, the **id** will be used.

## Selection

### Specific

This represents a specifc version that you can see on the Catalog UI.

### Range

Specifies a range to take the latest released version.

More information about the range can be found on [versioning of catalog items](xref:About_the_Catalog_module#versioning-of-catalog-items).

In case you want prereleases as well, you can use the **allowPrerelease** attribute.

A prerelease is defined as having a '-' (dash) in the version.
