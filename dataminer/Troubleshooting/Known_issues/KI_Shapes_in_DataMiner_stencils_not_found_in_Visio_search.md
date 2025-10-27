---
uid: KI_Shapes_in_DataMiner_stencils_not_found_in_Visio_search
---

# Shapes in DataMiner stencils not found in Visio search

## Description of the issue

In Microsoft Visio, when you search for the shapes within the Visio stencils that are shipped with DataMiner, these cannot be found. There is no problem when searching for shapes in the stencils that are shipped with Visio itself.

## Cause

Microsoft Visio relies on the Windows indexing service to find these shapes, and the folder `C:\users\username\appdata`, where the DataMiner stencils are stored, is by default not indexed.

## Resolution

Add the following location in the Windows indexing options: `C:\Users\username\AppData\Roaming\Skyline\DataMiner\Stencils\`

> [!TIP]
> For more information, see this [Microsoft blog post](https://devblogs.microsoft.com/windows-search-platform/configuration-and-settings/).
