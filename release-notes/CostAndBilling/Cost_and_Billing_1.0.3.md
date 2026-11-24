---
uid: Cost_and_Billing_1.0.3
description: "Learn about Cost & Billing 1.0.3, which fixes synchronization failures caused by adapter timeouts when processing billable events, groups, and items."
---

# Cost & Billing 1.0.3

## Fixes

### Adapter timeouts could cause synchronization to fail [ID 47188]

When synchronizing billable events, groups, and items, the Cost & Billing app could stop working because adapter execution timed out. To prevent these timeouts, the Interface Script now enables asynchronous adapter execution.
