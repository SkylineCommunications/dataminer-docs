---
uid: KI_SLProtocol_memory_leak_HTTP
---

# SLProtocol memory leak when HTTP connectors are used

## Affected versions

- DataMiner Main Release versions from 10.1.0 [CU19] and 10.2.0 [CU7] onwards.
- DataMiner Feature Release versions from 10.2.8 onwards.

## Cause

A double allocation could occur for an HTTP header defined in a connector, causing a memory leak for every HTTP request sent using such a header.

## Fix

No fix is available yet.

## Issue description

When connectors make HTTP requests, SLProtocol uses a continually increasing amount of memory without a clear reason.
