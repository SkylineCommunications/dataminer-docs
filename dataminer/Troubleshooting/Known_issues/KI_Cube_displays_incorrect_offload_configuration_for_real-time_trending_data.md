---
uid: KI_Cube_displays_incorrect_offload_configuration_for_real-time_trending_data
---

# Cube displays incorrect offload configuration for real-time trending data

## Affected versions

From DataMiner Cube 10.3.7/10.4.0 onwards.

## Cause

A server change introduced in DataMiner 10.3.7/10.4.0 (RN 35679) changed the default value for the permanent indication from -1 to 0. This value determines whether real-time trending data should be offloaded permanently or temporarily. While a corresponding client update was planned to align with this change, it was not implemented at the time. As a result, Cube continued to interpret -1 as the marker value, leading to an incorrect display of offload configurations when real-time trending data is permanently offloaded.

## Fix

Available from DataMiner Cube 10.4.0 [CU14]/10.5.0 [CU2]/10.5.5<!--RN 42469-->.

## Description

When real-time trending data is configured for permanent offload, Cube displays an incorrect offload configuration.
