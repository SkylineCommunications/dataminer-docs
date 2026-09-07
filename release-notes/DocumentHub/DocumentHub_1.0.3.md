---
uid: DocumentHub_1.0.3
---

# DocumentHub 1.0.3

## Prerequisites

> [!NOTE]
> This version requires:
>
> - DataMiner 10.6.5 or higher
> - [Standard Data Model Registration](https://catalog.dataminer.services/details/52173e49-9185-4772-9b60-c186ee365a81) 2.0.x or higher

## New features

### Added user-defined APIs [ID 46221]

User-defined APIs (UDAPIs) have been added to expose custom actions and data through a standard API interface. These APIs can be consumed through the Agent or the default UDAPI endpoint, enabling integration with other systems and supporting workflow automation.

They are intended for use cases where teams need lightweight, reusable endpoints to retrieve information, trigger actions, or connect DocumentHub with external applications without developing custom integrations from scratch.

This functionality is also ready to support DataMiner Assistant scenarios, making it easier to expose DocumentHub capabilities to AI-driven interactions and assistants.

## Fixes

### Not possible to trigger download of DOM files [ID 46221]

It could occur that it was not possible to trigger the download action for DOM files from the application.

The underlying script logic and related low-code app configuration have been updated to ensure that the download action will no function correctly in the app.

### Network share credentials and attachment settings overwritten when reinstalling the solution [ID 46221]

When the DocumentOps Solution was reinstalled, it could occur that the existing network share credentials and attachment settings were overwritten. This issue has been resolved.

### Incorrect relative path for local storage [ID 46221]

The relative path for local storage was incorrect, which could make it impossible to preview or download the selected files. This has been corrected.
