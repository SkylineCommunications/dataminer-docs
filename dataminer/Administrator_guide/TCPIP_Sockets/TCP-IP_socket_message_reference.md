---
uid: TCP-IP_socket_message_reference
---

# TCP-IP socket message reference

### Message format

Each command or response must have a fixed header character and a fixed trailer character.

- **Header character**: 0x09 (tab character \\t)

- **Trailer character**: 0x0D (carriage return character \\r)

### Commands and responses

#### Get_Alarm_Level (DMA)

- **Command**

  ```txt
  [Header]Get_Alarm_Level;[1][Trailer]
  ```

  \[1\]

  - id:\[DMA ID\]

  - ip:\[Primary IP address of the DMA\]

- **Response**

  ```txt
  [Header][1];[2][Trailer]
   ```

  \[1\] DMA ID

  \[2\] Current alarm severity level of the DMA (see [Alarm states](#alarm-states))

- **Example**

  When a DMA receives:

  ```txt
  \tGet_Alarm_Level;id:102\r
  ```

  It will return:

  ```txt
  \t102;3\r
  ```

#### Get_Alarm_Level (Element)

- **Command**

  ```txt
  [Header]Get_Alarm_Level;[1][Trailer]
  ```

  \[1\]

  - name:\[ElementName\]

  - *id:\[DataMinerID/ElementID\]* (e.g. 102/524)

  - ip:\[virtual IP address\]

- **Response**

  ```txt
  [Header][1];[2][Trailer]
  ```

  \[1\] Element ID

  \[2\] Current alarm severity level of the element (see [Alarm states](#alarm-states))

- **Example**

  When a DMA receives:

  ```txt
  \tGet_Alarm_Level;name:Paradise SSPA CO\r
  ```

  It will return:

  ```txt
  \t526;5\r
  ```

#### Get_Element_List (DMA)

- **Command**

  ```txt
  [Header]Get_Element_List;[1][Trailer]
  ```

  \[1\] *id:\[DMA ID\]*

- **Response**

  A colon-separated list of elements:

  ```txt
  [Header][1]│[2]│[3]│[4]:...:[1]│[2]│[3]│[4][Trailer]
  ```

  \[1\] Element ID

  \[2\] DMA ID of the DMA where the element was originally created

  \[3\] Element name

  \[4\] Virtual IP address of the element

- **Example**

  When a DMA receives:

  ```txt
  \tGet_Element_List;id:102\r
  ```

  It will return:

  ```txt
  \t261│102│Adam 6015:189│102│Cableworld CW-3823:175│102│Comstream ABR202\r
  ```

#### Get_Element_List (DMS)

- **Command**

  ```txt
  [Header]Get_Element_List[Trailer]
  ```

- **Response**

  A colon-separated list of elements:

  ```txt
  [Header][1]│[2]│[3]│[4]:...:[1]│[2]│[3]│[4][Trailer]
  ```

  \[1\] Element ID

  \[2\] DMA ID of the DMA where the element was originally created

  \[3\] Element name

  \[4\] Virtual IP address of the element

- **Example**

  When a DMA receives:

  ```txt
  \tGet_Element_List\r
  ```

  It will return:

  ```txt
  \t261│101│Adam 6015:504│102│Newtec 2085:175│103│Comstream ABR202\r
  ```

#### Get_Parameter

- **Command to retrieve a normal parameter**

  ```txt
  [Header]Get_Parameter;[1];[2][Trailer]
  ```

  \[1\]

  - name:\[ElementName\]

  - *id:\[DataMinerID/ElementID\]* (e.g. 102/524)

  \[2\]

  - name:\[ParameterName\]

  - id:\[ParameterID\]

  - tag:\[ParameterAlias\]

- **Command to retrieve a row from a table parameter**

  ```txt
  [Header]Get_Parameter;[1];[2];[3][Trailer]
  ```

  \[1\]

  - name:\[ElementName\]

  - *id:\[DataMinerID/ElementID\]* (e.g. 102/524)

  \[2\]

  - id:\[ParameterID\]

  \[3\]

  - *key:\[RowIndex\]* (Display key)

  > [!NOTE]
  > If you specify a table row key, then the parameter must be referred to by its ID. You cannot refer to it by its name or its alias.

- **Command to retrieve crosspoints from a matrix parameter**

  ```txt
  [Header]Get_Parameter;[1];[2];[3];[4][Trailer]
  ```

  \[1\]

  - name:\[ElementName\]

  - *id:\[DataMinerID/ElementID\]* (e.g. 102/524)

  \[2\]

  - name:\[ParameterName\]

  - id:\[ParameterID\]

  - tag:\[ParameterAlias\]

  \[3\]

  - *x:\[X-axis value of the crosspoint\]* (Use *x:-1* to retrieve an entire row)

  \[4\]

  - *y:\[Y-axis value of the crosspoint\]* (Use *y:-1* to retrieve an entire column)

- **Response**

  ```txt
  [Header]│[1]│[2]│[3]│[4]│[5]│[6]│[7]│[8][Trailer]
  ```

  \[1\] Parameter ID

  \[2\] Parameter name (as it is displayed on the screen)

  \[3\] Parameter alias (if one is specified in the Protocol)

  \[4\] Current value of the parameter

  \[5\] Units

  \[6\] Time at which the parameter value was first measured (format: YYYY-MM-DD HH:MM:SS)

  \[7\] Time at which the parameter value was last measured (format: YYYY-MM-DD HH:MM:SS)

  \[8\] Current alarm severity level of the parameter (see [Alarm states](#alarm-states))

  > [!NOTE]
  > If you requested crosspoint values from a matrix parameter, \[4\] will be a pair of x,y values for each connected crosspoint. Multiple pairs are separated by semicolons (”;”).

- **Example**

  When a DMA receives:

  ```txt
  \tGet_Parameter;id:102/526;name:Power Supply\r
  ```

  It will return:

  ```txt
  \t│526│Power Supply│C_PS1│11.2│V│2011-12-23 14:43:17│2011-12-23 15:03:17│1\r
  ```

#### Get_Redundancy_Info

- **Command**

  ```txt
  [Header]Get_Redundancy_Info;[1];[2][Trailer]
  ```

  \[1\] DMA ID

  \[2\] Redundancy group ID

- **Response**

  Name and ID of the redundancy group, followed by the colon-separated list of elements it contains.

  ```txt
  [Header][A]│[B]│[C]│[1]│[2]│[3]│[4]:...:[1]│[2]│[3]│[4][Trailer]
  ```

  \[A\] ID of the redundancy group

  \[B\] DMA ID of the DMA where the redundancy group was originally created

  \[C\] Name of the redundancy group

  \[1\] Element ID

  \[2\] DMA ID (as stored in the element)

  \[3\] Type of redundancy group element (PRIMARY, BACKUP or STATE)

  \[4\] ID of the virtual element. Only filled in if Type is PRIMARY

- **Example**

  When a DMA receives:

  ```txt
  \tGet_Redundancy_Info;5;10047\r
  ```

  It will return:

  ```txt
  \t10047│5│WMI Timeout group│
  10046│5│primary│10048:
  10039│5│primary│10049:
  9585│5│backup│:
  9633│5│state│\r
  ```

#### Get_Redundancy_List (DMA)

- **Command**

  ```txt
  [Header]Get_Redundancy_List;[1][Trailer]
  ```

  \[1\] DMA ID

- **Response**

  A colon-separated list of redundancy groups:

  ```txt
  [Header][1]│[2]│[3]:...:[1]│[2]│[3][Trailer]
  ```

  \[1\] ID of the redundancy group

  \[2\] DMA ID of the DMA where the redundancy group was originally created

  \[3\] Name of the redundancy group

- **Example**

  When a DMA receives:

  ```txt
  \tGet_Redundancy_List;5\r
  ```

  It will return:

  ```txt
  \t10047│5│WMI Timeout group:10017│5│RG_Some Channel\r
  ```

#### Get_Redundancy_List (DMS)

- **Command**

  ```txt
  [Header]Get_Redundancy_List[Trailer]
  ```

- **Response**

  A colon-separated list of redundancy groups:

  ```txt
  [Header][1]│[2]│[3]:...:[1]│[2]│[3][Trailer]
  ```

  \[1\] ID of the redundancy group

  \[2\] DMA ID of the DMA where the redundancy group was originally created

  \[3\] Name of the redundancy group

- **Example**

  When a DMA receives:

  ```txt
  \tGet_Redundancy_List\r
  ```

  It will return:

  ```txt
  \t10047│5│WMI Timeout group:10017│5│RG_Some Channel: 960│102│RG_RMS_2_ChannelY\r
  ```

#### Get_Service_Info

- **Command**

  ```txt
  [Header]Get_Service_Info;[1];[2][Trailer]
  ```

  \[1\] DMA ID

  \[2\] Service ID

- **Response**

  Name and ID of the service, followed by the colon-separated list of elements and services it contains.

  ```txt
  [Header][A]│[B]│[C]│[1]│[2]│[3]│[4]│[5]│[6]:...:[1]│[2]│[3]│[4]│[5]│[6][Trailer]
  ```

  \[A\] Service ID

  \[B\] DMA ID of the DMA where the service was originally created

  \[C\] Name of the service

  \[1\] ID of the element or service that is a part of \[A\]\[B\]\[C\]

  \[2\] DMA ID (as stored in \[1\])

  \[3\] Indicates whether \[1\] is an element (TRUE) or a service (FALSE).

  \[4\] Indicates whether \[1\] can be dynamically included or excluded (TRUE or FALSE).

  \[5\] Indicates whether \[1\] is currently included or excluded (INCLUDED/EXCLUDED).

  \[6\] Comma-separated list of parameter IDs, indicating which of the parameters of \[1\] are included in the service. If none are listed, then all parameters of \[1\] are included.

- **Example**

  When a DMA receives:

  ```txt
  \tGet_Service_Info;5;10056\r
  ```

  It will return:

  ```txt
  \t10056│5│SRV_Service_ChannelY│9605│5│FALSE│TRUE│ INCLUDED│:10060│5│FALSE│FALSE│ INCLUDED│23,24\r
  ```

#### Get_Service_List

- **Command**

  ```txt
  [Header]Get_Service_List[Trailer]
  ```

- **Response**

  A colon-separated list of services and spectrum measurement points:

  ```txt
  [Header][1]│[2]│[3]│[4]:...:[1]│[2]│[3]│[4][Trailer]
  ```

  \[1\] ID of the service or the spectrum measurement point

  \[2\] DMA ID of the DMA where the service or the spectrum measurement point was originally created

  \[3\] Name of the service or the spectrum measurement point

  \[4\] In case of a spectrum measurement point, the abbreviation “MP” is added after the name.

- **Example**

  When a DMA receives:

  ```txt
  \tGet_Service_List\rv
  ```

  It will return:

  ```txt
  \t627│101│S_DMA:502│102│Port01│MP:178│103│Serv_Test\r
  ```

#### Get_System_Info

- **Command**

  ```txt
  [Header]Get_System_Info;[1][Trailer]
  ```

  \[1\]

  - id:\[DMA ID\]

  - ip:\[Primary IP address of the DMA\]

- **Response**

  ```txt
  [Header][1]│[2]│[3]│[4]│[5]│[6][Trailer]
  ```

  \[1\] DMA ID

  \[2\] Computer name

  \[3\] Time at which the DataMiner Agent software was last started (format: YYYY-MM-DD HH:MM:SS)

  \[4\] Serial ports (number and names)

  \[5\] IP address and subnet mask of all IP interfaces

  \[6\] Network cards (number and MAC addresses)

- **Example**

  When a DMA receives:

  ```txt
  \tGet_System_Info;ip:10.11.2.1\r
  ```

  It will return:

  ```txt
  \t102│DMA-2│2011-12-23 11:05:31│ (2) : COM1;COM2│10.11.1.1-255.0.0.0;172.30.1.101-255.255.0.0│ (2) : 00-13-DA-58-8A-62;00-7C-49-69-74-9B;5\r
  ```

#### Get_User_Info

- **Command**

  ```txt
  [Header]Get_User_Info;[1][Trailer]
  ```

  \[1\] Username

  > [!NOTE]
  > To get user info for a domain user, place the domain name followed by backslash in front of the username.

- **Response**

  ```txt
  [Header][1]│[2]│[3]│[4]│[5]│[6][Trailer]
  ```

  \[1\] Username

  \[2\] Full name

  \[3\] Email address

  \[4\] Telephone number

  \[5\] Pager number

  \[6\] Pipe-separated list of DMS groups of which the user is a member

- **Example**

  When a DMA receives:

  ```txt
  \tGet_User_Info;John\r
  ```

or

 ```txt
  \tGet_User_Info;MyDomain\John\r
  ```

  It will return:

  ```txt
  \tJohn│John Doe│john.doe@skyline.be│051/313569│101│Administrators│System Engineers\r
  ```

#### Get_User_Info (list)

- **Command**

  ```txt
  [Header]Get_User_Info[Trailer]
  ```

- **Response**

  A colon-separated list of users:

  ```txt
  [Header][1]│[2]│[3]│[4]│[5]│[6]:...:[1]│[2]│[3]│[4]│[5]│[6][Trailer]
  ```

  \[1\] Username

  \[2\] Full name

  \[3\] Email address

  \[4\] Telephone number

  \[5\] Pager number

  \[6\] Pipe-separated list of DMS groups of which the user is a member

- **Example**

  When a DMA receives:

  ```txt
  \tGet_User_Info\rv
  ```

  It will return:

  ```txt
  \tJohn│John Doe│john.doe@skyline.be│051/313569│101│Administrators│System Engineers: Jane│Jane Doe│jane.doe@skyline.be│051/313569│102│Sales\r
  ```

#### Get_Virtual_Element_List

- **Command**

  ```txt
  [Header]Get_Virtual_Element_List[Trailer]
  ```

- **Response**

  A colon-separated list of virtual elements:

  ```txt
  [Header][1]│[2]│[3]│[4]:...:[1]│[2]│[3]│[4][Trailer]
  ```

  \[1\] ID of the primary element

  \[2\] DMA ID of the DMA where the primary and virtual element were originally created

  \[3\] ID of the virtual element

  \[4\] ID of the redundancy group of which the primary element is a member

- **Example**

  When a DMA receives:

  ```txt
  \tGet_Virtual_Element_List\r
  ```

  It will return:

  ```txt
  \t956│102│962│960:957│102│961│960:1023│102│1025│960: 1024│102│1026│960│10025│5│10029│10028:10024│5│10030│10028\r
  ```

#### Set_Parameter

- **Command**

  ```txt
  \tSet_Parameter;[1];[2];[3];[4];[5];[6];[7]\r
  ```

  \[1\] DMA ID

  \[2\] Element ID

  \[3\] ID of the write parameter

  \[4\] If you specify “double” or “string”, the value will be converted accordingly. If you do not specify a type, the value will be converted automatically (when the value contains only numbers (or a decimal point), it will be parsed as double).

  - double

  - string

  - \<empty>

  \[5\] If \[3\] refers to a table parameter, then \[5\] has to contain the primary key of the table row.

  \[6\] If \[3\] refers to a table parameter and you left \[5\] empty because you do not know the primary key of the table row, then in \[6\] specify the display key of the table row.

  \[7\] The value you want to assign to the parameter specified in \[3\].

- **Response**

  0x09\[1\]0x0D     \[1\] One of the following responses:

  | Response                                        | Description                                          |
  |---------------------------------------------------|------------------------------------------------------|
  | SUCCEEDED                                         | The SET command was executed successfully.           |
  | ERROR: Not allowed                                | Not allowed to perform SET commands via this socket. |
  | ERROR: General failure                            | No connection with the DMS                           |
  | ERROR: Invalid nr of options xx need at least 7   | Invalid command info                                 |
  | ERROR: Setting the parameter-value failed. (xxxx) | The SET command failed                               |

- **Example**

  When a DMA receives:

  ```txt
  \tSet_Parameter;5;20848;100;double;;;0\r
  ```

  It will return the following if the SET command was successful:

  ```txt
  \tSUCCEEDED\r
  ```

### Alarm states

| Alarm state | Integer |
|-------------|---------|
| Undefined   | 0       |
| Normal      | 1       |
| Warning     | 2       |
| Minor       | 3       |
| Major       | 4       |
| Critical    | 5       |
| Information | 6       |
| Timeout     | 7       |
| Initial     | 8       |
| Masked      | 9       |
