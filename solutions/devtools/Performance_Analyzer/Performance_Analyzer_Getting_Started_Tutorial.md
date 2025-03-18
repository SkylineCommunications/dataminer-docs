---
uid: Performance_Analyzer_Getting_Started_Tutorial
---

# Getting started with the Performance Analyzer

In this tutorial, you will learn how to get started with the Performance Analyzer solution, how and why you should consider using it in your projects, and what value you can expect to gain from it.

Expected duration: 25 minutes.
<!-- Sections in comment below will need to be uncommented when the Kata becomes available on Dojo -->
<!-- 
> [!TIP]
> See also: [Kata #62: Introduction to Performance Analyzer](https://community.dataminer.services/courses/kata-62/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)
 -->
## Prerequisites

- DataMiner version 10.5.0/10.5.2 or higher.
- DataMiner System that is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).
- DataMiner System using GQI DxM.

> [!NOTE]
> If the GQI DxM is not enabled on your system, refer to [GQI DxM](xref:GQI_DxM).

> ![!TIP]
> It is possible to follow the exercise using DataMiner version as low as 10.4.0 [CU10]/10.5.1, however, in that case you have to manually add *Skyline.DataMiner.Utils.PerformanceAnalyzer.dll* to *C:\Skyline DataMiner\Files* folder. After building the solution you can find the required DLL in *C:\Projects\Visual Studio\SLC-GQIDS-Kata-PerformanceAnalyzerKataExercise\PerformanceAnalyzerKataExercise\bin\Debug\net48* folder.

The following are not required but strongly suggested requirements:

