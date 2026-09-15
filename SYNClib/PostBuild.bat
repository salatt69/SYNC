@echo on

set "TargetDir=%~1"

if /I "%USERNAME%" == "dud" set "build=true"

if defined build (

    copy "%TargetDir%\*.dll" "..\Build\plugins"
    if %ERRORLEVEL% EQU 0 (echo COPY DLL successful) else (echo COPY DLL failed)
    echo:

    copy "%TargetDir%\*.xml" "..\Build\plugins"
    if %ERRORLEVEL% EQU 0 (echo COPY XML successful) else (echo COPY XML failed)
    echo:

    Xcopy /E /I /Y "..\Build\plugins" "D:\r2\r2profiles\RiskOfRain2\profiles\dev\BepInEx\plugins\salattwav-SYNClib\"
    if %ERRORLEVEL% EQU 0 (echo COPY TO R2 successful) else (echo COPY TO R2 failed)
    echo:

    Xcopy /E /I /Y "..\Build\plugins" "D:\Projects\ProjectSynth\ProjectSynth_VS\Libs"
    if %ERRORLEVEL% EQU 0 (echo COPY TO SYNTH LIBS successful) else (echo COPY TO SYNTH LIBS failed)
    echo:
)
