---
uid: DOM_Designer_Excel_config
---

# Configuring the Excel file

## Name of the Excel file

The name of the Excel file to provision the DOM definition and module needs to be in the following format:

`ModuleName^DefinitionName.xlsx`

Everything in front of the ^ is the module name, and everything after the ^ is the definition name. Spaces are not allowed in the name.

For example: `Channels^IPTVchannel.xlsx`

## *fields* tab

In the fields tab, you should define all fields with their data type for the object regardless of the state, for example:

| SectionName | Name | Type | Default | Values | Tooltip | Linked DOM Module Name | Linked DOM Definition Name | ResourcePool Filter | View Filter |
|---|---|---|---|---|---|---|---|---|---|
| General information | Name contact | String |  |  |  |  |  |  |  |
| General information | Role | Enum | | Engineer/Operator/<br>Technician/Planner/<br>Technical Director/<br>Cameraman  |  |  |  |  |  |
| General information | Experience | Enum |  | Junior/Senior/<br>Principal |  |  |  |  |  |
| General information | Team | Enum |  | IT/DOCSIS/Video/<br>IP/General/Production |  |  |  |  |  |
| General information | Street address | String |  |  |  |  |  |  |  |
| General information | City | String |  |  |  |  |  |  |  |
| General information | ZIP | Int64 |  |  |  |  |  |  |  |
| General information | Country | String |  |  |  |  |  |  |  |
| General information | Email | String |  |  |  |  |  |  |  |
| General information | Cell phone number | String |  |  |  |  |  |  |  |

These are the columns in this tab:

- **Section Name**: A section is a logical grouping of fields. Fill in the same section name for multiple fields if they belong in the same section.

- **Name**: The name of the field. This is both the display name and the ID of the field.

- **Type**: The data type of the DOM field, e.g. string, int, datetime, etc.

- **Default**: Optional. This is the value that will be automatically entered in a field when a new record or instance is created. For example, in an address object, you can set the default value for the city field to "New York". When users add a record to the table, they can then either accept this value or enter the name of a different city.

- **Values**: This column is only used for the Enum field type. This is where you can define the different Enum options.

- **Tooltip**: Optional. A tooltip can be used to specify extra information about the field when the user moves the mouse pointer over it.

- **Linked DOM Module Name**: This column is only used for DOM instance or multiple DOM instance field types. It specifies the module the field needs to point to.

- **Linked DOM definition Name**: This column is only used for DOM instance or multiple DOM instance field types. It specifies which definition the field needs to point to, within the module that is defined in the previous column.

- **ResourcePool Filter**: This is an optional column for the resource field type. It specifies an optional filter to filter out resources from a specific resource pool.

- **View Filter**: This is an optional column for the element field type. It specifies an optional filter to filter out elements from a specific view.

## *form_stateName* tab

For each possible state, you should have a corresponding tab titled form_*stateName*. For example, you could make a tab *form_Not active* and a tab *form_Validated*, each describing the following information for the different fields of the object in these respective states:

- **Name**: The name of the field.

- **Visible**: Determines whether the field should be shown for this state. Set this field to *yes* or *no*.

- **Read/write**: Determines whether users will be able to edit the value of the field when the object is in this state. Set this field to *read-write* or *read-only*.

- **Required**: Determines whether the field must be filled in or not for this state. Set this field to *yes* or *no*.

For example:

| Name | Visible | Read/write | Required |
|--|--|--|--|
| Name contact | yes | read-write | yes |
| Role | yes | read-write | yes |
| Experience | yes | read-write | yes |
| Team | yes | read-write | yes |
| Street address | yes | read-write | no |
| City | yes | read-write | no |
| ZIP | yes | read-write | no |
| Country | yes | read-write | no |
| Email | yes | read-write | no |
| Cell phone number | yes | read-write | no |

## *states* tab

The states tab describes all transitions that are possible between states.

In the example below, it is possible to go from the state *Not active* to *Validated* and from the state *Validated* to *Not active*.

| Transitions | Not active | Validated |
|--|--|--|
| Not active | no | yes |
| Validated | yes | no |

## *buttons* tab

It is possible to add buttons to a DOM form that will trigger an Automation script to add custom logic or automation to your object. These are configured in this tab.

In the example below, two buttons are configured. The first is only shown when an object is in the *Not active* state, and the second is only shown in the *Validated* state. The Automation script gets the context of which button is selected, so you can combine all logic from your buttons in the same script.

| Button | Script Name | Tooltip | Not active | Validated |
|--|--|--|--|--|
| Validate | People DOM button script |  | yes | no |
| Set as not active | People DOM button script |  | no | yes |

## *events* tab

Not only buttons can trigger an Automation script. You can also have a script triggered by each CRUD (Create, Read, Update, and Delete) action for an object. This is defined in the events tab.

For example:

| Action | Script Name|
|--|--|
| create | People CRUD script |
| delete | People CRUD script |
| update | People CRUD script |
