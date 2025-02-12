---
uid: WFD_Workflows
---

# Workflows

Workflows can be seen as templates for jobs that can be created from the [Scheduling app](xref:MO_Scheduling). Within contracts we have the following fields:

1. **Workflow name**: The name of the workflow

1. **Workflow description**: The description of the workflow

1. **Favorite**: Whether or not this is a favorite workflow. TODO CHECK WHAT THIS MEANS

1. **Priority**: The priority is of this workflow. TODO CHECK WHAT THIS MEANS

1. **Workflow execution script**: Specify a script to be triggered when this workflow is executed.

1. **Workflow configuration**: TODO CHECK IF WE CAN HIDE THIS?

1. **At job start**: Defines when the monitoring service has to be configured. TODO CHECK IF THIS CAN ALREADY BE USED? => NOT USED YET

   * Create Service Immediately - The service is created when the job is created. UP TO USER TO USE FROM EXECUTION SCRIPT => PROVIDE EXAMPLE
   * Create Service at Workflow Start - The service is created when the job starts. TODO WHY WORKFLOW START AND NOT JOB START?
   * Don't Create Service - No monitoring service wil be created for this job.

1. **At job end**: Defines what to do with the monitoring service when the job ends. TODO CHECK IF THIS CAN ALREADY BE USED?

   * Delete Service if One Exists - The service (if it exists) is deleted when the job ends. TODO HOW WILL THIS BE DONE?
   * Don't Delete Service - No actions are done related to the monitoring service at the end of the job.

1. **Monitoring service template**: TODO => REMOVE OR HIDE
