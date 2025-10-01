---
uid: KI_Trend_flatline_different_time_zones
---

# Trend graph flatline when client and DMA use different time zones

## Affected versions

From DataMiner Cube 10.4.0 [CU17]/10.5.0 [CU5]/10.5.8 onwards.

## Cause

In DataMiner Cube 10.4.0 [CU17]/10.5.0 [CU5]/10.5.8, a change is introduced to the way trend data is loaded. Before this version, when a period like *Last day* or *Last week* is requested, the system always requests all data up to the current time. To reduce the amount of data requested, from DataMiner Cube 10.4.0 [CU17]/10.5.0 [CU5]/10.5.8 onwards, only additional data is requested (e.g. *Last week* no longer re-requests the *Last day* data if it has already been retrieved).

However, this causes a flatline issue in some specific cases, because requests for *Last day* use the client's time zone, but requests for longer ranges (e.g. *Last week*) use the DataMiner Agent's time zone, and these no longer include the data from shorter ranges (e.g. *Last day*) that have already been retrieved.

This means that when the client's time zone is different from the DataMiner Agent's time zone, part of the data is skipped, resulting in a flatline on the graph.

## Workaround

Set the client's time zone to match the DataMiner Agent's time zone.

## Fix

Install DataMiner 10.4.0 [CU20]/10.5.0 [CU8]/10.5.10 [CU1]. <!-- RN 43757 -->

## Description

When the client's time zone is ahead of the DMA's time zone, trend graphs show a flatline for the hours covered by the time zone difference. This flatline typically starts 24 hours ago and continues for the duration of the time zone offset.
