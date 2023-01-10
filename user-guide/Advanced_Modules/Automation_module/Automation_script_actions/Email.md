---
uid: Email
---

# Email

Use this action to send a notification via email.

1. Enter the recipients in the *To*, *CC* and *BCC* fields.

1. Enter the message *Subject*.

1. Enter the email message in the *Message* field.

1. To send a plain text email, select *Plain text*.

1. To include a report or dashboard in the email, select *Include report or dashboard*, select an existing report template or dashboard, and add any required elements, parameters, etc.

   > [!NOTE]
   >
   > - If you want to specify multiple indices for one table parameter, use a semicolon “;” as separator.
   > - From DataMiner 9.6.13 onwards, you can select to include a dashboard from the new Dashboards app. The dashboards are listed in the drop-down list along with the reports. The icon in front of each item in the list shows whether the item is a dashboard or a report. From DataMiner 10.0.13 onwards, a *Configure* button is available that allows you to further configure a report based on a dashboard. See [Generating a PDF report based on a dashboard using DataMiner Cube](xref:Generating_a_report_based_on_a_dashboard_Cube).

> [!NOTE]
> It is also possible to add this action within a C# block in a script. For more information, see [SendEmail](xref:Skyline.DataMiner.Automation.Engine#Skyline_DataMiner_Automation_Engine_SendEmail_Skyline_DataMiner_Automation_EmailOptions_), [PrepareMailReport](xref:Skyline.DataMiner.Automation.Engine#Skyline_DataMiner_Automation_Engine_PrepareMailReport_System_String_) and [SendReport](xref:Skyline.DataMiner.Automation.Engine#Skyline_DataMiner_Automation_Engine_SendReport_Skyline_DataMiner_Automation_MailReportOptions_).
