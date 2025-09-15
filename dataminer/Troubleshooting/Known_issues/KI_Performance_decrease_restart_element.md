---
uid: KI_Performance_decrease_restart_element
---

# Performance decrease when restarting elements that export large numbers of DVEs or VFs

## Affected versions

DataMiner 10.5.9.

## Cause

DataMiner 10.5.9 introduces a change that causes an extra database flush for every DVE or virtual function exported by an element that gets stopped or unloaded. The total time for these flushes can be quite high, especially if the database is hosted remotely. For example, for a setup with a remote Cassandra cluster database, a delay of 10 seconds was observed for an element with 50 virtual functions.

## Fix

Install DataMiner 10.5.10.<!-- RN 43734 -->

## Description

After an upgrade to 10.5.9, restarting elements that export large numbers of DVEs or virtual functions takes much longer than usual.
