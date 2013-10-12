%output=Parser.cs 
%namespace IdpGie.Parser
%parsertype IdpParser

%using System.Linq;
%using IdpGie.Utils;

%tokentype Token

%visibility public

%union{
    public String                      str;
    public FunctionInstance            ter;
    public HeadTail<FunctionInstance>  vter;
    public Atom                        atm;
    public HeadTail<Atom>              vatm;
}

%sharetokens
%start idpdraw

%YYSTYPE StateStructure
%YYLTYPE LexSpan

%token	IDENTIFIER STRING OBR CBR DOT OFB CFB OPA COMMA
%type	<str>	identifier
%type	<ter>	term
%type	<vter>	terms
%type   <atm>   atom predatom
%type   <vatm>  atoms

%%

idpdraw		: atoms                                         {this.result = new DrawTheory($1.ToList());}
			;

atoms		: /* empty */                                   {$$ = null;}
            | DOT                                           {$$ = null;}
			| atom DOT atoms                                {$$ = new HeadTail<Atom>($1,$3);}
			;

atom		: predatom                                      {$$ = $1;}
//			| funcatom
			| error                                         {$$ = null;}
			;

predatom	: identifier OBR terms CBR				    	{$$ = this.Context.CreateAtom($1,$3);}
			| identifier							    	{$$ = this.Context.CreateAtom($1);}
			;

/*funcatom	: identifier OBR terms CBR OPA term DOT			{ Insert::instance()->atom(*$1,*$3,$6,@1); delete($1); delete($3);	}
			| identifier OPA term dot						{ Insert::instance()->atom(*$1,$3,@1); delete($1);					}
			;*/

terms		: /* empty */									{ $$ = null;}
            | term                                          { $$ = new HeadTail<FunctionInstance>($1);}
            | term COMMA terms                              { $$ = new HeadTail<FunctionInstance>($1,$3);}
			;

term		: identifier OBR terms CBR						{$$ = this.Context.CreateFunctionInstance($1,$3);}
			| identifier									{$$ = this.Context.CreateFunctionInstance($1);}
//			| OFB terms CFB									{ $$ = Insert::instance()->list(*$2,@1); delete($2);		}
			;

identifier	: IDENTIFIER									{ $$ = @1.ToString();}
			;

/*dot		:
			| DOT
			; */

%%

private InputContext context;
private DrawTheory result;

public InputContext Context {
    get {
        return this.context;
    }
    set {
        this.context = value;
    }
}

public DrawTheory Result {
    get {
        return this.result;
    }
}
  
public IdpParser (ScanBase sb) : base(sb) {
    this.context = new InputContext();
}