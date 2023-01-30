---
uid: Sending_reports_by_email
---

# Sending reports by email

Using DataMiner Scheduler and DataMiner Automation, you can make DataMiner send email messages that include reports created with the Reporter app or with a third-party report editor.

By default, the email containing the report is sent in HTML format, using the template in *C:\\Skyline Dataminer\\NotifyMail.html*, but it can also be sent in plain text format.

The report content will normally be placed inside the message body. However, you can also choose to attach reports to email messages as separate PDF or MHT files.

> [!NOTE]
> To attach a report to an email message as a separate PDF using DataMiner Scheduler, when you configure the email action in the scheduled task, select both *Plain text* and *Include report or dashboard*.

Reports can also be copied or uploaded as PDF or MHT files to a shared network folder or an FTP server. Separate options are available for this in the user interface of the Scheduler and Automation apps.

> [!NOTE]
>
> - MHT files contain MHTML code and can be opened by a variety of applications, including Microsoft Word and Excel.
> - Though user permissions may limit the possibilities to view information on certain elements or services in online reports, there are no such restrictions for email reports.

For more information on how to upload or email reports in DataMiner Cube, see:

- [Manually adding a scheduled task](xref:Manually_adding_a_scheduled_task), for the Scheduler module.

- [Designing Automation scripts](xref:Designing_Automation_scripts), [Email](xref:Email), [Upload report to FTP](xref:Upload_report_to_FTP), and [Upload report to shared folder](xref:Upload_report_to_shared_folder) for the Automation module.
