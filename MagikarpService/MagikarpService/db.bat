@echo off
cd "%~dp0"

docker-compose -f compose-db.yml up -d --build

if %ERRORLEVEL% neq 0 (
    echo =========== Docker Compose failed! ===========
    EXIT /B
)