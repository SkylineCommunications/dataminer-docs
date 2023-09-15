---
uid: Connector_help_Skyline_Media_Asset_Management
---

# Skyline Media Asset Management

This protocol can be used to manage media asset contents.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

After you set the **Content Information Element Name**, an element using this protocol can collect information about contents like episode titles, license expiration dates, and much more.

You will also be able to monitor how many files are required for a certain kind of content (video, metadata, audio and subtitles files)

## Notes

The DLL **ProcessAutomation.dll** must be available in the system.

In order to update the Assets table available in the system, the message used by this element needs to be like this:

namespace ContentInfo
{
public class Content
{
public string Id { get; set; }
public string Name { get; set; }
public string AssetId { get; set; }
public string Genre { get; set; }
public string Provider { get; set; }
public DateTime StartTime { get; set; }
public DateTime EndTime { get; set; }
public string Poster { get; set; }
}
}
