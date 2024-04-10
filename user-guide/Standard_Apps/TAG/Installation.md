---
uid: secure_coding
---

# Secure coding

## General

For a technology-agnostic set of secure coding practices, please refer to the [OWASP Secure Coding Practices Guide](~/attachments/technical_owasp_scp_v2.pdf).

## .NET

DataMiner heavily relies on .NET, below are some valuable resources regarding .NET &amp; Security:

- [OWASP DotNet Security Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/DotNet_Security_Cheat_Sheet.html)

- [Microsoft Secure Coding Guidelines](https://learn.microsoft.com/en-us/dotnet/standard/security/secure-coding-guidelines)

- [Key DotNet Security Concepts](https://learn.microsoft.com/en-us/dotnet/standard/security/key-security-concepts)

- [Building Secure ASP Applications](https://jamilhallal.blogspot.com/2021/08/building-secure-aspnet-mvc-web.html)

- [Meziantou (Microsoft MVP) .NET Vulnerabilities](https://www.meziantou.net/impersonation-and-security.htm)

## C++

Many of the core DataMiner processes are built using C++ (SLDataMiner, SLElement, SLDMS, ...), below are some resources regarding C++ security guidelines:

- [C++ Security Best Practices](https://learn.microsoft.com/en-us/cpp/security/security-best-practices-for-cpp)
- [Security Features in the CRT](https://learn.microsoft.com/en-us/cpp/c-runtime-library/security-features-in-the-crt)
- [Snyk Top 5 C++ Security Risks](https://snyk.io/blog/top-5-c-security-risks/)

## Angular

The (new) DataMiner web applications are built on Angular, for a set of angular specific secure coding guidelines:

- [Angular Security](https://angular.io/guide/security)

- [Snyk Angular Security Best Practices](https://snyk.io/blog/angular-security-best-practices/)

## DataMiner

### Request messages

Some requests are only meant for communication between internal DataMiner modules, never for client connections (Cube, Web Apps, etc.). 

See the following code:

```
/// <summary>
/// Can only be sent by DataMiner modules. Not to be sent by regular clients.
/// </summary>
[Serializable]
public class SomeInternalMessage : TargetedClientRequestMessage { }
```

The code above should not inherit from *(Targeted)ClientRequestMessage* because it is not meant to be used by customers. Instead use *InterDataMinerMessage* or expand the logic in *Facade.HandleMessageInternal()*.

### PermissionFlags/DataMinerSecurityAttribute

For new Request messages, always consider which **PermissionFlags** apply (or add new flags if needed).

```
[Serializable]
public class SomeRequestMessage : ClientRequestMessage { }
...
public void Handle(IConnectionInfo connInfo, SomeRequestMessage message)
{
    var allowed = connectionInfo.Security.IsAccessAllowed(PermissionFlags.SomeFlag);

    if (!allowed)
    {
        throw new DataMinerSecurityException("Not allowed to ...");
    }

    ... handle the message ...
}
```

The code above is correct, but can be written in an easier way by using the *DataMinerSecurity* attribute, which will automatically verify if the user is allowed to send the request.

```
[Serializable]
[DataMinerSecurity(PermissionFlags.SomeFlag)]
public class SomeMessage : ClientRequestMessage { }

// This even works for enums!
public enum MyDangerousEnum
{
    SafeAction,
    
    [DataMinerSecurity(PermissionFlags.Admin)]
    DangerousAction,
}
```

### SLLicenseRequiredAttribute / SLLicenseRequireOneAttribute

An attribute similar to *[DataMinerSecurity]* exists for licensing checks in the form of the *[SLLicenseRequired]* and *[SLLicenseRequireOneAttribute]*. For example, a message that requires the *Automation* license can be written as follows:

```
[Serializable]
[SLLicenseRequired(LicensedModules.Automation)]
public class SomeAutomationMessage : ClientRequestMessage { }
```

## General

### Directory or path traversal

When reading or writing to files, always make sure to sanitize **any** user input.

See the following code:

```
byte[] HandleGetDocumentMessage(GetDocumentMessage request)
{
    string fullPath = "C:\\Skyline DataMiner\\Documents\\" + request.FileName;

    if(!File.Exists(fullPath))
    {
        return new byte[0];
    }

    return File.ReadAllBytes(fullPath);
}
```

A threat actor could abuse this to read any file on the system by sending...

```
request.FileName = "..\\..\\db.xml";
```

To prevent this, use *Tools.ValidateFullPath()*, which is available in SLNetTypes.

### Insecure deserialization

Never deserialize any untrusted data without type checking.

See the following code:

```
public T Deserialize<T>(HttpRequest request)
{
    try
    {
        BinaryFormatter formatter = new BinaryFormatter();
        return (T)formatter.Deserialize(request.Body);
    }
    catch
    {
        return default;
    }
}

public DMSMessage Deserialize(string json)
{
    JsonSerializer jsonSerializer = new JsonSerializer();
    jsonSerializer.TypeNameHandling = TypeNameHandling.Auto;
    return jsonSerializer.Deserialize<DMSMessage>(json); 
}
```

A threat actor could send *any* .NET type to this API and run malicious code on the server.

Some .NET types are known to allow code execution upon deserialization. These are referred to as *RCE Gadgets*. For more information, see [Known RCE Gadgets](https://cheatsheetseries.owasp.org/cheatsheets/Deserialization_Cheat_Sheet.html#known-net-rce-gadgets).

To prevent this, remove the *BinaryFormatter* **completely**. [Microsoft recommends](https://docs.microsoft.com/en-us/dotnet/standard/serialization/binaryformatter-security-guide#deserialization-vulnerabilities) to stop using *BinaryFormatter* as soon as possible, even when only used for trustworthy input.

For other serializers (e.g. Json.NET), ensure the *TypeNameHandling* is set to *None*. For *NewtonSoft.Json* specifically, please refer to [TypeNameHandling](https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_TypeNameHandling.htm).

> [!WARNING]
> The BinaryFormatter type is dangerous and is not recommended for data processing. Applications should stop using BinaryFormatter as soon as possible, even if they believe the data they're processing to be trustworthy. BinaryFormatter is insecure and can't be made secure. BinaryFormatter will be removed in .NET 9 (Nov 2024).

### Server-side request forgery

Never trust unvalidated user input to interact with other resources on the network or machine. For example, URLs.

See the following backend code:

```
public HttpResponse LoadImageFromUrl(string imageUrl)
{
    HttpClient client = new HttpClient();
    return client.Get(imageUrl);
}
```

A threat actor could leverage this to access internal resources the server can reach, but the threat actor cannot. This can be mitigated by **whitelisting** the allowed URLs or domains. In general, never let the user specify full URLs (or parts of the URL).

## Hashing Algorithms

Hashing is a process that allows you to take plaintext data and apply a mathematical formula (i.e., hashing algorithm) to it to generate a random value of a specific length. A hashing algorithm is a **one-way cryptographic function** that generates an output of a **fixed** length (often shorter than the original input data).
Once something is hashed, it’s virtually **irreversible** as it would take too much computational power and time to feasibly attempt to reverse engineer.

Hashing is used for:
- Data validation
- Password verification
- Digital signatures
- Integrity checks
- Code signing
- Search functionality

Common hashing algorithms:
- **SHA2** is the recommended hashing algorithm by NIST. 
- **SHA3** is an *alternative* (not a successor) for SHA2, which is much faster.
- **MD5** &amp; **SHA1** are considered insecure because [collisions](https://en.wikipedia.org/wiki/Hash_collision) have been found.
- **Argon2** is recommend by the OWASP and designed to provide a high level of defense against GPU-based attacks.
- **Bcrypt** was built to slow down brute force attacks. A [salt](https://en.wikipedia.org/wiki/Salt_(cryptography)) is included in the hashing process, which protects your stored hash values against rainbow tables attacks.
- **PBKDF2** (password-based key derivation function) is recommended by NIST, this hashing algorithm is much slower than SHA, therefore, it’s another suitable hashing algorithm for password protection. It uses a salt to generate harder-to-guess password hashes.

The best hashing algorithm is the one that is making it as hard as possible for the attackers to find two values with the same hash output (aka a collision).

This will depend on your use case.

- To **protect passwords**, use a strong and slow hashing algorithm like Argon2, Bcrypt or PBKDF2, combined with [salt](https://en.wikipedia.org/wiki/Salt_(cryptography)) (or even better, with salt and [pepper](https://en.wikipedia.org/wiki/Pepper_(cryptography))). Basically, avoid faster algorithms for this usage.
- To **verify file signatures and certificates**, SHA-256 or higher is among your best hashing algorithm choices.
- For **data lookup** and files organization, you will want to opt for a fast hashing algorithm that allows you to search and find data quickly. The SHA3 family is a good choice here.

### Cipher Modes of Operation

One way of encrypting data is encrypting a block of information at a time. We would take a single piece of information and we would cut it into these single-sized blocks. And then perform encryption on a single block at a time. This encryption that we would perform can be done in many different kinds of ways. We call this a **mode of operation**. And it defines how that encryption process will occur.

Common Modes of Operation:
- **ECB (Electronic Codebook)**, encrypts each block with exactly the same key. This mode leaks information about the plain text due to a lack of randomization.
- **CBC (Cipher Block Chaining)**, takes each plaintext block and XOR's it with the previous ciphertext block. This is adding randomization, for the very first block we’ll use an IV, or initialization vector.
- **CTR (Counter Mode)**, a counter-initiated value is encrypted and given as input to XOR with plaintext which results in ciphertext block. CTR mode allows a block cipher to act like a stream cipher.
- **GCM (Galois Counter Mode)**, this mode of operation is an authenticated encryption algorithm designed to _provide both data authenticity (integrity) and confidentiality_. GCM combines the well-known counter mode of encryption with the Galois mode of authentication. The authentication tag is constructed by feeding blocks of data into the GHASH function and encrypting the result. _GCM provides great efficiency and security_, GCM is often a good choice for your mode of operation.

> [!TIP]
> Where possible, use **GCM** mode because it provides both confidentiality and integrity. **Prefer CTR mode over CBC mode and avoid ECB** completely because it leaks information about the plain text. 

![Cipher Modes of Operation](~/images/technical_cipher_modes_of_operation.png)


### Timing attacks

A timing attack allows threat actors to infer information about a target, by analyzing the time a specific action takes. This type of attack is quite complex and difficult to exploit, but not impossible! 

A practical example of a time attack is [CVE-2016-6210](https://cve.mitre.org/cgi-bin/cvename.cgi?name=CVE-2016-6210), where the computational difference between the Blowfish &amp; SHA algorithms allows attackers to infer valid usernames on a system.

See the following code:

```
public void ValidatePassword(Guid userId, string loginPassword)
{
    var user = GetUser(userId);

    // The .NET implementation of '!=' will short circuit (see below) when the length of the two strings being compared is not equal.
    // An attacker can leverage this short circuit by timing the compare action.
    // The equality check for a 'loginPassword' of the same length as the 'user.Password' will take more time than input strings of different lenghts.
    // This 'timing' difference is leaking information about the password length.
    if(user.Password != loginPassword)
    {
        throw new Exception("Username or password is incorrect");
    }
}

//From System.String:
public static bool Equals(string a, string b)
{
    if ((object)a == b)
    {
        return true;
    }

    if (a == null || b == null)
    {
        return false;
    }
    
    // Strings of different lengths will short circuit the .Equals check.
    if (a.Length != b.Length)
    {
        return false;
    }

    // Will compare the content of the two strings, character by character.
    return EqualsHelper(a, b);
}
```

Due to the way *'!='* is implemented, it will return early when the *.Length* of *dbUser.PasswordHash* and *hashedPassword* differs. This is also true for the *content* of the string. 

To prevent this side channel attack, ensure that critical operations always take the **same amount of time**.

For example, by using a *SlowEquals()* implementation:

```
private static bool SlowEquals(byte[] a, byte[] b)
{
    uint diff = (uint)a.Length ^ (uint)b.Length;
    for (int i = 0; i < a.Length && i < b.Length; i++)
        diff |= (uint)(a[i] ^ b[i]);
    return diff == 0;
}
```
