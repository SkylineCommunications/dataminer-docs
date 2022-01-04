# Sending reports by email

Using DMS Scheduler and DMS Automation, you can make DataMiner send email messages that include reports created with the Reporter app or with a third-party report editor.

By default, the email containing the report is sent in HTML format, using the template in *C:\\Skyline Dataminer\\NotifyMail.html*, but it can also be sent in plain text format.

The report content will normally be placed inside the message body. However, you can also choose to attach reports to email messages as separate PDF or MHT files.

Reports can also be copied or uploaded as PDF or MHT files to a shared network folder or an FTP server. Separate options are available for this in the user interface of the Scheduler and Automation apps.

> [!NOTE]
> -  MHT files contain MHTML code and can be opened by a variety of applications, including MS Internet Explorer, MS Word and MS Excel.
> -  Though user permissions may limit the possibilities to view information on certain elements or services in online reports, there are no such restrictions for email reports.

For more information on how to upload or email reports in DataMiner Cube, see:

- [Manually adding a scheduled task](../scheduler/Manually_adding_a_scheduled_task.md), for the Scheduler module.

- [Designing Automation scripts](../automation/Designing_Automation_scripts.md), [Email](../automation/Email.md), [Upload report to FTP](../automation/Upload_report_to_FTP.md), and [Upload report to shared folder](../automation/Upload_report_to_shared_folder.md) for the Automation module.
