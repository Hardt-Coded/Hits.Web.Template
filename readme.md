# Hits.Web.Template [![NuGet](https://img.shields.io/nuget/v/SAFEr.Template.svg?style=flat-square)](https://www.nuget.org/packages/SAFEr.Template/)

Strongly opinionated modification of amazing [SAFE Stack Template](https://safe-stack.github.io/) and [SAFEr.Template](https://github.com/Dzoukr/SAFEr.Template) for full-stack development in F#. 🔥 Now with Azure Functions (isolated) backend support!

## Installation

Install Hits.Web.Template:

    dotnet new --install Hits.Web.Template

Create new directory for your kick-ass full-stack next-unicorn app:

    mkdir NextUnicornApp
    cd NextUnicornApp

Create Application:

    dotnet new HitsWeb


Restore dotnet tools:

    dotnet tool restore

And start it in development mode:

    dotnet run

Your application is now running on:

    http://localhost:8080 // fable frontend
    http://localhost:7071 // backend API for Azure Functions


## Disclaimer

I stole...
I mean I was inspired by the Idea from https://github.com/Dzoukr/SAFEr.Template and only changed the code a little bit and removed paket and use nuget.

- Fable 4
- Feliz
- Feliz.Elmish
- Vite
- DaisyUI
- Nuget