---
uid: BPA_Password_Strength
---

# Password Strength

Weak passwords are a bad practice and easy to guess or crack. We recommend changing all default passwords to strong (preferably randomly generated) passwords. The recommended minimum length is 14 characters.

This BPA test will verify whether the database passwords are strong enough. It will analyze the length of the passwords and check whether they are in the top 10,000 most common passwords. It will also detect weak, default credentials.

> [!NOTE]
> This BPA is available from DataMiner version 10.2.12 and 10.3.0 onwards.

## Metadata

- Name: Password Strength
- Description: Verifies that the DataMiner database passwords are secure
- Author: Skyline Communications
- Default Schedule: Daily

## Results

### Success

All database passwords are strong.

### Warning

Some database passwords are weak or too common.

Possible warnings:

- No credentials configured.
- No password configured.
- Default credentials configured.
- A short password (less than 14 characters).
- A very common and insecure password. This means the password was found in the top 10,000 most common passwords and should be changed.
- Uses the database superuser.

### Error

This BPA does not create errors.

### Not Executed

The databases or credentials could not be read from *DB.xml*.

## Mitigation

Make sure that the database has authentication enabled. Preferably a **custom** database user is created.
Do not use the default superuser, e.g. 'root' or 'cassandra'.

Use a Password Manager to generate a strong, secure password (preferably longer than 14 characters). Change the database passwords and update them in DataMiner.

For more information, see [Securing the DataMiner databases](https://docs.dataminer.services/user-guide/Advanced_Functionality/Security/Advanced_security_configuration/Database_security.html).

## Limitations

- The BPA can only verify database passwords.
