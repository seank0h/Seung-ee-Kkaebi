#!/bin/bash

kill -9 `netstat -tnlp|grep 9000|gawk '{ print $7 }'|grep -o '[0-9]*'`
kill -9 `netstat -tnlp|grep 9001|gawk '{ print $7 }'|grep -o '[0-9]*'`
kill -9 `netstat -tnlp|grep 9002|gawk '{ print $7 }'|grep -o '[0-9]*'`
kill -9 `netstat -tnlp|grep 9003|gawk '{ print $7 }'|grep -o '[0-9]*'`
kill -9 `netstat -tnlp|grep 9004|gawk '{ print $7 }'|grep -o '[0-9]*'`
kill -9 `netstat -tnlp|grep 9005|gawk '{ print $7 }'|grep -o '[0-9]*'`
kill -9 `netstat -tnlp|grep 9006|gawk '{ print $7 }'|grep -o '[0-9]*'`
kill -9 `netstat -tnlp|grep 9007|gawk '{ print $7 }'|grep -o '[0-9]*'`
kill -9 `netstat -tnlp|grep 9008|gawk '{ print $7 }'|grep -o '[0-9]*'`
kill -9 `netstat -tnlp|grep 9009|gawk '{ print $7 }'|grep -o '[0-9]*'`
kill -9 `netstat -tnlp|grep 9010|gawk '{ print $7 }'|grep -o '[0-9]*'`
kill -9 `netstat -tnlp|grep 9011|gawk '{ print $7 }'|grep -o '[0-9]*'`
kill -9 `netstat -tnlp|grep 9012|gawk '{ print $7 }'|grep -o '[0-9]*'`
kill -9 `netstat -tnlp|grep 9013|gawk '{ print $7 }'|grep -o '[0-9]*'`
kill -9 `netstat -tnlp|grep 9014|gawk '{ print $7 }'|grep -o '[0-9]*'`
kill -9 `netstat -tnlp|grep 9015|gawk '{ print $7 }'|grep -o '[0-9]*'`

echo "Server Stop..."