---
uid: Configure_DataMiner_using_Ansible
---

# Configuring DataMiner using Ansible

With Ansible, you can enable infrastructure as a code in your organization. Ansible is an open-source software tool that runs on Linux-based operating systems, but that can control any kind of operating system (Windows, Linux, and macOS). With this tool, you can do provisioning, configuration management, and application deployment.

This means you can also provision your DataMiner System. This page will help you with the basic steps of installing Ansible and then using it to provision DataMiner using Ansible playbooks.

> [!TIP]
> For full documentation on Ansible, refer to [docs.ansible.com](https://docs.ansible.com/ansible/latest/getting_started/index.html).

## Installing Ansible

For the installation of Ansible, you can follow the [guide created by the Ansible team](https://docs.ansible.com/ansible/latest/installation_guide/index.html). It includes the server requirements as well as the exact steps to install the tool on your preferred Linux operating system.

If you want to control a Windows operating system, [some additional configuration](https://docs.ansible.com/ansible/latest/os_guide/windows_usage.html) needs to be done on the server.

## Configuring your inventory

To use an Ansible playbook, you have to [create your inventory](https://docs.ansible.com/ansible/latest/inventory_guide/intro_inventory.html#inventory-basics-formats-hosts-and-groups).

When you do so for DataMiner, you will need to create a **group for each DataMiner Agent** you want to provide with data. You should use the **IP or the hostname** of the server for this. Every IP/hostname in a group will receive the same provisioning, which is why each DMA should be in a group of its own; otherwise, all Agents would get the same commands to execute.

Strictly speaking, you could only execute the provisioning on one Agent in a cluster, and the DataMiner synchronization would take care of the rest. However, to spread the load, it can be useful to provision different DMAs in the cluster with different data.

## Using the DataMiner Web API

To provision your DataMiner System, you will need to use the [DataMiner Web API](xref:Using_the_Web_Services_v1). To connect to the API, go to <https://[DMA hostname]]/API/v1/json.asmx> or <https://[DMA IP]]/API/v1/json.asmx>. This page will show all the possible requests you can execute on the system.

For the example under [Creating an Ansible Playbook](#creating-an-ansible-playbook), you will need to use **DataMiner 10.2** or higher, as it makes use of options that are only available starting from this version.

The example includes several requests so you can get a feeling of how everything works. If you click on such a request on the above-mentioned API page, you will see which variables are needed for it.

For example, for the [ConnectApp](xref:ConnectApp) request, the following input parameters are needed:

- *login*: The username to log in to the DataMiner System.
- *password*: The corresponding password.
- *ClientAppName*: The name of your client app, so that you can see in the logging what is connected.
- *ClientAppVersion*: The version of your client app.
- *ClientComputerName*: The name of the computer you are connecting from.

This will return the following response:

- *ConnectAppResult*: This key is needed in the other requests.

![ConnectApp API Request](~/develop/images/Ansible_webapi.png)

> [!NOTE]
> It can be helpful to first test your API requests with an API platform like [Postman](xref:Postman) and check the returned values.

> [!TIP]
> For detailed information about each of the available methods, see [Methods (v1)](xref:WS_Methods_v1_overview).

## Creating an Ansible playbook

Below, you can find a small Ansible playbook to provision your DataMiner System. However, you can do much more using Ansible playbooks. For complete information, refer to [docs.ansible.com](https://docs.ansible.com/ansible/latest/playbook_guide/index.html).

If you want to try out the steps below, you can find the necessary files [on GitHub](https://github.com/SkylineCommunications/Ansible-How-To-Files). This includes a DataMiner app package that will upload the required protocol (i.e the Microsoft Platform protocol) and alarm template.

> [!NOTE]
> At present, it is not possible to install an app package or upload a protocol via the DataMiner API.

### Provisioning DataMiner

#### Create the .yaml file

To create the playbook, create a new .yaml file that starts with 3 dashes. Then give your playbook a name and define the hosts it should run on. This should be the group name you used in your Ansible inventory file. In the example below, this is *DataMiner*.

#### Define the variables

To be able to reuse some values, you can use variables in your playbook. These variables are defined at the top of the playbook under *vars*.

The example illustrates the use of both JSON and SOAP requests, but you can also use just one of these. The JSON and SOAP connection string, together with the content type, are configured as variables.

For a JSON request, you need the endpoints that will be used. This is also stored in a variable. These are the same as you will find on the Web API page.

```yaml
---
- name: DataMiner Provisioning Example
  hosts: DataMiner
  vars:
    jsonServer: "https://DataMinerServer/API/v1/json.asmx"
    soapServer: "https://DataMinerServer/API/v1/soap.asmx"
    jsonContent: "application/json"
    soapContent: "text/xml"
    connect: "/ConnectApp"
    createView: "/CreateView"
    elementByName: "/GetElementByName"
    assignAlarmTemplate: "/AssignAlarmTemplate"
```

#### Define the tasks of the Ansible playbook

There can be many different tasks. Below, we only show some of the available tasks in Ansible, but you can find more types on [docs.ansible.com](https://docs.ansible.com/ansible/latest/playbook_guide/index.html).

1. The first task is to **display some text on the screen**. This can be useful to debug or to have a better overview of what is happening. In the example below, you post a message to the screen to show you have started the playbook.

   ```yaml
       tasks:
           - debug:
               msg: "Ansible playbook to Provision DataMiner"
   ```

1. The second task is to **retrieve the connection ID** that is needed to be able to do other API requests. First you start with the name of the task, then you create your URI request. For the URI request, some parameters are needed to define the type of request:

   - In this case, the URL to connect to is the *jsonServer* with the *connect* variable. These two variables together form the *ConnectApp* URL.

     > [!NOTE]
     > A variable in a playbook is defined in the format *"{{variable_name}}"*.

   - Set *return_content* to *yes* to indicate that you will use the return value. This return value is then stored in the variable you assign in *register* at the bottom of the task.

   - The *body* section defines the parameters for the request. These are the parameters of DataMiner. For the login and password, these values are the values of an account that has access in DataMiner.

   ```yaml
       - name: Connect With DataMiner
         ansible.windows.win_uri:
           url: "{{jsonServer}}{{connect}}"
           return_content: yes
           content_type: "{{jsonContent}}"
           url_method: POST
           body: '{
               "host": "{{server}}",
               "login": "[Insert DataMiner User]",
               "password": "[Insert Password of DataMiner User]",
               "clientAppName": "[Name for your connection]",
               "clientAppVersion": "1.0",
               "clientComputerName": "[Client Computer Name]]"
               }'
           register: connectionId
   ```

   Now you can use the value of *connectionId* to create other requests for DataMiner.

1. **Create a view** in DataMiner. For this, you again need to create a new task with a name.

   - The request is a **JSON** request like above, but for the *connection* parameter, you will now need to use a special *connection* variable. This variable is then parsed to JSON, and there you will use the value of parameter *d*.

     > [!NOTE]
     > To know the output of a request, it can be useful to first test it in an API tool, so you can easily see the response you get.

   - The *parentViewID* is here configured to have the root view as its parent. This root view is defined with *-1*.

   - The response is saved in a variable, which will be used in a next request.

   ```yaml
       - name: CreateView
         ansible.windows.win_uri:
           url: "{{jsonServer}}{{createView}}"
           return_content: yes
           content_type: "{{jsonContent}}"
           url_method: POST
           body: '{
               "connection": "{{connectionId.json.d}}",
               "parentViewID": -1,
               "viewName": "AnsibleDemoView"
               }'
           register: ansibleView
   ```

1. Next, you can **create an element** in DataMiner. To illustrate this, this time we will use a **SOAP** request.

   - For this example, you will need to use the *soapServer* variable. For SOAP requests, you do not need to define the exact request link, as the SOAP body defines this. However, in the request, you also have to define the *soapContent*, as otherwise the request will not work.

   - The *connection.json.d* parameter is used as the connection string again.

   - Now you can also use the variable representing the view you created. This variable has to be cast to an integer value, as this is wat the request expects. To cast something to an integer you can use `| int`, as illustrated below.

   - The other parameters are basic parameters to create an element in DataMiner.

   > [!NOTE]
   > It is not yet possible to use the returned SOAP XML response as a variable in other tasks.

   ```yaml
       - name:
         ansible.windows.win_uri:
           url: "{{soapServer}}"
           return_content: yes
           content_type: "{{soapContent}}"
           url_method: POST
           body: '<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
           <soap:Body>
           <CreateElement xmlns="http://www.skyline.be/api/v1">
               <connection>{{connectionid.json.d}}</connection>
               <dmaID>[DataMiner ID]</dmaID>
               <viewIDs>
                   <int>{{ansibleView.json.d | int}}</int>
               </viewIDs>
               <configuration>
                   <Name>MS Platform</Name>
                   <ProtocolName>Microsoft Platform</ProtocolName>
                   <ProtocolVersion>1.1.0.99</ProtocolVersion>
                   <Ports>
                       <DMAElementBasePortInfo xsi:type="DMAElementSerialPortInfo">
                           <IPAddress>localhost</IPAddress>
                           <TimeoutTime>60</TimeoutTime>
                           <ElementTimeoutTime>30</ElementTimeoutTime>
                       </DMAElementBasePortInfo>
                   </Ports>
               </configuration>
           </CreateElement>
           </soap:Body>
           </soap:Envelope>'
   ```

1. To **retrieve the element ID of the created element**, use a *getElementByName* request. You can request this data with JSON.

   ```yaml
       - name: GetElementByName
         ansible.windows.win_uri:
           url: "{{jsonServer}}{{elementByName}}"
           return_content: yes
           content_type: "{{jsoncontent}}"
           url_method: POST
           body: '{
             "connection": "{{connectionid.json.d}}",
             "elementName": "MS Platform"
             }'
         register: elementInfo
   ```

   The example above returns a big response that cannot be directly converted to JSON. Because of this, you first need to parse the text with *from_json* and *to_json* pipelines. Then you can use *ID* as a variable in your playbook.

   ```yaml
       - name: Parse json
         set_fact:
           parsed_json: "{{elementInfo.content | from_json}}"
       - name: Extract ID
         set_fact:
           ID: "{{parsed_json.d.ID | to_json}}"
   ```

1. With the ID, you can now execute actions on the element itself, for example **assigning an alarm template** to it. If you downloaded our example package from GitHub, the alarm template is included in the package.

   Use the variable *ID* for the element ID now. Like you captured the ID, you can also capture the DataMiner ID. You can also collect variables such as the *protocolName* and *protocolVersion* from the element info.

   ```yaml
       - name: AssignAlarmTemplate
         ansible.windows.win_uri:
           url: "{{server}}{{assignAlarmTemplate}}"
           content_type: "{{jsoncontent}}"
           url_method: POST
           body: '{
             "connection": "{{connectionid.json.d}}",
             "elements": [{
               "DataMinerID": "{{dataminerID}}",
               "ID": "{{ID}}"
               }],
             "protocolName": "Microsoft Platform",
             "protocolVersion": "1.1.0.99",
             "templateName": "AlarmTemplate"
             }'
   ```

1. Next, you can **upload a Visio file**. This is the easiest using a **SOAP** request. For SOAP, you have to encode your file to Base64, while for JSON an array of bytes is required.

   Below you can find the example using SOAP; however, note that the complete encoded text is not included, as this would make the example too long.

   ```yaml
       - name:
         ansible.windows.win_uri:
           url: "{{soapServer}}"
           return_content: yes
           content_type: "{{soapContent}}"
           url_method: POST
           body: '<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
       <soap:Body>
           <AddVisioFileToProtocol xmlns="http://www.skyline.be/api/v1">
               <connection>{{connectionid.json.d}}</connection>
               <protocolName>Microsoft Platform</protocolName>
               <visioFileName>Microsoft Platform.vdx</visioFileName>
               <visio>[Encoded Visio file to Base64]</visio>
       </AddVisioFileToProtocol>
       </soap:Body>
   </soap:Envelope>'
   ```

1. Once it has been uploaded, you need to **set the Visio file active**. You can also use the API for this.

   - Reuse the *visioFileName* from the example above.

   - If the Visio drawing has multiple pages, you can use the parameter *defaultPageID* to configure which page should be the default page in Visual Overview.

   ```yaml
       - name:
         ansible.windows.win_uri:
           url: "{{soapServer}}"
           return_content: yes
           content_type: "{{soapContent}}"
           url_method: POST
           body: '<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
       <soap:Body>
           <AssignVisioFileToProtocol xmlns="http://www.skyline.be/api/v1">
               <connection>{{connectionid.json.d}}</connection>
               <protocolName>Microsoft Platform</protocolName>
               <visioFileName>Microsoft Platform.vdx</visioFileName>
               <defaultPageID>0</defaultPageID>
       </AssignVisioFileToProtocol>
       </soap:Body>
   </soap:Envelope>'
   ```

Now your DataMiner System has a custom view that contains one element, with an alarm template and a Visio file assigned to it.

### Cleaning DataMiner

You can also create an Ansible playbook te delete the view and element from the system.

For this you can use the same methods as before:

```yaml
---
- name: DataMiner Cleanup
  hosts: DataMiner
  vars:
    serverjson: "https://dataminerserver/API/v1/json.asmx"
    connect: "/ConnectApp"
    deleteView: "/DeleteView"
    deleteElement: "/DeleteElement"
    elementByName: "/GetElementByName"
    viewByName: "/GetViewByName"
    jsoncontent: "application/json"
    dmaid: 406
  tasks:
    - debug:
        msg: "Get Connection string"
    name: Connect With DataMiner
      ansible.windows.win_uri:
        url: "{{jsonServer}}{{connect}}"
        return_content: yes
        content_type: "{{jsonContent}}"
        url_method: POST
        body: '{
            "host": "{{server}}",
            "login": "[Insert DataMiner User]",
            "password": "[Inser Password of DataMiner User]",
            "clientAppName": "[Name for your connection]",
            "clientAppVersion": "1.0",
            "clientComputerName": "[Client Computer Name]]"
            }'
        register: connectionId
    - name: GetElementByName
      ansible.windows.win_uri:
        url: "{{jsonServer}}{{elementByName}}"
        return_content: yes
        content_type: "{{jsoncontent}}"
        url_method: POST
        body: '{
          "connection": "{{connectionid.json.d}}",
          "elementName": "MS Platform"
          }'
      register: elementInfo
    - name: Parse json
      set_fact:
        parsed_json: "{{elementInfo.content | from_json}}"
    - name: Extract ID
      set_fact:
        ElementID: "{{parsed_json.d.ID | to_json}}"
    - name: Delete Element
      ansible.windows.win_uri:
        url: "{{jsonServer}}{{deleteElement}}"
        return_content: yes
        content_type: "{{jsoncontent}}"
        url_method: POST
        body: '{
          "connection": "{{connectionid.json.d}}",
          "dmaID": "{{dmaid}}",
          "elementID": "{{ElementID | int}}"
          }'
    - name: GetViewByName
      ansible.windows.win_uri:
        url: "{{jsonServer}}{{viewByName}}"
        return_content: yes
        content_type: "{{jsoncontent}}"
        url_method: POST
        body: '{
          "connection": "{{connectionid.json.d}}",
          "viewName": "AnsibleDemoView"
          }'
      register: viewInfo
    - name: Parse json
      set_fact:
        parsed_json: "{{viewInfo.content | from_json}}"
    - name: Extract viewID
      set_fact:
        viewID: "{{parsed_json.d.ID | to_json}}"      
    - name: Delete View
      ansible.windows.win_uri:
        url: "{{jsonServer}}{{deleteView}}"
        return_content: yes
        content_type: "{{jsoncontent}}"
        url_method: POST
        body: '{
          "connection": "{{connectionid.json.d}}",
          "viewID": "{{viewID | int}}"
          }'
```

## Running an Ansible playbook

You can run an Ansible playbook from the server where the .yaml file is located.

You can use following command to run the playbook:

```cmd
ansible-playbook nameOfYourFile.yaml
```
