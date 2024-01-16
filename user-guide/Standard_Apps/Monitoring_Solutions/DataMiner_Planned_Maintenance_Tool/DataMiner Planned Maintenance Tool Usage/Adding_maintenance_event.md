---
uid: Adding_maintenance_event
---

# Adding a maintenance event

To create a PLM item, please follow these steps:

1. In the PLM Instances Page, locate and click on the "+ Add" icon located in the top panel. This will open a pop-up window for creating a new PLM item.

<!--    ![Planned Maintenance App ADD](~/user-guide/images/DataMiner_Planned_Maintenance_ADD.png) -->

1. In the pop-up window, enter the following information:

    - **Title**: Provide a descriptive title for the PLM item.

    - **Resource Type**: Select one of the available resource types that was previously configured. See: [Configuring resources](xref:PLM_tool_configuring_resources)

    - **Resource**: Specify the name of the resource to assign the PLM item to.

    - **Start Time**: Enter the start time of the maintenance window.

    - **End Time**: Enter the end time of the maintenance window.

    - **Recurrence**: Select the recurrence pattern: Once, Daily, Weekly, or Monthly.

        - If you select Once, enter the date of the one-time PLM activity.

        - If you select Daily, specify the interval: Every __ day(s).

        - If you select Weekly, specify the interval: Every __ week(s). Also select 
        the days of the week.
        - If you select Monthly, specify the interval: Every __ month(s). Also specify which day of the month: Day __.

    - **Range of Recurrence**: Specify the range of dates in which the recurrence should apply.

        - **Start**: Enter the start date of the recurrence.
        
        - **End**: Enter the end date of the recurrence.

<!--    ![Planned Maintenance App CREATE](~/user-guide/images/DataMiner_Planned_Maintenance_CREATE.png) -->

1. Once you have entered all the required information, click the "OK" button. A new row will be added to the PLM table, indicating the successful creation of the PLM item.

    > [!NOTE]
    > A PLM entry can have 5 different statuses:

    | **Status**    | Description                                                                                            |
    | ------------- | ------------------------------------------------------------------------------------------------------ |
    | Scheduled | One-time activities that were created but haven’t happened yet                                         |
    | Completed | One-time PLM activities that were completed                                                            |
    | Active    | Recurrent PLM activities that are currently happening and the range of recurrence hasn’t expired yet.  |
    | Inactive  | Recurrent PLM activities that are not currently active and the range of recurrence hasn’t expired yet. |
    | Expired   | Recurrent PLM activities that current date is out of the range of recurrence.                          |
