---
uid: ST_example_ST_creation
---

# Example of creating a service template

1. Right-click a view in the Surveyor and choose *New \> Service template*.

1. In the *General* tab, enter the name of the service template under *Template name*, and optionally add a description.

1. Select the *Child elements* tab, and add a child element:

   1. Click *Add child element*.

   1. In *Title*, enter the name of the child element (example: "MsElement").

   1. Click *Edit* to open the *Edit child element* dialog box.

   1. Select *Templated element*.

   1. Select *Allow element to be reused by multiple services*.

   1. Select the protocol (example: "Microsoft Platform") and the protocol version (example: "Production").

   1. Click *OK*.

1. Select the *Input data* tab, and add input data:

   1. Click *Add input data*.

   1. Specify a *Name* and a *Title* (example: "Model").

   1. Set Type to *Fixed Value*.

   1. In *Details*, open the placeholder selection box, and select *Child elements \> \[ElementTitle\] (example: "MsElement") \> Parameter*.

   1. In the *Select parameter* dialog box, open the *Parameter* selection box, select the parameter (example: "Model") from the list, and click *OK*.

1. Still in the *Input Data* tab, add input data again:

   1. Click *Add Input Data*.

   1. Specify a Name and a Title (example: "Process").

   1. Set Type to *Table Row Index*.

   1. Click *Edit*.

   1. In the *Select Table Parameter* dialog box, specify the Child Element (example: "MsElement"), specify the Parameter (example: "Task Manager"), specify the Filter Mask (example: "SL\*"), and click *OK*.

1. Select the *Child elements* tab, and edit the child element you have created earlier:

   1. Click *Edit* to open the *Edit child element* dialog box.

   1. In the *Included parameters* section, select *Some parameters*, and click *Select parameters*.

   1. Select the parameter you want, e.g., "CPU", open the placeholder selection box, and select *Input data > Process*.

   1. Select a next parameter, e.g., "Memory Usage", open the placeholder selection box, and select *Input data > Process*.

   1. Click *Close* to exit the *Select parameters* dialog box.

   1. Click *OK* to exit the *Edit child element* dialog box.

1. Select the *Generated service* tab.

   1. Open the placeholder selection box next to *Generated service name*, and select *Input data \> Model*.

   1. Open the placeholder selection box next to *Generated service name*, and select *Input data \> Process*.

   1. Enter an underscore ("\_") between *\[data:Model\]* and *\[data:Process\]*.

1. If you do not want SLAs to be created when the service template is applied, select the *Generated SLA* tab, and clear the *Create SLA* option.

1. Click *Save And Close*.

> [!NOTE]
> For an example of how to apply this service template, see [Example of applying a service template](xref:Applying_service_templates#example-of-applying-a-service-template).
