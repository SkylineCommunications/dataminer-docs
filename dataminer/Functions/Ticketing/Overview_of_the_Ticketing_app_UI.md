---
uid: Overview_of_the_Ticketing_app_UI
---

# Overview of the Ticketing app UI

> [!IMPORTANT]
> The Ticketing app is obsolete. It is no longer available from DataMiner 10.5.0 [CU11]/10.6.0/10.6.2 onwards.

The main page of the Ticketing app consists of a header bar, a side panel, and an overview panel.

- The header bar contains, from left to right:

    - The *Ticketing* button: Click this button to return to the main page of the Ticketing app.

    - The domain selector: Click this button and select a domain to switch to a different domain. The currently selected domain is displayed on the button.

    - The *New* button: Click this button to open a form to create a new ticket.

    - A cogwheel button: Click this button to access the domain and fields configuration.

    - The name of the current user: Click the user name and select *Log out* to log out of the app.

    > [!NOTE]
    > - Depending on your user permissions, not all buttons may be available.
    > - If you scroll down in the app, the header may be hidden from view in order to optimize the amount of information shown. As soon as you scroll upwards, the header will be displayed again.

- The side panel on the left side of the app can be collapsed like any card side panel in Cube. This panel can be used to filter the overview panel on the right.

    - By default, you can always filter using the quick filter at the top of the panel, by entering a piece of text. Any tickets with a field that matches the text you entered will be displayed.

        > [!NOTE]
        > Certain wildcards and special characters can be used in the filter:
        > - An asterisk (\*) can be used as a placeholder for one or several subsequent characters.
        > - A question mark (?) can be used as a placeholder for a single character.
        > - When an exclamation point (!) or dash (-) is placed in front of a search term, records containing the term will be excluded.
        > - To search for an exact phrase, surround it by double quotes (").

    - By default, a time filter is available below this, allowing you to display only active tickets, or tickets created in a particular time span.

    - Depending on the field configuration of the domain, you can also use single or multiple filters for fields that have several possible values.

- The main overview panel on the right side of the app contains an overview of all the tickets that have been created for the selected domain. The columns displayed in the overview are determined by the configuration of the domain.

    - Select a ticket in the overview to open a side panel on the right with detailed information.

    - When a ticket is selected, more buttons become available in the header bar, allowing you to view, edit or delete the ticket.

    - Double-click a ticket to view a list of all revisions that have been done to this ticket. Alternatively, you can also select the ticket and click the *View* button to do so.
