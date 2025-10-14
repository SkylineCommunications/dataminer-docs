---
uid: GVAMPP_Manager_Using
---

# Using the AMPP Manager Application

The Grass Valley Manager application allows users to visualize and control multiple GV AMPP Manager elements.

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

## Using the Workload Application Element Configurator

In the Workloads panel, the **Workload Element** column displays the currently assigned Application Element. An Application Element utilizes a specialized connector that processes both the configuration and state messages specific to a particular application type. Additionally, this connector offers configuration parameters that allows the change of the workload; for example, set the recording file or start a Clip Player: 

![Application Element](~/dataminer/images/GVAMPP_application_elementy_column.png)

When the button is clicked, a configurator dialog will allow the user to either assign the selected workload to an existins Application Element or to create an element and then assign the workload to it:

![Select Application Element](~/dataminer/images/GVAMPP_create_or_select_application_element.png)


Once assigned, the **AMPP Navigation** column will show the icon to jump to the Application Element using the Monitoring application:

![Navigate to monitor](~/dataminer/images/GVAMPP_navigation.png)

![Monitor element](~/dataminer/images/GVAMPP_monitor.png)


