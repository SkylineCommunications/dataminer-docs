---
uid: Editing_an_information_template
---

# Editing an information template

You can either edit the complete information template in the Protocols & Templates module, or edit the template for a single parameter.

## Editing the complete information template

To make changes to the complete information template:

1. Go to *Apps* > *Protocols & Templates*.

1. Under *Protocols*, select the protocol.

1. Under *Information Templates*, right-click the information template you want to edit and select *Open*. Alternatively, you can also open the information template in a new card with the context menu options *Open in new card* or *Open in new undocked card*.

1. Make the necessary changes and click *OK*.

   For more information, refer to step 4 of [Creating an information template](xref:Creating_an_information_template).

> [!NOTE]
>
> - A protocol’s default information template, which is defined in the *Protocol.xml* file, cannot be edited as described above. The only way to modify it is by making changes to the protocol itself.
> - If an information template is based on an older protocol version that does not have the same parameters as the latest protocol version, a warning is displayed at the bottom of the information template. Above the warning, a dropdown list allows you to select a different protocol version to load those parameters instead.

## Editing the information template for one parameter

To make changes to the information template for one particular parameter:

1. Go to the *Information* window, either from the Alarm Console, or from a parameter card:

   - In the Alarm Console, right-click an alarm for that particular parameter, and select *Change \> Information*.

   - In the top-left corner of the parameter card, click the hamburger button, and select *Change information*.

1. Make the necessary changes:

   - To adapt the category, choose a different category in the dropdown list next to *Category*

   - To adapt the alarm description, write a new alarm description in the *Alarm description* field.

   - To adapt the corrective actions, write the new corrective actions in the *Corrective actions* field.

1. Click *Update Information Template* to save your changes.

   > [!NOTE]
   >
   > - The template will be updated for all elements that use it. These are listed for reference at the bottom of the *Information* window.
   > - If you use this procedure for an element that was using the default information template, a new template will be created with the changes you entered for this parameter.
