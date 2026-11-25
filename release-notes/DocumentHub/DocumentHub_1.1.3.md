---
uid: DocumentHub_1.1.3
---

# DocumentHub 1.1.3

## Prerequisites

> [!NOTE]
> This version requires:
>
> - DataMiner 10.6.0 [CU2], 10.6.5, or higher
> - .NET Framework 4.8
> - [Standard Data Model Registration](https://catalog.dataminer.services/details/52173e49-9185-4772-9b60-c186ee365a81) 2.0.x

## New features

### Create a default local-files bucket during deployment [ID 46838]

When you deploy DocumentHub, it now creates a default *Local* bucket that points to `/`. You can use this bucket to access local files without creating a bucket manually.

### OpenAPI specification generation for DocumentHub user-defined APIs [ID 46903]

OpenAPI specifications are now available for DocumentHub user-defined APIs. Use them to review the available API operations and understand how to integrate your applications with DocumentHub.

## Changes

## Enhancements

### Remove DocumentHub-specific guardrails from the Assistant agent [ID 46904]

When you use the Assistant agent to delete files or buckets, or to download files, it no longer displays DocumentHub-specific confirmation prompts or warnings. This removes extra steps from these workflows.
