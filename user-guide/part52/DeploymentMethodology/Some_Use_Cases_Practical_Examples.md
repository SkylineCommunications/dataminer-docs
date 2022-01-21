---
uid: Some_Use_Cases_Practical_Examples
---

# Some Use Cases & Practical Examples

**ACTIVITY: Leveraging the DataMiner Visual Overview graphical UI to create an intuitive and graphically appealing set of bubble-up and drill-down mimics, for operators to easily manage and navigate through their operation end to end.**

TURNKEY PROJECT

- During the Consultancy and Detailed Design Specification phase, Skyline works with the user to exactly specify the complete required graphics. The environment is very well defined, the user and Skyline know exactly what they expect, the data sources are very well defined, and everybody knows what kind of data and controls are required to create a rich UI.

- As Visual Overview has a great many features and capabilities, resulting in endless possibilities, and the required results also depend on the preferences of the user (personal preferences and opinions, influence of past habits and ways of working, etc.), the process of specifying the design specification must be a collaborative and iterative effort between Skyline and the user.

- Once the design specification is signed off, the overall efforts will be estimated and quoted. Upon receipt of a purchase order, the graphics will be implemented in line with those agreed design specifications. This will be done at the time planned, and on the condition that all other prerequisites are in place (e.g. data sources are integrated, tested, validated and present).

- If after the sign-off of the design specification any changes are required, then this will be governed by a formal Change Request, which will also specify the impact on time and cost. The same applies if the planned activity cannot take place as planned because of external dependencies that are not in place. Only after a formal sign-off on the Change Request, can the changes be executed.

AGILE SCOPE-BASED PROJECT

- The project has an estimated time budget that accurately reflects the time typically needed for the team to create these types of graphics in a live environment, taking into account the specifics of the project known at that time (e.g. the type of project, the size of the solution, the complexity of the solution, etc.).

- The design specification does not define in detail what the graphics are going to look like. It only specifies that this activity is planned, the allocated time, and potentially some further details if there are very specific requirements that are already well-known and can be well-defined, so that the Project Squad is fully aligned on those very specific specifications/expectations.

- In due time, the Project Squad will start working on the actual implementation, and they will do this in the live system (very likely at the stage that the live data sources are in place, so that they can do it efficiently and based on real data). They will work in short cycles, seeking continuous feedback from the users by means of review sessions, and focusing on where they can deliver most value (e.g. ensuring that they have first versions of all graphics across all relevant parts of the managed ecosystem, delivering the key functionality, and then spending further time on fine-tuning and evolving the most important things, etc.).

- The Project Squad will also continuously track their time expenditure on this specific activity. They will jointly decide at which point they want to stop (e.g. because they have an acceptable first version and would prefer to focus on other important activities first, or because some unknowns surfaced and they want to take time to sort those out first and then revisit the activity later), or if they feel that they need to continue this activity (with the option to even exceed the initially allocated time expenditure, in the knowledge that they will then have to take that time away from another activity). The Project Squad jointly decides on where they put their focus, and where a minimum effort from their end can deliver the most value towards the end goal.

AGILE T&M PROJECT

As the Agile T&M engagement is essentially based on a time expenditure basis, the execution of activities can be organized in various ways, as deemed most appropriate. However, in general, Agile methodologies are highly recommended by Skyline, as this is the logical choice for many if not all of the typical activities in the context of the deployment of a DataMiner solution.

- The assigned decision maker decides that the available engineering resources need to work on Visual Overview graphics, presumably because there is value for the user in creating these based on the input from the stakeholders.

- The assigned decision maker decides together with the available engineering resources on the best way to approach this (e.g. either focusing on designing an exact specification and then executing this, or creating a first version and starting to iterate on it with close involvement of the users).

- The assigned decision maker decides on what exactly the available engineering resources should work and for how long (presumably weighing effort against business value).

**ACTIVITY: Creating a new driver for a new device.**

TURNKEY PROJECT