- Visual Studio with DIS extension. DIS extension can be download from [DataMiner Dojo](https://community.dataminer.services/dataminer-integration-studio-other-downloads/).
- DIS extension connected to your DataMiner system.
- Ability to clone [SLC-GQIDS-Kata-PerformanceAnalyzerKataExercise](https://github.com/SkylineCommunications/SLC-GQIDS-Kata-PerformanceAnalyzerKataExercise) repository.

> [!TIP]
> If you use a [DaaS system](xref:Creating_a_DMS_on_dataminer_services), DataMiner related prerequisites are automatically met.

> [!NOTE]
> If your DIS extension is not connected to DataMiner system you can read on how to do it at [Installing and configuring DataMiner Integration Studio](xref:Installing_and_configuring_DataMiner_Integration_Studio).

## Overview

- [Step 1: Clone the Repository](#step-1-clone-the-repository)
- [Step 2: Open the Solution](#step-2-open-the-solution)
- [Step 3: Publish the GQIDS](#step-3-publish-the-gqids)
- [Step 4: Create a low-code app](#step-4-create-a-low-code-app)
- [Step 5: Implement the Performance Analyzer](#step-5-implement-the-performance-analyzer)
- [Step 6: Analyze the Collected Data](#step-6-analyze-the-collected-data)
- [Step 7: Improve the implementation of the Process method](#step-7-improve-the-implementation-of-the-process-method)
- [Step 8: Repeat step #7](#step-8-repeat-step-7)

## Step 1: Clone the repository

1. *Open Command Prompt* where you want to clone the repository to.

1. Execute the command `git clone https://github.com/SkylineCommunications/SLC-GQIDS-Kata-PerformanceAnalyzerKataExercise.git`.

![Performance Analyzer getting started clone the repository](~/user-guide/images/performance_analyzer_getting_started_clone_the_repository.png)

## Step 2: Open the solution

1. Open the *SLC-GQIDS-Kata-PerformanceAnalyzerKataExercise solution* folder.

1. Open the *PerformanceAnalyzerKataExercise.sln*.

## Step 3: Publish the GQIDS

1. Open *PerformanceAnalyzerKataExercise.xml*.

   ![Performance Analyzer getting started open GQIDS XML](~/user-guide/images/performance_analyzer_getting_started_open_gqids_xml.png)

1. Click *Publish*.

   ![Performance Analyzer getting started publish the GQIDS](~/user-guide/images/performance_analyzer_getting_started_publish_the_gqi.png)

>[!NOTE]
> You can follow this step by deploying the GQIDS directly from the [Catalog](https://catalog.dataminer.services/details/d59135c3-36de-43bb-af16-d649360b5126).

## Step 4: Create a low-code app

1. Open the *DataMiner Web App*.

1. Click on *Create a new app*.

   ![Performance Analyzer getting started create a LCA](~/user-guide/images/performance_analyzer_getting_started_create_a_lca.png)

1. Create a query using the new GQIDS

   1. Click to add query.

      ![Performance Analyzer getting started add a query](~/user-guide/images/performance_analyzer_getting_started_add_query.png)

   1. Select *Get ad hoc data* and then *Employees Table*.

      ![Performance Analyzer getting started select a query](~/user-guide/images/performance_analyzer_getting_started_select_query.png)

   1. Drag and drop the new query on to the page.

      ![Performance Analyzer getting started add a query to page](~/user-guide/images/performance_analyzer_getting_started_add_query_to_page.png)

   1. Visualize the query as table.

      ![Performance Analyzer getting started visualize the query as table](~/user-guide/images/performance_analyzer_getting_started_visualize_query.png)

   > [!NOTE]
   > Optionally, you can name the low-code app and query, and adjust the table size.

   You will end up with something like this:

   ![Performance Analyzer getting started final edit](~/user-guide/images/performance_analyzer_getting_started_final_lca_edit.png)

1. Publish the low-code app.

   ![Performance Analyzer getting started publish the LCA](~/user-guide/images/performance_analyzer_getting_started_publish_the_app.png)

At this point you will be able to notice that the table takes a while to load without an obvious reason. Trying to figure out the cause of this issue can be a daunting task, but luckily the Performance Analyzer will help you identify the issue with ease.

> [!NOTE]
> In this exercise, the low-code app is used only to visualize to performance issues and you will only need to focus on the `DatabaseController` class.

## Step 5: Implement the Performance Analyzer

1. [Open the solution](#step-2-open-the-solution).

1. Install the *Skyline.DataMiner.Utils.PerformanceAnalyzer* NuGet.

1. Implement the *Performance Analyzer* NuGet in the solution.

   1. Add a `collector` field of type `PerformanceCollector` and initialize it in the constructor of the `DatabaseController` class.

      ![Performance Analyzer getting started collector setup](~/user-guide/images/performance_analyzer_getting_started_collector_setup.png)

   1. Wrap the bodies of all methods with `using` statement with the `PerformanceTracker` instance, using the `collector` from previous step.

      ![Performance Analyzer getting started collector setup](~/user-guide/images/performance_analyzer_getting_started_tracker_setup.png)

   1. [Publish the GQIDS](#step-3-publish-the-gqids).

   > [!NOTE]
   >
   > - You can follow this step by deploying the GQIDS, version 1.0.1-exercise1, directly from the [Catalog](https://catalog.dataminer.services/details/d59135c3-36de-43bb-af16-d649360b5126).
   > - For more details about the *Performance Analyzer* NuGet, see [Performance Analyzer library](xref:Performance_Analyzer_Library).

   > [!TIP]
   > The implementation of this step can be found on *exercise_1* branch.

1. Deploy the *Performance Analyzer LCA* package from the Catalog.

   1. Go to the [Performance Analyzer](https://catalog.dataminer.services/details/414894ce-21ae-48e7-b2c3-0652fff08349) package in the DataMiner Catalog.

   1. [Deploy the Catalog item](xref:Deploying_a_catalog_item) to your DataMiner Agent by clicking the *Deploy* button.

   > [!TIP]
   > See also: [Performance Analyzer app](xref:Performance_Analyzer_LCA).

## Step 6: Analyze the collected data

1. Refresh the page in the low-code app.

1. Open *DataMiner Web App*.

1. Open the *Performance Analyzer* low-code app.

   ![Performance Analyzer getting started collector setup](~/user-guide/images/performance_analyzer_getting_started_open_lca.png)

   You can now analyze the performance of your low-code app. By taking a look at *Metrics* table, you can see that biggest chunk of the time is spent on `DatabaseController.Process` method.

   ![Performance Analyzer getting started initial investigation](~/user-guide/images/performance_analyzer_getting_started_initial_investigation.png)

1. Double click the *DatabaseCollector.Process* row.

![Performance Analyzer getting started sequential processing](~/user-guide/images/performance_analyzer_getting_started_sequential_processing.png)

You will notice that processing is happening sequentially. It is possible to improve the performance by processing employees in parallel instead.

## Step 7: Improve the implementation of the Process method

1. [Open the solution](#step-2-open-the-solution).

1. Update the `DatabaseController.Process` method

   ```c#
   private List<Employee> Process(List<Employee> employees)
   {
      using (var tracker = new PerformanceTracker(collector))
      {
         var processedEmployees = new ConcurrentBag<Employee>();

         Parallel.ForEach(employees, employee =>
         {
            using (var threadTracker = new PerformanceTracker(tracker, nameof(MockExecution), nameof(MockExecution.Process)))
            {
               threadTracker
                  .AddMetadata("Thread Id", Convert.ToString(Thread.CurrentThread.ManagedThreadId))
                  .AddMetadata("Employee Id", employee.Id)
                  .AddMetadata("Employee Name", employee.Name);

               var processedEmployee = MockExecution.Process(employee);

               processedEmployees.Add(processedEmployee);
            }
         });

         return processedEmployees.ToList();
      }
   }
   ```

   > [!TIP]
   > Implementation of this step can be found on *exercise_2* branch.

1. [Publish the GQIDS](#step-3-publish-the-gqids)

>[!NOTE]
> You can follow this step by deploying the GQIDS, version 1.0.1-exercise2, directly from the [Catalog](https://catalog.dataminer.services/details/d59135c3-36de-43bb-af16-d649360b5126).

## Step 8: [Repeat step #7](#step-6-analyze-the-collected-data)

You will now notice that the table loads significantly faster and, in the *Performance Analyzer* app, you can see that execution time of `DatabaseController.Process` method has been reduced from ~9s to ~500ms.

Congratulations, you have successfully identified and resolved the issue with performance of your low-code app.

<!-- ## Exercise for DevOps Points

1. Pull branch *exercise_3*.

1. [Publish the GQIDS](#step-3-publish-the-gqids)

   >[!NOTE]
   > You can follow this step by deploying the GQIDS, version 1.0.1-exercise3, directly from the [Catalog](https://catalog.dataminer.services/details/d59135c3-36de-43bb-af16-d649360b5126).

1. Identify the user whose processing causes performance issues.

1. Send a screenshot to [devops@skyline.be](mailto:devops@skyline.be) or upload it on the [Kata page on Dojo](https://community.dataminer.services/courses/kata-62/).

> [!NOTE]
> The *Performance Analyzer* NuGet is open source. If you want to contribute, you can do so by create a pull request on the [Skyline.DataMiner.Utils.PerformanceAnalyzer repository](https://github.com/SkylineCommunications/Skyline.DataMiner.Utils.PerformanceAnalyzer). -->
