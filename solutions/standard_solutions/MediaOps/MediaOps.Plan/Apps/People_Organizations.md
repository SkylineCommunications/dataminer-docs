---
uid: People_Organizations
---

# People & Organizations

Upgrade your business operations with our People and Organizations app. This app simplifies personnel management by enabling you to effortlessly create, edit, and track records for individuals, teams, and organizations. With features like team booking, optimizing personnel allocation for the right job has never been easier.

![People & Organizations Overview](~/solutions/images/People_and_Organizations_Overview.png)

> [!TIP]
> Do you prefer visual learning? Take a look at the [demo video](https://www.youtube.com/watch?v=ybRBZICWMes) about this app. Or if you would like a practical example of how to use this app, refer to the tutorial [Creating an organization with a team and contacts to use as resources in MediaOps apps](xref:Tutorial_MediaOps_People_and_Organizations_Intro).

## App overview

The following pages are available in the app:

- ![People](~/solutions/images/PO_People_Overview.png) **People**: Allows you to [manage all contacts](xref:PO_Managing_Contacts) within your system. [Skills](xref:PO_Managing_Contacts#managing-skills) and [experience levels](xref:PO_Managing_Contacts#managing-experience) can be defined.

- ![Teams](~/solutions/images/PO_Teams_Overview.png) **Teams**: Allows you to [manage all teams](xref:PO_Managing_Teams) within your system. A team can be made bookable, which will create a pool for the team with all people as resources. [Skills](xref:PO_Managing_Contacts#managing-skills) can be used as a capability to find the right person for a job. [Roles](xref:PO_Managing_Teams#managing-roles) can be defined and people within the team can be assigned to those roles.

- ![Organizations](~/solutions/images/PO_Organizations_Overview.png) **Organizations**: Allows you to [manage all organizations](xref:PO_Managing_Organizations) within your system. You can [add or remove organization members](xref:PO_Managing_Organizations#configuring-organization-members). [Categories](xref:PO_Managing_Organizations#managing-organization-categories) can be used to group organizations.

- ![About](~/solutions/images/PO_About.png) **About**: Provides information on the **version** of the MediaOps package.

## People

You can add people to store administrative data on individuals that are relevant to your operations, such as operators, management, contractors, and customers. This data includes contact details, skills, and experience information. People added in this app can be used in other DataMiner applications:

- As contact persons that can be linked to a job in the [Scheduling app](xref:MO_Scheduling).
- As bookable resources in the [Resource Studio](xref:MO_Resource_Studio), [Scheduling](xref:MO_Scheduling), and [Workflow Designer](xref:MO_Workflow_Designer) apps.

The People & Organizations app allows you to define a list of **skills**, which can be assigned to people. These skills appear as capabilities on the associated resources, making it easy to find the right person for a job.

## Organizations

An organization represents a company in your supply chain, such as customers, suppliers, or partners. Each person added to the People & Organizations app can be part of one organization at most. The organizations created here can be used in the [Scheduling app](xref:MO_Scheduling) for the *Organization* field of a job, which can for example be used to specify for which external or internal customer a job is being carried out.

## Teams

Teams are used to group together a smaller number of people. When a team has been created, users can add people to it and assign them a role in the team, such as "member", "supervisor", etc. People can be part of multiple teams at the same time. Teams can be converted into pools of bookable people resources that will show up in the [Resource Studio](xref:MO_Resource_Studio), [Scheduling](xref:MO_Scheduling), and [Workflow Designer](xref:MO_Workflow_Designer) apps. People from different organizations can be part of the same team.
