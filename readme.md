# Hits.Web.Template [![NuGet](https://img.shields.io/nuget/v/SAFEr.Template.svg?style=flat-square)](https://www.nuget.org/packages/SAFEr.Template/)

Strongly opinionated modification of amazing [SAFE Stack Template](https://safe-stack.github.io/) and [SAFEr.Template](https://github.com/Dzoukr/SAFEr.Template) for full-stack development in F#. 🔥 Now with Azure Functions (isolated) backend support!

## Installation

Install SAFEr Template:

    dotnet new --install Hits.Web.Template

Create new directory for your kick-ass full-stack next-unicorn app:

    mkdir NextUnicornApp
    cd NextUnicornApp

Bootstrap your application using Giraffe 🦒:

    dotnet new HitsWeb


Restore dotnet tools:

    dotnet tool restore

And start it in development mode:

    dotnet run

Your application is now running on:

    http://localhost:8080 // fable frontend
    http://localhost:7071 // backend API for Azure Functions


## Disclaimer

I stole the Idea from https://github.com/Dzoukr/SAFEr.Template and only changed the code a little bit and removed paket and use nuget.

## Key differences from SAFE Stack template

### Folder structure

- Project folders contains names of application [AppName].Client, [AppName].Server, ...

### Client

- Fable 3 as dotnet tool
- Feliz + Feliz.DaisyUI as default
- Feliz.Router for secured routing (including fallback to default page when navigating to non-existent page)
- Feliz.UseElmish on page level
- Elmish for wrapper level
- TailwindCSS JIT as npm packages
- SharedView module for helper functions to navigate to strongly typed pages
- Public content in `public` folder
- Webpack pre-configured to support SCSS files (from `styles/styles.css`)
- Webpack pre-configured to correct SPA routing
- Femto pre-installed
- Yarn instead of npm used
- Added MSAL Helper inside

### Server

- Azure Functions

### Shared

- Remoting definition of 3 `API` modules for every Page one!

### GitHub Actions

- Continuous Integration pipeline prepared in `.github/workflows/CI.yml`