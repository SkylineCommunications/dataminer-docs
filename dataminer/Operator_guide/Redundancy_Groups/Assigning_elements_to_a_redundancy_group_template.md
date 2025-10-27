---
uid: Assigning_elements_to_a_redundancy_group_template
---

# Assigning elements to a redundancy group template

If a redundancy group template has been created, it is possible to assign elements to it.

To do so:

1. Right-click the redundancy group template in the Surveyor and select *Configure redundancy elements*.

1. In the *Advanced* options at the top of the card, optionally change the masking options:

   - Select *Configure masking for all elements at once*, and indicate if elements that are not operational should be masked, or

   - Select *Configure masking for each element individually*.

1. Add the primary elements:

   1. Click the *Manage primary* button in the lower-left corner.

   1. In the *Manage primary elements* window, use the *Add \>\>* and *\<\< Remove* buttons to move elements from the column with existing elements in the DMA to the column with primary elements in the redundancy group.

   1. Click *OK*. The primary elements you have added will be displayed in the list on the left of the card.

1. Select each primary element in turn to configure it using the options on the right side of the card:

   - Select *Custom templates after switching* and select the alarm and trend templates, if you want custom templates to be applied.

   - Under *Advanced element settings*, enter a derived name for the element.

   - Under *Advanced element settings*, select *Derived IP* and enter a derived IP.

   - If *Configure masking for each element individually* is selected, clear *Mask this element if it is not operational* if you do not want the element to be masked.

1. Add the backup elements:

   1. Click the *Manage backup* button in the lower-left corner.

   1. In the *Manage backup elements* window, use the *Add \>\>* and *\<\< Remove* buttons to move elements from the column with existing elements in the DMA to the column with backup elements in the redundancy group.

   1. Click *OK*. The backup elements you have added will be displayed in the list on the left of the card.

1. Select each backup element in turn to configure it using the options on the right side of the card:

   - In the drop-down lists under *Alarm templates*, choose an alarm template for when the backup element is operational, and one for when it is not operational. If set to *\<Dynamic>*, the element will take over the alarm template from the primary element.

   - In the drop-down lists under *Trend templates*, choose a trend template for when the backup element is operational, and one for when it is not operational. If set to *\<Dynamic>*, the element will take over the trend template from the primary element.

1. Click *Apply* in the lower-right corner to finish assigning elements to the template.

> [!NOTE]
> Adding a DVE main element as a primary or backup element in a redundancy group is only possible if the creation of DVE child elements is disabled for that element. See [Enabling or disabling the creation of DVE child elements](xref:Dynamic_virtual_elements#enabling-or-disabling-the-creation-of-dve-child-elements).
