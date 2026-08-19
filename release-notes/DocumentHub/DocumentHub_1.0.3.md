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

### Added User-Defined APIs [ID 46221]

- Added User-Defined APIs (UDAPIs) to expose custom actions and data through a standard API interface.

- These APIs can be consumed through the Agent or the default UDAPI endpoint, enabling integration with other systems and supporting workflow automation.

- They are intended for use cases where teams need lightweight, reusable endpoints to retrieve information, trigger actions, or connect DocumentHub with external applications without developing custom integrations from scratch.

- This functionality is also ready to support DataMiner Assistant (AI) scenarios, making it easier to expose DocumentHub capabilities to AI-driven interactions and assistants.

## Fixes

### DOM File Downloads [ID 46221]

- Fixed an issue where users could not trigger the download action for DOM files from the application.

- Updated the underlying script logic and related LCA configuration so the Download action works correctly when selected in the app.

### Preserve the existing network share attachment settings when reinstalling the solution [ID 46221]

- Fixed an issue where reinstalling the solution could overwrite the existing network share credentials and attachment settings.

- Users can now reinstall the solution without losing their configured network share connection details.

### Fixed GetRelativePath [ID 46221]

- The relative path for Local Storage was incorrect, causing that user could not preview or download the selected files.