- During the Consultancy and Detailed Design Specification phase, Skyline reviews the API of the target device in detail, collects all documentation, makes a final assessment in terms of how much work it will take to develop the driver, and plans that activity into the overall waterfall project plan for execution.

- When the planned activity is to take place, all prerequisites are verified, and a Change Request is issued if the activity cannot start as planned. This could for example be because:

    - The target test device needs to be available to support the development process. If not, a Change Request must be issued that will reschedule the activity at a later stage, and the Change Request must specify the impact on the overall project timeline and cost.

    - The firmware or API specification changed in comparison to what was planned. In this case, a Change Request must specify the impact on the overall project timeline and cost.

- If all prerequisites are in place, the development activity is executed as planned.

- If during the scheduled development specific issues or concerns arise based on variables that cannot be controlled by Skyline, this will be governed by a Change Request, with an assessment of impact on cost and timing. This could for example be because:

    - The target product API is not functioning according to the specifications and documentation available and used at the time of planning.

    - The target product API is still evolving and changing during development.

    - Performance issues with the target product API make it unfit for the intended purpose.

- Once the development of the driver is finished, it is submitted for review and approval. If this process cannot comply with the Turnkey Project terms & conditions, this deviation is managed through a Change Request, which will specify the impact on cost and timing for the project.

AGILE SCOPE-BASED PROJECT

- The development of the driver is included in the Solution Backlog as an activity that needs to be completed, along with an estimated time effort.

- The Project Squad Solution Owner works with the user in a timely fashion to ensure that everything related to this activity is as well defined and prepared as it can be. This includes determining what the expectations of the user are for this integration, what the real value is and what the objectives are, what the prerequisites are for this integration, what kind of information is already available and what is missing, where this integration fits into the overall objectives of the project, etc.

- The Project Squad Product Owner ensures that everybody is fully aware of when this activity must be completed at the latest, i.e. when it could be blocking for other activities and when it becomes critical towards the final overall delivery of the project.

- When all information is available and all prerequisites are fulfilled, the integration activity is weighed against the other priorities in the project and then included in the Sprint Planning.

- During the Sprint Reviews, the Project Squad evaluates the progress of the integration. In case the progress is not as anticipated, the squad can investigate how this can be resolved most efficiently to mitigate the impact.

    - If the issue has not yet significantly affected the time expenditure, the activity can be paused, and the issue can be handed over to the Project Squad Solution Owner and/or the Project Squad Product Owner to resolve, so that the activity can be resumed later. This could for example be if all development has progressed according to plan, but no configuration setting from DataMiner towards the target product can be implemented and tested because the test environment is not fully available for this type of testing.

    - If the issue has resulted in excess time expenditure as compared to what was initially envisioned, this needs to be resolved by the Project Squad Product Owner.

        - If, for example, there are performance issues with the third-party product, the development activity can be paused to prevent any further waste of time, and discussions can start with the technology vendor to see if the issue can be resolved.

        - The time lost, which is typically limited if the issue is detected at an early stage and can be mitigated, is then compensated in the Solution Backlog in line with the guidelines provided for this, to ensure that the overall project cost and timing are kept steady.

            Note that while the Project Squad has all the means to respond with as much agility as possible to such situations, there are also limitations as to how much unexpected time expenditure it can absorb. Not all activities can be continuously delayed with an expectation to tackle all of them at once at the end of the project. The continuous time balancing of the Solution Backlog ensures that the Project Squad has good visibility on when the anticipated final delivery date becomes at risk, and they can effectively mitigate this risk.

AGILE T&M PROJECT

As the Agile T&M engagement is essentially established on a time expenditure basis, the execution of activities can be organized in various ways, as deemed most appropriate. However, in general, Agile methodologies are highly recommended by Skyline, as this is the logical choice for many if not all of the typical activities in the context of the deployment of a DataMiner solution.

- The assigned decision maker decides that the available engineering resources need to work on the development of a connector (presumably because there is value for the user in having this connector deployed, based on the input from the stakeholders).

