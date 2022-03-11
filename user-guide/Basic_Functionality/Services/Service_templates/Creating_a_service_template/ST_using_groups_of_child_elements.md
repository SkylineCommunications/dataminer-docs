---
uid: ST_using_groups_of_child_elements
---

# Using groups of service template child elements

Go to the *Groups* tab of a service template card to create groups for the child elements of the service template. For these groups, you can then define conditions for inclusion or exclusion of elements or services, or set a maximum severity for child elements.

To add a group:

1. Click the *Add New Group* button at the bottom of the tab.

1. In the *Name* column, specify a name for the group.

1. In the *Edit* column, click the *Edit* button to configure the group further:

   - In the *Conditions* section of the *Edit group* window, two options can be selected:

     - To only include the group based on certain conditions, select *Dynamically include* or *Dynamically exclude* and add a trigger with the *Add trigger* button.

     - To limit the influence of the group on the service alarm severity, select *While included, influence overall service alarm severity when*, and add a trigger with the *Add trigger* button.

   - In the *Advanced* section of the *Edit Group* window, three configuration options are available:

     - To set a maximum severity for included elements in the group, select a severity in the drop-down list next to *Maximum severity on included element*.

     - To set a maximum severity for elements in the group that are not used, select a severity in the drop-down list next to *Maximum severity on element not used*.

     - To indicate a parent group for the group, select it in the *Parent Group* drop-down list.

     > [!NOTE]
     > For more information on service item statuses such as “included” and “not used”, see [DATA](xref:Service_card_pages#data).

If you have added any groups that you would like to delete, use the X in the *Delete* column of these groups.

To include child elements in a group:

- When editing a child element, select a parent group at the top of the *Edit Child Element* window. See [Creating child elements in service templates](xref:ST_creating_child_elements).
