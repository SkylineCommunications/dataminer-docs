---
uid: HTTP_error_500
---

# HTTP error 500

## Symptom

When connecting to the DataMiner Dashboards legacy app, you get the following HTTP error:

```txt
HTTP Error 500.19 - Internal Server Error.  The requested page cannot be accessed because the related configuration data for the page is invalid.
```

In the *Detailed Error Information* section, you find the following *Config Error*:

```txt
The configuration section 'system.web.extensions' cannot be read because it is missing a section declaration.
```

## Cause

The problem can have two causes:

- The application pool that is being used for the application (e.g. DataMiner Dashboards) is not configured to use Microsoft .NET 4.0 yet, OR

- there is a problem with IIS where the configuration of .NET 2.0 is read even for application pools using .NET 4.0.

## Resolution

To resolve the problem, open IIS and check whether the DataMiner Dashboards application is running in an application pool that is configured to use Microsoft .NET 4.0. If not, proceed as follows to change the Application Pool (AppPool) settings of the DataMiner Dashboards application:

1. In the tree structure on the left, select the application directory.

1. In the *Actions* section, click *Basic Settings...* The application pool will probably be set to “DefaultAppPool”.

1. Click *Select...* and change *Application pool* to “ASP.NET v4.0” (or another .NET 4.0 application pool).

1. Click *OK*.

1. Reconnect to DataMiner Dashboards.
