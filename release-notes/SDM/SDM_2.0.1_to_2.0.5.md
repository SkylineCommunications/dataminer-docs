---
uid: SDM_2.0.1_to_2.0.5
---

# Standard Data Model 2.0.1 to 2.0.5

## SDM 2.0.5 - Fix - GQI process locked the SDM.Abstractions DevPack [ID 45092]

A problem in the installation flow for the SDM.Abstractions DevPack could cause it to be locked by the GQI process. This issue has now been resolved. The installer will stop the GQI service before installing the DevPack and then restart the service again after installation.

## SDM 2.0.4 - Enhancement - General improvements [ID 45091]

A number of general maintenance updates and stability improvements have been implemented. This includes minor fixes and internal improvements, dependency and package maintenance, and documentation touch-ups.

## SDM 2.0.3 - Enhancement - General improvements [ID 45090]

A number of general maintenance updates and stability improvements have been implemented. This includes minor fixes and internal improvements, dependency and package maintenance, and documentation touch-ups.

## SDM 2.0.2 - Enhancement - Migration of NuGet package references to Central Package Management [ID 45089]

All NuGet package references have been migrated to use Central Package Management (CPM). This simplifies dependency management across the solution and ensures consistent package versions across all projects.

## SDM 2.0.1 - Enhancement - Solution ID standardization [ID 45088]

Solution IDs now follow the new standard format using the Catalog GUID as the identifier. This ensures consistent identification across all DataMiner Solutions and improves compatibility with the DataMiner Catalog.
