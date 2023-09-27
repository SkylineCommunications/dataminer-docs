---
uid: KI_SLProtocol_memory_leak_HTTP
---

# SLProtocol memory leak when HTTP connectors are used

## Affected versions

- DataMiner Main Release versions 10.1.0 [CU19] and 10.2.0 [CU7].
- DataMiner Feature Release versions 10.2.8 to 10.2.11.

## Cause

A double allocation could occur for an HTTP header defined in a connector, causing a memory leak for every HTTP request sent using such a header.

## Fix

Upgrade to DataMiner 10.1.0 [CU20], 10.2.0 [CU8], or 10.2.11 [CU1].

## Issue description

When connectors make HTTP requests, SLProtocol uses a continually increasing amount of memory without a clear reason.
