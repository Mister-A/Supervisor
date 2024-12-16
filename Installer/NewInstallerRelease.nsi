;NSIS Modern User Interface

;--------------------------------
;Include Modern UI

  !include "MUI2.nsh"

;--------------------------------
;General

  ;Name and file
  Name "Supervisor"
  OutFile "SetupSupervisor.exe"

  ;Default installation folder
  InstallDir "$PROGRAMFILES64\Supervisor\"

  ;Get installation folder from registry if available
  InstallDirRegKey HKLM "Software\Supervisor" "Install_Dir"

  ;Request application privileges
  RequestExecutionLevel admin	

;--------------------------------
;Interface Settings

  !define MUI_ABORTWARNING
  !define MUI_COMPONENTSPAGE_SMALLDESC

;--------------------------------
;Pages

  !insertmacro MUI_PAGE_WELCOME
  !insertmacro MUI_PAGE_LICENSE "License.txt"
  !insertmacro MUI_PAGE_COMPONENTS
  !insertmacro MUI_PAGE_DIRECTORY
  !insertmacro MUI_PAGE_INSTFILES
  !insertmacro MUI_PAGE_FINISH

  !insertmacro MUI_UNPAGE_WELCOME
  !insertmacro MUI_UNPAGE_CONFIRM
  !insertmacro MUI_UNPAGE_INSTFILES
  !insertmacro MUI_UNPAGE_FINISH

;--------------------------------
;Languages

  !insertmacro MUI_LANGUAGE "English"

;--------------------------------
;Installer Sections

Section "Supervisor (required)" SecMain

  SectionIn RO
  
  ; Set output path to the installation directory.
  SetOutPath $INSTDIR
  
  ; Put file there
  File "..\Supervisor.exe"
  
   ; Copy default settings to program data
  SetShellVarContext all
  SetOutPath "$LOCALAPPDATA\Supervisor\"
  ; Put file there if not exist
  SetOverwrite off 
  File "..\settings.config"


  ;allow all read write settings folder and settings file
  AccessControl::GrantOnFile "$LOCALAPPDATA\Supervisor\" "(BU)" "FullAccess"
  AccessControl::GrantOnFile "$LOCALAPPDATA\Supervisor\settings.config" "(BU)" "FullAccess"
  AccessControl::GrantOnFile "$LOCALAPPDATA\Supervisor\settings.config" "(S-1-5-32-545)" "FullAccess"
    
  ; Write the installation path into the registry
  WriteRegStr HKLM "SOFTWARE\Supervisor" "Install_Dir" "$INSTDIR"
  
  ; Write the uninstall keys for Windows
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Supervisor" "DisplayName" "Supervisor"
  WriteRegStr HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Supervisor" "UninstallString" '"$INSTDIR\uninstall.exe"'
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Supervisor" "NoModify" 1
  WriteRegDWORD HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Supervisor" "NoRepair" 1
  WriteUninstaller "uninstall.exe"
  
SectionEnd

Section "Start Menu Shortcuts" SecShort

  SectionIn 1
  CreateDirectory "$SMPROGRAMS\Supervisor"
  CreateShortCut "$SMPROGRAMS\Supervisor\Uninstall.lnk" "$INSTDIR\uninstall.exe" "" "$INSTDIR\uninstall.exe" 0
  CreateShortCut "$SMPROGRAMS\Supervisor\Supervisor.lnk" "$INSTDIR\Supervisor.exe" "" "$INSTDIR\Supervisor.exe" 0
  
SectionEnd

Section "Run at login" SecStart
  SectionIn 1
  CreateShortCut "$SMPROGRAMS\Startup\Supervisor.lnk" "$INSTDIR\Supervisor.exe" "" "$INSTDIR\Supervisor.exe" 0
  
SectionEnd

;--------------------------------
;Descriptions

  ;Language strings
  LangString DESC_SecMain ${LANG_ENGLISH} "The main Supervisor Application."
  LangString DESC_SecShort ${LANG_ENGLISH} "Add shortcuts to Supervisor in your Start Menu."
  LangString DESC_SecStart ${LANG_ENGLISH} "Automatically start Supervisor when you Login."

  ;Assign language strings to sections
  !insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
  !insertmacro MUI_DESCRIPTION_TEXT ${SecMain} $(DESC_SecMain)
  !insertmacro MUI_DESCRIPTION_TEXT ${SecShort} $(DESC_SecShort)
  !insertmacro MUI_DESCRIPTION_TEXT ${SecStart} $(DESC_SecStart)
  !insertmacro MUI_FUNCTION_DESCRIPTION_END

;--------------------------------
;Uninstaller Section

Section "Uninstall"
  
  ; Remove registry keys
  DeleteRegKey HKLM "Software\Microsoft\Windows\CurrentVersion\Uninstall\Supervisor"
  DeleteRegKey HKLM "Software\Supervisor"

  ; Remove files and uninstaller
  Delete "$INSTDIR\Supervisor.exe"
  Delete "$INSTDIR\uninstall.exe"

  ; Remove shortcuts, if any
  Delete "$SMPROGRAMS\Supervisor\*.*"
  Delete "$SMPROGRAMS\Startup\Supervisor.lnk"
  Delete "$LOCALAPPDATA\Supervisor\*.*"

  ; Remove directories used
  RMDir "$SMPROGRAMS\Supervisor"
  RMDir "$LOCALAPPDATA\Supervisor\"
  RMDir "$INSTDIR"

SectionEnd
