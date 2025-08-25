---
uid: CO_Creation
---

# Creating a custom operator

To define a new custom operator:

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

Depending on how the script is configured, there can be additional configuration possibilities. You can for instance use the [*IGQIInputArguments* interface](xref:GQI_IGQIInputArguments) in the script to define that a specific argument is required.

> [!IMPORTANT]
> Custom operators are identified by a combination of their script name, library name, and class name. Changing any of these values will cause existing queries to stop working, because they will no longer be able to find the script based on the identifier they are using.

> [!TIP]
> See also: [Best practices for developing GQI extensions](xref:GQI_Extensions_Best_Practices).
