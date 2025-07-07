---
uid: SCH_Recurring
---

# Recurring jobs

## Making a job recurring

1. [create a job](xref:SCG_Create_Job) as template that is still in the future (you can duplicate jobs that are already in the past or already started).

   > [!IMPORTANT]
   > It is important that this instance represents the template of the series as good as possible before turning it into a recurring job. When you make this job recurring all jobs will be created and it will only be possible to update all individual jobs afterwards. It is still possible to cancel and delete all jobs of an occurrence if a mistake was made.

1. Click on the Context menu of the job from the *Job View* page and select *Make Recurring*.

   ![Make Recurring](~/solutions/images/Scheduling_Make_Recurring.png)

1. Fill in the details of the pattern.

   > [!NOTE]
   > The pattern can't be changed after creating the series

1. Optionally, you can still change the timings of the job and the desired job state.

   > [!NOTE]
   > The job start time will be translated by default to UTC time. If needed, you can pick a different timezone and update the start time accordingly. When using a timezone that supports daylights savings, the jobs will be created so that the start time is always valid for the given date.

1. Click *Create Recurrence*.

   This will update the first instance and create an entry in the *Recurring Job View* page. There you can track the *Process status* indicating if all jobs were created successfully.

## Cancelling a recurring job

When cancelling an active recurring job, all jobs part of the recurrence that are still in the future will be canceled.

1. Open the *Edit recurring job* panel from the *Recurring Job View* page.

1. Click *Cancel Recurrence*.

## Deleting a recurring job

If a recurring job is *Completed* (all jobs part of the series are in the past) or *Canceled* it is possible to delete the recurring job and optionally all jobs that were part of the recurring job.

   > [!NOTE]
   > If you only delete the recurrence only, then the individual jobs will still show the link to a recurring job, but the link will be broken.

1. Open the *Edit recurring job* panel from the *Recurring Job View* page.

1. Click *Delete Recurrence*.
