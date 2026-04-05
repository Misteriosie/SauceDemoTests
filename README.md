# SauceDemo UI Test Automation

## Project Overview

This repository contains UI automated tests for the SauceDemo website:
https://www.saucedemo.com/

The framework was refactored from a folder-based structure into a layered multi-project architecture based on separate class libraries.

Covered use cases:
- UC-1: Login form validation when only username is provided
- UC-2: Login with valid credentials
- UC-3: Add product to shopping cart

## Tech Stack

- C#
- NUnit
- Selenium WebDriver
- FluentAssertions
- Firefox
- Edge

## Architecture

The solution is split into separate projects by responsibility:

- `SauceDemo.Framework.Core`  
  Core abstractions, enums, configuration models, constants

- `SauceDemo.Framework.Web`  
  Selenium infrastructure, driver factory, driver manager, waits, element actions, logging

- `SauceDemo.Framework.Pages`  
  Page Object Model classes and reusable UI components

- `SauceDemo.Framework.TestData`  
  Data-driven test sources and test case providers

- `SauceDemo.Tests`  
  NUnit test project containing UC-1, UC-2, UC-3 test scenarios

## Design Decisions

- Layered architecture with separate class libraries
- Page Object Model
- Factory-based browser creation
- Data-driven testing with `TestCaseSource`
- Parallel test execution
- Execution logging through NUnit `TestContext`
- CSS selectors for locating elements

## Covered Scenarios

### UC-1: Login form with only username provided
1. Enter any username
2. Enter password
3. Clear the password field
4. Click **Login**
5. Verify error message: **Password is required**

### UC-2: Login with valid credentials
1. Enter standard user credentials
2. Click **Login**
3. Verify that inventory page contains:
   - burger menu button
   - `Swag Labs` title
   - shopping cart icon
   - sorting dropdown
   - inventory items list

### UC-3: Add product to shopping cart
1. Login with standard user
2. Open any product details page
3. Add product to cart
4. Verify shopping cart badge count

## Test Execution

The same tests are executed for:
- Firefox
- Edge

Tests support parallel execution and use a data-driven approach.

## Configuration

Configuration is stored in `SauceDemo.Tests/appsettings.json`.

Example settings:
- `BaseUrl`
- `DefaultTimeoutSeconds`
- `Headless`

Make sure the configuration file is copied to the output directory.

## How to Run

1. Open the solution in Visual Studio
2. Restore NuGet packages
3. Build the solution
4. Open **Test Explorer**
5. Run all tests

## Expected Result

All implemented test cases for UC-1, UC-2, and UC-3 should pass in both supported browsers.

## Notes

This solution was reorganized specifically to match the requirement of using layered architecture with separate class libraries instead of a single project structured only by folders.