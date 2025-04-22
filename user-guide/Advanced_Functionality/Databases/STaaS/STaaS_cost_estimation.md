---
uid: STaaS_cost_estimation
---

# Requesting a cost estimation for STaaS

To request a cost estimation, follow the procedure below:

1. Follow the [STaaS setup procedure](xref:Setting_up_StaaS), but only up to the point where your system is registered to use STaaS.

1. Deploy the [STaaS Migration Script package](https://catalog.dataminer.services/details/46046c45-e44c-4bff-ba6e-3d0441a96f02) from the Catalog.

1. In the Automation module in DataMiner Cube, locate the *CloudStorageMigration* script and [execute the script](xref:Manually_executing_a_script).

   > [!NOTE]
   > When you run the Automation script on a Failover pair, make sure the currently active Agent is the main Failover Agent (i.e. the first Agent in the Failover configuration). Otherwise, the Automation script will not function correctly.

1. Initialize the migration:

   1. Optionally, configure a proxy for the migration if necessary. This is supported from DataMiner 10.4.6 onwards.

   1. Click *Init migration* to initialize the migration.

1. Start the migration:

   1. Make sure *Replication only* is selected.

   1. Select **all** data types.

      This way you will have the most accurate estimation of your system when running the script.

   1. Click *Start migration*.

1. Let the script run for 24 hours without restarting the DataMiner System (DMS).

1. After the 24-hour period, restart the DMS to stop the estimation process.

1. After this, at approximately 2 AM UTC, you will be able to view your cost estimation in the [Admin app](https://admin.dataminer.services), under *Overview* > *Usage* for the relevant organization.

   > [!NOTE]
   > You will only be able to see the *Usage* module if you are an Owner or Admin of the organization.

If you have any questions regarding this cost estimation, please contact <staas@dataminer.services>.

> [!IMPORTANT]
> Cost estimations can currently only be performed for the West Europe, UK South, and Southeast Asia regions.

> [!TIP]
> To optimize the cost efficiency of a STaaS solution, adhere to the best practices to prevent storing unnecessary data [with Automation scripts](xref:Automation_best_practices_information_events) or [with connectors](xref:Saving_parameters).
