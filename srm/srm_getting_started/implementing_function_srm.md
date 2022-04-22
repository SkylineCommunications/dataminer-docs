---
uid: implementing_function_srm
---

# Implementing virtual functions

## Creating profile parameters

To manage the service flow, SRM will need to orchestrate one or multiple virtual function resources, either ad hoc (with Resource Automation), or at the start and end of a booking (with Resource Orchestration or Service Orchestration). Configurations will need to be applied at the start and stop of each booking, and for this purpose, you will need to add [profile parameters](xref:srm_definitions#profile-parameter).

First, **for each virtual function** that you want to create, **identify the various configuration parameters** that will need to be orchestrated. Then make sure there is **a profile parameter for each of these parameters**. You can add these in the [Profiles module](xref:Configuring_profile_parameters).

For example, in DataMiner 10.2.0:

![Profile parameters in Cube](~/srm/images/ProfileParametersExample.png)

Secondly, it is also important to identify **capacity and capability parameters**. A specific parameter could be a capacity limitation or could be a specific capability provided by a function resource. For each identified capability and capacity, make sure there is a profile parameter in the [Profiles module](xref:Configuring_profile_parameters). The capacity or capability checkbox must be selected for these parameters.

For example, to make sure it will be possible to configure the interfaces of virtual function resources, you will need to create the ResourceInputInterfaces and ResourceOutputInterfaces capabilities (see [Provisioning virtual function resources](xref:provisioning_VFRs)).

When all profile parameters have been created, these can be used in profile definitions to orchestrate and filter out the virtual function resources.

> [!NOTE]
>
> - Instead of creating the same profile parameter multiple times, it is better to reuse profile parameters in multiple profile definitions and virtual functions.
> - It is possible to add more profile parameters later, to reflect changes in your system.

## Creating profile definitions

The next step is to create [profile definitions](xref:srm_definitions#profile-definition), to which virtual functions and virtual function interfaces can be linked. A profile definition is needed for each virtual function and its interfaces.

You can configure the profile definitions in the [Profiles module](xref:Configuring_profile_definitions):

- **For each virtual function** that you want to use, make sure there is a **profile definition with a similar name** as the virtual function.
- **For each virtual function interface** that needs to be supported, make sure there is a **profile definition with a similar name** as the interface.
- **Add the related profile parameters** to the profile definitions.

For example, in DataMiner 10.2.0:

![Profile definitions in Cube](~/srm/images/ProfileDefinitionsExample.png)

## Creating profile instances

While [profile instances](xref:srm_instantiations#profile-instance) can also be added later, we recommend that you already **create at least one profile instance for each virtual function** during setup. You can do so in the [Profiles module](xref:Configuring_profile_instances).

For example, in DataMiner 10.2.0:

![Profile instances in Cube](~/srm/images/ProfileInstancesExample.png)

## Creating virtual functions

As any device or platform in the solution must be considered from a function perspective rather than a physical device perspective, [virtual functions](xref:srm_definitions#virtual-function) are essential in DataMiner SRM.

You can **create virtual functions using DataMiner Integration Studio** (version 2.37 or above):

1. Open Visual Studio (with [DataMiner Integration Studio](xref:DIS) installed).

1. In the header menu, select *File* > *New File*.

1. In the *New File* window, select *DataMiner Function Template* and click *Open*.

   ![New File window](~/srm/images/NewFunctionTemplate.png)

1. Specify the path to the connector exposing the function and click *OK*.

   ![New Function window](~/srm/images/NewFunction.png)

1. At the top of the code editor, click *Function Editor*.

   ![Function editor](~/srm/images/FunctionEditor.png)

   > [!TIP]
   > See also: [Function editor](xref:Function_editor)

1. Click *New function* to start creating a new function.

   ![New Function option in Function editor](~/srm/images/FunctionEditorNewFunction.png)

1. In the *Edit Function* window:

   - Specify the name of the function (e.g. decoding).

   - In the *Profile* box, select the profile definition that should be linked to the function.

   - If necessary, define the entry point for the function. This indicates the source data of the main element that will be used to create virtual function resources.

     - If this is full element, leave the entry point empty.
     - If this is based on a specific table of the element, select the table that will expose multiple instances of the function.

   - If necessary, also add interfaces of the function (using the *Add* button) and link them to the corresponding profile definitions.

   - When you have added all necessary information, click *OK*.

1. At the bottom of the Function editor, click *New page*.

   ![New Function option in Function editor](~/srm/images/FunctionEditorNewPage.png)

1. Specify a name for the page and click *OK*.

1. Add parameters that need to be displayed by the virtual function resource by dragging them from the *Parameters* column on the right to the *Layout* section in the middle.

   ![New Function option in Function Editor](~/srm/images/FunctionEditorParameters.png)

1. To save the virtual function, in the top-right corner, click *Apply Changes*.

1. [Publish](xref:XML_editor#publish) the function using DIS, or [upload](xref:Functions_XML_files#uploading-a-functions-xml-file-in-dataminer-cube) it to the DataMiner System.

1. [Activate](xref:Functions_XML_files#setting-a-functions-file-active) the function. At this point, the virtual function has been added to the system and the corresponding function connector has been created.

1. Optionally, In the Profiles module, define the mapping between the profile parameters and the protocol function parameters. You can do so using the *Linked with* section of the profile parameter configuration. See [Configuring profile parameters](xref:Configuring_profile_parameters).

   > [!NOTE]
   > This step will make it easier to develop a Profile-Load Script, as you will be able to implement it in a generic way. However, it is not always possible to have a one-to-one relationship between a protocol parameter and a profile parameter.

## Creating Profile-Load Scripts

A [Profile-Load Script (PLS)](xref:srm_scripting#profile-load-script-pls) is responsible for the orchestration of a specific virtual function. It is typically created for a specific virtual function exposed by a specific connector.

To create a PLS:

1. Start from the example script *SRM_ProfileLoadScriptTemplate*, which is included in the SRM framework.
1. Configure the script to set the configuration parameters on the virtual function of a connector.
1. To make sure the PLS is executed when a specific virtual function is orchestrated, when you have created the script, assign it to a profile definition:

   1. In the Profiles module, select the profile definition in the *definitions* tab.
   1. In the *Scripts* section, click *Add* to add the script. See [Configuring profile definitions](xref:Configuring_profile_definitions).

   > [!NOTE]
   > If the same function is exposed by multiple connectors, different PLSs can be listed for the same profile definition.
