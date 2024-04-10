---
uid: secure_architecture
---

# Secure architecture

## SLDC (Secure Software Development Life Cycle) Principles

### CIA Triangle

The three pillars of a secure system are:

- **Confidentiality**: ensure only authorized users can access the data, e.g. authentication, encryption, ...
- **Integrity**: ensure the data cannot be modified or deleted without permission, e.g. authorization, checksums, ...
- **Availability**: ensure the data is available to authorized users when needed, e.g. backups, DoS protection, ...

![CIA Triangle](~/images/technical_cia_triad.png)

### User Input

Any user input must undergo validation/sanitizing prior to processing.

Examples:

- Some characters are not allowed in Windows filenames or directory names
- For data that will be rendered as HTML, ensure it is encoded.

### File Uploads

Secure applications should be able to fend off corrupt or malicious files.

- Whitelist allowed file types, don't rely on blacklists
- Validate the file type
- Set a filename length limit, restrict the allowed characters
- Set a file size limit
- Store files outside the web root

> [!TIP]
> For more file upload security tips, please refer to the [OWASP File Upload Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/File_Upload_Cheat_Sheet.html).

### Principle of Least Privilege

Always perform actions with the least amount of access necessary to perform a given function.

The Principle of Least Privilege requires running code only with the permissions needed to complete the required tasks and no more. When designing applications, the capabilities attached to executing code should be limited in this manner.

Far too often, applications run at too great a permission level. They execute using privileged accounts such as *root* in UNIX environment or *LOCALSYSTEM* in Windows environments. When web and application servers run as *root* or *LOCALSYSTEM*, the processes and the code on top of these processes run with all of the rights of these users. Malicious code will execute with the authority of the privileged account, thus increasing the possible damage from an exploit. Applications should be executed under accounts with **minimal permissions**.

For more information, please refer to [Enforce Least Privilege](https://cheatsheetseries.owasp.org/cheatsheets/Authorization_Cheat_Sheet.html#enforce-least-privileges).

> [!TIP]
> Do not perform your daily duties as Administrator or root user. Instead use a separate superuser account, and perform administrative actions under that account explicitly.

### Layered Security

A layered security architecture is based on the notion that the whole is many times stronger than the sum of its parts. In other words, the synchronization of multiple security measures produces a stronger effect than if those components are working individually. Layering security controls is more effective than relying on a single control on your endpoints.

> [!NOTE]
> This is often referred to as "Defense in Depth" or the **[onion](~/images/technical_onion.png)** because it implies the use of multiple embedded layers. With modern distributed systems, an **[artichoke](~/images/technical_artichoke.png)** often makes a better analogy than an onion. While protections do overlap each other, like the petals of an artichoke, the compromise of a single defense can often be used as a stepping stone to compromise other parts of the distributed system.

### Minimize the Attack Surface

The Attack Surface describes **all of the different points** where an attacker could get into a system, and where they could get data out.

The Attack Surface of an application is:
- the sum of all paths for data/commands into and out of the application
- the code that protects these paths (including resource connection and authentication, authorization, activity logging, data validation and encoding)
- all valuable data used in the application, including secrets and keys, intellectual property, critical business data, personal data
- the code that protects these data (including encryption and checksums, access auditing, and data integrity and security controls)
- overlay this with the different types of users (roles &amp; privilege) that can access the system

It is important to **focus especially on the two extremes**: unauthenticated, anonymous users and highly privileged admin users (e.g. database administrators, system administrators).

By minimizing your attack surface, you reduce the chance threat actors can gain unauthorized access.
Applications should **disable functionality** that is not *explicitly* activated by the user at run-time.
Developers should **delete unused or unreferenced code paths** from the application.

### Secure Defaults

Ensure your code is secure by default, do not rely on a user to configure security for your application.

The principle of secure defaults states that the default configuration of a system reflects a restrictive &amp; conservative enforcement of security policy. The principle of secure defaults applies to the initial configuration of a system as well as to the security engineering and design of access control and other security functions that follow a "deny unless explicitly authorized" strategy. The initial configuration aspect of this principle requires that any "as shipped" configuration of a system, subsystem, or system component does not aid in the violation of the security policy and can prevent the system from operating in the default configuration for those cases where the security policy itself requires configuration by the operational user.

For Example:
- Ensure all traffic is encrypted by default
- Ensure authentication of (sub)components is enabled
- Do not rely on default accounts

> [!TIP]
> - Enable authentication on that endpoint or database.
> - Deny access to resources by default.

### Fail Securely

Improper handling of errors can introduce a variety of security problems for a web site. The most common problem is when detailed internal error messages such as stack traces, database dumps, and error codes are displayed to the user (hacker). These messages reveal implementation details that should never be revealed. Such details can provide hackers important clues on potential flaws in the site and such messages are also disturbing to normal users.

> [!TIP]
> StackTraces contain a lot of valuable information for attackers, instead return fixed messages or error codes that users can translate into specific problems.

### Prioritizing Vulnerabilities

Prioritize your remediation efforts based on the severity of the vulnerability and its potential impact on the confidentiality, integrity, or availability of the vulnerable system or data. Vulnerability severity is determined by the rating provided by the National Institute of Standards and Technology (NIST) Common Vulnerability Scoring System (CVSS).

Highest priority should be given to vulnerabilities rated Critical (CVSS 9-10) or High (CVSS 7-8.9).

After a vulnerability is detected and a fix is available, the timeline for remediation begins.

- Critical (CVSS 9-10) Vulnerabilities:
    Create corrective action plan within two weeks.
    Remediate vulnerability within **one month**.
- High (CVSS 7-8.9) Vulnerabilities:
    Create corrective action plan within one month.
    Remediate vulnerability within **three months**.
    
![CVSS Scoring Metrics](~/images/technical_cvss_score_metrics.png)
