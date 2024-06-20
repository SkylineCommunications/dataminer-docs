---
uid: people_organizations_overview
---

# People and Organizations

Welcome to the **People and Organizations application**!

1. [People](xref:people_organizations_people): Navigate people and memberships.
1. [Teams](xref:people_organizations_teams): Manage teams and make them bookable.
1. [Organizations](xref:people_organizations_organizations): Assign people to organizations.

## Features

People are omnipresent with anything we do in MediaOps.

- Manage **organizations**, **teams** and **people**.
- Spans across the **supply chain**: your teams, contractors, suppliers, customers, and more.
- Contact persons are at **your fingertips** at **all times**, on **any screen and API of DataMiner**.
- Turn people and teams into **bookable resources** and **resource pools**.
- Assign **expertise** to teams, and **skills** to people, to facilitate **accurate booking**.
- Review and **analyze** team and people **activities over time**.
- Integrate with **3rd party CRM systems** to exchange (import/export) people and team information.

In this comprehensive guide, we will explore how to manage people, teams and organizations. Whether you're a seasoned user or new to the system, this documentation will empower you to make informed decisions and streamline your cost and billing processes. Let's dive in!

## Data Model

### People

<table>
    <thead>
        <tr>
            <th>Field Name</th>
            <th>Type</th>
            <th>Description</th>
            <th>Possible Values</th>
            <th>Default Value</th>
        </tr>
    </thead>
    <tbody>
        <tr>
          <td colspan=5 style="text-align:center;">People information</td>
        </tr>
        <tr>
          <td>Full name</td>
          <td>String</td>
          <td>This contact's full name</td>
          <td>Any alphanumeric text</td>
          <td></td>
        </tr>
        <tr>
          <td>Personal skills</td>
          <td>Guid</td>
          <td>A reference to another DOM object representing the skill assigned to this contact.</td>
          <td>A valid Guid identifier referring to another valid existing DOM object of type Skill.</td>
          <td></td>
        </tr>
        <tr>
          <td>Experience Level</td>
          <td>Guid</td>
          <td>A reference to another DOM object representing the experience assigned to this contact.</td>
          <td>A valid Guid identifier referring to another valid existing DOM object of type Expertise.</td>
          <td></td>
        </tr>
        <tr>
        <td colspan=5 style="text-align:center;">Contact info</td>
        </tr>
        <tr>
          <td>Email</td>
          <td>String</td>
          <td>This contact's email address.</td>
          <td>Any alphanumeric text.</td>
          <td></td>
        </tr>
        <tr>
          <td>Phone</td>
          <td>String</td>
          <td>This contact's phone number.</td>
          <td>Any alphanumeric text.</td>
          <td></td>
        </tr>
        <tr>
          <td>Street address</td>
          <td>String</td>
          <td>This contact's current residing street address.</td>
          <td>Any alphanumeric text.</td>
          <td></td>
        </tr>
        <tr>
          <td>City</td>
          <td>String</td>
          <td>This contact's current residing city.</td>
          <td>Any alphanumeric text.</td>
          <td></td>
        </tr>
        <tr>
          <td>Zip</td>
          <td>Int</td>
          <td>This contact's current zip code.</td>
          <td>Any integer numeric value.</td>
          <td></td>
        </tr>
        <tr>
          <td>Country</td>
          <td>Enum</td>
          <td>This contact's current residing country.</td>
          <td>Belgium, United States, France, etc...</td>
          <td></td>
        </tr>
        <tr>
          <td colspan=5 style="text-align:center;">Organization</td>
        </tr>
        <tr>
          <td>Organization</td>
          <td>Guid</td>
          <td>A reference to another DOM object representing the organization this contact is assigned to.</td>
          <td>A valid Guid identifier referring to another valid existing DOM object of type Organization.</td>
          <td></td>
        </tr>
        <tr>
          <td colspan=5 style="text-align:center;">Team (multiple)</td>
        </tr>
        <tr>
          <td>Team</td>
          <td>Guid</td>
          <td>A reference to another DOM object representing the team this contact is a member of.</td>
          <td>A valid Guid identifier referring to another valid existing DOM object of type Team.</td>
          <td></td>
        </tr>
        <tr>
          <td>Team role</td>
          <td>Guid</td>
          <td>A reference to another DOM object representing the role this contact has on this team.</td>
          <td>A valid Guid identifier referring to another valid existing DOM object of type Role.</td>
          <td></td>
        </tr>
        <tr>
          <td colspan=5 style="text-align:center;">Resource</td>
        </tr>
        <tr>
          <td>Linked resource</td>
          <td>Guid</td>
          <td>A reference to another DOM object representing the resource that is linked to this contact.</td>
          <td>A valid Guid identifier referring to another valid existing DOM object of type Resource.</td>
          <td></td>
        </tr>
    </tbody>
