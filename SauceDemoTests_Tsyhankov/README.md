# SauceDemo UI Test Automation

## Project Description

This project contains UI automated tests for the SauceDemo website:
https://www.saucedemo.com/

The solution covers the following use cases:

- UC-1: Test Login form with only Username provided
- UC-2: Test Login form with valid credentials
- UC-3: Test adding products to shopping cart

## Tech Stack

- C#
- NUnit
- Selenium WebDriver
- FluentAssertions
- Firefox
- Edge

## Project Structure

- `Core`
  - `Base` - base classes for pages and tests
  - `Config` - test configuration loading
  - `Driver` - browser factory and driver manager
  - `Logging` - logging utility
- `Pages` - Page Object Model classes
- `TestData` - data-driven test sources
- `Tests` - automated test cases
- `Utilities` - waits and reusable element actions

## Covered Test Cases

### UC-1 Test Login form with only Username provided
1. Enter any username
2. Enter password
3. Clear the Password field
4. Click Login
5. Verify error message "Password is required"

### UC-2 Test Login form with valid credentials
1. Enter username for a standard user
2. Enter password from "Password for all users"
3. Click Login
4. Verify page contains:
   - burger menu button
   - "Swag Labs" label
   - shopping cart icon
   - sorting dropdown
   - inventory items list

### UC-3 Test adding products to shopping cart
1. Login with standard user
2. Open details of any product
3. Add product to cart
4. Verify shopping cart badge count

## Test Design Notes

- CSS selectors are used for element location
- Page Object Model is used for page interactions
- Tests support parallel execution
- Logging is added through NUnit `TestContext`
- Data-driven testing is implemented with `TestCaseSource`
- The same tests run in both Firefox and Edge

## Configuration

The `appsettings.json` file contains:

- `BaseUrl`
- `DefaultTimeoutSeconds`
- `Headless`

Make sure `appsettings.json` is copied to the output directory.

## How to Run

1. Open the solution in Visual Studio
2. Restore NuGet packages
3. Build the solution
4. Open Test Explorer
5. Run all tests

## Expected Result

All three use cases should pass in both supported browsers.