## Email

Use this action to send a notification via email.

1. Enter the recipients in the *To*, *CC* and *BCC* fields.

2. Enter the message *Subject*.

3. Enter the email message in the *Message* field.

4. To send a plain text email, select *Plain text*.

5. To include a report or dashboard in the email, select *Include report or dashboard*, select an existing report template or dashboard, and add any required elements, parameters, etc.

    > [!NOTE]
    > - If you want to specify multiple indices for one table parameter, use a semicolon “;” as separator.
    > - From DataMiner 9.6.13 onwards, you can select to include a dashboard from the new Dashboards app. The dashboards are listed in the drop-down list along with the reports. The icon in front of each item in the list shows whether the item is a dashboard or a report. From DataMiner 10.0.13 onwards, a *Configure* button is available that allows you to further configure a report based on a dashboard. See [Generating a report based on a dashboard](../newR_D/Generating_a_report_based_on_a_dashboard.md).

> [!NOTE]
> It is also possible to add this action within a C# block in a script. For more information, see [SendEmail](../../part_7/CsharpReference/Engine_methods.md#sendemail), [PrepareMailReport](../../part_7/CsharpReference/Engine_methods.md#preparemailreport) and [SendReport](../../part_7/CsharpReference/Engine_methods.md#sendreport).
>
