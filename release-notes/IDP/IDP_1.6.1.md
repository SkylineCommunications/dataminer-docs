---
uid: IDP_1.6.1
---

# IDP 1.6.1

## Changes

### Enhancements

#### Network file caching introduced for faster file searches [ID 44834]

Network file caching has been introduced to improve performance when searching for configuration backup files stored on network shares.

#### Improved Comparison tool performance for large files [ID 44897]

The Comparison tool now requires less CPU and memory when comparing large configuration backup files.

> [!IMPORTANT]
> This enhancement is only available with DataMiner Web Upgrade version 10.6.5 or higher.

### Fixes

#### Comparison tool settings could not be changed during configuration comparisons [ID 44896]

The ability to change comparison settings during configuration comparisons has been restored. Users can once again adjust options such as difference highlighting and collapsing common lines, with the Comparison tool now opening in a separate browser window.

In addition, users can now choose whether they want to compare the full backups or only the core from within the main UI.