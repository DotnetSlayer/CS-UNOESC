//Comentário de uma linha

/*
    Comentário de 
    Múltiplas Linhas
*/

//Declarando Variáveis
using Aula01;

int number;
//Atribuindo Valor
number = 10;

//Declarando Constante
const int DAYS_IN_WEEK = 7;

//Imprimindo String Concatenada
Console.WriteLine($"A Semana tem {DAYS_IN_WEEK} dias.");

// new TipoEnumerador() -> invoca o método construtor do objeto
// Toda classe tem o seu construtor padrão implícito sem argumentos ou parâmetros
// É possivel sobescrever este método especificando argumentos
// Todavia, se fizermos, perdemos o original implícito e precisaremos defini-lo explicitamente
TipoEnumerador tipoEnum = new TipoEnumerador();

TipoEnumerador.Language enumEnglish =
 tipoEnum.GetLanguageEnum("inglês");

Console.WriteLine( $"O enum de english é {enumEnglish}" );



