# Supervisor GUI
A fork of Supervisor converting from a commandline app to a Windows Form app, collecting it's monitored process(es) from a config file instead of commandline arguments.

Application icon from <a href="https://www.flaticon.com/free-icons/supervision" title="supervision icons">Supervision icons created by Freepik - Flaticon</a>

When run this version of Supervisor runs as a System Tray icon, you'll find it by the clock, right click to access the settings:

![Systray Icon Image](https://github.com/Mister-A/Supervisor/blob/[master]/Installer/systrayicon.png?raw=true)

## Release with installer
TBC




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
