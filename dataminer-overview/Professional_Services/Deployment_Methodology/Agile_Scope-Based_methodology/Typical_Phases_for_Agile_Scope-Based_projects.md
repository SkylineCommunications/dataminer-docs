---
uid: Typical_Phases_for_Agile_Scope-Based_projects
---

# Typical phases for Agile Scope-Based projects

The Agile Scope-Based project has a flexible approach, and the Project Squad has maximum freedom to fine-tune the exact working methodology for the type of project at hand, and even depending on the exact activities throughout the execution of the project, on the condition that A) they ensure that it is clearly agreed with the entire Project Squad, and that it is practiced in full by everybody, and B) they comply with the key principles and mindset associated with the Agile Scope-Based project.

The phases and working methodologies outlined below are mandatory for the Project Squad.

## Offering

An Agile Scope-Based project is offered at a fixed price and with an agreed time frame, based on the high-level requirements available and all other relevant information available at the time of quoting. Everybody trusts and agrees that Skyline leverages its unique experience and expertise to ensure that the offered solution and accompanying budget will reasonably enable the Project Squad to deploy a professional solution in line with the Deployment Plan created during the Offering stage.

At the same time, both parties also agree and acknowledge the fact that this does not mean that the proposed solution and budget, which is finite, can include all imaginable desires, wishes, hopes and ambitions of all possible individuals that are and will be involved with the project during its execution. Therefore, the concept of value needs to be carefully applied throughout the execution of the project, and the joint Project Squad will be trusted to deliver the best possible solution in the most efficient manner. After all, this is the ambition of all parties involved.

> [!NOTE]
> To provide as much clarity as possible and to reduce risk of misalignment of expectations, both parties will still make all possible reasonable efforts to document and formally agree on everything they can reasonably already know and define at the offering stage. This can include requirements, use cases, documentation, roles & responsibilities and more. However, note that the project execution of an Agile Scope-Based project also offers the team maximum agility and the option to embrace any change that is needed to achieve their goal of delivering the best possible solution within the allocated time frame and budget.
>
> Anything agreed during the offering phase can therefore still be revisited when needed, on the condition that it is dealt with in the proper prescribed manner by the Project Squad (i.e. applying the necessary time budget balancing to keep them on track towards the end date and in line with the budget).

### Definition of Goals & Objectives

At the start of the Offering exercise, the Project Squad clearly describes the key objectives of the project, the expected outcome and the main benefits that it wants to deliver to the business and end users. 

The goal is not to provide an extended list of requirements or activities to be performed, but rather what the end goal is, closer to a Project Mission Statement, setting the direction for the work to be done, ensuring that the squad has a laser-focused mission that it can continuously refer to while executing the project, so that joint decisions of the Project Squad throughout the project are always aimed at what goes to the heart of the project (which may not always be in line with what was specified in the initial high-level requirements).

### Preliminary Solution Backlog

The Preliminary Solution Backlog is created as part of a commercial offer for a DataMiner Solution that will be deployed based on the Agile Scope-Based methodology. It contains a preliminary list of all known activities required for the deployment of the DataMiner Solution, along with the effort size (time-budget estimate) required for each of those activities, and their uncertainty score. Activities are usually grouped in so-called buckets.

The Uncertainty Score is the risk level for the estimate accuracy, a high uncertainty score reflects some level of ambiguity in the requirement, indicating that additional discussion is needed to fine-tune and clarify the activity.

Note that because of the nature of software projects, time forecasts on an activity level cannot be perfect. The main purpose of the Preliminary Solution Backlog is to get a realistic estimate of the overall consolidated workload for the design and deployment of the DataMiner Solution that fulfills the project's Goals & Objectives, within a committed fixed budget and delivery time frame. The Agile Scope-Based methodology allows exactly for that, as there's complete flexibility to move around time budget between activities based on priorities (e.g. spend less time on UI work and shift that time to automation logic).

### Value Delivery Plan

The Value Delivery Plan outlines the delivery strategy, how the work that needs to be done is prioritized in order to maximize value. As the ultimate purpose is to deliver maximum value in line with the specified goals, objectives and requirements, and within the agreed time frame and budget, value needs to be clearly defined, and activity planning needs to be aligned with this. 

