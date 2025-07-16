---
uid: Dynamic_virtual_elements
---

# Dynamic virtual elements

For cases where a large number of elements are combined, a dynamic virtual element (DVE) can be created. This can for instance be when numerous cards are contained in one chassis and every card should be a separate element.

A dynamic virtual element consists of one main parent DVE, from which child DVEs are dynamically generated. The parent DVE is responsible for all communication with the DMS, and all parameters of child DVEs are derived from the parent DVE.

## Creating a dynamic virtual element

A parent DVE is created like a regular element, but during creation a DVE protocol is assigned.

In the parent DVE, all child DVEs are indicated as rows in a table. If a row is added, a new child DVE is added. If a row is removed, the corresponding child DVE is removed. Each of the child DVEs also counts as an actual element in your DataMiner System.

> [!NOTE]
> Both parent and child DVEs must respect the DataMiner element naming conventions:
>
> - If a DVE name contains forbidden characters or leading or trailing dots or spaces, the name will be automatically adapted and an entry indicating this will be added in the Element log.
> - If a DVE name is empty or not unique in the DMS, the element will not be created or renamed, and a notice will be generated mentioning the primary key of the DVE table row that contains the invalid element name. Additional information will also be logged in the SLErrors.txt file, under “Validate DVE Name”.
> - Renaming a parent DVE will trigger a rename of all child elements of which the name starts with that of the parent element.

> [!TIP]
> See also: [Naming of elements, services, views, etc.](xref:NamingConventions#naming-of-elements-services-views-etc)

New child DVEs will be added in the same view as the parent DVE, except if a view column has been specified in the DVE protocol. If there is a view column:

- If the view column is left empty, the child DVE will be placed in the same view as the parent DVE.

- When a value is entered in the view column, the child DVE is placed in the view(s) referred to by that value.

- When you replace a value in the view column for an existing child DVE, the child DVE will be moved to the specified view(s), and removed from all other views.

> [!NOTE]
> It is advisable to specify the view(s) immediately when adding new rows to a DVE table with a view column. This way, unnecessary view updates can be avoided.

## Editing a dynamic virtual element

Child DVEs get most characteristics, including their different protocols, from the parent DVE protocol.

As a consequence:

- It is not possible to set the state of a single child DVE, only of the parent DVE and as a consequence of all child DVEs at the same time.

- A child DVE cannot be deleted separately. Instead, to remove it, a row must be deleted in the table of the parent DVE.

- A DVE child protocol cannot be deleted separately, but when the main protocol is deleted, the child protocols are deleted as well.

- Only limited editing possibilities are available for DVE child elements: you can modify the description of the element, the alarm template, the trend template, the parent view(s), and the properties, and you can set a DVE child element to *Hidden*.

  > [!NOTE]
  > By default, DVE child elements follow the alarm template of the parent DVE, if that is available. When an alarm template other than the parent DVE's alarm template is assigned to a DVE child element, the two templates will be applied in a hierarchical fashion, with the specific DVE child's template coming first, and the parent DVE's template next. When the parent DVE does not have any assigned alarm template, the DVE child's template behaves like a standard alarm template.

## Enabling or disabling the creation of DVE child elements

By default, when a parent element is created, creation of child elements is enabled. However, it is possible to disable or enable the creation of child elements.

In DataMiner Cube, this can be done when the DVE is created or edited:

- In the *Advanced element settings,* select or clear *Enable DVE child creation*.

Alternatively, if [Swarming](xref:Swarming) is not enabled, this can be done manually in the *Element.xml* file. To do so:

1. Stop DataMiner.

1. In `C:\Skyline DataMiner\Elements\`, go to the subfolder of the parent element and open *Element.xml*.

1. Add the *dvecreate* attribute to the Name tag and set its value to FALSE.

   Example:

   ```xml
   <Element>
     <Name dvecreate="FALSE">DVE Main Element</Name>
   </Element>
   ```

1. Save your changes and restart DataMiner.

When you disable the setting for a particular parent element, all its existing child elements will disappear from the system and their element IDs will be cleared. When you enable the setting afterwards for that same parent element, the child elements will be recreated with new element IDs.

> [!NOTE]
>
> - Only DVE main elements that have element creation disabled can be added to a redundancy group.
> - This setting does not affect the creation of virtual functions (used in DataMiner SRM).
