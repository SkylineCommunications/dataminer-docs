---
uid: CO_Creation
---

# Creating a custom operator

## Prerequisites

To create custom operators, we recommend using [DIS](xref:Overall_concept_of_the_DataMiner_Integration_Studio) with Visual Studio. DIS does not provide a direct template to create a custom operator; however, the template for an ad hoc data source can be reused. The source code of custom operators can also be viewed and edited in the Automation module within Cube, but this is not meant for maintaining extensions.

In order to create a GQI custom operator, you need to reference the [GQI extension API](xref:GQI_Extension_API).

## Operator creation

### Creating a new custom operator source project

1. Create a new project in Visual Studio.

1. Search for the *DataMiner Ad Hoc Data Source Solution* template.

1. Specify a name for the solution.

1. Under *Additional information*, fill in the name and author for the operator, and select the lifecycle interfaces you want to implement.

1. Click *Create*.

   The template creates a C# class file with the name of the data source.

1. To alter the file to be a custom operator, find the class that currently implements the [*IGQIDataSource* interface](xref:GQI_IGQIDataSource) and instead have it implement the [*IGQIOperator* interface](xref:GQI_IGQIOperator).

   Any class within the project that implements this interface will be discovered by GQI and used as an operator.

   Above the class, the *GQIMetaData* attribute is set. This attribute sets the display name of the operator in the Dashboards app or Low-Code Apps. If this attribute is not present, the name of the class is displayed instead, which may not be very user-friendly.

> [!TIP]
> For a full example of a custom operator implementation, see [Optimizing your custom operator](xref:Custom_Operator_Tutorial).

### Deploying the custom operator

The custom operator can be deployed similar to how you deploy an automation script using DIS. For more information, see [Publishing with DIS](xref:XML_editor#publish).

### Using the custom operator

1. In the Dashboards app or Low-Code Apps, when selecting an operator, select *Apply custom operator*.

1. In the *Operator* dropdown box, select the name of your custom operator.

Depending on how the script is configured, there can be additional configuration possibilities. You can for instance use the [*IGQIInputArguments* interface](xref:GQI_IGQIInputArguments) in the script to define that a specific argument is required.

> [!IMPORTANT]
> Custom operators are identified by a combination of their script name, library name, and class name. Changing any of these values will cause existing queries to stop working, because they will no longer be able to find the script based on the identifier they are using.

> [!TIP]
> See also: [Best practices for developing GQI extensions](xref:GQI_Extensions_Best_Practices).
