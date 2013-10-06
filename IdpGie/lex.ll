%{

#include "term.h"
#include "options.h"
#include "parse.tab.hh"
#include "commontypes.h"

extern Options options;

// Handle line and column numbers
//	call advanceline() each time a newline is read
//	call advancecol() each time a token is read
unsigned int prevlength = 0;
void advanceline() { 
	yylloc.first_line++;	
	yylloc.first_column = 1;	
	prevlength = 0;
}
void advancecol()	{ 
	yylloc.first_column += prevlength;
	prevlength = yyleng;						
}

%}

%option noyywrap

WHITESPACE		[\r ]*
ID				[^ \[\]()=,\.\r\t\n\"]*
STR				\"[^\n\"]*\"

%%

{ID}					{ advancecol();
						  yylval.str = new QString(yytext);
						  return IDENTIFIER;		
						}
{STR}					{ advancecol();
						  yylval.str = new QString(yytext);
						  return IDENTIFIER;		
						}
{WHITESPACE}            { advancecol();				
						}
"\t"					{ advancecol(); 
						  prevlength = options._tabLength;		
						}
.                       { advancecol();
						  return *yytext;			
						}
\n                      { advanceline();			
						}

%%
