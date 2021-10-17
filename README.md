# Bibli Hollow Application
## Overview
Book shopping is always difficult but when you live in Gothan or Mordor book shopping is almost imposible. *BibliHollow Books* allows you 
to get the books you want in those hard to reach locations! Bibibli Hollow allows for customers in Narnia, Gotham and Mordor to purchase
their books with ease and provides top notch customer service.

It's up on azure: https://biblihollow.azurewebsites.net/

## Tech Stack:
* C#
* EF Core
* ASP.NET MVC
* PostgreSQL DB
* Github Actions
* Azure 
* Xunit
* Moq
* Serilog

## Functionality:
* Add a new customer
* Search customers by name
* Display details of an order
* Place orders to store locations for customers
* View order history of customer
* View order history of location
* View location inventory
* The customer should be able to purchase multiple products
* Order histories should have the option to be sorted by date (latest to oldest and vice versa) or cost (least expensive to most expensive)
* The manager should be able to replenish inventory

## User Stories
* As a customer, I can use my username and password to sign in.
* As a customer, I can check if I already have an existing account when signing up.
* As a customer, I can select a store and add location to my profile.
* As a customer, I can view a list of available products. 
* As a customer, I can select multiple products and add quantity to a shopping cart. 
* As a customer, I can get notified if I put quantities that are more than in stock.
* As a customer, I can view a shopping cart and go back to shopping.
* As a customer, I can view a shopping cart if I have logged out without checking out.
* As a customer, I can edit or delete items in a shopping cart.
* As a customer, I can get confirmation if my order is placed successfully. 
* As a customer, I can view my order histories with details. 
* As a customer, I can change my userinforamtion and change my default location.
* As an admin, I can choose a location.
* As an admin, I can add a new location.
* As an admin, I can edit an existing location.
* As an admin, I can add a new product.
* As an admin, I can edit an existing product.
* As an admin, I can view and select products that have no inventory yet. 
* As an admin, I can add inventory of a specific product to a specific location.
* As an admin, I can view inventory stock by location.
* As an admin, I can replenish inventory to a specific product.

## Additional Features
* Exception Handling
* Input validation
* Logging
* Unit tests
* Use Moq and Sqlite for testing
* DB methods are tested
* Data are persisted
* Use PostgreSQL DB to store data
* Use code first approach to establish a connection to the DB
* WebApp is deployed using Azure App Services
* A CI/CD pipeline is established use Azure Pipelines
* Use ASP.NET MVC for the UI
* DB structure is 3NF
* Have an ER Diagram

#ERD
https://lucid.app/lucidchart/443f1e26-325e-4973-b900-f3fcd2b45953/edit?invitationId=inv_2600fa5b-4357-47ab-ab1a-d3c05c4d6387
