---
uid: KI_DxM_startup_failure_NET_10_0_12
description: "Learn how to identify and resolve intermittent DxM startup failures caused by a .NET 10.0.12 runtime regression."
---

# DxMs fail to start with .NET 10.0.12

## Affected versions

Any DataMiner version can be affected when a DxM runs on .NET 10.0.12 and all of the following conditions apply:

- The host runs Windows Server 2016, Windows Server 2019, or Windows 10.
- The host has more than one processor group.
- .NET 10.0.12 is the highest installed .NET 10.0 runtime.

Windows 11 and Windows Server 2022 and later are not affected.

## Cause

A [.NET 10.0.12 garbage collector regression](https://github.com/dotnet/runtime/issues/135221) can cause memory corruption at startup on systems with more than one processor group when a process uses Server GC. Most DxMs use Server GC, which is the ASP.NET Core default.

.NET Framework processes such as SLNet and SLDataGateway are not affected.

## Fix

Install the latest [.NET 10 Hosting Bundle](https://dotnet.microsoft.com/en-us/download/dotnet/10.0), version 10.0.13 or later, and restart DataMiner.

The runtime issue was fixed in .NET 10.0.13; no DataMiner fix is needed.

## Description

DataMiner Extension Modules (DxMs) can intermittently fail to start. A retry often succeeds. If BrokerGateway fails to start, DataMiner does not start, and SLDMS logs a message containing `Failed setting up NATS session` and `code 404`.<!-- https://collaboration.dataminer.services/task/313033 -->

The issue has been observed in BrokerGateway, CloudGateway, APIGateway, DataAPI, FieldControl, EdgeNode, UserDefinableApiEndpoint, DataAggregator, CloudFeed, and DataMiner Web.

The Windows Application event log may show an error for a DxM process involving *coreclr.dll* version 10.0.1226.42308, exception `0xc0000005`, and offset `0x2a038`, or *ntdll.dll* with exception `0xc0000374` indicating heap corruption.

To check whether the host meets the conditions for this issue:

1. Run `dotnet --list-runtimes` and check whether 10.0.12 is the highest `Microsoft.NETCore.App` 10.0 version.
1. Check whether the host runs Windows Server 2016, Windows Server 2019, or Windows 10.
1. Run `Coreinfo -g` using the Sysinternals Coreinfo tool and check whether it lists more than one processor group.
