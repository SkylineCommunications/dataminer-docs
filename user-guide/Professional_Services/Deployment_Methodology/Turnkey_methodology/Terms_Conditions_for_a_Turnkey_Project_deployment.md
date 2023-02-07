---
uid: Terms_Conditions_for_a_Turnkey_Project_deployment
---

# Terms & Conditions for a Turnkey Project deployment

For a Turnkey Project to be executed as planned, in line with the anticipated timeline, the offered price and the allocated human resources, it must be governed by the following specific and general terms & conditions. Strict compliance of all involved parties with these terms & conditions is an absolute must to ensure a successful execution in line with the provided Project Plan.

- Remote Access: The scheduled timeline assumes continuous 24/7 uninterrupted high-performance and professional remote access to all IT products and components involved in the project (i.e. both the DataMiner System and the products and systems subject to interfacing with DataMiner, or involved in any other way in the project), enabling the entire team of allocated resources to work unhampered, so that each of them, independently of one another, can perform their duties efficiently. By way of illustration, non-compliance could for example be:

    - Low-bandwidth and/or high-latency connections slowing down the planned activities.

    - Hardware tokens required for remote access that need to be shared between team members, or any other mechanisms that prevent the allocated resources from using remote access simultaneously and independently of one another.

    - Procedures that hamper the setup of remote connections, e.g. frequent re-submissions of remote access requests and delay times to obtain such access.

    - Interruptions and unavailability of remote access, which prevent the allocated resources from executing the planned activities in an uninterrupted manner.

    - Use of consumer-grade remote access technologies such as Team Viewer or cascading of multiple Remote Desktop sessions.

    - Etc.

- Loss of Data: Skyline is not responsible for any accidental or intentional loss of data in any way (e.g. HDD crashes, any loss or lack of backup files, accidental deletions, etc.), i.e. users must ensure that they provide the infrastructure and means to prevent any loss of data. Skyline is available to advise on best practices related to the matter.

- Data Collection & Control Plane Engineering: Connecting DataMiner with the underlying third-party products and data sources is a key activity of the deployment of a DataMiner solution, with potentially considerable dependencies that cannot be controlled by Skyline. Furthermore, not being able to complete such an integration as planned can also be a blocking issue or a considerable constraint to efficiently execute other activities that heavily depend on the integration (e.g. creating dashboards, creating Visual Overview graphics, designing automation workflows, etc.). Therefore, the following terms and conditions need to be taken into account in a Turnkey Project, as the provided Project Plan is drawn up assuming that these are respected:

    - DataMiner Connectors cannot be developed, deployed, and tested without a completely operational and functional, fully service-active, and continuously available test product or data source. This also implies that the test product is available both to collect data from and to freely perform configuration settings on.

    - DataMiner Connectors cannot be developed without a complete and error-free API documentation/definition at hand. Lack of documentation, or poor quality of such documentation, can have a considerable impact on the anticipated timing to develop a DataMiner Connector.

    - Any technical issues that are encountered with third-party APIs are not catered for in the timing and budget of a Turnkey Project. These can for example be breaking changes between different versions of the API, different versions of the API across multiple products of the same type in the operation, performance constraints of the API, data structures and constructs of the API that are not fit for the envisioned purpose, etc.

    - For any new connectors that need to be developed as part of the project, a total development time of 10 working days on average is taken into account. Should any integrations deviate from that, this must be mitigated through a Change Request updating the overall project timeline. Alternatively, other mitigations can be defined to limit the time expenditure to 10 working days (e.g. partial integration, focusing on the functionality required for the project at hand).

    - At least 2 weeks in advance, Skyline will give a heads-up on the expected availability (timing and estimated duration) of the required test products for the purpose of connector development. The duration of the availability is indicative, as it is impossible to determine exactly how long a connector development and validation process will take. However, a Turnkey Project assumes the uninterrupted availability of the test product for as long as is needed for the proper development and validation of the integration.

    - Any connectors that are part of the deliverables will be submitted by Skyline to the user for review and approval. Turnkey Projects are planned with the assumption that feedback from a user is received within 1 week from submission by Skyline, and that there are no more than 2 review iterations. It is also assumed that feedback from the user in the second iteration is not feedback that could have been given in the first iteration. Further iterations beyond the 2 planned cycles are exclusively limited to clearly defined deliverables/feedback provided earlier by the user that was not yet fully delivered by Skyline.