Typically, the plan starts with the objectives that provide maximum value with the goal of having a Minimum Viable Product, allowing people to use and experiment with the product early on. Alternatively, it may start with deliverables with higher levels of uncertainty, to confirm they can be achieved before venturing into the larger project.

### Projected Workload

The Projected Workload maps the overall effort defined by the Preliminary Solution Backlog over time to ensure that a reliable timeline is available for the overall project. 

It factors in the average number of people who will be working on the project and their actual capacity. It also takes proper buffers into account for project ramp-up time, risk mitigation, etc. 

### Dependencies, Assumptions & Constraints

These define the key dependencies for the project, to ensure that all parties understand which dependencies apply between the different activities so that everything can be planned and prioritized with those in mind.

## Setup of the Solution Backlog

At the start of the project, the Project Squad creates the so-called Solution Backlog, which consists of all known high-level activities (a.k.a. buckets) that will be required to design and deploy the envisioned solution, as well as to some extent the items described in the initial requirements for the project (e.g. connectors that will be required, DMA nodes that need to be deployed, ability for an operator to start a recording of a video stream, ability for an operator to track a stream in the network, etc.). The Solution Backlog then serves as the foundation to bring the solution in place.

> [!NOTE]
> The Solution Backlog consists of two separate components, i.e. the Solution Connector Backlog and the Solution System Backlog. The Solution Connector Backlog manages the development of the connectors that connect the solution with the third-party products involved in the project (in case the connectors do not exist yet). The Solution System Backlog manages the engineering services effort that goes into all other activities related to the design, development and rollout of the overall end-to-end solution (including the deployment of connectors).
>
> For the Solution Connector Backlog, an average budget of 2 weeks is automatically allocated for the development of new connectors. For the Solution System Backlog, the engineering services budget is defined in the commercial proposal for the project (this is not the case for connector development, as this is comprised in the licensing cost of the connectors).

The following important key principles must be applied when setting up and subsequently evolving the Solution Backlog:

- The Solution Backlog must always focus on what is known and well-defined. It is of no use to burn valuable time on speculation and to document details with high levels of uncertainty. As the focus should always go towards delivering value with the available resources and time, such a waste of valuable time and energy is to be avoided.

    After all, the Agile Scope-Based methodology embraces change whenever it is required, so that it is sometimes better to make decisions only at a later stage when there is less uncertainty. It is for example of no use to design detailed UIs when no one has an idea what kind of data the third-party product API supports, and it might therefore be better to move ahead with the integration of the third-party API and then decide later what the most optimal UI looks like.

- The Solution Backlog must immediately assign an estimated and realistic effort to all buckets and, if possible, all sub-items in the bucket (i.e. the activities), to map out the overall time budget required to deliver the solution by the planned delivery date. This must be based on an efficient agile methodology (e.g. applying planning poker, using S/M/L type classifications, labeling activities with levels of confidence or lack thereof, classifying the level of complexity of activities, etc.), considering also that individual buckets can still be balanced out against other buckets during the execution of the project. It is therefore useless to spend time on over-analyzing these estimates, especially not if the difficulty of the analysis is related to uncertainty and complexity that cannot be resolved at the present stage.

- The Solution Backlog must be fully documented and managed on Project Collaboration (part of dataminer.services) by the Project Squad Product Owner, where it must also be tracked, refined and time-balanced continuously over the course of the project execution. The latter is part of the standard review process and ensures that the Project Squad has visibility on how much of the overall Solution Backlog they have chipped away, and what they still have ahead of them. Furthermore, the Solution Backlog is also instrumental in keeping the Project Squad focused on short-term goals, ensuring that they continuously make maximum progress towards their ultimate end goal.

## Sprint Planning & Execution

The project must start as soon as possible and be executed in a continuous succession of short sprints no longer than 4 weeks. The Project Squad focuses continuously on developing the known and well-defined portions of the deliverables. In doing so, they create a foundation that will resolve some of the uncertainty for other work items, which can then in turn be used to further evolve the project in a more efficient manner.

