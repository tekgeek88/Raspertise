#!/bin/sh
cd "$(dirname "$0")";
CWD="$(pwd)"
echo $CWD
DNR="$(dotnet run --urls http://0.0.0.0:5001)"
echo $DNR
