---
uid: Creating_an_information_template
---

# Creating an information template

For every protocol in your DataMiner System, you can create custom information templates. When set as the active information template, a custom information template will override the default information template, which is defined in the *Protocol.xml* file itself.

To create an information template:

1. Go to *Apps* > *Protocols & Templates*.

1. Under *Information Templates*, right-click the default information template and select *New*.

1. In the *New Information Template* dialog box, enter the name of the template, select the protocol and click *OK*.

   > [!NOTE]
   > Some characters cannot be used in template names. For more information, see [Naming of elements, services, views, etc.](xref:NamingConventions#naming-of-elements-services-views-etc)

1. Go through the list of all parameters (inherited from the most recent version available of the protocol you selected previously) and make the necessary changes to the following parameter data:

   - **Description**: The parameter display name that will appear in the user interface instead of the display name defined in the protocol.

     > [!NOTE]
     > The actual parameter name in the protocol is an internal identifier only, and cannot be modified in an information template.

   - **Detailed description**: The parameter description that will be displayed in the parameter details.

   - **Custom name**: An alternative parameter name (i.e. alias) that can be used in Visual Overview, poll socket requests, Dashboards, Automation, etc.

     Suppose you use three protocols that have an identical parameter but with a slightly different name. In that case, you could use this “custom name” to assign the same alias to those three parameters and then use that alias in a Visio drawing shared by the three protocols.

   - **Category**: A custom category that will be assigned to the parameter.

     To visualize this information in the user interface, add the *Category* column to the Alarm Console.

   - **Key point**: The exact location in the signal chain where the error has occurred. E.g. “Encoding”, “Decoding”, “Reception”, etc.

     This is used in DataMiner Business Intelligence.

   - **Component info**: More information about the nature of the alarm. E.g. “Audio”, “Video”, etc.

     This is used in DataMiner Business Intelligence.

     > [!TIP]
     > See also: [Setting a violation filter](xref:Configuring_the_alarm_settings_for_an_SLA#setting-a-violation-filter)

   - **Hide parameter:** Allows you to hide this parameter in the Cube UI. Available from DataMiner 9.5.6/9.6.0 onwards.

     > [!NOTE]
     > While hiding page buttons via an information template is possible from DataMiner 9.5.6/9.6.0 onwards, hiding regular button or toggle button parameters is only possible from DataMiner 10.0.13/10.1.0 onwards.

   - **Alarm description**: Extra information for the operator describing the problem in case an alarm is generated.

     To visualize this information in the user interface, add the *Alarm description* column to the Alarm Console.

   - **Corrective actions**: Extra information for the operator about how to proceed in case an alarm is generated.

     To visualize this information in the user interface, add the *Corrective actions* column to the Alarm Console.

   - **Offline impact**: Enable this option to indicate that an alarm on this parameter will have an impact during the offline window of the SLA.

     This is used in DataMiner Business Intelligence.

     > [!TIP]
     > See also: [Setting the offline window for an SLA](xref:Setting_the_offline_window_for_an_SLA)

   - **Alarm properties**: Can be used from DataMiner 9.5.3 onwards to override alarm properties for the parameter.

     To override alarm properties, select *Override* and specify the alarm property name(s) and value(s). In the *Value* field, you can directly refer to other parameters by typing *parameter.* and then selecting the parameter in the drop-down list. Note that the alarm property name must not contain a semicolon.

   - **Part of snapshot**: Enable this option to add the value of this parameter to snapshots that are offloaded to the offload database.

     > [!TIP]
     > See also: [Configuring the offload rate](xref:Configuring_data_offloads#configuring-the-offload-rate)

    > [!NOTE]
    >
    > - To quickly find a parameter in the parameter list, use the filter box in the top right corner. You can also filter the displayed parameters with the button at the top of the parameter list, in order to view *Only edited parameters*, *Only protocol parameters* or *All parameters (protocol + general)*.
    > - In the top-right corner of the parameter details pane, click *Clear* to clear all data in the details pane on the right for the currently selected parameter.
    > - For table parameters, a field is available in the pane on the left that allows you to specify a filter, so that the information template configuration is only applied on a filtered selection of available rows of the dynamic table. As a result, alarm description, alarm category and corrective action can differ based on the display key of a table. You can also duplicate table parameters in the list in order to apply different filters at the same time.

1. Click *OK*.
