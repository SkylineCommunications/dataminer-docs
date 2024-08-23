---
uid: Skyline_Health_Check
---

# Skyline Health Check

The *Skyline Health Check* package provides essential tools for monitoring the health and performance of a Dataminer System. It integrates Automation scripts and connector into the Dataminer System, enabling users to configure and manage tests that ensure the continuous and optimal functioning of their infrastructure. The package also includes features for setting up email notifications, allowing users to stay informed about the system's status through scheduled alerts.

## System requirements

Before you install the *Skyline Health Check* package, make sure your Dataminer System is running version **10.2.0.0** or higher. This is the minimum required version for the package to function correctly.

## Installation

To install the *Skyline Health Check* package, do the following:

1. Download the package from the [Dataminer Catalog](https://catalog.dataminer.services/details/56b1b9e0-ffe1-4bd2-b5d2-06c17d97c6b1).

1. Install the package on a random DataMiner Agent within your DataMiner System.

1. Create an element that uses the *Skyline Health Check Manager* connector. This element will allow you to configure system tests and monitor overall health.

## Initial setup and configuration

Once the Health Check element is created, users can proceed to the **Test Configuration** page. This page provides options to add tests or subscriptions, each serving different monitoring purposes:

- **Tests**: These evaluate specific parameters or KPIs against defined thresholds, helping to monitor critical system metrics.
- **Subscriptions**: These assess thresholds across entire protocols, offering a comprehensive overview of system health.

Upon selecting "Add Test" or "Add Subscription," a configuration popup is displayed, where users can specify the parameters, thresholds, and other settings necessary for the test or subscription.

## Email notifications

Email notifications can be configured to keep users informed about the system’s health. This configuration is done on the **Configurations** page within the Dataminer UI. Users can enter their email addresses in the designated field and set the recurrence for receiving notifications, which defaults to daily but can be adjusted as needed.

## Maintenance and updates

Maintaining the *Skyline Health Check* package involves periodically checking for updates in the Dataminer Catalog. Applying updates follows the same installation process and ensures that the latest features and fixes are incorporated. It is also recommended to regularly review and adjust test configurations to reflect current system performance and requirements.

## Troubleshooting

For troubleshooting, the Dataminer UI provides access to logs and error reports that can assist in diagnosing and resolving issues related to the *Skyline Health Check* package. Common problems might include configuration errors, discrepancies in test results, issues with email notifications, or outdated dlls.

## Customization and advanced configuration

Users have the flexibility to customize the tests beyond the standard threshold settings, including altering scripts or adding new test scripts where necessary. Advanced configuration options may also be available, depending on the specific requirements and complexity of the system being monitored.
