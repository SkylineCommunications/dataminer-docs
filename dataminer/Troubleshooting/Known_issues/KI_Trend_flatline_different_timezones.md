---
uid: KI_Trend_flatline_different_timezones
---

# Trend graph flatline when client and DMA use different timezones

## Affected versions

This issue occurs in DataMiner 10.5.8 and later.

## Cause

The method for loading trend data has changed.  
- **Before 10.5.8**: When requesting periods like *Last day* or *Last week*, the system always requested all data up to the current time.  
- **From 10.5.8 onwards**: To reduce the amount of data requested, only additional data is requested (e.g. *Last week* no longer re-requests the *Last day* data if it has already been retrieved).  

The issue arises because:  
- Requests for *Last day* use the **client's timezone**.  
- Requests for longer ranges (e.g. *Last week*) use the **DataMiner Agent's timezone**, and unlike before, they no longer include the data from shorter ranges (e.g. *Last day*) that have already been retrieved.

When these timezones differ, part of the data is skipped, resulting in a flatline on the graph.

## Workaround

Set the client's timezone to match the DataMiner Agent's timezone.

## Fix

No fix is available yet.

## Description

If the client's timezone is **ahead of** the DMA's timezone, the trend graph will show a flatline for the hours covered by the timezone difference. This flatline typically starts 24 hours ago and continues for the duration of the timezone offset.
