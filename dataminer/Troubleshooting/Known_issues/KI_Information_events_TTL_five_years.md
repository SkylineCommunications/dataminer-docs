---
uid: KI_Information_events_TTL_five_years
---

# Unable to override information events TTL of 5 years

## Affected versions

Any versions using a Cassandra Cluster setup.

## Cause

The default TTL for information events is set to 5 years instead of the preferred default of 1 year.

## Workaround

1. Stop DataMiner.

1. Open the file `C:\Skyline DataMiner\database\DBMaintenanceDMS.xml`.

1. Add the following tag:

   ```xml
   <TTL type="Info" default="1Y">
           <Local>3M5D</Local>
           <Indexing>3M5D</Indexing>
   </TTL>
   ```

   This configuration sets a default TTL of 1 year but specifies an actual TTL of 3 months and 5 days.

   > [!NOTE]
   > Replace `3M5D` (3 months, 5 days) with your preferred TTL value.

1. Save and close the file.

1. Start DataMiner.

## Fix

No fix is available yet. <!--Task IDs: 244451 & 244733-->

## Description

In DataMiner Systems using a Cassandra Cluster setup, the default TTL of 5 years for information events cannot be overridden. This may lead to storage issues over time.
