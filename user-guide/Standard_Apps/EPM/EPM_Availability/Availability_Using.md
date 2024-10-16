---
uid: Availability_Using
---

# Using the EPM Availability solution

1. To pass endpoints to the solution, add a *MASTER_PING.csv* file in the import directory of the front end, containing all the endpoints.

   This file must have the following header:

   `ENDPOINT_ALIAS;IP;CUSTOMER_NAME;VENDOR_NAME;STATION_NAME;HUB_NAME;SUB_REGION_NAME;REGION_NAME;NETWORK_NAME;LATITUDE;LONGITUDE`

   > [!NOTE]
   > You can use either a semicolon or a comma as the delimiter for the CSV file. Not all fields are needed. Any fields not used can be left blank.

1. On the *Configuration* page of the front-end element, click the *Set* button next to *Import* to provision the elements.

   ![Import button](~/user-guide/images/Availability_Import_button.png)

   > [!NOTE]
   > This process can be automated using the Automation and Scheduler module in Dataminer to retrieve Endpoints from any data source and hit the Import button on the Frontend.

1. Default alarm and trend templates are automatically assigned when using the *EPM_SetupWizard* that have a baseline of thresholds as a starting off point. If you would like to make any further adjustments to the thresholds or apply conditional rules, duplicate the default templates as they will be overwritten with any subsequent Availability package update.

1. Navigate through your network using the EPM Topology app. Simply search and select an entry in the level it resides, and the dropdowns below will show all associated entities. Clicking on the right arrow will open the EPM card with a visual overview, data section, all associated entities in a table, and the topology diagram. At the top you are able to change the topology chain to see other levels.

![Navigation with the Topology app](~/user-guide/images/EPM_Availability_Topology_Navigation.gif)