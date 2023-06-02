---
uid: SRM_migrating_resources
---

# Migrating resources

To export and import resources, you can use the *SRM_DiscoverResources* Automation script.

## Exporting resources

1. In the Automation module, execute the *SRM_DiscoverResources* script.

1. Specify the following input data:

   - *Operation*: `EXPORT`

   - *File Path*: The full filename of the Excel file to which the resources should be exported.

   - *Input Data*: `{}`

1. Click *Execute now*.

The script will create an Excel file containing one tab per function and listing all (candidate) resources. In the exported file, the following columns are the most important:

- *Element Name*: The name of the DataMiner element that provides the resource or is a candidate for providing the resource.

- *Resource Name*: The name of the resource.

- *Create*: Indicates whether a resource has already been created (*TRUE* or *FALSE*).

- *Resource Pools*: Comma-separated list of pools containing the resource.

## Importing resources

1. Create a DataMiner backup that includes *Resource Manager objects and configuration*.

1. If you want to modify the original export, open the Excel file and modify it as necessary:

   - Set the `Create` column to *TRUE* if you want to create a new resource.

   - Add `PROPERTY: <property name>` columns to add properties.

   - Add `CAPABILITY: <capability name>` columns to add capabilities.

   - Add `CAPACITY: <capability name>` columns to add capacities.

1. In the Automation module, execute the *SRM_DiscoverResources* script.

1. Specify the following input data:

   - *Operation*: `IMPORT`

   - *File Path*: The full filename of the Excel file to import.

   - *Input Data*: `{}`

1. Click *Execute now*.
