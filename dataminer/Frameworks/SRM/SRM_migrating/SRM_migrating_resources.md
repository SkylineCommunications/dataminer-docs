---
uid: SRM_migrating_resources
---

# Migrating resources

To migrate the complete resource configuration, you can use the *SRM_DiscoverResources* Automation script, which is included in the SRM framework. When you export the resource configuration with this script, an Excel file will be generated that includes all resources defined in the system as well as the resources that could potentially be created. You can then import this file to adjust the configuration of resources that are already present in the system and to create new resources.<!-- RN 23632 -->

## Exporting the resource configuration

1. In the Automation module, execute the *SRM_DiscoverResources* script.

1. Specify the following input data:

   - *Operation*: `EXPORT`

   - *File Path*: The full filename of the Excel file to which the resources should be exported (including the file extension).

   - *Input Data*: `{}`

1. Click *Execute now*.

The script will create an Excel file containing one tab per function and listing all (candidate) resources. In the exported file, the following columns are the most important:

- *Element Name*: The name of the DataMiner element that provides the resource or is a candidate for providing the resource.

- *Resource Name*: The name of the resource.

- *Create*: Indicates whether a resource has already been created (*TRUE* or *FALSE*).

- *Resource Pools*: Comma-separated list of pools containing the resource.

## Importing the resource configuration

1. Create a DataMiner backup that includes *Resource Manager objects and configuration*.

1. If you want to modify the original export, open the Excel file and modify it as necessary:

   - Set the `Create` column to *TRUE* if you want to create a new resource.

   - Add `PROPERTY: <property name>` columns to add properties.

   - Add `CAPABILITY: <capability name>` columns to add capabilities.

   - Add `CAPACITY: <capability name>` columns to add capacities.

   > [!NOTE]
   >
   > - The columns have a maximum length of 64 characters. Column names must not contain hyphens or periods.
   > - Make sure to save and close the Excel file before you continue, because it will not be possible to import the file if it is still open.

1. In the Automation module, execute the *SRM_DiscoverResources* script.

1. Specify the following input data:

   - *Operation*: `IMPORT`

   - *File Path*: The full filename of the Excel file to import.

   - *Input Data*: `{}`

     Two input data options are available, which can optionally be used. By default, these are both set to false.

     - *IsSilent*: Allows you to run the script in "silent" mode (i.e. without user interaction). In that case, it will not update resources that could cause bookings to go into quarantine state, unless *ForceUpdate* is enabled.
     - *ForceUpdate*: Forces resources updates, which may cause some bookings to go into quarantine in case the updated resources can no longer support all bookings.

     For example: `{"ForceUpdate":"false", "IsSilent":"true"}`

1. Click *Execute now*.
