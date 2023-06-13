# AppointFirstTryWPF

Basically my first C# project I came up with for myself.
An appointment app for a therapist who is working with pen and paper atm so any technology I introduce will likely be an improvement. :)

-----------
TL;DR

- v0.1: Consult ticker, simplify invoicing
- v1.0: Google Calendar API connection
- v2.0: Web version for clients
------------

The app should allow to keep a record of all the consults that were had in a month and with which client.
The backbone will be a client database that holds all the usual details as well as gender and astrological signs. There will be a checkbox column to show if
the client is a current or former client. For former clients the archive box number holding documentation relevant to them will be stated as well.
At the end of the month the app should change an MS Word invoice template to reflect the amount of consults that were had in that month for every client,
give the dates, price per consult (fixed fee) and total costs.
Let's call those the ambitions for v0.1.

v1.0:
Once I learn how to use APIs I'd like to try and use the Google Calendar API to connect the app to her calendar and allow her to book the appointments directly in the app.
Maybe an automatic email to the client would be helpful as well... Alert at the end of the month to manually confirm the dates that weren't fully booked before invoices are created. 

v2.0:
Implement a web version on her website (MAUI / Blazor?). Perhaps allowing clients to log in on a page where they can cancel appointments themselves (min 24 hours prior to consult)
and maybe even allow them to request a slot. 


