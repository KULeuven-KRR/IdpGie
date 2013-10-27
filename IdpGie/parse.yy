%output=Parser.cs 
%namespace IdpGie.Parser
%parsertype IdpParser

%using System.Linq;
%using IdpGie.Utils;

%tokentype Token

%visibility public

%union{
    public String                       str;
    public IFunctionInstance            ter;
    public HeadTail<IFunctionInstance>  vter;
    public IAtom                        atm;
    public HeadTail<IAtom>              vatm;
    public ITheoryItem                  thi;
    public HeadTail<ITheoryItem>        vthi;
}

%sharetokens
%start idpdraw

%YYSTYPE StateStructure
%YYLTYPE LexSpan

%token IDENTIFIER STRING OBR CBR DOT OFB CFB OPA COMMA FLT INT IMPLY
%type   <str>   identifier
%type   <ter>   term list
%type   <vter>  terms
%type   <atm>   atom predatom
%type   <vatm>  body
%type   <thi>   element clause
%type   <vthi>  items

%%

idpdraw     : items                                         {this.result = new DrawTheory($1.ToList());}
            ;

items       : /* empty */                                   {$$ = null;}
            | DOT                                           {$$ = null;}
            | element DOT items                             {$$ = new HeadTail<ITheoryItem>($1,$3);}
            ;

element     : clause                                        {$$ = $1;}
            | atom                                          {$$ = $1;}
            ;

clause      : atom IMPLY body                               {$$ = new PositiveClause($1,$3);}
            ;

body        : /* empty */                                   {$$ = null;}
            | atom COMMA body                               {$$ = new HeadTail<IAtom>($1,$3);}
            ;

atom        : predatom                                      {$$ = $1;}
            | error                                         {$$ = null;}
            ;

predatom    : identifier OBR terms CBR                      {$$ = this.Context.GetAtom($1,$3);}
            | identifier                                    {$$ = this.Context.GetAtom($1);}
            ;

terms       : /* empty */                                   { $$ = null;}
            | term                                          { $$ = new HeadTail<IFunctionInstance>($1);}
            | term COMMA terms                              { $$ = new HeadTail<IFunctionInstance>($1,$3);}
            ;

term        : identifier OBR terms CBR                      { $$ = this.Context.GetFunctionInstance($1,$3);}
            | identifier                                    { $$ = this.Context.GetFunctionInstance($1);}
            | list                                          { $$ = $1;}
            | INT                                           { $$ = new IdpdIntegerFunctionInstance(@1.ToString());}
            | FLT                                           { $$ = new IdpdFloatFunctionInstance(@1.ToString());}
            | STRING                                        { $$ = new IdpdStringFunctionInstance(@1.LiteralString());}
            ;

list        : OFB terms CFB                                 { $$ = ArrayFunction.ToInstance($2);}
            ;

identifier  : IDENTIFIER                                    { $$ = @1.ToString();}
            ;

%%

private LocalInputContext context;
private DrawTheory result;

public LocalInputContext Context {
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
    this.context = new LocalInputContext();
}