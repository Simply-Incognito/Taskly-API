# Taskly

Simple task management REST API built with ASP.NET Core (.NET 10).

## Overview
`Taskly` exposes endpoints to create, read, update, and delete task items.

## Prerequisites
- Visual Studio 2026 or later (with .NET 10 workload)
- .NET 10 SDK
- Git

## Quick start (CLI)
1. Clone:
   - `git clone <repo-url>`
   - `cd <repo-folder>`

2. Restore and build:
   - `dotnet restore`
   - `dotnet build`
	- https://github.com/Simply-Incognito/Taskly-API

3. Run:
   - `dotnet run --project Taskly` (or open solution in Visual Studio and press F5)

4. Open the API
   - Default launch URL: `https://localhost:{port}/api/tasks`

## Working with Visual Studio 2026
- Open the `.sln` in Visual Studio 2026.
- Ensure the startup project is set to `Taskly`.
- Use the debugger or IIS Express profile as needed.

## Testing
- If you add tests, put them under a `tests/` folder and run `dotnet test`.

## Contributing
- Please follow repository coding conventions. Add `.editorconfig` and `CONTRIBUTING.md` if not present.
- Create a branch for your work, commit changes with clear messages, and open a pull request.

Example git workflow:
- `git checkout -b feat/your-feature`
- `git add .`
- `git commit -m "Add <short description>"`
- `git push origin feat/your-feature`
- Open a PR on the repository host.

## License
Add a `LICENSE` file for your preferred license.
