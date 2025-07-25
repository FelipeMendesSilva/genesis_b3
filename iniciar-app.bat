@echo off
title Inicializador da Aplicação CDB

set DOCKER_PORT="4200"
REM Abrir no navegador
timeout /t 2 > nul
start http://localhost:%DOCKER_PORT%


echo Construindo imagens Docker...
docker-compose up --build

echo.
echo Aguarde a execução dos containers e acesse http://localhost:%DOCKER_PORT%
echo.
echo Pressione qualquer tecla para sair, ou deixe esta janela aberta.
pause