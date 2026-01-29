---
uid: KI_Possible_overbooking_in_SRM
---

# Possible resource overbooking in SRM

## Affected versions

SRM setups using DataMiner 10.5.12 or higher.

Main Release versions are not affected.

## Cause

From DataMiner 10.5.12 onwards, only the first 1000 overlapping bookings returned by the database are taken into account when calculating resource availability. This can cause overbookings on resources.

## Fix

No fix is available yet.<!-- RN 44649 -->

## Description

When a booking is created that overlaps with more than 1000 other bookings, SRM will only use 1000 bookings to calculate the resource availability. This can cause overbookings on resources.
