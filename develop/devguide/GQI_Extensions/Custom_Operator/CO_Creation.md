---
uid: CO_Creation
---

# Creating a custom operator

## Prerequisites

It is advised to use [DIS](xref:Overall_concept_of_the_DataMiner_Integration_Studio) with Visual Studio to create custom operators. DIS does not provide a direct template to create a custom operator. Instead, the template for an ad hoc data source can be reused.
The source code of custom operators can also be viewed and edited in the automation module within Cube, but this is not meant for maintaining extensions.

In order to create a GQI custom operator, you need to reference the [GQI extension API](xref:GQI_Extension_API).

## Operator creation

### [Using DIS and the Ad Hoc Data Source template](#tab/tabid-1)

1. Create a new project in Visual Studio.

1. Search for the *DataMiner Ad Hoc Data Source Solution* template.

1. Specify a name for the solution.

1. Under *Additional information*, fill in the name and author for the operator, and select the lifecycle interfaces you want to implement.

1. Click *Create*.

#### Altering to be a custom operator

The template creates a C# class file with the name of the data source.
To alter it to be a custom operator, find the class that currently implements the [*IGQIDataSource* interface](xref:GQI_IGQIDataSource) and instead have it implement the [*IGQIOperator* interface](xref:GQI_IGQIOperator).
Any class within the project that implements this interface is discovered by GQI and used as an operator.

Above the class, the *GQIMetaData* attribute is set. This attribute sets the display name of the operator in the Dashboards app or Low-Code Apps. If this attribute is not present, the name of the class is displayed instead, which may not be very user-friendly.

(See [Example custom operator](xref:Custom_Operator_Tutorial) for a full example of a custom operator implementation)

#### Deploying the custom operator

The custom operator can be deployed similar to deploying automation scripts using DIS.
For more information, see [Publishing with DIS](xref:XML_editor#publish).

#### Using the custom operator

1. In the Dashboards app or Low-Code Apps, when selecting an operator, select *Apply custom operator*.

1. In the *Operator* dropdown box, select the name of your custom operator.

### [Using Cube](#tab/tabid-2)

1. In the Automation app, add a script containing a new class that implements either the [*IGQIRowOperator*](xref:GQI_IGQIRowOperator), [*IGQIColumnOperator*](xref:GQI_IGQIColumnOperator), or [*IGQIOptimizableOperator*] interface.

   > [!NOTE]
   > All object types needed to create a custom operator can be found within *SLAnalyticsTypes.dll*, which is located in the folder `C:\Skyline DataMiner\Files`.

1. Above the class, add the *GQIMetaData* attribute in order to configure the name of the operator as displayed in the Dashboards app or Low-Code Apps.

   For example (see [Example custom operator](xref:Creating_Minus_Operator) for a full example):

   ```csharp
   using Skyline.DataMiner.Analytics.GenericInterface;

   [GQIMetaData(Name = "Minus operator")]
   public class MyCustomOperator : IGQIColumnOperator, IGQIRowOperator
   {
   ...
   }
   ```

   > [!NOTE]
   > This is the name that will be shown to the user when they select the operator in the Dashboards app or Low-Code Apps. If you do not configure this name, the name of the class is displayed instead, which may not be very user-friendly.

1. Compile the script as a library (see [Compiling a C# code block as a library](xref:Compiling_a_CSharp_code_block_as_a_library)). You can use the same name as defined in the *GQIMetaData* attribute, or a different name. If there are different operators for which the same name is defined in the *GQIMetaData* attribute, the library name is appended to the metadata name.

1. Validate and save the script. It is important that you do this after you have compiled the script as a library, as otherwise the compiler will detect errors.

1. In the Dashboards app or Low-Code Apps, configure a query and select the operator *Apply custom operator*.

1. In the *Operator* dropdown box, select the name of your operator.

***

Depending on how the script is configured, there can be additional configuration possibilities. You can for instance use the [*IGQIInputArguments* interface](xref:GQI_IGQIInputArguments) in the script to define that a specific argument is required.

> [!IMPORTANT]
> Custom operators are identified by a combination of their script name, library name, and class name. Changing any of these values will cause existing queries to stop working, because they will no longer be able to find the script based on the identifier they are using.

> [!TIP]
> See also: [Best practices for developing GQI extensions](xref:GQI_Extensions_Best_Practices).
