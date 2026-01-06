---
uid: Creating_a_completely_new_dashboard
---

# Creating a completely new dashboard

To learn how to create a dashboard, you can follow the steps below or watch this short video, which shows you how to create a simple dashboard to monitor system health:

<div style="width: 100%; max-width: 800px;">
  <video style="width: 100%; aspect-ratio: 16 / 9; height: auto;" controls>
    <source src="~/dataminer/images/CreatingYourFirstDashboard.mp4" type="video/mp4">
  </video>
</div>

<br>

1. On the home page, click *Start with a new blank dashboard*. <!--TO DO-->

   Alternatively, you can also select a folder or dashboard in the list of dashboards on the left and select *New dashboard* in the right-click menu.

1. Enter the name of the dashboard.

1. To specify the folder that should contain the dashboard, specify the folder name in the *Location* box, or select the folder in the tree view below this box.

   If you created a dashboard by first selecting a folder in the list, this folder will automatically be selected.

   You can also create folders at this point in the dashboard creation, by hovering the mouse pointer over the folder in the tree view where you want to create a folder and clicking the + icon. Then specify the folder name and click the check mark icon.

1. In the *Security* box, select whether other users should be able to view and edit the dashboard.

   ![Security level](~/dataminer/images/Security_Level.png)<br>*Setting dashboard security level in DataMiner 10.4.5*

   > [!NOTE]
   > - Once the dashboard has been created, you can further refine which users have which level of access in the dashboard options. See [Changing dashboard settings](xref:Configuring_dashboard_security).
   > - The built-in Administrator account always has full access to all dashboards.

1. Click *Create* or *OK*, depending on your DataMiner version<!--RN 38278-->.

1. Optionally, fine-tune the dashboard settings. See [Changing dashboard settings](xref:Changing_dashboard_settings).

1. Optionally, fine-tune the dashboard layout. See [Configuring the dashboard layout](xref:Configuring_the_dashboard_layout).

1. Configure the necessary components. See [Configuring components](xref:Configuring_components).

1. When the dashboard is ready, in the top-right corner of the screen, click the “x” icon.

> [!NOTE]
> The following characters are not allowed in the name of a dashboard or dashboard folder: / \\ : ; \* ? \< \> \| °
>
> If you do specify a backslash (“\\”) in a folder name, this will not become part of the folder name. Instead, a subfolder will be created, with the characters after the backslash as its name.
>

<div style="display: flex; align-items: center; justify-content: space-between; margin: 0 auto; max-width: 100%;">
  <div style="border: 1px solid #ccc; border-radius: 10px; padding: 10px; flex-grow: 1; background-color: #DEF7FF; margin-right: 20px; color: #000000;">
    <b>💡 TIPS TO TAKE FLIGHT</b><br>
    Now that you know how to create a dashboard, you may be interested in reading our instructions on <a href="xref:Sharing_a_dashboard" style="color: #657AB7;">sharing a dashboard</a> with others.
  </div>
  <img src="~/images/Skye.svg" alt="Skye" style="width: 100px; flex-shrink: 0;">
</div>
