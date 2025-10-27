---
uid: KI_SRM_scheduler_unresponsive
---

# SRM scheduler unresponsive

## Affected versions

DataMiner 10.5.6 and 10.5.7

## Cause

DataMiner 10.5.6 includes improvements to the Resource Manager caching, introducing throttling to reduce latency. However, under specific conditions, this throttling can cause the SRM scheduler to become unresponsive. This happens when asynchronous and synchronous booking tasks compete for limited cache access slots, exhausting the available thread pool and preventing progress.

## Fix

Install DataMiner 10.5.8/10.6.0 or higher. <!--RN 43295-->

## Description

An SLNet runtime error occurs on the SRM event thread. Bookings do not transition to the correct state, and it can occur that booking actions are not executed. When booking information is requested from or updated in Resource Manager, there is a delay.
