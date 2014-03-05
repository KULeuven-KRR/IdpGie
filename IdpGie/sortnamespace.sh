#!/bin/bash
grep "namespace IdpGie.$1" *.cs | grep -o "^[^:]*" | while read fl
do
	mv "$fl" "$2"
done
