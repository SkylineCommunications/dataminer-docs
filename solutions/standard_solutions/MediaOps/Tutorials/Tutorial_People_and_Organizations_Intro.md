---
uid: Tutorial_MediaOps_People_and_Organizations_Intro
---

# Creating an organization with a team and contacts to use as resources in MediaOps apps

In this tutorial, you will learn how to create an organization, a team, and contacts in the [People & Organizations app](xref:People_Organizations), to interconnect these, and to make them bookable so that they can be treated as resources in other MediaOps apps.

Expected duration: 15 minutes

> [!NOTE]
> The content and screenshots for this tutorial have been created using DataMiner version 10.5.5 and MediaOps version 1.3.1.

## Prerequisites

- A DataMiner System using DataMiner 10.5.4 or higher.
- Access to the **People & Organizations** application.

## Overview

- [Step 1: Create a new organization](#step-1-create-a-new-organization)
- [Step 2: Create a new contact](#step-2-create-a-new-contact)
- [Step 3: Create a new team](#step-3-create-a-new-team)
- [Step 4: Add the contact to the team](#step-4-add-the-contact-to-the-team)
- [Step 5: Make the team bookable](#step-5-make-the-team-bookable)

## Step 1: Create a new organization

1. Navigate to the People & Organizations app.

1. Navigate to the *Organizations* page.

1. In the top-right corner, click *+ New Organization*.

1. Enter the *Organization name* you want to give to your organization.

1. Click *Save*.

   ![New Organization](~/solutions/images/People_And_Organizations_New_Organization.png)

1. In the new dialog, select your new organization and click *Activate Selected* to make it available in other MediaOps apps.

   ![Activate Organization](~/solutions/images/People_And_Organizations_Activate_Organization.png)

## Step 2: Create a new contact

1. Navigate to the *People* page.

1. In the top-right corner, click *New contact*.

1. Enter the *Full name* of the contact.

1. In the *Organization* box, select the organization you created in the previous step.

1. Click *Save*.

   ![New Contact](~/solutions/images/People_And_Organizations_New_Contact.png)

1. In the new panel, select your new contact and click *Activate Selected* to make it available in other MediaOps apps.

## Step 3: Create a new team

1. Navigate to the *Teams* page.

1. In the top-right corner, click *+ New team*.

1. Enter the *Team name* you want to give to your team.

1. Click *Save*.

   ![New Team](~/solutions/images/People_And_Organizations_New_Team.png)

1. In the new dialog, select your new team and click *Activate Selected* to make it available in other MediaOps apps.

## Step 4: Add the contact to the team

1. In the *Teams* table, click the button in the *Details* column for the team you have just created.

1. Click the *Edit members* button in the upper left corner of the new panel.

1. In the list on the left, find and select the contact you created earlier.

1. Click the arrow button that points to the right to move the person to the team.

   ![Add Contact To Team](~/solutions/images/People_And_Organizations_Add_Contact_To_Team.png)

## Step 5: Make the team bookable

1. If you closed the panel in the previous step, open it again by clicking the button in the *Details* column.

1. Click the *Bookable* switch in the top-right corner and click *OK* to confirm.

   ![Make Team Bookable](~/solutions/images/People_And_Organizations_Make_Team_Bookable.png)

The team and its members should now show up in the Resource Studio app. The team will be available as a resource pool, and its members will show up as resources belonging to that pool.

<!-- TODO: To make this example more complete, a step 6 should be added where the contact is actually booked in a job -->