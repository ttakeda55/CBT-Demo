echo off
rem for %%V in ( %temp%\Student\*.msi ) do %%V
if exist %temp%\Student_VetNorse_demo\setup.exe %temp%\Student_VetNorse_demo\setup.exe
del %1
