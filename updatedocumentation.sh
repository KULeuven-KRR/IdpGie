git checkout master
cd IdpGie/bin/Debug
monodocer -assembly:IdpGie.exe -path:xmldoc -pretty -name:IdpGie -overrides
mdoc export-html-webdoc -i xmldoc -o htmldoc
git checkout development
