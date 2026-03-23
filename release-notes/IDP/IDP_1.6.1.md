---
uid: IDP_1.6.1
---

# IDP 1.6.1

## Changes

### Enhancements

#### Network file caching introduced for faster file searches [ID 44834]

Network file caching has been introduced to improve performance when searching for configuration backup files stored on network shares.

#### Improved Comparison tool performance for large files [ID 44897]

The Comparison tool now requires less CPU and memory usage when comparing large configuration backup files.

> [!IMPORTANT]
> This enhancement requires DataMiner web 10.5.0 [CU14]/10.6.0 [CU2]/10.6.5 or higher.

### Fixes

#### Comparison tool settings could not be changed during configuration comparisons [ID 44896]

While comparing configurations in the Comparison tool, it was not possible to change any of the comparison settings. Now the Comparison tool will open in a separate browser window, allowing users to adjust settings again, such as highlighting differences and collapsing common lines.

In addition, users can now choose whether they want to compare the full backups or only the core from within the main UI.
