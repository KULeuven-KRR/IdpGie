%output=Parser.cs 
%namespace IdpGie.Parser
%parsertype IdpParser

%using IdpGie;

%tokentype Token

%visibility public

%partial
%union{
    public String          str;
    public Term            ter;
    public HeadTail<Term>  vter;
}

%sharetokens
%start idpdraw

%YYSTYPE StateStructure
%YYLTYPE LexSpan

%token	IDENTIFIER STRING OBR CBR DOT OFB CFB OPA
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

predatom	: identifier OBR terms CBR DOT					{ Insert::instance()->atom(*$1,*$3,@1); delete($1); delete($3);	}
			| identifier DOT								{ Insert::instance()->atom(*$1,@1); delete($1);					}
			;

funcatom	: identifier OBR terms CBR OPA term DOT			{ Insert::instance()->atom(*$1,*$3,$6,@1); delete($1); delete($3);	}
			| identifier OPA term dot						{ Insert::instance()->atom(*$1,$3,@1); delete($1);					}
			;

terms		: /* empty */									{ $$ = null;}
            | term                                          { $$ = new HeadTail<Term>($1);}
            | term COMMA terms                              { $$ = new HeadTail<term>($1,$3);}
			;

term		: identifier OBR terms CBR						{ $$ = Insert::instance()->term(*$1,*$3,@1); delete($1);	}
			| identifier									{ $$ = Insert::instance()->term(*$1,@1); delete($1);		}
			| OFB terms CFB									{ $$ = Insert::instance()->list(*$2,@1); delete($2);		}
			;

identifier	: IDENTIFIER									{ $$ = $1;	}
			;

dot			: /* empty */
			| DOT
			;

%%