---
uid: DashboardForm
---

# Form

Available from DataMiner 10.3.6/10.4.0 onwards.<!-- RN 36124 --> To use this visualization, you need to have at least one [DOM](xref:DOM) module defined in your DMS.

![Form component displaying editable input fields with labels and submission buttons in a DataMiner low-code app](~/dataminer/images/Form.png)<br>*Form component in DataMiner 10.4.6*

This visualization takes an object manager instance or object manager definition as data input and displays it as a form:

- In a dashboard, only an object manager instance can be used as input.
- In a low-code app, you can use either an object manager instance or an object manager definition, or both. If you use a definition, the fields of the definition are displayed, which the user can fill in to create an instance. Using both definition and instance input at the same time can for example be useful in case you use dynamic data for the instance. In that case, as long as a value is being provided, the data of the instance is displayed; otherwise the empty fields of the definition are displayed.

If you use this component with object manager instance input in a low-code app, you can use the *Read mode* layout setting to determine whether it should be an editable form or not. In a dashboard, a form can only be displayed in read-only mode.

In a low-code app, this component will also make a number of [component actions](xref:LowCodeApps_event_config) available, which you can for instance use with a [button](xref:DashboardButton):

- *Create a new instance*: This will create an empty form for the configured DOM definition even if a DOM instance is configured as data. This allows you to link DOM instance data to the component and at the same time make it possible to create a new DOM instance.
- *Cancel current changes*: If you execute this action after you executed the action to create a new instance, the previously shown form will be displayed again.
- *Delete instance*
- *Save current changes*
- *Set form to edit mode*
- *Set form to read mode*

Please note the following:

- Saving an empty field value for a DOM instance is only supported from DataMiner 10.3.8/10.4.0 onwards<!-- RN 36276 -->. Prior to this, you can only empty a DOM field value using an automation script. See [Altering values of a DomInstance - examples](xref:DOM_Altering_values_of_a_DomInstance).

- The `GroupFieldDescriptor` and `UserFieldDescriptor` [field descriptors](xref:DOM_SectionDefinition#fielddescriptor) are supported as a dropdown list in the form component from DataMiner 10.3.9/10.4.0 onwards<!-- RN 36556 -->. Fields defined as `GroupFieldDescriptor` will display the group name and use that same group name as value. Fields defined as `UserFieldDescriptor` will display the full name of the user, but will store the user name as value. When the field descriptor defines any group names, the dropdown list will only include the users belonging to those groups.

- From DataMiner 10.3.10/10.4.0 onwards<!-- RN 37007 -->, the GenericEnumFieldDescriptors options are listed in the same order as they are created, for optimal customizability of the form. In earlier DataMiner versions, they are ordered alphabetically.

- From DataMiner 10.3.0 [CU12]/10.4.3 onwards<!-- RN 37546 -->, only the first 100 instances are initially loaded in a form. To find other instances, you can search for them. However, note that for `DomInstanceValue` fields, you can only search on the DOM instance name. Also, if a `DomInstanceValueFieldDescriptor` is used that refers to a field descriptor in a section definition that allows multiple values, only the first value that is found will be shown. If a DOM instance does not contain a value for such a field descriptor, only the DOM instance name will be shown.

- From DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12 onwards<!--RN 43864-->, when a form is displayed in read-only mode, any HTML code in its content is displayed as code instead of being interpreted. For example, a value like `<b>Text</b>` will be displayed as "\<b\>Text\</b\>" instead of "**Text**".

  > [!TIP]
  > If you want HTML code to be rendered as formatted content, use a [grid component](xref:DashboardGrid) with a GQI query instead.
