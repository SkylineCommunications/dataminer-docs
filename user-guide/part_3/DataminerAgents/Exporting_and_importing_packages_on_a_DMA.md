---
uid: Exporting_and_importing_packages_on_a_DMA
---

# Exporting and importing packages on a DMA

This section consists of the following topics:

- [Exporting elements, services, etc. to a .dmimport file](Exporting_elements_services_etc_to_a_dmimport_file.md)

- [Importing elements, services, etc. from a .dmimport file](Importing_elements_services_etc_from_a_dmimport_file.md)

> [!NOTE]
> - For more information on how to migrate elements within one DataMiner System, see [Migrating elements in a DataMiner System](xref:Migrating_elements_in_a_DataMiner_System).
> - For more information on how to import and export elements using CSV files, see [Importing and exporting elements](xref:Importing_and_exporting_elements).
> - It is also possible to export element information to the printer or the clipboard. To do so, follow the same procedure as to export to a CSV file. See [Exporting elements to a CSV file](xref:Importing_and_exporting_elements#exporting-elements-to-a-csv-file).
> - Backwards compatibility of import packages is not supported. For example, if you create an import package on a DataMiner 9.0.0 system, this cannot be imported in a system using DataMiner version 8.5.8.
> - Exporting/importing logger table data saved in Elasticsearch is only supported from DataMiner 10.1.4/10.2.0 onwards.
> - External DLLs are not included in .dmimport packages. If you export and import an element that uses an external DLL, this external DLL will still need to be added to the DMA where you import the element, either manually, or by means of a separate install package.

> [!TIP]
> See also:
> <https://community.dataminer.services/video/ruis-rapid-recap-delt/>
