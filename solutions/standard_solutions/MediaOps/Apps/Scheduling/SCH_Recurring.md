---
uid: SCH_Recurring
---

# Working with recurring jobs

## Making a job recurring

1. [Create a job](xref:SCH_Create_Job) scheduled in the future as a template.

   To quickly create a job, you can duplicate a job that is in the past or that has already started.

1. Configure your job so that it matches the configuration for the series of job you want to create as well as possible.

   > [!IMPORTANT]
   > When a job is made recurring, all job instances based on that job will be created immediately, and you will only be able to update individual instances afterwards. If necessary, you can [cancel](#canceling-a-recurring-job) and [delete](#deleting-a-recurring-job) all instances of a recurring job if you made a mistake.

1. Click on the Context menu of the job from the *Job View* page and select *Make Recurring*.

   ![Make Recurring](~/solutions/images/Scheduling_Make_Recurring.png)

1. Fill in the details of the pattern.

   > [!NOTE]
   > The pattern cannot be changed after creating the series.

1. Optionally, you can still change the timings of the job and the desired job state.

   > [!NOTE]
   > The job start time will be translated by default to UTC time. If needed, you can pick a different timezone and update the start time accordingly. When using a timezone that supports daylights savings, the jobs will be created so that the start time is always valid for the given date.

1. Click *Create Recurrence*.

   This will update the first instance and create an entry in the *Recurring Job View* page. There you can track the *Process status* indicating if all jobs were created successfully.

## Canceling a recurring job

When canceling an active recurring job, all jobs part of the recurrence that are still in the future will be canceled.

1. Open the *Edit recurring job* panel from the *Recurring Job View* page.

1. Click *Cancel Recurrence*.

## Deleting a recurring job

If a recurring job is *Completed* (all jobs part of the series are in the past) or *Canceled* it is possible to delete the recurring job and optionally all jobs that were part of the recurring job.

   > [!NOTE]
   > If you only delete the recurrence only, then the individual jobs will still show the link to a recurring job, but the link will be broken.

1. Open the *Edit recurring job* panel from the *Recurring Job View* page.

1. Click *Delete Recurrence*.
