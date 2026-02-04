---
uid: Overview_of_the_Job_Manager_app_UI
---

# Overview of the Jobs app UI

> [!IMPORTANT]
> The Jobs app is obsolete. It is not supported with [STaaS](xref:STaaS) and is no longer available from DataMiner 10.5.0 onwards.

The main page of the app consists of a header bar, a side panel and an overview panel.

- The header bar contains, from left to right:

  - The apps button: Click this button to access other DataMiner web apps, such as the Monitoring app.

  - The *Jobs* button: Click this button to return to the home page of the app.

  - The search box: Enter text in this box to search for matching jobs.

  - User icon: Click this icon in the top-right corner to open a menu with the following options:

    - *Configuration*: Select this option to access the configuration of the job fields. See [Configuring jobs in the Jobs app](xref:Configuring_job_domains).

     *About*: Select this option to view version information on the app.

    - *Sign out*: Select this option to log out and return to the logon screen.

- The filter panel on the left side of the app can be collapsed and expanded. This panel can be used to filter the overview panel on the right. The layout of this panel is different depending on the DataMiner version.

  **From DataMiner 10.2.0/10.1.5 onwards:**

  First select the type of time filter in the box at the top:

  - *Occur* means that the filter time should be within the job lifespan

  - *Start* means that the filter time should contain the start time of the job.

  - *End* means that the filter time should contain the end time of the job.

  When you have selected this, you can then select a time filter. To do so, select one of the default filters in the *During* dropdown box, or select *Custom* and specify a custom start and end time for the filter.

  If dropdown fields have been configured to allow filtering on these fields, the different dropdown options will be displayed in the *Field filters* section below this, allowing you to quickly filter on particular options by selecting them there. If you have selected multiple options for one field, you can clear the selection for all options at the same time by clicking the “x” next to the field name. To clear the selection for all options of all fields, click the “x” icon next to *Field filters*.

  **In earlier DataMiner versions:**

   At the top of the panel, a time filter can be specified. To do so, select one of the default filters in the time filter dropdown box, or select *Custom* and specify a custom start and end time for the filter.

   If dropdown fields have been configured to allow filtering on these fields, the different dropdown options will be displayed in the *Field filters* section below this, allowing you to quickly filter on particular options by selecting them there. If you have selected multiple options for one field, you can clear the selection for all options at the same time by clicking the “x” next to the field name. To clear the selection for all options of all fields, click the “x” icon next to *Field filters*.

- The overview panel on the right side of the app has a gray header containing several buttons:

  - **\<domain name> button**: The dropdown box on the left allows you to select a different job domain. Only the jobs belonging to the selected domain will be displayed

  - **New**: Click this button to open a form to manually add a new job. See [Manually adding a job](xref:Manually_adding_a_job).

  - **View**: Only displayed if a job is selected. Click this button to view the details of the job in a pop-up window. On the right side of that pop-up window, a bar will be displayed that shows history information for the job when clicked.

  - **Edit**: Only displayed if a job is selected. Opens a pop-up window where you can modify the job, in the same way as when you add a job.

  - **Delete**: Only displayed if a job is selected. Removes the selected job.

  - **Export / PDF**: Only displayed if a job is selected. Exports the selected job to PDF. From DataMiner 10.1.0 \[CU1\]/10.1.4 onwards, this will open a pop-up window where you can view a preview of the PDF and configure its settings. You can specify the PDF title and subject, select whether your company information, your company logo, and/or page numbers should be included, and customize the PDF width.

  - ![List button](~/dataminer/images/JobsX_list.png) : Displays the list view, which shows the jobs that have been planned within the time span specified in the filter. When a job is selected in the list, more buttons become available, allowing you to view, edit, export or delete the job.

  - ![Timeline button](~/dataminer/images/JobsX_timeline.png) : Displays a timeline that contains all jobs within the time specified in the filter panel on the left. See [Working with the jobs timeline](xref:Working_with_the_jobs_timeline).

  > [!NOTE]
  > The timeline view is not available on small screens.
