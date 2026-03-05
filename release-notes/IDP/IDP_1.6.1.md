---
uid: IDP_1.6.1
---

# IDP 1.6.1

### Enhancements

#### Network file caching introduced for faster file searches [ID 44834]

Network file caching has been introduced to improve performance when searching for configuration backup files stored on network shares.

#### Comparison tool now opens in the browser and supports comparing full or core backups [ID 44896]

To improve performance, the Comparison tool is now opened in the browser instead of being embedded.

In addition, users can now choose whether they want to compare the full backups or only the core from within the main UI.

#### Further improved Comparison tool performance for large files [ID 44897]

The Comparison tool now requires less CPU and memory when comparing large configuration backup files.