</table>

### Teams

<table>
    <thead>
        <tr>
            <th>Field Name</th>
            <th>Type</th>
            <th>Description</th>
            <th>Possible Values</th>
            <th>Default Value</th>
        </tr>
    </thead>
    <tbody>
        <tr>
          <td colspan=5 style="text-align:center;">Team information</td>
        </tr>
        <tr>
          <td>Team name</td>
          <td>String</td>
          <td>The team's name.</td>
          <td>Any alphanumeric text.</td>
          <td></td>
        </tr>
        <tr>
          <td>Team email</td>
          <td>String</td>
          <td>The team's email address.</td>
          <td>Any alphanumeric text.</td>
          <td></td>
        </tr>
        <tr>
          <td>Team description</td>
          <td>String</td>
          <td>This team's description.</td>
          <td>Any alphanumeric text.</td>
          <td></td>
        </tr>
        <tr>
          <td>Team expertise(s)</td>
          <td>Guid</td>
          <td>A reference to another DOM object representing the individual expertise assigned to this team.</td>
          <td>A valid Guid identifier referring to another valid existing DOM object of type Expertise.</td>
          <td></td>
        </tr>
        <tr>
          <td>Bookable</td>
          <td>Boolean</td>
          <td>Whether this team's time can be booked or scheduled.</td>
          <td>True, False</td>
          <td></td>
        </tr>
        <tr>
          <td colspan=5 style="text-align:center;">Collaboration</td>
        </tr>
        <tr>
          <td>Create MS teams channel</td>
          <td>Boolean</td>
          <td></td>
          <td></td>
          <td></td>
        </tr>
        <tr>
          <td>Create MS team</td>
          <td>Boolean</td>
          <td></td>
          <td></td>
          <td></td>
        </tr>
        <tr>
          <td>MS team name</td>
          <td>String</td>
          <td></td>
          <td></td>
          <td></td>
        </tr>
        <tr>
          <td>Channel id</td>
          <td>String</td>
          <td></td>
          <td></td>
          <td></td>
        </tr>
        <tr>
          <td>Team id</td>
          <td></td>
          <td></td>
          <td></td>
          <td></td>
        </tr>
    </tbody>
</table>

### Organizations

<table>
    <thead>
        <tr>
            <th>Field Name</th>
            <th>Type</th>
            <th>Description</th>
            <th>Possible Values</th>
            <th>Default Value</th>
        </tr>
    </thead>
    <tbody>
        <tr>
          <td colspan=5 style="text-align:center;">Organization information</td>
        </tr>
        <tr>
          <td>Organization name</td>
          <td>String</td>
          <td>The name of this organization</td>
          <td>Any alphanumeric text value.</td>
          <td></td>
        </tr>
        <tr>
          <td>Category</td>
          <td>Guid</td>
          <td>A reference to another DOM object representing the individual category assigned to this organization.</td>
          <td>A valid Guid identifier referring to another valid existing DOM object of type Category.</td>
          <td></td>
        </tr>
        <tr>
          <td colspan=5 style="text-align:center;">Contracts (multiple)</td>
        </tr>
        <tr>
          <td>Contracts</td>
          <td>Guid</td>
          <td>A reference to another DOM object representing the contract assigned to this organization.</td>
          <td>A valid Guid identifier referring to another valid existing DOM object of type Contract.</td>
          <td></td>
        </tr>
        <tr>
          <td>Bill to</td>
          <td>Guid</td>
          <td>A reference to another DOM object representing the billing contact for this contract.</td>
          <td>A valid Guid identifier referring to another valid existing DOM object of type Contract.</td>
          <td></td>
        </tr>
    </tbody>
</table>
