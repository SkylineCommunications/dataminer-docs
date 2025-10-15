---
uid: GVAMPP_Manager_Using
---

# Using the AMPP Manager app

The Grass Valley Manager application allows users to visualize and control multiple GV AMPP Manager elements.

## App overview

You can select a manager using the dropdown box in the top-right corner of the *Statistics* page.

![Manager Selection](~/dataminer/images/GVAMPP_Manager_Selection.png)

The sidebar on the left of the Grass Valley AMPP Manager app contains buttons that can be used to access different pages of the app:

| Button | Page description |
|:-:|--|
| ![Statistics](~/dataminer/images/GVAMPP_Button1_Icon.png) | Opens the *Workloads Statistics* page, which displays metrics related to workload states, application type, and their distribution across different fabrics. Additionally, the *DataMiner Applications* graphic shows how workloads are distributed across the different DataMiner Application elements. |
| ![Workloads Control](~/dataminer/images/GVAMPP_Button2_Icon.png) | Opens the *Workloads Control* page, which provides multi-criteria search and filtering, along with the ability to start or stop selected workloads. |
| ![Snapshots Control](~/dataminer/images/GVAMPP_Button2_Icon.png) | Opens the *Snapshots Control* page. Similar to *Workloads Control*, this displays a table of all discovered snapshots, allowing users to start or stop selected ones. |
| ![Configuration](~/dataminer/images/GVAMPP_Button3_Icon.png) | Opens the *Setup* page, where users can [configure the external component](xref:GVAMPP_Manager_Installing#installing-and-configuring-the-communication-component) and create a GV AMPP Manager element. |
| ![About](~/dataminer/images/GVAMPP_Button4_Icon.png) | Opens the *About* page, which shows the application version information. |

## Configuring workload application elements

On the Workloads Control page, the **Workload Element** column displays the currently assigned application element. An application element utilizes a specialized connector that processes the configuration and state messages specific to a particular application type. This connector also includes configuration parameters that allow changes of the workload.

![Application element on the Workloads Control page](~/dataminer/images/GVAMPP_application_elementy_column.png)

Clicking the button in the *Workload Element* column, as shown above, opens a dialog where you can either assign the selected workload to an existing application element or create a new element and then assign the workload to it:

![Create or add an application element](~/dataminer/images/GVAMPP_create_or_select_application_element.png)

Once an application element has been assigned, you can click the icon in the **AMPP Navigation** column to open the application element using the [Monitoring app](xref:Working_with_the_Monitoring_app):

![Navigate to monitor](~/dataminer/images/GVAMPP_navigation.png)

In the Monitoring app, this will for example look like this:

![Monitor element](~/dataminer/images/GVAMPP_monitor.png)
