---
uid: Ad_hoc_Creation
---

# Creating an ad hoc data source

> [!TIP]
> If you are using [DIS](xref:Overall_concept_of_the_DataMiner_Integration_Studio) with Visual Studio 2022, you can use a template in Visual Studio to create ad hoc data sources more easily. To do so:
>
> 1. Create a new project in Visual Studio 2022.
> 1. Search for the *DataMiner Ad Hoc Data Source Solution* template.
> 1. Specify a name for the solution.
> 1. Under *Additional information*, fill in the name and author for the data source, and select the lifecycle interfaces you want to implement.
> 1. Click *Create*.

To define a new ad hoc data source:

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

Depending on how the script is configured, there can be additional configuration possibilities. You can for instance use the [*IGQIInputArguments* interface](xref:GQI_IGQIInputArguments) in the script to define that a specific argument is required, for instance to filter the displayed data.

> [!IMPORTANT]
> Ad hoc data sources are identified by a combination of their script name, library name, and class name. Changing any of these values will cause existing queries to stop working, because they will no longer be able to find the script based on the identifier they are using.

> [!TIP]
> See also: [Best practices for developing GQI extensions](xref:GQI_Extensions_Best_Practices).
