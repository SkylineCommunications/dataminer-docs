---
uid: QAOps
---

# QAOps

> [!IMPORTANT]
> This section contains information intended only for Skyline employees.

## What is QAOps

QAOps (Quality Assurance and Operations) is a regression test orchestration platform built on DataMiner. It enables you and your automation pipelines to run DataMiner test packages on DaaS setups, visualize results, and store them for future reference.

You can use these results to create quality gates, automatically blocking releases within automation pipelines if issues are detected.

The main goal of QAOps is to automatically deliver a more robust product within a DataMiner environment and to improve interoperability between different modules and solutions. This is achieved by sharing and combining test packages for various solutions and DataMiner features.

## Why use QAOps

With the increasing prevalence of collaborative development and community-driven pull requests, often assisted by large language models, automated quality assurance is becoming a critical part of any ecosystem.

QAOps allows you to create your own test packages and, if needed, request that new DataMiner releases are blocked if your test package detects a breaking change. More commonly, you can test changes made to your solution in a repeatable, automated, and consistent way using the QAOps platform.

QAOps also provisions clean DataMiner (DaaS) servers, ensuring your tests always start from a fresh setup.

## How to use QAOps

For Skyline Communications, you can access the QAOps system at:

- [QAOps production](https://qaops-skyline.on.dataminer.services/root/)

- [QAOps staging](https://qaopsstaging-skyline.on.dataminer.services/root/)

You can interact with QAOps in the following ways:

- [Several low-code apps](xref:QAOps_Main_UI) handle most access.

- The [QAOps .NET tool](xref:QAOps_Tool) is intended for command-line access.

- You can create [test packages](xref:QAOps_Test_Package), intended to run on the QAOps system, using Visual Studio projects.

## QAOps system components

The QAOps system consists of the following components:

- [QAOps configurations](xref:QAOps_Configuration), which define what kind of DataMiner Agents to run, how many servers to use, and for which project. Each configuration includes one or more test suites.

- [QAOps test suites](xref:QAOps_Test_Suite), which specify the type of testing to execute. Each test suite includes one or more test packages.

- [QAOps test packages](xref:QAOps_Test_Package), which contain collections of tests. Each test can send one or more test results.

<!-- ![QAOps overview](QAOpsUserOverview.drawio.png) -->

## Starting a test

To start a test, select the test suite from the specific configuration you want to execute.

QAOps receives the test run and waits for an available server for the selected configuration. Once a server is available, it begins running all test packages of the test suite on that server. Results will appear in the user low-code ap of the QAOps setup.
