---
uid: ConnectorBestPracticesDVEs
---

# Dynamic Virtual Elements (DVEs)

## DVE names

The name of a DVE protocol should be constructed as follows: Mother Protocol Name - Product Name.

## DVE export rules

Verify that an export rule removes the table name suffixes when parameters are exported as standalone parameters in a DVE element. For example, when the main DVE element has a column named "Admin Status (Interfaces)", the description in the DVE child element should be "Admin Status".

## DVE child element deletion

- DVE protocols must not delete DVE child elements automatically by default. (See [Data handling](xref:Data_handling).)
