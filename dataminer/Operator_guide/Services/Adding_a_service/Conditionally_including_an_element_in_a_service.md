---
uid: Conditionally_including_an_element_in_a_service
---

# Conditionally including an element in a service

During service creation or while editing a service, it is possible to include an element based on certain conditions, and/or to only let it influence the alarm severity of a service based on certain conditions.

**To include an element conditionally:**

1. Select an element that has been added to the service in the *elements* tab of the service creation card.

1. In the pane on the right, under *This element is included in the service*, select *Based on conditions*.

1. If the element should be included when the condition matches, select *Include (In Use when condition match)*, otherwise select *Exclude (Excluded when condition match)*.

1. Click *Add condition* and select one of the options in the drop-down list, depending on what the condition should match with: *Parameter value*, *Alarm state*, or *Element state*, or *Element is in the active connectivity chain*.

   - If you select *Parameter value* or *Alarm state* and specify a table parameter, a toggle button is displayed next to the index. Click the toggle button to switch between using the primary key or the display key (default) to check for the parameter value or the alarm state.

   - If you select *Element is in the active connectivity chain*, element inclusion will depend on whether the element, or the instance of the element, is part of a connectivity chain. In this case, the following steps in this procedure no longer apply, and you can instead specify a connectivity configuration.

   - Note that for the above-mentioned option to be enabled, the folder `C:\Skyline DataMiner\Connectivity` must be created, which must contain a file called *Connectivity.xml* containing the following code:

     ```xml
     <DCF>
       <ServiceConnectivity>true</ServiceConnectivity>
       ...
     </DCF>
     ```

     The configuration you can select in the option depends on another *Connectivity.xml* file placed in a subfolder of this folder. The “itemA” attribute of the first of the \<link> tags in this file determines the name of the available configuration.

     > [!TIP]
     > See also:
     > [Defining connectivity chains in XML files](xref:Defining_connectivity_chains_in_XML_files)

   > [!NOTE]
   > - If you use the option *Element is in the active connectivity chain*, but do not select *Specify config*, then the element will always be excluded when *Include (In Use when condition match)* is selected, or always included when *Exclude (Excluded when condition match)* is selected.

1. Click the first *\<Click to select>* field, and select the name of the element on which the condition should occur.

1. If you have selected *Parameter value* or *Alarm state*, select the parameter for which the condition applies.

1. If necessary, click *Equal to* in order to select a different relational operator: *Not equal to*, *Greater than*, etc.

1. Click the last field in the line to select or enter the value the condition should match with.

1. To add more conditions:

   1. Click *Add filter*.

   1. To select a different logical operator to combine the new condition with the previous one, click *And* and select the logical operator: *And Not*, *Or*, etc.

   1. Configure the new condition in the same way as described above.

**To make an element’s effect on the alarm severity of the service conditional:**

1. Select an element that has been added to the service in the *elements* tab of the service creation card.

1. In the pane on the right, under *Once included, this element will influence the overall alarm severity of the service*, select *Based on conditions*.

1. Continue in the same manner as in step 4 of the procedure above.

> [!NOTE]
>
> - If an element is included conditionally, or influences the alarm severity conditionally, it is also possible to set a delay for the trigger. To do so, select the *Delay for this trigger* checkbox, and specify a number of seconds. However, note that this delay is not possible if the condition depends on whether the element is part of a connectivity chain.
> - For more information on the possible status of child items based on these conditions, see [DATA](xref:Service_card_pages#data).
