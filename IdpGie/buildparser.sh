clear

mono ../Libraries/gplex.exe lex.ll
mono ../Libraries/gppg.exe /gplex /no-lines /verbose parse.yy
