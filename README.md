# Sending Emails with MailKit/MimeKit

This project demonstrates how to send emails programmatically using the **MailKit** and **MimeKit** libraries in C#. These libraries provide a robust and flexible way to create and send emails via an SMTP server, supporting features like attachments, secure connections (SSL/TLS), and authentication.

## Key Features

- Configure SMTP server connection details.
- Create and customize email messages (e.g., sender, recipient, subject, body).
- Add optional attachments.
- Establish a secure connection with SMTP authentication.
- Send emails and gracefully disconnect.

## Basic Steps to Send an Email

1. **Set up SMTP Server Connection Details**: Define the SMTP host, port, and credentials (e.g., username and password).
2. **Create the Email Message**: Use `MimeMessage` (or `MailMessage`) to construct the email, specifying the sender, recipient, subject, and body content.
3. **Add Recipients, Sender, and Subject**: Populate the "To," "From," and "Subject" fields of the email.
4. **Add Email Content and Attachments**: Include plain text or HTML content, and optionally attach files (e.g., images, PDFs).
5. **Open SMTP Connection**: Connect to the SMTP server using MailKit's `SmtpClient`.
6. **Authenticate and Secure the Connection**: Perform authentication and enable SSL/TLS for security.
7. **Send the Email and Disconnect**: Transmit the email to the server and close the connection cleanly.
