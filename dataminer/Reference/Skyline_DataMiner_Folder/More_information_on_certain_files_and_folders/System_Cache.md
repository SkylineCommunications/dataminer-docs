---
uid: System_Cache
---

# System Cache

The `C:\Skyline DataMiner\System Cache\` directory of a DMA contains synchronization information and cached data.

> [!NOTE]
> Everything in this directory can be deleted, EXCEPT the files of which the name contains “DO_NOT_REMOVE”.

## Files in this directory

### {DO_NOT_REMOVE\_\[\*\]}.txf

Synchronization information: Files changed

Example: {DO_NOT_REMOVE_C0E05277-A7C5-4969-904D-E2E52076400A}.txf

> [!WARNING]
> Do not remove this file!

### {DO_NOT_REMOVE\_\[\*\]}.txf

Synchronization information: Files added

Example: {DO_NOT_REMOVE_1DFB0EC4-5D32-4b1c-987E-8BE3302C6DB5}.txf

> [!WARNING]
> Do not remove this file!

### {CACHED_REDUNDANCY\_\[\*\]}.txf

Information on cached redundancy groups (Cleared at DataMiner startup)

Example: {CACHED_REDUNDANCY_35525262-F518-4ce5-AD2D-D8672D89278F}.txf

### {CACHED_SERVICES\_\[\*\]}.txf

Information on cached services (Cleared at DataMiner startup)

Example: {CACHED_SERVICES_35525262-F518-4ce5-AD2D-D8672D89278F}.txf

### \[\*\]\_STD\_\[\*\].txf

Cached XML data (Cleared at DataMiner startup)

Example: 1_STD_DATAMINER.txf

### YYYY_MM_DD HH_MM_SS_C%3A%5CSkyline%20DataMiner\[\*\].zip

Compressed files used during synchronization

## Subdirectories

### SLNet

This subdirectory contains the following files:

| File(s)                     | Description                                         |
|-----------------------------|-----------------------------------------------------|
| startup.txt                 | Information on the last six startups                |
| protocol\_\[\*\].bin        | Information on cached Protocols (for SLNet)         |
| elementProtocol\_\[\*\].bin | Information on cached Element Protocols (for SLNet) |

### Local/Failover/Offload

These three subdirectories are used for pushing data to the database. They contain subfolders that refer to database tables (e.g., “alarm” or “data123”).

Each of them can contain files like “2010_11_10_09_22_28_6348_210.dat” or “2010_11_10_09_22_28_6348_210.sql”, ready to be inserted into either the general or the offload database, or ready to be forwarded to the backup DMA (in case of Failover).
