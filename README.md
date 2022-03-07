# Supervisor GUI
A fork of Supervisor converting from a commandline app to a Windows Form app, collecting it's monitored process(es) from a config file instead of commandline arguments.

Supervisor is a 64 bit .NET 4.8 Windows application that allows you to define a number of programms to start, monitor and automatically restart in the event they fail, optionally emailing alerts whenever an application is restarted.

When run this version of Supervisor runs as a System Tray icon, you'll find it by the clock, right click to access the settings:

![Systray Icon Image](https://github.com/Mister-A/Supervisor/blob/master/Docs/systrayicon.png?raw=true)

Add your chosen applications via the UI:
![Configure Monitors](https://github.com/Mister-A/Supervisor/blob/master/Docs/AddAppsUI.png?raw=true)

Configure monitor interval and optional email alerts:
![Configure Monitors](https://github.com/Mister-A/Supervisor/blob/master/Docs/SettingsUI.png?raw=true)

## Release with installer
https://github.com/Mister-A/Supervisor/releases/tag/1.0GUI

Application icon from <a href="https://www.flaticon.com/free-icons/supervision" title="supervision icons">Supervision icons created by Freepik - Flaticon</a>


.
## Original command line version:
# Supervisor
Simple process supervisor for Windows. Download built app here: [https://github.com/chebum/Supervisor/releases/tag/1.0](https://github.com/chebum/Supervisor/releases/tag/1.0)

## Usage examples
Start and monitor one app:

	supervisor myapp.exe
                
Start and monitor two apps:

	supervisor app1.exe "Path With Spaces\app2.exe"

Start two apps with arguments:

	supervisor "app1.exe arg1" """Path With Spaces\app1.exe"" ""argument with spaces"""
