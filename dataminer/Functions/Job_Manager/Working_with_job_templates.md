---
uid: Working_with_job_templates
---

# Working with job templates

> [!IMPORTANT]
> The Jobs app is obsolete. It is not supported with [STaaS](xref:STaaS) and is no longer available from DataMiner 10.5.0 onwards.

It is possible to save a particular job configuration as a job template. This way you can later apply the template to immediately fill in the configured values.

> [!NOTE]
> The default fields *Name*, *Start Time* and *Stop Time*, as well as any auto-increment or booking fields are not included in job templates.

## Saving a job template

1. Create a job, applying the configuration you would like to have in the template, but do not save it.

   > [!TIP]
   > See also: [Manually adding a job](xref:Manually_adding_a_job)

1. In the top-right corner of the *New job* pane, click the downward arrow and select *Save template*.

1. Specify a name for the template.

1. In case you want this template to replace an existing template, in the filter box, select the template you want to replace.

1. Click *Save* or *Update*, depending on the selected options.

## Applying a job template

1. Create a job.

   > [!TIP]
   > See also: [Manually adding a job](xref:Manually_adding_a_job)

1. In the top-right corner of the *New job* pane, click the downward arrow and select *Apply template*.

1. In the *Load from template* dialog box, select the template you want to apply.

1. Click *Apply*.

## Deleting a job template

1. Create a job.

   > [!TIP]
   > See also: [Manually adding a job](xref:Manually_adding_a_job)

1. In the top-right corner of the *New job* pane, click the downward arrow and select *Apply template*.

1. In the *Load from template* dialog box, click the red recycle bin icon next to the template you want to delete.

1. In the confirmation box, click *Delete*.

1. Click *Cancel* to close the dialog box.

   Alternatively, you can also delete job templates while applying a different job template. In that case, select that template and click *Apply*.
