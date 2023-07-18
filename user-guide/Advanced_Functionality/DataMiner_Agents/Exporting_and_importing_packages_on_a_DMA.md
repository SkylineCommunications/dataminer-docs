---
uid: Exporting_and_importing_packages_on_a_DMA
---

# Exporting and importing packages on a DMA

This section consists of the following topics:

- [Exporting elements, services, etc. to a .dmimport file](xref:Exporting_elements_services_etc_to_a_dmimport_file)

- [Importing elements, services, etc. from a .dmimport file](xref:Importing_elements_services_etc_from_a_dmimport_file)

> [!NOTE]
>
> - For more information on how to migrate elements within one DataMiner System, see [Migrating elements in a DataMiner System](xref:Migrating_elements_in_a_DataMiner_System).
> - For more information on how to import and export elements using CSV files, see [Importing and exporting elements](xref:Importing_and_exporting_elements).
> - It is also possible to export element information to the printer or the clipboard. To do so, follow the same procedure as to export to a CSV file. See [Exporting elements to a CSV file](xref:Importing_and_exporting_elements#exporting-elements-to-a-csv-file).
> - Exporting/importing logger table data saved in Elasticsearch is only supported from DataMiner 10.1.4/10.2.0 onwards.

> [!CAUTION]
> - Importing a package created with a more recent DataMiner version into a system with an older version is not supported and may not work. Importing a package created with an older DataMiner version into a system with a newer version will work in most cases, but this is not guaranteed.
> - External DLLs are not included in .dmimport packages. If you export and import an element that uses an external DLL, this external DLL will still need to be added to the DMA where you import the element, either manually, or by means of a separate install package.

> [!TIP]
> See also: [Rui’s Rapid Recap – DELT](https://community.dataminer.services/video/ruis-rapid-recap-delt/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)
