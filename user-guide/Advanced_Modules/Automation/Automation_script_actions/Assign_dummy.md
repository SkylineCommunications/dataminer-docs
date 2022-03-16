---
uid: Assign_dummy
---

# Assign dummy

Use this action to assign an Automation script’s dummy to a specific element by using a variable or a value. This can for example be used to allow a script to swap the originally assigned dummy with a different one in case a problem with the dummy is encountered.

1. Click the left-most underlined field to select or create a dummy element.

   > [!NOTE]
   > For more information on creating dummy elements, see [Creating a dummy](xref:Script_variables#creating-a-dummy).

1. Select how the new element will be determined:

   - For a pre-determined element, select *Value* to select a specific element, and enter the element name or ID.

   - For an element determined by a script variable, select *Variable* and select the variable.

   > [!NOTE]
   > The value of the variable or the directly specified value should contain either the dmaID and elementID formatted as “dmaID/elementID” or the element name.
