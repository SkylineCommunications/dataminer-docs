---
uid: DashboardForm
---

# Form

Available from DataMiner 10.3.6/10.4.0 onwards.<!-- RN 36124 --> To use this visualization, you need to have at least one [DOM](xref:DOM) module defined in your DMS.

This visualization takes an object manager instance or object manager definition as data input and displays it as a form:

- In a dashboard, only an object manager instance can be used as input.
- In a low-code app, you can use either an object manager instance or an object manager definition, or both. If you use a definition, the fields of the definition are displayed, which the user can fill in to create an instance. Using both definition and instance input at the same time can for example be useful in case you use a dynamic feed for the instance. In that case, as long as a value is being fed, the data of the instance is displayed; otherwise the empty fields of the definition are displayed.

If you use this component with object manager instance input in a low-code app, you can use the *Read mode* layout setting to determine whether it should be an editable form or not. In a dashboard, a form can only be displayed in read-only mode.

In a low-code app, this component will also make a number of [component actions](xref:LowCodeApps_event_config) available, which you can for instance use with a [button](xref:DashboardButton):

- *Create a new instance*: This will create an empty form for the configured DOM definition even if a DOM instance is configured as data. This allows you to link a DOM instance feed to the component and at the same time make it possible to create a new DOM instance.
- *Cancel current changes*: If you execute this action after you executed the action to create a new instance, the previously shown form will be displayed again.
- *Delete instance*
- *Save current changes*
- *Set form to edit mode*
- *Set form to read mode*

> [!NOTE]
> Saving an empty field value for a DOM instance is only supported from DataMiner 10.3.8/10.4.0 onwards<!-- RN 36276 -->. Prior to this, you can only empty a DOM field value using an Automation script. See [Altering values of a DomInstance - examples](xref:DOM_Altering_values_of_a_DomInstance).
