---
uid: Creating_a_new_task_under_the_current_project
---

# Creating a new task under the current project

As a customer or a DataMiner Strategic Partner, you will always create tasks under an active project. This can be a contracted delivery of a solution or a number of professional services, or an active DataMiner Maintenance & Support contract. Depending on the scope of the project, certain constraints may apply as to which kind of tasks can be created.

To create a new task under the current project, do the following:

1. In either the *List* tab or the *Board* tab, click *New task*, and select the type of task from the list.

   Customers and DataMiner Strategic Partners can create the following types of tasks:

   | Type | Description |
   |--|--|
   | Action item | Used to indicate that a specific action has to be taken. |
   | DIS issue | Used to report an issue regarding the DataMiner Integration Studio. |
   | Driver issue | Used to report an issue regarding the DataMiner drivers deployed in your system, provided by Skyline. |
   | New DIS feature | Used to send in a request for Skyline to consider a feature to be added to the DataMiner Integration Studio. |
   | New driver feature | Used to send in a request for Skyline to consider a feature to be added to one of the DataMiner drivers deployed in your system, provided by Skyline. |
   | New software feature | Used to send in a request for Skyline to consider a feature to be added to the DataMiner software. |
   | Software issue | Used to report an issue regarding the DataMiner software. |
   | Support | Used if none of the above-mentioned other types apply or if no type can be selected at this stage. |

1. Enter a title.

   > [!NOTE]
   > - Above the title you have just entered, you will notice the current status of the task you are creating, i.e., “Not started”. Hover over the small question mark to see an overview of all possible task statuses depicted in a typical task lifecycle. For more information on the different task statuses, see [Task statuses](xref:Statuses#task-statuses).
   > - In the top-right corner, you can click an ellipsis button to open a menu that contains the following commands:
   >
   >   - Click *Full screen* to expand the task pane. In full-screen mode, you can then click *Split view* to exit the full-screen mode.
   >   - Click *Show planning fields* to have the task pane also show planning fields (e.g., *Start date*).

1. If necessary, change the task type.

   > [!NOTE]
   > Customers and DataMiner Strategic Partners can only create tasks of certain types. See above for an overview.

1. If necessary, flag the task as a project risk.

   If you consider the task to be critical to the success of the entire project (critical path), select the *Flag as project risk* option. Note that when you filter tasks in the *List* view or the *Board* view, you can indicate that you only want to see the tasks that are flagged as a project risk.

1. Enter a detailed description.

   Depending on the type of task, the description box can contain a template that will help you add all relevant information that is typically expected for the type of task you are creating.

1. In the *Percent complete* box, enter a percentage (0 to 100) to indicate how much of the task has already been done. As soon as the task is set to “In progress”, this field should be updated continuously as work progresses.

   *This field is available if the task type is set to DIS issue, Driver issue, New DIS feature, New driver feature, New software feature or Software issue.*

1. In the *Priority* box, set the priority of the task to “High”, “Normal” or “Low”.

   > [!NOTE]
   > Depending on the project, certain criteria may be agreed upon with regard to priorities.

   *This field is available if the task type is set to DIS issue, Driver issue, New DIS feature, New driver feature, New software feature, Software issue or Support.*

1. In the *SLA level* box, set the SLA level of the task to “n/a” (i.e., “not applicable”), 1, 2 or 3.

   > [!NOTE]
   > SLAs are typically used in the context of an active DataMiner Maintenance & Support agreement, which defines the criteria for the SLA classification and the implications of that classification.

   *This field is available if the task type is set to DIS issue, Driver issue, Software issue or Support.*

1. In the *Issue type* box, indicate whether the reported issue applies to either a new feature or an existing feature by selecting “n/a” (i.e., “not applicable”), “New feature” or “Existing feature (regression)”.

   *This field is available if the task type is set to Driver issue or Software issue.*

1. In the *Driver* box, select the DataMiner driver for which you want to report an issue or request a new feature.

   *This field is available if the task type is set to Driver issue or New driver feature.*

1. The *Developer* box cannot be edited when you create a new task. This box will contain the name of the developer as soon as one has been assigned to the task.

   *This field is available if the task type is set to DIS issue, Driver issue, New DIS feature, New driver feature, New software feature or Software issue.*

1. The *Target release* box is reserved for the developers involved in the task. In this box, they will select the software version in which the new feature will probably be made available or in which the issue will probably be fixed.

    *This field is available if the task type is set to New software feature or Software issue.*

1. In the *Found in version* box, it is highly recommended to specify the software or driver version in which the issue was first encountered as this will facilitate the resolution of the issue. If the task type is set to “Software issue”, specifying this version is mandatory.

   *This field is available if the task type is set to DIS issue, Driver issue, New DIS feature, Software issue or Support.*

1. The *Released in version* box is reserved for the developers involved in the task. In this box, they will enter the software or driver version in which the new feature will be available or in which the issue will be fixed.

   *This field is available if the task type is set to DIS issue, Driver issue, New DIS feature, New driver feature, New software feature or Software issue.*

1. The *Release note* box is reserved for the developers involved in the task. In this box, they will enter the release note(s) associated with the task.

   *This field is available if the task type is set to DIS issue, New DIS feature, New software feature or Software issue.*

1. The *Main release version* box is reserved for the developers involved in the task. In this box, they will enter the main release DataMiner version in which the new feature will be available or in which the issue will be fixed.

   *This field is available if the task type is set to New software feature or Software issue.*

1. The *Feature release version* box is reserved for the developers involved in the task. In this box, they will enter the feature release DataMiner version in which the new feature will be available or in which the issue will be fixed.

   *This field is available if the task type is set to New software feature or Software issue.*

1. The *Start date* box cannot be edited when you create a new task. In this box, the developer will enter the date when they started with the task at hand.

   *This field is available if the task type is set to Driver issue or New driver feature.*

1. Click the “+” icon to upload any files you want to attach to the task (documents, images, etc.).

1. If you want to add a comment to the task, click inside the *Write a comment* box, and enter your comment.

   > [!NOTE]
   > It is recommended to provide as much relevant information as possible each time you create or edit a task.

1. At the top of the pane or window, click *Save*.
