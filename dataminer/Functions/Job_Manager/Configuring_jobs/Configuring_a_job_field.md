---
uid: Configuring_a_job_field
---

# Configuring a job field

When you are configuring a job section, you can edit or create job fields. See [Configuring job sections](xref:Configuring_job_sections).

For each field, the following configuration is possible.

- **Name**: The name of the field that will be displayed when the user is creating or editing a job. This box must always be filled in.

- **Type**: Allows you to select the type of field in a dropdown list. A field always has to have a particular type assigned. The following types are available:

    - *Datetime*: Select this type to create a box in which the user will need to specify a date and time.

    - *Double*: Select this type to create a box in which the user will need to specify a double. (For more information on this data type, see <https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/data-types/index>).

    - *Dropdown*: When you select this type, you will need to specify the different values the user will be able to select in the dropdown list.

    - *Time span*: Select this type to create a box in which the user will need to specify a time span.

    - *Check box*: Select this type to create a checkbox.

    - *Integer*: Select this type to create a box in which the user will need to specify a integer. (For more information on this data type, see <https://docs.microsoft.com/en-us/dotnet/visual-basic/language-reference/data-types/index>).

    - *Auto increment*: Select this type to create an automatic counter. If a user specifies -1 in this field, DataMiner will automatically look up the next available number and use this, so that with every new job this number increases. If the user specifies a different number in this field, that number will be used instead. When you select this type, you can optionally specify a prefix and/or a suffix that will be added to the number.

        > [!NOTE]
        > - It is not possible to edit the value of the auto-increment field. The field will only be displayed after a job has been created and the value of the field is filled in by the system. This field can also not be set as optional, so the *Required* checkbox is not available in the configuration for this field.
        > - If you change the format of auto-increment fields when these are used in existing jobs, the existing jobs will keep using the old format.

    - *User*: Select this type to create a dropdown list in which one of the users available in the DataMiner System will need to be selected.

    - *URL*: Select this type to create a box in which only a URL can be specified.

    - *Email*: Select this type to create a box in which only an email address can be specified.

    - *Static text*: Select this type if you want to display static text that cannot be changed by the user. When you select this type, you will also need to specify this static text.

    - *Text*: Select this type to create a box in which the user can specify any text.

- **Tooltip**: The text specified in this box will be displayed when the user hovers the mouse pointer over the field.

- **Required**: Select this option if the field must always be filled in when a job is created. This option is not available for fields of type *Static text* and *Auto increment*.

- **Show in list view**: Clear this option if this field should not be displayed in the list view of the app. This option is not available for fields of type *Static text*.

- **Read only**: If you select this option, users will not be able to modify the field. Changes to the field will only be possible via scripts. This option is not available for fields of type *Static text* and *Auto increment*. Prior to DataMiner 10.2.1/10.3.0 it is also not available for the *Name*, *Start Time* and *End Time* field of the default section.

- **Allow filtering on this field**: Only displayed for fields of type *Dropdown* prior to DataMiner 10.2.0/10.1.5. From DataMiner 10.2.0/10.1.5 onwards, this option is also available for fields of type *Text*, *Email* and *URL*. Determines whether users will be able to filter on the value selected for the field.

When the configuration is ready, click *Save*.

> [!NOTE]
> If a field is used by existing jobs, you can modify its type as well as any selectable *Dropdown* options.
