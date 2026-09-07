---
uid: MediaOps_Live_1.2.0
description: Highlights of the features, enhancements, and fixes included in the MediaOps Live 1.2.0 release, including improved CSV encoding.
---

# MediaOps Live 1.2.0 - Preview

> [!IMPORTANT]
> We are still working on this release. Release notes may still be modified, added, or moved to a later release. Check back soon for updates!

## Enhancements

*No enhancements have been added to this release yet.*

## Fixes

### CSV import and export could handle special characters incorrectly [ID 46381]

When importing endpoint or virtual signal group data from CSV files, special characters such as the degree symbol (°) could be parsed incorrectly, especially in files saved using the legacy Microsoft Excel CSV format.

CSV imports now support both UTF-8 and Windows-1252 encoding, preserving special characters during import and provisioning. CSV exports now use UTF-8 encoding with a byte order mark (BOM), allowing Microsoft Excel to detect the encoding correctly when opening exported files.
