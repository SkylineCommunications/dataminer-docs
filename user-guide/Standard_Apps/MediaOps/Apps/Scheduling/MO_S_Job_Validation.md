---
uid: MO_S_Job_Validation
---

# Validating upcoming jobs

When a job is created it contains configuration, resources, ... It is possible that a resource was deleted, configuration requirements changed, etc. before the booking was able to start. To avoid that these issues are only discovered at the start of the booking during the automated orchestration, it is possible to detect this with the job validation feature. The validation runs on a regular basis for a defined time window. This validation can be customized to tailor it to the needs of the use-case of the system.

## Scheduled Task

When the MediaOps package is installed a scheduled task will be added or updated if not marked as customized. The scheduled task will be called 'MediaOps Job Validation' and will be by default enabled. It is possible to customize the Schedule to fit more the needs of the use-case. To avoid that during an update of MediaOps the scheduled task is updated again, set the description of the scheduled task to contain 'customized'.

## Validation Script

By default the scheduled task will trigger the default validation script 'Scheduling_Validate Upcoming'. This script contains validation tests that covers the most common use-cases. It is possible to customize the validation script (e.g. to add ChatOps notifications or to add additional tests). To customize you duplicate the script with a new name and update the scheduled task to execute the custom script instead (don't forget to add 'customized' in the description of the scheduled task).

Below tests are part of the default script:

| Test Name | Description |
|--|--|
|TBD|TBD|
