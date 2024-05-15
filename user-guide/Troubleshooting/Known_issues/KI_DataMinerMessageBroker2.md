---
uid: KI_DataMinerMessageBroker2
---

# Various issues when using MessageBroker with chunking

## Affected versions

- 10.3.0 Main Release versions from DataMiner 10.3.0 [CU5] onwards.

- DataMiner 10.3.8 to 10.3.11.

## Cause

DataMiner 10.3.8/10.3.0 [CU5] introduces a change to the way DataMiner MessageBroker handles chunked messages: Every request/response chunk now needs to be acknowledged to ensure it has arrived, to prevent the sender from waiting for messages that never return. However, this has been implemented in a way that could cause a buildup of tasks, especially in very busy systems. This can result in messages not getting acknowledged in time, which can lead to various issues.

## Fix

Install DataMiner 10.4.0 or 10.4.1.<!--RN 37532-->

## Description

There is a buildup of messages in NATS, which can lead to various issues.
