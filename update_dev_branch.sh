#!/usr/bin/env bash
git add .
git commit -m 'update dev branch'
git push
git push origin dev:main --force