- For any other third-party dependencies (e.g. IP address scheme, required credentials, requirement clarifications, etc.) Skyline will provide a timely notification to indicate the dependency, along with the ultimate date at which the dependency must be fully resolved for it not to affect the anticipated timeline and/or budget of the Turnkey Project.

- For any cross-element logic (e.g. alarm correlation, automation and orchestration logic, dashboards, Visual Overview graphics, etc.) Skyline must have a fully operational and fully available test and validation environment available, for which the same terms and conditions apply as for the availability of individual test products for the purpose of developing connectors.

- All governance and tracking of all activities, dependencies, change requests or any other items will be done exclusively with the DataMiner Project Collaboration tool available on dataminer.services. The execution of a Turnkey Project does include a Skyline allocated resource spending time on consulting and replicating information on any third-party project management tool, or generating custom project-related reports beyond what is by default available in the DataMiner Project Collaboration tool.

- The Turnkey Project assumes the availability of a Single Point of Contact (SPoC) at the user side and if applicable the System Integrator side, to ensure an efficient process of handover, synching, and clear ownership. The absence of a Single Point of Contact or changes to the Single Point of Contact throughout the project can result in considerable inefficiency and time expenditure that was not catered for in the Project Plan.

The above are merely examples of variables that cannot be controlled by Skyline. As these cannot be anticipated, they are not taken into account in an initial Turnkey Project execution planning and budgeting. These examples are explicitly provided to ensure that both Skyline and the user can collaborate on mitigating the risk that these situations might present themselves.

In general, as part of the terms & conditions for a Turnkey Project, any occurrence of variables that cannot be controlled by Skyline, but undeniably affect the time and effort invested in the deployment of the Turnkey Project, will automatically result in a Change Request to update both the price and timing of the project.

> [!NOTE]
> These general terms & conditions are also applicable in the context of any of the Agile deployment methodologies, i.e. Skyline cannot be held accountable for variables that it cannot control or predict, regardless of the methodology leveraged for the deployment of a DataMiner solution. As such, it is always important to focus in the first place on mitigating the chances of these kinds of situations happening.
>
> The main difference between the Turnkey Project methodology and the two available Agile methodologies (Agile Scope-Based and Agile Time & Materials), when it comes down to variables that cannot be controlled and to change in general, is the way these are dealt with. In the context of a Turnkey Project, these circumstances are more costly and cumbersome to deal with, and the options to deal with them are very limited (i.e. change inevitably results in increased cost and a prolonged execution timeline). An Agile methodology deals with these more efficiently (i.e. less impact for the same change), and there are more options to choose from (i.e. you can opt not to affect the cost and timeline).
>
> As outlined earlier, in the context of a Turnkey Project deployment, these types of circumstances are managed through Change Requests. These kinds of formalized procedures come with the necessary overhead, and it is therefore important to avoid them in the first place. While the advantage is that they are well-defined, very controlled and formal, they also cause a higher impact on cost and time as compared to an Agile approach (i.e. changes in the context of a Turnkey Project methodology are more expensive as compared to the same changes being dealt with using an Agile methodology). Very importantly, in a Turnkey Project context, a trade-off with other planned activities is not possible. Any change is dealt with by itself (i.e. what is its impact on cost and timing) and the remainder of the project remains unchanged. This means that Change Requests, and hence dealing with variables that cannot be controlled, always drives up the cost and extends the timeline of the project. As a result, if a Turnkey Project deployment methodology is applied in the context of a project with a lot of variables that cannot be controlled, this will inevitably result in spiraling costs and execution time.
>
> For the two available Agile methodologies, change in general, and hence also impact of variables that cannot be controlled, is dealt with by the Project Squad in a far less formal and far more continuous manner. Therefore, a given change will always have less impact in terms of cost and time in an Agile methodology context as compared to a Turnkey Project methodology context. This is because of the far more practical, continuous, and to-the-point way of dealing with change in an Agile context. Moreover, in an Agile context, alternative options are also available other than having an immediate impact on cost and timing. The entire backlog of pending activities can be considered, and changes in that backlog can also be leveraged to mitigate or even entirely annul the impact of the change at hand (i.e. the change is dealt with without impact on budget or timing).
>
