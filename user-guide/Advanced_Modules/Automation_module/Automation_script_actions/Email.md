---
uid: Email
---

# Email

Use this action to send a notification via email.

1. Enter the recipients in the *To*, *CC* and *BCC* fields.

1. Enter the message *Subject*.

1. Enter the email message in the *Message* field.

1. To send a plain text email, select *Plain text*.

1. To include a (legacy) report or a dashboard in the email, select *Include report or dashboard*, select an existing report template or dashboard, add any required elements, parameters, etc.

![Email](~/user-guide/images/Automation_Email.png)<br>*Automation module in DataMiner 10.4.5*

   > [!NOTE]
   >
   > - If you want to specify multiple indices for one table parameter, use a semicolon ";" as separator.
   > - If you want to specify multiple parameters for one element, service, or protocol version, assign them all within a single line.
   > - The icon in front of each item in the drop-down list shows whether the item is a dashboard or a report.

1. If you have selected a report or dashboard to include, optionally click the *Configure* button to further configure it. See [Generating a PDF report based on a dashboard using DataMiner Cube](xref:Generating_a_report_based_on_a_dashboard_Cube).

> [!NOTE]
> It is also possible to add this action within a C# block in a script. For more information, see [SendEmail](xref:Skyline.DataMiner.Automation.Engine.SendEmail(Skyline.DataMiner.Automation.EmailOptions)), [PrepareMailReport](xref:Skyline.DataMiner.Automation.Engine.PrepareMailReport(System.String)) and [SendReport](xref:Skyline.DataMiner.Automation.Engine.SendReport(Skyline.DataMiner.Automation.MailReportOptions)).
