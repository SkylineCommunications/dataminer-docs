---
uid: Creating_a_selection_box_with_all_elements_in_a_connectivity_chain
---

# Creating a selection box with all elements in a connectivity chain

When connectivity has been defined in a drawing, you can turn a shape into a selection box containing all elements in the connectivity chain.

Create a shape, add a shape data field of type **Connection** to it, and set its value to “*ConnectionElements*”. You can then also specify a number of options.

- On the **Connection** shape itself, you can specify the following options, separated by pipe characters:

    | Option            | Description                                                                                                                           |
    |---------------------|---------------------------------------------------------------------------------------------------------------------------------------|
    | ItemFormat=         | Can be used to format the selection box items (which by default only show the element name).                                          |
    | NoSelectionDisplay= | Ensures that the selection box contains an extra item that represents “No selection”. This will always be the first item in the list. |

- On other shapes: the selection box will not include shapes for which the “*DisableConnectivity*” option has been specified.

#### Example:

| Shape data field | Value                                                                                 |
|------------------|---------------------------------------------------------------------------------------|
| Connection       | ConnectionElements\|ItemFormat=Connectivity for '{0}'\|NoSelectionDisplay<br>=\<None> |

If the configuration above is applied, the selection box will contain the following items:

- \<None>

- Connectivity for 'Element1'

- Connectivity for 'Element2'

- ...

- Connectivity for 'ElementX'
