---
uid: Configure_DataMiner_using_Ansible
---

# Configure DataMiner using Ansible

## Ansible

With Ansible it's possible to enable Infrastructure as a code in your organisation. It's an open-source software tool that runs on a Linux based OS but can control any kind of OS (Windows, Linux and Mac). With the tool you can do provisioning, configuration management and application deployment.

This means you can also provision your DataMiner!

This page will help you with the basic steps of installing Ansible and then use it to provision DataMiner using Ansible Playbooks.

Full documentation and how Ansible works can be found [here](https://docs.ansible.com/ansible/latest/getting_started/index.html).

### Installing Ansible

For the installation of Ansible you can follow the guide created by the Ansible team. There you can find the requirements of the server, but also the exact steps to install it on your prefered OS (Linux). With the following link you will open the [Installation guide](https://docs.ansible.com/ansible/latest/installation_guide/index.html).

If you want to control a Windows OS, some additional configuration needs to be done on the server. The steps for this you can find [here](https://docs.ansible.com/ansible/latest/os_guide/windows_usage.html).

### Configure your inventory

To use Ansible Playbook you have to create your Inventory. This is really easy to do.
The full documenten can be found [here](https://docs.ansible.com/ansible/latest/inventory_guide/intro_inventory.html#inventory-basics-formats-hosts-and-groups).

For DataMiner, you have to create a group for each DataMiner you want to provide with data. This because only 1 agent in a cluster needs to receive the provisioning.
You can offcourse provision different DMA's in the cluster with different data to spread the load.

In the inventory file you can use the IP or the hostname of the server.

## Create an Ansible Playbook

Below you can find a small Ansible Playbook to provision your DataMiner, however much more is possible using Ansible Playbooks, here you can find the full [information](https://docs.ansible.com/ansible/latest/playbook_guide/index.html).

If you want to follow the steps below, you can find the needed files [here](https://github.com/SkylineCommunications/Ansible-How-To-Files). Here you can find a DataMiner apppackage that will upload the needed protocol and alarm template.

### DataMiner Web API

To provision your DataMiner system, you'll use the DataMiner Web API. To connect to your DataMiner Web API go to: <https://[hostname]]/API/v1/json.asmx> or <https://[IP]]/API/v1/json.asmx>.

On this page you'll be able to see all the possible request that you can do on the sytem. For the below example you'll need a minimum DataMiner version of 10.2. This because some new options have been added starting from this version.

For the demo below you'll use several of the request to get a feeling how evertyhing works.

By clicking on one of those request, you can see what variables are needed for the request. As example, below you can see the request for the ConnectApp request.

As you can see you need several parameters for the request:

- host = hostname of server, can be the IP or hostname
- loging = username to login in the DataMiner system
- password = password of the user
- ClientAppName = a visual name so you can see in your logs what is connected
- ClientAppVersion = the version of your App
- ClientComputerName = the name of the Computer you are connecting from

You can see you also have a response:

- ConnectAppResult = this key is needed to use in the other requests

![ConnectApp API Request](~/images/Ansible_webapi.png)

> [!TIP]
> It can be helpfull to first test the API request with an API platform like Postman to test your requests and see the returned values.

### Installing DataMiner App Package

This is currently not possible with the API, also upload a protocol is not possible yet.
For this demo, you can download and install this [DataMiner App Package](https://github.com/SkylineCommunications/Ansible-How-To-Files) from our Skyline Communications github. This will install the Microsoft Platform Protocol that can be used for this demo purpose.

### Creating an Ansible Playbook

### Provision DataMiner

To create the playbook you create a new yaml file. This yaml file has to start with 3 dashes.
You give your playbook a name and define the hosts to run on. This should be the group name you used in your invetory file from Ansible. In the test case you can see this is called **DataMiner**.

To be able to reuse some values, you can use vars in your playbook.
The variables are defined at the top of your playbook under **vars**.
In the demo you'll see JSON and SOAP requests, because of that both are configures, however also using 1 of these is possible.
In below example the JSON and SOAP connection string together with the content type are configures as variable.

For the JSON request you also need the endpoints that will be used. This is also stored in a variable. These are the same that you'll find on the WEB API page.

```yaml
---
- name: DataMiner Provisiong Example
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

After defining the variables its time to define the tasks of the Ansible Playbook.
You can have a lot of different tasks, below you'll only see some that are available in Ansible, but on the help pages of Ansible you can find more types of tasks.

The first tasks is a way to display some text on the screen. This can be usefull to debug, or have a better overview of what is happening. In the example below you'll post a message to the screen to show you have started the playbook.

```yaml
    tasks:
        - debug:
            msg: "Ansible Playbook to Provision DataMiner"
```

The second task is to retrieve the connectionID that is needed to be able to do other API requests.

First you start with the name of the task. And then create your URI request. For the URI request, some parameters are needed to define the type of request.

The url to connect to is our **jsonServer** with the **connect** variable, these 2 variables create our **ConnectApp** url. A variable in a Playbook is defined between **"{{variable_name}}"**.

With the **return_content** set to yes, you tell the request that you'll use the return value. This return value is then stored in the variable you assign in **register** at the bottom of the task.

The body part then defines the parameters for the request. These are the parameters of DataMiner. For the login and password, these values are the values of an account that has access in DataMiner.

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
            "password": "[Inser Password of DataMiner User]",
            "clientAppName": "[Name for your connection]",
            "clientAppVersion": "1.0",
            "clientComputerName": "[Client Computer Name]]"
            }'
        register: connectionId
```

Now you can use the value of this connectionId to do other requests on DataMiner. You'll first create a View on DataMiner. For this you create again a new task with a name.

The request is again a JSON request as above. But for the **connection** parameter you can see you'll now use a special variable. This is the variable of **connection**, then parsed to JSON and you'll use the value of parameter **d** in this JSON.
To know the output of a request, it's usefull to first test it in an API tool, so you can easily see the response you get.

The **parentViewID** is here configured to have the root view as parent. This root view is defined with **-1**.

At the end the response is saved again in a variable, this variable will then be used again in a next request.

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

The next example is to create an element on the DataMiner. But now you'll use a SOAP request.

For this example you'll have to use use the soapServer variable. For SOAP requests you don't need to define the exact request link, as the SOAP body defines this.
In the request however, you also have to define the soapContent, otherwise the request will not work.

You can see you'll use the **connection.json.d** as connection string again, and now you'll also use the variable from the view you created. This variable has to be casted to an integer value, as this is wat the request expects. To cast something to an integer you can use **| int**, see the below example.

The other parameters are basic parameters to create an element on DataMiner.

> [!CAUTION]
> It's not possible yet to use the returned SOAP XML response as variable in other tasks.

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

In order to retrieve the elementID that was created you can do another request: **getElementByName**. You can request this data with JSON.

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

From the above example you get a big response back. This response cannot be directly converted to JSON.

Because of this you first have to parse the text with **from_json** and **to_json** pipelines. Now you can use **ID** as variable in your playbook.

```yaml
    - name: Parse json
      set_fact:
        parsed_json: "{{elementInfo.content | from_json}}"
    - name: Extract ID
      set_fact:
        ID: "{{parsed_json.d.ID | to_json}}"
```

With the ID you can now do actions on the Element itself, for example assign an alarm template to it (this alarm template is also in the package with the protocol).

As you can see you'll use the variable **ID** now for the element ID. Like you captured the ID you can also capture the DataMinerID. Also variables as the protocolName and protocolVersion can be collected from the elementInfo if wanted.

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

The next step you can take is to upload a visio file. This is most easy using the SOAP request. For SOAP you have to encode your file to Base64, for JSON however an array of Bytes is required.

Below you can find the example using SOAP, note that we didn't include the complete encoded text as this would make it to long.

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

After you uploaded the Visio file, you still have to set it active. This is also easily done with the API.
For this you'll reuse the **visioFileName** from the example above.

The parameter **defaultPageID** can be used if you have Visio with multiple pages, to configure which page is the default one when opening the Visio file.

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

Now you have a DataMiner with a custom view that contains 1 element, with an assigned alarm template and a Visio file assigned to it.

#### Clean DataMiner

In the same way, you can create an Ansible Playbook te delete the view and element from the system.
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

### Running an Ansible Playbook

To run an Ansible Playbook you can do this from your server where the yaml file is located.
You can then easily use following command to run the playbook.

```cmd
ansible-playbook nameOfYourFile.yaml
```
