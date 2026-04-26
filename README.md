# MCP .NET Project

This repository contains a Model Context Protocol (MCP) server implemented in .NET.

## How to Run with VS Code and GitHub Copilot

Follow these steps to enable and use the MCP server in your development environment.

### 1. Prerequisites
- **VS Code**: Version 1.99 or later.
- **GitHub Copilot Extension**: Installed and active.
- **.NET SDK**: Installed on your machine.

### 2. Enable MCP in VS Code
1. Open **Settings** (`Ctrl+,`).
2. Search for `chat.mcp.enabled`.
3. Ensure the checkbox is **checked**.

### 3. Configure the MCP Server
This project already includes a configuration file at `.vscode/mcp.json`. To ensure VS Code recognizes it:

1. Open the **Command Palette** (`Ctrl+Shift+P`).
2. Type **"MCP: Open Workspace Configuration"** and select it.
3. If the file is empty, you can copy the content from `.vscode/mcp.json` into it, or ensure VS Code is pointed to the correct workspace file.

The configuration should look like this:
```json
{
    "servers": {
        "console-mcp": {
            "type": "stdio",
            "command": "dotnet",
            "args": [
                "run",
                "--project",
                "./src/ConsoleMCPTest/ConsoleMCPTest/ConsoleMCPTest.csproj"
            ]
        }
    }
}
```

### 4. Use in GitHub Copilot Chat
1. Open **GitHub Copilot Chat** (`Ctrl+Alt+I`).
2. Switch to **Agent Mode** (look for the "Agent" toggle or dropdown in the chat window).
3. Click the **Tools** icon (looks like a small toolbox or gear) in the chat interface.
4. You should see `console-mcp` listed. Ensure it is enabled.
5. You can now ask Copilot to perform actions using the tools provided by this MCP server.

### 5. Troubleshooting
- **Path Issues**: Ensure the path to the `.csproj` file in `mcp.json` is correct relative to your workspace root.
- **Logs**: Use the Command Palette and type **"MCP: List Servers"** to check the status and logs of your server if it fails to start.
- **Build**: Run `dotnet build` in the `src/ConsoleMCPTest` directory to ensure the project compiles correctly before running.