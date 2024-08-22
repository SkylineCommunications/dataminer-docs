---
uid: Skyline_Health_Check_Installer
---

# Skyline Health Check Documentation

## Overview
The Skyline Health Check package provides essential tools for monitoring the health and performance of Dataminer System (DMS) clusters. It integrates automation scripts and protocols into the Dataminer system, enabling users to configure and manage tests that ensure the continuous and optimal functioning of their infrastructure. The package also includes features for setting up email notifications, allowing users to stay informed about the system's status through scheduled alerts.

## System Requirements
To install the Skyline Health Check package, ensure that your Dataminer system is running version **10.2.0.0** or higher. This is the minimum required version for the package to function correctly.

## Installation Process
To install the Skyline Health Check package, download it from the Dataminer Catalog and execute the installation on any server within your DMS cluster. Upon completion, the necessary automation scripts and protocols will be integrated and accessible through the Dataminer User Interface (UI).

Following the installation, users should utilize the Health Check protocol to create an element. This element acts as the central point for configuring system tests and managing overall health monitoring.

## Initial Setup and Configuration
Once the Health Check element is created, users can proceed to the **Test Configuration** page. This page provides options to add tests or subscriptions, each serving different monitoring purposes:

- **Tests**: These evaluate specific parameters or KPIs against defined thresholds, helping to monitor critical system metrics.
- **Subscriptions**: These assess thresholds across entire protocols, offering a comprehensive overview of system health.

Upon selecting "Add Test" or "Add Subscription," a configuration popup is displayed, where users can specify the parameters, thresholds, and other settings necessary for the test or subscription.

## Email Notifications
Email notifications can be configured to keep users informed about the system’s health. This configuration is done on the **Configurations** page within the Dataminer UI. Users can enter their email addresses in the designated field and set the recurrence for receiving notifications, which defaults to daily but can be adjusted as needed.

## Maintenance and Updates
Maintaining the Skyline Health Check package involves periodically checking for updates in the Dataminer Catalog. Applying updates follows the same installation process and ensures that the latest features and fixes are incorporated. It is also recommended to regularly review and adjust test configurations to reflect current system performance and requirements.

## Troubleshooting
For troubleshooting, the Dataminer UI provides access to logs and error reports that can assist in diagnosing and resolving issues related to the Skyline Health Check package. Common problems might include configuration errors, discrepancies in test results, issues with email notifications, or outdated dlls.

## Customization and Advanced Configuration
Users have the flexibility to customize the tests beyond the standard threshold settings, including altering scripts or adding new test scripts where necessary. Advanced configuration options may also be available, depending on the specific requirements and complexity of the system being monitored.
