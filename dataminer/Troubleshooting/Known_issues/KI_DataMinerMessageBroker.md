---
uid: KI_DataMinerMessageBroker_Chunking_MaxPayload
---

# Max Payload exceptions occur when using MessageBroker with chunking

## Affected versions

From DataMiner 10.3.0 [CU5]/10.3.8 onwards.

## Cause

An issue can occur when MessageBroker uses chunking, which employs the memory allocation method [Array Pooling](https://learn.microsoft.com/en-us/dotnet/api/system.buffers.arraypool-1?view=net-7.0). In some cases, the generated chunks are not trimmed to the correct size before transmission. This issue is most likely to occur with messages that need to be split into multiple chunks.

## Fix

Install DataMiner 10.4.0/10.4.1<!--RN 37245-->.

## Description

When using DataMinerMessageBroker with chunking, it is possible to encounter *Max Payload* exceptions, which indicate that the packets DataMiner is trying to send are too large.
