
%{

#include "term.h"
#include "insert.h"
#include "error.h"
#include <iostream>
#include "commontypes.h"

extern int yylex();
void yyerror(const char*);

%}

%locations
%error-verbose

%union{
	QString*		str;
	Term*			ter;
	QVector<Term*>*	vter;
}

%token	<str> IDENTIFIER

%type	<str>	identifier
%type	<ter>	term
%type	<vter>	terms

%%

idpdraw		: atoms
			;

atoms		: /* empty */
			| atoms atom
			;

atom		: predatom
			| funcatom
			| error
			;

predatom	: identifier '(' terms ')' dot					{ Insert::instance()->atom(*$1,*$3,@1); delete($1); delete($3);	}
			| identifier dot								{ Insert::instance()->atom(*$1,@1); delete($1);					}
			;

funcatom	: identifier '(' terms ')' '=' term dot			{ Insert::instance()->atom(*$1,*$3,$6,@1); delete($1); delete($3);	}
			| identifier '=' term dot						{ Insert::instance()->atom(*$1,$3,@1); delete($1);					}
			;

terms		: /* empty */									{ $$ = new QVector<Term*>(0);		}
			| terms ',' term								{ $$ = $1; $$->push_back($3);		}
			| term											{ $$ = new QVector<Term*>(1,$1);	}
			;

term		: identifier '(' terms ')'						{ $$ = Insert::instance()->term(*$1,*$3,@1); delete($1);	}
			| identifier									{ $$ = Insert::instance()->term(*$1,@1); delete($1);		}
			| '[' terms ']'									{ $$ = Insert::instance()->list(*$2,@1); delete($2);		}
			;

identifier	: IDENTIFIER									{ $$ = $1;	}
			;

dot			: /* empty */
			| '.'
			;

%%

void yyerror(const char* s) {
	ParseInfo pi(yylloc.first_line,yylloc.first_column,Insert::instance()->currfile());
	Error::error(pi);
	std::cerr << s << std::endl;
}
