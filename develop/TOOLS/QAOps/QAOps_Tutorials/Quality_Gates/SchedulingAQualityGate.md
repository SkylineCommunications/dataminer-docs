---
uid: QAOps_Tutorials_Scheduling_A_Quality_Gate
description: Configure a daily QAOps quality gate digest with a notification rule, a five-field cron expression, an explicit time zone, and schedule previews.
---

# Scheduling a quality gate digest

In this tutorial, you will set up a daily status digest for your quality gate at 09:00 Brussels time.

Expected duration: 15 minutes.

> [!IMPORTANT]
> A digest schedule does not run tests. It reevaluates available evidence and queues a status snapshot for matching notification rules. Automatic gate-execution schedules are not currently available. Use a separate pipeline or scheduler to produce new QAOps runs and external reports.

## Prerequisites

- A gate on [QAOps Staging](https://qaopsstaging-skyline.on.dataminer.services/public/qaops-quality-gates/index.html) with access to its *Automation* settings.

- A notification destination you are authorized to use.

- For email, configured DataMiner SMTP. For Teams, a supported Teams Workflow URL and the required QAOps notification configuration.

The screenshots show a paused example to avoid sending practice messages. Use your own destination, not the example address.

## Step 1: Create a digest notification rule

1. Open your gate.

1. Select *Automation*.

1. Click *New notification rule*.

1. Select the *Digest* trigger.

   Other triggers can notify you of failures, warnings, recovery, or completed executions. For this exercise, select only the digest trigger.

1. Click *Add email destination*.

1. Enter a destination label.

1. Enter your authorized email recipients.

   Separate multiple recipients with semicolons. Alternatively, add a *Teams Workflow* destination and enter its HTTPS workflow URL. Treat that URL as a secret.

   ![Notification rule configured with the digest trigger and an example email destination](~/develop/images/QAOps_QualityGates_DigestRule.png)

1. Select *Rule enabled (uncheck to pause)* when you are ready to use the destination.

1. Click *Save notification rule*.

   Saving the rule will not send a message. If you use the saved rule's test-send action, it will send a real notification.

## Step 2: Configure the daily schedule

1. In *Automation*, click *New digest schedule*.

1. Enter `0 9 * * *` in *Five-field cron (Cronos)*.

   The five fields are minute, hour, day of month, month, and day of week. This expression means every day at 09:00.

1. Set *Time zone (IANA or Windows)* to `Europe/Brussels`.

   Use `UTC` instead if you want a fixed UTC time throughout the year. An explicit time zone avoids depending on your browser's local time.

1. Click *Preview current draft*.

   Check that the upcoming occurrences match your intended local time.

   ![Daily digest schedule with cron expression 0 9 * * *, Europe/Brussels time zone, and previewed occurrences](~/develop/images/QAOps_QualityGates_DigestSchedule.png)

1. Select *Schedule enabled (uncheck to pause)* when you are ready for it to take effect.

1. Click *Save schedule*.

## Step 3: Verify the setup

1. Confirm that the saved rule includes the digest trigger and the intended destination.

1. Confirm that the saved schedule is enabled and has the expected next occurrence.

1. After an occurrence, inspect schedule history and notification delivery information in *Automation*.

   A queued snapshot is not the same as confirmed delivery. Check delivery information if no message arrives.

The scheduler does not replay missed occurrences after downtime. For daylight saving changes, nonexistent local times are skipped and repeated local times run once. Choose a time such as 09:00 to avoid the usual overnight clock changes.

For other schedules, `0 * * * *` means hourly, and `0 9 * * 1-5` means weekdays at 09:00. The default minimum supported interval is 15 minutes.

Pause practice schedules and notification rules when you no longer need them.
