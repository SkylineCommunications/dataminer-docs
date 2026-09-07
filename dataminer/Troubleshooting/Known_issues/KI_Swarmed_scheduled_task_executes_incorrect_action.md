---
uid: KI_Swarmed_scheduled_task_executes_incorrect_action
description: Learn why a swarmed scheduled task can execute another task's action after it is edited and how to work around this issue.
---

# Swarmed scheduled task executes incorrect action after editing

## Affected versions

Feature Release versions from DataMiner 10.6.3 onwards.

## Cause

When a [scheduled task is swarmed](xref:SwarmingScheduledTasks) and subsequently edited, it can incorrectly be assigned the action ID of an existing scheduled task. As a result, two scheduled tasks can reference the same action, even though each action should be unique.

## Fix

No fix is available yet.

## Workaround

Recreate the affected scheduled task so that it is assigned a new action ID.

Until a fix is available, avoid swarming scheduled tasks. While the issue only occurs when a swarmed task is subsequently edited, this is the safest way to prevent it.

## Description

A scheduled task can execute an incorrect action, for example, an Automation script intended for another scheduled task.
