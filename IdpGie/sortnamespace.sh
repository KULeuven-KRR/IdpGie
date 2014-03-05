#!/bin/bash
grep "namespace IdpGie.$1" *.cs | grep -o "^[^:]*" | while read fl
do
	mv "$fl" "$1"
done
