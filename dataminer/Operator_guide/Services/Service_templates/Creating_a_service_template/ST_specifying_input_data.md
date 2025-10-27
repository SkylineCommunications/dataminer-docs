---
uid: ST_specifying_input_data
---

# Specifying the input data for a service template

In the *Input data* tab of a service template card, you can add and configure the input data that will either have to be specified by the user applying the template, or that will be automatically determined from parameters.

To add input data:

1. Click the *Add input data* button at the bottom of the card.

1. For each entry:

   1. In the *Name* column, specify a name.

   1. In the *Title* column, specify a description. This description is the text that will be shown when you use the input data elsewhere.

   1. In the *Type* column, select one of the three options: *User Input Text*, *Table Row Index*, or *Fixed Value*.

   1. In the *Details* column:

      - If you selected *User Input Text*, optionally indicate whether a valid element name is required, or if “N/A” can be used to indicate an empty value.

      - If you selected *Table Row Index*, click *Edit* to specify a table parameter and optionally add a filter mask.

      - If you selected *Fixed Value*, specify the fixed value.

      > [!NOTE]
      > While specifying the User Input Text, Table Row Index or Fixed Value, it is possible to refer to other input data or to child elements specified elsewhere in the service template.

If you added any input data that you want to delete later, you can delete them with the X in the *Delete* column.

> [!NOTE]
> - You can choose both monitored and unmonitored parameters as input data for the service. The latter can be used to include information that is important for the user, even though it does not necessarily have an impact on the service state.
> - By default, the services created by a service template will be added on the DMA hosting the majority of the child elements. In case there are no child elements, the services are added on the DMA where the service template is executed. However, you can force the selection of a specific DMA by adding an input data field with the name *:forceDMA* and the type *Fixed Value*, and specifying the DMA ID in the *Details* column.
