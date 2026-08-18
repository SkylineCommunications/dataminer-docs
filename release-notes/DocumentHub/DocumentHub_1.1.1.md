---
uid: DocumentHub_1.1.1
---

# DocumentHub 1.1.1 - preview

## Prerequisites

> [!NOTE]
> This version requires:
>
> - DataMiner 10.6.5 or higher
> - [Standard Data Model Registration](https://catalog.dataminer.services/details/52173e49-9185-4772-9b60-c186ee365a81) 2.0.x or higher

## New features

### DocumentHub: Added User-Defined APIs [ID 299213]

- Added User-Defined APIs (UDAPIs) that can be used through the Agent or the default UDAPI endpoint.

## Fixes

### DocumentHub: DOM File Downloads [ID 299559]

- Fixed issues in script logic and implemented changes to the LCA where the user could not trigger the Download script.

### DocumentHub: Preserve the existing network share attachment settings when reinstalling the solution [ID 299891]

- Logic was added to ensure that credentials and network share are not overwritten.

### DocumentHub: Fixed GetRelativePath [ID 303509]

- The relative path for Local Storage was incorrect, causing that user could not preview or download the selected files.

**Full Changelog:** https://github.com/SkylineCommunications/SLC-S-DocumentHub/compare/1.0.2...1.0.3
