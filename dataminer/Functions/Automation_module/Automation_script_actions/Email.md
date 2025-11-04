---
uid: Email
---

# Email

Use this action to send a notification via email.

![Email](~/dataminer/images/Automation_Email.png)<br>*Automation module in DataMiner 10.5.6*

- You need to specify at least one recipient in the *To*, *CC*, and/or *BCC* fields.

  Prior to DataMiner 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12<!--RN 43848-->, at least one *To* recipient is required, and all recipients need to be present in your contact list.

- The *Subject* field is required. The *Message* field is optional.

- The subject and message support the following **placeholders**<!--RN 42985-->:

  - `[dummyX]`: This will be replaced with the name of the specific element you want to display. X is the dummy ID.
  - `[user]`: This will be replaced with the name of the user executing the Automation script.

- To send a **plain text** email, select *Plain text*.

- To include a **dashboard** in the email, select *Include report or dashboard*, select an existing dashboard, and optionally click the *Configure* button to further configure it. See [Generating a PDF report based on a dashboard using DataMiner Cube](xref:Generating_a_report_based_on_a_dashboard_Cube).

  You can select any of the dashboards available in the [dashboards app](xref:newR_D).

- To include a **legacy report** in the email, select *Include report or dashboard*, select an existing report template, and add any required elements, parameters, etc. If you want to specify multiple indices for one table parameter, use a semicolon ";" as separator. If you want to specify multiple parameters for one element, service, or protocol version, assign them all within a single line.

  Legacy reports are only available if the [legacy Reporter module](xref:reporter) is still available in your system.

> [!TIP]
> It is also possible to add this action within a C# block in a script. For more information, see [SendEmail](xref:Skyline.DataMiner.Automation.Engine.SendEmail(Skyline.DataMiner.Automation.EmailOptions)), [PrepareMailReport](xref:Skyline.DataMiner.Automation.Engine.PrepareMailReport(System.String)) and [SendReport](xref:Skyline.DataMiner.Automation.Engine.SendReport(Skyline.DataMiner.Automation.MailReportOptions)).
