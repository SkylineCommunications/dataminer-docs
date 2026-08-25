---
uid: DocumentHub_1.1.1
---

# DocumentHub 1.1.1

## Prerequisites

> [!NOTE]
> This version requires:
>
> - DataMiner 10.6.0 [CU2], 10.6.5, or higher
> - .NET Framework 4.8
> - [Standard Data Model Registration](https://catalog.dataminer.services/details/52173e49-9185-4772-9b60-c186ee365a81), versions 2.0.X are supported.

## New features

### Updated DevPack versions to 1.1.1: support for Graph API v5 [ID 46228]

The DocumentHub DevPacks (`Skyline.DataMiner.Dev.Utils.Solutions.DocumentHub`, `.GQI`, and `.Automation`) have been updated to version **1.1.1**.

This update upgrades the underlying SharePoint integration from the deprecated Microsoft Graph SDK v4 to **Microsoft Graph API v5**, which brings:

- **Long-term support alignment**: Graph API v5 is the current stable release and will be supported well beyond the v4 end-of-life date.
- **Improved authentication flows**: Modernized token acquisition and permission scopes aligned with the latest Azure AD/Entra ID recommendations.
- **Expanded SharePoint capabilities**: Access to newer Graph endpoints for site and document library operations, enabling future feature enhancements without requiring a breaking upgrade.
- **Bug fixes and reliability improvements** included in the SDK upgrade.

> [!NOTE]
> Existing SharePoint configurations (Tenant ID, Client ID, Site URL) do not need to be changed. The upgrade is transparent to end users.

### Implemented KQL (Keyword Query Language) as searchable storage for SharePoint [ID 46228]

SharePoint-backed buckets now use **KQL (Keyword Query Language)** as the query engine when searching for files within a SharePoint document library.

Key benefits:

- **Full-text search** across file names, metadata, and document content indexed by SharePoint — not just prefix/substring matching.
- **Faster search results** by leveraging SharePoint's native search index instead of iterating over all files in a library.
- **Flexible query syntax**, with support for keyword combinations, property-scoped queries (e.g., `Author:`, `FileType:`), and wildcards, enabling richer filtering in future UI enhancements.
- **Scalability**: Performs well in large document libraries where a brute-force file enumeration would time out or degrade performance.

> [!NOTE]
> This change affects SharePoint storage sources only. Local and DOM (network share) buckets are not impacted.
