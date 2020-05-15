#!/bin/sh
mv $1 "$(stat -c %W "$1")-$1"
