---
uid: KI_stable_trend_points_not_kept_alive
---

# Stable trend points not kept alive

## Affected versions

- DataMiner 10.2.0 [CU8] up to 10.2.0 [CU10]
- DataMiner 10.2.10 up to 10.3.1

## Cause

DataMiner should regularly rewrite stable trend data points to keep them alive, but this does not happen correctly.

## Fix

Install DataMiner 10.2.0 [CU11] or 10.3.2. <!-- RN 35139 -->

## Issue description

Trend graphs for parameters with few value changes show "No Data". This mainly occurs with real-time trending.
