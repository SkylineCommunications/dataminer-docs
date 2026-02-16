---
uid: Performance_Analyzer_Getting_Started_Tutorial
---

# Getting started with the Performance Analyzer

In this tutorial, you will learn how to get started with the Performance Analyzer solution based on an example solution with a simulated performance issue.

Expected duration: 25 minutes.

> [!NOTE]
> The content and screenshots for this tutorial have been created using DataMiner version 10.5.4.

> [!TIP]
> See also: [Kata #62: Introduction to Performance Analyzer](https://community.dataminer.services/courses/kata-62/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)

## Prerequisites

For this tutorial, you will need a DataMiner System that meets the following requirements:

- DataMiner version 10.5.0 [CU1]/10.5.4 or higher.
- [Connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).
- The [GQI DxM](xref:GQI_DxM) is enabled.

> [!TIP]
> If you use a [DaaS system](xref:Creating_a_DMS_on_dataminer_services), these DataMiner-related prerequisites are automatically met.

In addition, the following prerequisites are optional but highly recommended:

- Visual Studio with DIS extension, connected to your DataMiner System (see [DIS installation and configuration](xref:Installing_and_configuring_the_software)).
- [Git](https://git-scm.com/) (this may be included with Visual Studio, depending on the version).

## Overview

- [Step 1: Set up the example solution](#step-1-set-up-the-example-solution)
- [Step 2: Create a low-code app](#step-2-create-a-low-code-app)
- [Step 3: Implement the Performance Analyzer in the solution](#step-3-implement-the-performance-analyzer-in-the-solution)
- [Step 4: Deploy the Performance Analyzer app](#step-4-deploy-the-performance-analyzer-app)
- [Step 5: Analyze the collected data](#step-5-analyze-the-collected-data)
- [Step 6: Improve the implementation of the Process method](#step-6-improve-the-implementation-of-the-process-method)
- [Step 7: Analyze the collected data again](#step-7-analyze-the-collected-data-again)
- [Step 8: Exercise for DevOps Points (optional)](#step-8-exercise-for-devops-points-optional)

## Step 1: Set up the example solution

To start this tutorial, you will need to follow the steps below to set up an example solution based on a GitHub repository that was specifically created for the tutorial.

> [!NOTE]
> If you do not have Visual Studio, you can skip the steps below and instead **deploy the example solution directly** from the Catalog, by deploying the following package to a DMA connected to dataminer.services: [Tutorial - Introduction to Performance Analyzer](https://catalog.dataminer.services/details/d59135c3-36de-43bb-af16-d649360b5126).

1. Clone the GitHub repository:

   1. Open a command prompt in the location where you want to clone the repository.

   1. Execute the command `git clone https://github.com/SkylineCommunications/SLC-GQIDS-Kata-PerformanceAnalyzerKataExercise.git`.

      ![Performance Analyzer getting started clone the repository](~/dataminer/images/performance_analyzer_getting_started_clone_the_repository.png)

1. Open the solution in Visual Studio:

   1. Open the *SLC-GQIDS-Kata-PerformanceAnalyzerKataExercise solution* folder.

   1. Open the solution *PerformanceAnalyzerKataExercise.sln*.

1. Publish the GQIDS:

   1. Open *PerformanceAnalyzerKataExercise.xml*.

      ![Performance Analyzer getting started open GQIDS XML](~/dataminer/images/performance_analyzer_getting_started_open_gqids_xml.png)

   1. Click *Publish*.

      ![Performance Analyzer getting started publish the GQIDS](~/dataminer/images/performance_analyzer_getting_started_publish_the_gqi.png)

## Step 2: Create a low-code app

In this step, you will create a low-code app to visualize the performance issue that can then be analyzed with the Performance Analyzer.

1. Go to the root page of your DataMiner System, for example by clicking the *Home* button for your DMS on the [dataminer.services page](https://dataminer.services/).

1. Create a [new low-code app](xref:Creating_custom_apps#creating-a-new-low-code-app).

1. Optionally, give the app a name of your choice, e.g., *Employee Overview*.

1. Create a query using the new GQIDS:

   1. In the *Data* pane on the right, go to *Queries* and click the "+" icon to create a query.

      ![+ icon to create query](~/dataminer/images/GQI_create_query.png)

   1. Optionally, specify a custom name for the query, e.g., *Employees Table*.

   1. Select *Get ad hoc data* and then *Employees Table*.

      ![Performance Analyzer getting started select a query](~/dataminer/images/performance_analyzer_getting_started_select_query.png)

1. Drag the new query to the page.

   ![Performance Analyzer getting started add a query to page](~/dataminer/images/performance_analyzer_getting_started_add_query_to_page.png)

1. [Select a table visualization](xref:Apply_Visualization) for the component.

   ![Performance Analyzer getting started visualize the query as table](~/dataminer/images/performance_analyzer_getting_started_visualize_query.png)

1. Optionally, drag the edges of the table component to adjust its size, until it looks like this:

   ![Performance Analyzer getting started final edit](~/dataminer/images/performance_analyzer_getting_started_final_lca_edit.png)

1. Publish the low-code app using the button in the top-right corner.

   ![Performance Analyzer getting started publish the LCA](~/dataminer/images/performance_analyzer_getting_started_publish_the_app.png)

At this point, you will be notice that the table takes a while to load, without any obvious reason. Trying to figure out the cause of this issue can be a daunting task, so this is where the Performance Analyzer will prove very helpful.

## Step 3: Implement the Performance Analyzer in the solution

> [!NOTE]
> If you do not have Visual Studio , you can skip the steps below and instead deploy the *exercise_1* branch of the example solution, where the Performance Analyzer has been implemented:
>
> 1. Go to [Tutorial - Introduction to Performance Analyzer](https://catalog.dataminer.services/details/d59135c3-36de-43bb-af16-d649360b5126).
> 1. Go to the *Versions* tab and click the *Deploy* button for the *1.0.1-exercise1* branch.

1. Open the solution in the same way as in [step 1](#step-1-set-up-the-example-solution).

1. Install the *Skyline.DataMiner.Utils.PerformanceAnalyzer* NuGet.

   > [!TIP]
   > For more details about the *Performance Analyzer* NuGet, see [Performance Analyzer library](xref:Performance_Analyzer_Library).

1. Implement the *Performance Analyzer* NuGet in the solution:

   1. Add a `collector` field of type `PerformanceCollector` and initialize it in the constructor of the `DatabaseController` class.

      ![Performance Analyzer getting started collector setup](~/dataminer/images/performance_analyzer_getting_started_collector_setup.png)

   1. Wrap the bodies of all methods with `using` statement with the `PerformanceTracker` instance, using the `collector` from the previous step.

      ![Performance Analyzer getting started collector setup](~/dataminer/images/performance_analyzer_getting_started_tracker_setup.png)

1. Publish the GQIDS in the same way as in [step 1](#step-1-set-up-the-example-solution).

## Step 4: Deploy the Performance Analyzer app

1. Go to the [Performance Analyzer](https://catalog.dataminer.services/details/414894ce-21ae-48e7-b2c3-0652fff08349) package in the Catalog.

1. [Deploy the Catalog item](xref:Deploying_a_catalog_item) to your DataMiner Agent by clicking the *Deploy* button.

> [!TIP]
> See also: [Performance Analyzer app](xref:Performance_Analyzer_LCA).

## Step 5: Analyze the collected data

As the Performance Analyzer has now been implemented in the solution, you will now be able to use the *Performance Analyzer* app to find out why loading your app takes so long.

1. Refresh the page in the low-code app from [step 2](#step-2-create-a-low-code-app).

1. From the root page of your DataMiner System, open the *Performance Analyzer* low-code app.

   ![Performance Analyzer getting started collector setup](~/dataminer/images/performance_analyzer_getting_started_open_lca.png)

1. Analyze the performance of your low-code app: By taking a look at the *Metrics* table, you can see that the biggest chunk of time is spent on the *DatabaseController.Process* method.

   ![Performance Analyzer getting started initial investigation](~/dataminer/images/performance_analyzer_getting_started_initial_investigation.png)

1. Double click the *DatabaseCollector.Process* row.

   You will see that the processing is happening sequentially. This means that the performance of your app could be improved by processing employees in parallel instead.

   ![Performance Analyzer getting started sequential processing](~/dataminer/images/performance_analyzer_getting_started_sequential_processing.png)

## Step 6: Improve the implementation of the Process method

> [!NOTE]
> If you do not have Visual Studio, you can skip the steps below and instead deploy the *exercise_2* branch of the example solution, where this improvement has been implemented:
>
> 1. Go to [Tutorial - Introduction to Performance Analyzer](https://catalog.dataminer.services/details/d59135c3-36de-43bb-af16-d649360b5126).
> 1. Go to the *Versions* tab and click the *Deploy* button for the *1.0.1-exercise2* branch.

1. Open the solution in the same way as in [step 1](#step-1-set-up-the-example-solution).

1. Update the `DatabaseController.Process` method:

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

1. Publish the GQIDS in the same way as in [step 1](#step-1-set-up-the-example-solution).

## Step 7: Analyze the collected data again

Follow the same steps as in [step 5](#step-5-analyze-the-collected-data) to analyze the collected data again.

You will notice that the table loads significantly faster now, and in the *Performance Analyzer* app you will see that the execution time of the *DatabaseController.Process* method has been reduced from ~9 s to ~500 ms.

Congratulations, you have successfully identified and resolved the issue with the performance of your low-code app!

## Step 8: Exercise for DevOps Points (optional)

In this step, you can do an optional exercise to earn DevOps Points.

1. Update the solution to the *exercise_3* branch:

   - If you have Visual Studio, pull branch *exercise_3*, and then publish the GQIDS like before.
   - Otherwise, deploy branch version *1.0.1-exercise3* of the [tutorial package](https://catalog.dataminer.services/details/d59135c3-36de-43bb-af16-d649360b5126).

1. Identify the user for which the processing causes performance issues.

1. Send a screenshot to [devops@skyline.be](mailto:devops@skyline.be) or upload it on the [Kata page on Dojo](https://community.dataminer.services/courses/kata-62/).

> [!NOTE]
> The *Performance Analyzer* NuGet is open source. If you want to contribute, you can do so by creating a pull request on the [Skyline.DataMiner.Utils.PerformanceAnalyzer repository](https://github.com/SkylineCommunications/Skyline.DataMiner.Utils.PerformanceAnalyzer).
