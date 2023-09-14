---
uid: Connector_help_Generic_Mail_Sender
---

# Generic Mail Sender

With the **Generic Mail Sender** connector, you can send email via a certain SMTP server.

## About

This connector uses the **command parameter** (ID: 101, not displayed) to send the email, which is a 'pipe'-separated string that includes *from address, to address and body*. The emails are stored in a **Mail Overview table** (see "Mail Page" section below). A number of retries can be configured in case an email cannot be sent (see "General Page" section below).

## Installation and configuration

### Creation

***Virtual connection***
This connector uses a virtual connection and does not require any input during element creation.

### Configuration

To be able to use this connector, you must first fill in the parameters **SMTP Mail Server** and **SMTP Mail Port** (default 25) on the **General** page.

## Usage

### General Page

This page contains the parameters that you must configure in order to use this connector, i.e. the SMTP server and retry configuration. The **Number of Mail Retries** is the number of times the connector will try to send an email, the **Frequency of Mail Retries** is the frequency at which the retries will occur.

With the **Max. Number of Mails in Overview Table** parameter, you can configure the maximum number of emails that will be kept in the **Mail Overview Table** (see "Mail Page" section below)

### Mail Page

On this page, you can manually send an email.

The **Mail Overview Table** provides an overview of the emails that have been sent, with their status *OK, Retrying* or *Failed*. If an email was sent correctly, the status will be *OK*. If the connector is trying to send the email again after a failed attempt, the status will be *Retrying*. If the email cannot be sent after a number of retries, the status will be *Failed*.
