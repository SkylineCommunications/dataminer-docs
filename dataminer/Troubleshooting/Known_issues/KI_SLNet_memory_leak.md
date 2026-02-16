---
uid: KI_SLNet_memory_leak
---

# SLNet memory leak related to indexing logic for Cube search bar

## Affected versions

From DataMiner 10.5.2 onwards.

## Cause

SLNet indexes various aspects of elements and protocols for the Cube search bar. By default, this includes all trended parameters. Because of an issue introduced in DataMiner 10.5.2 (RN41643), this is not cleaned up correctly, leading to duplicate entries being kept in the SearchManager in SLNet, consuming more and more memory.

## Fix

Install DataMiner 10.5.4 or 10.6.0.<!-- RN 42544 -->

## Workaround

Exclude parameters from the search bar indexing:

1. Open the [SLNetClientTest tool](xref:SLNetClientTest_tool) and [connect to the DMA](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Navigate to *Advanced* > *Options* > *SLNet Options*.

1. In the dropdown list next to *Option values for*, select *SearchOptions*.

1. For each listed Agent:

   1. Right-click the *Value* column
   1. Select *Edit Value*
   1. Specify `ExcludeParams`.
   1. Click *OK*.

1. Click *OK* to apply the changes and close the window.

This will stop the memory leak, but it will cause parameters to be excluded from the search bar in Cube. If you want to free up the memory, a DataMiner restart will also be required.

If you do still notice a memory leak after this, you can disable the search bar indexing completely by specifying `disable` instead of `ExcludeParams`, but this will disable the feature completely, making it impossible to for instance look up an element via the search bar. To enable the feature again, set the value to `trendedParamsOnly` again.

## Description

In systems with many trended parameters, especially in case a parameter name is unusually long, there is a slight increase in SLNet memory usage every time an ElementInfoMessage gets sent (e.g., when an element is restarted or edited, or when an element property is changed).
