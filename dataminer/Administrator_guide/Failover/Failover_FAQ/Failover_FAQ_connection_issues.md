---
uid: Failover_FAQ_connection_issues
---

# What if I have connection issues after a Failover switch?

It is possible that, after a Failover switch, you run into connection issues because of incorrect routing mechanisms to the correct Agent.

## [Virtual IP addresses](#tab/tabid-1)

Failover pairs using virtual IP addresses may run into connection issues because the servers' routing tables have been altered. This problem is caused by the way persistent routes have been defined.

To fix the problem, you need to recreate the routes and explicitly specify an interface for them to bind to.

> [!NOTE]
> It is best to do this from a remote desktop session on the other Agent, as deleting the routes could otherwise kill your session.

1. In a command prompt window, execute the following command:

   ```txt
   route print
   ```

   This will produce a list like the following one:

   ```txt
   Interface List
   23...b8 ac 6f 15 15 1a ......BASP Virtual Adapter #4
   20...b8 ac 6f 15 15 1a ......BASP Virtual Adapter #2
   21...b8 ac 6f 15 15 1a ......BASP Virtual Adapter #3
   24...b8 ac 6f 15 15 1e ......BASP Virtual Adapter #6
   1...........................Software Loopback Interface 1
   22...00 00 00 00 00 00 00 e0 Microsoft ISATAP Adapter #2
   17...00 00 00 00 00 00 00 e0 Microsoft ISATAP Adapter #4
   ```

   Also, there will be a list of persistent routes for IPv4:

   ```txt
   Persistent routes:  Network Address Netmask Gateway Address Metric   1.2.3.4 255.255.255.0 5.6.7.8 1
   ```

1. In another command prompt window, execute the following commands for each of the listed persistent routes.

   In the lines below, replace the IP addresses and masks by the ones in the list above, and replace “X” by the correct interface ID. In the list above, “23”, “20”, “21” and “24” are correct interface IDs.

   ```txt
   route delete 1.2.3.4  route add 1.2.3.4 mask 255.255.255.0 5.6.7.8 IF X -p
   ```

   > [!NOTE]
   > Make sure that you use the correct interface ID for the route to go through. In the example above, this should be the interface through which the 5.6.7.8 gateway address can be reached. "Ipconfig /all" might help for you to select the correct interface. If an interface exists for which the route gateway address falls within the subnet for that interface, that interface should be used (e.g., a local interface having IP address 5.6.0.1 and mask 255.255.0.0).

Once the routes have been recreated with an interface number assigned, they will no longer disappear from the list of active routes when the virtual IP address is removed because the DMA is stopped or goes offline.

## [Shared hostname](#tab/tabid-2)

Failover pairs using a shared hostname rely on the [*Application Request Routing* IIS extension](https://www.iis.net/downloads/microsoft/application-request-routing), which redirects requests from the offline Agent to the online Agent. Configuration or state issues with these rules may result in connection issues.

1. Open Internet Information Services (IIS) and navigate to *Manager > Sites > Default Web Site > URL Rewrite*.

   ![IIS URL Rewrite](~/dataminer/images/FailoverIISUrlRewrite.png)

1. In the list of rules, look for a rule named `dataminer-failover-reverseproxy-rule`.

   This rule should be enabled on the offline Agent and disabled on the online Agent. During a switch, the state of the rule should reflect this change.

1. If the state of the `dataminer-failover-reverseproxy-rule` rule is incorrect, manually change it by selecting the rule and clicking *Enable Rule* or *Disable Rule* in the right section.

   ![Change Rule State](~/dataminer/images/FailoverIISRewriteRuleChangeState.png)

1. Double-click the rule to view its properties, which should include:

   - Match URL

     ![Failover Rewrite Rule Match URL Property](~/dataminer/images/FailoverRewriteMatchURLProperty.png)

   - Conditions

     ![Failover Rewrite Rule Conditions Property](~/dataminer/images/FailoverRewriteConditionsProperty.png)

   - Action

     ![Failover Rewrite Rule Action Property](~/dataminer/images/FailoverRewriteActionProperty.png)

1. To fix any inconsistencies in the rules, follow these steps:

   1. Open a Powershell console as Administrator.

   1. Navigate to `C:\Skyline Dataminer\Tools`.

   1. Execute the following command:

      ```txt
      .\Failover-ARR-WriteInboundRule.ps1 <Buddy ip>
      ```

   1. Execute the following command:

      ```txt
      .\Failover-ARR-ToggleInboundRule.ps1 <true|false> 
      ```

      Use `true` if the Agent is the offline Agent in the Failover pair. Otherwise, use `false`.

***
