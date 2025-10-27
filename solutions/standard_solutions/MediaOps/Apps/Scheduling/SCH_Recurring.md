---
uid: SCH_Recurring
---

# Working with recurring jobs

<!-- RN 43043 -->

## Making a job recurring

1. [Create a job](xref:SCH_Create_Job) scheduled in the future as a template.

   To quickly create a job, you can duplicate a job that is in the past or that has already started.

1. Configure your job so that it matches the configuration for the series of jobs you want to create as much as possible.

   > [!IMPORTANT]
   > When a job is made recurring, all job instances based on that job will be created immediately, and you will only be able to update individual instances afterwards. If necessary, you can [cancel](#canceling-a-recurring-job) and [delete](#deleting-a-recurring-job) all instances of a recurring job if you made a mistake.

1. On the *Job View* page, click the ... button for the job and select *Make Recurring*.

   ![Make Recurring option](~/solutions/images/Scheduling_Make_Recurring.png)

1. Fill in the details of the pattern.

   > [!NOTE]
   > Keep in mind that you will not be able to change the pattern after you have created the recurrence.

1. Optionally, change the timing of the job and the desired job state.

   By default, the job start time will be translated to UTC time. If needed, you can pick a different time zone and update the start time accordingly. If you select a time zone that uses daylight saving time, the jobs will be created so that the start time is always valid for the given date.

1. Click *Create Recurrence*.

   This will update the job from which you started the action so it is the first instance in the series of recurring jobs, and it will create an entry on the *Recurring Job View* page that will make all other job instances get created in the background in the future. From the *Recurring Job View* page, you can track the *Process status*, which indicates if all jobs were created successfully.

   Jobs will be created up to one year in the future. On a daily basis, new jobs will be created for all recurring jobs if needed. This keeps the number of jobs linked to the recurring job under control when you create, cancel, or delete a recurring job.

## Canceling a recurring job

When an active recurring job is canceled, all recurring instances of this job that are scheduled in the future will be canceled if they are in the *Tentative* or *Confirmed* state, or deleted if they are in the *Draft* state.

To cancel a recurring job:

1. Go to the *Recurring Job View* page and click the pencil icon next to the job.

1. Click the *Cancel Recurrence* button.

## Deleting a recurring job

If a recurring job is *Completed* (i.e. all recurring instances of the job are in the past) or *Canceled*, it is possible to delete the recurring job and optionally all of its instances.

To do so:

1. Go to the *Recurring Job View* page and click the pencil icon next to the job.

1. Click the *Delete Recurrence* button.

> [!NOTE]
> If you delete the recurrence only, the individual job instances will still show the link to a recurring job, but this link will no longer work.
