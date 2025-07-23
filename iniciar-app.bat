@echo off
title Inicializador da Aplicação CDB

REM 🔹 Caminho IIS Express
set IIS_EXE="%ProgramFiles(x86)%\IIS Express\iisexpress.exe"
set SITE_PATH="%~dp0CdbBack\Publish"
set API_PORT="44347"

REM 🔹 Docker para Angular
set FRONTEND_PATH="%~dp0CdbFront"
set DOCKER_IMAGE="angular-frontend"
set DOCKER_PORT="4200"

echo Iniciando API via IIS Express... 
start "" %IIS_EXE% /path:%SITE_PATH% /port:%API_PORT%

echo Construindo imagem Docker do Angular...
docker build -t %DOCKER_IMAGE% %FRONTEND_PATH%

echo Executando contêiner Angular na porta %DOCKER_PORT%...
docker run -d --rm -p %DOCKER_PORT%:80 --name %DOCKER_IMAGE%_container %DOCKER_IMAGE%

REM Abrir no navegador
timeout /t 2 > nul
start http://localhost:%DOCKER_PORT%

echo.
echo Tudo rodando! Aplicações disponíveis:
echo - Frontend:   http://localhost:%DOCKER_PORT%
echo.
echo Pressione qualquer tecla para sair, ou deixe esta janela aberta.
pause