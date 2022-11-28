---
uid: Sending_an_email
---

# Sending an email

Use this action to make a Correlation rule send an email to one or more recipients, optionally with an email report attached.

In the *Actions* section of the details pane:

1. Click *Add Action* and select *Send email*.

1. Enter the recipient addresses in the *To*, *CC* and *BCC* boxes. Use semicolons to separate multiple addresses.

   Alternatively, you can also click the *To*, *CC* and *BCC* fields to select users and/or groups from the DMS.

   > [!NOTE]
   > You can also specify the destination addresses in the following formats:
   >
   > - user:domainname\\username
   > - group:domainname\\groupname
   >
   > For email reports only, the following formats are also possible:
   >
   > - ftp:hostname:/path/on/server/remotefilename:username:password
   > - copy:remotefilename:\\\\ipaddress\\path\\to

1. Enter the message *Subject*.

1. Enter the email message in the *Message* field.

   > [!NOTE]
   > The email subject and message can contain placeholders. To insert a placeholder, right-click inside the subject or message, click *Insert placeholder*, and select the placeholder. For more information on the different placeholders, see [Notification template placeholders](xref:Customizing_the_layout_of_notification_messages#notification-template-placeholders).
   >
   > Note that prior to DataMiner 10.0.5, placeholders in the subject only are not supported. To use a placeholder in the subject, you must also use one in the message. From DataMiner 10.0.5 onwards, this limitation no longer applies

1. To send a plain text email, select *Plain text*.

1. To include a report or dashboard in the email, select *Include report or dashboard*, select an existing report template or dashboard, and add any required elements, parameters, etc.

   > [!NOTE]
   >
   > - In the *Elements and services in view selection* section, you can select the “Dynamic” option to indicate that the elements that triggered the Correlation rule have to be included.
   > - If you want to specify multiple indices for one table parameter, use a semicolon “;” as separator.
   > - From DataMiner 9.6.13 onwards, you can select to include a dashboard from the new Dashboards app. The dashboards are listed in the drop-down list along with the reports. The icon in front of each item in the list shows whether the item is a dashboard or a report. From DataMiner 10.0.13 onwards, a *Configure* button is available that allows you to further configure a report based on a dashboard. See [Generating a PDF report based on a dashboard using DataMiner Cube](xref:Generating_a_report_based_on_a_dashboard_Cube).

1. Optionally, to also send the message when the conditions are no longer fulfilled, select *Execute on clear*.

1. Optionally, to also send the message when there is a change to the base alarms of the Correlated alarm, select *Execute on base alarm updates*.

## Using notification message templates

If custom *correlation-infoheader*, *correlation-infoitem*, and *correlation-infofooter* templates have been defined in the file *NotifyTemplates.xml*, you can configure the email message to use these templates.

To do so, insert an *\[info\]* placeholder in the message body (or click *Insert Placeholder* to the right of the text box, and select *More info (base alarms)*).

> [!TIP]
> See also: [Customizing the layout of notification messages](xref:Customizing_the_layout_of_notification_messages)
