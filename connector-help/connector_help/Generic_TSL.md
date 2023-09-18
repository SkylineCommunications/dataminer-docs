---
uid: Connector_help_Generic_TSL
---

# Generic TSL

This is a generic connector for under monitor display devices using the TSL protocol.

## About

This is a **serial** connector using the TSL protocol. Only commands can be sent to the device, as there is no response. In the 3.0.0.x range, where version 5.0 of the TSL is used, it is possible to use Unicode characters in the text field.

The minimum framework required is .NET 4.0, so that System.Web.Extensions.dll is available.

### Version Info

| **Range** | **Description**                            | **DCF Integration** | **Cassandra Compliant** |
|------------------|--------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                            | No                  | Yes                     |
| 2.0.0.x          | Redundant interfaces                       | No                  | Yes                     |
| 3.0.0.x          | TSL v5.0 implementation                    | No                  | Yes                     |
| 3.0.1.x          | Smart-serial (no disconnect after command) | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          |                             |
| 2.0.0.x          |                             |
| 3.0.0.x          | TSL v5.0                    |
| 3.0.1.x          | TSL v5.0                    |

## Installation and configuration

### Creation: Range 3.0.x.x

#### (Smart-)Serial Main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **Type of port**: Both *UDP/IP* and *TCP/IP* are supported. The type is also discovered in the element to adjust the message format.
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device. Default is *2050*.

## Usage Range 3.0.0.x

### General

To adjust the behavior of the element:

- **Periodic Update**: When this is enabled, all UMDs with **Admin State** *Up* are sent to the device every minute.
- **Exclusive Update**: A bulk set will set the **Admin State** of all other UMDs to *Down*.
- **Default** values are used to fill in missing values for new UMD objects in a bulk set. They are also used to initialize the UMD values on the Create UMDs page.
- **Active Interface** is a reflection of the chosen communication type in the element setup and alters the message format. When the value is *Unavailable*, something went wrong during initialization. In that case, the best solution is to restart the element.

### UMDs

The **UMDs** table is a collection of all the UMDs added through single adds and bulk updates on the **Create UMDs** page. With the *Send* button in the **Send Row** column, individual UMDs can be sent to the device.

To edit UMDs, you can either set individual cells, or edit the entire row on the **Update UMD Row** subpage.

- After you click **load** in the table row, its values will be loaded in the parameters on the **Update UMD Row** page, which is accessed via the page button **Update Row** below the **UMDs** table. Edit the desired values and click **Send Row CMD**.
- Use the **UMD Row Identifier** to load a specific row, instead of using the **Edit Row** column. There is a drop-down list, but typing is also possible to speed up access. Setting an incorrect identifier will not result in any change of parameters.

To delete UMDs, use the context menu (by right-clicking in the table).

- **Delete UMDs older than ...** will ask for the maximum age, which is the amount of time measured from the moment **OK** is clicked. All UMDs (even those with **Admin State** equal to *Up*) of which the **Last Update** value is before this maximum age are deleted.
  Example values: *10 seconds*, *10 minutes*, *10 hours*, *10 days*, *10 weeks* (these are suggested by DataMiner while you type).
  If only a number is entered, this is interpreted as a number of hours.
- **Delete UMDs in Admin Down state** will delete all UMDs of which the **Admin State** is *Down*.
- **Delete Selected UMDs** will delete all selected rows. Select multiple rows using the Shift or Ctrl key as usual in Windows.

### Create UMDs

This is a subpage of the UMDs page. Set the **UMD** parameters to the desired values and click **Add Command** to create a UMD in the **UMDs** table. If the key *({screen}.{index})* already exists, it will be overwritten.

**Bulk UMD Update JSON** allows you to do a bulk update. Not only will the values be added or updated in the **UMDs** table, they will also immediately be sent to the device. Missing properties will be filled in with the default values if the UMD does not exist yet. If **Exclusive Update** is *Enabled*, all UMD IDs that are not in this bulk message will have their **Admin State** set to *Down*.

The format is JSON and can be a single object or an array of objects containing the fields described below. Only Index is mandatory. Objects are enclosed in curly braces (e.g. *{ Object }* ), while an array of objects is surrounded by square brackets (e.g. *\[ {object1}, {object2} \]* ). For more information on the format, please refer to <http://www.json.org/>.

- **"Text"**: string, Empty or current if null

- **"Index"**: ushort, Mandatory!

- **"Screen"**: ushort, Default or current if null

- **"AdminUp"**: bool, Default or current if null

- **"Control"**: controlObject (dictionary), Default or current if null
  controlObject contains:

- **"RHT"**: Byte (Range \[0-3\]), the right-hand tally
  - **"LHT"**: Byte (Range \[0-3\]), the left-hand tally
  - **"TXT"**: Byte (Range \[0-3\]), the text tally
  - **"BRI"**: Byte (Range \[0-3\]), the brightness

> Where the tally byte is one of these four values:
>
> - *0*: Off
> - *1*: Red
> - *2*: Green
> - *3*: Amber

Here are some examples of possible messages:

- *{"Text":"testText","Control":{"RHT":3,"LHT":2,"TXT":1,"BRI":1},"Index":5,"Screen":2,"AdminUp":true} -* All values are defined in this single-object update.
- *\[{"Text":"@text","Control":{"RHT":3,"LHT":2,"TXT":1,"BRI":1},"Index":1,"Screen":2},{"Index":2,"Screen":2,"Text":"?","AdminUp":false}\]* - The values not defined in these objects will behave as described above.

### Update UMD Row

This is a subpage of the UMDs page. The parameters are filled in with the default values when no row has been selected. Refer to the section above ("To edit UMDs ...") in this connector help for more information about the usage of this page.

### UMD Automation

The **Scheduled Time Table** receives its data from the **Sky UK VICC** elements and has columns for the **Channel**, **Start Date Time Next Schedule Item** and **Row** **Status**.

The **UMD Automation** **Table** has the same UMD rows as the UMDs Table. The **Connected Services**, **Service Name** and **Service Alarm State** are filled in by an Automation script. The Start Date Time is retrieved from the Scheduled Time Table. The values from the **Count Down** are calculated from the Start Date Time and the current time.

### Destinations

Via the destinations table, multiple destinations can be added to which every command will be sent. The destination with the key *Element* is always overwritten with the element's configuration at startup and cannot be removed. Remove unwanted entries by selecting them and using the right-click menu option *Delete Selected Destinations*.
