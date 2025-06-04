# Messenger

Messenger is a small client/server chat application for Windows.  It consists of
a WinForms based server and client along with a few supporting libraries and an
installer.  Users can register, authenticate and exchange messages over a local
network.

## Prerequisites

- Windows with [.NET&nbsp;9.0](https://dotnet.microsoft.com/) installed
- [Visual&nbsp;Studio](https://visualstudio.microsoft.com/) 2024 or newer (includes MSBuild)

## Build

1. Open `Messenger.sln` in Visual Studio.
2. Restore NuGet packages if prompted.
3. Choose **Release** or **Debug** configuration and build the solution.

The server and client executables will be placed in each project’s `bin` directory.
You can also invoke `msbuild Messenger.sln` from a Developer Command Prompt.

## Run

### Server

Launch `MessengerServer.exe` from `MessengerServer/bin/<Configuration>` to start the
server interface.  It listens on TCP port **1100** by default; ensure this port
is accessible to your clients.

### Client

Run `Messenger Client.exe` from `Messenger Client/Messenger Client/bin/<Configuration>`.
By default the client attempts to connect to `127.0.0.1:1100`.  Adjust the IP
address and port in `config.bin` or through the client settings if needed.  Start
the server first and then connect one or more clients to begin chatting.

## License

This project is licensed under the [Apache License 2.0](LICENSE).
