---
uid: Configuring_domains
---

# Configuring domains

Click the cogwheel button in the header bar of the Ticketing app to access the configuration page.

On the configuration page you can:

- Create a new domain. See [Creating a new domain](#creating-a-new-domain).

- Edit an existing domain. See [Editing an existing domain](#editing-an-existing-domain).

- Configure the fields in a domain. See [Configuring the fields in a domain](#configuring-the-fields-in-a-domain).

- Adjust the detailed configuration of a field. See [Configuring a Ticketing field](#configuring-a-ticketing-field).

### Creating a new domain

1. On the configuration page of the Ticketing app, click the *Add domain* button.

   A new domain will be added at the top of the list of domains.

1. Fill in the name of the new domain and click *Save*.

   A number of default fields will be generated for the domain, which you can further configure if necessary. See [Configuring the fields in a domain](#configuring-the-fields-in-a-domain).

   > [!NOTE]
   > By means of a protocol and element that use the Ticketing Gateway API, fields can also be linked to fields of a third-party system.

### Editing an existing domain

On the configuration page of the Ticketing app, click the pencil icon next to the name of the domain you want to edit. You can then do the following:

- Enter a new domain name and click *Save*, to change the name of the domain.

- Click *Delete*, to remove the domain.

  > [!NOTE]
  > Deleting a domain is not possible if not all DMAs in the DMS can be reached.

### Configuring the fields in a domain

Each domain contains one or more fields. These are displayed on the *Create new ticket* form, and in the overview on the main page of the Ticketing app. On the configuration page of the Ticketing app, there are several ways you can configure the fields:

- To change the order of the fields, click the up and down arrow buttons next to the fields of the relevant domain.

  This will determine both the order of the columns in the Ticketing overview, and the order of the fields presented in the *Create new ticket* form.

- To add a field, click the *Add field* button next to the name of the domain, and then enter the name of the field and select the type of field.

  Depending on the type of field, further configuration options may be available. See [Configuring a Ticketing field](#configuring-a-ticketing-field).

- To remove a field, next to that field, click *Delete*.

  > [!NOTE]
  > The default *State* field cannot be removed, although it is possible to adjust its configuration, including its name.

### Configuring a Ticketing field

To access the detailed configuration of a Ticketing field, on the configuration page of the Ticketing app, next to that field, click *Config*.

This opens a window where you can specify the name of the ticket field, the field type, and a number of other configuration options.

> [!NOTE]
>
> - It is not possible to change the *Type* for a *State* field.
> - The name of a ticket field may not start with an underscore ("\_") or contain any of the following characters, as these are not supported in the indexing database: .#\*,"'

The following configuration options are available, depending on the selected field type:

| Option | Usable with | Description |
|--|--|--|
| Required | All field types except *Check box*, *State* and *Drop-down list*. | Select this option to make this a required field, so that the user will always need to fill it in to be able to save the ticket. |
| Show this field in the ticket overview | All field types except *DataMiner Object*. | Select this option to display the field in the overview panel on the main page of the Ticketing app. |
| Allow single selection filtering on this field | *Drop-down list* and *State* fields. | Select this option to allow users to filter the overview panel on the main page of the Ticketing app by selecting a single filter in the side panel. |
| Allow multiple selection filtering on this field | *Drop-down list* and *State* fields. | Select this option to allow users to filter the overview panel on the main page of the Ticketing app by selecting multiple filters in the side panel. |
| Possible values | *Drop-down list* and *State* fields. | This option lists the possible values a user will be able to select for this field. Click the *x* next to one of the possible values to remove that value. Click the pencil icon next to a value to modify that value. To add a value, click the + icon to the right of *Possible values*. |
| Select default value | *Drop-down list* and *State* fields. | Allows you to specify a value that will be selected by default. |
| Linking alarm | All field types. | Allows you to link the field to a DataMiner alarm field. This way, when a user right-clicks an alarm in the Alarm Console and selects to create a new ticket, the ticket field linked to the alarm field will inherit the alarm field content.<br>You can combine multiple alarm fields and static text in a ticket field by clicking *Add concatenation* after you have added an alarm field, and then adding additional alarm fields and/or static text. |

> [!NOTE]
> A *State* field requires at least one open state and one closed state. A *Drop-down list* field requires at least one possible value.
