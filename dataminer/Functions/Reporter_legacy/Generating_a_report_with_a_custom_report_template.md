---
uid: Generating_a_report_with_a_custom_report_template
---

# Generating a report with a custom report template

Custom report templates can be used to generate reports that are sent by email. However, you can also directly generate reports using the Reporter app, or generate reports based on a custom template by constructing a URL which users can then click.

- [Generating a report with the Reporter app](xref:Generating_a_report_with_the_Reporter_app)

- [Generating reports with a report URL](xref:Generating_reports_with_a_report_URL)

> [!NOTE]
> - By default, when the generation of a report is started, but there is not response within 60 minutes, the SLASPConnection ends the request and a timeout error is generated saying that the report could not be generated.<br>However, it is possible to customize this setting in *MaintenanceSettings.xml* in case reports need to be generated that need more than 60 minutes. See [SLASPConnection.ReportResponseTimeout](xref:MaintenanceSettings.SLASPConnection.ReportResponseTimeout).
> - If you do not have the necessary rights to view certain elements or services, you will not be able to view information on these elements or services in online reports. However, there are no such restrictions for email reports.
>
