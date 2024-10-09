---
uid: Availability_Using
keywords: Availability Using
---


# Using the EPM Availability solution

1. Passing in endpoints into the solution is simple. All that is needed is a MASTER_PING.csv file in the Frontend's import directory. This file should have this header
    >ENDPOINT_ALIAS;IP;CUSTOMER_NAME;VENDOR_NAME;STATION_NAME;HUB_NAME;SUB_REGION_NAME;REGION_NAME;NETWORK_NAME;LATITUDE;LONGITUDE

    > [!NOTE]
    > Semicolon and comma can be used as the delimiter for the CSV file. Not all fields are needed, any fields not used can be left blank.

1. Once the file has been updated with all of the Endpoints, simply hit the Import button on the Frontend's Configuration page to provision all of the elements.

    ![alt text](image.png)

    > [!NOTE]
    > This process can be automated using the Automation and Scheduler module in Dataminer to retrieve Endpoints from any data source and hit the Import button on the Frontend.

1. Default Alarm and Trend templates are automatically assigned when using the *EPM_SetupWizard* that have a baseline of thresholds as a starting off point. If you would like to make any further adjustments to the thresholds or apply conditional rules, duplicate the default templates as they will be overwritten with any subsequent Availability package update.

1. Navigate through your Network using the EPM Topology app. Simply search and select an entry in the level it resides, and the dropdowns below will show all associated entities. Clicking on the right arrow will open the EPM card with a visual overview, data section, all associated entities in a table, and the topology diagram. At the top you are able to change the topology chain to see other levels.

![alt text](<Topology Naviagation.gif>)