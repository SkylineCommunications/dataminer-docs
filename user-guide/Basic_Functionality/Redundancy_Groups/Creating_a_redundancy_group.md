---
uid: Creating_a_redundancy_group
---

# Creating a redundancy group

> [!TIP]
> See also: [Rui’s Rapid Recap – Redundancy groups](https://community.dataminer.services/video/ruis-rapid-recap-redundancy-groups/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

To create a redundancy group:

1. Right-click the view in the Surveyor where you want to create the new redundancy group and select *New \> Redundancy group.*

1. On the first tab page, enter a name. Optionally, you can also add a description, and select the DMA that has to host the redundancy group.

   > [!NOTE]
   > After the redundancy group has been created, you can quickly change its name by right-clicking it in the Surveyor and selecting *Rename*.

1. On the *Configuration* tab page, in the *Advanced* options at the top of the card, optionally change the masking options:

   - Select *Configure masking for all elements at once*, and indicate if elements that are not operational should be masked, or

   - Select *Configure masking for each element individually*.

1. Add the primary elements:

   1. Click the *Manage primary* button.

   1. In the *Manage primary elements* window, use the *Add \>\>* and *\<\< Remove* buttons to move elements from the column with existing elements in the DMA to the column with primary elements in the redundancy group.

      > [!NOTE]
      >
      > - The elements in the redundancy group must use the same protocol and protocol version, and must be hosted by the same DataMiner Agent.
      > - Prior to DataMiner 9.6.0/9.5.10, elements that were imported using DELT are not supported in redundancy groups.

   1. Click *OK*. The primary elements you have added will be displayed in the *Primary elements* list.

1. Select each primary element in turn to configure it using the options on the right side of the card:

   - If you want the element to use different alarm or trend templates after switching, select *Custom templates after switching*, and indicate which templates should be used when the element is and is not operational.

   - To give a custom name to the virtual primary element corresponding to the primary element, in the *Advanced element settings* section, enter a different name next to *Derived name*. By default, the same name as for the primary element is used, but enclosed in curly brackets.

   - To assign a virtual IP address to the virtual primary element, in the *Advanced element settings* section, select *Derived IP* and enter the IP address.

   - If *Configure masking for each element individually* is selected, in the *Advanced element settings* section, select *Mask this element if it is not operational* if you want the element to be masked when it is not operational.

1. Add the backup elements:

   1. Click the *Manage backup* button.

   1. In the *Manage backup elements* window, use the *Add \>\>* and *\<\< Remove* buttons to move elements from the column with existing elements in the DMA to the column with backup elements in the redundancy group.

   1. Click *OK*. The backup elements you have added will be displayed in the *Backup elements* list.

   > [!NOTE]
   > To quickly remove any of the elements you have added, click the x to the right of the element in the primary or backup elements list.

1. Select each backup element in turn to configure it using the options on the right side of the card:

   - In the drop-down lists under *Alarm templates*, choose an alarm template for when the backup element is operational, and one for when it is not operational. If set to *\<Dynamic>*, the element will take over the alarm template from the primary element.

   - In the drop-down lists under *Trend templates*, choose a trend template for when the backup element is operational, and one for when it is not operational. If set to *\<Dynamic>*, the element will take over the trend template from the primary element.

1. If you wish to use software redundancy:

   1. In the *Redundancy mode* section, click the underlined section and select *intervene in the switching (software redundancy)*.

   1. On the same line, click the underlined section to the right of *redundancy mode* and specify the redundancy mode.

      > [!NOTE]
      > For more information on the different redundancy modes and on how to switch between redundancy modes after the redundancy group has been created, see [Changing the redundancy mode](xref:Changing_the_redundancy_mode).

   1. If you want the conditions of the switching logic to also be checked when a user does a manual switch, in the *Redundancy mode* section, select *On manual switchover to a backup, also check the conditions from the switching logic*.

   1. In the *Switching logic* section, click add and select *Add switching logic*. A first empty switching condition will be displayed.

   1. Configure the switching condition by clicking the underlined fields and selecting the appropriate values, and add more conditions with the *Add* field below the condition if necessary:

      - The switchover and switchback actions can be triggered by an alarm, an element state or a parameter value. If connectivity has been configured on the DMA, they can also be triggered based on whether an element is in the active connectivity chain.

        > [!TIP]
        > See also: [Configuring redundancy switching based on connectivity](#configuring-redundancy-switching-based-on-connectivity)

      - If you configure a condition that triggers on a particular alarm or parameter value of a table parameter, a toggle button is displayed next to the parameter index. Click the toggle button to switch between using the primary key or the display key (default) to check for the parameter value or the alarm state.

      - With the last field of a condition, you can indicate whether the condition has to persist for a certain time or not before its result is triggered.

      - Next to *by executing*, you can configure what should happen during a switch: a parameter set or an Automation script execution.

1. In the *Switching Detection* section, specify when a switchover or switchback operation will be considered finished:

   1. Click *Add* and select *Add switching detection* to create a pair of conditions for switchover and switchback.

   1. Configure the conditions by clicking the underlined fields and selecting the appropriate values. The conditions are configured in a similar way as the switching conditions. They can be triggered based on whether an alarm exists, whether an element is in a particular alarm state, and whether a parameter has a particular value.

   1. If more conditions are necessary, click *Add* and configure the new conditions as described above.

   1. If the redundancy group state should be set to *Undefined* in case switching detection cannot be resolved, select the checkbox at the top of the *Switching Detection* section (available from DataMiner 9.6.11 onwards).

1. On the *Views* tab page, specify the view(s) where the redundancy group and its virtual primary element(s) will be placed:

   - By default, simplified view configuration is used. There you can select in what view the redundancy group should be created, and select either to add the virtual primary elements in the same view as the original element, or to add them in the same view as the redundancy group.

   - If you wish to select a view for the redundancy group and another view for each of the virtual primary elements, click *Switch to advanced view configuration*, and select each item in turn to indicate the view where it should be placed.

1. Click the *Create* button in the lower right corner.

> [!NOTE]
>
> - To make changes to an existing redundancy group, right-click it in the Surveyor and select *Edit*.
> - A redundancy group can also be created by a parent element. In that case, it is possible that it is not or only partly editable, except by an Administrator or via the parent element.
> - Elements that have been migrated from one DMA to another can only be used in redundancy groups from DataMiner version 9.5.1 onwards.

> [!TIP]
> See also: [Automation scripts triggered from redundancy groups](xref:Automation_scripts_triggered_from_redundancy_groups)

## Configuring redundancy switching based on connectivity

To switch a redundancy group based on connectivity, when configuring the trigger, select to switch based on whether an element is in the active connectivity chain, and then select the *Connectivity.xml* file that should be used.

In the *\<Link>* tag of that *Connectivity.xml* file, the *itemB* attribute refers to the protocol with the initial logic DCF will use to find the connections. In the corresponding element using the protocol specified in this attribute, you must set the correct connection properties to trigger redundancy switching based on connectivity:

1. Open the element card of this element, and go to the *General Parameters* page.

1. Next to *DataMiner Connectivity Framework*, click the *Configure* button.

1. In the *Connection Properties* table, each entry refers to a connection with an element. To switch the redundancy group:

   - Set the *Connection Property value* for the element to which you want to switch to a value corresponding to what is configured in the *value* attribute of the *\<Map>* tag in the *Connectivity.xml* file.

     > [!NOTE]
     > In the *\<Map>* tag of the *Connectivity.xml* file, the *propertyB* attribute refers to the Connection Property name.

   - If you are switching from primary to backup, make sure that the new value you specify for the backup is the same as the value that was previously specified for the primary.

> [!NOTE]
>
> - Prior to DataMiner 9.5.5, the connectivity path is only calculated starting from an internal connection, so that a connectivity chain path with only external connections cannot cause a redundancy group to switch. From DataMiner 9.5.5 onwards, this restriction no longer applies.
> - If a *Connectivity.xml* file with the *includeValueInContext* option is used, up to DataMiner 9.5.6, multiple matching values are not supported. From DataMiner 9.5.7 onwards, multiple paths to the shared destination interface are allowed in the connections matching the switching criteria.

> [!TIP]
> See also: [Defining connectivity chains in XML files](xref:Defining_connectivity_chains_in_XML_files)