- The assigned decision maker decides together with the Project Squad on the best way to approach this (e.g. either focusing on designing an exact specification and then executing this, or creating a first version and starting to iterate on that with close involvement of the stakeholders).

- The assigned decision maker decides on what exactly the available engineering resources should work and for how long (presumably weighing effort versus business value).

**ACTIVITY: Creating an automation workflow to provision a new service as part of a booking**

TURNKEY PROJECT

> [!NOTE]
> The description below is a theoretical analysis of how this kind of activity would have to be dealt with based on a Turnkey methodology. However, in practice this would be an extremely inefficient process to deal with this type of activity. This is why for the large majority of DataMiner projects an Agile methodology is highly recommended, as it will yield much more value with the same resources and in the same time frame compared to a Turnkey methodology.

- During the Consultancy and Detailed Design Specification phase, Skyline and the user collaborate to document the desired automation workflow in detail to prepare for coding, testing, validation, and deployment. This starts with the high-level logical design and documentation of the workflow, which is then further elaborated down to the step-by-step individual settings, readings and checks that need to be performed on the actual third-party products in the operation involved in the service provisioning workflow.

    It is highly recommended to thoroughly test and validate all these steps on the actual products through manual configuration, to make sure that they are as accurate as possible, and nothing is missing. It is also recommended to review the underlying third-party APIs to ensure that all documented workflows are effectively feasible based on those. After all, in a Turnkey methodology, once everything is firmly planned, all changes and deviations from the initial plan need to be managed by means of a cumbersome and expensive Change Request procedure.

- When the planned activity, i.e. the coding, validation and deployment of the service provisioning automation workflow, is to take place, all prerequisites are verified. A Change Request is issued if the activity cannot start as planned. This could for example be the case because:

    - The third-party products involved in the automation need to be available to support the development process (i.e. for comprehensive testing and validation). Otherwise, a Change Request must be issued that will reschedule the activity at a later stage, and the Change Request must specify the impact on the overall project timeline and the cost.

    - If the firmware or API specification changed on the third-party product in comparison to what was designed and planned for, a Change Request will specify the impact on the overall project timeline and cost.

- If all prerequisites are in place, the development, test and validation work is executed as planned. If during the scheduled development, specific issues or concerns arise based on variables that cannot be controlled by Skyline and that were not considered during the planning phase, then this will be governed by a Change Request again, with an assessment of impact on cost and timing. This could for example include:

    - The third-party product API is not functioning according to the specifications and documentation available and used at the time of planning.

    - The third-party product API is still evolving and changing during development.

    - Performance issues with the target product API make it unfit for the intended purpose.

    - The functionality supported by the third-party product API is not fit for the intended purpose and cannot be used to achieve the goals of the workflow. Additional work has to be done to work around these shortcomings and/or the workflow has to be adapted to deal with the shortcomings.

    - Etc.

- Once the development of the service provisioning automation workflow is finished, it is submitted for review and approval. If this process cannot comply with the Turnkey Project terms & conditions, this deviation is managed through a Change Request, which will specify the impact on cost and timing for the project.

AGILE SCOPE-BASED PROJECT

- The development of the service provisioning workflow is included in the Solution Backlog as an activity that needs to be completed, along with an estimated time effort.

- The Project Squad Solution Owner works with the user in a timely fashion to ensure that everything related to this activity is as well defined and prepared as it can be. This includes determining what the expectations of the user are for this integration, what the real value is and what the objectives are, what the prerequisites are for this integration, what kind of information is already available and what is missing, where this integration fits into the overall objectives of the project, etc.

    This is done in a pragmatic way, i.e. all certitudes and possible already-known details are properly documented and prepared as much as possible, so that the Project Squad can develop the required automation logic as efficiently as reasonably possible.      However, at the same time the involved staff will not venture into the unknown and speculate about matters that cannot be firmly concluded upon, as this could potentially result in a lot of wasted time and valuable resources. The development of the service provisioning automation will be done in a succession of iterations, with room to review the work, and to fine-tune details based on the circumstances and details that reveal itself.
    In that sense, from a practical point of view it is of no use to fully review, scrutinize and test all the APIs of the involved third-party products. A high-level functional review of the key products will suffice, and these will be assumed to comply with the industry-standard best practices to support the envisioned workflows. Should any issues or constraints arise during the development, the Project Squad will deal with this in a pragmatic manner in close collaboration with the stakeholders.

