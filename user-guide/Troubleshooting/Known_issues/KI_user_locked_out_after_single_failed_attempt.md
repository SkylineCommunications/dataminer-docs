---
uid: KI_user_locked_out_after_single_failed_attempt
---

# User locked out after single login attempt

## Affected versions

From DataMiner 9.5.0 [CU12]/9.6.3 onwards.<!-- RN 20426 -->

## Cause

A failed login attempt will result in an additional attempt by SLNet in order to check if the password was expired. In addition, Cube will automatically and silently try to log in at startup with saved credentials, which will also lead to four additional login attempts in case the password had been changed. Cube will also try to automatically reconnect every second in the background under certain conditions. As a result of this, if the security policy only allows a small number of login attempts (e.g. 5), one failed attempt can already cause a user to be locked out.

## Fix

No fix is available yet.

## Workaround

Adjust the security policy on the DataMiner server to allow 10 or even 15 attempts to introduce some tolerance to one or two consecutive failed login attempts.

In case a local security policy is used:

1. Run `secpol.msc` (for a local security policy) or `gpmc.msc` (in case a group policy is used).

1. Go to *Account Policies* > *Account Lockout Policy*.

1. Adjust the *Account lockout threshold* so more attempts are allowed.

## Description

Users get locked out after a single failed login attempt, even if the security policy allows several attempts (e.g. 5).
