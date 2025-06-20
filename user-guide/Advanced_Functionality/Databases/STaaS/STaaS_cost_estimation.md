---
uid: STaaS_cost_estimation
description: To view a cost estimation for STaaS, deploy the STaaS Migration Script package, and run the CloudStorageMigration script.
---

# Requesting a cost estimation for STaaS

To request a cost estimation, follow the procedure below:

1. Follow the [STaaS setup procedure](xref:Setting_up_StaaS), but only up to the point where your system is registered to use STaaS.

1. Deploy the [STaaS Migration Script package](https://catalog.dataminer.services/details/46046c45-e44c-4bff-ba6e-3d0441a96f02) from the Catalog.

1. In the Automation module in DataMiner Cube, locate the *CloudStorageMigration* script and [execute the script](xref:Manually_executing_a_script).

   > [!NOTE]
   >
   > - When you run the Automation script and there are Failover pairs in the cluster, make sure the **main Failover Agents** (i.e. the first Agent in the Failover configuration) are the **active** ones. Otherwise, the Automation script will not function correctly.
   > - To do the cost estimation for a **cluster**, you only need to execute the script on **one Agent**.

1. Initialize the replication:

   1. Optionally, configure a proxy for the replication if necessary. This is supported from DataMiner 10.4.6 onwards.

   1. Click *Start Replication* to initialize the replication.

1. Let the script run for 24 hours without restarting the DataMiner System (DMS).

1. After the 24-hour period, stop the estimation process:

   1. Locate the *CloudStorageMigration* script and [execute the script](xref:Manually_executing_a_script).
      
   1. Click *Stop Migration/Replication* to stop the replication.
      
      1. Optionally, you can also restart your DMS to stop the replication.

   > [!NOTE]
   >
   > - This 24-hour period is not mandatory, but we recommend this to be able to extrapolate the data from a daily consumption to a monthly consumption.

1. After this, at approximately 2 AM UTC, you will be able to view your cost estimation in the [Admin app](https://admin.dataminer.services), under *Overview* > *Usage* for the relevant organization.

   > [!NOTE]
   > You will only be able to see the *Usage* module if you are an Owner or Admin of the organization.

If you have any questions regarding this cost estimation, please contact <support@dataminer.services>.

> [!IMPORTANT]
> Cost estimations can currently only be performed for the West Europe, UK South, Southeast Asia, and Central US regions.

> [!TIP]
> To optimize the cost efficiency of a STaaS solution, adhere to the best practices to prevent storing unnecessary data [with Automation scripts](xref:Automation_best_practices_information_events) or [with connectors](xref:Saving_parameters).
