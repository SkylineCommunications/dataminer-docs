---
uid: Ad_hoc_Creation
---

# Creating an ad hoc data source

## Prerequisites

To create ad hoc data sources, we recommend using [DIS](xref:Overall_concept_of_the_DataMiner_Integration_Studio) with Visual Studio . DIS provides a template to start creating a data source and simplifies deployment, including potential dependencies. The source code of ad hoc data sources can also be viewed and edited in the Automation module within Cube, but this is not meant for maintaining extensions.

In order to create a GQI ad hoc data source, you need to reference the [GQI extension API](xref:GQI_Extension_API).

## Data source creation

### Creating a new ad hoc data source project

1. Create a new project in Visual Studio.

1. Search for the *DataMiner Ad Hoc Data Source Solution* template.

1. Specify a name for the solution.

1. Under *Additional information*, fill in the name and author for the data source, and select the [lifecycle interfaces](xref:Ad_hoc_Life_cycle#detailed-lifecycle-overview) you want to implement.

1. Click *Create*.

   The template will create a C# class file with the name of the data source. The core of an ad hoc data source is a class that implements the [*IGQIDataSource* interface](xref:GQI_IGQIDataSource). Any class within the project that implements this interface is discovered by GQI and used as a data source.

   Above the class, the *GQIMetaData* attribute is set. This attribute sets the display name of the data source in the Dashboards app or Low-Code Apps. If this attribute is not present, the name of the class is displayed instead, which may not be very user-friendly.

> [!TIP]
> For a full example of an ad hoc data source implementation, see [Forwarding dummy data to the GQI](xref:Forwarding_dummy_data_to_GQI).

### Deploying the data source

The data source can be deployed similar to how you deploy an automation script using DIS. For more information, see [Publishing with DIS](xref:XML_editor#publish).

### Using the data source

1. In the Dashboards app or Low-Code Apps, configure a query and select the data source *Get ad hoc data* or *Get custom data*, depending on your DataMiner version.

1. In the *Data source* dropdown box, select the name of your ad hoc data source.

Depending on how the script is configured, there can be additional configuration possibilities. You can for instance use the [*IGQIInputArguments* interface](xref:GQI_IGQIInputArguments) in the script to define that a specific argument is required, for instance to filter the displayed data.

> [!IMPORTANT]
> Ad hoc data sources are identified by a combination of their script name, library name, and class name. Changing any of these values will cause existing queries to stop working, because they will no longer be able to find the script based on the identifier they are using.

> [!TIP]
> See also: [Best practices for developing GQI extensions](xref:GQI_Extensions_Best_Practices).
