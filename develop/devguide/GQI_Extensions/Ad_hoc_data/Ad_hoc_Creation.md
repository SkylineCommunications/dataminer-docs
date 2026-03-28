---
uid: Ad_hoc_Creation
---

# Creating an ad hoc data source

## Prerequisites

It is advised to use [DIS](xref:Overall_concept_of_the_DataMiner_Integration_Studio) with Visual Studio to create ad hoc data sources. DIS provides a template to start creating a data source and simplifies deployment, including potential dependencies.
The source code of ad hoc data sources can also be viewed and edited in the automation module within Cube, but this is not meant for maintaining extensions.

## API Reference

To create an ad hoc data source, it is required to have a reference to the API. The API is available in two forms:

- The `Skyline.DataMiner.Core.GQI` NuGet package
    - Requires DIS.
    - Only available on the GQI DxM from DataMiner web version 10.6.6 onward.
    - Supports new features on older DataMiner server versions.
    - Namespace: `Skyline.DataMiner.Core.GQI`.

- The legacy API in the `Skyline.DataMiner.Files.SLAnalyticsTypes` NuGet package (`SLAnalyticsTypes.dll` in DataMiner)
    - Requires a newer DataMiner server version for new features.
    - Namspace: `Skyline.DataMiner.Analytics.GenericInterface`.

> [!IMPORTANT]
> When using the DIS template, for compatibilty reasons, the legacy API is added by default.
> To use the Core.GQI NuGet, it must be installed manually and the legacy API needs to be removed.

> [!NOTE]
> It is possible to combine both APIs within extension libraries and within extensions.
> If a data source is implemented with both the Core.GQI package and the legacy API, GQI uses the Core.GQI implementation when it is supported.

> [!IMPORTANT]
> From web version 10.6.6, all new API features will only be available within the GQI NuGet package.
> Therefore, the GQI NuGet package should be preferred over the legacy API whenever possible.

## Data source creation

### [Using DIS and the Ad Hoc Data Source template](#tab/tabid-1)

#### Creating a new ad hoc data source project

1. Create a new project in Visual Studio.

1. Search for the *DataMiner Ad Hoc Data Source Solution* template.

1. Specify a name for the solution.

1. Under *Additional information*, fill in the name and author for the data source, and select the lifecycle interfaces you want to implement.

1. Click *Create*.

#### Exploring the data source

The template creates a C# class file with the name of the data source.
The core of an ad hoc data source is a class that implements the [*IGQIDataSource* interface](xref:GQI_IGQIDataSource).
Any class within the project that implements this interface is discovered by GQI and used as a data source.

Above the class, the *GQIMetaData* attribute is set. This attribute sets the display name of the data source in the Dashboards app or Low-Code Apps. If this attribute is not present, the name of the class is displayed instead, which may not be very user-friendly.

(See [Example ad hoc data script](xref:Forwarding_dummy_data_to_GQI) for a full example of an ad hoc data source implementation):

#### Deploying the data source

The data source can be deployed in the same way as automation scripts with DIS. Next to the C# file, the template creates an automation XML file. When opening this file in Visual Studio with DIS, a publish button appears in the top left. Pressing this button and connecting to the DataMiner Agent automatically deploys the data source on the system.

More information about publishing with DIS can be found [here](xref:XML_editor#publish).

#### Using the data source

1. In the Dashboards app or Low-Code Apps, configure a query and select the data source *Get ad hoc data* or *Get custom data*, depending on your DataMiner version.

1. In the *Data source* dropdown box, select the name of your ad hoc data source.

### [Using Cube](#tab/tabid-2)

1. In the Automation app, add a script containing a new class that implements the [*IGQIDataSource* interface](xref:GQI_IGQIDataSource).

   > [!NOTE]
   > All object types needed to create an ad hoc data source can be found within *SLAnalyticsTypes.dll*, which is located in the folder `C:\Skyline DataMiner\Files`.

1. Above the class, add the *GQIMetaData* attribute in order to configure the name of the data source as displayed in the Dashboards app or Low-Code Apps.

   For example (see [Example ad hoc data script](xref:Forwarding_dummy_data_to_GQI) for a full example):

   ```csharp
   using Skyline.DataMiner.Analytics.GenericInterface;

   [GQIMetaData(Name = "People")]
   public class MyDataSource : IGQIDataSource
   {
   ...
   }
   ```

   > [!NOTE]
   > This is the name that will be shown to the user when they select the data in the Dashboards app or Low-Code Apps. If you do not configure this name, the name of the class is displayed instead, which may not be very user-friendly.

1. Compile the script as a library (see [Compiling a C# code block as a library](xref:Compiling_a_CSharp_code_block_as_a_library)). You can use the same name as defined in the *GQIMetaData* attribute, or a different name. If there are different data sources for which the same name is defined in the *GQIMetaData* attribute, the library name is appended to the metadata name.

1. Validate and save the script. It is important that you do this after you have compiled the script as a library, as otherwise the compiler will detect errors.

1. In the Dashboards app or Low-Code Apps, configure a query and select the data source *Get ad hoc data* or *Get custom data*, depending on your DataMiner version.

1. In the *Data source* dropdown box, select the name of your ad hoc data source.

***

Depending on how the script is configured, there can be additional configuration possibilities. You can for instance use the [*IGQIInputArguments* interface](xref:GQI_IGQIInputArguments) in the script to define that a specific argument is required, for instance to filter the displayed data.

> [!IMPORTANT]
> Ad hoc data sources are identified by a combination of their script name, library name, and class name. Changing any of these values will cause existing queries to stop working, because they will no longer be able to find the script based on the identifier they are using.

> [!TIP]
> See also: [Best practices for developing GQI extensions](xref:GQI_Extensions_Best_Practices).
