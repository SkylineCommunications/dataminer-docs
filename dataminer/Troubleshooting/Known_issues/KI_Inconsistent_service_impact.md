---
uid: KI_Inconsistent_service_impact
---

# Inconsistent service impact of alarms after element is stopped and restarted

## Affected versions

All currently supported DataMiner versions.

## Cause

When an element is stopped and then excluded from a service, the status of the element cannot be updated in the service because the element is not available. While an element should notify a service of its exclusion when it is started up, something goes wrong with this flow. Because of this, the service impact of the element's alarms is not correctly updated.

## Workaround

Unassign the alarm template from the element and then assign it again.

## Fix

No fix is available yet. <!--Task ID: 208267-->

## Description

When a stopped element is removed from a service and then restarted, the service impact of alarms on the element can be inconsistent. It can occur that the service still has alarms of the element, or that the service has no alarms even when alarms are expected.
