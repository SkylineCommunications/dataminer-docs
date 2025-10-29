---
uid: Configuring_job_sections
---

# Configuring job sections

While a user is creating a job, several different job sections can be displayed.

To configure these job sections:

1. Click the user icon in the top-right corner and select *Configuration*.

  The different job sections are displayed in a diagram with nodes extending to the right and in between them. The lowest nodes below the job sections are represented as + icons.

1. In the dropdown box at the top, make sure the right job domain is selected.

1. You can then create new job sections, modify job sections and delete job sections:

   - To create a new job section, click the node where you want to add the job section. Specify the necessary information in the *New* tab of the pop-up window and then click *Save* to add the section.

     Alternatively, instead of creating a new section from scratch, you can re-use a job section that is used in a different domain, by going to the *Existing* tab, selecting the section in the dropdown box and clicking *Save*.

     The following information can be specified if you create a completely new section:

     - *Name*: The title of the job section.

     - *Color*: An optional custom color for the job section, either specified in RGB format or selected by clicking the color icon on the right and selecting one of the available colors.

     - *Icon*: An optional icon for the section.

     - *Type*: Determines the type of section, i.e. *Fields* or *Booking*. Further configuration will depend on the selected type.

     - *Booking manager*: Available for a booking section. Determines which Booking Manager element is used. Once jobs have been created with the selected booking manager element, you will no longer be able to modify this selection.

     - *Booking script*: Available for a booking section. Determines which script is executed when you click an action in the job section. This can for example be a script to create a new booking. See [Configuring jobs linked to bookings](xref:Configuring_jobs_linked_to_bookings).

     - *Allow multiple instances*: Available for a fields section. If this option is selected, and a new job is created, it will then be possible to specify additional instances in tabs. In the list view, the different instances will be separated by a pipe character.

     > [!NOTE]
     > The *Color*, *Icon* and *Allow multiple instances* settings are bound to a specific domain. If the section definition is re-used in other domains, changing these settings in one domain will not affect their configuration in the other domains.

   - To modify a job section, click the pencil icon in the header of the job section. A pop-up window will be displayed where you can modify the fields mentioned above.

   - If a job section of type "fields" has multiple fields, you can move the order in which they will appear with the up and down arrows next to the fields.

   - For a job section of type "fields", you can modify fields via the pencil icon to the right of each field or add more fields using the + icon. See [Configuring a job field](xref:Configuring_a_job_field).

   - To delete a job section, click the recycle bin icon in the job section box. You will then be able to choose whether you want to delete the section completely or only remove the link between this section and the current job domain, so that the section still remains in the database to potentially be used by other domains.

     > [!NOTE]
     > If you delete a job section that has already been used in one or more jobs, it will not be removed from the system but instead it will be hidden. An eye icon will be displayed for the section in the configuration window. Clicking this icon will enable the section again.