- The Project Squad Product Owner ensures that everybody is fully aware of when this activity must be completed at the latest, i.e. when it could be blocking for other activities and when it becomes critical towards the final overall delivery of the project.

- When a sufficiently reliable baseline of information is available for the activity to start, even if only partially, and the needed prerequisites are in place for this, the Project Squad can consider picking up the activity to start evolving it. The decision to do this will also depend on how this activity compares to the priority of other activities in the Solution Backlog. These priorities are mainly driven by value, effort, and dependency considerations.

- Once the development of the service provisioning automation workflow starts, the Project Squad reviews and monitors the progress continuously. If at any stage during the continuous iterations the progress deviates from what was anticipated, the squad will investigate immediately how this can be resolved in the most efficient way in order to prevent or at least mitigate the impact on the overall project.

    - If the issue has not yet significantly affected the time expenditure, the activity can be paused, and the issue can be handed over to the Project Squad Solution Owner and/or the Project Squad Product Owner to resolve, so that the activity can be resumed later.

        For example, all development has progressed according to plan, but no configuration setting from DataMiner towards an involved third-party product can be implemented and tested, because the test environment is not fully available for this type of testing. The activity can be paused, and the necessary preparations can be made to ensure that proper testing can be executed on the involved third-party product in a timely fashion.

        Or as an alternative example, all development has progressed nicely as planned, but the user expectations around the further details of the use case at hand are not entirely clear. The activity can be paused, and the Solution Owner and/or the Project Squad Product Owner will work with the Stakeholders and users to resolve this, so that the activity can progress again at a later stage.

    - If the issue resulted in excess time expenditure as compared to what was initially envisioned, then this needs to be resolved by the Project Squad Product Owner. Because for an Agile Scope-Based project all parties agreed that the effort and execution timeline need to be maintained at all times, this is an explicit priority for the project at hand.

        - If, for example, there are performance issues with the third-party product, the development activity can be paused to prevent any further waste of time, and discussions can start with the technology vendor to see if the issue can be resolved.

        - The time lost, which is typically limited if the issue is detected at an early stage and can be mitigated, is then compensated in the Solution Backlog in line with the guidelines provided for this, to ensure that the overall project effort and timing are kept in balance.

            Note that while the Project Squad has all the means to respond with as much agility as possible to such situations, there are also limitations as to how much unexpected time expenditure it can absorb. Not all activities can be continuously delayed with an expectation to tackle all of them at once at the end of the project.              The continuous time balancing of the Solution Backlog ensures that the Project Squad has good visibility on when the anticipated final delivery date becomes at risk, and they can effectively mitigate this risk.

AGILE T&M PROJECT

As the Agile T&M engagement is essentially based on a time expenditure basis, the execution of activities can be organized in various ways, as deemed most appropriate. However, in general, Agile methodologies are highly recommended by Skyline, as this is the logical choice for many if not all of the typical activities in the context of the deployment of a DataMiner solution.

- The assigned decision maker decides that the available engineering resources need to work on the development of the service provisioning automation workflow (presumably because there is value for the user in having this activity developed and deployed, and this based on the input from the stakeholders).

- The assigned decision maker decides together with the Project Squad on the best way to approach this (e.g. either focusing on designing an exact specification and then executing this, or creating a first version and starting to iterate on that with close involvement of the stakeholders).

- The assigned decision maker decides on what exactly the available engineering resources should work and for how long (presumably weighing effort versus business value).
