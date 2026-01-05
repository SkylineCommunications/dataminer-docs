---
uid: Configuring_profile_parameters
---

# Configuring profile parameters

The parameters in a profile definition are linked to one or more parameters of existing DataMiner protocols. This way, if different protocols have conceptually identical parameters (e.g. “bit rate”), these can be linked to one and the same parameter in the *Profiles* module.

Profile parameters can be configured in two ways. You can either [add a parameter with the 'Add parameter' button](#creating-a-profile-parameter-with-the-add-parameter-button) and then configure it, or [drag an element from the Surveyor](#configuring-profile-parameters-by-dragging-an-element-onto-the-module) onto the *Parameters* pane and then add one or more parameters from that element to an existing or a new profile parameter:

> [!TIP]
> See also: [Profile parameters](xref:srm_definitions#profile-parameter).

## Creating a profile parameter with the Add parameter button

1. At the bottom of the *Parameters* tab of the list pane, click *Add parameter.*

   The new parameter will immediately be added to the list of parameters, with a red *\[new\]* marker to indicate that you still need to configure it further before it can be saved.

1. At the top of the configuration pane, enter the parameter name, and optionally enter any additional information about the parameter in the *Remarks* field below this.

1. If you wish to indicate whether the profile parameter is optional or not, click the toggle button next to *Optional* until it either shows *No*, for a mandatory parameter, or *Yes* for an optional parameter.

   Clicking the toggle button again will set it back to the default *Undefined*.

1. In the *Details* section below this, next to *Category*, select one or more categories for the parameter:

   - *Configuration*: Indicates that the parameter is used for configuration. If this category is not selected, it will not be possible to link the parameter to a protocol or to specify a default configuration value.

     > [!NOTE]
     > A profile parameter with category *Configuration* cannot be linked to a read-only element parameter.

   - *Monitoring*: Indicates that the parameter is used for monitoring.

   - *Capacity*: Indicates that the parameter represents a capacity. This category cannot be combined with the *Capability* category.

   - *Capability*: Indicates that the parameter represents a capability. This category cannot be combined with the *Capacity* category.

1. Next to *Type*, use the dropdown list to specify whether the parameter consists of a number or of text, or if it is a discrete parameter.

   - Depending on the category selection, the type options may be limited.

   - If the parameter consists of a number, optionally configure a default configuration value, units of measure, a minimum and maximum range, a step size and the number of decimals to be displayed.

   - If the parameter consists of text, optionally specify a default configuration value, or define a regular expression the text must conform with.

   - If it is a discrete parameter, add values using the *Add discrete value* option. Optionally, you can specify a default configuration value. To remove a value, click the x next to the value.

      You can also specify whether the values of the discrete parameter are text or numbers, and specify display values corresponding with the raw values of the parameter. Note that the raw values always have to be unique, and that both raw and display values always need to be specified. For discrete parameters configured prior to this version, only the raw values are displayed.

   > [!NOTE]
   > A profile parameter is considered invalid if it has a default value of type *Undefined*. Upgrading from a legacy DataMiner version where this is still supported will cause the default value type to be determined automatically. Note that parameters of type *Undefined* are also no longer considered valid, but these cannot be corrected automatically.

1. Click the *Add* button in the lower-right corner.

   The *Add link with protocol* dialog box will appear.

1. In the *Add link with protocol* dialog box, select a protocol, a protocol version and a parameter, specify a table index in case of a table parameter, and then click *OK*.

   > [!NOTE]
   > You can also configure a converter when linking the parameter to a protocol. See [Configuring a converter for a profile parameter](#configuring-a-converter-for-a-profile-parameter).

   The *\[new\]* marker next to the profile parameter will now turn blue to indicate that the parameter can be saved.

1. To save the new parameter, click the *Save all changes* button in the lower-right corner of the module.

### Configuring a converter for a profile parameter

To convert parameter values from the format defined in the protocol to a different format defined in the profile parameter, you can configure a converter (i.e. mediation snippet) for a parameter linked to a profile parameter.

1. Make sure the parameter is selected in the *Parameters* tab of the list pane of the *Profiles* module.

1. In the *Linked with* section, select the profile parameter and click the *Edit* button.

1. In the pop-up window, set *Converter* to *On*.

1. In the code section below this, modify the example C# code to the converter you want.

   > [!NOTE]
   >
   > - The converter code must contain one class that implements the *IMediator* interface and it must be able to handle concurrent *ConvertDeviceToProfile* and *ConvertProfileToDevice* calls. In the code, you can only reference *SLMediationSnippets.dll*, which contains the *IMediator* interface, *SLUnitConverter.dll*, and system DLLs such as *System.dll* and *System.Core.dll.*
   > - Exceptions and logging for converters can be found in the log file *SLMediationSnippetInfo.txt*.

1. When the converter has been configured, click *OK*.

1. Click *Save* to apply the changes.

## Configuring profile parameters by dragging an element onto the module

1. Drag an element from the Surveyor onto the *Parameters* tab of the list pane in the *Profiles* module.

   The *Import parameters* window will appear.

1. In the *Protocol parameters* section of the *Import parameters* window, select a protocol parameter.

   If you want to add one of the element’s general parameters, first select *Show general parameters* in order to have these displayed.

1. Either link the parameter to an existing profile parameter, or create a new profile parameter:

   - To link the parameter to an existing profile parameter, in the *Link* tab on the right-hand side of the *Import parameters* window, select the existing parameter in the list and then click the *Link* button.

   - To link the parameter to a new profile parameter, in the *New* tab on the right-hand side of the *Import parameters* window, configure the new profile parameter:

     1. Enter the profile parameter name next to *Name* and optionally add additional information in the *Remarks* field.

     1. If you wish to indicate whether the profile parameter is optional or not, click the toggle button next to *Optional* to either show *No*, for a mandatory parameter, or *Yes* for an optional parameter. Clicking the toggle button again will set it back to the default *Undefined*.

     1. Below this, specify whether the parameter consists of a number or of text, and apply any further options if necessary. For more information, refer to step 4 in the procedure [Creating a profile parameter with the Add parameter button](#creating-a-profile-parameter-with-the-add-parameter-button).

     1. Click *Create*.

1. To add more protocol parameters, repeat from step 2.

1. When the necessary parameters have been added, click *Close* to close the *Import parameters* window, and then click *Save all changes* in the lower-right corner of the module.
