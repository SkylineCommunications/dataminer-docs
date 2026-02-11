---
uid: Adding_maintenance_event
---

# Adding a maintenance event

> [!IMPORTANT]
> Make sure you have set up the two resource validation configuration tables before creating any maintenance events. For more information, see [Configuring resources](xref:PLM_tool_configuring_resources).

To create a maintenance event (also known as a PLM item), follow these steps:

1. Go to the *PLM Instances* page and click *+ Add* in the top-left corner.

1. In the *Planned Maintenance* pop-up window, provide the necessary information.

   ![Adding maintenance event](~/dataminer/images/Adding_Maintenance_Event.png)

   - **Title**: Choose a name for the maintenance event. We recommend choosing a descriptive title to ensure intuitive use of the app.

   - **Resource Type**: Select the type of resource from the options previously configured on the *Configuration* page. See [Configuring resources](xref:PLM_tool_configuring_resources).

   - **Resource**: Specify the name of the resource to assign the PLM item to.

   - **Start Time**: Enter the start time of the maintenance window.

   - **End Time**: Enter the end time of the maintenance window.

      > [!NOTE]
      >  When opening the App from a remote server, the time that is displayed in the *Start/End Time* section when adding a new entry to the *Maintanace Table* will be in client time and may differ from server time.

   - **Recurrence**: Choose the recurrence pattern that suits your needs:

     - *Once*: Provide the date for the one-time PLM activity.

     - *Daily*: Define the interval (*Every XX day(s)* or *Every Weekday*).

     - *Weekly*: Define the interval (*Every XX week(s)*). Select specific days of the week.

     - *Monthly*: Define the interval (*Every XX month(s)*). Specify the day of the month.

   - **Range of Recurrence**: Specify the start and end dates for the recurrence.

     - **Start**: Enter the start date of the recurrence.

     - **End**: Enter the end date of the recurrence.

     ![Range of Recurrence](~/dataminer/images/Range_of_Recurrence.png)

1. To save your changes, click *OK*. A new row will be added to the PLM table, indicating the successful creation of the PLM item.

   > [!NOTE]
   > A PLM item can have 5 different statuses:
   >
   >
   > | Status | Description |
   > |--|--|
   > | Scheduled | One-time activities that were created but have not occurred yet |
   > | Completed | One-time PLM activities that have been completed |
   > | Active    | Recurrent PLM activities currently in progress within the specified range of recurrence |
   > | Inactive  | Recurrent PLM activities not currently active within the specified range of recurrence |
   > | Expired   | Recurrent PLM activities with a current date outside the range of recurrence. |
