---
uid: DocumentHub_1.1.2
---

# DocumentHub 1.1.2 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

## Prerequisites

> [!NOTE]
> This version requires:
>
> - DataMiner 10.6.0 [CU2], 10.6.5, or higher
> - .NET Framework 4.8
> - [Standard Data Model Registration](https://catalog.dataminer.services/details/52173e49-9185-4772-9b60-c186ee365a81) 2.0.x

## New features

### Support for downloading files via temporary folder workflow [ID 46386]

The DocumentHub agent now supports downloading files via a temporary folder workflow, enabling safer and more reliable file retrieval while aligning with the existing UDAPI and capability-based architecture. This feature extends the agent’s file operation support and lays the foundation for consistent download handling in the 1.1.x revision line.

For this purpose, a new *DownloadFile* automation script has also been introduced.

## Changes

### Enhancements

#### Improved integration between agent and backend operations [ID 46386]

The integration between DocumentHub backend operations and agent-driven usage has been improved.
