---
uid: DocumentHub_1.1.2
---

# DocumentHub 1.1.2

## Prerequisites

> [!NOTE]
> This version requires:
>
> - DataMiner 10.6.0 [CU2], 10.6.5, or higher
> - .NET Framework 4.8
> - [Standard Data Model Registration](https://catalog.dataminer.services/details/52173e49-9185-4772-9b60-c186ee365a81), versions 2.0.X are supported.

## New features

### DownloadFile Automation & Agent Support [ID 46386]

Implemented a new DocumentHub Agent capability to **download files via a temporary folder workflow**, enabling safer and more reliable file retrieval while aligning with the existing UDAPI and capability-based architecture. This feature extends the agent’s file-operation support and lays the foundation for consistent download handling in the 1.1.x revision line.

- Added **DownloadFile automation script** support.
- Added **DocumentHub-Agent support** for download-related flows.

## Improvements

- Improved integration between DocumentHub backend operations and agent-driven usage.