In relation to Sprint Planning & Execution, the Project Squad must ensure that the following key activities take place as part of the Agile Scope-Based project execution:

- **Sprint Planning**: Each sprint must be carefully prepared and planned, taking the following into consideration:

    - In a timely fashion, the Project Squad Product Owner will coordinate all activities required to ensure that an agreed Sprint Plan is in place for the Project Squad to start each iteration in time, with all required information and infrastructure at their disposal. The Squad Product Owner is also accountable for ensuring that the Sprint Plan is available in Project Collaboration. The Project Squad must also ensure that the estimated workload for the Sprint is reasonable and realistic for the Development Members to be successful towards the sprint goals.

    - The sprint planning is done based on what is known at the time, keeping in mind that a lot is still unknown and will be discovered during the sprint itself, and that there is no value in trying to predict every possible situation.

    - The Project Squad Solution Owner will decide which objectives the team needs to work towards in which iteration and will do so in close collaboration with the End-User Stakeholder Representative (to quantify the business value) and with input from the Development Members of the Project Squad (to quantify the efforts).

    - The Project Squad Solution Owner will make decisions based on the principle of weighing value versus effort for the activities and based on a general assessment of the readiness of specific activities to be tackled by the Development Members (e.g. is there a clear consensus among the end users about the expected outcome, is all the technical information required for the activities available, is it clear how it needs to be implemented in DataMiner, etc.).

    - The development team will decide what needs to be done and how it will be done to make to best possible progress towards these objectives.

- **Daily Stand-up**: Only the developers actively participate in this very short daily gathering. Others that attend take an observing position. The outcome of a daily stand-up is a revised planning towards the goal based on new information that has become available during the previous 24 hours, the state of the increment, obstacles, opportunities, etc.

- **Sprint Review**: At the end of every sprint there is a review. The goal is to compare the outcome of the sprint with the previously set expectations and use this information to adapt the next sprint.

    - The Squad Product Owner is accountable for ensuring invitations are sent to the key stakeholders.

    - The Agile coach is accountable for facilitating the review.

    - During this part of the process, the key stakeholders and the Project Squad work together as one team to inspect the outcome of the sprint. The Project Squad explains what is done, what is not done, what obstacles have been encountered, how those obstacles were dealt with, and what their impact is on the forecast of the project.

    - Using this increment as input, both the Project Squad and key stakeholders collaborate on what the team should work on next. All feedback is welcomed considering its priority, effort, value and impact on timing.

    - The result of the sprint review is a shared understanding of the current state of the project and an adjustment of the Solution Backlog to further optimize value delivery for the end user.

- **Sprint Retrospective**: At the end of each sprint there is a retrospect.

    - The Agile Coach is accountable for the preparation and facilitation of the Sprint Retrospective.

    - During this meeting, the entire Project Squad is actively engaged in inspecting the previous sprint in relation to the people, the tools and the processes. Both positive and negative aspects are identified and discussed with the goal of improving the quality and effectiveness with each sprint, cutting out any waste or sources of friction for the team.

    - The Project squad identifies and commits to implementing at least one action point for improvement that came out of this meeting in the next sprint.

- **Solution Backlog Refinement and Balancing**: After each sprint or at any other time deemed necessary, the Project Squad Product Owner can call for a Time Budget Refinement and Balancing session with the End-User Stakeholder Representative. They review all activities that have fallen behind as compared to what was anticipated, investigate why this happened, and immediately decide how this will be resolved (the correction) and how this situation can be prevented or mitigated towards the future (risk mitigation). The objective of this is to continuously track progress and manage the workload ahead, to ensure that the pending activities comfortably fit within the mutually agreed timeframe and budget.

- **User Reviews**: Upon each iteration, the Project Squad Product Owner must organize a User Review session (either recorded or live) for the End-User Stakeholder Representative (who can, and in some cases also should, involve the concerned end users). The purpose of this session is to walk through the work that was achieved during the previous iteration, to answer any questions users may have, and to seek further input from the end users. The Project Squad Product Owner can work with the Development Members and the Solution Owner to organize the reviews. Note that User Reviews can be combined for example with the general Sprint Review sessions.
